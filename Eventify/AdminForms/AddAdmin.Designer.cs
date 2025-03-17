namespace Eventify.AdminForms
{
    partial class AddAdmin
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(532, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(345, 530);
            this.dataGridView1.TabIndex = 17;
            // 
            // iconButton6
            // 
            this.iconButton6.BackColor = System.Drawing.Color.Transparent;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.iconButton6.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.Location = new System.Drawing.Point(163, 350);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Size = new System.Drawing.Size(132, 91);
            this.iconButton6.TabIndex = 15;
            this.iconButton6.Text = "Add New Admin";
            this.iconButton6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton6.UseVisualStyleBackColor = false;
            this.iconButton6.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(86, 271);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(293, 24);
            this.textBox2.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Admin Password";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(86, 213);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 24);
            this.textBox1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Admin Name";
            // 
            // AddAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 588);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.iconButton6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAdmin";
            this.Text = "AddAdmin";
            this.Load += new System.EventHandler(this.AddAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton iconButton6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}