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
    public partial class FrmBan : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmBan()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBan_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from Ban";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvBan.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvBan.CurrentCell.RowIndex;
                string maban = dgvBan.Rows[vitri].Cells[0].Value.ToString();
                string makv = dgvBan.Rows[vitri].Cells[1].Value.ToString();
                string tenban = dgvBan.Rows[vitri].Cells[2].Value.ToString();
                string thuoctinh = dgvBan.Rows[vitri].Cells[3].Value.ToString();
                string insert = "insert into Ban(MaBan, MaKV, TenBan, ThuocTinh) values('" + maban + "','" + makv + "',N'" + tenban + "',N'" + thuoctinh + "')";
                data.ExecuteNonQuery(insert);
                MessageBox.Show("Thêm bàn " + tenban + " thành công!", "Thông Báo",
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
                int vitri = dgvBan.CurrentCell.RowIndex;
                string maban = dgvBan.Rows[vitri].Cells[0].Value.ToString();
                string tenban = dgvBan.Rows[vitri].Cells[2].Value.ToString();
                string delete = "delete from Ban where MaBan ='" + maban + "'";
                data.ExecuteNonQuery(delete);
                MessageBox.Show("Xóa bàn " + tenban + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa bàn thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvBan.CurrentCell.RowIndex;
                string maban = dgvBan.Rows[vitri].Cells[0].Value.ToString();
                string makv = dgvBan.Rows[vitri].Cells[1].Value.ToString();
                string tenban = dgvBan.Rows[vitri].Cells[2].Value.ToString();
                string thuoctinh = dgvBan.Rows[vitri].Cells[3].Value.ToString();
                string update = "update Ban set MaBan= '" + maban + "',MaKV= '"
                    + makv + "',TenBan= N'" + tenban + "',ThuocTinh= '" + thuoctinh + "' where MaBan= '" + maban + "'";
                data.ExecuteNonQuery(update);
                MessageBox.Show("Sửa thông tin bàn " + tenban + " thành công!", "Thông Báo",
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
            string str = "select * from Ban where TenBan like N'%" + txtTenBan.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBan.DataSource = dt;
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
