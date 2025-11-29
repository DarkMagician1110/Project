using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlithuvien
{
    public partial class AdminMainform : Form
    {
        private string currentUsername;
        public AdminMainform(string username)
        {
            InitializeComponent();
            currentUsername = username;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            label3.Text = "Username: " + currentUsername;
        }
        private void DashBoardbt_Click(object sender, EventArgs e)
        {
            AdDashBoard DBooks = new AdDashBoard();
            panelContainer.Controls.Clear();    // xóa control cũ
            panelContainer.Controls.Add(DBooks); // thêm UserControl vào panel
            DBooks.Dock = DockStyle.Fill;        // phóng to vừa panel
        }

        private void Bookbt_Click(object sender, EventArgs e)
        {
            Books BookDetail = new Books();
            panelContainer.Controls.Clear();    // xóa control cũ
            panelContainer.Controls.Add(BookDetail); // thêm UserControl vào panel
            BookDetail.Dock = DockStyle.Fill;        // phóng to vừa panel
        }

        private void Userbt_Click(object sender, EventArgs e)
        {
            Users us = new Users();
            panelContainer.Controls.Clear();    // xóa control cũ
            panelContainer.Controls.Add(us); // thêm UserControl vào panel
            us.Dock = DockStyle.Fill;        // phóng to vừa panel
        }

        private void Logoutbt_Click(object sender, EventArgs e)
        {
            SignInForm loginForm = new SignInForm();
            loginForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
