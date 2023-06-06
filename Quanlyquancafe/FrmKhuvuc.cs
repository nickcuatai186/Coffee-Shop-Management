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
    public partial class FrmKhuvuc : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmKhuvuc()
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
                int vitri = dgvKhuvuc.CurrentCell.RowIndex;
                string makv = dgvKhuvuc.Rows[vitri].Cells[0].Value.ToString();
                string tenkv = dgvKhuvuc.Rows[vitri].Cells[1].Value.ToString();
                string trangthai = dgvKhuvuc.Rows[vitri].Cells[2].Value.ToString();   
                data.ExecuteNonQuery("insert into KhuVuc values('" + makv + "',N'" + tenkv + "',N'" + trangthai + "')");
                MessageBox.Show("Thêm khu vực " + tenkv + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmKhuvuc_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from KhuVuc";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvKhuvuc.DataSource = bdsource;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKhuvuc.CurrentCell.RowIndex;
                string makv = dgvKhuvuc.Rows[vitri].Cells[0].Value.ToString();
                string tenkv = dgvKhuvuc.Rows[vitri].Cells[1].Value.ToString();
                data.ExecuteNonQuery("delete from KhuVuc where MaKV ='" + makv + "'");
                MessageBox.Show("Xóa khu vực " + tenkv + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa khu vực thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKhuvuc.CurrentCell.RowIndex;
                string makv = dgvKhuvuc.Rows[vitri].Cells[0].Value.ToString();
                string tenkv = dgvKhuvuc.Rows[vitri].Cells[1].Value.ToString();
                string trangthai = dgvKhuvuc.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("update KhuVuc set MaKV= '" + makv + "',TenKV= N'"
                    + tenkv + "',TrangThai= N'" + trangthai + "' where MaKV= '" + makv + "'");
                MessageBox.Show("Sửa thông tin khu vực " + tenkv + " thành công!", "Thông Báo",
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
            string str = "select * from KhuVuc where TenKV like N'%" + txtTenKV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKhuvuc.DataSource = dt;
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
