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
    public partial class FrmBangDiem : Form
    {
        public FrmBangDiem()
        {
            InitializeComponent();
        }

        private void FrmBangDiem_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            this.tbLopDaThiADT.Connection.ConnectionString = Program.connstr;
            this.tbLopDaThiADT.Fill(this.DS.LOP_DA_THI);
            this.tbMHDaThiADT.Connection.ConnectionString = Program.connstr;
            this.tbMHDaThiADT.Fill(this.DS.MH_DA_THI);

            cbbCoSo.DataSource = Program.bds_dspm.DataSource;
            cbbCoSo.DisplayMember = "TENCS";
            cbbCoSo.ValueMember = "TENSERVER";
            cbbCoSo.SelectedIndex = Program.mCoSo;

            if (Program.mGroup == "COSO")
            {
                cbbCoSo.Enabled = false;

            }
            //Truong thì login đó có thể đăng nhập vào bất kỳ phân mảnh  nào để xem dữ liệu 
            else if (Program.mGroup == "TRUONG")
            {
                cbbCoSo.Enabled = true;
            }
            cbbLanThi.Items.Add(1);
            cbbLanThi.Items.Add(2);
            cbbLanThi.SelectedIndex = -1;
            cbbTenMon.SelectedIndex = -1;
            cbbTenLop.SelectedIndex = -1;

            txtMaLop.Text = txtMaMon.Text = "";
            if(bdsLopDaThi.Count <= 0)
            {
                XtraMessageBox.Show("Danh sách lớp đã thi trống, vui lòng xem lại!", "", MessageBoxButtons.OK);
            }
            if(bdsMHDaThi.Count <= 0)
            {
                XtraMessageBox.Show("Danh sách môn học đã thi trống, vui lòng xem lại!", "", MessageBoxButtons.OK);
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
                DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

                this.tbLopDaThiADT.Connection.ConnectionString = Program.connstr;
                this.tbLopDaThiADT.Fill(this.DS.LOP_DA_THI);
                this.tbMHDaThiADT.Connection.ConnectionString = Program.connstr;
                this.tbMHDaThiADT.Fill(this.DS.MH_DA_THI);
                txtMaLop.Text = txtMaMon.Text = "";

                cbbLanThi.SelectedIndex = -1;
                cbbTenMon.SelectedIndex = -1;
                cbbTenLop.SelectedIndex = -1;
                if (bdsLopDaThi.Count <= 0)
                {
                    XtraMessageBox.Show("Danh sách lớp đã thi trống, vui lòng xem lại!", "", MessageBoxButtons.OK);
                }
                if (bdsMHDaThi.Count <= 0)
                {
                    XtraMessageBox.Show("Danh sách môn học đã thi trống, vui lòng xem lại!", "", MessageBoxButtons.OK);
                }
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaLop.Text.Trim()))
            {
                XtraMessageBox.Show("Mã lớp học không được để trống ", "", MessageBoxButtons.OK);
                cbbTenLop.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMaMon.Text.Trim()))
            {
                XtraMessageBox.Show("Mã môn học không được để trống ", "", MessageBoxButtons.OK);
                cbbTenMon.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cbbLanThi.Text.Trim()))
            {
                XtraMessageBox.Show("Lần thi không được để trống ", "", MessageBoxButtons.OK);
                cbbLanThi.Focus();
                return;
            }

            string sql = "EXEC SP_GET_BANGDIEM_MONHOC N'" + txtMaLop.Text.Trim() + "', N'" + txtMaMon.Text.Trim() + "', " + + Int32.Parse(cbbLanThi.Text.Trim()) + "";
            try
            {
                Program.myReader = Program.ExecSqlDataReader(sql);
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Không có bảng điểm cho môn học " + txtMaMon.Text.Trim() + " tại lớp " + txtMaLop.Text.Trim() 
                        +" thi lần " + cbbLanThi.Text.Trim() + "!", "", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra tồn tại bảng điểm", "", MessageBoxButtons.OK);
                return;
            }
            finally
            {
                Program.myReader.Close();
            }

            RptXemBangDiem rpt = new RptXemBangDiem(txtMaLop.Text.Trim(), txtMaMon.Text.Trim(), Int32.Parse(cbbLanThi.Text.Trim()));

            rpt.lblLop.Text = cbbTenLop.Text.Trim();
            rpt.lblMon.Text = cbbTenMon.Text.Trim();
            rpt.lblLan.Text = cbbLanThi.Text.Trim();
            DateTime today = DateTime.Today;
            rpt.lblDate.Text = "TP Hồ Chí Minh, ngày " + today.Day + " tháng " + today.Month + " năm " + today.Year;
            rpt.lblNguoiLap.Text = Program.mHoten;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
