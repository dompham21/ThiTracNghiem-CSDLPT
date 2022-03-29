using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FrmKhoa : Form
    {
        public FrmKhoa()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhoa.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FrmKhoa_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false; //Tat kiem tra ranh buoc (khoa ngoai)

            // TODO: This line of code loads data into the 'DS.KHOA' table. You can move, or remove it, as needed.
            this.tbKhoaADT.Connection.ConnectionString = Program.connstr;
            this.tbKhoaADT.Fill(this.DS.KHOA);

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LawnGreen;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
