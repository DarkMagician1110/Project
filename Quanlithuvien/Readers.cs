using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quanlithuvien
{
    public partial class Reader : UserControl
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter myAdapter;
        private DataSet ds;
        private DataTable dt;

        public Reader()
        {
            InitializeComponent();
        }

        // ================= LOAD DATA =================
        private void LoadData(string query)
        {
            try
            {
                myAdapter = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                myAdapter.Fill(ds, "DOCGIA");
                dt = ds.Tables["DOCGIA"];
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            string key = txtContent.Text;
            string query = "";

            switch (cboOption.SelectedItem.ToString())
            {
                case "IDUsername":
                    query = $"SELECT * FROM DOCGIA WHERE MaKH LIKE N'%{key}%'";
                    break;
                case "Username":
                    query = $"SELECT * FROM DOCGIA WHERE HoTen LIKE N'%{key}%'";
                    break;
                case "Address":
                    query = $"SELECT * FROM DOCGIA WHERE DiaChi LIKE N'%{key}%'";
                    break;
            }

            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();
                LoadData(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string key = txtContent.Text;
            string query = "";

            switch (cboOption.SelectedItem.ToString())
            {
                case "IDUsername":
                    query = $"SELECT * FROM DOCGIA WHERE MaKH LIKE N'%{key}%'";
                    break;
                case "Username":
                    query = $"SELECT * FROM DOCGIA WHERE HoTen LIKE N'%{key}%'";
                    break;
                case "Address":
                    query = $"SELECT * FROM DOCGIA WHERE DiaChi LIKE N'%{key}%'";
                    break;
            }

            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();
                LoadData(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void Reader_Load(object sender, EventArgs e)
        {
            try
            {
                cboOption.SelectedIndex = 0;
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();
                LoadData("SELECT * FROM DOCGIA");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load độc giả: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();

                string insertQuery =
                    @"INSERT INTO DOCGIA 
              (MaKH, HoTen, DiaChi, SoDienThoai, Email, NgayDangKy)
              VALUES 
              (@MaKH, @HoTen, @DiaChi, @SoDienThoai, @Email, @NgayDangKy)";

                cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtID.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtUsername.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtAddress.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@NgayDangKy", DateTime.Now);

                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công!");
                    GeneralMethod.ResetText(new List<Control>
            {
                txtID, txtUsername, txtAddress, txtPhone, txtEmail
            });

                    conn.Close();
                    conn.Open();
                    LoadData("SELECT * FROM DOCGIA");
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ID khách hàng cần xóa!");
                return;
            }

            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();

                string deleteQuery = "DELETE FROM DOCGIA WHERE MaKH = @MaKH";
                cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtID.Text);

                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                    GeneralMethod.ResetText(new List<Control>
            {
                txtID, txtUsername, txtAddress, txtPhone, txtEmail
            });

                    conn.Close();
                    conn.Open();
                    LoadData("SELECT * FROM DOCGIA");
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnDeactive_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ID khách hàng cần hủy kích hoạt!");
                return;
            }

            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();
                string deactivateQuery = "UPDATE DOCGIA SET TrangThai = 0 WHERE MaKH = @MaKH";
                cmd = new SqlCommand(deactivateQuery, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtID.Text);
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Hủy kích hoạt khách hàng thành công!");
                    GeneralMethod.ResetText(new List<Control>
            {
                txtID, txtUsername, txtAddress, txtPhone, txtEmail
            });
                    conn.Close();
                    conn.Open();
                    LoadData("SELECT * FROM DOCGIA");
                }
                else
                {
                    MessageBox.Show("Hủy kích hoạt khách hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy kích hoạt khách hàng: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value?.ToString();
                txtUsername.Text = row.Cells[1].Value?.ToString();
                txtAddress.Text = row.Cells[2].Value?.ToString();
                txtPhone.Text = row.Cells[3].Value?.ToString();
                txtEmail.Text = row.Cells[4].Value?.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ ID và Username!");
                return;
            }

            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();
                string updateQuery =
                    @"UPDATE DOCGIA SET 
              HoTen = @HoTen, 
              DiaChi = @DiaChi, 
              SoDienThoai = @SoDienThoai, 
              Email = @Email, 
              WHERE MaKH = @MaKH";
                cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtID.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtUsername.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtAddress.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                    GeneralMethod.ResetText(new List<Control>
            {
                txtID, txtUsername, txtAddress, txtPhone, txtEmail
            });
                    LoadData("SELECT * FROM DOCGIA");
                }
                else
                {
                    MessageBox.Show("Cập nhật khách hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
