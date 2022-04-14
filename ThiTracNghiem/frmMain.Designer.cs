using System.Windows.Forms;

namespace ThiTracNghiem
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnKhoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonHoc = new DevExpress.XtraBars.BarButtonItem();
            this.btnGVDK = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeThi = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btnGiaoVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnSinhVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnThiThu = new DevExpress.XtraBars.BarButtonItem();
            this.rbpQuanLy = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpgKhoa = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgLop = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rnpgGiaoVien = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbgpSinhVien = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgMonHoc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgGVDK = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgDeThi = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpTaiKhoan = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpgTaoTaiKhoan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgDangXuat = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MaGVSV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.Nhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnKhoa,
            this.btnLop,
            this.btnMonHoc,
            this.btnGVDK,
            this.btnDeThi,
            this.btnTaoTaiKhoan,
            this.btnDangXuat,
            this.btnGiaoVien,
            this.btnSinhVien,
            this.btnThiThu});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(1);
            this.ribbon.MaxItemId = 23;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 152;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpQuanLy,
            this.rbpTaiKhoan,
            this.rbpBaoCao});
            this.ribbon.Size = new System.Drawing.Size(810, 158);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // btnKhoa
            // 
            this.btnKhoa.Caption = "Khoa";
            this.btnKhoa.Id = 12;
            this.btnKhoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKhoa.ImageOptions.SvgImage")));
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhoa_ItemClick);
            // 
            // btnLop
            // 
            this.btnLop.Caption = "Lớp";
            this.btnLop.Id = 13;
            this.btnLop.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLop.ImageOptions.SvgImage")));
            this.btnLop.Name = "btnLop";
            this.btnLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLop_ItemClick);
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.Caption = "Môn học";
            this.btnMonHoc.Id = 14;
            this.btnMonHoc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMonHoc.ImageOptions.Image")));
            this.btnMonHoc.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMonHoc.ImageOptions.LargeImage")));
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonHoc_ItemClick);
            // 
            // btnGVDK
            // 
            this.btnGVDK.Caption = "Giảng viên đăng ký";
            this.btnGVDK.Id = 15;
            this.btnGVDK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGVDK.ImageOptions.Image")));
            this.btnGVDK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGVDK.ImageOptions.LargeImage")));
            this.btnGVDK.Name = "btnGVDK";
            this.btnGVDK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGVDK_ItemClick);
            // 
            // btnDeThi
            // 
            this.btnDeThi.Caption = "Đề thi";
            this.btnDeThi.Id = 16;
            this.btnDeThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeThi.ImageOptions.Image")));
            this.btnDeThi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeThi.ImageOptions.LargeImage")));
            this.btnDeThi.Name = "btnDeThi";
            this.btnDeThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeThi_ItemClick);
            // 
            // btnTaoTaiKhoan
            // 
            this.btnTaoTaiKhoan.Caption = "Tạo tài khoản";
            this.btnTaoTaiKhoan.Id = 17;
            this.btnTaoTaiKhoan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaoTaiKhoan.ImageOptions.SvgImage")));
            this.btnTaoTaiKhoan.Name = "btnTaoTaiKhoan";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 18;
            this.btnDangXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.Image")));
            this.btnDangXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.LargeImage")));
            this.btnDangXuat.Name = "btnDangXuat";
            // 
            // btnGiaoVien
            // 
            this.btnGiaoVien.Caption = "Giáo viên";
            this.btnGiaoVien.Id = 20;
            this.btnGiaoVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGiaoVien.ImageOptions.SvgImage")));
            this.btnGiaoVien.Name = "btnGiaoVien";
            this.btnGiaoVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGiaoVien_ItemClick);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Caption = "Sinh viên";
            this.btnSinhVien.Id = 21;
            this.btnSinhVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSinhVien.ImageOptions.SvgImage")));
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSinhVien_ItemClick);
            // 
            // btnThiThu
            // 
            this.btnThiThu.Caption = "Thi thử";
            this.btnThiThu.Id = 22;
            this.btnThiThu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThiThu.ImageOptions.SvgImage")));
            this.btnThiThu.Name = "btnThiThu";
            this.btnThiThu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThiThu_ItemClick);
            // 
            // rbpQuanLy
            // 
            this.rbpQuanLy.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbpgKhoa,
            this.rbpgLop,
            this.rnpgGiaoVien,
            this.rbgpSinhVien,
            this.rbpgMonHoc,
            this.rbpgGVDK,
            this.rbpgDeThi,
            this.ribbonPageGroup1});
            this.rbpQuanLy.Name = "rbpQuanLy";
            this.rbpQuanLy.Text = "Quản lý";
            // 
            // rbpgKhoa
            // 
            this.rbpgKhoa.ItemLinks.Add(this.btnKhoa);
            this.rbpgKhoa.Name = "rbpgKhoa";
            // 
            // rbpgLop
            // 
            this.rbpgLop.ItemLinks.Add(this.btnLop);
            this.rbpgLop.Name = "rbpgLop";
            // 
            // rnpgGiaoVien
            // 
            this.rnpgGiaoVien.ItemLinks.Add(this.btnGiaoVien);
            this.rnpgGiaoVien.Name = "rnpgGiaoVien";
            // 
            // rbgpSinhVien
            // 
            this.rbgpSinhVien.ItemLinks.Add(this.btnSinhVien);
            this.rbgpSinhVien.Name = "rbgpSinhVien";
            // 
            // rbpgMonHoc
            // 
            this.rbpgMonHoc.ItemLinks.Add(this.btnMonHoc);
            this.rbpgMonHoc.Name = "rbpgMonHoc";
            // 
            // rbpgGVDK
            // 
            this.rbpgGVDK.ItemLinks.Add(this.btnGVDK);
            this.rbpgGVDK.Name = "rbpgGVDK";
            // 
            // rbpgDeThi
            // 
            this.rbpgDeThi.ItemLinks.Add(this.btnDeThi);
            this.rbpgDeThi.Name = "rbpgDeThi";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnThiThu);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // rbpTaiKhoan
            // 
            this.rbpTaiKhoan.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbpgTaoTaiKhoan,
            this.rbpgDangXuat});
            this.rbpTaiKhoan.Name = "rbpTaiKhoan";
            this.rbpTaiKhoan.Text = "Tài khoản";
            // 
            // rbpgTaoTaiKhoan
            // 
            this.rbpgTaoTaiKhoan.ItemLinks.Add(this.btnTaoTaiKhoan);
            this.rbpgTaoTaiKhoan.Name = "rbpgTaoTaiKhoan";
            // 
            // rbpgDangXuat
            // 
            this.rbpgDangXuat.ItemLinks.Add(this.btnDangXuat);
            this.rbpgDangXuat.Name = "rbpgDangXuat";
            // 
            // rbpBaoCao
            // 
            this.rbpBaoCao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rbpBaoCao.Name = "rbpBaoCao";
            this.rbpBaoCao.Text = "Báo cáo";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaGVSV,
            this.HoTen,
            this.Nhom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 345);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.statusStrip1.Size = new System.Drawing.Size(810, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MaGVSV
            // 
            this.MaGVSV.Name = "MaGVSV";
            this.MaGVSV.Size = new System.Drawing.Size(130, 17);
            this.MaGVSV.Text = "Mã giáo viên/ sinh viên";
            // 
            // HoTen
            // 
            this.HoTen.Name = "HoTen";
            this.HoTen.Size = new System.Drawing.Size(43, 17);
            this.HoTen.Text = "Họ tên";
            // 
            // Nhom
            // 
            this.Nhom.Name = "Nhom";
            this.Nhom.Size = new System.Drawing.Size(41, 17);
            this.Nhom.Text = "Nhóm";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDeThi);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 367);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.Text = "Form Chính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;

        private StatusStrip statusStrip1;
        public ToolStripStatusLabel MaGVSV;
        public ToolStripStatusLabel HoTen;
        public ToolStripStatusLabel Nhom;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpQuanLy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgKhoa;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpTaiKhoan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgTaoTaiKhoan;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnKhoa;
        private DevExpress.XtraBars.BarButtonItem btnLop;
        private DevExpress.XtraBars.BarButtonItem btnMonHoc;
        private DevExpress.XtraBars.BarButtonItem btnGVDK;
        private DevExpress.XtraBars.BarButtonItem btnDeThi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgLop;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgMonHoc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgGVDK;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgDeThi;
        private DevExpress.XtraBars.BarButtonItem btnTaoTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgDangXuat;
        private DevExpress.XtraBars.BarButtonItem btnGiaoVien;
        private DevExpress.XtraBars.BarButtonItem btnSinhVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rnpgGiaoVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgpSinhVien;
        private DevExpress.XtraBars.BarButtonItem btnThiThu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}