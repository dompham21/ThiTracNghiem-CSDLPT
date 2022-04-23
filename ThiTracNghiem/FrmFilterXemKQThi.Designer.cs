namespace ThiTracNghiem
{
    partial class FrmFilterXemKQThi
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
            this.gbInfoSV = new System.Windows.Forms.GroupBox();
            this.txtTenLop = new DevExpress.XtraEditors.TextEdit();
            this.labeltenlop = new DevExpress.XtraEditors.LabelControl();
            this.txtMaLop = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaSV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.gbInfoBaiThi = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.cbbTenMon = new System.Windows.Forms.ComboBox();
            this.bdsSPMonHoc = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new ThiTracNghiem.DS();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cbbLanThi = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.txtMaMon = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.tableAdapterManager = new ThiTracNghiem.DSTableAdapters.TableAdapterManager();
            this.tbMHocADT = new ThiTracNghiem.DSTableAdapters.SP_GET_MH_DATHI_SVTableAdapter();
            this.gbInfoSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSV.Properties)).BeginInit();
            this.gbInfoBaiThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSPMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfoSV
            // 
            this.gbInfoSV.Controls.Add(this.txtTenLop);
            this.gbInfoSV.Controls.Add(this.labeltenlop);
            this.gbInfoSV.Controls.Add(this.txtMaLop);
            this.gbInfoSV.Controls.Add(this.labelControl3);
            this.gbInfoSV.Controls.Add(this.txtHoTen);
            this.gbInfoSV.Controls.Add(this.labelControl1);
            this.gbInfoSV.Controls.Add(this.txtMaSV);
            this.gbInfoSV.Controls.Add(this.labelControl4);
            this.gbInfoSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInfoSV.Enabled = false;
            this.gbInfoSV.ForeColor = System.Drawing.Color.DarkBlue;
            this.gbInfoSV.Location = new System.Drawing.Point(0, 0);
            this.gbInfoSV.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoSV.Name = "gbInfoSV";
            this.gbInfoSV.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoSV.Size = new System.Drawing.Size(1284, 87);
            this.gbInfoSV.TabIndex = 4;
            this.gbInfoSV.TabStop = false;
            this.gbInfoSV.Text = "Thông tin sinh viên";
            // 
            // txtTenLop
            // 
            this.txtTenLop.Enabled = false;
            this.txtTenLop.Location = new System.Drawing.Point(879, 37);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLop.Properties.Appearance.Options.UseFont = true;
            this.txtTenLop.Size = new System.Drawing.Size(156, 24);
            this.txtTenLop.TabIndex = 13;
            // 
            // labeltenlop
            // 
            this.labeltenlop.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltenlop.Appearance.Options.UseFont = true;
            this.labeltenlop.Location = new System.Drawing.Point(820, 40);
            this.labeltenlop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labeltenlop.Name = "labeltenlop";
            this.labeltenlop.Size = new System.Drawing.Size(45, 17);
            this.labeltenlop.TabIndex = 12;
            this.labeltenlop.Text = "Tên lớp";
            // 
            // txtMaLop
            // 
            this.txtMaLop.Enabled = false;
            this.txtMaLop.Location = new System.Drawing.Point(623, 37);
            this.txtMaLop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLop.Properties.Appearance.Options.UseFont = true;
            this.txtMaLop.Size = new System.Drawing.Size(156, 24);
            this.txtMaLop.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(567, 40);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 17);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Mã lớp";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(364, 37);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Properties.Appearance.Options.UseFont = true;
            this.txtHoTen.Size = new System.Drawing.Size(156, 24);
            this.txtHoTen.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(293, 40);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 17);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Họ và tên";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Enabled = false;
            this.txtMaSV.Location = new System.Drawing.Point(73, 37);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSV.Properties.Appearance.Options.UseFont = true;
            this.txtMaSV.Size = new System.Drawing.Size(156, 24);
            this.txtMaSV.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(14, 40);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 17);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Mã SV";
            // 
            // gbInfoBaiThi
            // 
            this.gbInfoBaiThi.Controls.Add(this.btnThoat);
            this.gbInfoBaiThi.Controls.Add(this.cbbTenMon);
            this.gbInfoBaiThi.Controls.Add(this.labelControl5);
            this.gbInfoBaiThi.Controls.Add(this.cbbLanThi);
            this.gbInfoBaiThi.Controls.Add(this.btnLoc);
            this.gbInfoBaiThi.Controls.Add(this.txtMaMon);
            this.gbInfoBaiThi.Controls.Add(this.labelControl2);
            this.gbInfoBaiThi.Controls.Add(this.labelControl8);
            this.gbInfoBaiThi.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInfoBaiThi.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfoBaiThi.ForeColor = System.Drawing.Color.DarkBlue;
            this.gbInfoBaiThi.Location = new System.Drawing.Point(0, 87);
            this.gbInfoBaiThi.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoBaiThi.Name = "gbInfoBaiThi";
            this.gbInfoBaiThi.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.gbInfoBaiThi.Size = new System.Drawing.Size(1284, 546);
            this.gbInfoBaiThi.TabIndex = 5;
            this.gbInfoBaiThi.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(677, 251);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(109, 40);
            this.btnThoat.TabIndex = 44;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cbbTenMon
            // 
            this.cbbTenMon.DataSource = this.bdsSPMonHoc;
            this.cbbTenMon.DisplayMember = "TENMH";
            this.cbbTenMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenMon.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTenMon.FormattingEnabled = true;
            this.cbbTenMon.Location = new System.Drawing.Point(545, 99);
            this.cbbTenMon.Name = "cbbTenMon";
            this.cbbTenMon.Size = new System.Drawing.Size(223, 25);
            this.cbbTenMon.TabIndex = 31;
            this.cbbTenMon.ValueMember = "MAMH";
            this.cbbTenMon.SelectedIndexChanged += new System.EventHandler(this.cbbTenMon_SelectedIndexChanged);
            // 
            // bdsSPMonHoc
            // 
            this.bdsSPMonHoc.DataMember = "SP_GET_MH_DATHI_SV";
            this.bdsSPMonHoc.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(440, 102);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 17);
            this.labelControl5.TabIndex = 30;
            this.labelControl5.Text = "Tên môn";
            // 
            // cbbLanThi
            // 
            this.cbbLanThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLanThi.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLanThi.FormattingEnabled = true;
            this.cbbLanThi.Location = new System.Drawing.Point(545, 148);
            this.cbbLanThi.Name = "cbbLanThi";
            this.cbbLanThi.Size = new System.Drawing.Size(156, 25);
            this.cbbLanThi.TabIndex = 29;
            // 
            // btnLoc
            // 
            this.btnLoc.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLoc.Location = new System.Drawing.Point(514, 253);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(104, 38);
            this.btnLoc.TabIndex = 8;
            this.btnLoc.Text = "Xem kết quả";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // txtMaMon
            // 
            this.txtMaMon.Enabled = false;
            this.txtMaMon.Location = new System.Drawing.Point(853, 100);
            this.txtMaMon.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMon.Properties.Appearance.Options.UseFont = true;
            this.txtMaMon.Size = new System.Drawing.Size(140, 24);
            this.txtMaMon.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(789, 103);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 17);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Mã môn";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(440, 151);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(41, 17);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Lần thi";
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.Connection = null;
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
            // tbMHocADT
            // 
            this.tbMHocADT.ClearBeforeFill = true;
            // 
            // FrmFilterXemKQThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 781);
            this.Controls.Add(this.gbInfoBaiThi);
            this.Controls.Add(this.gbInfoSV);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmFilterXemKQThi";
            this.Text = "Form xem kết quả thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmFilterXemKQThi_Load);
            this.gbInfoSV.ResumeLayout(false);
            this.gbInfoSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSV.Properties)).EndInit();
            this.gbInfoBaiThi.ResumeLayout(false);
            this.gbInfoBaiThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSPMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfoSV;
        private DevExpress.XtraEditors.TextEdit txtTenLop;
        private DevExpress.XtraEditors.LabelControl labeltenlop;
        private DevExpress.XtraEditors.TextEdit txtMaLop;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMaSV;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.GroupBox gbInfoBaiThi;
        private System.Windows.Forms.ComboBox cbbTenMon;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.ComboBox cbbLanThi;
        private System.Windows.Forms.Button btnLoc;
        private DevExpress.XtraEditors.TextEdit txtMaMon;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.Button btnThoat;
        private DS DS;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource bdsSPMonHoc;
        private DSTableAdapters.SP_GET_MH_DATHI_SVTableAdapter tbMHocADT;
    }
}