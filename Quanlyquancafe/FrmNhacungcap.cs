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
    public partial class FrmNhacungcap : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmNhacungcap()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvNhacungcap.CurrentCell.RowIndex;
                string mancc = dgvNhacungcap.Rows[vitri].Cells[0].Value.ToString();
                string tenncc = dgvNhacungcap.Rows[vitri].Cells[1].Value.ToString();
                string diachi = dgvNhacungcap.Rows[vitri].Cells[2].Value.ToString();
                string sdt = dgvNhacungcap.Rows[vitri].Cells[3].Value.ToString();
                data.ExecuteNonQuery("update NhaCungCap set MaNCC= '" + mancc + "',TenNCC= N'"
                    + tenncc + "',DiaChi= N'" + diachi + "',SDT= '" + sdt + "' where MaNCC= '" + mancc + "'");
                MessageBox.Show("Sửa thông tin nhà cung cấp " + tenncc + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNhacungcap_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from NhaCungCap";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvNhacungcap.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvNhacungcap.CurrentCell.RowIndex;
                string mancc = dgvNhacungcap.Rows[vitri].Cells[0].Value.ToString();
                string tenncc = dgvNhacungcap.Rows[vitri].Cells[1].Value.ToString();
                string diachi = dgvNhacungcap.Rows[vitri].Cells[2].Value.ToString();
                string sdt = dgvNhacungcap.Rows[vitri].Cells[3].Value.ToString();
                data.ExecuteNonQuery("insert into NhaCungCap values('" + mancc + "',N'" + tenncc + "',N'" + diachi + "','" + sdt + "')");
                MessageBox.Show("Thêm nhà cung cấp " + tenncc + " thành công!", "Thông Báo",
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
                int vitri = dgvNhacungcap.CurrentCell.RowIndex;
                string mancc = dgvNhacungcap.Rows[vitri].Cells[0].Value.ToString();
                string tenncc = dgvNhacungcap.Rows[vitri].Cells[1].Value.ToString();
                data.ExecuteNonQuery("delete from NhaCungCap where MaNCC ='" + mancc + "'");
                MessageBox.Show("Xóa nhà cung cấp " + tenncc + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa nhà cung cấp thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string str = "select * from NhaCungCap where TenNCC like N'%" + txtTenNCC.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhacungcap.DataSource = dt;
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
