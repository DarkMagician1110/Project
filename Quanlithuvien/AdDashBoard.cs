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
using System.Xml.Linq;

namespace Quanlithuvien
{
    public partial class AdDashBoard : UserControl
    {
        private SqlConnection conn; 
        private SqlDataAdapter myAdapter; 
        private SqlCommand cmd;
        private DataSet ds; 
        private DataTable dt;
        public AdDashBoard()
        {
            InitializeComponent();
        }

        private int countAvailableBooks()
        {
            int cnt = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TinhTrang"].Value != null && row.Cells["TinhTrang"].Value.ToString() == "0")
                {
                    cnt++;
                }
            }
            return cnt;
        }

        private int countBorrowedBooks()
        {
            int cnt = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TinhTrang"].Value != null && row.Cells["TinhTrang"].Value.ToString() == "1")
                {
                    cnt++;
                }
            }
            return cnt;
        }

        private int countBrokenBooks()
        {
            int cnt = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TinhTrang"].Value != null && row.Cells["TinhTrang"].Value.ToString() == "2")
                {
                    cnt++;
                }
            }
            return cnt;
        }

        private int countLostBooks()
        {
            int cnt = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["TinhTrang"].Value != null && row.Cells["TinhTrang"].Value.ToString() == "3")
                {
                    cnt++;
                }
            }
            return cnt;
        }
        
        public void LoadData(string sqlStr)
        {
            DBConnect DataBooks = new DBConnect();
            conn = DataBooks.GetConnection();   // Tạo kết nối CSDL
            conn.Open();                         // Mở kết nối

            myAdapter = new SqlDataAdapter(sqlStr, conn); // Tạo Adapter

            ds = new DataSet();
            myAdapter.Fill(ds, "SACH");     // Lấy dữ liệu cho DataTable từ bảng trên
            dt = ds.Tables["SACH"];         // Lấy dữ liệu từ bảng trên

            dataGridView1.DataSource = dt;         // Gán dữ liệu từ dt cho DataGridView trong Form AdDashBoard

            conn.Close();                        // Đóng kết nối

            label2.Text = countAvailableBooks().ToString();
            label3.Text = countBorrowedBooks().ToString();
            label5.Text = countBrokenBooks().ToString();
            label7.Text = countLostBooks().ToString();                       // Đóng kết nối
        }
        private void AdDashBoard_Load(object sender, EventArgs e)
        {
            cboState.SelectedIndex = 0;
            if(Session.Role == "READER")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            LoadData("select * from SACH");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtAccessionNo.Focus();
            if (txtAccessionNo.Text == "" || txtIDBook.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách(AccesionNo, IdBook)");
                return;
            }

            if(cboState.SelectedItem.ToString() != "Có sẵn")
            {
                MessageBox.Show("Chỉ được thêm sách với trạng thái là có sẵn!");
                return;
            }
            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();

                // ===== 1. KIỂM TRA TRÙNG MÃ SÁCH =====
                string checkQuery = "SELECT COUNT(*) FROM SACH WHERE AccessionNo = @IDSach";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@IDSach", txtAccessionNo.Text);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("AccessionNo đã tồn tại! Vui lòng nhập mã khác.");
                    conn.Close();
                    return;
                }

                // ===== 2. THÊM SÁCH =====
                string insertQuery = @"INSERT INTO SACH 
                (AccessionNo, IDSach, TinhTrang, NgayNhap)
                VALUES 
                (@AccessionNo, @IDSach, @TinhTrang, @NgayNhap)";

                cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@AccessionNo", txtAccessionNo.Text);
                cmd.Parameters.AddWithValue("@IDSach", txtIDBook.Text);
                cmd.Parameters.AddWithValue("@TinhTrang", cboState.SelectedIndex);
                cmd.Parameters.AddWithValue("@NgayNhap", DateTime.Now);
                int k = cmd.ExecuteNonQuery();
                conn.Close();

                if (k > 0)
                {
                    MessageBox.Show("Thêm sách thành công!");
                    LoadData("select * from SACH");
                    GeneralMethod.ResetText(new List<Control>
                {
                    txtAccessionNo, txtIDBook, cboState
                });
                }
                else
                {
                    MessageBox.Show("Thêm sách thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo.Text == "" || txtIDBook.Text == "" || cboState.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách!");
                return;
            }

            string statement = "SELECT TinhTrang FROM SACH WHERE AccessionNo = @IDSach";
            cmd = new SqlCommand(statement, conn);
            cmd.Parameters.AddWithValue("@IDSach", txtAccessionNo.Text);
            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();
            if (result.ToString() == "1")
            {
                MessageBox.Show("Chỉ được cập nhật sách ở trạng thái có sẵn, bị hỏng, bị mất!");
                return;
            }

            if(cboState.SelectedItem.ToString() == "Đang được mượn")
            {
                MessageBox.Show("Không được chuyển đổi trạng thái sách thành được mượn!");
                return;
            }
            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();
                string updateQuery = "UPDATE SACH SET IDSach = @IDSach, TinhTrang = @TrangThai WHERE AccessionNo = @AccessionNo";
                cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@AccessionNo", txtAccessionNo.Text);
                cmd.Parameters.AddWithValue("@IDSach", txtIDBook.Text);
                cmd.Parameters.AddWithValue("@TrangThai", cboState.SelectedIndex);
                int k = cmd.ExecuteNonQuery();
                conn.Close();
                if (k > 0)
                {
                    MessageBox.Show("Cập nhật sách thành công!");
                    string query = "select * from SACH";
                    LoadData(query);
                    GeneralMethod.ResetText(new List<Control> { txtAccessionNo, txtIDBook, cboState });
                }
                else
                {
                    MessageBox.Show("Cập nhật sách thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string IDSach = txtAccessionNo.Text;
            if (IDSach == "")
            {
                MessageBox.Show("Vui lòng nhập AccessionNo cần xóa!");
                return;
            }

            string statement = "SELECT TinhTrang FROM SACH WHERE AccessionNo = @IDSach";
            cmd = new SqlCommand(statement, conn);
            cmd.Parameters.AddWithValue("@IDSach", IDSach);
            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();
            if (result.ToString() == "1")
            {
                MessageBox.Show("Chỉ được xóa sách ở trạng thái có sẵn, bị hỏng, bị mất!");
                return;
            }

            string query = "DELETE FROM SACH WHERE AccessionNo = @IDSach";
            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDSach", IDSach);
                int k = cmd.ExecuteNonQuery();
                conn.Close();
                if (k > 0)
                {
                    MessageBox.Show("Xóa sách thành công!");
                    string querySelect = "select * from SACH";
                    LoadData(querySelect);
                    GeneralMethod.ResetText(new List<Control> { txtAccessionNo, txtIDBook, cboState });
                }
                else
                {
                    MessageBox.Show("Xóa sách thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtAccessionNo.Text = row.Cells["AccessionNo"].Value.ToString();
                txtIDBook.Text = row.Cells["IDSach"].Value.ToString();
                string tinhTrang = row.Cells["TinhTrang"].Value.ToString();
                if(tinhTrang == "0")
                {
                    cboState.SelectedIndex = 0;
                }
                else if(tinhTrang == "1")
                {
                    cboState.SelectedIndex = 1;
                }
                else if(tinhTrang == "2")
                {
                    cboState.SelectedIndex = 2;
                }
                else if(tinhTrang == "3")
                {
                    cboState.SelectedIndex = 3;
                }
            }
        }
    }
}
