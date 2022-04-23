using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class FrmChuanBiThiThu : Form
    {
        public FrmChuanBiThiThu()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FrmChuanBiThiThu_Load(object sender, EventArgs e)
        {
          
            DS.EnforceConstraints = false;

            this.tbGVDKyADT.Connection.ConnectionString = Program.connstr;
            this.tbGVDKyADT.Fill(this.DS.GIAOVIEN_DANGKY);

            bdsGVDK.Filter = string.Format("NGAYTHI >= #{0}#", DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            bdsGVDK.Sort = "NGAYTHI ASC";

        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;

            }

        }

       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn thoát?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThi_Click(object sender, EventArgs e)
        {
            if(bdsGVDK.Count > 0 )
            {
                FrmThi.maMH = ((DataRowView)this.bdsGVDK.Current).Row["MAMH"].ToString().Trim();
                FrmThi.trinhDo = ((DataRowView)this.bdsGVDK.Current).Row["TRINHDO"].ToString().Trim();
                FrmThi.lan = Int32.Parse(((DataRowView)this.bdsGVDK.Current).Row["LAN"].ToString().Trim());
                FrmThi.maLop = ((DataRowView)this.bdsGVDK.Current).Row["MALOP"].ToString().Trim();
                FrmThi.ngaythi = Convert.ToDateTime(((DataRowView)this.bdsGVDK.Current).Row["NGAYTHI"]);
                FrmThi.thoiGian = Int32.Parse(((DataRowView)this.bdsGVDK.Current).Row["THOIGIAN"].ToString().Trim());
                FrmThi.soCau = Int32.Parse(((DataRowView)this.bdsGVDK.Current).Row["SOCAUTHI"].ToString().Trim());
                this.Close();
                Program.frmThi = new FrmThi();
                Program.frmThi.Activate();
                Program.frmThi.Show();
                this.Visible = false;
            }
            else
            {
                XtraMessageBox.Show("Chưa có lịch giáo viên đăng ký nào để thi thử!", "", MessageBoxButtons.OK);
            } 
            
        }
    }
}
