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
    public partial class FrmKhachhang : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmKhachhang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmKhachhang_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvKhachhang.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKhachhang.CurrentCell.RowIndex;
                string makh = dgvKhachhang.Rows[vitri].Cells[0].Value.ToString();
                string malkh = dgvKhachhang.Rows[vitri].Cells[1].Value.ToString();
                string tenkh = dgvKhachhang.Rows[vitri].Cells[2].Value.ToString();
                string diachi = dgvKhachhang.Rows[vitri].Cells[3].Value.ToString();
                string sdt = dgvKhachhang.Rows[vitri].Cells[4].Value.ToString();
                string diemtl = dgvKhachhang.Rows[vitri].Cells[5].Value.ToString();
                data.ExecuteNonQuery("insert into KhachHang values('" + makh + "','" + malkh + "',N'" + tenkh + "',N'" + diachi + "'" +
                    ",'" + sdt + "','" + diemtl + "')");
                MessageBox.Show("Thêm khách hàng " + tenkh + " thành công!", "Thông Báo",
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
                int vitri = dgvKhachhang.CurrentCell.RowIndex;
                string makh = dgvKhachhang.Rows[vitri].Cells[0].Value.ToString();
                string tenkh = dgvKhachhang.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("delete from KhachHang where MaKH ='" + makh + "'");
                MessageBox.Show("Xóa khách hàng " + tenkh + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa khách hàng thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKhachhang.CurrentCell.RowIndex;
                string makh = dgvKhachhang.Rows[vitri].Cells[0].Value.ToString();
                string malkh = dgvKhachhang.Rows[vitri].Cells[1].Value.ToString();
                string tenkh = dgvKhachhang.Rows[vitri].Cells[2].Value.ToString();
                string diachi = dgvKhachhang.Rows[vitri].Cells[3].Value.ToString();
                string sdt = dgvKhachhang.Rows[vitri].Cells[4].Value.ToString();
                string diemtl = dgvKhachhang.Rows[vitri].Cells[5].Value.ToString();
                data.ExecuteNonQuery("update KhachHang set MaKH= '" + makh + "',MaLKH= '"
                    + malkh + "',TenKH= N'" + tenkh + "',DiaChi= N'" + diachi + "',SDT= '" + sdt +
                    "',DiemTL= '" + diemtl + "' where MaKH= '" + makh + "'");
                MessageBox.Show("Sửa thông tin khách hàng " + tenkh + " thành công!", "Thông Báo",
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
            string str = "select * from KhachHang where TenKH like N'%" + txtTenKH.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKhachhang.DataSource = dt;
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
