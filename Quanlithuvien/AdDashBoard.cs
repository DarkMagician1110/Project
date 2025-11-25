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

        private int tongSoSach()
        {
            if (dt == null)
            {
                return 0;
            }
            return dt.Rows.Count;
        }
        private int tongSLSachChoMuon()
        {
            if (dt == null)
            {
                return 0;
            }
            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["TinhTrang"]) == 1)
                {
                    count++;
                }
            }
            return count;
        }

        private int SoNguoiMuon ()
        {
            if (dt == null) {
                return 0;
            }
            HashSet<string> uniqueBorrowers = new HashSet<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["TinhTrang"]) == 1)
                {
                    uniqueBorrowers.Add(row["NguoiMuon"].ToString());
                }
            }
            return uniqueBorrowers.Count;
        }

        //private int SoSachQuaHan()
        //{
        //    if (dt == null)
        //    {
        //        return 0;
        //    }
        //    int count = 0;
            
        //    return count;
        //}

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

            label2.Text = tongSoSach().ToString();
            label3.Text = tongSLSachChoMuon().ToString();
            label5.Text = SoNguoiMuon().ToString();

        }
    }
}
