using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIEW_USECASE
{
    public partial class FrmLOGIN : Form
    {
        public FrmLOGIN()
        {
            InitializeComponent();
        }

       

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            GDChinhGiaoVien a = new GDChinhGiaoVien();
            a.ShowDialog();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
