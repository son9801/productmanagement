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

namespace WindowsFormsApp1
{
    public partial class frmBanLe : Form
    {
        public frmBanLe()
        {
            InitializeComponent();
        }
        private SqlConnection con;
        private void LoadData()
        {
            String sql = "Select * from Retailer";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            dgvBanLe.DataSource = ds.Tables[0];
            dgvBanLe.Refresh();
        }

        private void dgvBanLe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBanLe.ReadOnly = true;
            int i;
            i = dgvBanLe.CurrentRow.Index;
            txtMaBanLe.Text = dgvBanLe.Rows[i].Cells[0].Value.ToString();
            txtTenBanLe.Text = dgvBanLe.Rows[i].Cells[1].Value.ToString();
            txtEmail.Text = dgvBanLe.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dgvBanLe.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvBanLe.Rows[i].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Retailer (retailer_id, name, email, phone_number, address) VALUES('" + txtMaBanLe.Text + "',N'" + txtTenBanLe.Text + "', '" + txtEmail.Text + "','" + txtSDT.Text + "',N'" + txtDiaChi.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Retailer set  name = N'" + txtTenBanLe.Text + "', email = '" + txtEmail.Text + "', phone_number = N'" + txtSDT.Text + "', address = N'" + txtDiaChi.Text + "' WHERE retailer_id = '" + txtMaBanLe.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Retailer WHERE retailer_id='" + txtMaBanLe.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaBanLe.Clear();
            txtTenBanLe.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaBanLe.ReadOnly = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = "Select * from Retailer WHERE name like N'%" + txtTimKiem.Text + "%' OR retailer_id like  '%" + txtTimKiem.Text + "%'";

            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(dt);
            dgvBanLe.DataSource = dt;
        }

        private void frmBanLe_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True";
            con.Open();
            LoadData();
        }
    }

    
 }

