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
    public partial class SignInForm : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public SignInForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DBConnect dBConnect = new DBConnect();
                conn = dBConnect.GetConnection();
                conn.Open();

                // 1️ Kiểm tra tài khoản tồn tại + trạng thái
                string queryCheck = "SELECT TrangThai, VaiTro FROM THUTHU WHERE Username = @username AND Password = @password";
                cmd = new SqlCommand(queryCheck, conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bool trangThai = Convert.ToBoolean(reader["TrangThai"]);
                        string role = reader["VaiTro"].ToString();

                        if (!trangThai)
                        {
                            MessageBox.Show(
                                "Tài khoản của bạn đã bị vô hiệu hóa.\nVui lòng liên hệ quản trị viên.",
                                "Tài khoản bị khóa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        // 2️ Đăng nhập thành công
                        MessageBox.Show("Đăng nhập thành công!",
                                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Session.Username = txtUsername.Text;
                        Session.Role = role;

                        AdminMainform adminMainform = new AdminMainform(Session.Username);
                        adminMainform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!",
                                        "Lỗi đăng nhập",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập:\n" + ex.Message,
                                "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registerform registerForm = new Registerform();
            registerForm.Show();
            this.Hide();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminMainform adminMainform = new AdminMainform("Reader");
            Session.Role = "READER";
            adminMainform.Show();
            this.Hide();
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu checkbox được check (hiện mật khẩu)
            if (chkPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0'; // '\0' là ký tự rỗng, dùng để hiện chữ bình thường
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                // Nếu bạn muốn dùng dấu tròn của hệ thống thì không cần dòng dưới, 
                // nhưng nếu muốn dùng dấu ● hoặc * cố định:
                txtPassword.PasswordChar = '●';
            }
        }
    }
}
