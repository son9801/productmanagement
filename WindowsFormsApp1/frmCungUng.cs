using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmCungUng : Form
    {
        public frmCungUng()
        {
            InitializeComponent();
        }
        private SqlConnection con;
        private void LoadData()
        {
            String sql = "Select * from Supplier";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            dgvCungUng.DataSource = ds.Tables[0];
            dgvCungUng.Refresh();
        }
        private void frmCungUng_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True";
            con.Open();
            LoadData();

            //dgvCungUng.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCungUng.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // dgvCungUng.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCungUng.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCungUng.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Supplier(supplier_id, name, email, phone_number, address) VALUES('" + txtMaCungUng.Text + "',N'" + txtTenCungUng.Text + "', '" + txtEmail.Text + "','" + txtSDT.Text + "',N'" + txtDiaChi.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Supplier set  name = N'" + txtTenCungUng.Text + "', email = '" + txtEmail.Text + "', phone_number = N'" + txtSDT.Text + "', address = N'" + txtDiaChi.Text + "' WHERE supplier_id = '" + txtMaCungUng.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void dgvCungUng_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCungUng.ReadOnly = true;
            int i;
            i = dgvCungUng.CurrentRow.Index;
            txtMaCungUng.Text = dgvCungUng.Rows[i].Cells[0].Value.ToString();
            txtTenCungUng.Text = dgvCungUng.Rows[i].Cells[1].Value.ToString();
            txtEmail.Text = dgvCungUng.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dgvCungUng.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvCungUng.Rows[i].Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Supplier WHERE supplier_id='" + txtMaCungUng.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaCungUng.Clear();
            txtTenCungUng.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaCungUng.ReadOnly = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = "Select * from Supplier WHERE name like N'%" + txtTimKiem.Text + "%' OR supplier_id like  '%" + txtTimKiem.Text + "%'";
           
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(dt);
            dgvCungUng.DataSource = dt;
        }
    }
}
