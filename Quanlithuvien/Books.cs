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
    public partial class Books : UserControl
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter myAdapter;
        private DataSet ds;
        private DataTable dt;
        public Books()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Books_Load(object sender, EventArgs e)
        {
            DBConnect DataBooks = new DBConnect();
            conn = DataBooks.GetConnection();   // Tạo kết nối CSDL
            conn.Open();                         // Mở kết nối

            string sqlStr = "Select * from DAUSACH"; // Câu lệnh truy vấn SQL lấy toàn bộ dữ liệu từ bảng QLSACH
            myAdapter = new SqlDataAdapter(sqlStr, conn); // Tạo Adapter

            ds = new DataSet();
            myAdapter.Fill(ds, "DAUSACH");     // Lấy dữ liệu cho DataTable từ bảng trên
            dt = ds.Tables["DAUSACH"];         // Lấy dữ liệu từ bảng trên

            dataGridView1.DataSource = dt;         // Gán dữ liệu từ dt cho DataGridView trong Form AdDashBoard

            conn.Close();                        // Đóng kết nối
        }
    }
}
