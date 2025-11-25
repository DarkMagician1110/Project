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
            string query = "select * from DAUSACH";
            LoadData(query);
        }
        private void ResetText(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                if(control is ListBox listBox) listBox.SelectedIndex = -1;
                else control.Text = string.Empty;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = txtSearchName.Text, query = "", choice = "";
            if (listBox3.SelectedItem != null) choice = listBox3.SelectedItem.ToString();
            string key = txtSearchName.Text;
            if (key == "" || choice == "")
            {
                MessageBox.Show("Vui lòng chọn tiêu chí và nhập từ khóa tìm kiếm!");
                return;
            }

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
            if (txtID.Text == "" || txtName.Text == "" || txtQuanlity.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách(ID, Name, SL) !");
                return;
            }
            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();

                string insertQuery = "INSERT INTO DAUSACH (IDSach, TenSach, TheLoai, TacGia, NhaXuatBan, NamXuatBan, NgayNhap, SL) " +
                                     "VALUES (@IDSach, @TenSach, @TheLoai, @TacGia, @NhaXuatBan, @NamXuatBan,@NgayNhap, @SoLuong)";
                cmd = new SqlCommand(insertQuery, conn);
                if (txtReceivedDate.Text == "")
                {
                    cmd.Parameters.AddWithValue("@NgayNhap", DBNull.Value);
                }
                else
                {
                    if (!DateTime.TryParse(txtReceivedDate.Text, out DateTime ngayNhap))
                    {
                        MessageBox.Show("Ngày nhập không hợp lệ!");
                        return;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@NgayNhap", ngayNhap);
                    }
                }
                cmd.Parameters.AddWithValue("@IDSach", txtID.Text);
                cmd.Parameters.AddWithValue("@TenSach", txtName.Text);
                if (lbCategory.SelectedItem != null)
                    cmd.Parameters.AddWithValue("@TheLoai", lbCategory.SelectedItem.ToString());
                else cmd.Parameters.AddWithValue("@TheLoai", "");
                cmd.Parameters.AddWithValue("@TacGia", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@NhaXuatBan", txtNXB.Text);
                cmd.Parameters.AddWithValue("@NamXuatBan", txtNamXB.Text);
                cmd.Parameters.AddWithValue("@SoLuong", txtQuanlity.Text);
                int k = cmd.ExecuteNonQuery();
                conn.Close();
                ResetText(new List<Control> { txtID, txtName, txtAuthor, txtNXB, txtNamXB, txtQuanlity, txtReceivedDate });
                if (k > 0)
                {
                    MessageBox.Show("Thêm sách thành công!");
                    string query = "select * from DAUSACH";
                    LoadData(query);
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

            if (txtID.Text == "" || txtName.Text == "" || txtAuthor.Text == "" || lbCategory.SelectedItem.ToString() == "" || txtNXB.Text == "" || txtNamXB.Text == "" || txtQuanlity.Text == "" || txtReceivedDate.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách!");
                return;
            }
            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();
                string updateQuery = "UPDATE DAUSACH SET TenSach = @TenSach, TheLoai = @TheLoai, TacGia = @TacGia, NhaXuatBan = @NhaXuatBan, NamXuatBan = @NamXuatBan, NgayNhap = @NgayNhap, SL = @SoLuong WHERE IDSach = @IDSach";
                cmd = new SqlCommand(updateQuery, conn);
                if(txtReceivedDate.Text == "")
                {
                    cmd.Parameters.AddWithValue("@NgayNhap", DBNull.Value);
                }
                else
                {
                    if (!DateTime.TryParse(txtReceivedDate.Text, out DateTime ngayNhap))
                    {
                        MessageBox.Show("Ngày nhập không hợp lệ!");
                        return;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@NgayNhap", ngayNhap);
                    }
                }
                cmd.Parameters.AddWithValue("@IDSach", txtID.Text);
                cmd.Parameters.AddWithValue("@TenSach", txtName.Text);
                if(lbCategory.SelectedItem != null) cmd.Parameters.AddWithValue("@TheLoai", lbCategory.SelectedItem.ToString());
                else cmd.Parameters.AddWithValue("@TheLoai", "");
                cmd.Parameters.AddWithValue("@TacGia", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@NhaXuatBan", txtNXB.Text);
                cmd.Parameters.AddWithValue("@NamXuatBan", txtNamXB.Text);
                cmd.Parameters.AddWithValue("@SoLuong", txtQuanlity.Text);
                int k = cmd.ExecuteNonQuery();
                conn.Close();
                ResetText(new List<Control> { txtID, txtName, txtAuthor, txtNXB, txtNamXB, txtQuanlity, txtReceivedDate });
                if (k > 0)
                {
                    MessageBox.Show("Cập nhật sách thành công!");
                    string query = "select * from DAUSACH";
                    LoadData(query);
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
                ResetText(new List<Control> { txtID, txtName, txtAuthor, txtNXB, txtNamXB, txtQuanlity, txtReceivedDate });
                if (k > 0)
                {
                    MessageBox.Show("Xóa sách thành công!");
                    string querySelect = "select * from DAUSACH";
                    LoadData(querySelect);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtID.Text = row.Cells["IDSach"].Value.ToString();
                txtName.Text = row.Cells["TenSach"].Value.ToString();
                lbCategory.SelectedItem = row.Cells["TheLoai"].Value.ToString();
                txtAuthor.Text = row.Cells["TacGia"].Value.ToString();
                txtNXB.Text = row.Cells["NhaXuatBan"].Value.ToString();
                txtNamXB.Text = row.Cells["NamXuatBan"].Value.ToString();
                txtReceivedDate.Text = Convert.ToDateTime(row.Cells["NgayNhap"].Value).ToString("dd/MM/yyyy");
                txtQuanlity.Text = row.Cells["SL"].Value.ToString();
            }
        }
    }
}
