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
    public partial class frmDanhMuc : Form
    {
        public frmDanhMuc()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDM.ReadOnly = true;
            int i;
            i = dgvDanhMuc.CurrentRow.Index;
            txtMaDM.Text =  dgvDanhMuc.Rows[i].Cells[0].Value.ToString();
            txtTenDM.Text = dgvDanhMuc.Rows[i].Cells[1].Value.ToString();
        }
        private SqlConnection con;
        private void LoadData()
        {
            String sql = "Select * from Catalog";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            dgvDanhMuc.DataSource = ds.Tables[0];
            dgvDanhMuc.Refresh();
        }
        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True";
            con.Open();
            LoadData();

            dgvDanhMuc.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhMuc.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            string sql = "INSERT INTO Catalog(catalog_id, name) VALUES('"+txtMaDM.Text+"',N'"+txtTenDM.Text+"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Catalog set name = N'"+ txtTenDM.Text + "' WHERE catalog_id ='" + txtMaDM.Text +"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Catalog WHERE catalog_id='"+ txtMaDM.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaDM.ReadOnly = false;
            txtMaDM.Clear();
            txtTenDM.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = "Select * from Catalog where name like N'%" + txtTimKiem.Text + "%'";
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(dt);
            dgvDanhMuc.DataSource = dt;
        }
    }
}
