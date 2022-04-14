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
    public partial class FrmGVDK : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private Stack<Recovery> stackUndo = new Stack<Recovery>();
        private Stack<Recovery> stackRedo = new Stack<Recovery>();
        private String beforeUpdateString;
        public FrmGVDK()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FrmGVDK_Load(object sender, EventArgs e)
        {
            cbbCoSo.DataSource = Program.bds_dspm.DataSource;
            cbbCoSo.DisplayMember = "TENCS";
            cbbCoSo.ValueMember = "TENSERVER";
            cbbCoSo.SelectedIndex = Program.mCoSo;
            cbbCoSo.Enabled = true;

            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            this.tbDSGiaoVienADT.Connection.ConnectionString = Program.connstr;
            this.tbDSGiaoVienADT.Fill(this.DS.SP_DS_GiaoVien);
            this.tbLopADT.Connection.ConnectionString = Program.connstr;
            this.tbLopADT.Fill(this.DS.LOP);
            this.tbMonHocADT.Connection.ConnectionString = Program.connstr;
            this.tbMonHocADT.Fill(this.DS.MONHOC);
            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

            cbbTrinhDo.Items.Add("A");
            cbbTrinhDo.Items.Add("B");
            cbbTrinhDo.Items.Add("C");

            cbbLanThi.Items.Add(1);
            cbbLanThi.Items.Add(2);
            if(bdsGVDK.Count > 0)
            {
                cbbLanThi.Text = ((DataRowView)this.bdsGVDK.Current).Row["LAN"].ToString();
                cbbTrinhDo.Text = ((DataRowView)this.bdsGVDK.Current).Row["TRINHDO"].ToString();
            }


            checkStateUndoRedo();

            btnHuy.Enabled = btnGhi.Enabled = false;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;

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
                this.tbLopADT.Connection.ConnectionString = Program.connstr;
                this.tbLopADT.Fill(this.DS.LOP);
                this.tbMonHocADT.Connection.ConnectionString = Program.connstr;
                this.tbMonHocADT.Fill(this.DS.MONHOC);
                this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                

                gcGVDK.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;
                cbbTenGV.Enabled = cbbTenLop.Enabled = cbbTenMon.Enabled = cbbTrinhDo.Enabled 
                    = cbbLanThi.Enabled = dateNgayThi.Enabled = numSoCau.Enabled = numThoiGian.Enabled = true;
                bdsGVDK.AddNew();
                dateNgayThi.Properties.MinValue = DateTime.Today;
                isThem = true;
                cbbTrinhDo.SelectedIndex = cbbLanThi.SelectedIndex = -1;
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = false;
                numSoCau.Value = 10;
                numThoiGian.Value = 15;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm  giáo viên đăng ký thi " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsLop.Count == 0)
            {
                XtraMessageBox.Show("Không có giáo viên đăng ký để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcGVDK.Enabled = true;
                cbbTenGV.Enabled = cbbTrinhDo.Enabled = numSoCau.Enabled = numThoiGian.Enabled = dateNgayThi.Enabled = true;
                cbbTenMon.Enabled = cbbTenLop.Enabled = cbbLanThi.Enabled = false;
                cbbTenGV.Focus();
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
                beforeUpdateString = "N'" + txtMaGV.Text.Trim() + "', N'" + txtMaLop.Text.Trim()
                                                   + "', N'" + txtMaMon.Text.Trim() + "', N'" + cbbTrinhDo.Text.Trim() + "', " + cbbLanThi.Text.Trim()
                                                   + ", '" + dateNgayThi.DateTime + "', " + numSoCau.Value + ", " + numThoiGian.Value;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsGVDK.Count == 0)
            {
                MessageBox.Show("Không có giảng viên đăng ký để xóa!", "", MessageBoxButtons.OK);

            }
            else
            {
                String sql = "EXEC SP_KT_Lop_Da_Thi N'" + txtMaLop.Text.Trim()
                   + "', N'" + txtMaMon.Text.Trim()
                   + "',  " + cbbLanThi.Text.Trim();

                int kq = Program.ExecSqlNonQuery(sql);
                if (kq == 1)
                {
                    XtraMessageBox.Show("Thông tin của giảng viên đăng ký này đã tồn tại trong bảng bảng điểm, Không thể xóa", "", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa giảng viên đăng ký của môn "
                    + ((DataRowView)this.bdsGVDK.Current).Row["MAMH"].ToString().Trim() + " lớp "
                     + ((DataRowView)this.bdsGVDK.Current).Row["MALOP"].ToString().Trim() + " lần "
                     + ((DataRowView)this.bdsGVDK.Current).Row["LAN"].ToString().Trim()
                    + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            stackUndo.Push(new Recovery("N'" + txtMaGV.Text.Trim() + "', N'" + txtMaLop.Text.Trim()
                                                    + "', N'" + txtMaMon.Text.Trim() + "', N'" + cbbTrinhDo.Text.Trim() + "', " + cbbLanThi.Text.Trim()
                                                    + ", '" + dateNgayThi.DateTime + "', " + numSoCau.Value + ", " + numThoiGian.Value, "DELETE",""));
                            bdsGVDK.RemoveCurrent();
                            //đẩy dữ liệu về adapter
                            this.tbGVDKyADT.Update(this.DS.GIAOVIEN_DANGKY);
                            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                            checkStateUndoRedo();

                        }
                        catch (Exception ex)
                        {
                            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

                            MessageBox.Show("Lỗi xóa giảng viên đăng ký " + ex.Message, "", MessageBoxButtons.OK);
                        }
                    }
                }

            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGVDK.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            cbbTenGV.Enabled = cbbTenLop.Enabled = cbbTenMon.Enabled = cbbTrinhDo.Enabled
                   = cbbLanThi.Enabled = dateNgayThi.Enabled = numSoCau.Enabled = numThoiGian.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            gcGVDK.Enabled = true;

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isValid = ValidateInput(); 
            if (!isValid) return;

            btnHuy.Enabled = btnGhi.Enabled = false;
            if (isThem)
            {
                String sql = "EXEC SP_KT_GVDK N'" + txtMaMon.Text.Trim() + "', N'" + txtMaLop.Text.Trim() + "', " + cbbLanThi.SelectedItem + "";
                if (Program.ExecSqlNonQuery(sql) == 1)
                {
                    btnHuy.Enabled = btnGhi.Enabled = true;
                    return;
                }
                else
                {


                    stackUndo.Push(new Recovery("N'" + txtMaGV.Text.Trim() + "', N'" + txtMaLop.Text.Trim()
                                                   + "', N'" + txtMaMon.Text.Trim() + "', N'" + cbbTrinhDo.Text.Trim() + "', " + cbbLanThi.Text.Trim()
                                                   + ", '" + dateNgayThi.DateTime + "', " + numSoCau.Value + ", " + numThoiGian.Value, "INSERT",""));

                    WriteToDB();


                    isThem = false;


                    checkStateUndoRedo();
                    return;


                }
            }
            else if(isSua)
            {
                stackUndo.Push(new Recovery("N'" + txtMaGV.Text.Trim() + "', N'" + txtMaLop.Text.Trim()
                                                  + "', N'" + txtMaMon.Text.Trim() + "', N'" + cbbTrinhDo.Text.Trim() + "', " + cbbLanThi.Text.Trim()
                                                  + ", '" + dateNgayThi.DateTime + "', " + numSoCau.Value + ", " + numThoiGian.Value, beforeUpdateString, "UPDATE",""));
                WriteToDB();

                isSua = false;
                checkStateUndoRedo();
                return;
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
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_GVDK " + undo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Thông tin của giảng viên đăng ký này đã tồn tại trong bảng bảng điểm, Không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Xoa thanh cong
                    {
                        stackRedo.Push(new Recovery(undo.SqlString, "INSERT", undo.MaPosition));

                        this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                        this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                        XtraMessageBox.Show("Phục hồi thành công, đã xóa giáo viên đăng ký", "", MessageBoxButtons.OK);
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
                    String sql = "EXEC SP_Phuc_Hoi_Sua_GVDK " + undo.SqlBeforeUpdateString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("0")) //Sua thanh cong
                    {
                        this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                        this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                        isSua = isThem = false;

                        stackRedo.Push(new Recovery(undo.SqlString, undo.SqlBeforeUpdateString, undo.Type, undo.MaPosition));
                        XtraMessageBox.Show("Phục hồi thành công, đã sửa lại giáo viên đăng ký", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Them_GVDK " + undo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);

                    Program.myReader.Close();

                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Đã tồn tại đăng ký thi lần thi cho môn học và lớp này, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Them thanh cong
                    {
                        stackRedo.Push(new Recovery(undo.SqlString, undo.Type, undo.MaPosition));

                        this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                        this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                        XtraMessageBox.Show("Phục hồi thành công, đã thêm lại giảng viên đăng ký", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Them_GVDK " + redo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();

                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Đã tồn tại đăng ký thi lần thi cho môn học và lớp này, không thể phục hồi", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Them thanh cong
                    {
                        stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                        this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                        this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

                        XtraMessageBox.Show("Phục hồi thành công, đã thêm lại giáo viên đăng ký", "", MessageBoxButtons.OK);
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
                    String sql = "EXEC SP_Phuc_Hoi_Sua_GVDK " + redo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    
                    if (kq.Equals("0")) //Sua thanh cong
                    {
                        stackUndo.Push(new Recovery(redo.SqlString, redo.SqlBeforeUpdateString, redo.Type, redo.MaPosition));
                        this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                        this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                        isSua = isThem = false;

                        XtraMessageBox.Show("Phục hồi thành công, đã sửa lại giáo viên đăng ký", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_GVDK " + redo.SqlString;
                    Program.myReader = Program.ExecSqlDataReader(sql);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Thông tin của giảng viên đăng ký này đã tồn tại trong bảng bảng điểm, Không thể xóa", "", MessageBoxButtons.OK);
                        return;
                    }
                    else if (kq.Equals("0")) // Xoa thanh cong
                    {
                        stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                        this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                        this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                        XtraMessageBox.Show("Phục hồi thành công, đã xóa giáo viên đăng ký", "", MessageBoxButtons.OK);
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

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
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
                if (XtraMessageBox.Show("Bạn đang tạo mới đăng ký thi, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa đăng ký thi, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }

            this.Close();
        }

        private void cbbTenGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cbbTenGV.SelectedValue != null)
                {
                    txtMaGV.Text = cbbTenGV.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cbbTenLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbTenLop.SelectedValue != null)
                {
                    txtMaLop.Text = cbbTenLop.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cbbTenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbTenMon.SelectedValue != null)
                {
                    txtMaMon.Text = cbbTenMon.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public bool ValidateInput()
        {
            
            if (txtMaGV.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã giáo viên không được để trống ", "", MessageBoxButtons.OK);
                cbbTenGV.Focus();
                return false;
            }

            if (txtMaLop.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã lớp học không được để trống ", "", MessageBoxButtons.OK);
                cbbTenLop.Focus();
                return false;
            }

            if (txtMaMon.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã môn học không được để trống ", "", MessageBoxButtons.OK);
                cbbTenMon.Focus();
                return false;
            }

            if (dateNgayThi.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Ngày thi không được để trống ", "", MessageBoxButtons.OK);
                dateNgayThi.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbbLanThi.Text.Trim()))
            {
                XtraMessageBox.Show("Lần thi không được để trống ", "", MessageBoxButtons.OK);
                cbbLanThi.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbbTrinhDo.Text.Trim()))
            {
                XtraMessageBox.Show("Trình độ thi không được để trống ", "", MessageBoxButtons.OK);
                cbbTrinhDo.Focus();
                return false;
            }

            if (numSoCau.Value.ToString().Equals(""))
            {
                XtraMessageBox.Show("Số câu thi không được để trống ", "", MessageBoxButtons.OK);
                numSoCau.Focus();
                return false;
            }

            if (numThoiGian.Value.ToString().Equals(""))
            {
                XtraMessageBox.Show("Thời gian thi không được để trống ", "", MessageBoxButtons.OK);
                numThoiGian.Focus();
                return false;
            }

            if(DateTime.Compare(DateTime.Today, dateNgayThi.DateTime) > 0)
            {
                XtraMessageBox.Show("Thời gian thi không được bé hơn ngày hiện tại ", "", MessageBoxButtons.OK);
                dateNgayThi.Focus();
                return false;
            }

            if (numSoCau.Value < 10 || numSoCau.Value > 100)
            {
                MessageBox.Show("Số câu thi phải >=10 và <=100 câu, vui lòng nhập lại", "", MessageBoxButtons.OK);
                numSoCau.Focus();
                return false;
            }

            if(numThoiGian.Value < 15 || numThoiGian.Value > 60)
            {
                MessageBox.Show("Thời gian thi phải >=15 và <=60 phút, vui lòng nhập lại", "", MessageBoxButtons.OK);
                numThoiGian.Focus();
                return false;
            }

            //------ktra thông tin đăng ký------start(đã lập hay chưa, nếu là dky lần 2 thì ktra thêm đã thi lần 1 chưa, ngày lần 2 có lớn hơn ngày lần 1 ko) 
            //------Lượt thi của Môn thi này cho lớp đó đã được tổ chức thi hai lần. Và không thể tổ chức thêm
            //------Không đủ câu hỏi để tổ chức thi.
            return true;
        }
        private void WriteToDB()
        {
            gcGVDK.Enabled = true;
            cbbTenGV.Enabled = cbbTenLop.Enabled = cbbTenMon.Enabled = cbbTrinhDo.Enabled
                    = cbbLanThi.Enabled = dateNgayThi.Enabled = numSoCau.Enabled = numThoiGian.Enabled = false;

            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                bdsGVDK.EndEdit();
                bdsGVDK.ResetCurrentItem();
                this.tbGVDKyADT.Update(this.DS.GIAOVIEN_DANGKY);

                this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi đăng ký thi" + ex.Message, "", MessageBoxButtons.OK);
            }
        }
    }
}

