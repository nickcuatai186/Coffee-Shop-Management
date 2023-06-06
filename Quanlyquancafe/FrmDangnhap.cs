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
    public partial class FrmDangnhap : Form
    {
        Ketnoi data = new Ketnoi();
        public FrmDangnhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string tk = txtTK.Text;
            string mk = txtMK.Text;
            if(string.IsNullOrEmpty(tk))
            {
                MessageBox.Show("Hãy nhập tài khoản!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTK.Focus();
                return;
            }
            if (string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Hãy nhập mật khẩu!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMK.Focus();
                return;
            }
            dt = data.ExcuteQuery("select * from NhanVien where MaNV = '" +tk+ "' and MatKhau = '" +mk+ "'");
            if (dt.Rows.Count>0)
            {
                FrmMain fr = new FrmMain(dt.Rows[0][7].ToString());
                this.Hide();
                fr.ShowDialog();          
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     
        private void rdbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbHienMK.Checked)
            {
                txtMK.PasswordChar = (char)0;
            }
            else
            {
                txtMK.PasswordChar = '*';
            }
        }
    }
}
