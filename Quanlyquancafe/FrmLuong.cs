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
    public partial class FrmLuong : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmLuong()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvLuong.CurrentCell.RowIndex;
                string maclv = dgvLuong.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvLuong.Rows[vitri].Cells[1].Value.ToString();
                string tongcalam = dgvLuong.Rows[vitri].Cells[2].Value.ToString();
                string thanhtien = dgvLuong.Rows[vitri].Cells[3].Value.ToString();
                string kyluong = dgvLuong.Rows[vitri].Cells[4].Value.ToString();
                data.ExecuteNonQuery("insert into ChiTietLuongNhanVien values('" + maclv + "','" + manv + "','" + tongcalam + "','" + thanhtien + "'" +
                    ",'" + kyluong + "')");
                MessageBox.Show("Thêm thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmLuong_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from ChiTietLuongNhanVien";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvLuong.DataSource = bdsource;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvLuong.CurrentCell.RowIndex;
                string maclv = dgvLuong.Rows[vitri].Cells[0].Value.ToString();
                data.ExecuteNonQuery("delete from ChiTietLuongNhanVien where MaCLV ='" + maclv + "'");
                MessageBox.Show("Xóa thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvLuong.CurrentCell.RowIndex;
                string maclv = dgvLuong.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvLuong.Rows[vitri].Cells[1].Value.ToString();
                string tongcalam = dgvLuong.Rows[vitri].Cells[2].Value.ToString();
                string thanhtien = dgvLuong.Rows[vitri].Cells[3].Value.ToString();
                string kyluong = dgvLuong.Rows[vitri].Cells[4].Value.ToString();
                data.ExecuteNonQuery("update ChiTietLuongNhanVien set MaCLV= '" + maclv + "',MaNV= '"
                    + manv + "',TongSoCaLam= '" + tongcalam + "',ThanhTien= '" + thanhtien + "',KyLuong= '" + kyluong + "'" +
                    "where MaCLV= '" + maclv + "'");
                MessageBox.Show("Sửa thông tin thành công!", "Thông Báo",
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
            string str = "select * from ChiTietLuongNhanVien where MaNV like N'%" + txtMaNV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvLuong.DataSource = dt;
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
