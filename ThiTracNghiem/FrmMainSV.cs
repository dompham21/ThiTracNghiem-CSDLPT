using DevExpress.XtraBars;
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
    public partial class FrmMainSV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Form form;
        private FrmChuanBiThiSV frmChuanBiThiSV = null;
        private FrmFilterXemKQThi frmFilterXemKQThi = null;
        public FrmMainSV()
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

        private void btnThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            form = this.CheckExists(typeof(FrmChuanBiThiSV));
            if (form == null)
            {

                IsMdiContainer = true;
                frmChuanBiThiSV = new FrmChuanBiThiSV();
                frmChuanBiThiSV.MdiParent = this;

                frmChuanBiThiSV.Show();
            }
            else form.Activate();
        }

        private void FrmMainSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            DialogResult dr = XtraMessageBox.Show("Bạn có chắc muốn thoát chương trình", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else e.Cancel = true;
            
        }

        private void btnXemKQ_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            form = this.CheckExists(typeof(FrmFilterXemKQThi));
            if (form == null)
            {

                IsMdiContainer = true;
                frmFilterXemKQThi = new FrmFilterXemKQThi();
                frmFilterXemKQThi.MdiParent = this;

                frmFilterXemKQThi.Show();
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
                Program.frmMainSV.Hide();
                FrmDangNhap frmDangNhap = new FrmDangNhap();
                frmDangNhap.Activate();
                frmDangNhap.ShowDialog();
            }
        }
    }
}