namespace SalesControl.FrontEnd.View {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cart_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.cartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employees_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.products_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.make_backup_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.restore_backup_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.quit_session_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.user_lbl = new System.Windows.Forms.Label();
            this.menu_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_strip
            // 
            this.menu_strip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem,
            this.cartToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(991, 28);
            this.menu_strip.TabIndex = 0;
            this.menu_strip.Text = "menuStrip1";
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cart_btn});
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // cart_btn
            // 
            this.cart_btn.Name = "cart_btn";
            this.cart_btn.Size = new System.Drawing.Size(224, 26);
            this.cart_btn.Text = "New Cart";
            this.cart_btn.Click += new System.EventHandler(this.CartButtonClickEvent);
            // 
            // cartToolStripMenuItem
            // 
            this.cartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employees_btn,
            this.products_btn});
            this.cartToolStripMenuItem.Name = "cartToolStripMenuItem";
            this.cartToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.cartToolStripMenuItem.Text = "Manager";
            // 
            // employees_btn
            // 
            this.employees_btn.Name = "employees_btn";
            this.employees_btn.Size = new System.Drawing.Size(164, 26);
            this.employees_btn.Text = "Employees";
            this.employees_btn.Click += new System.EventHandler(this.EmployeesButtonClickEvent);
            // 
            // products_btn
            // 
            this.products_btn.Name = "products_btn";
            this.products_btn.Size = new System.Drawing.Size(164, 26);
            this.products_btn.Text = "Products";
            this.products_btn.Click += new System.EventHandler(this.ProductsButtonClickEvent);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.make_backup_btn,
            this.restore_backup_btn,
            this.quit_session_btn});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // make_backup_btn
            // 
            this.make_backup_btn.Name = "make_backup_btn";
            this.make_backup_btn.Size = new System.Drawing.Size(224, 26);
            this.make_backup_btn.Text = "Make a Backup";
            this.make_backup_btn.Click += new System.EventHandler(this.MakeBackupButtonClickEvent);
            // 
            // restore_backup_btn
            // 
            this.restore_backup_btn.Name = "restore_backup_btn";
            this.restore_backup_btn.Size = new System.Drawing.Size(224, 26);
            this.restore_backup_btn.Text = "Restore Backup";
            this.restore_backup_btn.Click += new System.EventHandler(this.RestoreBackupButtonClickEvent);
            // 
            // quit_session_btn
            // 
            this.quit_session_btn.Name = "quit_session_btn";
            this.quit_session_btn.Size = new System.Drawing.Size(224, 26);
            this.quit_session_btn.Text = "Quit session";
            this.quit_session_btn.Click += new System.EventHandler(this.QuitSessionButtonClickEvent);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about_btn});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // about_btn
            // 
            this.about_btn.Name = "about_btn";
            this.about_btn.Size = new System.Drawing.Size(224, 26);
            this.about_btn.Text = "About";
            this.about_btn.Click += new System.EventHandler(this.AboutBtnClickEvent);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(519, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(472, 478);
            this.label2.TabIndex = 16;
            this.label2.Text = "Sales Control System (SCS) @ 2024";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // user_lbl
            // 
            this.user_lbl.AutoSize = true;
            this.user_lbl.BackColor = System.Drawing.Color.Transparent;
            this.user_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_lbl.ForeColor = System.Drawing.SystemColors.Window;
            this.user_lbl.Location = new System.Drawing.Point(25, 53);
            this.user_lbl.Name = "user_lbl";
            this.user_lbl.Size = new System.Drawing.Size(287, 46);
            this.user_lbl.TabIndex = 23;
            this.user_lbl.Text = "Welcome user!";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(991, 506);
            this.Controls.Add(this.user_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menu_strip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_strip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Control System (SCS)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.ToolStripMenuItem cartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employees_btn;
        private System.Windows.Forms.ToolStripMenuItem products_btn;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem make_backup_btn;
        private System.Windows.Forms.ToolStripMenuItem restore_backup_btn;
        private System.Windows.Forms.ToolStripMenuItem quit_session_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label user_lbl;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cart_btn;
        private System.Windows.Forms.ToolStripMenuItem about_btn;
    }
}