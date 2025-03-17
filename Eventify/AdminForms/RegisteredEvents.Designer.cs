namespace Eventify.AdminForms
{
    partial class RegisteredEvents
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton9 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, -1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(811, 284);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Registered Events";
            // 
            // iconButton9
            // 
            this.iconButton9.BackColor = System.Drawing.Color.LightGreen;
            this.iconButton9.FlatAppearance.BorderSize = 0;
            this.iconButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton9.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton9.IconColor = System.Drawing.Color.Black;
            this.iconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton9.Location = new System.Drawing.Point(819, 122);
            this.iconButton9.Name = "iconButton9";
            this.iconButton9.Size = new System.Drawing.Size(73, 32);
            this.iconButton9.TabIndex = 25;
            this.iconButton9.Text = "Back";
            this.iconButton9.UseVisualStyleBackColor = false;
            this.iconButton9.Click += new System.EventHandler(this.iconButton9_Click);
            // 
            // RegisteredEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 283);
            this.Controls.Add(this.iconButton9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisteredEvents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisteredEvents";
            this.Load += new System.EventHandler(this.RegisteredEvents_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton9;
    }
}