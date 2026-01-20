namespace Quanlithuvien
{
    partial class AdminMainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMainform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.btnMax = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.Logoutbt = new Guna.UI2.WinForms.Guna2Button();
            this.btnLibrarian = new Guna.UI2.WinForms.Guna2Button();
            this.btnBorrowReturn = new Guna.UI2.WinForms.Guna2Button();
            this.btnReader = new Guna.UI2.WinForms.Guna2Button();
            this.Bookbt = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DashBoardbt = new Guna.UI2.WinForms.Guna2Button();
            this.panelContainer = new Guna.UI2.WinForms.Guna2Panel();
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 45);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMin);
            this.panel2.Controls.Add(this.close);
            this.panel2.Controls.Add(this.btnMax);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1382, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 45);
            this.panel2.TabIndex = 23;
            // 
            // btnMin
            // 
            this.btnMin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMin.Location = new System.Drawing.Point(3, 9);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(26, 24);
            this.btnMin.TabIndex = 22;
            this.btnMin.Text = "-";
            this.btnMin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(92, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(23, 24);
            this.close.TabIndex = 19;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // btnMax
            // 
            this.btnMax.AutoSize = true;
            this.btnMax.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMax.Location = new System.Drawing.Point(48, 9);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(24, 24);
            this.btnMax.TabIndex = 21;
            this.btnMax.Text = "☐";
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Library Management System";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(286, 130);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.guna2GradientPanel1.Controls.Add(this.label3);
            this.guna2GradientPanel1.Controls.Add(this.label4);
            this.guna2GradientPanel1.Controls.Add(this.Logoutbt);
            this.guna2GradientPanel1.Controls.Add(this.btnLibrarian);
            this.guna2GradientPanel1.Controls.Add(this.btnBorrowReturn);
            this.guna2GradientPanel1.Controls.Add(this.btnReader);
            this.guna2GradientPanel1.Controls.Add(this.Bookbt);
            this.guna2GradientPanel1.Controls.Add(this.pictureBox2);
            this.guna2GradientPanel1.Controls.Add(this.DashBoardbt);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.DarkSeaGreen;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.LightGray;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 45);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(266, 745);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 27);
            this.label3.TabIndex = 47;
            this.label3.Text = "User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(30, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 33);
            this.label4.TabIndex = 34;
            this.label4.Text = "Admin\'s portal";
            // 
            // Logoutbt
            // 
            this.Logoutbt.BackColor = System.Drawing.Color.Transparent;
            this.Logoutbt.BorderColor = System.Drawing.Color.White;
            this.Logoutbt.BorderRadius = 5;
            this.Logoutbt.BorderThickness = 1;
            this.Logoutbt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.Logoutbt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logoutbt.ForeColor = System.Drawing.Color.Black;
            this.Logoutbt.HoverState.FillColor = System.Drawing.Color.SeaGreen;
            this.Logoutbt.Image = ((System.Drawing.Image)(resources.GetObject("Logoutbt.Image")));
            this.Logoutbt.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Logoutbt.ImageSize = new System.Drawing.Size(36, 36);
            this.Logoutbt.Location = new System.Drawing.Point(12, 668);
            this.Logoutbt.Name = "Logoutbt";
            this.Logoutbt.Size = new System.Drawing.Size(246, 65);
            this.Logoutbt.TabIndex = 46;
            this.Logoutbt.Text = "Logout";
            this.Logoutbt.Click += new System.EventHandler(this.Logoutbt_Click);
            // 
            // btnLibrarian
            // 
            this.btnLibrarian.BackColor = System.Drawing.Color.Transparent;
            this.btnLibrarian.BorderColor = System.Drawing.Color.White;
            this.btnLibrarian.BorderRadius = 5;
            this.btnLibrarian.BorderThickness = 1;
            this.btnLibrarian.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLibrarian.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnLibrarian.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibrarian.ForeColor = System.Drawing.Color.Black;
            this.btnLibrarian.HoverState.FillColor = System.Drawing.Color.SeaGreen;
            this.btnLibrarian.Image = ((System.Drawing.Image)(resources.GetObject("btnLibrarian.Image")));
            this.btnLibrarian.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLibrarian.ImageSize = new System.Drawing.Size(36, 36);
            this.btnLibrarian.Location = new System.Drawing.Point(12, 565);
            this.btnLibrarian.Name = "btnLibrarian";
            this.btnLibrarian.Size = new System.Drawing.Size(246, 56);
            this.btnLibrarian.TabIndex = 45;
            this.btnLibrarian.Text = "Librarian";
            this.btnLibrarian.Click += new System.EventHandler(this.btnLibrarian_Click);
            // 
            // btnBorrowReturn
            // 
            this.btnBorrowReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrowReturn.BorderColor = System.Drawing.Color.White;
            this.btnBorrowReturn.BorderRadius = 5;
            this.btnBorrowReturn.BorderThickness = 1;
            this.btnBorrowReturn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBorrowReturn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnBorrowReturn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrowReturn.ForeColor = System.Drawing.Color.Black;
            this.btnBorrowReturn.HoverState.FillColor = System.Drawing.Color.SeaGreen;
            this.btnBorrowReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrowReturn.Image")));
            this.btnBorrowReturn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBorrowReturn.ImageSize = new System.Drawing.Size(36, 36);
            this.btnBorrowReturn.Location = new System.Drawing.Point(12, 503);
            this.btnBorrowReturn.Name = "btnBorrowReturn";
            this.btnBorrowReturn.PressedColor = System.Drawing.Color.Bisque;
            this.btnBorrowReturn.Size = new System.Drawing.Size(246, 56);
            this.btnBorrowReturn.TabIndex = 44;
            this.btnBorrowReturn.Text = "    Borrow/Return";
            this.btnBorrowReturn.Click += new System.EventHandler(this.btnBorrowReturn_Click);
            // 
            // btnReader
            // 
            this.btnReader.BackColor = System.Drawing.Color.Transparent;
            this.btnReader.BorderColor = System.Drawing.Color.White;
            this.btnReader.BorderRadius = 5;
            this.btnReader.BorderThickness = 1;
            this.btnReader.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnReader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnReader.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReader.ForeColor = System.Drawing.Color.Black;
            this.btnReader.HoverState.FillColor = System.Drawing.Color.SeaGreen;
            this.btnReader.Image = ((System.Drawing.Image)(resources.GetObject("btnReader.Image")));
            this.btnReader.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReader.ImageSize = new System.Drawing.Size(36, 36);
            this.btnReader.Location = new System.Drawing.Point(12, 441);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(246, 56);
            this.btnReader.TabIndex = 43;
            this.btnReader.Text = "Reader";
            this.btnReader.Click += new System.EventHandler(this.btnReader_Click);
            // 
            // Bookbt
            // 
            this.Bookbt.BackColor = System.Drawing.Color.Transparent;
            this.Bookbt.BorderColor = System.Drawing.Color.White;
            this.Bookbt.BorderRadius = 5;
            this.Bookbt.BorderThickness = 1;
            this.Bookbt.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.Bookbt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.Bookbt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bookbt.ForeColor = System.Drawing.Color.Black;
            this.Bookbt.HoverState.FillColor = System.Drawing.Color.SeaGreen;
            this.Bookbt.Image = ((System.Drawing.Image)(resources.GetObject("Bookbt.Image")));
            this.Bookbt.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Bookbt.ImageSize = new System.Drawing.Size(36, 36);
            this.Bookbt.Location = new System.Drawing.Point(12, 379);
            this.Bookbt.Name = "Bookbt";
            this.Bookbt.Size = new System.Drawing.Size(246, 56);
            this.Bookbt.TabIndex = 42;
            this.Bookbt.Text = "Books";
            this.Bookbt.Click += new System.EventHandler(this.Bookbt_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(59, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(159, 165);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // DashBoardbt
            // 
            this.DashBoardbt.BackColor = System.Drawing.Color.Transparent;
            this.DashBoardbt.BorderColor = System.Drawing.Color.White;
            this.DashBoardbt.BorderRadius = 5;
            this.DashBoardbt.BorderThickness = 1;
            this.DashBoardbt.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.DashBoardbt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.DashBoardbt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashBoardbt.ForeColor = System.Drawing.Color.Black;
            this.DashBoardbt.HoverState.FillColor = System.Drawing.Color.SeaGreen;
            this.DashBoardbt.Image = ((System.Drawing.Image)(resources.GetObject("DashBoardbt.Image")));
            this.DashBoardbt.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DashBoardbt.ImageSize = new System.Drawing.Size(36, 36);
            this.DashBoardbt.Location = new System.Drawing.Point(12, 317);
            this.DashBoardbt.Name = "DashBoardbt";
            this.DashBoardbt.Size = new System.Drawing.Size(246, 56);
            this.DashBoardbt.TabIndex = 34;
            this.DashBoardbt.Text = "DashBoard";
            this.DashBoardbt.Click += new System.EventHandler(this.DashBoardbt_Click_1);
            // 
            // panelContainer
            // 
            this.panelContainer.BorderRadius = 20;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(266, 45);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1234, 745);
            this.panelContainer.TabIndex = 2;
            // 
            // AdminMainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 790);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMainform";
            this.Load += new System.EventHandler(this.AdminMainform_Load);
            this.SizeChanged += new System.EventHandler(this.AdminMainform_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnMin;
        private System.Windows.Forms.Label btnMax;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button DashBoardbt;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button Logoutbt;
        private Guna.UI2.WinForms.Guna2Button btnLibrarian;
        private Guna.UI2.WinForms.Guna2Button btnBorrowReturn;
        private Guna.UI2.WinForms.Guna2Button btnReader;
        private Guna.UI2.WinForms.Guna2Button Bookbt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Panel panelContainer;
        private Guna.UI2.WinForms.Guna2HtmlLabel label3;
        private System.Windows.Forms.Panel panel2;
    }
}