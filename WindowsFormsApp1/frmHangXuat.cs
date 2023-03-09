using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public partial class frmHangXuat : Form
    {
        public frmHangXuat()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmHangXuat_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True";
            con.Open();
            LoadData();
        }
        private SqlConnection con;
        private void LoadData()
        {
            String sql = "Select * from Export";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            dgvHangXuat.DataSource = ds.Tables[0];
            dgvHangXuat.Refresh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Export (export_id, retailer_id, product_id, quantity, price, export_date) VALUES('" + txtMaXuatHang.Text + "',N'" + txtMaBanLe.Text + "','" + txtMaHang.Text + "', '" + txtSoLuong.Text + "','" + txtGiaHang.Text + "','" + dtpNgayXuat.Text + "')";
            string update = "UPDATE Product SET inventory_count = inventory_count - " + txtSoLuong.Text + " WHERE product_id = '" + txtMaHang.Text + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd1 = new SqlCommand(update, con);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Export WHERE export_id='" + txtMaXuatHang.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Export set  retailer_id = '" + txtMaBanLe.Text + "', product_id = '" + txtMaHang.Text + "', quantity = '" + txtSoLuong.Text + "', price = '" + txtGiaHang.Text + "', export_date = '" + dtpNgayXuat.Text + "' WHERE export_id = '" + txtMaXuatHang.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaXuatHang.Clear();
            txtMaBanLe.Clear();
            txtMaHang.Clear();
            txtGiaHang.Clear();
            txtSoLuong.Clear();
            txtMaXuatHang.ReadOnly = false;
        }

        private void dgvHangXuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                txtMaXuatHang.ReadOnly = true;
                int i;
                i = dgvHangXuat.CurrentRow.Index;
                txtMaXuatHang.Text = dgvHangXuat.Rows[i].Cells[0].Value.ToString();
                txtMaBanLe.Text = dgvHangXuat.Rows[i].Cells[1].Value.ToString();
                txtMaHang.Text = dgvHangXuat.Rows[i].Cells[2].Value.ToString();
                txtSoLuong.Text = dgvHangXuat.Rows[i].Cells[4].Value.ToString();
                txtGiaHang.Text = dgvHangXuat.Rows[i].Cells[5].Value.ToString();


                dtpNgayXuat.Value = (DateTime)dgvHangXuat.Rows[i].Cells[3].Value;
                

            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double thanhtien, soluong, dongia;
            if (txtSoLuong.Text == "")
                soluong = 0;
            else
                soluong = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiaHang.Text == "")
                dongia = 0;
            else
                dongia = Convert.ToDouble(txtGiaHang.Text);
            thanhtien = soluong * dongia;
            textBox1.Text = thanhtien.ToString();
        }
    }
}
