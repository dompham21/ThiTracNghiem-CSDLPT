using DevExpress.XtraBars;
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
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Form form;
        private FrmMonHoc frmMonHoc = null;
        private FrmKhoa frmKhoa = null;
        private FrmGiaoVien frmGiaoVien = null;
        private FrmSinhVien frmSinhVien = null;
        private FrmGVDK frmGVDK = null;
        private FrmBoDe frmBoDe = null;
        private FrmChuanBiThiThu frmChuanBiThiThu = null;
        private FrmBangDiem frmBangDiem = null;
        private FrmXemDSDangKy frmXemDSDangKy = null;
        private FrmTaoTaiKhoan frmTaoTaiKhoan = null;
        public FrmMain()
        {
            InitializeComponent();
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn thoát?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "GIANGVIEN")
            {
                rbpgKhoa.Visible = rbpgMonHoc.Visible = rbpBaoCao.Visible = rbpgGiaoVien.Visible =
                  rbgpSinhVien.Visible = rbpgGVDK.Visible = rbpgTaoTaiKhoan.Visible = false;
             
            }
            else if (Program.mGroup == "COSO")
            {
                rbpgKhoa.Visible = rbpgMonHoc.Visible = rbpBaoCao.Visible =
                  rbgpSinhVien.Visible = rbpgGVDK.Visible = rbpgTaoTaiKhoan.Visible = rbpgGiaoVien.Visible = 
                   rbpgThiThu.Visible = rbpgDeThi.Visible =  true;
            }
            else if(Program.mGroup == "TRUONG")
            {
                rbpgKhoa.Visible = rbpgMonHoc.Visible = rbpBaoCao.Visible =
                  rbgpSinhVien.Visible = rbpgGVDK.Visible = rbpgTaoTaiKhoan.Visible 
                  = rbpgGiaoVien.Visible = rbpgDeThi.Visible = true;
                rbpgThiThu.Visible = false;
            }
        }

        private void btnMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmMonHoc));
            if (form == null)
            {

                IsMdiContainer = true;
                frmMonHoc = new FrmMonHoc();
                frmMonHoc.MdiParent = this;

                frmMonHoc.Show();
            }
            else form.Activate();
        }

        private void btnKhoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmKhoa));
            if (form == null)
            {

                IsMdiContainer = true;
                frmKhoa = new FrmKhoa();
                frmKhoa.MdiParent = this;

                frmKhoa.Show();
            }
            else form.Activate();
        }

        private void btnGiaoVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmGiaoVien));
            if (form == null)
            {

                IsMdiContainer = true;
                frmGiaoVien = new FrmGiaoVien();
                frmGiaoVien.MdiParent = this;

                frmGiaoVien.Show();
            }
            else form.Activate();
        }


        private void btnSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmSinhVien));
            if (form == null)
            {

                IsMdiContainer = true;
                frmSinhVien = new FrmSinhVien();
                frmSinhVien.MdiParent = this;

                frmSinhVien.Show();
            }
            else form.Activate();
        }

        private void btnGVDK_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmGVDK));
            if (form == null)
            {

                IsMdiContainer = true;
                frmGVDK = new FrmGVDK();
                frmGVDK.MdiParent = this;

                frmGVDK.Show();
            }
            else form.Activate();
        }

        private void btnDeThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmBoDe));
            if (form == null)
            {

                IsMdiContainer = true;
                frmBoDe = new FrmBoDe();
                frmBoDe.MdiParent = this;

                frmBoDe.Show();
            }
            else form.Activate();
        }

        private void btnThiThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmChuanBiThiThu));
            if (form == null)
            {

                IsMdiContainer = true;
                frmChuanBiThiThu = new FrmChuanBiThiThu();
                frmChuanBiThiThu.MdiParent = this;

                frmChuanBiThiThu.Show();
            }
            else form.Activate();
        }

        private void btnBangDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmBangDiem));
            if (form == null)
            {

                IsMdiContainer = true;
                frmBangDiem = new FrmBangDiem();
                frmBangDiem.MdiParent = this;

                frmBangDiem.Show();
            }
            else form.Activate();
        }

        private void btnDSDangKyThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmXemDSDangKy));
            if (form == null)
            {

                IsMdiContainer = true;
                frmXemDSDangKy = new FrmXemDSDangKy();
                frmXemDSDangKy.MdiParent = this;

                frmXemDSDangKy.Show();
            }
            else form.Activate();
        }

        private void btnTaoTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmTaoTaiKhoan));
            if (form == null)
            {

                IsMdiContainer = true;
                frmTaoTaiKhoan = new FrmTaoTaiKhoan();
                frmTaoTaiKhoan.MdiParent = this;

                frmTaoTaiKhoan.Show();
            }
            else form.Activate();
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                Program.username = "";
                Program.mlogin = "";
                Program.password = "";
                Program.mHoten = "";
                Program.mGroup = "";

                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.ShowInTaskbar)
                        frm.Close();
                }
                Program.frmChinh.Hide();
                FrmDangNhap frmDangNhap = new FrmDangNhap();
                frmDangNhap.Activate();
                frmDangNhap.ShowDialog();
            }
        }
    }
}