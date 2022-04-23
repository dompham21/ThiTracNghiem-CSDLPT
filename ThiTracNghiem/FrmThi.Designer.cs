namespace ThiTracNghiem
{
    partial class FrmThi
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gbInfoBaiThi = new System.Windows.Forms.GroupBox();
            this.txtThoiGian = new DevExpress.XtraEditors.TextEdit();
            this.txtSoCau = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtTrinhDo = new DevExpress.XtraEditors.TextEdit();
            this.txtLan = new DevExpress.XtraEditors.TextEdit();
            this.txtMaMon = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateNgayThi = new DevExpress.XtraEditors.DateEdit();
            this.gbInfoSV = new System.Windows.Forms.GroupBox();
            this.txtTenLop = new DevExpress.XtraEditors.TextEdit();
            this.labeltenlop = new DevExpress.XtraEditors.LabelControl();
            this.txtMaLop = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaSV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnNop = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MaGVSV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.Nhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dS = new ThiTracNghiem.DS();
            this.bdsDeThi = new System.Windows.Forms.BindingSource(this.components);
            this.tbDeThiADT = new ThiTracNghiem.DSTableAdapters.BANGDIEMTableAdapter();
            this.tableAdapterManager = new ThiTracNghiem.DSTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewDAChon = new System.Windows.Forms.ListView();
            this.colCau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDapAn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowDeThi = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.gbInfoBaiThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayThi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayThi.Properties)).BeginInit();
            this.gbInfoSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeThi)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowDeThi.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gbInfoBaiThi);
            this.panelControl1.Controls.Add(this.gbInfoSV);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1284, 180);
            this.panelControl1.TabIndex = 0;
            // 
            // gbInfoBaiThi
            // 
            this.gbInfoBaiThi.Controls.Add(this.txtThoiGian);
            this.gbInfoBaiThi.Controls.Add(this.txtSoCau);
            this.gbInfoBaiThi.Controls.Add(this.labelControl5);
            this.gbInfoBaiThi.Controls.Add(this.labelControl6);
            this.gbInfoBaiThi.Controls.Add(this.txtTrinhDo);
            this.gbInfoBaiThi.Controls.Add(this.txtLan);
            this.gbInfoBaiThi.Controls.Add(this.txtMaMon);
            this.gbInfoBaiThi.Controls.Add(this.labelControl4);
            this.gbInfoBaiThi.Controls.Add(this.labelControl3);
            this.gbInfoBaiThi.Controls.Add(this.labelControl2);
            this.gbInfoBaiThi.Controls.Add(this.labelControl1);
            this.gbInfoBaiThi.Controls.Add(this.dateNgayThi);
            this.gbInfoBaiThi.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbInfoBaiThi.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfoBaiThi.ForeColor = System.Drawing.Color.DarkBlue;
            this.gbInfoBaiThi.Location = new System.Drawing.Point(2, 2);
            this.gbInfoBaiThi.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoBaiThi.Name = "gbInfoBaiThi";
            this.gbInfoBaiThi.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoBaiThi.Size = new System.Drawing.Size(642, 176);
            this.gbInfoBaiThi.TabIndex = 0;
            this.gbInfoBaiThi.TabStop = false;
            this.gbInfoBaiThi.Text = "Thông tin bài thi";
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.Enabled = false;
            this.txtThoiGian.Location = new System.Drawing.Point(292, 48);
            this.txtThoiGian.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThoiGian.Properties.Appearance.Options.UseFont = true;
            this.txtThoiGian.Size = new System.Drawing.Size(138, 24);
            this.txtThoiGian.TabIndex = 11;
            // 
            // txtSoCau
            // 
            this.txtSoCau.Enabled = false;
            this.txtSoCau.Location = new System.Drawing.Point(292, 106);
            this.txtSoCau.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtSoCau.Name = "txtSoCau";
            this.txtSoCau.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoCau.Properties.Appearance.Options.UseFont = true;
            this.txtSoCau.Size = new System.Drawing.Size(138, 24);
            this.txtSoCau.TabIndex = 10;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(230, 51);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 17);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Thời gian";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(230, 109);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 17);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Số câu";
            // 
            // txtTrinhDo
            // 
            this.txtTrinhDo.Enabled = false;
            this.txtTrinhDo.Location = new System.Drawing.Point(503, 106);
            this.txtTrinhDo.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtTrinhDo.Name = "txtTrinhDo";
            this.txtTrinhDo.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrinhDo.Properties.Appearance.Options.UseFont = true;
            this.txtTrinhDo.Size = new System.Drawing.Size(130, 24);
            this.txtTrinhDo.TabIndex = 7;
            // 
            // txtLan
            // 
            this.txtLan.Enabled = false;
            this.txtLan.Location = new System.Drawing.Point(503, 48);
            this.txtLan.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtLan.Name = "txtLan";
            this.txtLan.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLan.Properties.Appearance.Options.UseFont = true;
            this.txtLan.Size = new System.Drawing.Size(130, 24);
            this.txtLan.TabIndex = 6;
            // 
            // txtMaMon
            // 
            this.txtMaMon.Enabled = false;
            this.txtMaMon.Location = new System.Drawing.Point(68, 48);
            this.txtMaMon.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMon.Properties.Appearance.Options.UseFont = true;
            this.txtMaMon.Size = new System.Drawing.Size(140, 24);
            this.txtMaMon.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(4, 51);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 17);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Mã môn";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(446, 51);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 17);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Trình độ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(446, 109);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 17);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Lần thi";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(4, 109);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 17);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Ngày thi";
            // 
            // dateNgayThi
            // 
            this.dateNgayThi.EditValue = null;
            this.dateNgayThi.Enabled = false;
            this.dateNgayThi.Location = new System.Drawing.Point(68, 106);
            this.dateNgayThi.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.dateNgayThi.Name = "dateNgayThi";
            this.dateNgayThi.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgayThi.Properties.Appearance.Options.UseFont = true;
            this.dateNgayThi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayThi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayThi.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dateNgayThi.Properties.UseMaskAsDisplayFormat = true;
            this.dateNgayThi.Size = new System.Drawing.Size(140, 24);
            this.dateNgayThi.TabIndex = 0;
            // 
            // gbInfoSV
            // 
            this.gbInfoSV.Controls.Add(this.txtTenLop);
            this.gbInfoSV.Controls.Add(this.labeltenlop);
            this.gbInfoSV.Controls.Add(this.txtMaLop);
            this.gbInfoSV.Controls.Add(this.labelControl9);
            this.gbInfoSV.Controls.Add(this.txtHoTen);
            this.gbInfoSV.Controls.Add(this.labelControl8);
            this.gbInfoSV.Controls.Add(this.txtMaSV);
            this.gbInfoSV.Controls.Add(this.labelControl7);
            this.gbInfoSV.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbInfoSV.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfoSV.ForeColor = System.Drawing.Color.DarkBlue;
            this.gbInfoSV.Location = new System.Drawing.Point(644, 2);
            this.gbInfoSV.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoSV.Name = "gbInfoSV";
            this.gbInfoSV.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoSV.Size = new System.Drawing.Size(638, 176);
            this.gbInfoSV.TabIndex = 2;
            this.gbInfoSV.TabStop = false;
            this.gbInfoSV.Text = "Thông tin sinh viên";
            // 
            // txtTenLop
            // 
            this.txtTenLop.Enabled = false;
            this.txtTenLop.Location = new System.Drawing.Point(370, 106);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLop.Properties.Appearance.Options.UseFont = true;
            this.txtTenLop.Size = new System.Drawing.Size(156, 24);
            this.txtTenLop.TabIndex = 17;
            // 
            // labeltenlop
            // 
            this.labeltenlop.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltenlop.Appearance.Options.UseFont = true;
            this.labeltenlop.Location = new System.Drawing.Point(299, 109);
            this.labeltenlop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labeltenlop.Name = "labeltenlop";
            this.labeltenlop.Size = new System.Drawing.Size(45, 17);
            this.labeltenlop.TabIndex = 16;
            this.labeltenlop.Text = "Tên lớp";
            // 
            // txtMaLop
            // 
            this.txtMaLop.Enabled = false;
            this.txtMaLop.Location = new System.Drawing.Point(83, 106);
            this.txtMaLop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLop.Properties.Appearance.Options.UseFont = true;
            this.txtMaLop.Size = new System.Drawing.Size(156, 24);
            this.txtMaLop.TabIndex = 15;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(22, 109);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(42, 17);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "Mã lớp";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(370, 48);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Properties.Appearance.Options.UseFont = true;
            this.txtHoTen.Size = new System.Drawing.Size(156, 24);
            this.txtHoTen.TabIndex = 11;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(299, 51);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(58, 17);
            this.labelControl8.TabIndex = 10;
            this.labelControl8.Text = "Họ và tên";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Enabled = false;
            this.txtMaSV.Location = new System.Drawing.Point(83, 48);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSV.Properties.Appearance.Options.UseFont = true;
            this.txtMaSV.Size = new System.Drawing.Size(156, 24);
            this.txtMaSV.TabIndex = 9;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(22, 51);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(43, 17);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "Mã SV";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnThoat);
            this.panelControl2.Controls.Add(this.btnNop);
            this.panelControl2.Controls.Add(this.labelTime);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 180);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1284, 84);
            this.panelControl2.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(821, 24);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(165, 42);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnNop
            // 
            this.btnNop.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNop.Location = new System.Drawing.Point(165, 24);
            this.btnNop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.btnNop.Name = "btnNop";
            this.btnNop.Size = new System.Drawing.Size(165, 42);
            this.btnNop.TabIndex = 5;
            this.btnNop.Text = "Nộp bài";
            this.btnNop.UseVisualStyleBackColor = true;
            this.btnNop.Click += new System.EventHandler(this.btnNop_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.Green;
            this.labelTime.Location = new System.Drawing.Point(598, 28);
            this.labelTime.Margin = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(23, 34);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(500, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thời gian:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaGVSV,
            this.HoTen,
            this.Nhom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 592);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 3;
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
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbDeThiADT
            // 
            this.tbDeThiADT.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = this.tbDeThiADT;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.CT_BAITHITableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ThiTracNghiem.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listViewDAChon);
            this.panel1.Controls.Add(this.flowDeThi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 328);
            this.panel1.TabIndex = 4;
            // 
            // listViewDAChon
            // 
            this.listViewDAChon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCau,
            this.colDapAn});
            this.listViewDAChon.Dock = System.Windows.Forms.DockStyle.Right;
            this.listViewDAChon.GridLines = true;
            this.listViewDAChon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDAChon.HideSelection = false;
            this.listViewDAChon.Location = new System.Drawing.Point(1047, 0);
            this.listViewDAChon.Name = "listViewDAChon";
            this.listViewDAChon.Size = new System.Drawing.Size(237, 328);
            this.listViewDAChon.TabIndex = 7;
            this.listViewDAChon.UseCompatibleStateImageBehavior = false;
            this.listViewDAChon.View = System.Windows.Forms.View.Details;
            // 
            // colCau
            // 
            this.colCau.Text = "Câu hỏi";
            // 
            // colDapAn
            // 
            this.colDapAn.Text = "Đáp án";
            this.colDapAn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDapAn.Width = 171;
            // 
            // flowDeThi
            // 
            this.flowDeThi.AutoScroll = true;
            this.flowDeThi.Controls.Add(this.flowLayoutPanel1);
            this.flowDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowDeThi.Location = new System.Drawing.Point(0, 0);
            this.flowDeThi.Name = "flowDeThi";
            this.flowDeThi.Size = new System.Drawing.Size(1284, 328);
            this.flowDeThi.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // FrmThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 614);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmThi";
            this.Text = "Form Thi Thử";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmThi_FormClosing);
            this.Load += new System.EventHandler(this.FrmThiThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.gbInfoBaiThi.ResumeLayout(false);
            this.gbInfoBaiThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayThi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayThi.Properties)).EndInit();
            this.gbInfoSV.ResumeLayout(false);
            this.gbInfoSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeThi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowDeThi.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox gbInfoBaiThi;
        private DevExpress.XtraEditors.TextEdit txtThoiGian;
        private DevExpress.XtraEditors.TextEdit txtSoCau;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtTrinhDo;
        private DevExpress.XtraEditors.TextEdit txtLan;
        private DevExpress.XtraEditors.TextEdit txtMaMon;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateNgayThi;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnNop;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel MaGVSV;
        public System.Windows.Forms.ToolStripStatusLabel HoTen;
        public System.Windows.Forms.ToolStripStatusLabel Nhom;
        private System.Windows.Forms.Timer timer1;
        private DS dS;
        private System.Windows.Forms.BindingSource bdsDeThi;
        private DSTableAdapters.BANGDIEMTableAdapter tbDeThiADT;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.GroupBox gbInfoSV;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ListView listViewDAChon;
        private System.Windows.Forms.FlowLayoutPanel flowDeThi;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ColumnHeader colCau;
        private System.Windows.Forms.ColumnHeader colDapAn;
        private System.Windows.Forms.Button btnThoat;
        private DevExpress.XtraEditors.TextEdit txtMaSV;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtTenLop;
        private DevExpress.XtraEditors.LabelControl labeltenlop;
        private DevExpress.XtraEditors.TextEdit txtMaLop;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}