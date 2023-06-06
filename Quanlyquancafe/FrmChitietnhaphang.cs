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
    public partial class FrmChitietnhaphang : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmChitietnhaphang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChitietnhaphang_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from ChiTietNhapHang";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvChitietnhaphang.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvChitietnhaphang.CurrentCell.RowIndex;
                string mahh = dgvChitietnhaphang.Rows[vitri].Cells[0].Value.ToString();
                string manh = dgvChitietnhaphang.Rows[vitri].Cells[1].Value.ToString();
                string soluong = dgvChitietnhaphang.Rows[vitri].Cells[2].Value.ToString();
                string thanhtien = dgvChitietnhaphang.Rows[vitri].Cells[3].Value.ToString();
                data.ExecuteNonQuery("insert into ChiTietNhapHang values('" + mahh + "','" + manh + "','" + soluong + "','" + thanhtien + "')");
                MessageBox.Show("Thêm chi tiết hóa đơn nhập hàng thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvChitietnhaphang.CurrentCell.RowIndex;
                string manh = dgvChitietnhaphang.Rows[vitri].Cells[1].Value.ToString();
                data.ExecuteNonQuery("delete from ChiTietNhapHang where MaHDNH ='" + manh + "'");
                MessageBox.Show("Xóa chi tiết hóa đơn nhập hàng thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa chi tiết hóa đơn nhập hàng thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvChitietnhaphang.CurrentCell.RowIndex;
                string mahh = dgvChitietnhaphang.Rows[vitri].Cells[0].Value.ToString();
                string manh = dgvChitietnhaphang.Rows[vitri].Cells[1].Value.ToString();
                string soluong = dgvChitietnhaphang.Rows[vitri].Cells[2].Value.ToString();
                string thanhtien = dgvChitietnhaphang.Rows[vitri].Cells[3].Value.ToString();
                data.ExecuteNonQuery("update ChiTietNhapHang set MaHH= '" + mahh + "',MaHDNH= '"
                    + manh + "',SoLuong= '" + soluong + "',ThanhTien= '" + thanhtien + "' where MaHDNH= '" + manh + "'");
                MessageBox.Show("Sửa thông tin chi tiết hóa đơn nhập hàng thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string str = "select * from ChiTietNhapHang where MaHDNH like N'%" + txtMaHD.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvChitietnhaphang.DataSource = dt;
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bdsource.Position = 0;
            btnTruoc.Enabled = false;
            btnDau.Enabled = false;
            btnSau.Enabled = true;
            btnCuoi.Enabled = true;
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bdsource.Position -= 1;
            if (bdsource.Position == 0)
            {
                btnTruoc.Enabled = false;
                btnDau.Enabled = false;
            }
            btnSau.Enabled = true;
            btnCuoi.Enabled = true;
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            bdsource.Position += 1;
            if (bdsource.Position == bdsource.Count - 1)
            {
                btnSau.Enabled = false;
                btnCuoi.Enabled = false;
            }
            btnTruoc.Enabled = true;
            btnDau.Enabled = true;
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bdsource.Position = bdsource.Count - 1;
            btnSau.Enabled = false;
            btnCuoi.Enabled = false;
            btnTruoc.Enabled = true;
            btnDau.Enabled = true;
        }
    }
}
