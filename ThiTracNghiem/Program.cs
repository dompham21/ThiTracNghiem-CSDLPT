using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    internal static class Program
    {
        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static String connstr_publiser = "Data Source=DESKTOP-A8S0739;Initial Catalog=TN_CSDLPT;Integrated Security=True";

        public static SqlDataReader myReader;
        public static String servername = "";
        public static String username = "";
        public static String mlogin = "";
        public static String password = "";
        public static String mSV = "";

        public static String database = "TN_CSDLPT";
        public static String remoteLogin = "HTKN";
        public static String remotePassword = "123456";
        public static String svLogin = "sv";
        public static String svPassword = "123456";
        public static String mloginDN = "";
        public static String passwordDN = "";
        public static String mGroup = "";
        public static String mHoten = "";
        public static int mCoSo = 0;
        public static String studentCode = String.Empty;

        public static BindingSource bds_dspm = new BindingSource(); //Giữ danh sách các phân mảnh


        public static FrmMain frmChinh;
        public static frmDangNhap frmDangNhap;
        public static FrmThiThu frmThiThu = null;
        public static FrmKQThi frmKQThi = null;



        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" +
                      Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;

            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }


        public static int ExecSqlNonQuery(String strlenh)
        {

            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlCommand Sqlcmd = new SqlCommand(strlenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            try
            {
                Sqlcmd.ExecuteNonQuery();

                return 0;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
        }
        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;

            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }



        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmDangNhap = new frmDangNhap();
            Application.Run(frmDangNhap);
        }
    }
}
