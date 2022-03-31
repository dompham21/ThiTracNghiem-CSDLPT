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
    public partial class FrmLop : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private Stack<Recovery> stackUndo = new Stack<Recovery>();
        private Stack<Recovery> stackRedo = new Stack<Recovery>();
        private String beforeUpdateString;
        public FrmLop()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FrmLop_Load(object sender, EventArgs e)
        {
            cbbCoSo.DataSource = Program.bds_dspm.DataSource;
            cbbCoSo.DisplayMember = "TENCS";
            cbbCoSo.ValueMember = "TENSERVER";

            cbbCoSo.SelectedIndex = Program.mCoSo;
            cbbCoSo.Enabled = true;


            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            // TODO: This line of code loads data into the 'DS.KHOA' table. You can move, or remove it, as needed.
            this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
            this.tbKhoaADT.Fill(this.DS.KHOA);
            // TODO: This line of code loads data into the 'DS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'DS.SINHVIEN' table. You can move, or remove it, as needed.
            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
            // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.
            this.tbLopADT.Connection.ConnectionString = Program.connstr;
            this.tbLopADT.Fill(this.DS.LOP);

            checkStateUndoRedo();
            cbbTenKhoa.Enabled = false;
            btnHuy.Enabled = btnGhi.Enabled = false;

        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;
            }

            if(!txtMaKhoa.Text.Trim().Equals(""))
            {
                cbbTenKhoa.SelectedValue = txtMaKhoa.Text.Trim();
            }
            


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
                this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                this.tbKhoaADT.Fill(this.DS.KHOA);
                this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                // TODO: This line of code loads data into the 'DS.SINHVIEN' table. You can move, or remove it, as needed.
                this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.
                this.tbLopADT.Connection.ConnectionString = Program.connstr;
                this.tbLopADT.Fill(this.DS.LOP);
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLop.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            txtMaLop.Enabled = false;
            cbbTenKhoa.Enabled = false;
            txtTenLop.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            this.tbLopADT.Connection.ConnectionString = Program.connstr;
            this.tbLopADT.Fill(this.DS.LOP);
            gcLop.Enabled = true;
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.tbLopADT.Connection.ConnectionString = Program.connstr;
                this.tbLopADT.Fill(this.DS.LOP);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi tải lại :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isThem == true)
            {
                if (XtraMessageBox.Show("Bạn đang tạo mới lớp học, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa lớp học, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }

            this.Close();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isValid = ValidateEmpty(); //Kiem tra ma va ten lop hoc empty
            if (!isValid) return;
            btnHuy.Enabled = btnGhi.Enabled = false;

            if (isThem)
            {
                //Kiem tra ma va ten mon hoc ton tai
                String sql = "EXEC SP_KT_Lop_Ton_Tai '" + txtMaLop.Text.Trim() + "', N'" + txtTenLop.Text.Trim() + "'";

                Program.myReader = Program.ExecSqlDataReader(sql);
                if (Program.myReader == null) return;
                Program.myReader.Read();

                String kq = Program.myReader.GetString(0);
                Program.myReader.Close();

                if (kq.Equals("1"))
                {
                    txtMaLop.Focus();
                    btnHuy.Enabled = btnGhi.Enabled = true;
                    XtraMessageBox.Show("Mã lớp học đã tồn tại, vui lòng nhập mã khác", "", MessageBoxButtons.OK);
                    return;
                }
                else if (kq.Equals("2"))
                {
                    txtTenLop.Focus();
                    btnHuy.Enabled = btnGhi.Enabled = true;
                    XtraMessageBox.Show("Tên lớp học đã tồn tại, vui lòng nhập tên khác", "", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    string maLop = txtMaLop.Text.Trim();

                    stackUndo.Push(new Recovery("'" + maLop + "', N'" + txtTenLop.Text.Trim() + "', N'"+ txtMaKhoa.Text.Trim() + "'", "INSERT", maLop));

                    WriteToDB();

                    bdsLop.Position = bdsLop.Find("MALOP", maLop);

                    isThem = false;


                    checkStateUndoRedo();
                    return;


                }
            }
            else if (isSua)
            {

                //Kiem tra ten mon hoc dang sua co ton tai khong 
                String sql = "EXEC SP_KT_Sua_Lop_Ton_Tai '" + txtMaLop.Text.Trim() + "', N'" + txtTenLop.Text.Trim() + "'";

                int kq = Program.ExecSqlNonQuery(sql);

                if (kq == 1)
                {
                    txtTenLop.Focus();
                    return;
                }
                else
                {
                    string maLop = txtMaLop.Text.Trim();

                    stackUndo.Push(new Recovery("'" + maLop + "', N'" + txtTenLop.Text.Trim() + "', N'" + txtMaKhoa.Text.Trim()  + "'", beforeUpdateString, "UPDATE", maLop));
                    WriteToDB();
                    isSua = false;
                    bdsLop.Position = bdsLop.Find("MALOP", maLop);

                    checkStateUndoRedo();
                    return;
                }
            }
            else return;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsLop.Count == 0)
            {
                XtraMessageBox.Show("Không có lớp để xóa!", "", MessageBoxButtons.OK);

            }
            else
            {
                if (bdsSinhVien.Count > 0)
                {
                    XtraMessageBox.Show("Lớp học đã có sinh viên, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                if (bdsGVDK.Count > 0)
                {
                    XtraMessageBox.Show("Lớp học đã có giảng viên đăng ký, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa lớp học: " + ((DataRowView)this.bdsLop.Current).Row["TENLOP"].ToString() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maLop = "";
                    try
                    {
                        maLop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
                        stackUndo.Push(new Recovery("N'" + maLop + "', N'" + txtTenLop.Text.Trim() + "', N'" + txtMaKhoa.Text.Trim() + "'", "DELETE", maLop));

                        bdsLop.RemoveCurrent();
                        this.tbLopADT.Update(this.DS.LOP);

                        this.tbLopADT.Connection.ConnectionString = Program.connstr;
                        this.tbLopADT.Fill(this.DS.LOP);
                        checkStateUndoRedo();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi xóa lớp học " + ex.Message, "", MessageBoxButtons.OK);
                        this.tbLopADT.Fill(this.DS.LOP);
                        bdsLop.Position = bdsLop.Find("MALOP", maLop);
                        return;
                    }
                }
                else return;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gcLop.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;
                cbbTenKhoa.Enabled = true;

                bdsLop.AddNew();
                isThem = true;

                txtMaLop.Enabled = txtTenLop.Enabled = true;
                txtMaLop.Focus();
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = false;
                cbbTenKhoa.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm lớp học " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsLop.Count == 0)
            {
                XtraMessageBox.Show("Không có lớp học để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcLop.Enabled = true;
                txtTenLop.Enabled = true;
                txtMaLop.Enabled = false;
                txtTenLop.Focus();
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
                beforeUpdateString = "'" + txtMaLop.Text.Trim() + "', N'" + txtTenLop.Text.Trim() + "', N'" + txtMaKhoa.Text.Trim() + "'";
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
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_Lop " + undo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Lớp học đã có sinh viên, không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        XtraMessageBox.Show("Lớp học đã tồn tại trong giảng viên đăng ký, không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Xoa thanh cong
                    {
                        stackRedo.Push(new Recovery(undo.SqlString, "INSERT", undo.MaPosition));

                        this.tbLopADT.Connection.ConnectionString = Program.connstr;
                        this.tbLopADT.Fill(this.DS.LOP);
                        XtraMessageBox.Show("Phục hồi thành công, đã xóa lớp học", "", MessageBoxButtons.OK);
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
                    // Neu sua thi lay malop va tenlop truoc khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Lop " + undo.SqlBeforeUpdateString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Tên lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) //Sua thanh cong
                    {
                        this.tbLopADT.Connection.ConnectionString = Program.connstr;
                        this.tbLopADT.Fill(this.DS.LOP);
                        isSua = isThem = false;

                        bdsLop.Position = bdsLop.Find("MALOP", undo.MaPosition);
                        stackRedo.Push(new Recovery(undo.SqlString, undo.SqlBeforeUpdateString, undo.Type, undo.MaPosition));
                        XtraMessageBox.Show("Phục hồi thành công, đã sửa lại lớp học", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Them_Lop " + undo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();

                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Mã lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        XtraMessageBox.Show("Tên lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Them thanh cong
                    {
                        stackRedo.Push(new Recovery(undo.SqlString, undo.Type, undo.MaPosition));

                        this.tbLopADT.Connection.ConnectionString = Program.connstr;
                        this.tbLopADT.Fill(this.DS.LOP);
                        bdsLop.Position = bdsLop.Find("MALOP", undo.MaPosition);
                        XtraMessageBox.Show("Phục hồi thành công, đã thêm lại lớp học", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Them_Lop " + redo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();

                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Mã lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        XtraMessageBox.Show("Tên lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Them thanh cong
                    {
                        stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                        this.tbLopADT.Connection.ConnectionString = Program.connstr;
                        this.tbLopADT.Fill(this.DS.LOP);

                        bdsLop.Position = bdsLop.Find("MALOP", redo.MaPosition);
                        XtraMessageBox.Show("Phục hồi thành công, đã thêm lại lớp học", "", MessageBoxButtons.OK);
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
                    //Neu sua thi lay malop va tenlop sau khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Lop " + redo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Tên lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) //Sua thanh cong
                    {
                        stackUndo.Push(new Recovery(redo.SqlString, redo.SqlBeforeUpdateString, redo.Type, redo.MaPosition));
                        this.tbLopADT.Connection.ConnectionString = Program.connstr;
                        this.tbLopADT.Fill(this.DS.LOP);
                        isSua = isThem = false;
                        bdsLop.Position = bdsLop.Find("MALOP", redo.MaPosition);

                        XtraMessageBox.Show("Phục hồi thành công, đã sửa lại lớp học", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_Lop " + redo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Lớp học đã có sinh viên, không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        XtraMessageBox.Show("Lớp học đã tồn tại trong giảng viên đăng ký, không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Xoa thanh cong
                    {
                        stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                        this.tbLopADT.Connection.ConnectionString = Program.connstr;
                        this.tbLopADT.Fill(this.DS.LOP);
                        XtraMessageBox.Show("Phục hồi thành công, đã xóa lớp học", "", MessageBoxButtons.OK);
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

        private void WriteToDB()
        {
            gcLop.Enabled = true;
            txtTenLop.Enabled = false;
            txtMaLop.Enabled = false;
            cbbTenKhoa.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                bdsLop.EndEdit();
                bdsLop.ResetCurrentItem();
                this.tbLopADT.Update(this.DS.LOP);

                this.tbLopADT.Connection.ConnectionString = Program.connstr;
                this.tbLopADT.Fill(this.DS.LOP);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi lớp học" + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        public bool ValidateEmpty()
        {
            if (txtMaLop.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã lớp học không được để trống ", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return false;
            }

            if (txtTenLop.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Tên lớp học không được để trống ", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return false;
            }
            if(txtMaKhoa.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã khoa không được để trống ", "", MessageBoxButtons.OK);
                cbbTenKhoa.Focus();
                return false;
            }

            return true;
        }

        private void cbbTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTenKhoa.SelectedValue != null)
            {
                txtMaKhoa.Text = cbbTenKhoa.SelectedValue.ToString().Trim();
            }
        }
    }
}
