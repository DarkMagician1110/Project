using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlithuvien
{
    public partial class Users : UserControl
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter myAdapter;
        private DataSet ds;
        private DataTable dt;
        public Users()
        {
            InitializeComponent();
        }

        private void LoadData(string query)
        {
            myAdapter = new SqlDataAdapter(query, conn); // Tạo Adapter

            ds = new DataSet();
            myAdapter.Fill(ds, "KHACHHANG");     // Lấy dữ liệu cho DataTable từ bảng trên
            dt = ds.Tables["KHACHHANG"];         // Lấy dữ liệu từ bảng trên

            dataGridView1.DataSource = dt;         // Gán dữ liệu từ dt cho DataGridView trong Form AdDashBoard

            conn.Close();                        // Đóng kết nối
        }
        private void Users_Load(object sender, EventArgs e)
        {
            string query = "select * from KHACHHANG";
            DBConnect dBConnect = new DBConnect();
            conn = dBConnect.GetConnection();
            conn.Open();
            LoadData(query);
        }

        private void ResetText(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                if (control is ListBox listBox) listBox.SelectedIndex = -1;
                else control.Text = string.Empty;
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

                string insertQuery = "insert into KHACHHANG(MaKH, HoTen, DiaChi, SoDienThoai, Email, NgayDangKy)" +
                                        " values(@MaKH, @HoTen, @DiaChi, @SoDienThoai, @Email, @NgayDangKy)";
                cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtID.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtUsername.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtAddress.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                if(txtRgtDate.Text == "")
                {
                    cmd.Parameters.AddWithValue("@NgayDangKy", DBNull.Value);
                }
                else
                {
                    if(DateTime.TryParse(txtRgtDate.Text, out DateTime rgtDate))
                    {
                        cmd.Parameters.AddWithValue("@NgayDangKy", rgtDate);
                    }
                    else
                    {
                        MessageBox.Show("Ngày đăng ký không hợp lệ!");
                        conn.Close();
                        return;
                    }
                }
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công!");
                    List<Control> controls = new List<Control>() { txtID, txtUsername, txtAddress, txtPhone, txtEmail, txtRgtDate };
                    ResetText(controls);
                    string query = "select * from KHACHHANG";
                    LoadData(query);
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!");
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
            }
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            if (ID == "")
            {
                MessageBox.Show("Vui lòng nhập ID khách hàng cần xóa!");
                return;
            }
            string deleteQuery = "delete from KHACHHANG where MaKH = @MaKH";
            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();

                cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@MaKH", ID);
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                    List<Control> controls = new List<Control>() { txtID, txtUsername, txtAddress, txtPhone, txtEmail, txtRgtDate };
                    ResetText(controls);
                    string query = "select * from KHACHHANG";
                    LoadData(query);
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại!");
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtID.Text = row.Cells[0].Value.ToString();
                txtUsername.Text = row.Cells[1].Value.ToString();
                txtAddress.Text = row.Cells[2].Value.ToString();
                txtPhone.Text = row.Cells[3].Value.ToString();
                txtEmail.Text = row.Cells[4].Value.ToString();
                txtRgtDate.Text = row.Cells[5].Value.ToString();
            }
        }


        private void btnFind_Click_1(object sender, EventArgs e)
        {
            if (lbColumn.SelectedItem == null || txtContent.Text == "")
            {
                MessageBox.Show("Vui lòng chọn cột và nhập từ khóa tìm kiếm!");
                return;
            }
            string column = lbColumn.SelectedItem.ToString();
            string key = txtContent.Text;
            string query = "";
            switch (column)
            {
                case "IDUsername":
                    query = $"select * from KHACHHANG  where MaKH like N'%{key}%'";
                    break;
                case "Username":
                    query = $"select * from KHACHHANG  where HoTen like N'%{key}%'";
                    break;
                case "Address":
                    query = $"select * from KHACHHANG  where DiaChi like N'%{key}%'";
                    break;
            }
            DBConnect dBConnect = new DBConnect();
            conn = dBConnect.GetConnection();
            conn.Open();
            LoadData(query);
        }
    }
}
