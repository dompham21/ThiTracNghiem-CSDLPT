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
    public partial class FrmChuanBiThiSV : Form
    {
        public FrmChuanBiThiSV()
        {
            InitializeComponent();
        }

        private void FrmChuanBiThiSV_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)
            this.tbMHDKyADT.Connection.ConnectionString = Program.connstr;
            this.tbMHDKyADT.Fill(this.DS.DSMHDK);
            txtMaSV.Text = Program.username.Trim();
            txtHoTen.Text = Program.mHoten.Trim();
            cbbLanThi.Items.Add(1);
            cbbLanThi.Items.Add(2);
            cbbLanThi.SelectedIndex = -1;
            dateNgayThi.EditValue = DateTime.Today;
            cbbTenMon.SelectedIndex = -1;
            txtMaMon.Focus();
            String sql = "SELECT LOP.MALOP, TENLOP FROM dbo.LOP JOIN dbo.SINHVIEN " +
                    "ON SINHVIEN.MALOP = LOP.MALOP WHERE MASV = N'" + Program.username + "'";
            try
            {
                Program.myReader = Program.ExecSqlDataReader(sql);
                if (Program.myReader != null)
                {
                    Program.myReader.Read();
                    txtMaLop.Text = Program.myReader.GetString(0).Trim();
                    txtTenLop.Text = Program.myReader.GetString(1).Trim();
                   
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lỗi " + ex.Message, "", MessageBoxButtons.OK);
            }
            finally
            {
                Program.myReader.Close();
                Program.conn.Close();
            }
           

            if(bdsMHDK.Count <=0)
            {
                XtraMessageBox.Show("Không có môn học nào được đăng ký thi", "", MessageBoxButtons.OK);
                return;
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text.Trim()))
            {
                XtraMessageBox.Show("Mã môn học không được để trống ", "", MessageBoxButtons.OK);
                cbbTenMon.Focus();
                return;
            }

            if (string.IsNullOrEmpty(dateNgayThi.Text.Trim()))
            {
                XtraMessageBox.Show("Ngày thi không được để trống ", "", MessageBoxButtons.OK);
                dateNgayThi.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cbbLanThi.Text.Trim()))
            {
                XtraMessageBox.Show("Lần thi không được để trống ", "", MessageBoxButtons.OK);
                cbbLanThi.Focus();
                return;
            }
            //Kiem tra sinhvien da thi lan 1 chua
            //Kiem tra sinhvien da thi chua 
            String sql = "EXEC SP_GET_GVDK N'" + txtMaLop.Text.Trim() + "', N'" + txtMaMon.Text.Trim() + "', '" + dateNgayThi.DateTime.ToString() + "', " + cbbLanThi.Text.Trim() + "";
            try
            {
                DataTable dt = Program.ExecSqlDataTable(sql);
                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Không tồn tại lịch thi theo điều kiện lọc, vui lòng chọn lại!", "", MessageBoxButtons.OK);
                    return;
                }
                bdsGVDK.DataSource = dt;

                if(bdsGVDK.Count > 0)
                {
                    btnThi.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
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

        private void btnThi_Click(object sender, EventArgs e)
        {
            if(bdsGVDK.Count <=0)
            {
                XtraMessageBox.Show("Danh sách đăng ký thi trống!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                String maMH = ((DataRowView)this.bdsGVDK.Current).Row["MAMH"].ToString().Trim();
                int lan = Int32.Parse(((DataRowView)this.bdsGVDK.Current).Row["LAN"].ToString().Trim());

                String ktlan = "exec SP_KT_Lan_Thi N'"
                    + Program.username + "', N'"
                    + maMH + "', "
                    + lan;
                try
                {
                    Program.myReader = Program.ExecSqlDataReader(ktlan);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();

                    String kq = Program.myReader.GetString(0);
                    Program.myReader.Close();

                    if (kq.Equals("1"))
                    {
                        XtraMessageBox.Show("Sinh viên đã thi lần này, không được thi lại", "", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {

                        FrmThi.maMH = maMH;
                        FrmThi.trinhDo = ((DataRowView)this.bdsGVDK.Current).Row["TRINHDO"].ToString().Trim();
                        FrmThi.lan = lan;
                        FrmThi.maLop = ((DataRowView)this.bdsGVDK.Current).Row["MALOP"].ToString().Trim();
                        FrmThi.tenLop = txtTenLop.Text.Trim();
                        FrmThi.ngaythi = Convert.ToDateTime(((DataRowView)this.bdsGVDK.Current).Row["NGAYTHI"]);
                        FrmThi.thoiGian = Int32.Parse(((DataRowView)this.bdsGVDK.Current).Row["THOIGIAN"].ToString().Trim());
                        FrmThi.soCau = Int32.Parse(((DataRowView)this.bdsGVDK.Current).Row["SOCAUTHI"].ToString().Trim());
                        this.Close();
                        Program.frmThi = new FrmThi();
                        Program.frmThi.Activate();
                        Program.frmThi.Show();
                        this.Visible = false;
                    }
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show("Lỗi " + ex.Message, "", MessageBoxButtons.OK);
                    Program.myReader.Close();

                }


            }
        }
    }
}
