using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class FrmFilterXemKQThi : Form
    {
        public FrmFilterXemKQThi()
        {
            InitializeComponent();
           
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

            if(txtMaMon.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Mã môn học không được để trống ", "", MessageBoxButtons.OK);
                cbbTenMon.Focus();
                return;
            }
            if (cbbLanThi.Text.Trim().Equals(""))
            {
                XtraMessageBox.Show("Lần thi không được để trống ", "", MessageBoxButtons.OK);
                cbbLanThi.Focus();
                return;
            }
            String ktlan = "exec SP_KT_Lan_Thi N'"
                   + Program.username + "', N'"
                   + txtMaMon.Text.Trim() + "', "
                   + cbbLanThi.Text.Trim();
            try
            {
                Program.myReader = Program.ExecSqlDataReader(ktlan);
                if (Program.myReader == null) return;
                Program.myReader.Read();

                String kq = Program.myReader.GetString(0);
                Program.myReader.Close();

                if (kq.Equals("0"))
                {
                    XtraMessageBox.Show("Sinh viên chưa thi môn học vào lần thi này!", "", MessageBoxButtons.OK);
                    return;
                }
                else if (kq.Equals("1"))
                {
                    string ngaythi = "SELECT Ngaythi from BangDiem Where MASV='" + txtMaSV.Text.Trim() + "'AND MAMH='" + txtMaMon.Text.Trim() + "'AND LAN=" + Int32.Parse(cbbLanThi.Text.Trim()) + "";
                    
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader(ngaythi);
                        if (!Program.myReader.HasRows)
                        {
                            MessageBox.Show("Lỗi lấy ngày thi", "", MessageBoxButtons.OK);

                            return;
                        }
                        Program.myReader.Read();


                        string ngay = Program.myReader.GetDateTime(0).ToString("dd/MM/yyyy");
                        Program.myReader.Close();

                        RptXemKQThi rpt = new RptXemKQThi(txtMaSV.Text.Trim(), txtMaMon.Text.Trim(), Int32.Parse(cbbLanThi.Text.Trim()));

                        rpt.lblLop.Text = txtTenLop.Text.Trim();
                        rpt.lblHoTen.Text = txtHoTen.Text.Trim();
                        DateTime today = DateTime.Today;
                        rpt.lblDate.Text = "TP Hồ Chí Minh, ngày " + today.Day + " tháng " + today.Month + " năm " + today.Year;
                        rpt.lblNguoiLap.Text = Program.mHoten;
                        rpt.lblMon.Text = txtMaMon.Text.Trim();
                        rpt.lblLan.Text = cbbLanThi.Text.Trim();
                        rpt.lblNgay.Text = ngay;
                        ReportPrintTool print = new ReportPrintTool(rpt);
                        print.ShowPreviewDialog();
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi " + ex.Message, "", MessageBoxButtons.OK);
                    }                
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("lỗi " + ex.Message, "", MessageBoxButtons.OK);

            }
            finally
            {
                Program.myReader.Close();

            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FrmFilterXemKQThi_Load(object sender, EventArgs e)
        {
           
            this.tbMHocADT.Fill(this.DS.SP_GET_MH_DATHI_SV, Program.username);

            cbbLanThi.Items.Add(1);
            cbbLanThi.Items.Add(2);
            cbbLanThi.SelectedIndex = -1;
            txtMaSV.Text = Program.username.Trim();
            txtHoTen.Text = Program.mHoten.Trim();
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

            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi " + ex.Message, "", MessageBoxButtons.OK);
            }
            finally
            {
                Program.myReader.Close();
                Program.conn.Close();

            }
            

            if (bdsSPMonHoc.Count <= 0)
            {
                XtraMessageBox.Show("Bạn chưa thi môn nào, vui lòng thử lại sau!", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                this.cbbTenMon.SelectedIndex = -1;
            }

        }

      
    }
}
