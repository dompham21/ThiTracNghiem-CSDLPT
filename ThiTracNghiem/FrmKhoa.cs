using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class FrmKhoa : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private Stack<Recovery> stackUndo = new Stack<Recovery>();
        private Stack<Recovery> stackRedo = new Stack<Recovery>();
        private String beforeUpdateString;
        private String maCS = "";

        public FrmKhoa()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhoa.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FrmKhoa_Load(object sender, EventArgs e)
        {
            cbbCoSo.DataSource = Program.bds_dspm.DataSource;
            cbbCoSo.DisplayMember = "TENCS";
            cbbCoSo.ValueMember = "TENSERVER";

            cbbCoSo.SelectedIndex = Program.mCoSo;
            cbbCoSo.Enabled = true;

            String tenCS = cbbCoSo.Text;
            String strLenh = "EXEC SP_Lay_MaCS_Tu_TenCS N'" + tenCS + "'";
            //Thực hiện sp
            Program.myReader = Program.ExecSqlDataReader(strLenh);

            if (Program.myReader == null) return;
            Program.myReader.Read();
            maCS = Program.myReader.GetString(0);     // Lay maCS
            Program.myReader.Close();


            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)
           
            // TODO: This line of code loads data into the 'DS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.tbGiaoVienADT.Connection.ConnectionString = Program.connstr;
            this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
            
            // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.
            this.tbLopADT.Connection.ConnectionString = Program.connstr;
            this.tbLopADT.Fill(this.DS.LOP);
            
            // TODO: This line of code loads data into the 'DS.KHOA' table. You can move, or remove it, as needed.
            this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
            this.tbKhoaADT.Fill(this.DS.KHOA);

            checkStateUndoRedo();

            btnHuy.Enabled = btnGhi.Enabled = false;

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gcKhoa.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;
                bdsKhoa.AddNew();
                isThem = true;
                txtCoSo.Text = maCS;

                txtMaKhoa.Enabled = txtTenKhoa.Enabled = true;
                txtMaKhoa.Focus();
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm khoa " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;
            }
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                this.tbKhoaADT.Fill(this.DS.KHOA);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi tải lại :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void WriteToDB()
        {
            gcKhoa.Enabled = true;
            txtMaKhoa.Enabled = false;
            txtTenKhoa.Enabled = false;

            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                bdsKhoa.EndEdit();
                bdsKhoa.ResetCurrentItem();
                this.tbKhoaADT.Update(this.DS.KHOA);

                this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                this.tbKhoaADT.Fill(this.DS.KHOA);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi khoa" + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        public bool ValidateEmpty()
        {
            if (txtMaKhoa.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã khoa không được để trống ", "", MessageBoxButtons.OK);
                txtMaKhoa.Focus();
                return false;
            }

            if (txtTenKhoa.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Tên khoa không được để trống ", "", MessageBoxButtons.OK);
                txtTenKhoa.Focus();
                return false;
            }

            return true;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isThem == true)
            {
                if (XtraMessageBox.Show("Bạn đang tạo mới khoa, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa khoa, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }

            this.Close();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isValid = ValidateEmpty(); //Kiem tra ma va ten khoa empty
            if (!isValid) return;
            btnHuy.Enabled = btnGhi.Enabled = false;
            if (isThem)
            {
                //Kiem tra ma va ten mon hoc ton tai
                String sql = "EXEC SP_KT_Khoa_Ton_Tai N'" + txtMaKhoa.Text.Trim() + "', N'" + txtTenKhoa.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sql);
                if (Program.myReader == null) return;
                Program.myReader.Read();

                String kq = Program.myReader.GetString(0);
                Program.myReader.Close();
                if (kq.Equals("1"))
                {
                    txtMaKhoa.Focus();
                    btnHuy.Enabled = btnGhi.Enabled = true;
                    XtraMessageBox.Show("Mã khoa đã tồn tại, vui lòng nhập mã khác", "", MessageBoxButtons.OK);
                    return;
                }
                else if (kq.Equals("2"))
                {
                    txtTenKhoa.Focus();
                    btnHuy.Enabled = btnGhi.Enabled = true;
                    XtraMessageBox.Show("Tên khoa đã tồn tại, vui lòng nhập tên khác", "", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    string maKhoa = txtMaKhoa.Text.Trim();

                    stackUndo.Push(new Recovery("N'" + maKhoa + "', N'" + txtTenKhoa.Text.Trim() + "', N'" + txtCoSo.Text.Trim() + "'", "INSERT", maKhoa));

                    WriteToDB();

                    bdsKhoa.Position = bdsKhoa.Find("MaKH", maKhoa);

                    isThem = false;


                    checkStateUndoRedo();
                    return;
                }
            }
            else if (isSua)
            {
                //Kiem tra ten mon hoc dang sua co ton tai khong 
                String sql = "EXEC SP_KT_Sua_Khoa_Ton_Tai '" + txtMaKhoa.Text.Trim() + "', N'" + txtTenKhoa.Text.Trim()  + "'";

                int kq = Program.ExecSqlNonQuery(sql);

                if (kq == 1)
                {
                    txtTenKhoa.Focus();
                    return;
                }
                else
                {
                    string maKhoa = txtMaKhoa.Text.Trim();

                    stackUndo.Push(new Recovery("N'" + maKhoa + "', N'" + txtTenKhoa.Text.Trim() + "', N'" + txtCoSo.Text.Trim() + "'", beforeUpdateString, "UPDATE", maKhoa));
                    WriteToDB();
                    isSua = false;
                    bdsKhoa.Position = bdsKhoa.Find("MAKH", maKhoa);

                    checkStateUndoRedo();
                    return;
                }
            }
            else return;

        }

        private void checkStateUndoRedo()
        {
            if (stackRedo.Count > 0)
            {
                btnRedo.Enabled = true;
            }
            else
            {
                btnRedo.Enabled = false;
            }

            if (stackUndo.Count > 0)
            {
                btnUndo.Enabled = true;
            }
            else
            {
                btnUndo.Enabled = false;
            }

        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKhoa.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            txtMaKhoa.Enabled = false;
            txtTenKhoa.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
            this.tbKhoaADT.Fill(this.DS.KHOA);
            gcKhoa.Enabled = true;
        }

        private void cbbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Kiem tra cbbCoSo co du lieu chua
            if (cbbCoSo.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.servername = cbbCoSo.SelectedValue.ToString();
            if (cbbCoSo.SelectedIndex != Program.mCoSo)
            {
                Program.mlogin = Program.remoteLogin;
                Program.password = Program.remotePassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở mới", "", MessageBoxButtons.OK);
            }
            else
            {
                stackUndo.Clear();
                stackRedo.Clear();

                DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

                // TODO: This line of code loads data into the 'DS.GIAOVIEN' table. You can move, or remove it, as needed.
                this.tbGiaoVienADT.Connection.ConnectionString = Program.connstr;
                this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);

                // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.
                this.tbLopADT.Connection.ConnectionString = Program.connstr;
                this.tbLopADT.Fill(this.DS.LOP);

                // TODO: This line of code loads data into the 'DS.KHOA' table. You can move, or remove it, as needed.
                this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                this.tbKhoaADT.Fill(this.DS.KHOA);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsKhoa.Count == 0)
            {
                XtraMessageBox.Show("Không có khoa để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcKhoa.Enabled = true;
                txtTenKhoa.Enabled = true;
                txtMaKhoa.Enabled = false;
                txtTenKhoa.Focus();
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
                beforeUpdateString = "N'" + txtMaKhoa.Text.Trim() + "', N'" + txtTenKhoa.Text.Trim() + "', N'" + txtCoSo.Text.Trim() + "'";
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsKhoa.Count == 0)
            {
                XtraMessageBox.Show("Không có khoa để xóa!", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (bdsLop.Count > 0)
                {
                    XtraMessageBox.Show("Khoa đã có lớp, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                if (bdsGiaoVien.Count > 0)
                {
                    XtraMessageBox.Show("Khoa đã có giáo viên, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa " + ((DataRowView)this.bdsKhoa.Current).Row["TENKH"].ToString() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maKhoa = "";
                    try
                    {
                        maKhoa = ((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString();
                        stackUndo.Push(new Recovery("N'" + maKhoa + "', N'" + txtTenKhoa.Text.Trim() + "', N'" + txtCoSo.Text.Trim() + "'", "DELETE", maKhoa));

                        bdsKhoa.RemoveCurrent();
                        this.tbKhoaADT.Update(this.DS.KHOA);

                        this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                        this.tbKhoaADT.Fill(this.DS.KHOA);
                        checkStateUndoRedo();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi xóa khoa " + ex.Message, "", MessageBoxButtons.OK);
                        this.tbKhoaADT.Fill(this.DS.KHOA);
                        bdsKhoa.Position = bdsKhoa.Find("MAKH", maKhoa);
                        return;
                    }
                }
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (stackUndo.Count > 0)
            {
                //Lay cai moi them vao trong stack
                Recovery undo = stackUndo.Pop();
                if (undo.Type.Equals("INSERT"))
                {
                    //Neu them thi xoa no di
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_Khoa " + undo.SqlString;

                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Khoa đã có lớp, không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        XtraMessageBox.Show("Khoa đã có giáo viên, không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Xoa thanh cong
                    {
                        stackRedo.Push(new Recovery(undo.SqlString, "INSERT", undo.MaPosition));

                        this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                        this.tbKhoaADT.Fill(this.DS.KHOA);
                        XtraMessageBox.Show("Phục hồi thành công, đã xóa khoa", "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if (undo.Type.Equals("UPDATE"))
                {
                    // Neu sua thi lay mamh va tenmh truoc khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Khoa " + undo.SqlBeforeUpdateString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Tên khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) //Sua thanh cong
                    {
                        this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                        this.tbKhoaADT.Fill(this.DS.KHOA);
                        isSua = isThem = false;

                        bdsKhoa.Position = bdsKhoa.Find("MAKH", undo.MaPosition);
                        stackRedo.Push(new Recovery(undo.SqlString, undo.SqlBeforeUpdateString, undo.Type, undo.MaPosition));
                        XtraMessageBox.Show("Phục hồi thành công, đã sửa lại khoa", "", MessageBoxButtons.OK);

                        checkStateUndoRedo();
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if (undo.Type.Equals("DELETE"))
                {
                    //Them lai
                    String sql = "EXEC SP_Phuc_Hoi_Them_Khoa " + undo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();

                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Mã khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        XtraMessageBox.Show("Tên khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Them thanh cong
                    {
                        stackRedo.Push(new Recovery(undo.SqlString, undo.Type, undo.MaPosition));

                        this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                        this.tbKhoaADT.Fill(this.DS.KHOA);
                        bdsKhoa.Position = bdsKhoa.Find("MAKH", undo.MaPosition);
                        XtraMessageBox.Show("Phục hồi thành công, đã thêm lại khoa", "", MessageBoxButtons.OK);

                        checkStateUndoRedo();
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else return;
            }
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (stackRedo.Count > 0)
            {
                Recovery redo = stackRedo.Pop();
                if (redo.Type.Equals("INSERT"))
                {
                    //Them lai
                    String sql = "EXEC SP_Phuc_Hoi_Them_Khoa " + redo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();

                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Mã khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        XtraMessageBox.Show("Tên khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Them thanh cong
                    {
                        stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                        this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                        this.tbKhoaADT.Fill(this.DS.KHOA);

                        bdsKhoa.Position = bdsKhoa.Find("MAKH", redo.MaPosition);
                        XtraMessageBox.Show("Phục hồi thành công, đã thêm lại khoa", "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if (redo.Type.Equals("UPDATE"))
                {
                    //Neu sua thi lay makhoa va tenkhoa sau khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Khoa " + redo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Tên khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) //Sua thanh cong
                    {
                        stackUndo.Push(new Recovery(redo.SqlString, redo.SqlBeforeUpdateString, redo.Type, redo.MaPosition));
                        this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                        this.tbKhoaADT.Fill(this.DS.KHOA);
                        isSua = isThem = false;
                        bdsKhoa.Position = bdsKhoa.Find("MAKH", redo.MaPosition);

                        XtraMessageBox.Show("Phục hồi thành công, đã sửa lại khoa", "", MessageBoxButtons.OK);

                        checkStateUndoRedo();
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if (redo.Type.Equals("DELETE"))
                {
                    //Xoa di
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_Khoa " + redo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Khoa đã có lớp, không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        XtraMessageBox.Show("Khoa đã có giáo viên, không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Xoa thanh cong
                    {
                        stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                        this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                        this.tbKhoaADT.Fill(this.DS.KHOA);
                        XtraMessageBox.Show("Phục hồi thành công, đã xóa khoa", "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else return;
            }
        }
    }
}
