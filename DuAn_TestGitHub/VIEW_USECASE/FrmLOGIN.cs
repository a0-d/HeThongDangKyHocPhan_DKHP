using MetroFramework.Forms;
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
    public partial class FrmLOGIN : MetroForm
    {
        public FrmLOGIN()
        {
            InitializeComponent();
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng nhập", "Thông báo");
        }
    }
}
