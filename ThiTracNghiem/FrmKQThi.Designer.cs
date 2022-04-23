namespace ThiTracNghiem
{
    partial class FrmKQThi
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MaGVSV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.Nhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbInfoBaiThi = new System.Windows.Forms.GroupBox();
            this.txtThoiGian = new DevExpress.XtraEditors.TextEdit();
            this.txtSoCauHoi = new DevExpress.XtraEditors.TextEdit();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDiem = new System.Windows.Forms.Label();
            this.labelSoCauDung = new System.Windows.Forms.Label();
            this.labelSoCau = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbInfoBaiThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCauHoi.Properties)).BeginInit();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaGVSV,
            this.HoTen,
            this.Nhom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 759);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 4;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.gbInfoBaiThi);
            this.panel1.Controls.Add(this.gbInfoSV);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 759);
            this.panel1.TabIndex = 5;
            // 
            // gbInfoBaiThi
            // 
            this.gbInfoBaiThi.Controls.Add(this.txtThoiGian);
            this.gbInfoBaiThi.Controls.Add(this.txtSoCauHoi);
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
            this.gbInfoBaiThi.Location = new System.Drawing.Point(0, 0);
            this.gbInfoBaiThi.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoBaiThi.Name = "gbInfoBaiThi";
            this.gbInfoBaiThi.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoBaiThi.Size = new System.Drawing.Size(642, 250);
            this.gbInfoBaiThi.TabIndex = 3;
            this.gbInfoBaiThi.TabStop = false;
            this.gbInfoBaiThi.Text = "Thông tin bài thi";
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.Enabled = false;
            this.txtThoiGian.Location = new System.Drawing.Point(294, 86);
            this.txtThoiGian.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThoiGian.Properties.Appearance.Options.UseFont = true;
            this.txtThoiGian.Size = new System.Drawing.Size(138, 24);
            this.txtThoiGian.TabIndex = 11;
            // 
            // txtSoCauHoi
            // 
            this.txtSoCauHoi.Enabled = false;
            this.txtSoCauHoi.Location = new System.Drawing.Point(294, 144);
            this.txtSoCauHoi.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtSoCauHoi.Name = "txtSoCauHoi";
            this.txtSoCauHoi.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoCauHoi.Properties.Appearance.Options.UseFont = true;
            this.txtSoCauHoi.Size = new System.Drawing.Size(138, 24);
            this.txtSoCauHoi.TabIndex = 10;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(232, 89);
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
            this.labelControl6.Location = new System.Drawing.Point(232, 147);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 17);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Số câu";
            // 
            // txtTrinhDo
            // 
            this.txtTrinhDo.Enabled = false;
            this.txtTrinhDo.Location = new System.Drawing.Point(505, 86);
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
            this.txtLan.Location = new System.Drawing.Point(505, 144);
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
            this.txtMaMon.Location = new System.Drawing.Point(70, 86);
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
            this.labelControl4.Location = new System.Drawing.Point(6, 89);
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
            this.labelControl3.Location = new System.Drawing.Point(448, 89);
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
            this.labelControl2.Location = new System.Drawing.Point(448, 147);
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
            this.labelControl1.Location = new System.Drawing.Point(6, 147);
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
            this.dateNgayThi.Location = new System.Drawing.Point(70, 144);
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
            this.gbInfoSV.ForeColor = System.Drawing.Color.DarkBlue;
            this.gbInfoSV.Location = new System.Drawing.Point(642, 0);
            this.gbInfoSV.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoSV.Name = "gbInfoSV";
            this.gbInfoSV.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoSV.Size = new System.Drawing.Size(642, 250);
            this.gbInfoSV.TabIndex = 4;
            this.gbInfoSV.TabStop = false;
            this.gbInfoSV.Text = "Thông tin sinh viên";
            // 
            // txtTenLop
            // 
            this.txtTenLop.Enabled = false;
            this.txtTenLop.Location = new System.Drawing.Point(417, 144);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLop.Properties.Appearance.Options.UseFont = true;
            this.txtTenLop.Size = new System.Drawing.Size(156, 24);
            this.txtTenLop.TabIndex = 25;
            // 
            // labeltenlop
            // 
            this.labeltenlop.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltenlop.Appearance.Options.UseFont = true;
            this.labeltenlop.Location = new System.Drawing.Point(346, 147);
            this.labeltenlop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labeltenlop.Name = "labeltenlop";
            this.labeltenlop.Size = new System.Drawing.Size(45, 17);
            this.labeltenlop.TabIndex = 24;
            this.labeltenlop.Text = "Tên lớp";
            // 
            // txtMaLop
            // 
            this.txtMaLop.Enabled = false;
            this.txtMaLop.Location = new System.Drawing.Point(130, 144);
            this.txtMaLop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLop.Properties.Appearance.Options.UseFont = true;
            this.txtMaLop.Size = new System.Drawing.Size(156, 24);
            this.txtMaLop.TabIndex = 23;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(69, 147);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(42, 17);
            this.labelControl9.TabIndex = 22;
            this.labelControl9.Text = "Mã lớp";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(417, 86);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Properties.Appearance.Options.UseFont = true;
            this.txtHoTen.Size = new System.Drawing.Size(156, 24);
            this.txtHoTen.TabIndex = 21;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(346, 89);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(58, 17);
            this.labelControl8.TabIndex = 20;
            this.labelControl8.Text = "Họ và tên";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Enabled = false;
            this.txtMaSV.Location = new System.Drawing.Point(130, 86);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSV.Properties.Appearance.Options.UseFont = true;
            this.txtMaSV.Size = new System.Drawing.Size(156, 24);
            this.txtMaSV.TabIndex = 19;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(69, 89);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(43, 17);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "Mã SV";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.labelDiem);
            this.groupBox1.Controls.Add(this.labelSoCauDung);
            this.groupBox1.Controls.Add(this.labelSoCau);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Location = new System.Drawing.Point(0, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1284, 509);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả làm bài";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(589, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDiem
            // 
            this.labelDiem.AutoSize = true;
            this.labelDiem.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiem.Location = new System.Drawing.Point(600, 172);
            this.labelDiem.Name = "labelDiem";
            this.labelDiem.Size = new System.Drawing.Size(18, 27);
            this.labelDiem.TabIndex = 5;
            this.labelDiem.Text = " ";
            // 
            // labelSoCauDung
            // 
            this.labelSoCauDung.AutoSize = true;
            this.labelSoCauDung.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoCauDung.Location = new System.Drawing.Point(600, 128);
            this.labelSoCauDung.Name = "labelSoCauDung";
            this.labelSoCauDung.Size = new System.Drawing.Size(18, 27);
            this.labelSoCauDung.TabIndex = 4;
            this.labelSoCauDung.Text = " ";
            // 
            // labelSoCau
            // 
            this.labelSoCau.AutoSize = true;
            this.labelSoCau.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoCau.Location = new System.Drawing.Point(600, 83);
            this.labelSoCau.Name = "labelSoCau";
            this.labelSoCau.Size = new System.Drawing.Size(18, 27);
            this.labelSoCau.TabIndex = 3;
            this.labelSoCau.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(373, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng điểm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(372, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số câu trả lời đúng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(372, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng số câu hỏi:";
            // 
            // FrmKQThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 781);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmKQThi";
            this.Text = "frmKQThi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmKQThi_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbInfoBaiThi.ResumeLayout(false);
            this.gbInfoBaiThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThoiGian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCauHoi.Properties)).EndInit();
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel MaGVSV;
        public System.Windows.Forms.ToolStripStatusLabel HoTen;
        public System.Windows.Forms.ToolStripStatusLabel Nhom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDiem;
        private System.Windows.Forms.Label labelSoCauDung;
        private System.Windows.Forms.Label labelSoCau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbInfoBaiThi;
        private DevExpress.XtraEditors.TextEdit txtThoiGian;
        private DevExpress.XtraEditors.TextEdit txtSoCauHoi;
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
        private System.Windows.Forms.GroupBox gbInfoSV;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraEditors.TextEdit txtTenLop;
        private DevExpress.XtraEditors.LabelControl labeltenlop;
        private DevExpress.XtraEditors.TextEdit txtMaLop;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtMaSV;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}