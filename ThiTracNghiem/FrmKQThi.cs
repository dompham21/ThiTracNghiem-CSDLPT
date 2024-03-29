﻿using System;
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
    public partial class FrmKQThi : Form
    {
        public static int socau;
        public static int soCauDung;
        public static double diem;
        public static string maMH = "";
        public static string trinhDo = "";
        public static int lan;
        public static string ngayThi = "";
        public static int thoiGian;
        public static string maLop = "";
        public static string tenLop = "";

        public FrmKQThi()
        {
            InitializeComponent();
        }

        private void FrmKQThi_Load(object sender, EventArgs e)
        {
            MaGVSV.Text = "Mã số: " + Program.username; ;
            HoTen.Text = "Họ tên: " + Program.mHoten;
            Nhom.Text = "Nhóm: " + Program.mGroup;
            labelSoCau.Text = socau.ToString();
            labelSoCauDung.Text = soCauDung.ToString();
            labelDiem.Text = diem.ToString() + " điểm";

            txtSoCauHoi.Text = socau.ToString();
            txtMaMon.Text = maMH;
            txtTrinhDo.Text = trinhDo;
            txtLan.Text = lan.ToString();
            dateNgayThi.Text = ngayThi;
            txtThoiGian.Text = thoiGian.ToString();
            if(Program.mGroup == "SINHVIEN")
            {
                gbInfoSV.Visible = true;
                txtHoTen.Text = Program.mHoten;
                txtMaSV.Text = Program.username;
                txtMaLop.Text = maLop;
                txtTenLop.Text = tenLop;
            }
            else
            {
                gbInfoSV.Visible = false;
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
