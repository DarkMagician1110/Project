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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMainform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Logoutbt = new System.Windows.Forms.Button();
            this.Userbt = new System.Windows.Forms.Button();
            this.Bookbt = new System.Windows.Forms.Button();
            this.DashBoardbt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 45);
            this.panel1.TabIndex = 0;
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
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(1465, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(23, 24);
            this.close.TabIndex = 19;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(286, 130);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.Logoutbt);
            this.panel2.Controls.Add(this.Userbt);
            this.panel2.Controls.Add(this.Bookbt);
            this.panel2.Controls.Add(this.DashBoardbt);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 745);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // Logoutbt
            // 
            this.Logoutbt.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.Logoutbt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logoutbt.ForeColor = System.Drawing.Color.Black;
            this.Logoutbt.Location = new System.Drawing.Point(6, 677);
            this.Logoutbt.Name = "Logoutbt";
            this.Logoutbt.Size = new System.Drawing.Size(228, 56);
            this.Logoutbt.TabIndex = 30;
            this.Logoutbt.Text = "Logout";
            this.Logoutbt.UseVisualStyleBackColor = false;
            this.Logoutbt.Click += new System.EventHandler(this.Logoutbt_Click);
            // 
            // Userbt
            // 
            this.Userbt.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.Userbt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Userbt.ForeColor = System.Drawing.Color.Black;
            this.Userbt.Location = new System.Drawing.Point(6, 471);
            this.Userbt.Name = "Userbt";
            this.Userbt.Size = new System.Drawing.Size(228, 56);
            this.Userbt.TabIndex = 29;
            this.Userbt.Text = "Users";
            this.Userbt.UseVisualStyleBackColor = false;
            this.Userbt.Click += new System.EventHandler(this.Userbt_Click);
            // 
            // Bookbt
            // 
            this.Bookbt.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.Bookbt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bookbt.ForeColor = System.Drawing.Color.Black;
            this.Bookbt.Location = new System.Drawing.Point(6, 409);
            this.Bookbt.Name = "Bookbt";
            this.Bookbt.Size = new System.Drawing.Size(228, 56);
            this.Bookbt.TabIndex = 27;
            this.Bookbt.Text = "Books";
            this.Bookbt.UseVisualStyleBackColor = false;
            this.Bookbt.Click += new System.EventHandler(this.Bookbt_Click);
            // 
            // DashBoardbt
            // 
            this.DashBoardbt.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.DashBoardbt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashBoardbt.ForeColor = System.Drawing.Color.Black;
            this.DashBoardbt.Location = new System.Drawing.Point(6, 347);
            this.DashBoardbt.Name = "DashBoardbt";
            this.DashBoardbt.Size = new System.Drawing.Size(228, 56);
            this.DashBoardbt.TabIndex = 26;
            this.DashBoardbt.Text = "DashBoard";
            this.DashBoardbt.UseVisualStyleBackColor = false;
            this.DashBoardbt.Click += new System.EventHandler(this.DashBoardbt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Username: Admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 33);
            this.label2.TabIndex = 21;
            this.label2.Text = "Admin\'s portal";
            // 
            // panelContainer
            // 
            this.panelContainer.Location = new System.Drawing.Point(242, 46);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1258, 744);
            this.panelContainer.TabIndex = 2;
            // 
            // AdminMainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 790);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMainform";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Logoutbt;
        private System.Windows.Forms.Button Userbt;
        private System.Windows.Forms.Button Bookbt;
        private System.Windows.Forms.Button DashBoardbt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelContainer;
    }
}