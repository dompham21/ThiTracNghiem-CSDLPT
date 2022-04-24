using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class FrmSinhVien : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private Stack<Recovery> stackUndo = new Stack<Recovery>();
        private Stack<Recovery> stackRedo = new Stack<Recovery>();
        private String beforeUpdateString;
        private String beforePassword;
        public FrmSinhVien()
        {
            InitializeComponent();
        }

    
        private void FrmSinhVien_Load(object sender, EventArgs e)
        {
            cbbCoSo.DataSource = Program.bds_dspm.DataSource;
            cbbCoSo.DisplayMember = "TENCS";
            cbbCoSo.ValueMember = "TENSERVER";

            cbbCoSo.SelectedIndex = Program.mCoSo;

            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            this.tbBangDiemADT.Connection.ConnectionString = Program.connstr;
            this.tbBangDiemADT.Fill(this.DS.BANGDIEM);

            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);

            this.tbLopADT.Connection.ConnectionString = Program.connstr;
            this.tbLopADT.Fill(this.DS.LOP);

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
            }

            checkStateUndoRedo();

            btnHuy.Enabled = btnGhi.Enabled = false;
            


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

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;
               
            }
        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;
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

                DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

                this.tbBangDiemADT.Connection.ConnectionString = Program.connstr;
                this.tbBangDiemADT.Fill(this.DS.BANGDIEM);

                this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

                this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                this.tbSinhVienADT.Fill(this.DS.SINHVIEN);

                this.tbLopADT.Connection.ConnectionString = Program.connstr;
                this.tbLopADT.Fill(this.DS.LOP);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gcSinhVien.Enabled = gcLop.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;
                bdsSinhVien.AddNew();
                isThem = true;
                txtMaSV.Enabled = txtHoSV.Enabled = txtTenSV.Enabled = txtDiaChi.Enabled = dateNgaySinh.Enabled = txtPassword.Enabled = true;
                txtMaSV.Focus();
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm sinh viên " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

                this.tbBangDiemADT.Connection.ConnectionString = Program.connstr;
                this.tbBangDiemADT.Fill(this.DS.BANGDIEM);

                this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

                this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                this.tbSinhVienADT.Fill(this.DS.SINHVIEN);

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
                if (XtraMessageBox.Show("Bạn đang tạo mới sinh viên, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa sinh viên, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }

            this.Close();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isValid = ValidateEmpty(); 
            if (!isValid) return;
            btnHuy.Enabled = btnGhi.Enabled = false;

            if (isThem)
            {
                //Kiem tra ma va ten mon hoc ton tai
                String sql = "EXEC SP_KT_Sinh_Vien_Ton_Tai N'" + txtMaSV.Text.Trim() + "'";
                try
                {
                    int kq = Program.ExecSqlNonQuery(sql);
                    if (kq == 1)
                    {
                        btnHuy.Enabled = btnGhi.Enabled = true;

                        txtMaSV.Focus();
                        return;
                    }
                    else
                    {
                        string maSV = txtMaSV.Text.Trim();
                        txtPassword.Text = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text.Trim());

                        stackUndo.Push(new Recovery("N'" + maSV + "', N'" + txtHoSV.Text.Trim() + "', N'"
                        + txtMaSV.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', '" + dateNgaySinh.Text.Trim() + "', N'" + txtMaLop.Text.Trim() 
                        + "', N'" + txtPassword.Text.Trim() + "'", "INSERT", maSV));


                        WriteToDB();

                        bdsSinhVien.Position = bdsSinhVien.Find("MASV", maSV);

                        isThem = false;

                        XtraMessageBox.Show("Thêm sinh viên thành công!", "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Thêm sinh viên thất bại " + ex.Message, "", MessageBoxButtons.OK);
                }
                finally
                {
                    Program.conn.Close();   
                }
                

            }
            else if (isSua)
            {
                string maSV = txtMaSV.Text.Trim();
                if(!txtPassword.Text.Trim().Equals(beforePassword))
                {
                    txtPassword.Text = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text.Trim());

                }
                stackUndo.Push(new Recovery("N'" + maSV + "', N'" + txtHoSV.Text.Trim() + "', N'"
                    + txtMaSV.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', '" + dateNgaySinh.Text.Trim() + "', N'" + txtMaLop.Text.Trim() + "', N'" + txtPassword.Text.Trim() + "'", beforeUpdateString, "UPDATE", maSV));
                WriteToDB();
                isSua = false;
                bdsSinhVien.Position = bdsSinhVien.Find("MASV", maSV);

                checkStateUndoRedo();
                XtraMessageBox.Show("Sửa sinh viên thành công!", "", MessageBoxButtons.OK);
                return;
            }

        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSinhVien.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            txtMaSV.Enabled = txtHoSV.Enabled = txtTenSV.Enabled = txtDiaChi.Enabled = dateNgaySinh.Enabled = txtPassword.Enabled = false;

            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
            gcLop.Enabled = true;
            checkStateUndoRedo();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsSinhVien.Count == 0)
            {
                XtraMessageBox.Show("Không có sinh viên để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcSinhVien.Enabled = gcLop.Enabled = true;
                txtMaSV.Enabled = false;
                txtHoSV.Enabled = txtTenSV.Enabled = txtDiaChi.Enabled = dateNgaySinh.Enabled = txtPassword.Enabled = true;
                txtMaLop.Enabled = false;
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled  
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                beforePassword = txtPassword.Text.Trim();
                beforeUpdateString = "N'" + txtMaSV.Text.Trim() + "', N'" + txtHoSV.Text.Trim() + "', N'"
                    + txtTenSV.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', '" + dateNgaySinh.Text.Trim()  
                    + "', N'" + txtMaLop.Text.Trim() + "', N'" + txtPassword.Text.Trim() + "'";
            }
        }
        public bool ValidateEmpty()
        {
            if (txtMaSV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã sinh viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return false;
            }

            if (txtHoSV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Họ sinh viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtHoSV.Focus();
                return false;
            }

            if (Regex.IsMatch(txtHoSV.Text, Program.FULLNAME_PATTERN) == false)
            {
                XtraMessageBox.Show("Họ của người chỉ có chữ cái và khoảng trắng", "", MessageBoxButtons.OK);
                txtHoSV.Focus();
                return false;
            }

            if (Regex.IsMatch(txtTenSV.Text, Program.FULLNAME_PATTERN) == false)
            {
                XtraMessageBox.Show("Tên của người chỉ có chữ cái và khoảng trắng", "", MessageBoxButtons.OK);
                txtHoSV.Focus();
                return false;
            }

            if (txtTenSV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Tên sinh viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtTenSV.Focus();
                return false;
            }

            if (txtDiaChi.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Địa chỉ sinh viên không được để trống, vui lòng nhập lại", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            if (CalculateAge(dateNgaySinh.DateTime) < 18)
            {
                MessageBox.Show("Sinh viên chưa đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK);
                dateNgaySinh.Focus();
                return false;
            }

            if (txtMaSV.Text.Trim().Length > 8)
            {
                XtraMessageBox.Show("Mã sinh viên không được lớn hơn 8 kí tự ", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return false;
            }

            if (txtHoSV.Text.Trim().Length > 50)
            {
                XtraMessageBox.Show("Họ sinh viên không được lớn hơn 50 kí tự ", "", MessageBoxButtons.OK);
                txtHoSV.Focus();
                return false;
            }

            if (txtTenSV.Text.Trim().Length > 10)
            {
                XtraMessageBox.Show("Tên sinh viên không được lớn hơn 10 kí tự ", "", MessageBoxButtons.OK);
                txtTenSV.Focus();
                return false;
            }

            if (txtDiaChi.Text.Trim().Length > 100)
            {
                XtraMessageBox.Show("Địa chỉ sinh viên không được lớn hơn 100 kí tự ", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }

            return true;
        }

        private void WriteToDB()
        {
            gcSinhVien.Enabled = gcLop.Enabled = true;
            txtMaSV.Enabled = txtHoSV.Enabled = txtTenSV.Enabled = txtDiaChi.Enabled = dateNgaySinh.Enabled = txtPassword.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                bdsSinhVien.EndEdit();
                bdsSinhVien.ResetCurrentItem();
                this.tbSinhVienADT.Update(this.DS.SINHVIEN);
                this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi sinh viên" + ex.Message, "", MessageBoxButtons.OK);
            }
        }
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsSinhVien.Count == 0)
            {
                XtraMessageBox.Show("Không có sinh viên để xóa!", "", MessageBoxButtons.OK);
            }
            else
            {
                if (bdsBangDiem.Count > 0)
                {
                    XtraMessageBox.Show("Sinh viên này đã có bảng điểm, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên: " + ((DataRowView)this.bdsSinhVien.Current).Row["TEN"].ToString() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maSV = "";
                    try
                    {
                        maSV = ((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString();
                        stackUndo.Push(new Recovery("N'" + maSV + "', N'" + txtHoSV.Text.Trim() + "', N'"
                    + txtMaSV.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', '" + dateNgaySinh.Text.Trim() + "', N'" + txtMaLop.Text.Trim() + "', N'" + txtPassword.Text.Trim() + "'", "DELETE", maSV));

                        bdsSinhVien.RemoveCurrent();
                        this.tbSinhVienADT.Update(this.DS.SINHVIEN);

                        this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                        this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                        checkStateUndoRedo();
                        XtraMessageBox.Show("Xóa sinh viên thành công!", "", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi xóa sinh viên " + ex.Message, "", MessageBoxButtons.OK);
                        this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                        bdsSinhVien.Position = bdsSinhVien.Find("MASV", maSV);
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
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_SV " + undo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Sinh viên đã có bảng điểm, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Xoa thanh cong
                        {
                            stackRedo.Push(new Recovery(undo.SqlString, "INSERT", undo.MaPosition));

                            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                            XtraMessageBox.Show("Phục hồi thành công, đã xóa sinh viên", "", MessageBoxButtons.OK);
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
                else if (undo.Type.Equals("UPDATE"))
                {
                    // Neu sua thi lay mamh va tenmh truoc khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_SV " + undo.SqlBeforeUpdateString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("0")) //Sua thanh cong
                        {
                            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                            isSua = isThem = false;

                            bdsSinhVien.Position = bdsSinhVien.Find("MASV", undo.MaPosition);
                            stackRedo.Push(new Recovery(undo.SqlString, undo.SqlBeforeUpdateString, undo.Type, undo.MaPosition));
                            XtraMessageBox.Show("Phục hồi thành công, đã sửa lại sinh viên", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Them_SV " + undo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã sinh viên đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Them thanh cong
                        {
                            stackRedo.Push(new Recovery(undo.SqlString, undo.Type, undo.MaPosition));

                            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                            bdsSinhVien.Position = bdsSinhVien.Find("MASV", undo.MaPosition);
                            XtraMessageBox.Show("Phục hồi thành công, đã thêm lại sinh viên", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Them_SV " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã sinh viên đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Them thanh cong
                        {
                            stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);

                            bdsSinhVien.Position = bdsSinhVien.Find("MASV", redo.MaPosition);
                            XtraMessageBox.Show("Phục hồi thành công, đã thêm lại sinh viên", "", MessageBoxButtons.OK);
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
                    //Neu sua thi lay thong tin sinh vien sau khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_SV " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("0")) //Sua thanh cong
                        {
                            stackUndo.Push(new Recovery(redo.SqlString, redo.SqlBeforeUpdateString, redo.Type, redo.MaPosition));
                            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                            isSua = isThem = false;
                            bdsSinhVien.Position = bdsSinhVien.Find("MASV", redo.MaPosition);

                            XtraMessageBox.Show("Phục hồi thành công, đã sửa lại sinh viên", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_SV " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Sinh viên đã có bảng điểm, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Xoa thanh cong
                        {
                            stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                            this.tbSinhVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbSinhVienADT.Fill(this.DS.SINHVIEN);
                            XtraMessageBox.Show("Phục hồi thành công, đã xóa sinh viên", "", MessageBoxButtons.OK);
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
            }
        }
    }
}
