namespace Quanlithuvien
{
    partial class Registerform
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
            this.Register_btn = new System.Windows.Forms.Button();
            this.Register_showpass = new System.Windows.Forms.CheckBox();
            this.Register_confirmpass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Register_username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Register_loginbtn = new System.Windows.Forms.Button();
            this.Register_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Register_btn
            // 
            this.Register_btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.Register_btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_btn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Register_btn.Location = new System.Drawing.Point(544, 392);
            this.Register_btn.Name = "Register_btn";
            this.Register_btn.Size = new System.Drawing.Size(137, 42);
            this.Register_btn.TabIndex = 8;
            this.Register_btn.Text = "SIGNUP";
            this.Register_btn.UseVisualStyleBackColor = false;
            // 
            // Register_showpass
            // 
            this.Register_showpass.AutoSize = true;
            this.Register_showpass.Location = new System.Drawing.Point(472, 368);
            this.Register_showpass.Name = "Register_showpass";
            this.Register_showpass.Size = new System.Drawing.Size(124, 20);
            this.Register_showpass.TabIndex = 14;
            this.Register_showpass.Text = "Show password";
            this.Register_showpass.UseVisualStyleBackColor = true;
            // 
            // Register_confirmpass
            // 
            this.Register_confirmpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_confirmpass.Location = new System.Drawing.Point(472, 314);
            this.Register_confirmpass.Name = "Register_confirmpass";
            this.Register_confirmpass.PasswordChar = '*';
            this.Register_confirmpass.Size = new System.Drawing.Size(347, 30);
            this.Register_confirmpass.TabIndex = 13;
            this.Register_confirmpass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(468, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Password:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Register_username
            // 
            this.Register_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_username.Location = new System.Drawing.Point(472, 124);
            this.Register_username.Name = "Register_username";
            this.Register_username.Size = new System.Drawing.Size(347, 30);
            this.Register_username.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(468, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Username:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(551, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 55);
            this.label2.TabIndex = 9;
            this.label2.Text = "REGISTER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Register_loginbtn);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 486);
            this.panel1.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(116, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(313, 55);
            this.label7.TabIndex = 9;
            this.label7.Text = "By Thawsng And Two other";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 91);
            this.label6.TabIndex = 8;
            this.label6.Text = "Library Manager";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(56, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Already have a account?";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Register_loginbtn
            // 
            this.Register_loginbtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.Register_loginbtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_loginbtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Register_loginbtn.Location = new System.Drawing.Point(43, 403);
            this.Register_loginbtn.Name = "Register_loginbtn";
            this.Register_loginbtn.Size = new System.Drawing.Size(352, 42);
            this.Register_loginbtn.TabIndex = 1;
            this.Register_loginbtn.Text = "SIGN IN";
            this.Register_loginbtn.UseVisualStyleBackColor = false;
            this.Register_loginbtn.Click += new System.EventHandler(this.Register_loginbtn_Click);
            // 
            // Register_password
            // 
            this.Register_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_password.Location = new System.Drawing.Point(472, 228);
            this.Register_password.Name = "Register_password";
            this.Register_password.PasswordChar = '*';
            this.Register_password.Size = new System.Drawing.Size(347, 30);
            this.Register_password.TabIndex = 17;
            this.Register_password.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(468, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Confirm password:";
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(828, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(23, 24);
            this.close.TabIndex = 18;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Registerform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 484);
            this.Controls.Add(this.close);
            this.Controls.Add(this.Register_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Register_btn);
            this.Controls.Add(this.Register_showpass);
            this.Controls.Add(this.Register_confirmpass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Register_username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Registerform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registerform";
            this.Load += new System.EventHandler(this.Registerform_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Register_btn;
        private System.Windows.Forms.CheckBox Register_showpass;
        private System.Windows.Forms.TextBox Register_confirmpass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Register_username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Register_loginbtn;
        private System.Windows.Forms.TextBox Register_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label close;
    }
}