namespace Eventify.AdminForms
{
    partial class MainAdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAdminForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.minimize = new FontAwesome.Sharp.IconButton();
            this.exit = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 588);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel2.Controls.Add(this.iconButton4);
            this.panel2.Controls.Add(this.minimize);
            this.panel2.Controls.Add(this.exit);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 26);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // iconButton4
            // 
            this.iconButton4.BackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromBracket;
            this.iconButton4.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 25;
            this.iconButton4.Location = new System.Drawing.Point(871, 0);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(25, 25);
            this.iconButton4.TabIndex = 42;
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton4.UseVisualStyleBackColor = false;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // minimize
            // 
            this.minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimize.BackColor = System.Drawing.Color.Transparent;
            this.minimize.FlatAppearance.BorderSize = 0;
            this.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.minimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.minimize.IconColor = System.Drawing.Color.Gainsboro;
            this.minimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.minimize.IconSize = 20;
            this.minimize.Location = new System.Drawing.Point(900, 1);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(25, 25);
            this.minimize.TabIndex = 41;
            this.minimize.UseVisualStyleBackColor = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.exit.IconColor = System.Drawing.Color.Gainsboro;
            this.exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exit.IconSize = 21;
            this.exit.Location = new System.Drawing.Point(926, 1);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(25, 25);
            this.exit.TabIndex = 40;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.SystemColors.Control;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt;
            this.iconButton3.IconColor = System.Drawing.SystemColors.Control;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.Location = new System.Drawing.Point(476, 614);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(247, 91);
            this.iconButton3.TabIndex = 6;
            this.iconButton3.Text = "Generate Cards";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton3.UseVisualStyleBackColor = false;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.SystemColors.Control;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.iconButton2.IconColor = System.Drawing.SystemColors.Control;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.Location = new System.Drawing.Point(232, 614);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(244, 91);
            this.iconButton2.TabIndex = 3;
            this.iconButton2.Text = "Event List";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.iconButton1.IconColor = System.Drawing.SystemColors.Control;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(0, 614);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(232, 91);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.Text = "User List";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton5
            // 
            this.iconButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton5.ForeColor = System.Drawing.SystemColors.Control;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.iconButton5.IconColor = System.Drawing.SystemColors.Control;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.Location = new System.Drawing.Point(717, 614);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(236, 91);
            this.iconButton5.TabIndex = 7;
            this.iconButton5.Text = "Add Admin";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton5.UseVisualStyleBackColor = false;
            this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // MainAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(952, 700);
            this.Controls.Add(this.iconButton5);
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainAdminForm";
            this.Load += new System.EventHandler(this.MainAdminForm_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton minimize;
        private FontAwesome.Sharp.IconButton exit;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton5;
    }
}