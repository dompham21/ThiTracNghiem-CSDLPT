using DevExpress.XtraEditors;
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
    public partial class FrmThiThu : Form
    {
       

        public static string maMH = "";
        public static string trinhDo = "";
        public static int lan;
        public static string maLop = "";
        public static string ngayThi = "";
        public static int thoiGian;
        public static int soCau;
        public static CauHoi[] listCauHoi;
        private static int soCauDung = 0;
        private static double diem = 0.0;


        public FrmThiThu()
        {
            InitializeComponent();
        }

        private void FrmThiThu_Load(object sender, EventArgs e)
        {
            txtMaMon.Text = maMH;
            txtTrinhDo.Text = trinhDo;
            txtLan.Text = lan.ToString();
            dateNgayThi.Text = ngayThi;
            txtThoiGian.Text = thoiGian.ToString();
            txtSoCau.Text = soCau.ToString();
            gbInfoSV.Visible = false;
            MaGVSV.Text = "Mã số: " + Program.username; ;
            HoTen.Text = "Họ tên: " + Program.mHoten;
            Nhom.Text = "Nhóm: " + Program.mGroup;
            labelTime.Visible = false;
            btnNop.Visible = false;
            loadCauHoi();
        }


        private void loadCauHoi()
        {
            String sql = "exec SP_GET_CauHoi N'"
                    + maLop + "',N'"
                    + maMH + "', " + lan;
            try { 
                DataTable dt = Program.ExecSqlDataTable(sql);
                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Không thể lấy được đề thi, thiếu đề", "", MessageBoxButtons.OK);
                    return;
                }
                labelTime.Visible = true;
                labelTime.Text = thoiGian.ToString() + " : 00";
                timer1.Start();
                btnNop.Visible = true;
                bdsDeThi.DataSource = dt;
                listCauHoi = new CauHoi[soCau];
                for (int i = 0; i < listCauHoi.Length; i++)
                {
                    listCauHoi[i] = new CauHoi();
                    listCauHoi[i].CauSo = i + 1;
                    listCauHoi[i].IdCauHoi = (int)((DataRowView)bdsDeThi[i])["CauHoi"];
                    listCauHoi[i].NoiDung = ((DataRowView)bdsDeThi[i])["NoiDung"].ToString();
                    listCauHoi[i].CauA = ((DataRowView)bdsDeThi[i])["A"].ToString();
                    listCauHoi[i].CauB = ((DataRowView)bdsDeThi[i])["B"].ToString();
                    listCauHoi[i].CauC = ((DataRowView)bdsDeThi[i])["C"].ToString();
                    listCauHoi[i].CauD = ((DataRowView)bdsDeThi[i])["D"].ToString();
                    listCauHoi[i].DapAn = ((DataRowView)bdsDeThi[i])["DAP_AN"].ToString();
                    listCauHoi[i].DaChon = "";
                    flowDeThi.Controls.Add(listCauHoi[i]);
                    String[] arr = new string[2];
                    arr[0] = "Câu " + (i+1);
                    arr[1] = listCauHoi[i].DaChon;

                    ListViewItem item = new ListViewItem(arr);
                    listViewDAChon.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }


        private int s = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            s--;
            if (s == 0)
            {
                if (thoiGian != 0)
                {
                    thoiGian--;
                    s = 59;
                }
            }
            labelTime.Text = thoiGian.ToString() + " : " + s.ToString();
            if (thoiGian == 0 && s == 0)
            {
                timer1.Stop();

                XtraMessageBox.Show("Đã hết thời gian thi!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnNop.Enabled = false;
            }
        }

        private void btnNop_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có chắc muốn nộp bài", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                timer1.Stop();
                tinhdiem();
                
                btnNop.Visible = false;
                flowDeThi.Controls.Clear();
                FrmKQThi.socau = soCau;
                FrmKQThi.diem = diem;
                FrmKQThi.soCauDung = soCauDung;
                FrmKQThi.maMH = maMH;
                FrmKQThi.thoiGian = thoiGian;
                FrmKQThi.trinhDo = trinhDo;
                FrmKQThi.lan = lan;
                FrmKQThi.ngayThi = ngayThi;
                this.Close();

                Program.frmKQThi = new FrmKQThi();
                Program.frmKQThi.Activate();
                Program.frmKQThi.Show();
            }
        }

        private void tinhdiem()
        {
            soCauDung = 0;
            for (int i = 0; i < listCauHoi.Length; i++)
            {
                if (listCauHoi[i].DaChon.Trim().CompareTo(listCauHoi[i].DapAn.Trim()) == 0)
                    soCauDung++;
            }

            if (soCauDung == 0) diem = 0;

            else diem = (float)Math.Round((double)(10 * soCauDung) / soCau, 2);
        }
        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chưa nộp bài thi, nhấn OK để nộp bài", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
            {
                btnNop_Click(sender, e);
            }
            else this.Close();
        }
    }
}
