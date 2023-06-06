using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quanlyquancafe
{
    public partial class FrmMain : Form
    {
        Ketnoi data = new Ketnoi();
        string quyen = "";
        public FrmMain(string quyen)
        {
            InitializeComponent();
            this.quyen = quyen;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (quyen=="True")
            {
                quanlyMenu.Enabled = true;
                khachhangMenu.Enabled = true;
                hoadonMenu.Enabled = true;
            }
            else
            {
                khachhangMenu.Enabled = true;
                hoadonMenu.Enabled = true;
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhanVien fr = new FrmNhanVien();
            fr.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmDangnhap fr = new FrmDangnhap();
            fr.Show();
        }

        private void caLàmViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCalamviec fr = new FrmCalamviec();
            fr.Show();
        }

        private void lươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLuong fr = new FrmLuong();
            fr.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHanghoa fr = new FrmHanghoa();
            fr.Show();
        }

        private void loạiHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoaihanghoa fr = new FrmLoaihanghoa();
            fr.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhacungcap fr = new FrmNhacungcap();
            fr.Show();
        }

        private void khuVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKhuvuc fr = new FrmKhuvuc();
            fr.Show();
        }

        private void bànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBan fr = new FrmBan();
            fr.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKhachhang fr = new FrmKhachhang();
            fr.Show();
        }

        private void loạiKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoaikhachhang fr = new FrmLoaikhachhang();
            fr.Show();
        }

        private void hóaĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhaphang fr = new FrmNhaphang();
            fr.Show();
        }

        private void chiTiếtHóaĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChitietnhaphang fr = new FrmChitietnhaphang();
            fr.Show();
        }

        private void hóaĐơnBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBanhang fr = new FrmBanhang();
            fr.Show();
        }

        private void chiTiếtHóaĐơnBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChitietbanhang fr = new FrmChitietbanhang();
            fr.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
