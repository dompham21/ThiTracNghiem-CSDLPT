namespace ThiTracNghiem
{
    partial class FrmTaoTaiKhoan
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
            this.lbLoaiTaiKhoan = new System.Windows.Forms.Label();
            this.lbLoginName = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbPass = new System.Windows.Forms.Label();
            this.cbbLoaiTK = new System.Windows.Forms.ComboBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.cbbTenGV = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtMaGV = new DevExpress.XtraEditors.TextEdit();
            this.DS = new ThiTracNghiem.DS();
            this.bdsGVChuaDK = new System.Windows.Forms.BindingSource(this.components);
            this.tbGVChuaDK = new ThiTracNghiem.DSTableAdapters.SP_GET_GV_CHUA_DKTableAdapter();
            this.tableAdapterManager = new ThiTracNghiem.DSTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVChuaDK)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLoaiTaiKhoan
            // 
            this.lbLoaiTaiKhoan.AutoSize = true;
            this.lbLoaiTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoaiTaiKhoan.Location = new System.Drawing.Point(359, 94);
            this.lbLoaiTaiKhoan.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbLoaiTaiKhoan.Name = "lbLoaiTaiKhoan";
            this.lbLoaiTaiKhoan.Size = new System.Drawing.Size(108, 20);
            this.lbLoaiTaiKhoan.TabIndex = 0;
            this.lbLoaiTaiKhoan.Text = "Loại tài khoản";
            // 
            // lbLoginName
            // 
            this.lbLoginName.AutoSize = true;
            this.lbLoginName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoginName.Location = new System.Drawing.Point(359, 159);
            this.lbLoginName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbLoginName.Name = "lbLoginName";
            this.lbLoginName.Size = new System.Drawing.Size(116, 20);
            this.lbLoginName.TabIndex = 1;
            this.lbLoginName.Text = "Tên đăng nhập";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(359, 224);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(106, 20);
            this.lbUserName.TabIndex = 2;
            this.lbUserName.Text = "Mã giảng viên";
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPass.Location = new System.Drawing.Point(359, 291);
            this.lbPass.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(75, 20);
            this.lbPass.TabIndex = 3;
            this.lbPass.Text = "Mật khẩu";
            // 
            // cbbLoaiTK
            // 
            this.cbbLoaiTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoaiTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLoaiTK.FormattingEnabled = true;
            this.cbbLoaiTK.Location = new System.Drawing.Point(498, 91);
            this.cbbLoaiTK.Margin = new System.Windows.Forms.Padding(1);
            this.cbbLoaiTK.Name = "cbbLoaiTK";
            this.cbbLoaiTK.Size = new System.Drawing.Size(277, 28);
            this.cbbLoaiTK.TabIndex = 6;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.Location = new System.Drawing.Point(498, 156);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(277, 27);
            this.txtTenDangNhap.TabIndex = 7;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(673, 403);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(132, 44);
            this.btnThoat.TabIndex = 21;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangKy.Location = new System.Drawing.Point(425, 403);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(1);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(132, 44);
            this.btnDangKy.TabIndex = 20;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // cbbTenGV
            // 
            this.cbbTenGV.DataSource = this.bdsGVChuaDK;
            this.cbbTenGV.DisplayMember = "HOTEN";
            this.cbbTenGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTenGV.FormattingEnabled = true;
            this.cbbTenGV.Location = new System.Drawing.Point(498, 219);
            this.cbbTenGV.Margin = new System.Windows.Forms.Padding(1);
            this.cbbTenGV.Name = "cbbTenGV";
            this.cbbTenGV.Size = new System.Drawing.Size(277, 28);
            this.cbbTenGV.TabIndex = 26;
            this.cbbTenGV.ValueMember = "MAGV";
            this.cbbTenGV.SelectedIndexChanged += new System.EventHandler(this.cbbTenGV_SelectedIndexChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(498, 288);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(1);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(277, 27);
            this.txtPassword.TabIndex = 32;
            // 
            // txtMaGV
            // 
            this.txtMaGV.Enabled = false;
            this.txtMaGV.Location = new System.Drawing.Point(818, 221);
            this.txtMaGV.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGV.Properties.Appearance.Options.UseFont = true;
            this.txtMaGV.Size = new System.Drawing.Size(93, 26);
            this.txtMaGV.TabIndex = 31;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsGVChuaDK
            // 
            this.bdsGVChuaDK.DataMember = "SP_GET_GV_CHUA_DK";
            this.bdsGVChuaDK.DataSource = this.DS;
            // 
            // tbGVChuaDK
            // 
            this.tbGVChuaDK.ClearBeforeFill = true;
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
            // FrmTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1260, 596);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtMaGV);
            this.Controls.Add(this.cbbTenGV);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.cbbLoaiTK);
            this.Controls.Add(this.lbPass);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbLoginName);
            this.Controls.Add(this.lbLoaiTaiKhoan);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FrmTaoTaiKhoan";
            this.Text = "Đăng ký tài khoản";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVChuaDK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLoaiTaiKhoan;
        private System.Windows.Forms.Label lbLoginName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.ComboBox cbbLoaiTK;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.ComboBox cbbTenGV;
        private DevExpress.XtraEditors.TextEdit txtMaGV;
        private System.Windows.Forms.TextBox txtPassword;
        private DS DS;
        private System.Windows.Forms.BindingSource bdsGVChuaDK;
        private DSTableAdapters.SP_GET_GV_CHUA_DKTableAdapter tbGVChuaDK;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
    }
}