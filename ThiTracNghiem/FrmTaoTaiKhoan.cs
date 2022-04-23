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
    public partial class FrmTaoTaiKhoan : Form
    {
        public FrmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void FrmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            this.tbGVChuaDK.Connection.ConnectionString = Program.connstr;
            this.tbGVChuaDK.Fill(this.DS.SP_GET_GV_CHUA_DK);
            
            cbbTenGV.SelectedIndex = -1;
            if (Program.mGroup == "COSO")
            {
                cbbLoaiTK.Items.Add("COSO");
                cbbLoaiTK.Items.Add("GIANGVIEN");
            }
            else if (Program.mGroup == "TRUONG")
            {
                cbbLoaiTK.Items.Add("TRUONG");
            }


            cbbLoaiTK.SelectedIndex = 0;
            if (bdsGVChuaDK.Count <= 0)
            {
                XtraMessageBox.Show("Tất cả các giáo viên đều đã đăng ký tài khoản, vui lòng xem lại!", "", MessageBoxButtons.OK);
            }
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
            catch (Exception ex)
            {

            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập", "", MessageBoxButtons.OK);
                txtTenDangNhap.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "", MessageBoxButtons.OK);
                txtPassword.Focus();
                return;
            }
            if (txtMaGV.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn mã giáo viên", "", MessageBoxButtons.OK);
                cbbTenGV.Focus();
                return;
            }

            if (cbbLoaiTK.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn loại tài khoản", "", MessageBoxButtons.OK);
                cbbLoaiTK.Focus();
                return;
            }

            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlCommand sqlcmd = Program.conn.CreateCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SP_TAOLOGIN";
            sqlcmd.Parameters.Add(new SqlParameter("@LGNAME", txtTenDangNhap.Text.Trim()));
            sqlcmd.Parameters.Add(new SqlParameter("@PASS", txtPassword.Text.Trim()));
            sqlcmd.Parameters.Add(new SqlParameter("@USERNAME", txtMaGV.Text.Trim()));
            sqlcmd.Parameters.Add(new SqlParameter("@ROLE", cbbLoaiTK.SelectedItem.ToString().Trim()));
            SqlParameter sqlParameter = new SqlParameter("@return", System.Data.SqlDbType.Int, sizeof(int));
            sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            sqlcmd.Parameters.Add(sqlParameter);


            try
            {
                sqlcmd.ExecuteNonQuery();
                int result = (int)sqlcmd.Parameters["@return"].Value;
                if (result == 1)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "", MessageBoxButtons.OK);
                    txtTenDangNhap.Focus();
                    return;
                }
                if (result == 2)
                {
                    MessageBox.Show("Mã giảng viên đã tồn tại", "", MessageBoxButtons.OK);
                    cbbTenGV.Focus();
                    return;
                }
                if (result == 0) //Thanh cong
                {
                    MessageBox.Show("Tạo tài khoản thành công", "", MessageBoxButtons.OK);
                    txtPassword.Text = "";
                    txtTenDangNhap.Text = "";
                    this.tbGVChuaDK.Connection.ConnectionString = Program.connstr;
                    this.tbGVChuaDK.Fill(this.DS.SP_GET_GV_CHUA_DK);
                    cbbTenGV.SelectedIndex = -1;
                    return;
                }
                else
                {
                    MessageBox.Show("Tạo tài khoản thất bại", "", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo tài khoản " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            finally
            {
                Program.conn.Close();

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đang tạo tài khoản, bạn có chắn muốn thoát không?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               this.Close();
            }
            
        }
    }
}
