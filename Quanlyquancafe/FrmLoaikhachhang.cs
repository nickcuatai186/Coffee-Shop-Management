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
    public partial class FrmLoaikhachhang : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmLoaikhachhang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLoaikhachhang_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from LoaiKhachHang";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvLoaikhachhang.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvLoaikhachhang.CurrentCell.RowIndex;
                string malkh = dgvLoaikhachhang.Rows[vitri].Cells[0].Value.ToString();
                string tenlkh = dgvLoaikhachhang.Rows[vitri].Cells[1].Value.ToString();
                string giamgia = dgvLoaikhachhang.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("insert into LoaiKhachHang values('" + malkh + "',N'" + tenlkh + "','" + giamgia + "')");
                MessageBox.Show("Thêm loại khách hàng " + tenlkh + " thành công!", "Thông Báo",
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
                int vitri = dgvLoaikhachhang.CurrentCell.RowIndex;
                string malkh = dgvLoaikhachhang.Rows[vitri].Cells[0].Value.ToString();
                string tenlkh = dgvLoaikhachhang.Rows[vitri].Cells[1].Value.ToString();
                data.ExecuteNonQuery("delete from LoaiKhachHang where MaLKH ='" + malkh + "'");
                MessageBox.Show("Xóa loại khách hàng " + tenlkh + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa loại khách hàng thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvLoaikhachhang.CurrentCell.RowIndex;
                string malkh = dgvLoaikhachhang.Rows[vitri].Cells[0].Value.ToString();
                string tenlkh = dgvLoaikhachhang.Rows[vitri].Cells[1].Value.ToString();
                string giamgia = dgvLoaikhachhang.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("update LoaiKhachHang set MaLKH= '" + malkh + "',TenLKH= N'"
                    + tenlkh + "',GiamGia= '" + giamgia + "' where MaLKH= '" + malkh + "'");
                MessageBox.Show("Sửa thông tin loại khách hàng " + tenlkh + " thành công!", "Thông Báo",
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
            string str = "select * from LoaiKhachHang where TenLKH like N'%" + txtTenLKH.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvLoaikhachhang.DataSource = dt;
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
