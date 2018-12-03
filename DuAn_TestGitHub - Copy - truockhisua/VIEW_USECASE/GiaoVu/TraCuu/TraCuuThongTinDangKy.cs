using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIEW_USECASE.GiaoVu.TraCuu
{
    public partial class TraCuuThongTinDangKy : Form
    {
        public TraCuuThongTinDangKy()
        {
            InitializeComponent();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã click Tra Cứu TTDK");
        }
    }
}
