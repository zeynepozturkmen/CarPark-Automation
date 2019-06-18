namespace Otopark
{
    partial class FormPersonelOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPersonelOperations));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.boşYerleriGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boşYerleriGösterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.otoparkÇıkışİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşteriİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boşYerleriGösterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(918, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // boşYerleriGösterToolStripMenuItem
            // 
            this.boşYerleriGösterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boşYerleriGösterToolStripMenuItem1,
            this.otoparkÇıkışİşlemleriToolStripMenuItem,
            this.müşteriİşlemleriToolStripMenuItem});
            this.boşYerleriGösterToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.boşYerleriGösterToolStripMenuItem.Name = "boşYerleriGösterToolStripMenuItem";
            this.boşYerleriGösterToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.boşYerleriGösterToolStripMenuItem.Text = "İşlemler";
            // 
            // boşYerleriGösterToolStripMenuItem1
            // 
            this.boşYerleriGösterToolStripMenuItem1.Name = "boşYerleriGösterToolStripMenuItem1";
            this.boşYerleriGösterToolStripMenuItem1.Size = new System.Drawing.Size(278, 24);
            this.boşYerleriGösterToolStripMenuItem1.Text = "Otopark Giriş İşlemleri";
            this.boşYerleriGösterToolStripMenuItem1.Click += new System.EventHandler(this.boşYerleriGösterToolStripMenuItem1_Click);
            // 
            // otoparkÇıkışİşlemleriToolStripMenuItem
            // 
            this.otoparkÇıkışİşlemleriToolStripMenuItem.Name = "otoparkÇıkışİşlemleriToolStripMenuItem";
            this.otoparkÇıkışİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(278, 24);
            this.otoparkÇıkışİşlemleriToolStripMenuItem.Text = "Otopark Çıkış İşlemleri";
            this.otoparkÇıkışİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.otoparkÇıkışİşlemleriToolStripMenuItem_Click);
            // 
            // müşteriİşlemleriToolStripMenuItem
            // 
            this.müşteriİşlemleriToolStripMenuItem.Name = "müşteriİşlemleriToolStripMenuItem";
            this.müşteriİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(278, 24);
            this.müşteriİşlemleriToolStripMenuItem.Text = "Müşteri Ve Araç Kayıt İşlemleri";
            this.müşteriİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.müşteriİşlemleriToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(587, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btnCikis
            // 
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikis.Location = new System.Drawing.Point(700, -1);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(92, 28);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Image")));
            this.btnChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePassword.Location = new System.Drawing.Point(798, 0);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(120, 28);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.Text = "Şifre Değiştir";
            this.btnChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // FormPersonelOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 450);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPersonelOperations";
            this.Text = "FormPersonelOperations";
            this.Activated += new System.EventHandler(this.FormPersonelOperations_Activated);
            this.Load += new System.EventHandler(this.FormPersonelOperations_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem boşYerleriGösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boşYerleriGösterToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.ToolStripMenuItem müşteriİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otoparkÇıkışİşlemleriToolStripMenuItem;
        private System.Windows.Forms.Button btnChangePassword;
    }
}