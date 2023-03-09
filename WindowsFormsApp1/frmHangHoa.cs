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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WindowsFormsApp1
{
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();
        }
        private SqlConnection con;
        private void LoadData()
        {
            String sql = "Select * from Product";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            dgvHangHoa.DataSource = ds.Tables[0];
            dgvHangHoa.Refresh();
        }
        private void cboMDM_Click_1(object sender, EventArgs e)
        {
            String sql = "Select * from Catalog";
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(dt);
            cboMDM.DataSource = dt;
            cboMDM.DisplayMember = "catalog_id";
            cboMDM.ValueMember = "catalog_id";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Product(product_id, catalog_id, name, price, inventory_count) VALUES('" + txtMaHang.Text + "','"+cboMDM.Text+"', N'" + txtTenHang.Text + "','"+txtGiaHang.Text+"','" + txtSoLuong.Text+"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHang.ReadOnly = true;
            int i;
            i = dgvHangHoa.CurrentRow.Index;
            txtMaHang.Text =dgvHangHoa.Rows[i].Cells[0].Value.ToString();
            cboMDM.Text =dgvHangHoa.Rows[i].Cells[1].Value.ToString();
            txtTenHang.Text =dgvHangHoa.Rows[i].Cells[2].Value.ToString();
            txtGiaHang.Text = dgvHangHoa.Rows[i].Cells[3].Value.ToString();
            txtSoLuong.Text =dgvHangHoa.Rows[i].Cells[4].Value.ToString();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True";
            con.Open();
            LoadData();

            dgvHangHoa.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHangHoa.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Product set catalog_id ='" +cboMDM.Text + "', name = N'" + txtTenHang.Text +"', inventory_count = '" + txtSoLuong.Text + "', price = N'" +txtGiaHang.Text + "' WHERE product_id = '"+txtMaHang.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Product WHERE product_id='" +txtMaHang.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtSoLuong.Clear();
            txtGiaHang.Clear();
            txtMaHang.ReadOnly = false;
        }

        private void cboDM_Click(object sender, EventArgs e)
        {
            String sql = "Select * from Catalog";
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(dt);
            cboDM.DataSource = dt;
            cboDM.DisplayMember = "name";
            cboDM.ValueMember = "catalog_id";
        }

        private void cboDM_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql = "Select * from Product Where catalog_id ='"+cboDM.SelectedValue+"'";
            DataTable dt1 = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(dt1);
            dgvHangHoa.DataSource = dt1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = "Select * from Product where name like N'%" + txtTimKiem.Text + "%'" ;
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(dt);
            dgvHangHoa.DataSource = dt;
        }
    }
}
