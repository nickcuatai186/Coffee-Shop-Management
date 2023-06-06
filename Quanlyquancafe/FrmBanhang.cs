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
    public partial class FrmBanhang : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmBanhang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBanhang_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from HoaDonBanHang";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvBanhang.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvBanhang.CurrentCell.RowIndex;
                string mabh = dgvBanhang.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvBanhang.Rows[vitri].Cells[1].Value.ToString();
                string maban = dgvBanhang.Rows[vitri].Cells[2].Value.ToString();
                string makh = dgvBanhang.Rows[vitri].Cells[3].Value.ToString();
                string ngaybh = dgvBanhang.Rows[vitri].Cells[4].Value.ToString();
                string tongtien = dgvBanhang.Rows[vitri].Cells[5].Value.ToString();
                string giamgia = dgvBanhang.Rows[vitri].Cells[6].Value.ToString();
                string diemtl = dgvBanhang.Rows[vitri].Cells[7].Value.ToString();
                string cpk = dgvBanhang.Rows[vitri].Cells[8].Value.ToString();
                data.ExecuteNonQuery("insert into HoaDonBanHang values('" + mabh + "','" + manv + "','" + maban + "','" + makh + "'" +
                    ",'" + ngaybh + "','" + tongtien + "','" + giamgia + "','" + diemtl + "','" + cpk + "')");
                MessageBox.Show("Thêm hóa đơn bán hàng thành công!", "Thông Báo",
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
                int vitri = dgvBanhang.CurrentCell.RowIndex;
                string mabh = dgvBanhang.Rows[vitri].Cells[0].Value.ToString();
                data.ExecuteNonQuery("delete from HoaDonBanHang where MaHDBH ='" + mabh + "'");
                MessageBox.Show("Xóa hóa đơn bán hàng thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa hóa đơn bán hàng thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvBanhang.CurrentCell.RowIndex;
                string mabh = dgvBanhang.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvBanhang.Rows[vitri].Cells[1].Value.ToString();
                string maban = dgvBanhang.Rows[vitri].Cells[2].Value.ToString();
                string makh = dgvBanhang.Rows[vitri].Cells[3].Value.ToString();
                string ngaybh = dgvBanhang.Rows[vitri].Cells[4].Value.ToString();
                string tongtien = dgvBanhang.Rows[vitri].Cells[5].Value.ToString();
                string giamgia = dgvBanhang.Rows[vitri].Cells[6].Value.ToString();
                string diemtl = dgvBanhang.Rows[vitri].Cells[7].Value.ToString();
                string cpk = dgvBanhang.Rows[vitri].Cells[8].Value.ToString();
                data.ExecuteNonQuery("update HoaDonBanHang set MaHDBH= '" + mabh + "',MaNV= '"
                    + manv + "',MaBan= '" + maban + "',MaKH= '" + makh + "',NgayHDBH= '" + ngaybh +
                    "',TongTien= '" + tongtien + "',GiamGia= '" + giamgia + "',DiemTL= '" + diemtl +
                    "',ChiPhiKhac= '" + cpk + "'where MaHDBH= '" + mabh + "'");
                MessageBox.Show("Sửa thông tin hóa đơn bán hàng thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select * from HoaDonBanHang where MaHDBH like N'%" + txtMaHD.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBanhang.DataSource = dt;
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
