using System;
using System.Collections.Generic;
using System.Drawing;
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

            // Kích hoạt DoubleBuffered để Form chính chạy mượt hơn
            this.DoubleBuffered = true;
        }

        /// <summary>
        /// Kỹ thuật quan trọng: Chống nhấp nháy và lag khi render các control Guna
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        /// <summary>
        /// Hàm điều hướng mượt mà: Kiểm tra trong bộ nhớ trước khi tạo mới
        /// </summary>
        /// <param name="type">Kiểu dữ liệu của UserControl (ví dụ: typeof(Librarian))</param>
        private void ShowUserControl(Type type)
        {
            panelContainer.SuspendLayout();

            UserControl uc = null;
            foreach (Control c in panelContainer.Controls)
            {
                if (c.GetType() == type)
                {
                    uc = (UserControl)c;
                    break;
                }
            }

            if (uc == null)
            {
                uc = (UserControl)Activator.CreateInstance(type);
                uc.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(uc);
            }

            foreach (Control c in panelContainer.Controls)
            {
                c.Visible = (c == uc);
            }

            // THÊM DÒNG NÀY: Ép UserControl cập nhật lại kích thước khớp với Panel khi hiện ra
            uc.Size = panelContainer.ClientSize;
            uc.BringToFront();

            panelContainer.ResumeLayout();
        }

        // --- CÁC SỰ KIỆN CLICK NÚT TRÊN SIDEBAR ---

        private void DashBoardbt_Click_1(object sender, EventArgs e)
        {
            ShowUserControl(typeof(AdDashBoard));
        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            // Kiểm tra tên Class là Readers hay Reader (theo ảnh của bạn là Readers.cs)
            ShowUserControl(typeof(Reader));
        }

        private void btnBorrowReturn_Click(object sender, EventArgs e)
        {
            ShowUserControl(typeof(BorrowAndReturn));
        }

        private void btnLibrarian_Click(object sender, EventArgs e)
        {
            ShowUserControl(typeof(Librarian));
        }

        private void Bookbt_Click(object sender, EventArgs e)
        {
            ShowUserControl(typeof(Books));
        }

        // --- CÁC CHỨC NĂNG HỆ THỐNG ---

        private void AdminMainform_Load(object sender, EventArgs e)
        {
            label3.Text = "Username: " + currentUsername;

            // Phân quyền hiển thị nút dựa trên Session
            if (Session.Role == "THUTHU")
            {
                btnLibrarian.Visible = false;
            }
            else if (Session.Role == "READER")
            {
                btnReader.Visible = false;
                btnLibrarian.Visible = false;
                btnBorrowReturn.Visible = false;
            }

            // Mặc định load trang Dashboard khi ứng dụng khởi động xong
            DashBoardbt_Click_1(null, null);
        }

        private void Logoutbt_Click(object sender, EventArgs e)
        {
            SignInForm loginForm = new SignInForm();
            loginForm.Show();
            this.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

            this.Refresh();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AdminMainform_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                foreach (Control c in panelContainer.Controls)
                {
                    if (c is UserControl && c.Visible)
                    {
                        c.Dock = DockStyle.Fill;
                        c.Invalidate(); // Ép Control vẽ lại vùng bị bẩn
                        c.Update();     // Yêu cầu vẽ ngay lập tức
                        break;
                    }
                }
            }
        }
    }
}