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

        private void LoadData(string query)
        {
            DBConnect DataBooks = new DBConnect();
            conn = DataBooks.GetConnection();   // Tạo kết nối CSDL
            conn.Open();                         // Mở kết nối

            
            myAdapter = new SqlDataAdapter(query, conn); // Tạo Adapter

            ds = new DataSet();
            myAdapter.Fill(ds, "DAUSACH");     // Lấy dữ liệu cho DataTable từ bảng trên
            dt = ds.Tables["DAUSACH"];         // Lấy dữ liệu từ bảng trên

            dataGridView1.DataSource = dt;         // Gán dữ liệu từ dt cho DataGridView trong Form AdDashBoard

            conn.Close();                        // Đóng kết nối
            dataGridView1.ClearSelection();
        }

        private void Books_Load(object sender, EventArgs e)
        {
            if (Session.Role == "READER")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            cboOption.SelectedIndex = 0;
            string query = "select * from DAUSACH";
            LoadData(query);
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            string query = "", choice = cboOption.SelectedItem.ToString();
            string key = txtSearchName.Text;


            switch (choice)
            {
                case "Name":
                    query = $"select * from DAUSACH  where TenSach like N'%{key}%'";
                    break;
                case "Author":
                    query = $"select * from DAUSACH  where TacGia like N'%{key}%'";
                    break;
                case "Category":
                    query = $"select * from DAUSACH  where TheLoai like N'%{key}%'";
                    break;
            }
            LoadData(query);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string query = "", choice = cboOption.SelectedItem.ToString();
            string key = txtSearchName.Text;


            switch (choice)
            {
                case "Name":
                    query = $"select * from DAUSACH  where TenSach like N'%{key}%'";
                    break;
                case "Author":
                    query = $"select * from DAUSACH  where TacGia like N'%{key}%'";
                    break;
                case "Category":
                    query = $"select * from DAUSACH  where TheLoai like N'%{key}%'";
                    break;
            }
            LoadData(query);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Focus();
            if (txtID.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách(ID, Name)!");
                return;
            }

            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();

                // ===== 1. KIỂM TRA TRÙNG MÃ SÁCH =====
                string checkQuery = "SELECT COUNT(*) FROM DAUSACH WHERE IDSach = @IDSach";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@IDSach", txtID.Text);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã sách đã tồn tại! Vui lòng nhập mã khác.");
                    conn.Close();
                    return;
                }

                // ===== 2. THÊM SÁCH =====
                string insertQuery = @"INSERT INTO DAUSACH 
                (IDSach, TenSach, TheLoai, TacGia, NhaXuatBan, NamXuatBan)
                VALUES 
                (@IDSach, @TenSach, @TheLoai, @TacGia, @NhaXuatBan, @NamXuatBan)";

                cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@IDSach", txtID.Text);
                cmd.Parameters.AddWithValue("@TenSach", txtName.Text);
                cmd.Parameters.AddWithValue("@TheLoai", cboCategory.SelectedItem != null ? cboCategory.SelectedItem.ToString() : "");
                cmd.Parameters.AddWithValue("@TacGia", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@NhaXuatBan", txtNXB.Text);
                cmd.Parameters.AddWithValue("@NamXuatBan", txtNamXB.Text);

                int k = cmd.ExecuteNonQuery();
                conn.Close();

                if (k > 0)
                {
                    MessageBox.Show("Thêm sách thành công!");
                    LoadData("select * from DAUSACH");
                    GeneralMethod.ResetText(new List<Control>
                {
                    txtID, txtName, txtAuthor, cboCategory, txtNXB, txtNamXB
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
            if (txtID.Text == "" || txtName.Text == "" || txtAuthor.Text == "" || cboCategory.SelectedItem.ToString() == "" || txtNXB.Text == "" || txtNamXB.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách!");
                return;
            }
            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();
                string updateQuery = "UPDATE DAUSACH SET TenSach = @TenSach, TheLoai = @TheLoai, TacGia = @TacGia, NhaXuatBan = @NhaXuatBan, NamXuatBan = @NamXuatBan WHERE IDSach = @IDSach";
                cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@IDSach", txtID.Text);
                cmd.Parameters.AddWithValue("@TenSach", txtName.Text);
                if (cboCategory.SelectedItem != null) cmd.Parameters.AddWithValue("@TheLoai", cboCategory.SelectedItem.ToString());
                else cmd.Parameters.AddWithValue("@TheLoai", "");
                cmd.Parameters.AddWithValue("@TacGia", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@NhaXuatBan", txtNXB.Text);
                cmd.Parameters.AddWithValue("@NamXuatBan", txtNamXB.Text);
                int k = cmd.ExecuteNonQuery();
                conn.Close();
                if (k > 0)
                {
                    MessageBox.Show("Cập nhật sách thành công!");
                    string query = "select * from DAUSACH";
                    LoadData(query);
                    GeneralMethod.ResetText(new List<Control> { txtID, txtName, txtAuthor, cboCategory, txtNXB, txtNamXB });
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
            string IDSach = txtID.Text;
            if (IDSach == "")
            {
                MessageBox.Show("Vui lòng nhập ID sách cần xóa!");
                return;
            }

            string query = "DELETE FROM DAUSACH WHERE IDSach = @IDSach";
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
                    string querySelect = "select * from DAUSACH";
                    LoadData(querySelect);
                    GeneralMethod.ResetText(new List<Control> { txtID, txtName, txtAuthor, cboCategory, txtNXB, txtNamXB });
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
                txtID.Text = row.Cells["IDSach"].Value.ToString();
                txtName.Text = row.Cells["TenSach"].Value.ToString();
                cboCategory.SelectedItem = row.Cells["TheLoai"].Value.ToString();
                txtAuthor.Text = row.Cells["TacGia"].Value.ToString();
                txtNXB.Text = row.Cells["NhaXuatBan"].Value.ToString();
                txtNamXB.Text = row.Cells["NamXuatBan"].Value.ToString();
            }
        }
    }
}
