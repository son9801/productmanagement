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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadChart_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True";
            string query = "SELECT name, SUM(quantity) AS total_quantity FROM Export JOIN Product ON Export.product_id = product.product_id GROUP BY name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Create a new series for the chart
                    Series series = new Series("Quantity");
                    series.ChartType = SeriesChartType.Pie;

                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        int totalQuantity = reader.GetInt32(1);

                        // Add the data point to the chart series
                        series.Points.AddXY(productName, totalQuantity);
                    }

                    // Add the series to the chart
                    chartXuatHang.Series.Clear();
                    chartXuatHang.Series.Add(series);
                }
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True";
            string query = "SELECT name, SUM(quantity) AS total_quantity FROM Export JOIN Product ON Export.product_id = product.product_id GROUP BY name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Create a new series for the chart
                    Series series = new Series("Quantity");
                    series.ChartType = SeriesChartType.Pie;

                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        int totalQuantity = reader.GetInt32(1);

                        // Add the data point to the chart series
                        series.Points.AddXY(productName, totalQuantity);
                    }

                    // Add the series to the chart
                    chartXuatHang.Series.Clear();
                    chartXuatHang.Series.Add(series);
                }
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
