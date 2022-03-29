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
            if (Program.mGroup == "Giangvien")
            {
                rbpgKhoa.Visible = rbpgLop.Visible = rbpgMonHoc.Visible = rbpgGVDK.Visible = rbpgDeThi.Visible = false;

            }
            else if (Program.mGroup == "Coso")
            {

            }
            else
            {

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
    }
}