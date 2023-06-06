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
    public partial class FrmCalamviec : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmCalamviec()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCalamviec_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string str = "select * from CaLamViec";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvCalamviec.DataSource = bdsource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvCalamviec.CurrentCell.RowIndex;
                string maclv = dgvCalamviec.Rows[vitri].Cells[0].Value.ToString();
                string tenclv = dgvCalamviec.Rows[vitri].Cells[1].Value.ToString();
                string giobd = dgvCalamviec.Rows[vitri].Cells[2].Value.ToString();
                string giokt = dgvCalamviec.Rows[vitri].Cells[3].Value.ToString();
                string sotien = dgvCalamviec.Rows[vitri].Cells[4].Value.ToString();              
                data.ExecuteNonQuery("insert into CaLamViec values('" + maclv + "',N'" + tenclv + "','" + giobd + "','" + giokt + "'" +
                    ",'" + sotien + "')");
                MessageBox.Show("Thêm ca làm việc " + tenclv + " thành công!", "Thông Báo",
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
                int vitri = dgvCalamviec.CurrentCell.RowIndex;
                string maclv = dgvCalamviec.Rows[vitri].Cells[0].Value.ToString();
                string tenclv = dgvCalamviec.Rows[vitri].Cells[1].Value.ToString();
                data.ExecuteNonQuery("delete from CaLamViec where MaCLV ='" + maclv + "'");
                MessageBox.Show("Xóa ca làm việc " + tenclv + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa ca làm việc thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvCalamviec.CurrentCell.RowIndex;
                string maclv = dgvCalamviec.Rows[vitri].Cells[0].Value.ToString();
                string tenclv = dgvCalamviec.Rows[vitri].Cells[1].Value.ToString();
                string giobd = dgvCalamviec.Rows[vitri].Cells[2].Value.ToString();
                string giokt = dgvCalamviec.Rows[vitri].Cells[3].Value.ToString();
                string sotien = dgvCalamviec.Rows[vitri].Cells[4].Value.ToString();
                data.ExecuteNonQuery("update CaLamViec set MaCLV= '" + maclv + "',TenCLV= N'"
                    + tenclv + "',GioBD= '" + giobd + "',GioKT= '" + giokt + "',SoTien= '" + sotien + "' where MaCLV= '"
                    + maclv + "'");
                MessageBox.Show("Sửa thông tin ca làm việc " + tenclv + " thành công!", "Thông Báo",
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
            string str = "select * from CaLamViec where TenCLV like N'%" + txtTenCLV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCalamviec.DataSource = dt;
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
