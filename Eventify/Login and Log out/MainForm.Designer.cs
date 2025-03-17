namespace Eventify
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.settingsButton = new FontAwesome.Sharp.IconButton();
            this.historyButton = new FontAwesome.Sharp.IconButton();
            this.myButtoy = new FontAwesome.Sharp.IconButton();
            this.createButton = new FontAwesome.Sharp.IconButton();
            this.regesteredButton = new FontAwesome.Sharp.IconButton();
            this.browseButton = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.titleButton = new System.Windows.Forms.Button();
            this.homeButton = new FontAwesome.Sharp.IconButton();
            this.minimize = new FontAwesome.Sharp.IconButton();
            this.maximize = new FontAwesome.Sharp.IconButton();
            this.exit = new FontAwesome.Sharp.IconButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonPanel.Controls.Add(this.label7);
            this.buttonPanel.Controls.Add(this.settingsButton);
            this.buttonPanel.Controls.Add(this.historyButton);
            this.buttonPanel.Controls.Add(this.myButtoy);
            this.buttonPanel.Controls.Add(this.createButton);
            this.buttonPanel.Controls.Add(this.regesteredButton);
            this.buttonPanel.Controls.Add(this.browseButton);
            this.buttonPanel.Controls.Add(this.panel1);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(233, 761);
            this.buttonPanel.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 732);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "© credits";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.settingsButton.IconChar = FontAwesome.Sharp.IconChar.Sliders;
            this.settingsButton.IconColor = System.Drawing.Color.Gainsboro;
            this.settingsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.settingsButton.IconSize = 45;
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(0, 520);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.settingsButton.Size = new System.Drawing.Size(233, 80);
            this.settingsButton.TabIndex = 10;
            this.settingsButton.Text = "  Settings";
            this.settingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.historyButton.FlatAppearance.BorderSize = 0;
            this.historyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.historyButton.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            this.historyButton.IconColor = System.Drawing.Color.Gainsboro;
            this.historyButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.historyButton.IconSize = 45;
            this.historyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.historyButton.Location = new System.Drawing.Point(0, 440);
            this.historyButton.Name = "historyButton";
            this.historyButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.historyButton.Size = new System.Drawing.Size(233, 80);
            this.historyButton.TabIndex = 9;
            this.historyButton.Text = "  Event History";
            this.historyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // myButtoy
            // 
            this.myButtoy.Dock = System.Windows.Forms.DockStyle.Top;
            this.myButtoy.FlatAppearance.BorderSize = 0;
            this.myButtoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myButtoy.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myButtoy.ForeColor = System.Drawing.Color.Gainsboro;
            this.myButtoy.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            this.myButtoy.IconColor = System.Drawing.Color.Gainsboro;
            this.myButtoy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.myButtoy.IconSize = 45;
            this.myButtoy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.myButtoy.Location = new System.Drawing.Point(0, 360);
            this.myButtoy.Name = "myButtoy";
            this.myButtoy.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.myButtoy.Size = new System.Drawing.Size(233, 80);
            this.myButtoy.TabIndex = 8;
            this.myButtoy.Text = "  My Events";
            this.myButtoy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.myButtoy.UseVisualStyleBackColor = true;
            this.myButtoy.Click += new System.EventHandler(this.myButtoy_Click);
            // 
            // createButton
            // 
            this.createButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.createButton.FlatAppearance.BorderSize = 0;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.createButton.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            this.createButton.IconColor = System.Drawing.Color.Gainsboro;
            this.createButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.createButton.IconSize = 45;
            this.createButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createButton.Location = new System.Drawing.Point(0, 280);
            this.createButton.Name = "createButton";
            this.createButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.createButton.Size = new System.Drawing.Size(233, 80);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "  Create Events";
            this.createButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // regesteredButton
            // 
            this.regesteredButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.regesteredButton.FlatAppearance.BorderSize = 0;
            this.regesteredButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regesteredButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regesteredButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.regesteredButton.IconChar = FontAwesome.Sharp.IconChar.FileCircleCheck;
            this.regesteredButton.IconColor = System.Drawing.Color.Gainsboro;
            this.regesteredButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.regesteredButton.IconSize = 45;
            this.regesteredButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.regesteredButton.Location = new System.Drawing.Point(0, 200);
            this.regesteredButton.Name = "regesteredButton";
            this.regesteredButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.regesteredButton.Size = new System.Drawing.Size(233, 80);
            this.regesteredButton.TabIndex = 2;
            this.regesteredButton.Text = "  Registered Events";
            this.regesteredButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.regesteredButton.UseVisualStyleBackColor = true;
            this.regesteredButton.Click += new System.EventHandler(this.regesteredButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.browseButton.FlatAppearance.BorderSize = 0;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.browseButton.IconChar = FontAwesome.Sharp.IconChar.TableList;
            this.browseButton.IconColor = System.Drawing.Color.Gainsboro;
            this.browseButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.browseButton.IconSize = 45;
            this.browseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browseButton.Location = new System.Drawing.Point(0, 120);
            this.browseButton.Name = "browseButton";
            this.browseButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.browseButton.Size = new System.Drawing.Size(233, 80);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "  Browse Events";
            this.browseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 120);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Freestyle Script", 51.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(23, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 82);
            this.label8.TabIndex = 9;
            this.label8.Text = "Eventify";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.titlePanel.Controls.Add(this.iconButton1);
            this.titlePanel.Controls.Add(this.titleButton);
            this.titlePanel.Controls.Add(this.homeButton);
            this.titlePanel.Controls.Add(this.minimize);
            this.titlePanel.Controls.Add(this.maximize);
            this.titlePanel.Controls.Add(this.exit);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(233, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(951, 120);
            this.titlePanel.TabIndex = 1;
            this.titlePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.titlePanel_Paint);
            this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlePanel_MouseDown);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromBracket;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(883, 45);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(53, 50);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // titleButton
            // 
            this.titleButton.BackColor = System.Drawing.Color.Transparent;
            this.titleButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleButton.Enabled = false;
            this.titleButton.FlatAppearance.BorderSize = 0;
            this.titleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.titleButton.Location = new System.Drawing.Point(124, 0);
            this.titleButton.Name = "titleButton";
            this.titleButton.Size = new System.Drawing.Size(694, 120);
            this.titleButton.TabIndex = 5;
            this.titleButton.Text = "Home";
            this.titleButton.UseVisualStyleBackColor = true;
            this.titleButton.Click += new System.EventHandler(this.titleButton_Click);
            this.titleButton.MouseHover += new System.EventHandler(this.titleButton_MouseHover);
            // 
            // homeButton
            // 
            this.homeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.homeButton.Enabled = false;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.homeButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.homeButton.IconColor = System.Drawing.Color.Gainsboro;
            this.homeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.homeButton.IconSize = 45;
            this.homeButton.Location = new System.Drawing.Point(0, 0);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(124, 120);
            this.homeButton.TabIndex = 4;
            this.homeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.homeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // minimize
            // 
            this.minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.minimize.FlatAppearance.BorderSize = 0;
            this.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.minimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.minimize.IconColor = System.Drawing.Color.Gainsboro;
            this.minimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.minimize.IconSize = 20;
            this.minimize.Location = new System.Drawing.Point(865, 0);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(25, 25);
            this.minimize.TabIndex = 2;
            this.minimize.UseVisualStyleBackColor = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // maximize
            // 
            this.maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.maximize.FlatAppearance.BorderSize = 0;
            this.maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximize.IconChar = FontAwesome.Sharp.IconChar.SquareFull;
            this.maximize.IconColor = System.Drawing.Color.Gainsboro;
            this.maximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.maximize.IconSize = 17;
            this.maximize.Location = new System.Drawing.Point(895, -1);
            this.maximize.Name = "maximize";
            this.maximize.Size = new System.Drawing.Size(25, 25);
            this.maximize.TabIndex = 1;
            this.maximize.UseVisualStyleBackColor = false;
            this.maximize.Click += new System.EventHandler(this.maximize_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.exit.IconColor = System.Drawing.Color.Gainsboro;
            this.exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exit.IconSize = 21;
            this.exit.Location = new System.Drawing.Point(926, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(25, 25);
            this.exit.TabIndex = 0;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.flowLayoutPanel3);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Controls.Add(this.flowLayoutPanel1);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(233, 120);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(951, 641);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ongoing";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoScroll = true;
            this.flowLayoutPanel3.BackColor = System.Drawing.SystemColors.Info;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(14, 356);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(716, 264);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Limited Seats";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(739, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 119);
            this.panel2.TabIndex = 5;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 60);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Greetings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(4, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Greetings";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(4, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Your accont balance is";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 59);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(716, 261);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(355, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To EVENTIFY";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.buttonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton browseButton;
        private FontAwesome.Sharp.IconButton regesteredButton;
        private FontAwesome.Sharp.IconButton myButtoy;
        private FontAwesome.Sharp.IconButton createButton;
        private FontAwesome.Sharp.IconButton settingsButton;
        private FontAwesome.Sharp.IconButton historyButton;
        private FontAwesome.Sharp.IconButton minimize;
        private FontAwesome.Sharp.IconButton maximize;
        private FontAwesome.Sharp.IconButton exit;
        private System.Windows.Forms.Panel mainPanel;
        private FontAwesome.Sharp.IconButton homeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button titleButton;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}