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


        private Boolean isThemLop = false;
        private Boolean isSuaLop = false;
        private Stack<Recovery> stackUndoLop = new Stack<Recovery>();
        private Stack<Recovery> stackRedoLop = new Stack<Recovery>();
        private String beforeUpdateStringLop;

        public FrmKhoa()
        {
            InitializeComponent();
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
            try
            {
                Program.myReader = Program.ExecSqlDataReader(strLenh);

                if (Program.myReader == null) return;
                Program.myReader.Read();
                maCS = Program.myReader.GetString(0);     // Lay maCS
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("lỗi " + ex.Message);
            }   
            finally {
                Program.myReader.Close();

            }



            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
            this.tbGiaoVienADT.Connection.ConnectionString = Program.connstr;
            this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
            this.tbLopADT.Connection.ConnectionString = Program.connstr;
            this.tbLopADT.Fill(this.DS.LOP);
            this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
            this.tbKhoaADT.Fill(this.DS.KHOA);


            if (Program.mGroup == "COSO")
            {
                cbbCoSo.Enabled = false;
                btnThem.Visibility = btnHuy.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnSua.Visibility
                       = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            //Truong thì login đó có thể đăng nhập vào bất kỳ phân mảnh  nào để xem dữ liệu 
            else if (Program.mGroup == "TRUONG")
            {
                cbbCoSo.Enabled = true;
                btnThem.Visibility = btnHuy.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnSua.Visibility
                    = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                ctxMenuLop.Visible = false;
            }


            checkStateUndoRedo();
            checkStateUndoRedoLop();


            btnHuy.Enabled = btnGhi.Enabled = btnHuyLop.Enabled = btnGhiLop.Enabled = false;

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gcKhoa.Enabled = gcLop.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;
                bdsKhoa.AddNew();
                isThem = true;
                txtCoSo.Text = maCS;
                ctxMenuLop.Enabled = false;
                txtMaKhoa.Enabled = txtTenKhoa.Enabled = true;
                txtMaKhoa.Focus();
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;

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
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
            gcKhoa.Enabled = gcLop.Enabled = true;
            txtMaKhoa.Enabled = false;
            txtTenKhoa.Enabled = false;
            ctxMenuLop.Enabled = true;
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

            if(txtMaKhoa.Text.Trim().Length > 8 )
            {
                XtraMessageBox.Show("Mã khoa không được lớn hơn 8 kí tự ", "", MessageBoxButtons.OK);
                txtMaKhoa.Focus();
                return false;
            }

            if (txtTenKhoa.Text.Trim().Length > 50)
            {
                XtraMessageBox.Show("Tên khoa không được lớn hơn 50 kí tự ", "", MessageBoxButtons.OK);
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

            if (isThemLop == true)
            {
                if (XtraMessageBox.Show("Bạn đang tạo mới lớp học, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhiLop_Click(sender, e);
                }

            }
            else if (isSuaLop == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa lớp học, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhiLop_Click(sender, e);
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
                try 
                {
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
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

                        XtraMessageBox.Show("Thêm khoa thành công!", "", MessageBoxButtons.OK);

                        checkStateUndoRedo();
                        return;
                    }
                }
                catch(Exception ex) {
                    XtraMessageBox.Show("Thêm khoa thất bại " + ex.Message, "", MessageBoxButtons.OK);

                }
                finally
                {
                    Program.myReader.Close();

                }

            }
            else if (isSua)
            {
                //Kiem tra ten mon hoc dang sua co ton tai khong 
                String sql = "EXEC SP_KT_Sua_Khoa_Ton_Tai '" + txtMaKhoa.Text.Trim() + "', N'" + txtTenKhoa.Text.Trim()  + "'";

                try
                {
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
                        XtraMessageBox.Show("Sửa khoa thành công!", "", MessageBoxButtons.OK);

                        checkStateUndoRedo();
                        return;
                    }
                }
                catch (Exception ex) {
                    XtraMessageBox.Show("Sửa khoa thất bại " + ex.Message, "", MessageBoxButtons.OK);
                }
                finally
                {
                    Program.conn.Close();

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

        private void checkStateUndoRedoLop()
        {
            if (stackRedoLop.Count > 0)
            {
                btnRedoLop.Enabled = true;
            }
            else
            {
                btnRedoLop.Enabled = false;
            }

            if (stackUndoLop.Count > 0)
            {
                btnUndoLop.Enabled = true;
            }
            else
            {
                btnUndoLop.Enabled = false;
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
            gcKhoa.Enabled = gcLop.Enabled = true;
            ctxMenuLop.Enabled = true;
            checkStateUndoRedo();
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
                Program.mCoSo = cbbCoSo.SelectedIndex;
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
                stackUndoLop.Clear();
                stackRedoLop.Clear();
                DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

                this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                this.tbGiaoVienADT.Connection.ConnectionString = Program.connstr;
                this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);

                this.tbLopADT.Connection.ConnectionString = Program.connstr;
                this.tbLopADT.Fill(this.DS.LOP);

                this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                this.tbKhoaADT.Fill(this.DS.KHOA);

                checkStateUndoRedo();
                checkStateUndoRedoLop();


                String tenCS = cbbCoSo.Text;
                String strLenh = "EXEC SP_Lay_MaCS_Tu_TenCS N'" + tenCS + "'";
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(strLenh);

                    if (Program.myReader == null) return;
                    Program.myReader.Read();
                    maCS = Program.myReader.GetString(0);     // Lay maCS
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("lỗi " + ex.Message);
                }
                finally
                {
                    Program.myReader.Close();

                }

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
                gcKhoa.Enabled = gcLop.Enabled = true;
                ctxMenuLop.Enabled = false;
                txtTenKhoa.Enabled = true;
                txtMaKhoa.Enabled = false;
                txtTenKhoa.Focus();
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
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
                        maKhoa = ((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString().Trim();
                        stackUndo.Push(new Recovery("N'" + maKhoa + "', N'" + txtTenKhoa.Text.Trim() + "', N'" + txtCoSo.Text.Trim() + "'", "DELETE", maKhoa));

                        bdsKhoa.RemoveCurrent();
                        this.tbKhoaADT.Update(this.DS.KHOA);

                        this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                        this.tbKhoaADT.Fill(this.DS.KHOA);
                        XtraMessageBox.Show("Xóa khoa thành công!", "", MessageBoxButtons.OK);
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
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Khoa đã có lớp, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Khoa đã có giáo viên, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
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
                            checkStateUndoRedo();
                            return;
                        }
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();
                    }

                }
                else if (undo.Type.Equals("UPDATE"))
                {
                    // Neu sua thi lay mamh va tenmh truoc khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Khoa " + undo.SqlBeforeUpdateString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Tên khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();

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
                            checkStateUndoRedo();

                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedo();

                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();
                    }

                }
                else if (undo.Type.Equals("DELETE"))
                {
                    //Them lai
                    String sql = "EXEC SP_Phuc_Hoi_Them_Khoa " + undo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Tên khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
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
                            checkStateUndoRedo();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();

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
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Tên khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
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
                            checkStateUndoRedo();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();
                    }

                }
                else if (redo.Type.Equals("UPDATE"))
                {
                    //Neu sua thi lay makhoa va tenkhoa sau khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Khoa " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Tên khoa đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
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
                            checkStateUndoRedo();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();

                    }

                }
                else if (redo.Type.Equals("DELETE"))
                {
                    //Xoa di
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_Khoa " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Khoa đã có lớp, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Khoa đã có giáo viên, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
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
                            checkStateUndoRedo();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();

                    }

                }
                else return;
            }
        }

       

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            try
            {
                gcLop.Enabled = gcKhoa.Enabled = false;
                btnGhiLop.Enabled = btnHuyLop.Enabled = true;
                btnThem.Enabled = btnSua.Enabled = btnGhi.Enabled = btnTaiLai.Enabled
                    = btnHuy.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                bdsLop.AddNew();
                isThemLop = true;
                txtMaLop.Enabled = txtTenLop.Enabled = true;
                txtMaLop.Focus();
                btnThemLop.Enabled = btnSuaLop.Enabled = btnTaiLaiLop.Enabled =
                    btnUndoLop.Enabled = btnRedoLop.Enabled = btnXoaLop.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm lớp học " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            if (bdsLop.Count == 0)
            {
                XtraMessageBox.Show("Không có lớp học để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                btnThem.Enabled = btnSua.Enabled = btnGhi.Enabled = btnTaiLai.Enabled
                   = btnHuy.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                btnGhiLop.Enabled = btnHuyLop.Enabled = true;
                gcLop.Enabled = gcKhoa.Enabled = true;
                txtTenLop.Enabled = true;
                txtMaLop.Enabled = false;
                txtTenLop.Focus();
                isSuaLop = true;
                btnThemLop.Enabled = btnTaiLaiLop.Enabled = btnSuaLop.Enabled 
                    = btnXoaLop.Enabled = btnUndoLop.Enabled = btnRedoLop.Enabled = false;
                beforeUpdateStringLop = "'" + txtMaLop.Text.Trim() + "', N'" + txtTenLop.Text.Trim() + "', N'" + txtMaKhoaLop.Text.Trim() + "'";
            }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
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
                        maLop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString().Trim();
                        MessageBox.Show(maLop);
                        stackUndoLop.Push(new Recovery("N'" + maLop + "', N'" + txtTenLop.Text.Trim() + "', N'" + txtMaKhoaLop.Text.Trim() + "'", "DELETE", maLop));

                        bdsLop.RemoveCurrent();
                        this.tbLopADT.Update(this.DS.LOP);

                        this.tbLopADT.Connection.ConnectionString = Program.connstr;
                        this.tbLopADT.Fill(this.DS.LOP);
                        XtraMessageBox.Show("Xóa lớp thành công!", "", MessageBoxButtons.OK);

                        checkStateUndoRedoLop();
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

        private void btnHuyLop_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = true;

            bdsLop.CancelEdit();
            btnHuyLop.Enabled = btnGhiLop.Enabled = false;
            isSuaLop = isThemLop = false;
            txtMaLop.Enabled = false;
            txtTenLop.Enabled = false;
            btnThemLop.Enabled = btnTaiLaiLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = true;
            this.tbLopADT.Connection.ConnectionString = Program.connstr;
            this.tbLopADT.Fill(this.DS.LOP);
            gcLop.Enabled = gcKhoa.Enabled = true;
            checkStateUndoRedoLop();

        }

        private void btnGhiLop_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateEmptyLop(); //Kiem tra ma va ten lop hoc empty
            if (!isValid) return;
            btnHuyLop.Enabled = btnGhiLop.Enabled = false;
            if (isThemLop)
            {
                //Kiem tra ma va ten mon hoc ton tai
                String sql = "EXEC SP_KT_Lop_Ton_Tai '" + txtMaLop.Text.Trim() + "', N'" + txtTenLop.Text.Trim() + "'";
                try
                {

                    Program.myReader = Program.ExecSqlDataReader(sql);

                    if (Program.myReader == null) return;

                    Program.myReader.Read();
                    String kq = Program.myReader.GetString(0);

                    if (kq.Equals("1"))
                    {
                        txtMaLop.Focus();
                        btnHuyLop.Enabled = btnGhiLop.Enabled = true;
                        XtraMessageBox.Show("Mã lớp học đã tồn tại, vui lòng nhập mã khác", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        txtTenLop.Focus();
                        btnHuyLop.Enabled = btnGhiLop.Enabled = true;
                        XtraMessageBox.Show("Tên lớp học đã tồn tại, vui lòng nhập tên khác", "", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {

                        string maLop = txtMaLop.Text.Trim();

                        stackUndoLop.Push(new Recovery("'" + maLop + "', N'" + txtTenLop.Text.Trim() + "', N'" + txtMaKhoaLop.Text.Trim() + "'", "INSERT", maLop));

                        WriteToDBLop();

                        bdsLop.Position = bdsLop.Find("MALOP", maLop);

                        isThemLop = false;
                        XtraMessageBox.Show("Thêm lớp thành công!", "", MessageBoxButtons.OK);
                        checkStateUndoRedoLop();
                        return;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi ghi lớp học " + ex.Message, "", MessageBoxButtons.OK);
                }
                finally
                {
                    Program.myReader.Close();
                }
            }
            else if (isSuaLop)
            {

                //Kiem tra ten mon hoc dang sua co ton tai khong 
                String sql = "EXEC SP_KT_Sua_Lop_Ton_Tai '" + txtMaLop.Text.Trim() + "', N'" + txtTenLop.Text.Trim() + "'";
                try {
                    int kq = Program.ExecSqlNonQuery(sql);
                    if (kq == 1)
                    {
                        txtTenLop.Focus();
                        return;
                    }
                    else
                    {
                        string maLop = txtMaLop.Text.Trim();

                        stackUndoLop.Push(new Recovery("'" + maLop + "', N'" + txtTenLop.Text.Trim() + "', N'" + txtMaKhoaLop.Text.Trim() + "'", beforeUpdateStringLop, "UPDATE", maLop));
                        WriteToDBLop();
                        isSuaLop = false;
                        bdsLop.Position = bdsLop.Find("MALOP", maLop);
                        XtraMessageBox.Show("Sửa lớp thành công!", "", MessageBoxButtons.OK);

                        checkStateUndoRedoLop();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi sửa lớp " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                finally
                {
                    Program.conn.Close();

                }


            }
            else return;
        }

        private void btnUndoLop_Click(object sender, EventArgs e)
        {
            if (stackUndoLop.Count > 0)
            {
                //Lay cai moi them vao trong stack
                Recovery undo = stackUndoLop.Pop();

                if (undo.Type.Equals("INSERT"))
                {
                    //Neu them thi xoa no di
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_Lop " + undo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Lớp học đã có sinh viên, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Lớp học đã tồn tại trong giảng viên đăng ký, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("0")) // Xoa thanh cong
                        {
                            stackRedoLop.Push(new Recovery(undo.SqlString, "INSERT", undo.MaPosition));

                            this.tbLopADT.Connection.ConnectionString = Program.connstr;
                            this.tbLopADT.Fill(this.DS.LOP);
                            XtraMessageBox.Show("Phục hồi thành công, đã xóa lớp học", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedoLop();
                        return;

                    }
                    finally
                    {
                        Program.myReader.Close();
                    }

                }
                else if (undo.Type.Equals("UPDATE"))
                {
                    // Neu sua thi lay malop va tenlop truoc khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Lop " + undo.SqlBeforeUpdateString;
                    try {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Tên lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("0")) //Sua thanh cong
                        {
                            this.tbLopADT.Connection.ConnectionString = Program.connstr;
                            this.tbLopADT.Fill(this.DS.LOP);
                            isSuaLop = isThemLop = false;

                            bdsLop.Position = bdsLop.Find("MALOP", undo.MaPosition);
                            stackRedoLop.Push(new Recovery(undo.SqlString, undo.SqlBeforeUpdateString, undo.Type, undo.MaPosition));
                            XtraMessageBox.Show("Phục hồi thành công, đã sửa lại lớp học", "", MessageBoxButtons.OK);

                            checkStateUndoRedoLop();
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedoLop();
                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();
                    }
                    
                }
                else if (undo.Type.Equals("DELETE"))
                {
                    //Them lai
                    String sql = "EXEC SP_Phuc_Hoi_Them_Lop " + undo.SqlString;
                    try {

                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        MessageBox.Show(kq + " " + undo.SqlString );

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Tên lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("0")) // Them thanh cong
                        {
                            stackRedoLop.Push(new Recovery(undo.SqlString, undo.Type, undo.MaPosition));

                            this.tbLopADT.Connection.ConnectionString = Program.connstr;
                            this.tbLopADT.Fill(this.DS.LOP);
                            bdsLop.Position = bdsLop.Find("MALOP", undo.MaPosition);
                            XtraMessageBox.Show("Phục hồi thành công, đã thêm lại lớp học", "", MessageBoxButtons.OK);

                            checkStateUndoRedoLop();
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại "  + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedoLop();
                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();

                    }

                }
                else return;

            }
        }

        private void btnRedoLop_Click(object sender, EventArgs e)
        {
            if (stackRedoLop.Count > 0)
            {
                Recovery redo = stackRedoLop.Pop();
                if (redo.Type.Equals("INSERT"))
                {
                    //Them lai
                    String sql = "EXEC SP_Phuc_Hoi_Them_Lop " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Tên lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("0")) // Them thanh cong
                        {
                            stackUndoLop.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                            this.tbLopADT.Connection.ConnectionString = Program.connstr;
                            this.tbLopADT.Fill(this.DS.LOP);

                            bdsLop.Position = bdsLop.Find("MALOP", redo.MaPosition);
                            XtraMessageBox.Show("Phục hồi thành công, đã thêm lại lớp học", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedoLop();
                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();
                    }

                }
                else if (redo.Type.Equals("UPDATE"))
                {
                    //Neu sua thi lay malop va tenlop sau khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Lop " + redo.SqlString;
                    try {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Tên lớp học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("0")) //Sua thanh cong
                        {
                            stackUndoLop.Push(new Recovery(redo.SqlString, redo.SqlBeforeUpdateString, redo.Type, redo.MaPosition));
                            this.tbLopADT.Connection.ConnectionString = Program.connstr;
                            this.tbLopADT.Fill(this.DS.LOP);
                            isSuaLop = isThemLop = false;
                            bdsLop.Position = bdsLop.Find("MALOP", redo.MaPosition);

                            XtraMessageBox.Show("Phục hồi thành công, đã sửa lại lớp học", "", MessageBoxButtons.OK);

                            checkStateUndoRedoLop();
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedoLop();
                        return;
                    }
                    finally
                    {
                        Program.myReader.Close();
                    }

                }
                else if (redo.Type.Equals("DELETE"))
                {
                    //Xoa di
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_Lop " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Lớp học đã có sinh viên, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Lớp học đã tồn tại trong giảng viên đăng ký, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else if (kq.Equals("0")) // Xoa thanh cong
                        {
                            stackUndoLop.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                            this.tbLopADT.Connection.ConnectionString = Program.connstr;
                            this.tbLopADT.Fill(this.DS.LOP);
                            XtraMessageBox.Show("Phục hồi thành công, đã xóa lớp học", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
                            checkStateUndoRedoLop();
                            return;
                        }
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show("Phục hồi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                        checkStateUndoRedoLop();
                        return;

                    }
                    finally
                    {
                        Program.myReader.Close();

                    }

                }
                else return;
            }
        }

        private void btnTaiLaiLop_Click(object sender, EventArgs e)
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

        private void WriteToDBLop()
        {
            btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = true;
            checkStateUndoRedo();
            gcLop.Enabled = gcKhoa.Enabled = true;
            txtTenLop.Enabled = false;
            txtMaLop.Enabled = false;
            btnThemLop.Enabled = btnTaiLaiLop.Enabled = btnSuaLop.Enabled = btnXoaLop.Enabled = true;
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

        public bool ValidateEmptyLop()
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
            if (txtMaKhoaLop.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã khoa không được để trống ", "", MessageBoxButtons.OK);
                return false;
            }

            if (txtMaLop.Text.Trim().Length > 15)
            {
                XtraMessageBox.Show("Mã lớp không được lớn hơn 15 kí tự ", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return false;
            }

            if (txtTenLop.Text.Trim().Length > 40)
            {
                XtraMessageBox.Show("Tên lớp không được lớn hơn 40 kí tự ", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return false;
            }

            return true;
        }
       
    }
}
