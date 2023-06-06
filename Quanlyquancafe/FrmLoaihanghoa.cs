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
    public partial class FrmLoaihanghoa : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmLoaihanghoa()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLoaihanghoa_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from LoaiHangHoa";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvLoaihanghoa.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvLoaihanghoa.CurrentCell.RowIndex;
                string malhh = dgvLoaihanghoa.Rows[vitri].Cells[0].Value.ToString();
                string tenlhh = dgvLoaihanghoa.Rows[vitri].Cells[1].Value.ToString();
                string mota = dgvLoaihanghoa.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("insert into LoaiHangHoa values('" + malhh + "',N'" + tenlhh + "',N'" + mota + "')");
                MessageBox.Show("Thêm loại hàng hóa " + tenlhh + " thành công!", "Thông Báo",
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
                int vitri = dgvLoaihanghoa.CurrentCell.RowIndex;
                string malhh = dgvLoaihanghoa.Rows[vitri].Cells[0].Value.ToString();
                string tenlhh = dgvLoaihanghoa.Rows[vitri].Cells[1].Value.ToString();
                data.ExecuteNonQuery("delete from LoaiHangHoa where MaLHH ='" + malhh + "'");
                MessageBox.Show("Xóa loại hàng hóa " + tenlhh + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa loại hàng hóa thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvLoaihanghoa.CurrentCell.RowIndex;
                string malhh = dgvLoaihanghoa.Rows[vitri].Cells[0].Value.ToString();
                string tenlhh = dgvLoaihanghoa.Rows[vitri].Cells[1].Value.ToString();
                string mota = dgvLoaihanghoa.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("update LoaiHangHoa set MaLHH= '" + malhh + "',TenLHH= N'"
                    + tenlhh + "',MoTa= N'" + mota + "' where MaLHH= '" + malhh + "'");
                MessageBox.Show("Sửa thông tin loại hàng hóa " + tenlhh + " thành công!", "Thông Báo",
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
            string str = "select * from LoaiHangHoa where TenLHH like N'%" + txtTenLHH.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvLoaihanghoa.DataSource = dt;
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
