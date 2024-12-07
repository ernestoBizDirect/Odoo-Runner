namespace OdooRunner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnRun = new Button();
            lblConfig = new Label();
            lstConfiguration = new ListBox();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            button1 = new Button();
            btnAdd = new Button();
            menuStrip1 = new MenuStrip();
            stgsMenu = new ToolStripMenuItem();
            txtOdooLog = new TextBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnRun
            // 
            btnRun.Location = new Point(330, 80);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(75, 23);
            btnRun.TabIndex = 1;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // lblConfig
            // 
            lblConfig.AutoSize = true;
            lblConfig.Location = new Point(6, 197);
            lblConfig.Name = "lblConfig";
            lblConfig.Size = new Size(144, 15);
            lblConfig.TabIndex = 2;
            lblConfig.Text = "Select odoo configuration";
            // 
            // lstConfiguration
            // 
            lstConfiguration.FormattingEnabled = true;
            lstConfiguration.ItemHeight = 15;
            lstConfiguration.Location = new Point(6, 22);
            lstConfiguration.Name = "lstConfiguration";
            lstConfiguration.Size = new Size(318, 169);
            lstConfiguration.TabIndex = 3;
            lstConfiguration.SelectedIndexChanged += lstConfiguration_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(lstConfiguration);
            groupBox1.Controls.Add(lblConfig);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnRun);
            groupBox1.Location = new Point(12, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(422, 222);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Odoo configurations";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(330, 51);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // button1
            // 
            button1.Location = new Point(330, 109);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Stop";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnStop_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(330, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add new";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { stgsMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(446, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // stgsMenu
            // 
            stgsMenu.Name = "stgsMenu";
            stgsMenu.Size = new Size(61, 20);
            stgsMenu.Text = "Settings";
            stgsMenu.Click += stgsMenu_Click;
            // 
            // txtOdooLog
            // 
            txtOdooLog.Dock = DockStyle.Fill;
            txtOdooLog.Location = new Point(3, 19);
            txtOdooLog.Multiline = true;
            txtOdooLog.Name = "txtOdooLog";
            txtOdooLog.ReadOnly = true;
            txtOdooLog.ScrollBars = ScrollBars.Vertical;
            txtOdooLog.Size = new Size(416, 244);
            txtOdooLog.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtOdooLog);
            groupBox2.Location = new Point(12, 264);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(422, 266);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Odoo Log";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 540);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Odoo Runner";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRun;
        private Label lblConfig;
        private ListBox lstConfiguration;
        private GroupBox groupBox1;
        private Button btnAdd;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem stgsMenu;
        private TextBox txtOdooLog;
        private GroupBox groupBox2;
        private Button button1;
        private Button btnDelete;
    }
}