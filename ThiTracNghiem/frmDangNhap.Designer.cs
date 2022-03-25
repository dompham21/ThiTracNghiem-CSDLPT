using System.Windows.Forms;

namespace ThiTracNghiem
{
    partial class frmDangNhap
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
            this.cbCoSo = new System.Windows.Forms.ComboBox();
            this.tbTaiKhoan = new System.Windows.Forms.TextBox();
            this.tbMatKhau = new System.Windows.Forms.TextBox();
            this.btDangNhap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbMaSV = new System.Windows.Forms.TextBox();
            this.labelMaSV = new System.Windows.Forms.Label();
            this.btThoat = new System.Windows.Forms.Button();
            this.checkBoxSV = new System.Windows.Forms.CheckBox();
            this.labelCoSo = new System.Windows.Forms.Label();
            this.labelMatKhau = new System.Windows.Forms.Label();
            this.labelTaiKhoan = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCoSo
            // 
            this.cbCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbCoSo.FormattingEnabled = true;
            this.cbCoSo.Location = new System.Drawing.Point(314, 39);
            this.cbCoSo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCoSo.Name = "cbCoSo";
            this.cbCoSo.Size = new System.Drawing.Size(383, 39);
            this.cbCoSo.TabIndex = 0;
            this.cbCoSo.SelectedIndexChanged += new System.EventHandler(this.cbCoSo_SelectedIndexChanged);
            // 
            // tbTaiKhoan
            // 
            this.tbTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbTaiKhoan.Location = new System.Drawing.Point(312, 128);
            this.tbTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTaiKhoan.Name = "tbTaiKhoan";
            this.tbTaiKhoan.Size = new System.Drawing.Size(383, 48);
            this.tbTaiKhoan.TabIndex = 4;
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbMatKhau.Location = new System.Drawing.Point(312, 203);
            this.tbMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.PasswordChar = '*';
            this.tbMatKhau.Size = new System.Drawing.Size(383, 48);
            this.tbMatKhau.TabIndex = 5;
            // 
            // btDangNhap
            // 
            this.btDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDangNhap.Location = new System.Drawing.Point(199, 419);
            this.btDangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(215, 64);
            this.btDangNhap.TabIndex = 6;
            this.btDangNhap.Text = "Đăng Nhập";
            this.btDangNhap.UseVisualStyleBackColor = true;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbMaSV);
            this.panel1.Controls.Add(this.labelMaSV);
            this.panel1.Controls.Add(this.btThoat);
            this.panel1.Controls.Add(this.checkBoxSV);
            this.panel1.Controls.Add(this.labelCoSo);
            this.panel1.Controls.Add(this.labelMatKhau);
            this.panel1.Controls.Add(this.labelTaiKhoan);
            this.panel1.Controls.Add(this.cbCoSo);
            this.panel1.Controls.Add(this.btDangNhap);
            this.panel1.Controls.Add(this.tbMatKhau);
            this.panel1.Controls.Add(this.tbTaiKhoan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 548);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tbMaSV
            // 
            this.tbMaSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbMaSV.Location = new System.Drawing.Point(312, 284);
            this.tbMaSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMaSV.Name = "tbMaSV";
            this.tbMaSV.Size = new System.Drawing.Size(383, 48);
            this.tbMaSV.TabIndex = 14;
            // 
            // labelMaSV
            // 
            this.labelMaSV.AutoSize = true;
            this.labelMaSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelMaSV.Location = new System.Drawing.Point(142, 287);
            this.labelMaSV.Name = "labelMaSV";
            this.labelMaSV.Size = new System.Drawing.Size(125, 40);
            this.labelMaSV.TabIndex = 13;
            this.labelMaSV.Text = "Mã SV";
            // 
            // btThoat
            // 
            this.btThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Location = new System.Drawing.Point(496, 419);
            this.btThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(164, 64);
            this.btThoat.TabIndex = 11;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // checkBoxSV
            // 
            this.checkBoxSV.AutoSize = true;
            this.checkBoxSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBoxSV.Location = new System.Drawing.Point(314, 346);
            this.checkBoxSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSV.Name = "checkBoxSV";
            this.checkBoxSV.Size = new System.Drawing.Size(197, 44);
            this.checkBoxSV.TabIndex = 10;
            this.checkBoxSV.Text = "Sinh viên";
            this.checkBoxSV.UseVisualStyleBackColor = true;
            this.checkBoxSV.CheckedChanged += new System.EventHandler(this.checkBoxSV_CheckedChanged);
            // 
            // labelCoSo
            // 
            this.labelCoSo.AutoSize = true;
            this.labelCoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelCoSo.Location = new System.Drawing.Point(166, 39);
            this.labelCoSo.Name = "labelCoSo";
            this.labelCoSo.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCoSo.Size = new System.Drawing.Size(115, 40);
            this.labelCoSo.TabIndex = 9;
            this.labelCoSo.Text = "Cơ sở";
            // 
            // labelMatKhau
            // 
            this.labelMatKhau.AutoSize = true;
            this.labelMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatKhau.Location = new System.Drawing.Point(113, 203);
            this.labelMatKhau.Name = "labelMatKhau";
            this.labelMatKhau.Size = new System.Drawing.Size(165, 40);
            this.labelMatKhau.TabIndex = 8;
            this.labelMatKhau.Text = "Mật khẩu";
            // 
            // labelTaiKhoan
            // 
            this.labelTaiKhoan.AutoSize = true;
            this.labelTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaiKhoan.Location = new System.Drawing.Point(113, 125);
            this.labelTaiKhoan.Name = "labelTaiKhoan";
            this.labelTaiKhoan.Size = new System.Drawing.Size(175, 40);
            this.labelTaiKhoan.TabIndex = 7;
            this.labelTaiKhoan.Text = "Tài khoản";
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 548);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangNhap_FormClosing);
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cbCoSo;
        private TextBox tbTaiKhoan;
        private TextBox tbMatKhau;
        private Button btDangNhap;
        private Panel panel1;
        private Label labelMatKhau;
        private Label labelTaiKhoan;
        private CheckBox checkBoxSV;
        private Label labelCoSo;
        private Button btThoat;
        private Label labelMaSV;
        private TextBox tbMaSV;
    }
}