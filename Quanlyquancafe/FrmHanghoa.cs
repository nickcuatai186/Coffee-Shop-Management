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
    public partial class FrmHanghoa : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmHanghoa()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHanghoa_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from HangHoa";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvHanghoa.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvHanghoa.CurrentCell.RowIndex;
                string mahh = dgvHanghoa.Rows[vitri].Cells[0].Value.ToString();
                string malhh = dgvHanghoa.Rows[vitri].Cells[1].Value.ToString();
                string tenhh = dgvHanghoa.Rows[vitri].Cells[2].Value.ToString();
                string soluong = dgvHanghoa.Rows[vitri].Cells[3].Value.ToString();
                string giasp = dgvHanghoa.Rows[vitri].Cells[4].Value.ToString();
                string mancc = dgvHanghoa.Rows[vitri].Cells[5].Value.ToString();
                data.ExecuteNonQuery("insert into HangHoa values('" + mahh + "','" + malhh + "',N'" + tenhh + "','" + soluong + "'" +
                    ",'" + giasp + "','" + mancc + "')");
                MessageBox.Show("Thêm hàng hóa " + tenhh + " thành công!", "Thông Báo",
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
                int vitri = dgvHanghoa.CurrentCell.RowIndex;
                string mahh = dgvHanghoa.Rows[vitri].Cells[0].Value.ToString();
                string tenhh = dgvHanghoa.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("delete from HangHoa where MaHH ='" + mahh + "'");
                MessageBox.Show("Xóa hàng hóa " + tenhh + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa hàng hóa thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvHanghoa.CurrentCell.RowIndex;
                string mahh = dgvHanghoa.Rows[vitri].Cells[0].Value.ToString();
                string malhh = dgvHanghoa.Rows[vitri].Cells[1].Value.ToString();
                string tenhh = dgvHanghoa.Rows[vitri].Cells[2].Value.ToString();
                string soluong = dgvHanghoa.Rows[vitri].Cells[3].Value.ToString();
                string giasp = dgvHanghoa.Rows[vitri].Cells[4].Value.ToString();
                string mancc = dgvHanghoa.Rows[vitri].Cells[5].Value.ToString();
                data.ExecuteNonQuery("update HangHoa set MaHH= '" + mahh + "',MaLHH= '"
                    + malhh + "',TenHH= N'" + tenhh + "',SoLuong= '" + soluong + "',GiaSP= '" + giasp + 
                    "',MaNCC= '" + mancc + "' where MaHH= '" + mahh + "'");
                MessageBox.Show("Sửa thông tin hàng hóa " + tenhh + " thành công!", "Thông Báo",
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
            string str = "select * from HangHoa where TenHH like N'%" + txtTenHH.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHanghoa.DataSource = dt;
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
