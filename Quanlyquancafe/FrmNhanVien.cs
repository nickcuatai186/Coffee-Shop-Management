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
    public partial class FrmNhanVien : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from NhanVien";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvNhanvien.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvNhanvien.CurrentCell.RowIndex;
                string manv = dgvNhanvien.Rows[vitri].Cells[0].Value.ToString();
                string tennhanvien = dgvNhanvien.Rows[vitri].Cells[1].Value.ToString();
                string diachi = dgvNhanvien.Rows[vitri].Cells[2].Value.ToString();
                string sdt = dgvNhanvien.Rows[vitri].Cells[3].Value.ToString();
                string chucvu = dgvNhanvien.Rows[vitri].Cells[4].Value.ToString();
                string ngayvaolam = dgvNhanvien.Rows[vitri].Cells[5].Value.ToString();
                string gioitinh = dgvNhanvien.Rows[vitri].Cells[6].Value.ToString();
                string phanquyen = dgvNhanvien.Rows[vitri].Cells[7].Value.ToString();
                string matkhau = dgvNhanvien.Rows[vitri].Cells[8].Value.ToString();
                data.ExecuteNonQuery("insert into NhanVien values('" + manv + "',N'" + tennhanvien + "',N'" + diachi + "','" + sdt + "'" +
                    ",N'" + chucvu + "','" + ngayvaolam + "','" + gioitinh + "','" + phanquyen + "','" + matkhau + "')");
                MessageBox.Show("Thêm nhân viên " + tennhanvien + " thành công!", "Thông Báo",
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
                int vitri = dgvNhanvien.CurrentCell.RowIndex;
                string manv = dgvNhanvien.Rows[vitri].Cells[0].Value.ToString();
                string tennhanvien = dgvNhanvien.Rows[vitri].Cells[1].Value.ToString();
                data.ExecuteNonQuery("delete from NhanVien where MaNV ='" + manv + "'");
                MessageBox.Show("Xóa nhân viên " + tennhanvien + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa nhân viên thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvNhanvien.CurrentCell.RowIndex;
                string manv = dgvNhanvien.Rows[vitri].Cells[0].Value.ToString();
                string tennhanvien = dgvNhanvien.Rows[vitri].Cells[1].Value.ToString();
                string diachi = dgvNhanvien.Rows[vitri].Cells[2].Value.ToString();
                string sdt = dgvNhanvien.Rows[vitri].Cells[3].Value.ToString();
                string chucvu = dgvNhanvien.Rows[vitri].Cells[4].Value.ToString();
                string ngayvaolam = dgvNhanvien.Rows[vitri].Cells[5].Value.ToString();
                string gioitinh = dgvNhanvien.Rows[vitri].Cells[6].Value.ToString();
                string phanquyen = dgvNhanvien.Rows[vitri].Cells[7].Value.ToString();
                string matkhau = dgvNhanvien.Rows[vitri].Cells[8].Value.ToString();
                data.ExecuteNonQuery("update NhanVien set MaNV= '" + manv + "',TenNV= N'"
                    + tennhanvien + "',DiaChi= N'" + diachi + "',SDT= '" + sdt + "',ChucVu= N'" + chucvu +
                    "',NgayVaoLam= '" + ngayvaolam + "',GioiTinh= '" + gioitinh + "',PhanQuyen= '" + phanquyen +
                    "',MatKhau= '" + matkhau + "'where MaNV= '" + manv + "'");
                MessageBox.Show("Sửa thông tin nhân viên " + tennhanvien + " thành công!", "Thông Báo",
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
            string str = "select * from NhanVien where TenNV like N'%" + textBox1.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhanvien.DataSource = dt;
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
