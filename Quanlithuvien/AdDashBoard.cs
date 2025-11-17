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

namespace Quanlithuvien
{
    public partial class AdDashBoard : UserControl
    {
        private SqlConnection conn; 
        private SqlCommand cmd; 
        private SqlDataAdapter myAdapter; 
        private DataSet ds; 
        private DataTable dt;
        public AdDashBoard()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdDashBoard_Load(object sender, EventArgs e)
        {
            DBConnect DataBooks = new DBConnect();
            conn = DataBooks.GetConnection();   // Tạo kết nối CSDL
            conn.Open();                         // Mở kết nối

            string sqlStr = "Select * from QLSACH"; // Câu lệnh truy vấn SQL lấy toàn bộ dữ liệu từ bảng QLSACH
            myAdapter = new SqlDataAdapter(sqlStr, conn); // Tạo Adapter

            ds = new DataSet();
            myAdapter.Fill(ds, "QLSACH");     // Lấy dữ liệu cho DataTable từ bảng trên
            dt = ds.Tables["QLSACH"];         // Lấy dữ liệu từ bảng trên

            dataGridView1.DataSource = dt;         // Gán dữ liệu từ dt cho DataGridView trong Form AdDashBoard

            conn.Close();                        // Đóng kết nối

        }
    }
}
