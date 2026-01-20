using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quanlithuvien
{
    public partial class Librarian : UserControl
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter myAdapter;
        private DataSet ds;
        private DataTable dt;

        public Librarian()
        {
            InitializeComponent();
        }

        private void LoadData(string query)
        {
            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();

                myAdapter = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                myAdapter.Fill(ds, "THUTHU");
                dt = ds.Tables["THUTHU"];
                dgvLibrarian.DataSource = dt;
                dgvLibrarian.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu thủ thư:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void Librarian_Load(object sender, EventArgs e)
        {
            cboOption.SelectedIndex = 0;
            string query = "SELECT * FROM THUTHU";
            LoadData(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string column = cboOption.SelectedItem.ToString();
                string key = txtSearch.Text;
                string query = "";

                switch (column)
                {
                    case "MaNV":
                        query = "SELECT * FROM THUTHU WHERE MaNV LIKE '%" + key + "%'";
                        break;
                    case "Fullname":
                        query = "SELECT * FROM THUTHU WHERE HoTen LIKE '%" + key + "%'";
                        break;
                    case "Position":
                        query = "SELECT * FROM THUTHU WHERE VaiTro LIKE '%" + key + "%'";
                        break;
                }

                LoadData(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string column = cboOption.SelectedItem.ToString();
                string key = txtSearch.Text;
                string query = "";

                switch (column)
                {
                    case "MaNV":
                        query = "SELECT * FROM THUTHU WHERE MaNV LIKE '%" + key + "%'";
                        break;
                    case "Fullname":
                        query = "SELECT * FROM THUTHU WHERE HoTen LIKE '%" + key + "%'";
                        break;
                    case "Position":
                        query = "SELECT * FROM THUTHU WHERE VaiTro LIKE '%" + key + "%'";
                        break;
                }

                LoadData(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "" ||
        txtFullname.Text == "" || txtID.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm thủ thư này?",
                                              "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            //CHÈN DỮ LIỆU  
            string query = @"INSERT INTO THUTHU (MaNV, HoTen, Username, Password, VaiTro)
                     VALUES (@MaNV, @HoTen, @Username, @Password, @VaiTro)";

            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", txtID.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtFullname.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@VaiTro", "THUTHU");
                int k = cmd.ExecuteNonQuery();

                if (k > 0)
                {
                    MessageBox.Show("Thêm thủ thư thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GeneralMethod.ResetText(new List<Control>
            {
                txtID, txtFullname, txtUsername, txtPassword
            });
                    LoadData("SELECT * FROM THUTHU");
                }
                else
                {
                    MessageBox.Show("Thêm thủ thư thất bại!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thủ thư:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên để xóa!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /////////////// KIỂM TRA NGƯỜI BỊ XÓA CÓ PHẢI LÀ ADMIN KHÔNG //////////////
            string THUTHUdeleteCheck = "SELECT VaiTro FROM THUTHU WHERE MaNV = @MaNV";
            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();
                cmd = new SqlCommand(THUTHUdeleteCheck, conn);
                cmd.Parameters.AddWithValue("@MaNV", txtID.Text);
                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Mã Nhân Viên không tồn tại!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (result.ToString() == "ADMIN")
                {
                    MessageBox.Show("Không thể xóa thủ thư có quyền ADMIN!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra thủ thư trước khi xóa:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa thủ thư này?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;
            ////////////////////// XÓA DỮ LIỆU //////////////////////
            string query = "DELETE FROM THUTHU WHERE MaNV = @MaNV";

            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", txtID.Text);

                int k = cmd.ExecuteNonQuery();

                if (k > 0)
                {
                    MessageBox.Show("Xóa thủ thư thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GeneralMethod.ResetText(new List<Control>                     {
                txtID, txtFullname, txtUsername, txtPassword
            });
                    LoadData("SELECT * FROM THUTHU");
                }
                else
                {
                    MessageBox.Show("Xóa thủ thư thất bại!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thủ thư:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thủ thư để phân quyền!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ///////KIỂM TRA CÓ PHẢI LÀ THUTHU KHÔNG///////
            string checkThuthuQuery = "SELECT VaiTro FROM THUTHU WHERE MaNV = @MaNV";
            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();
                cmd = new SqlCommand(checkThuthuQuery, conn);
                cmd.Parameters.AddWithValue("@MaNV", txtID.Text);
                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Mã Nhân Viên không tồn tại!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (result.ToString() == "ADMIN")
                {
                    MessageBox.Show("Thủ thư này đã là ADMIN!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra thủ thư trước khi phân quyền:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn phân quyền ADMIN cho thủ thư này?",
                                          "Xác nhận phân quyền", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            /////////////UPDATE VAI TRÒ CHO THUTHU////////////
            string updateRoleTHUTHU = "UPDATE THUTHU SET VaiTro = @VaiTro WHERE MaNV = @MaNV";
            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();
                cmd = new SqlCommand(updateRoleTHUTHU, conn);
                cmd.Parameters.AddWithValue("@VaiTro", "ADMIN");
                cmd.Parameters.AddWithValue("@MaNV", txtID.Text);
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Phân quyền thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GeneralMethod.ResetText(new List<Control>                    {
                txtID, txtFullname, txtUsername, txtPassword
            });
                    LoadData("SELECT * FROM THUTHU");
                }
                else
                {
                    MessageBox.Show("Phân quyền thất bại!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phân quyền:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            //UPDATE VAI TRÒ CHO ADMIN
            string updateRoleAdmin = "UPDATE THUTHU SET VaiTro = @VaiTro WHERE Username = @Username";
            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();
                cmd = new SqlCommand(updateRoleAdmin, conn);
                cmd.Parameters.AddWithValue("@VaiTro", "THUTHU");
                cmd.Parameters.AddWithValue("@Username", Session.Username);
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Hủy phân quyền admin thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GeneralMethod.ResetText(new List<Control>
            {
                txtID, txtFullname, txtUsername, txtPassword
            });
                    LoadData("SELECT * FROM THUTHU");
                }
                else
                {
                    MessageBox.Show("Hủy phân quyền admin thất bại!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy phân quyền admin:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Vui lòng chọn thủ thư để Deactive!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn Deactive thủ thư này?",
                                              "Xác nhận Deactive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            /////////// DEACTIVE THỦ THƯ ///////////
            string deactiveQuery = "UPDATE THUTHU SET TrangThai = 0 where MaNV = @MaNV";
            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();
                cmd = new SqlCommand(deactiveQuery, conn);
                cmd.Parameters.AddWithValue("@MaNV", txtID.Text);
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Deactive thủ thư thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GeneralMethod.ResetText(new List<Control>
            {
                txtID, txtFullname, txtUsername, txtPassword
            });
                    LoadData("SELECT * FROM THUTHU");
                }
                else
                {
                    MessageBox.Show("Deactive thủ thư thất bại!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Deactive thủ thư:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void dgvLibrarian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLibrarian.Rows[e.RowIndex];
                txtID.Text = row.Cells["MaNV"].Value.ToString();
                txtFullname.Text = row.Cells["HoTen"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text == "" || txtID.Text == "" || txtPassword.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();
                string query = "UPDATE THUTHU SET HoTen = @HoTen, Username = @Username, Password = @Password WHERE MaNV = @MaNV";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoTen", txtFullname.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@MaNV", txtID.Text);
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GeneralMethod.ResetText(new List<Control> { txtID, txtFullname, txtUsername, txtPassword });
                    LoadData("SELECT * FROM THUTHU");
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin thủ thư!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
        

