using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ThiTracNghiem
{
    public partial class RptXemBangDiem : DevExpress.XtraReports.UI.XtraReport
    {
        public RptXemBangDiem()
        {
            InitializeComponent();
        }

        public RptXemBangDiem(string maLop, string maMH, int lan)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maLop;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = maMH;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = lan;
            this.sqlDataSource1.Fill();
        }
    }
}
