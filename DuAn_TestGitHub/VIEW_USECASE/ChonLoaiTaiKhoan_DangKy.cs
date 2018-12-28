using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIEW_USECASE
{
    public partial class ChonLoaiTaiKhoan_DangKy : Form
    {
        public ChonLoaiTaiKhoan_DangKy()
        {
            InitializeComponent();
        }

        private void btnCanCel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGVGV_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(openFormDangKyGVGV);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
            return;
        }
        private void openFormDangKyGVGV(object sender)
        {
            Application.Run(new DangKyGVGV());
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(openFormDangKySV);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
            return;
        }
        private void openFormDangKySV(object sender)
        {
            Application.Run(new DangKySV());
        }
    }
}
