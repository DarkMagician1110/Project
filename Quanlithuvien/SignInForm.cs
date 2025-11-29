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

        private void Signin_registerbtn_Click(object sender, EventArgs e)
        {
            Registerform registerForm = new Registerform();
            registerForm.Show();
            this.Hide();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string query = "SELECT COUNT(*) FROM QLDANGNHAP WHERE username = @username AND password = @password";
            DBConnect dbConnect = new DBConnect();
            conn = dbConnect.GetConnection();
            conn.Open();
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                MessageBox.Show("Login successful!");
                AdminMainform adminMainform = new AdminMainform(username);
                adminMainform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {

        }
    }
}
