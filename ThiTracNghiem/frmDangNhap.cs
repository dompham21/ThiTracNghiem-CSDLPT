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
using DevExpress.XtraEditors;


namespace ThiTracNghiem
{
    public partial class frmDangNhap : Form
    {
        private SqlConnection conn_publisher = new SqlConnection();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

            labelMaSV.Visible = false;
            tbMaSV.Visible = false;

            if (KetNoiCSDLGoc() == 0) return;
            LayDSPM();
            cbCoSo.SelectedIndex = 1; cbCoSo.SelectedIndex = 0;
        }

        private void LayDSPM()
        {
            String cmd = "SELECT * FROM Get_Subscribes";
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(dt);

            Program.bds_dspm.DataSource = dt;

            conn_publisher.Close();

            cbCoSo.DataSource = Program.bds_dspm;
            cbCoSo.DisplayMember = "TENCS"; cbCoSo.ValueMember = "TENSERVER";

            conn_publisher.Close();
        }

        private int KetNoiCSDLGoc()
        {
            if (conn_publisher != null && conn_publisher.State == ConnectionState.Open)
                conn_publisher.Close();
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publiser;
                conn_publisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Lỗi kết nối về CSDL gốc.\nBạn xem lại tên server của publiser, và tên CSDL trong chuối kết nối.\n" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        private void cbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cbCoSo.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            if (tbTaiKhoan.Text.Trim() == "" || tbMatKhau.Text.Trim() == "")
            {
                XtraMessageBox.Show("Login name và password không được trống", "", MessageBoxButtons.OK);
                return;
            }
            if (tbMaSV.Text.Trim() == "" && checkBoxSV.Checked == true)
            {
                XtraMessageBox.Show("Bạn chưa nhập mã sinh viên", "", MessageBoxButtons.OK);
                return;
            }
            Program.mlogin = tbTaiKhoan.Text;
            Program.password = tbMatKhau.Text;
            Program.mSV = tbMaSV.Text;


            // Đăng nhập thất bại
            if (Program.KetNoi() == 0) return;


            Program.mCoSo = cbCoSo.SelectedIndex;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;

            if (checkBoxSV.Checked == true)
            {
                //Kiem tra ma sv co ton tai khong 
                String sql = "EXEC SP_KT_SV_DangNhap '" + tbMaSV.Text + "'";
                int kq = Program.ExecSqlNonQuery(sql);
                if (kq == 1)
                {
                    return;
                }
            }

            string strLenh;
            if (checkBoxSV.Checked == false)
            {
                strLenh = "EXEC SP_Lay_Thong_Tin_GV_Tu_Login '" + Program.mlogin + "'";
            }
            else
            {
                strLenh = "EXEC SP_Lay_Thong_Tin_SV_Tu_Login  '" + Program.mlogin + "' , " + "'" + Program.mSV + "'";
            }

            //Thực hiện sp
            Program.myReader = Program.ExecSqlDataReader(strLenh);

            if (Program.myReader == null) return;
            Program.myReader.Read();

            // Check giáo viên nhưng lại lấy tài khoản sinh viên đăng nhập
            if (checkBoxSV.Checked == false)
            {
                if (Program.myReader.GetString(2).Trim().Equals("Sinhvien"))
                {
                    XtraMessageBox.Show("Bạn đang đăng nhập tài khoản có quyền Sinhvien. \nVui lòng kiểm tra lại.", "", MessageBoxButtons.OK);
                    return;
                }
            }
            // Check sinh viên nhưng lại lấy Giangvien đăng nhập
            else
            {
                if (Program.myReader.GetString(2).Trim().Equals("Giangvien"))
                {
                    XtraMessageBox.Show("Bạn đang đăng nhập tài khoản có quyền của Giangvien." +
                        "\n Vui lòng kiểm tra lại thông tin đăng nhập.", "", MessageBoxButtons.OK);
                    return;
                }
            }

            Program.username = Program.myReader.GetString(0);     // Lay user name
            if (Convert.IsDBNull(Program.username))
            {
                XtraMessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Program.mHoten = Program.myReader.GetString(1);
                Program.mGroup = Program.myReader.GetString(2);
                Program.myReader.Close();
                Program.conn.Close();

                if (checkBoxSV.Checked == true)
                {
                    this.Hide();
                    
                    this.Close();
                }
                else
                {
                    this.Hide();
                    Program.frmChinh = new frmMain();
                    Program.frmChinh.MaGVSV.Text = "Mã số: " + Program.username;
                    Program.frmChinh.HoTen.Text = "Họ tên: " + Program.mHoten;
                    Program.frmChinh.Nhom.Text = "Nhóm: " + Program.mGroup;
                    Program.frmChinh.ShowDialog();
                    this.Close();
                }
            }

        }

        private void checkBoxSV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSV.Checked == true)
            {
                labelMaSV.Visible = true;
                tbMaSV.Visible = true;
            }
            else
            {
                labelMaSV.Visible = false;
                tbMaSV.Text = "";
                tbMaSV.Visible = false;
            }
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn thoát?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
