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
    public partial class FrmBoDe : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private Stack<Recovery> stackUndo = new Stack<Recovery>();
        private Stack<Recovery> stackRedo = new Stack<Recovery>();
        private String beforeUpdateString;
        public FrmBoDe()
        {
            InitializeComponent();
        }

       

        private void FrmBoDe_Load(object sender, EventArgs e)
        {
            

            DS.EnforceConstraints = false;

            this.tbCTBThiADT.Connection.ConnectionString = Program.connstr;
            this.tbCTBThiADT.Fill(this.DS.CT_BAITHI);
            this.tbMonHocADT.Connection.ConnectionString = Program.connstr;
            this.tbMonHocADT.Fill(this.DS.MONHOC);
            
            

            if (Program.mGroup.Equals("GIANGVIEN"))
            {
                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
            }
            else
            {
                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                this.tbBoDeADT.Fill(this.DS.BODE);
                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                this.tbDSGVienADT.Fill(this.DS.DSGV);
            }

            cbbTrinhDo.Items.Add("A");
            cbbTrinhDo.Items.Add("B");
            cbbTrinhDo.Items.Add("C");
            cbbDapAn.Items.Add("A");
            cbbDapAn.Items.Add("B");
            cbbDapAn.Items.Add("C");
            cbbDapAn.Items.Add("D");
            if (bdsBoDe != null && bdsBoDe.Count > 0)
            {
                cbbDapAn.Text = ((DataRowView)this.bdsBoDe.Current).Row["DAP_AN"].ToString();
                cbbTrinhDo.Text = ((DataRowView)this.bdsBoDe.Current).Row["TRINHDO"].ToString();
            }

            if (Program.mGroup == "COSO")
            {
                btnThem.Visibility = btnGhi.Visibility = btnSua.Visibility = btnXoa.Visibility = btnHuy.Visibility
                    = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            //Truong thì login đó có thể đăng nhập vào bất kỳ phân mảnh  nào để xem dữ liệu 
            else if (Program.mGroup == "TRUONG")
            {
                btnThem.Visibility = btnGhi.Visibility = btnSua.Visibility = btnXoa.Visibility = btnHuy.Visibility
                    = btnUndo.Visibility = btnRedo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
               

                gcBoDe.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;

                
                bdsBoDe.AddNew();
                isThem = true;

                txtMaCH.Enabled = cbbTenMon.Enabled = cbbDapAn.Enabled =
                    cbbTrinhDo.Enabled = rtxtA.Enabled = rtxtB.Enabled = rtxtC.Enabled = rtxtD.Enabled = rtxtNoiDung.Enabled = true;
                txtMaCH.Focus();
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled 
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                cbbDapAn.SelectedIndex = cbbTrinhDo.SelectedIndex = -1;
                if (Program.mGroup.Equals("GIANGVIEN"))
                {
                    cbbTenGV.Enabled = false;
                    cbbTenGV.SelectedIndex = 0;

                }
                else
                {
                    cbbTenGV.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm bộ đề " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsBoDe.Count == 0)
            {
                XtraMessageBox.Show("Không có bộ đề để sửa!", "", MessageBoxButtons.OK);
            }
            else
            {
                if (Program.mGroup.Equals("GIANGVIEN"))
                {
                    cbbTenGV.SelectedIndex = 0;
                }
                else
                {
                    cbbTenGV.Enabled = true;
                }

                cbbTenMon.Enabled = cbbDapAn.Enabled = cbbTrinhDo.Enabled 
                    = rtxtA.Enabled = rtxtB.Enabled = rtxtC.Enabled = rtxtD.Enabled = rtxtNoiDung.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcBoDe.Enabled = true;
                txtMaCH.Enabled = false;
                rtxtNoiDung.Focus();
                isSua = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled 
                    = btnUndo.Enabled = btnRedo.Enabled = btnXoa.Enabled = false;
                beforeUpdateString = txtMaCH.Text.Trim() + ", N'" + txtMaMon.Text.Trim() + "', N'" + txtMaGV.Text.Trim() + "',N'" +
                    cbbTrinhDo.Text.Trim() + "', N'" + cbbDapAn.Text.Trim() + "', N'" + rtxtNoiDung.Text.Trim() + "', N'" +
                    rtxtA.Text.Trim() + "', N'" + rtxtB.Text.Trim() + "', N'" + rtxtC.Text.Trim() + "', N'" + rtxtD.Text.Trim() + "'";
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsBoDe.Count == 0)
            {
                XtraMessageBox.Show("Không có bộ đề để xóa!", "", MessageBoxButtons.OK);
                return;

            }
            else if(bdsCTBT.Count > 0)
            {
                XtraMessageBox.Show("Câu này đã tồn tại trong bài thi của sinh viên, không được xóa", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
               
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa bộ đề: " + ((DataRowView)this.bdsBoDe.Current).Row["CAUHOI"].ToString() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    String maCH = "";
                    try
                    {
                        maCH = ((DataRowView)bdsBoDe[bdsBoDe.Position])["CAUHOI"].ToString();
                        stackUndo.Push(new Recovery(maCH + ", N'" + txtMaMon.Text.Trim() + "', N'" + txtMaGV.Text.Trim() + "',N'" +
                        cbbTrinhDo.Text.Trim() + "', N'" + cbbDapAn.Text.Trim() + "', N'" + rtxtNoiDung.Text.Trim() + "', N'" +
                        rtxtA.Text.Trim() + "', N'" + rtxtB.Text.Trim() + "', N'" + rtxtC.Text.Trim() + "', N'" + rtxtD.Text.Trim() + "'", "DELETE", maCH));

                        bdsBoDe.RemoveCurrent();
                        this.tbBoDeADT.Update(this.DS.BODE);

                        if (Program.mGroup.Equals("GIANGVIEN"))
                        {
                            this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                            this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                            this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
                        }
                        else
                        {
                            this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                            this.tbBoDeADT.Fill(this.DS.BODE);
                            this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbDSGVienADT.Fill(this.DS.DSGV);
                        }
                        checkStateUndoRedo();

                        XtraMessageBox.Show("Xóa đề thi thành công!", "", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi xóa bộ đề " + ex.Message, "", MessageBoxButtons.OK);
                        if (Program.mGroup.Equals("GIANGVIEN"))
                        {
                            this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                            this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                            this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
                        }
                        else
                        {
                            this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                            this.tbBoDeADT.Fill(this.DS.BODE);
                            this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                            this.tbDSGVienADT.Fill(this.DS.DSGV);
                        }
                        bdsBoDe.Position = bdsBoDe.Find("CAUHOI", maCH);
                        return;
                    }
                }
                else return;
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsBoDe.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            txtMaCH.Enabled = cbbTenMon.Enabled = cbbTenGV.Enabled = cbbDapAn.Enabled =
                    cbbTrinhDo.Enabled = rtxtA.Enabled = rtxtB.Enabled = rtxtC.Enabled = rtxtD.Enabled = rtxtNoiDung.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            if (Program.mGroup.Equals("GIANGVIEN"))
            {
                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
            }
            else
            {
                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                this.tbBoDeADT.Fill(this.DS.BODE);
                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                this.tbDSGVienADT.Fill(this.DS.DSGV);
            }
            checkStateUndoRedo();
            gcBoDe.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isValid = ValidateInput(); 
            if (!isValid) return;
            btnHuy.Enabled = btnGhi.Enabled = false;

            if (isThem)
            {
                //Kiem tra ma va ten mon hoc ton tai
                String sql = "EXEC SP_KT_Bo_De_Ton_Tai " + txtMaCH.Text.Trim();

                try
                {
                    int kq = Program.ExecSqlNonQuery(sql);



                    if (kq == 1)
                    {
                        txtMaCH.Focus();
                        btnHuy.Enabled = btnGhi.Enabled = true;
                        return;
                    }
                    else
                    {
                        string maCH = txtMaCH.Text.Trim();

                        stackUndo.Push(new Recovery(maCH + ", N'" + txtMaMon.Text.Trim() + "', N'" + txtMaGV.Text.Trim() + "',N'" +
                        cbbTrinhDo.Text.Trim() + "', N'" + cbbDapAn.Text.Trim() + "', N'" + rtxtNoiDung.Text.Trim() + "', N'" +
                        rtxtA.Text.Trim() + "', N'" + rtxtB.Text.Trim() + "', N'" + rtxtC.Text.Trim() + "', N'" + rtxtD.Text.Trim() + "'", "INSERT", maCH));

                        WriteToDB();

                        bdsBoDe.Position = bdsBoDe.Find("CAUHOI", maCH);

                        isThem = false;


                        checkStateUndoRedo();
                        XtraMessageBox.Show("Thêm đề thi thành công", "", MessageBoxButtons.OK);

                        return;


                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Thêm đề thi thất bại " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                finally
                {
                    Program.conn.Close(); 
                }
                
            }
            else if (isSua)
            {


                string maCH = txtMaCH.Text.Trim();

                stackUndo.Push(new Recovery(maCH + ", N'" + txtMaMon.Text.Trim() + "', N'" + txtMaGV.Text.Trim() + "',N'" +
                    cbbTrinhDo.Text.Trim() + "', N'" + cbbDapAn.Text.Trim() + "', N'" + rtxtNoiDung.Text.Trim() + "', N'" +
                    rtxtA.Text.Trim() + "', N'" + rtxtB.Text.Trim() + "', N'" + rtxtC.Text.Trim() + "', N'" + rtxtD.Text.Trim() + "'", beforeUpdateString, "UPDATE", maCH));
                WriteToDB();
                isSua = false;
                bdsBoDe.Position = bdsBoDe.Find("CAUHOI", maCH);
                XtraMessageBox.Show("Sửa đề thi thành công!", "", MessageBoxButtons.OK);
                checkStateUndoRedo();
                return;
                
            }
            else return;
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
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_Bo_De " + undo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Bộ đề đã có trong chi tiết bài thi, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Xoa thanh cong
                        {
                            stackRedo.Push(new Recovery(undo.SqlString, "INSERT", undo.MaPosition));

                            if (Program.mGroup.Equals("GIANGVIEN"))
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
                            }
                            else
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.Fill(this.DS.BODE);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.Fill(this.DS.DSGV);
                            }
                            XtraMessageBox.Show("Phục hồi thành công, đã xóa bộ đề", "", MessageBoxButtons.OK);
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
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Bo_De " + undo.SqlBeforeUpdateString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("0")) //Sua thanh cong
                        {
                            if (Program.mGroup.Equals("GIANGVIEN"))
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
                            }
                            else
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.Fill(this.DS.BODE);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.Fill(this.DS.DSGV);
                            }
                            isSua = isThem = false;

                            bdsBoDe.Position = bdsBoDe.Find("CAUHOI", undo.MaPosition);
                            stackRedo.Push(new Recovery(undo.SqlString, undo.SqlBeforeUpdateString, undo.Type, undo.MaPosition));
                            XtraMessageBox.Show("Phục hồi thành công, đã sửa lại bộ đề", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Them_Bo_De " + undo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã câu hỏi đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Them thanh cong
                        {
                            stackRedo.Push(new Recovery(undo.SqlString, undo.Type, undo.MaPosition));

                            if (Program.mGroup.Equals("GIANGVIEN"))
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
                            }
                            else
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.Fill(this.DS.BODE);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.Fill(this.DS.DSGV);
                            }
                            bdsBoDe.Position = bdsBoDe.Find("CAUHOI", undo.MaPosition);
                            XtraMessageBox.Show("Phục hồi thành công, đã thêm lại bộ đề", "", MessageBoxButtons.OK);

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
                    String sql = "EXEC SP_Phuc_Hoi_Them_Bo_De " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Mã bộ đề đã tồn tại, không thể phục hồi", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Them thanh cong
                        {
                            stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                            if (Program.mGroup.Equals("GIANGVIEN"))
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
                            }
                            else
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.Fill(this.DS.BODE);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.Fill(this.DS.DSGV);
                            }

                            bdsBoDe.Position = bdsBoDe.Find("CAUHOI", redo.MaPosition);
                            XtraMessageBox.Show("Phục hồi thành công, đã thêm lại bộ đề", "", MessageBoxButtons.OK);
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
                    String sql = "EXEC SP_Phuc_Hoi_Sua_Bo_De " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);

                        if (kq.Equals("0")) //Sua thanh cong
                        {
                            stackUndo.Push(new Recovery(redo.SqlString, redo.SqlBeforeUpdateString, redo.Type, redo.MaPosition));
                            if (Program.mGroup.Equals("GIANGVIEN"))
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
                            }
                            else
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.Fill(this.DS.BODE);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.Fill(this.DS.DSGV);
                            }
                            isSua = isThem = false;
                            bdsBoDe.Position = bdsBoDe.Find("CAUHOI", redo.MaPosition);

                            XtraMessageBox.Show("Phục hồi thành công, đã sửa lại bộ đề", "", MessageBoxButtons.OK);

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
                    //Neu them thi xoa no di
                    String sql = "EXEC SP_Phuc_Hoi_Xoa_Bo_De " + redo.SqlString;
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(sql);
                        if (Program.myReader == null) return;
                        Program.myReader.Read();

                        String kq = Program.myReader.GetString(0);
                        if (kq.Equals("1"))
                        {
                            XtraMessageBox.Show("Bộ đề đã có trong chi tiết bài thi, không thể xóa", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else if (kq.Equals("0")) // Xoa thanh cong
                        {
                            stackUndo.Push(new Recovery(redo.SqlString, redo.Type, redo.MaPosition));

                            if (Program.mGroup.Equals("GIANGVIEN"))
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
                            }
                            else
                            {
                                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                                this.tbBoDeADT.Fill(this.DS.BODE);
                                this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                                this.tbDSGVienADT.Fill(this.DS.DSGV);
                            }
                            XtraMessageBox.Show("Phục hồi thành công, đã xóa bộ đề", "", MessageBoxButtons.OK);
                            checkStateUndoRedo();
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Phục hồi thất bại", "", MessageBoxButtons.OK);
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

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Program.mGroup.Equals("GIANGVIEN"))
                {
                    this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                    this.tbBoDeADT.FillByGV(this.DS.BODE, Program.username);
                    this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                    this.tbDSGVienADT.FillByMAGV(this.DS.DSGV, Program.username);
                }
                else
                {
                    this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                    this.tbBoDeADT.Fill(this.DS.BODE);
                    this.tbDSGVienADT.Connection.ConnectionString = Program.connstr;
                    this.tbDSGVienADT.Fill(this.DS.DSGV);
                }
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
                if (XtraMessageBox.Show("Bạn đang tạo mới bộ đề, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa bộ đề, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }

            this.Close();
        }
        private void WriteToDB()
        {
            gcBoDe.Enabled = true;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            try
            {
                bdsBoDe.EndEdit();
                bdsBoDe.ResetCurrentItem();
                this.tbBoDeADT.Update(this.DS.BODE);
                txtMaCH.Enabled = cbbTenMon.Enabled = cbbTenGV.Enabled = cbbDapAn.Enabled =
                    cbbTrinhDo.Enabled = rtxtA.Enabled = rtxtB.Enabled = rtxtC.Enabled = rtxtD.Enabled = rtxtNoiDung.Enabled = false;
                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                this.tbBoDeADT.Fill(this.DS.BODE);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ghi bộ đề" + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        public bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaCH.Text.Trim()))
            {
                XtraMessageBox.Show("Mã câu hỏi không được để trống ", "", MessageBoxButtons.OK);
                txtMaCH.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMaGV.Text.Trim()))
            {
                XtraMessageBox.Show("Mã giáo viên không được để trống ", "", MessageBoxButtons.OK);
                cbbTenGV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaMon.Text.Trim()))
            {
                XtraMessageBox.Show("Mã môn học không được để trống ", "", MessageBoxButtons.OK);
                cbbTenMon.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbTrinhDo.Text.Trim()))
            {
                XtraMessageBox.Show("Trình độ không được để trống", "", MessageBoxButtons.OK);
                cbbTrinhDo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbDapAn.Text.Trim()))
            {
                XtraMessageBox.Show("Đáp án không được để trống", "", MessageBoxButtons.OK);
                cbbDapAn.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(rtxtA.Text.Trim()))
            {
                XtraMessageBox.Show("Nội dung đáp án A không được để trống", "", MessageBoxButtons.OK);
                rtxtA.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(rtxtB.Text.Trim()))
            {
                XtraMessageBox.Show("Nội dung đáp án B không được để trống", "", MessageBoxButtons.OK);
                rtxtB.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(rtxtC.Text.Trim()))
            {
                XtraMessageBox.Show("Nội dung đáp án C không được để trống", "", MessageBoxButtons.OK);
                rtxtC.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(rtxtD.Text.Trim()))
            {
                XtraMessageBox.Show("Nội dung đáp án D không được để trống", "", MessageBoxButtons.OK);
                rtxtD.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(rtxtNoiDung.Text.Trim()))
            {
                XtraMessageBox.Show("Nội dung câu hỏi không được để trống", "", MessageBoxButtons.OK);
                rtxtNoiDung.Focus();
                return false;
            }
            return true;
        }

        private void cbbTenGV_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cbbTenGV.SelectedValue != null)
                {
                    txtMaGV.Text = cbbTenGV.SelectedValue.ToString();
                }
            }
            catch (Exception ex) { }
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
            catch (Exception ex) { }
        }

        private void txtMaCH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
