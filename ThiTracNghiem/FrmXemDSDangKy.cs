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
    public partial class FrmXemDSDangKy : Form
    {
        public FrmXemDSDangKy()
        {
            InitializeComponent();
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
                
            }
        }

        private void FrmXemDSDangKy_Load(object sender, EventArgs e)
        {
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
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTuNgay.Text.ToString().Trim().Equals(""))
            {
                XtraMessageBox.Show("Bạn chưa nhập ngày bắt đầu", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (dateDenNgay.Text.ToString().Trim().Equals(""))
            {
                XtraMessageBox.Show("Bạn chưa nhập ngày kết thúc", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (DateTime.Compare(dateTuNgay.DateTime, dateDenNgay.DateTime) > 0)
            {
                // ngày bắt đầu không thể lớn hơn ngày kết thúc
                XtraMessageBox.Show("ngày bắt đầu không thể lớn hơn ngày kết thúc", "", MessageBoxButtons.OK);
                return;
            }

            RptXemDSDangKy rpt = new RptXemDSDangKy(dateTuNgay.DateTime, dateDenNgay.DateTime);
            rpt.lbCoSo.Text = " " + ((DataRowView)Program.bds_dspm[Program.mCoSo])["TENCS"].ToString();
            rpt.lbNgay.Text = "TỪ NGÀY " + dateTuNgay.Text.Trim() + " ĐẾN NGÀY " + dateDenNgay.Text.Trim();
            
            DateTime today = DateTime.Today;
            rpt.lblDate.Text = "TP Hồ Chí Minh, ngày " + today.Day + " tháng " + today.Month + " năm " + today.Year;
            rpt.lblNguoiLap.Text = Program.mHoten;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
