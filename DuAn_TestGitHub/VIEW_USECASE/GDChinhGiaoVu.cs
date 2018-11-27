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
    public partial class GDChinhGiaoVu : Form
    {
        public GDChinhGiaoVu()
        {
            InitializeComponent();
            tabControlChuyenDe.Visible = true;
            panelCapNhatGVPhuTrach.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            groupBoxCapNhatGiaoVienPhuTrachChuyenDe.Visible = false;
            panelThemChuyenDe.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
        }

        //private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (tabControl.SelectedTab == tabControl.TabPages["tabPage1"])
        //    {
        //        dataGridViewTraCuu.Visible = true;
        //    }
        //}
        
        private void button15_Click(object sender, EventArgs e)
        {
            panelThemChuyenDe.Visible = false;
            tabControlChuyenDe.Visible = true;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
        }
        

        private void button16_Click(object sender, EventArgs e)
        {
            panelThemChuyenDe.Visible = false;
            tabControlChuyenDe.Visible = true;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            panelThemChuyenDe.Visible = false;
            tabControlChuyenDe.Visible = true;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panelThemChuyenDe.Visible = false;
            tabControlChuyenDe.Visible = true;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            panelThemChuyenDe.Visible = false;
            tabControlChuyenDe.Visible = true;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
        }
        private void btSuaChuyenDeMo_Click_1(object sender, EventArgs e)
        {
            panelThemChuyenDe.Visible = false;
            tabControlChuyenDe.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = true;
            groupBoxSuaChuyenDeMo.Visible = true;
            panelCapNhatGVPhuTrach.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
        }

        

        private void buttonThemChuyenDe_Click(object sender, EventArgs e)
        {
            panelThemChuyenDe.Visible = true;
            groupBoxThemChuyenDe.Visible = true;
            tabControlChuyenDe.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
        }

        private void buttonSuaChuyenDe_Click(object sender, EventArgs e)
        {
            panelSuaChuyenDe.Visible = true;
            groupBoxSuaChuyenDe.Visible = true;
            tabControlChuyenDe.Visible = false;
            panelThemChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;

        }

        private void buttonMoChuyenDe_Click(object sender, EventArgs e)
        {
            panelThemChuyenDe.Visible = false;
            tabControlChuyenDe.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = true;
            groupBoxMoChuyenDe.Visible = true;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelQT.Visible = false;
        }
        
        private void buttonLuuChinhSuaChuyenDeMo_Click(object sender, EventArgs e)
        {

        }

        private void buttonLuuMoChuyenDe_Click(object sender, EventArgs e)
        {

        }

        private void btLuuThayDoiSuaChuyenDe_Click(object sender, EventArgs e)
        {

        }

        private void buttonCapNhatGVPhuTrach_Click_1(object sender, EventArgs e)
        {
            panelThemChuyenDe.Visible = false;
            tabControlChuyenDe.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelCapNhatGVPhuTrach.Visible = true;
            groupBoxCapNhatGiaoVienPhuTrachChuyenDe.Visible = true;
        }

        private void buttonDiem_Click(object sender, EventArgs e)
        {
            dataGridViewTraCuu.Visible = true;
            groupBoxTraCuuTTDK.Visible = false;
            groupBoxTraCuuDiem.Visible = true;
            panelQT.Visible = false;
            tabControlChuyenDe.Visible = false;
            panelThemChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
            
        }

        private void buttonTTDK_Click(object sender, EventArgs e)
        {
            dataGridViewTraCuu.Visible = true;
            groupBoxTraCuuDiem.Visible = false;
            groupBoxTraCuuTTDK.Visible = true;
            panelQT.Visible = false;
            tabControlChuyenDe.Visible = false;
            panelThemChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
        }

        private void buttonTraCuuTTDK_Click(object sender, EventArgs e)
        {

        }

        private void buttonTraCuuDiem_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            button_QT_ChinhSua.Enabled = false;
            button_QT_LuuChinhSua.Enabled = true;
            tb_QT_TenTK.ReadOnly = false;
            tb_QT_TenChuTK.ReadOnly = false;
            tb_QT_NgayBDCongTac.ReadOnly = false;
            tb_QT_ChucVu.ReadOnly = false;
            tb_QT_Email.ReadOnly = false;
            panelQT.Visible = true;
            tabControlChuyenDe.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelThemChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
        }

        private void button_QT_LuuChinhSua_Click(object sender, EventArgs e)
        {
            button_QT_ChinhSua.Enabled = true;
            button_QT_LuuChinhSua.Enabled = false;
            tb_QT_TenTK.ReadOnly = true;
            tb_QT_TenChuTK.ReadOnly = true;
            tb_QT_NgayBDCongTac.ReadOnly = true;
            tb_QT_ChucVu.ReadOnly = true;
            tb_QT_Email.ReadOnly = true;
            panelSuaChuyenDeMo.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;
        }

        private void button_QT_DoiMatKhau_Click(object sender, EventArgs e)
        {
            panelQT.Visible = true;
            tabControlChuyenDe.Visible = false;
            dataGridViewTraCuu.Visible = false;
            panelThemChuyenDe.Visible = false;
            panelSuaChuyenDeMo.Visible = false;
            panelSuaChuyenDe.Visible = false;
            panelMoChuyenDe.Visible = false;
            panelCapNhatGVPhuTrach.Visible = false;

            button_QT_DoiMatKhau.Enabled = false;
            labelMKC.Visible = true;
            labelMKM.Visible = true;
            labelXNMKM.Visible = true;
            labelNOTE1.Visible = true;
            labelNOTE2.Visible = true;
            labelNOTE3.Visible = true;
            tb_QT_MKC.Visible = true;
            tb_QT_MKM.Visible = true;
            tb_QT_XNMKM.Visible = true;
            buttonDoiMatKhau.Visible = true;
        }

        private void buttonDoiMatKhau_Click(object sender, EventArgs e)
        {
            button_QT_DoiMatKhau.Enabled = true;
            labelMKC.Visible = false;
            labelMKM.Visible = false;
            labelXNMKM.Visible = false;
            labelNOTE1.Visible = false;
            labelNOTE2.Visible = false;
            labelNOTE3.Visible = false;
            tb_QT_MKC.Visible = false;
            tb_QT_MKM.Visible = false;
            tb_QT_XNMKM.Visible = false;
            buttonDoiMatKhau.Visible = false;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            //button_QT_LuuChinhSua_Click(sender, e);
        }

        
        private void labelNOTE2_Click(object sender, EventArgs e)
        {

        }

        private void labelNOTE3_Click(object sender, EventArgs e)
        {

        }

        private void tb_QT_XNMKM_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelXNMKM_Click(object sender, EventArgs e)
        {

        }

        private void tb_QT_MKM_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelMKM_Click(object sender, EventArgs e)
        {

        }

        private void labelNOTE1_Click(object sender, EventArgs e)
        {

        }

        private void labelMKC_Click(object sender, EventArgs e)
        {

        }

        private void tb_QT_TenTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
