using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class FrmThi : Form
    {
       

        public static string maMH = "";
        public static string trinhDo = "";
        public static int lan;
        public static string maLop = "";
        public static string tenLop = "";
        public static int thoiGian;
        public static int soCau;
        public static CauHoi[] listCauHoi;
        private static int soCauDung = 0;
        private static double diem = 0.0;
        public static DateTime ngaythi;


        public FrmThi()
        {
            InitializeComponent();
        }

        private void FrmThiThu_Load(object sender, EventArgs e)
        {
            txtMaMon.Text = maMH;
            txtTrinhDo.Text = trinhDo;
            txtLan.Text = lan.ToString();
            dateNgayThi.Text = ngaythi.ToString();
            txtThoiGian.Text = thoiGian.ToString();
            txtSoCau.Text = soCau.ToString();
            gbInfoSV.Visible = false;
            MaGVSV.Text = "Mã số: " + Program.username; ;
            HoTen.Text = "Họ tên: " + Program.mHoten;
            Nhom.Text = "Nhóm: " + Program.mGroup;

            if(Program.mGroup == "SINHVIEN")
            {
                gbInfoSV.Visible = true;
                txtHoTen.Text = Program.mHoten;
                txtMaSV.Text = Program.username;
                txtMaLop.Text = maLop;
                txtTenLop.Text = tenLop;
            }
            labelTime.Visible = false;
            btnNop.Visible = false;
            loadCauHoi();
        }


        private void loadCauHoi()
        {
            String sql = "exec SP_GET_CauHoi N'"
                    + maMH + "',N'"
                    + trinhDo + "', " + soCau;
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
                MessageBox.Show("Lỗi " + ex.Message, "", MessageBoxButtons.OK);
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
                tinhdiem();
                if (Program.mGroup == "SINHVIEN")
                {
                    ghiDiemBaiThi();
                }
                btnNop.Visible = false;
                flowDeThi.Controls.Clear();
                FrmKQThi.socau = soCau;
                FrmKQThi.diem = diem;
                FrmKQThi.soCauDung = soCauDung;
                FrmKQThi.maMH = maMH;
                FrmKQThi.thoiGian = thoiGian;
                FrmKQThi.trinhDo = trinhDo;
                FrmKQThi.lan = lan;
                FrmKQThi.ngayThi = dateNgayThi.DateTime.ToString();
                FrmKQThi.maLop = maLop;
                FrmKQThi.tenLop = tenLop;
                this.Close();

                Program.frmKQThi = new FrmKQThi();
                Program.frmKQThi.Activate();
                Program.frmKQThi.Show();
            }
        }

        private void btnNop_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có chắc muốn nộp bài", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                timer1.Stop();
                tinhdiem();
                if(Program.mGroup == "SINHVIEN")
                {

                    ghiDiemBaiThi();
                }
                btnNop.Visible = false;
                flowDeThi.Controls.Clear();
                FrmKQThi.socau = soCau;
                FrmKQThi.diem = diem;
                FrmKQThi.soCauDung = soCauDung;
                FrmKQThi.maMH = maMH;
                FrmKQThi.thoiGian = thoiGian;
                FrmKQThi.trinhDo = trinhDo;
                FrmKQThi.lan = lan;
                FrmKQThi.ngayThi = dateNgayThi.DateTime.ToString();
                FrmKQThi.maLop = maLop;
                FrmKQThi.tenLop = tenLop;
                this.Close();

                Program.frmKQThi = new FrmKQThi();
                Program.frmKQThi.Activate();
                Program.frmKQThi.Show();
            }
        }

        private void ghiDiemBaiThi()
        {
            
            DataTable dt = new DataTable();

            //Add columns  
            dt.Columns.Add(new DataColumn("MASV", typeof(string)));
            dt.Columns.Add(new DataColumn("MAMH", typeof(string)));
            dt.Columns.Add(new DataColumn("LAN", typeof(int)));
            dt.Columns.Add(new DataColumn("MACH", typeof(int)));
            dt.Columns.Add(new DataColumn("DAP_AN_CHON", typeof(string)));
            for (int i = 0; i < listCauHoi.Length; i++)
            {
                dt.Rows.Add(Program.username, txtMaMon.Text.Trim(), int.Parse(txtLan.Text.Trim()), listCauHoi[i].IdCauHoi, listCauHoi[i].DaChon);
            }

            SqlParameter para = new SqlParameter();
            para.SqlDbType = SqlDbType.Structured;
            para.TypeName = "dbo.TYPE_CT_BAITHI";
            para.ParameterName = "@BAITHI";
            para.Value = dt;
            Program.conn.Open();
            SqlCommand sqlcom = new SqlCommand("SP_INSERT_KQ_THI", Program.conn);
            sqlcom.Parameters.Clear();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add(para);
            sqlcom.Parameters.Add("@MASV", SqlDbType.Char, 8);
            sqlcom.Parameters.Add("@MAMH", SqlDbType.Char, 5);
            sqlcom.Parameters.Add("@LAN", SqlDbType.SmallInt);
            sqlcom.Parameters.Add("@NGAYTHI", SqlDbType.DateTime);
            sqlcom.Parameters.Add("@DIEM", SqlDbType.Float);
            sqlcom.Parameters["@MASV"].Value = Program.username;
            sqlcom.Parameters["@MAMH"].Value = txtMaMon.Text.Trim();
            sqlcom.Parameters["@LAN"].Value = txtLan.Text.Trim();
            sqlcom.Parameters["@NGAYTHI"].Value = dateNgayThi.DateTime.ToString();
            sqlcom.Parameters["@DIEM"].Value = diem;

            try
            {
                sqlcom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi điểm bài thi " + ex.Message, "", MessageBoxButtons.OK);
            }
            finally
            {
                Program.conn.Close();
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

            else diem = Math.Round((double)(10 * soCauDung) / soCau, 2);

        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chưa nộp bài thi, nhấn OK để nộp bài", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
            {
                timer1.Stop();
                tinhdiem();
                if (Program.mGroup == "SINHVIEN")
                {
                    ghiDiemBaiThi();
                }
                btnNop.Visible = false;
                flowDeThi.Controls.Clear();
                FrmKQThi.socau = soCau;
                FrmKQThi.diem = diem;
                FrmKQThi.soCauDung = soCauDung;
                FrmKQThi.maMH = maMH;
                FrmKQThi.thoiGian = thoiGian;
                FrmKQThi.trinhDo = trinhDo;
                FrmKQThi.lan = lan;
                FrmKQThi.ngayThi = dateNgayThi.DateTime.ToString();
                FrmKQThi.maLop = maLop;
                FrmKQThi.tenLop = tenLop;
                this.Close();

                Program.frmKQThi = new FrmKQThi();
                Program.frmKQThi.Activate();
                Program.frmKQThi.Show();
            }
            else this.Close();
        }


        private void FrmThi_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
