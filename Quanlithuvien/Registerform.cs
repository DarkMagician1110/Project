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
    public partial class Registerform : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        public Registerform()
        {
            InitializeComponent();
        }

        private void Registerform_Load(object sender, EventArgs e)
        {
            txtConfirm.UseSystemPasswordChar = true;
            txtConfirm.UseSystemPasswordChar = true;
        }


        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Register_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked)
            {
                txtConfirm.UseSystemPasswordChar = false;
                txtConfirm.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirm.UseSystemPasswordChar = true;
                txtConfirm.UseSystemPasswordChar = true;
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtConfirm.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Password and Confirm Password do not match.");
                    return;
                }
                DBConnect dBregister = new DBConnect();
                conn = dBregister.GetConnection();
                conn.Open();

                string checkStr = "SELECT COUNT(*) FROM THUTHU WHERE UserName = @username";
                SqlCommand checkCmd = new SqlCommand(checkStr, conn);
                checkCmd.Parameters.AddWithValue("@username", txtUsername.Text);
                int userCount = (int)checkCmd.ExecuteScalar();
                if (userCount > 0)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                    return;
                }

                string sqlStr = "INSERT INTO THUTHU (UserName, PassWord) VALUES (@username, @password)";
                cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtConfirm.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SignInForm loginForm = new SignInForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
