using DevExpress.Utils;
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
    public partial class FrmMonHoc : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private Stack<Recovery> stackUndo = new Stack<Recovery>();
        private Stack<Recovery> stackRedo = new Stack<Recovery>();
        private String beforeUpdateString;

        public FrmMonHoc()
        {
            InitializeComponent();
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {

           

            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)



            this.tbBangDiemADT.Connection.ConnectionString = Program.connstr;
            this.tbBangDiemADT.Fill(this.DS.BANGDIEM);
            this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
            this.tbBoDeADT.Fill(this.DS.BODE);
            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

            this.tbMonHoc.Connection.ConnectionString = Program.connstr;
            this.tbMonHoc.Fill(this.DS.MONHOC);

            if (Program.mGroup == "COSO")
            {
                btnRedo.Visibility = btnHuy.Visibility =
                btnThem.Visibility = btnSua.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnUndo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            //Truong thì login đó có thể đăng nhập vào bất kỳ phân mảnh  nào để xem dữ liệu 
            else if (Program.mGroup == "TRUONG")
            {
                btnRedo.Visibility = btnHuy.Visibility =
                btnThem.Visibility = btnSua.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnUndo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            checkStateUndoRedo();

            btnHuy.Enabled = btnGhi.Enabled = false;

        }


        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.tbMonHoc.Connection.ConnectionString = Program.connstr;
                this.tbMonHoc.Fill(this.DS.MONHOC);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi tải lại :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
           
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gcMonHoc.Enabled = false;

                btnGhi.Enabled = btnHuy.Enabled = true;
                bdsMonHoc.AddNew();
                isThem = true;
                txtTenMH.Enabled = txtMaMH.Enabled = true;
                txtMaMH.Focus();
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm môn học " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void WriteToDB()
        {
            gcMonHoc.Enabled = true;
            txtTenMH.Enabled = false;
            txtMaMH.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                bdsMonHoc.EndEdit();
                bdsMonHoc.ResetCurrentItem();
                this.tbMonHoc.Update(this.DS.MONHOC);

                this.tbMonHoc.Connection.ConnectionString = Program.connstr;
                this.tbMonHoc.Fill(this.DS.MONHOC);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi môn học" + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isValid = ValidateEmpty(); //Kiem tra ma va ten mon hoc empty
            if (!isValid) return;
            btnHuy.Enabled = btnGhi.Enabled = false;

            if (isThem)
            {
                //Kiem tra ma va ten mon hoc ton tai
                String sql = "EXEC SP_KT_MonHoc_Ton_Tai '" + txtMaMH.Text.Trim() + "', N'" + txtTenMH.Text.Trim() + "'";
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);

                    if (kq.Equals("1"))
                    {
                        txtMaMH.Focus();
                        btnHuy.Enabled = btnGhi.Enabled = true;
                        XtraMessageBox.Show("Mã môn học đã tồn tại, vui lòng nhập mã khác", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("2"))
                    {
                        txtTenMH.Focus();
                        btnHuy.Enabled = btnGhi.Enabled = true;
                        XtraMessageBox.Show("Tên môn học đã tồn tại, vui lòng nhập tên khác", "", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        string maMH = txtMaMH.Text.Trim();

                        stackUndo.Push(new Recovery("'" + txtMaMH.Text.Trim() + "', N'" + txtTenMH.Text.Trim() + "'", "INSERT", maMH));

                        WriteToDB();
                        bdsMonHoc.Position = bdsMonHoc.Find("MAMH", maMH);

                        isThem = false;
                        XtraMessageBox.Show("Thêm môn học thành công!", "", MessageBoxButtons.OK);
                        checkStateUndoRedo();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Thêm môn học thất bại " + ex.Message, "", MessageBoxButtons.OK);
                }
                finally
                {
                    Program.myReader.Close();

                }

            }
            else if (isSua)
            {

                //Kiem tra ten mon hoc dang sua co ton tai khong 
                String sql = "EXEC SP_KT_Sua_MonHoc_Ton_Tai '" + txtMaMH.Text.Trim() + "', N'" + txtTenMH.Text.Trim() + "'";
                try
                {
                    int kq = Program.ExecSqlNonQuery(sql);

                    if (kq == 1)
                    {
                        txtTenMH.Focus();
                        return;
                    }
                    else
                    {
                        string maMH = txtMaMH.Text.Trim();

                        stackUndo.Push(new Recovery("'" + txtMaMH.Text.Trim() + "', N'" + txtTenMH.Text.Trim() + "'", beforeUpdateString, "UPDATE", txtMaMH.Text.Trim()));
                        WriteToDB();
                        isSua = false;
                        bdsMonHoc.Position = bdsMonHoc.Find("MAMH", maMH);

                        checkStateUndoRedo();
                        XtraMessageBox.Show("Sửa môn học thành công!", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Sửa môn học thất bại " + ex.Message, "", MessageBoxButtons.OK);
                }
                finally
                {
                    Program.conn.Close();
                }
                
            }
            else return;

        }

        public bool ValidateEmpty()
        {
            if (txtMaMH.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã môn học không được để trống ", "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return false;
            }

            if (txtTenMH.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Tên môn học không được để trống ", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return false;
            }

            if (txtMaMH.Text.Trim().Length > 5)
            {
                XtraMessageBox.Show("Mã môn học không được lớn hơn 5 kí tự ", "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return false;
            }

            if (txtTenMH.Text.Trim().Length > 50)
            {
                XtraMessageBox.Show("Tên môn học không được lớn hơn 50 kí tự ", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return false;
            }

            return true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsMonHoc.Count == 0)
            {
                XtraMessageBox.Show("Không có môn học để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcMonHoc.Enabled = true;
                txtTenMH.Enabled = true;
                txtMaMH.Enabled = false;
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                beforeUpdateString = "'" + txtMaMH.Text.Trim() + "', N'" + txtTenMH.Text.Trim() + "'";
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMonHoc.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            txtTenMH.Enabled = false;
            txtMaMH.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            this.tbMonHoc.Connection.ConnectionString = Program.connstr;
            this.tbMonHoc.Fill(this.DS.MONHOC);
            gcMonHoc.Enabled = true;
            checkStateUndoRedo();

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isThem == true)
            {
                if (XtraMessageBox.Show("Bạn đang tạo mới môn học, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }
                               
            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa môn học, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }
                 
            }
            
            this.Close();
            
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsMonHoc.Count == 0)
            {
                XtraMessageBox.Show("Không có môn học để xóa!", "", MessageBoxButtons.OK);

            }
            else
            {
                if (bdsBangDiem.Count > 0)
                {
                    XtraMessageBox.Show("Môn học này đã có bảng điểm, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                if (bdsBoDeMH.Count > 0)
                {
                    XtraMessageBox.Show("Môn học này đã có bộ đề, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                if (bdsGiaoVienDKMH.Count > 0)
                {
                    XtraMessageBox.Show("Môn học này đã có giảng viên đăng ký, không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }

                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa môn học: " + ((DataRowView)this.bdsMonHoc.Current).Row["TENMH"].ToString() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maMH = "";
                    try
                    {
                        maMH = ((DataRowView)bdsMonHoc[bdsMonHoc.Position])["MAMH"].ToString();
                        stackUndo.Push(new Recovery("N'" + txtMaMH.Text.Trim() + "', N'" + txtTenMH.Text.Trim() + "'", "DELETE", maMH));

                        bdsMonHoc.RemoveCurrent();
                        this.tbMonHoc.Update(this.DS.MONHOC);
                     
                        this.tbMonHoc.Connection.ConnectionString = Program.connstr;
                        this.tbMonHoc.Fill(this.DS.MONHOC);
                        checkStateUndoRedo();
                        XtraMessageBox.Show("Xóa môn học thành công!", "", MessageBoxButtons.OK);
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi xóa môn học " + ex.Message, "", MessageBoxButtons.OK);
                        this.tbMonHoc.Fill(this.DS.MONHOC);
                        bdsMonHoc.Position = bdsMonHoc.Find("MAMH", maMH);
                        return;
                    }
                }
                else return;
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

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(stackUndo.Count > 0)
            {
                //Lay cai moi them vao trong stack
                Recovery undo = stackUndo.Pop();

                if (undo.Type.Equals("INSERT"))
                {
                    //Neu them thi xoa no di
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_MH " + undo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Môn học đã có trong bảng điểm, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Môn học đã tồn tại trong bộ đề, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("3"))
                        {
                            XtraMessageBox.Show("Môn học đã tồn tại trong giảng viên đăng ký, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Xoa thanh cong
                        {
                            stackRedo.Push(new Recovery(undo.SqlString, "INSERT", undo.MaPosition));

                            this.tbMonHoc.Connection.ConnectionString = Program.connstr;
                            this.tbMonHoc.Fill(this.DS.MONHOC);
                            XtraMessageBox.Show("Phục hồi thành công, đã xóa môn học", "", MessageBoxButtons.OK);
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
                    String sql = "EXEC SP_Phuc_Hoi_Sua_MH " + undo.SqlBeforeUpdateString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Tên môn học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) //Sua thanh cong
                        {
                            this.tbMonHoc.Connection.ConnectionString = Program.connstr;
                            this.tbMonHoc.Fill(this.DS.MONHOC);
                            isSua = isThem = false;

                            bdsMonHoc.Position = bdsMonHoc.Find("MAMH", undo.MaPosition);
                            stackRedo.Push(new Recovery(undo.SqlString, undo.SqlBeforeUpdateString, undo.Type, undo.MaPosition));
                            XtraMessageBox.Show("Phục hồi thành công, đã sửa lại môn học", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Them_MH " + undo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã môn học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Tên môn học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Them thanh cong
                        {
                            stackRedo.Push(new Recovery(undo.SqlString, undo.Type, undo.MaPosition));

                            this.tbMonHoc.Connection.ConnectionString = Program.connstr;
                            this.tbMonHoc.Fill(this.DS.MONHOC);
                            bdsMonHoc.Position = bdsMonHoc.Find("MAMH", undo.MaPosition);
                            XtraMessageBox.Show("Phục hồi thành công, đã thêm lại môn học", "", MessageBoxButtons.OK);

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

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(stackRedo.Count > 0)
            {
                Recovery redo = stackRedo.Pop();
                if (redo.Type.Equals("INSERT"))
                {
                    //Them lai
                    String sql = "EXEC SP_Phuc_Hoi_Them_MH " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã môn học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Tên môn học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Them thanh cong
                        {
                            stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                            this.tbMonHoc.Connection.ConnectionString = Program.connstr;
                            this.tbMonHoc.Fill(this.DS.MONHOC);

                            bdsMonHoc.Position = bdsMonHoc.Find("MAMH", redo.MaPosition);
                            XtraMessageBox.Show("Phục hồi thành công, đã thêm lại môn học", "", MessageBoxButtons.OK);
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
                    //Neu sua thi lay maMh va tenMH sau khi sua
                    String sql = "EXEC SP_Phuc_Hoi_Sua_MH " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Tên môn học đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) //Sua thanh cong
                        {
                            stackUndo.Push(new Recovery(redo.SqlString, redo.SqlBeforeUpdateString, redo.Type, redo.MaPosition));
                            this.tbMonHoc.Connection.ConnectionString = Program.connstr;
                            this.tbMonHoc.Fill(this.DS.MONHOC);
                            isSua = isThem = false;
                            bdsMonHoc.Position = bdsMonHoc.Find("MAMH", redo.MaPosition);

                            XtraMessageBox.Show("Phục hồi thành công, đã sửa lại môn học", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_MH " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Môn học đã có trong bảng điểm, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("2"))
                        {
                            XtraMessageBox.Show("Môn học đã tồn tại trong bộ đề, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("3"))
                        {
                            XtraMessageBox.Show("Môn học đã tồn tại trong giảng viên đăng ký, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Xoa thanh cong
                        {
                            stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                            this.tbMonHoc.Connection.ConnectionString = Program.connstr;
                            this.tbMonHoc.Fill(this.DS.MONHOC);
                            XtraMessageBox.Show("Phục hồi thành công, đã xóa môn học", "", MessageBoxButtons.OK);
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


       
    }
}
