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
    public partial class FrmGiaoVien : Form
    {
        private Boolean isThem = false;
        private Boolean isSua = false;
        private Stack<Recovery> stackUndo = new Stack<Recovery>();
        private Stack<Recovery> stackRedo = new Stack<Recovery>();
        private String beforeUpdateString;

        public FrmGiaoVien()
        {
            InitializeComponent();
        }

        private void FrmKhoa_Load(object sender, EventArgs e)
        {


            cbbCoSo.DataSource = Program.bds_dspm;
            cbbCoSo.DisplayMember = "TENCS";
            cbbCoSo.ValueMember = "TENSERVER";
            cbbCoSo.SelectedIndex = Program.mCoSo;

            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.
            this.tbLopADT.Connection.ConnectionString = Program.connstr;
            this.tbLopADT.Fill(this.DS.LOP);

            // TODO: This line of code loads data into the 'DS.BODE' table. You can move, or remove it, as needed.
            this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
            this.tbBoDeADT.Fill(this.DS.BODE);
            // TODO: This line of code loads data into the 'DS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.tbGiaoVienADT.Connection.ConnectionString = Program.connstr;
            this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
            // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
            this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
            this.tbKhoaADT.Fill(this.DS.KHOA);

            // phân quyền
            // nhóm CoSo thì ta chỉ cho phép toàn quyền làm việc trên cơ sở  đó , không được log vào cơ sở  khác,   
            if (Program.mGroup == "COSO")
            {
                cbbCoSo.Enabled = false;
                btnThem.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnSua.Visibility
                   = btnUndo.Visibility = btnRedo.Visibility = btnHuy.Visibility =  DevExpress.XtraBars.BarItemVisibility.Always;
            }
            //Truong thì login đó có thể đăng nhập vào bất kỳ phân mảnh  nào để xem dữ liệu 
            else if (Program.mGroup == "TRUONG")
            {
                cbbCoSo.Enabled = true;
                btnThem.Visibility = btnGhi.Visibility = btnXoa.Visibility = btnSua.Visibility
                    = btnUndo.Visibility = btnRedo.Visibility = btnHuy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            checkStateUndoRedo();

            btnHuy.Enabled = btnGhi.Enabled = false;

        }

       
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                btnGhi.Enabled = btnHuy.Enabled = true;
                bdsGiaoVien.AddNew();
                isThem = true;
                gcGiaoVien.Enabled = gcKhoa.Enabled = false;
                txtMaGV.Enabled = txtHoGV.Enabled = txtTenGV.Enabled = txtDiaChi.Enabled  = true;
                txtMaKhoa.Enabled = cbbTenKhoa.Enabled = false;
                txtMaGV.Focus();
                btnThem.Enabled = btnSua.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi thêm môn học " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isThem == true)
            {
                if (XtraMessageBox.Show("Bạn đang tạo mới giáo viên, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }
            else if (isSua == true)
            {
                if (XtraMessageBox.Show("Bạn đang sửa giáo viên, bạn có muốn ghi thông tin này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnGhi_ItemClick(sender, e);
                }

            }

            this.Close();
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'DS.BODE' table. You can move, or remove it, as needed.
                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                this.tbBoDeADT.Fill(this.DS.BODE);
                // TODO: This line of code loads data into the 'DS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.

                this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                // TODO: This line of code loads data into the 'DS.LOP' table. You can move, or remove it, as needed.

                this.tbLopADT.Connection.ConnectionString = Program.connstr;
                this.tbLopADT.Fill(this.DS.LOP);
                // TODO: This line of code loads data into the 'DS.GIAOVIEN' table. You can move, or remove it, as needed.

                this.tbGiaoVienADT.Connection.ConnectionString = Program.connstr;
                this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
                // TODO: This line of code loads data into the 'DS.KHOA' table. You can move, or remove it, as needed.

                this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                this.tbKhoaADT.Fill(this.DS.KHOA);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi tải lại :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGiaoVien.CancelEdit();
            btnHuy.Enabled = btnGhi.Enabled = false;
            isSua = isThem = false;
            gcKhoa.Enabled = gcGiaoVien.Enabled = true;
            txtMaGV.Enabled = txtHoGV.Enabled = txtTenGV.Enabled = txtDiaChi.Enabled = txtMaKhoa.Enabled = cbbTenKhoa.Enabled = false;
            btnThem.Enabled = btnTaiLai.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            this.tbGiaoVienADT.Connection.ConnectionString = Program.connstr;
            this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);

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
                this.tbLopADT.Connection.ConnectionString = Program.connstr;
                this.tbLopADT.Fill(this.DS.LOP);

                // TODO: This line of code loads data into the 'DS.BODE' table. You can move, or remove it, as needed.
                this.tbBoDeADT.Connection.ConnectionString = Program.connstr;
                this.tbBoDeADT.Fill(this.DS.BODE);
                // TODO: This line of code loads data into the 'DS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
                this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
                this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);
                // TODO: This line of code loads data into the 'dS.GIAOVIEN' table. You can move, or remove it, as needed.
                this.tbGiaoVienADT.Connection.ConnectionString = Program.connstr;
                this.tbGiaoVienADT.Fill(this.DS.GIAOVIEN);
                // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
                this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
                this.tbKhoaADT.Fill(this.DS.KHOA);
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;
            }
        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;
            }

        }

        private void cbbTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaKhoa.Text = cbbTenKhoa.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
