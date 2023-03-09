using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void AddForm(Form f)
        {
            this.pnlContent.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.pnlContent.Controls.Add(f);
            f.Show();
        }


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.AutoSize = true;
        }

        private void toolStripButtonDanhMuc_Click(object sender, EventArgs e)
        {
            frmDanhMuc f = new frmDanhMuc();
            AddForm(f);
        }

        private void toolStripButtonNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            AddForm(f);
        }

        private void toolStripButtonHangXuat_Click(object sender, EventArgs e)
        {
            frmHangXuat f = new frmHangXuat();
            AddForm(f);
        }

        private void toolStripButtonHangNhap_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButtonThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe f = new frmThongKe();
            AddForm(f);
        }

        private void toolStripButtonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButtonHangHoa_Click(object sender, EventArgs e)
        {
            frmHangHoa f = new frmHangHoa();
            AddForm(f);
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmCungUng f = new frmCungUng();
            AddForm(f);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmBanLe f = new frmBanLe();
            AddForm(f);
        }

        private void tạoHoáĐơnXuấtMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHangNhap f = new frmHangNhap();
            AddForm(f);
        }
    }
}
