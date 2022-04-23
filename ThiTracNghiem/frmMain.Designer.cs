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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnKhoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonHoc = new DevExpress.XtraBars.BarButtonItem();
            this.btnGVDK = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeThi = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btnGiaoVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnSinhVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnThiThu = new DevExpress.XtraBars.BarButtonItem();
            this.btnBangDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnDSDangKyThi = new DevExpress.XtraBars.BarButtonItem();
            this.rbpQuanLy = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpgKhoa = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgGiaoVien = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbgpSinhVien = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgMonHoc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgGVDK = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgDeThi = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgThiThu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpTaiKhoan = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpgTaoTaiKhoan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgDangXuat = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MaGVSV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.Nhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator;
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(65, 67, 65, 67);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnKhoa,
            this.btnMonHoc,
            this.btnGVDK,
            this.btnDeThi,
            this.btnTaoTaiKhoan,
            this.btnDangXuat,
            this.btnGiaoVien,
            this.btnSinhVien,
            this.btnThiThu,
            this.btnBangDiem,
            this.btnDSDangKyThi});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(2);
            this.ribbon.MaxItemId = 25;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 329;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpQuanLy,
            this.rbpTaiKhoan,
            this.rbpBaoCao});
            this.ribbon.Size = new System.Drawing.Size(1755, 344);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // btnKhoa
            // 
            this.btnKhoa.Caption = "Khoa / Lớp";
            this.btnKhoa.Id = 12;
            this.btnKhoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKhoa.ImageOptions.SvgImage")));
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhoa_ItemClick);
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
            this.btnTaoTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTaiKhoan_ItemClick);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 18;
            this.btnDangXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.Image")));
            this.btnDangXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.LargeImage")));
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangXuat_ItemClick);
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
            // btnBangDiem
            // 
            this.btnBangDiem.Caption = "Bảng điểm môn học";
            this.btnBangDiem.Id = 23;
            this.btnBangDiem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBangDiem.ImageOptions.SvgImage")));
            this.btnBangDiem.Name = "btnBangDiem";
            this.btnBangDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBangDiem_ItemClick);
            // 
            // btnDSDangKyThi
            // 
            this.btnDSDangKyThi.Caption = "Danh sách đăng ký thi";
            this.btnDSDangKyThi.Id = 24;
            this.btnDSDangKyThi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDSDangKyThi.ImageOptions.SvgImage")));
            this.btnDSDangKyThi.Name = "btnDSDangKyThi";
            this.btnDSDangKyThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSDangKyThi_ItemClick);
            // 
            // rbpQuanLy
            // 
            this.rbpQuanLy.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbpgKhoa,
            this.rbpgGiaoVien,
            this.rbgpSinhVien,
            this.rbpgMonHoc,
            this.rbpgGVDK,
            this.rbpgDeThi,
            this.rbpgThiThu});
            this.rbpQuanLy.Name = "rbpQuanLy";
            this.rbpQuanLy.Text = "Quản lý";
            // 
            // rbpgKhoa
            // 
            this.rbpgKhoa.ItemLinks.Add(this.btnKhoa);
            this.rbpgKhoa.Name = "rbpgKhoa";
            // 
            // rbpgGiaoVien
            // 
            this.rbpgGiaoVien.ItemLinks.Add(this.btnGiaoVien);
            this.rbpgGiaoVien.Name = "rbpgGiaoVien";
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
            // rbpgThiThu
            // 
            this.rbpgThiThu.ItemLinks.Add(this.btnThiThu);
            this.rbpgThiThu.Name = "rbpgThiThu";
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
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.rbpBaoCao.Name = "rbpBaoCao";
            this.rbpBaoCao.Text = "Báo cáo";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnBangDiem);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDSDangKyThi);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaGVSV,
            this.HoTen,
            this.Nhom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1161);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1755, 48);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MaGVSV
            // 
            this.MaGVSV.Name = "MaGVSV";
            this.MaGVSV.Size = new System.Drawing.Size(293, 37);
            this.MaGVSV.Text = "Mã giáo viên/ sinh viên";
            // 
            // HoTen
            // 
            this.HoTen.Name = "HoTen";
            this.HoTen.Size = new System.Drawing.Size(97, 37);
            this.HoTen.Text = "Họ tên";
            // 
            // Nhom
            // 
            this.Nhom.Name = "Nhom";
            this.Nhom.Size = new System.Drawing.Size(91, 37);
            this.Nhom.Text = "Nhóm";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDeThi);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1755, 1209);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.Text = "Form Chính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnMonHoc;
        private DevExpress.XtraBars.BarButtonItem btnGVDK;
        private DevExpress.XtraBars.BarButtonItem btnDeThi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgMonHoc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgGVDK;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgDeThi;
        private DevExpress.XtraBars.BarButtonItem btnTaoTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgDangXuat;
        private DevExpress.XtraBars.BarButtonItem btnGiaoVien;
        private DevExpress.XtraBars.BarButtonItem btnSinhVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgGiaoVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgpSinhVien;
        private DevExpress.XtraBars.BarButtonItem btnThiThu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgThiThu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnBangDiem;
        private DevExpress.XtraBars.BarButtonItem btnDSDangKyThi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
    }
}