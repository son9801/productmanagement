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
    public partial class frmNhanVien : Form
    {
        private SqlConnection con;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        
        private void LoadData()
        {
            String sql = "Select * from Employee";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            dgvNhanVien.DataSource = ds.Tables[0];
            dgvNhanVien.Refresh();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True";
            con.Open();
            LoadData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Employee (employee_id, name, gender, phone_number, address) VALUES('" + txtMaNV.Text + "',N'" + txtHoTen.Text + "',N'" + txtGioiTinh.Text + "', '" + txtSDT.Text + "',N'" + txtDiaChi.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Employee set  name = N'" + txtHoTen.Text + "', gender = N'" + txtGioiTinh.Text + "', phone_number = '" + txtSDT.Text + "', address = N'" + txtDiaChi.Text + "' WHERE employee_id = '" + txtMaNV.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Employee WHERE employee_id='" + txtMaNV.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtGioiTinh.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaNV.ReadOnly = false;
        }

      


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = "Select * from Employee WHERE name like N'%" + txtTimKiem.Text + "%' OR employee_id like  '%" + txtTimKiem.Text + "%'";
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(dt);
            dgvNhanVien.DataSource = dt;
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.ReadOnly = true;
            int i;
            i = dgvNhanVien.CurrentRow.Index;
            txtMaNV.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            txtGioiTinh.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
        }
    }
}
