namespace ThiTracNghiem
{
    partial class FrmKhoa
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
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar6 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnRedo = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaiLai = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.btnInDanhSachMH = new DevExpress.XtraBars.BarButtonItem();
            this.DS = new ThiTracNghiem.DS();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCoSo = new DevExpress.XtraEditors.TextEdit();
            this.bdsKhoa = new System.Windows.Forms.BindingSource(this.components);
            this.tENMHLabel = new System.Windows.Forms.Label();
            this.txtTenKhoa = new DevExpress.XtraEditors.TextEdit();
            this.labelMaKhoa = new System.Windows.Forms.Label();
            this.txtMaKhoa = new DevExpress.XtraEditors.TextEdit();
            this.tbKhoaADT = new ThiTracNghiem.DSTableAdapters.KHOATableAdapter();
            this.tableAdapterManager = new ThiTracNghiem.DSTableAdapters.TableAdapterManager();
            this.gcKhoa = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACS = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKhoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKhoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(580, 337);
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar6});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnGhi,
            this.btnXoa,
            this.btnSua,
            this.btnUndo,
            this.btnTaiLai,
            this.btnInDanhSachMH,
            this.btnThoat,
            this.btnRedo,
            this.btnHuy});
            this.barManager2.MainMenu = this.bar6;
            this.barManager2.MaxItemId = 11;
            // 
            // bar6
            // 
            this.bar6.BarName = "Main menu";
            this.bar6.DockCol = 0;
            this.bar6.DockRow = 0;
            this.bar6.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar6.FloatLocation = new System.Drawing.Point(467, 311);
            this.bar6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRedo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTaiLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar6.OptionsBar.MultiLine = true;
            this.bar6.OptionsBar.UseWholeRow = true;
            this.bar6.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = global::ThiTracNghiem.Properties.Resources.Button_Add_24_icon1;
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 3;
            this.btnSua.ImageOptions.Image = global::ThiTracNghiem.Properties.Resources.Text_Edit_icon_24;
            this.btnSua.Name = "btnSua";
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.Image = global::ThiTracNghiem.Properties.Resources.Delete_2_icon_24;
            this.btnXoa.Name = "btnXoa";
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy thêm/sửa";
            this.btnHuy.Id = 9;
            this.btnHuy.ImageOptions.Image = global::ThiTracNghiem.Properties.Resources.btnHuy_ImageOptions_Image;
            this.btnHuy.Name = "btnHuy";
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 1;
            this.btnGhi.ImageOptions.Image = global::ThiTracNghiem.Properties.Resources.btnGhiMH_ImageOptions_Image;
            this.btnGhi.Name = "btnGhi";
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Phục hồi";
            this.btnUndo.Id = 4;
            this.btnUndo.ImageOptions.Image = global::ThiTracNghiem.Properties.Resources.btnPhucHoiMH_ImageOptions_Image;
            this.btnUndo.Name = "btnUndo";
            // 
            // btnRedo
            // 
            this.btnRedo.Caption = "Quay lại";
            this.btnRedo.Id = 8;
            this.btnRedo.ImageOptions.Image = global::ThiTracNghiem.Properties.Resources.btnRedo_ImageOptions_Image;
            this.btnRedo.Name = "btnRedo";
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Caption = "Tải lại";
            this.btnTaiLai.Id = 5;
            this.btnTaiLai.ImageOptions.Image = global::ThiTracNghiem.Properties.Resources.Button_Refresh_icon_24;
            this.btnTaiLai.Name = "btnTaiLai";
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
            this.btnThoat.ImageOptions.Image = global::ThiTracNghiem.Properties.Resources.Exit_24_icon;
            this.btnThoat.Name = "btnThoat";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager2;
            this.barDockControl1.Margin = new System.Windows.Forms.Padding(1);
            this.barDockControl1.Size = new System.Drawing.Size(983, 40);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 724);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Margin = new System.Windows.Forms.Padding(1);
            this.barDockControl2.Size = new System.Drawing.Size(983, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 40);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Margin = new System.Windows.Forms.Padding(1);
            this.barDockControl3.Size = new System.Drawing.Size(0, 684);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(983, 40);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Margin = new System.Windows.Forms.Padding(1);
            this.barDockControl4.Size = new System.Drawing.Size(0, 684);
            // 
            // btnInDanhSachMH
            // 
            this.btnInDanhSachMH.Id = 10;
            this.btnInDanhSachMH.Name = "btnInDanhSachMH";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txtCoSo);
            this.panelControl1.Controls.Add(this.tENMHLabel);
            this.panelControl1.Controls.Add(this.txtTenKhoa);
            this.panelControl1.Controls.Add(this.labelMaKhoa);
            this.panelControl1.Controls.Add(this.txtMaKhoa);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 543);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(983, 181);
            this.panelControl1.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã cơ sở";
            // 
            // txtCoSo
            // 
            this.txtCoSo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsKhoa, "MACS", true));
            this.txtCoSo.Enabled = false;
            this.txtCoSo.Location = new System.Drawing.Point(106, 115);
            this.txtCoSo.Margin = new System.Windows.Forms.Padding(1);
            this.txtCoSo.Name = "txtCoSo";
            this.txtCoSo.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoSo.Properties.Appearance.Options.UseFont = true;
            this.txtCoSo.Size = new System.Drawing.Size(152, 24);
            this.txtCoSo.TabIndex = 9;
            // 
            // bdsKhoa
            // 
            this.bdsKhoa.DataMember = "KHOA";
            this.bdsKhoa.DataSource = this.DS;
            // 
            // tENMHLabel
            // 
            this.tENMHLabel.AutoSize = true;
            this.tENMHLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tENMHLabel.Location = new System.Drawing.Point(324, 65);
            this.tENMHLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tENMHLabel.Name = "tENMHLabel";
            this.tENMHLabel.Size = new System.Drawing.Size(63, 17);
            this.tENMHLabel.TabIndex = 6;
            this.tENMHLabel.Text = "Tên khoa";
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsKhoa, "TENKH", true));
            this.txtTenKhoa.Enabled = false;
            this.txtTenKhoa.Location = new System.Drawing.Point(409, 61);
            this.txtTenKhoa.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhoa.Properties.Appearance.Options.UseFont = true;
            this.txtTenKhoa.Size = new System.Drawing.Size(277, 24);
            this.txtTenKhoa.TabIndex = 7;
            // 
            // labelMaKhoa
            // 
            this.labelMaKhoa.AutoSize = true;
            this.labelMaKhoa.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaKhoa.Location = new System.Drawing.Point(18, 65);
            this.labelMaKhoa.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelMaKhoa.Name = "labelMaKhoa";
            this.labelMaKhoa.Size = new System.Drawing.Size(60, 17);
            this.labelMaKhoa.TabIndex = 4;
            this.labelMaKhoa.Text = "Mã khoa";
            // 
            // txtMaKhoa
            // 
            this.txtMaKhoa.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsKhoa, "MAKH", true));
            this.txtMaKhoa.Enabled = false;
            this.txtMaKhoa.Location = new System.Drawing.Point(106, 61);
            this.txtMaKhoa.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKhoa.Properties.Appearance.Options.UseFont = true;
            this.txtMaKhoa.Size = new System.Drawing.Size(152, 24);
            this.txtMaKhoa.TabIndex = 5;
            // 
            // tbKhoaADT
            // 
            this.tbKhoaADT.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = this.tbKhoaADT;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ThiTracNghiem.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gcKhoa
            // 
            this.gcKhoa.DataSource = this.bdsKhoa;
            this.gcKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcKhoa.Location = new System.Drawing.Point(0, 40);
            this.gcKhoa.MainView = this.gridView1;
            this.gcKhoa.MenuManager = this.barManager2;
            this.gcKhoa.Name = "gcKhoa";
            this.gcKhoa.Size = new System.Drawing.Size(983, 503);
            this.gcKhoa.TabIndex = 31;
            this.gcKhoa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAKH,
            this.colTENKH,
            this.colMACS});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gcKhoa;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // colMAKH
            // 
            this.colMAKH.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.colMAKH.Caption = "Mã khoa";
            this.colMAKH.FieldName = "MAKH";
            this.colMAKH.Name = "colMAKH";
            this.colMAKH.OptionsColumn.AllowEdit = false;
            this.colMAKH.Visible = true;
            this.colMAKH.VisibleIndex = 0;
            // 
            // colTENKH
            // 
            this.colTENKH.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.colTENKH.Caption = "Tên khoa";
            this.colTENKH.FieldName = "TENKH";
            this.colTENKH.Name = "colTENKH";
            this.colTENKH.OptionsColumn.AllowEdit = false;
            this.colTENKH.Visible = true;
            this.colTENKH.VisibleIndex = 1;
            // 
            // colMACS
            // 
            this.colMACS.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.colMACS.Caption = "Mã cơ sở";
            this.colMACS.FieldName = "MACS";
            this.colMACS.Name = "colMACS";
            this.colMACS.OptionsColumn.AllowEdit = false;
            this.colMACS.Visible = true;
            this.colMACS.VisibleIndex = 2;
            // 
            // FrmKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(983, 724);
            this.Controls.Add(this.gcKhoa);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FrmKhoa";
            this.Text = "Form Khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmKhoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKhoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKhoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar6;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnTaiLai;
        private DevExpress.XtraBars.BarButtonItem btnInDanhSachMH;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarButtonItem btnRedo;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private DS DS;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label tENMHLabel;
        private DevExpress.XtraEditors.TextEdit txtTenKhoa;
        private System.Windows.Forms.Label labelMaKhoa;
        private DevExpress.XtraEditors.TextEdit txtMaKhoa;
        private System.Windows.Forms.BindingSource bdsKhoa;
        private DSTableAdapters.KHOATableAdapter tbKhoaADT;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcKhoa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKH;
        private DevExpress.XtraGrid.Columns.GridColumn colTENKH;
        private DevExpress.XtraGrid.Columns.GridColumn colMACS;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtCoSo;
    }
}