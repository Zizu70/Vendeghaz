﻿namespace Vendeghaz
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_LoginName = new System.Windows.Forms.TextBox();
            this.textBox_LoginPass = new System.Windows.Forms.TextBox();
            this.comboBox_LoginRole = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_LoginPerm = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.button_LoginService = new System.Windows.Forms.Button();
            this.button_LoginInsert = new System.Windows.Forms.Button();
            this.button_LoginUpdate = new System.Windows.Forms.Button();
            this.button_LoginDelete = new System.Windows.Forms.Button();
            this.textBox_LoginId = new System.Windows.Forms.TextBox();
            this.label_LoginId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::Vendeghaz.Properties.Resources.logoatlatszo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 131);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(241, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Üdvözöljük!";
            // 
            // textBox_LoginName
            // 
            this.textBox_LoginName.Location = new System.Drawing.Point(203, 167);
            this.textBox_LoginName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox_LoginName.Name = "textBox_LoginName";
            this.textBox_LoginName.Size = new System.Drawing.Size(244, 30);
            this.textBox_LoginName.TabIndex = 1;
            // 
            // textBox_LoginPass
            // 
            this.textBox_LoginPass.Location = new System.Drawing.Point(203, 222);
            this.textBox_LoginPass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox_LoginPass.Name = "textBox_LoginPass";
            this.textBox_LoginPass.Size = new System.Drawing.Size(244, 30);
            this.textBox_LoginPass.TabIndex = 2;
            // 
            // comboBox_LoginRole
            // 
            this.comboBox_LoginRole.FormattingEnabled = true;
            this.comboBox_LoginRole.Location = new System.Drawing.Point(203, 272);
            this.comboBox_LoginRole.Name = "comboBox_LoginRole";
            this.comboBox_LoginRole.Size = new System.Drawing.Size(244, 31);
            this.comboBox_LoginRole.TabIndex = 3;
            this.comboBox_LoginRole.Visible = false;
            this.comboBox_LoginRole.SelectedIndexChanged += new System.EventHandler(this.comboBox_LoginRole_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(162, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Név";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(148, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Jelszó";
            // 
            // label_LoginPerm
            // 
            this.label_LoginPerm.AutoSize = true;
            this.label_LoginPerm.BackColor = System.Drawing.Color.White;
            this.label_LoginPerm.Location = new System.Drawing.Point(113, 275);
            this.label_LoginPerm.Name = "label_LoginPerm";
            this.label_LoginPerm.Size = new System.Drawing.Size(84, 23);
            this.label_LoginPerm.TabIndex = 9;
            this.label_LoginPerm.Text = "Jogosultság";
            this.label_LoginPerm.Visible = false;
            // 
            // button_Login
            // 
            this.button_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button_Login.Location = new System.Drawing.Point(233, 328);
            this.button_Login.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(180, 36);
            this.button_Login.TabIndex = 4;
            this.button_Login.Text = "Belépés";
            this.button_Login.UseVisualStyleBackColor = false;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // button_LoginService
            // 
            this.button_LoginService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_LoginService.Location = new System.Drawing.Point(233, 374);
            this.button_LoginService.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_LoginService.Name = "button_LoginService";
            this.button_LoginService.Size = new System.Drawing.Size(180, 36);
            this.button_LoginService.TabIndex = 5;
            this.button_LoginService.Text = "Szervíz";
            this.button_LoginService.UseVisualStyleBackColor = false;
            this.button_LoginService.Click += new System.EventHandler(this.button_LoginService_Click);
            // 
            // button_LoginInsert
            // 
            this.button_LoginInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(225)))));
            this.button_LoginInsert.Location = new System.Drawing.Point(194, 427);
            this.button_LoginInsert.Name = "button_LoginInsert";
            this.button_LoginInsert.Size = new System.Drawing.Size(75, 36);
            this.button_LoginInsert.TabIndex = 6;
            this.button_LoginInsert.Text = "Felvitel";
            this.button_LoginInsert.UseVisualStyleBackColor = false;
            this.button_LoginInsert.Visible = false;
            this.button_LoginInsert.Click += new System.EventHandler(this.button_LoginInsert_Click);
            // 
            // button_LoginUpdate
            // 
            this.button_LoginUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(165)))), ((int)(((byte)(240)))));
            this.button_LoginUpdate.Location = new System.Drawing.Point(275, 427);
            this.button_LoginUpdate.Name = "button_LoginUpdate";
            this.button_LoginUpdate.Size = new System.Drawing.Size(85, 36);
            this.button_LoginUpdate.TabIndex = 7;
            this.button_LoginUpdate.Text = "Módosítás";
            this.button_LoginUpdate.UseVisualStyleBackColor = false;
            this.button_LoginUpdate.Visible = false;
            this.button_LoginUpdate.Click += new System.EventHandler(this.button_LoginUpdate_Click);
            // 
            // button_LoginDelete
            // 
            this.button_LoginDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.button_LoginDelete.Location = new System.Drawing.Point(365, 427);
            this.button_LoginDelete.Name = "button_LoginDelete";
            this.button_LoginDelete.Size = new System.Drawing.Size(75, 36);
            this.button_LoginDelete.TabIndex = 8;
            this.button_LoginDelete.Text = "Törlés";
            this.button_LoginDelete.UseVisualStyleBackColor = false;
            this.button_LoginDelete.Visible = false;
            this.button_LoginDelete.Click += new System.EventHandler(this.button_LoginDelete_Click);
            // 
            // textBox_LoginId
            // 
            this.textBox_LoginId.Location = new System.Drawing.Point(203, 115);
            this.textBox_LoginId.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBox_LoginId.Name = "textBox_LoginId";
            this.textBox_LoginId.ReadOnly = true;
            this.textBox_LoginId.Size = new System.Drawing.Size(244, 30);
            this.textBox_LoginId.TabIndex = 10;
            this.textBox_LoginId.Visible = false;
            // 
            // label_LoginId
            // 
            this.label_LoginId.AutoSize = true;
            this.label_LoginId.BackColor = System.Drawing.Color.White;
            this.label_LoginId.Location = new System.Drawing.Point(174, 118);
            this.label_LoginId.Name = "label_LoginId";
            this.label_LoginId.Size = new System.Drawing.Size(23, 23);
            this.label_LoginId.TabIndex = 11;
            this.label_LoginId.Text = "Id";
            this.label_LoginId.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vendeghaz.Properties.Resources.Login___out;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(638, 544);
            this.Controls.Add(this.button_LoginDelete);
            this.Controls.Add(this.button_LoginUpdate);
            this.Controls.Add(this.button_LoginInsert);
            this.Controls.Add(this.button_LoginService);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.label_LoginPerm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_LoginId);
            this.Controls.Add(this.comboBox_LoginRole);
            this.Controls.Add(this.textBox_LoginPass);
            this.Controls.Add(this.textBox_LoginName);
            this.Controls.Add(this.textBox_LoginId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormLogin";
            this.Text = "Vendégház Vadaspark";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_LoginName;
        private System.Windows.Forms.TextBox textBox_LoginPass;
        private System.Windows.Forms.ComboBox comboBox_LoginRole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_LoginPerm;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Button button_LoginService;
        private System.Windows.Forms.Button button_LoginInsert;
        private System.Windows.Forms.Button button_LoginUpdate;
        private System.Windows.Forms.Button button_LoginDelete;
        private System.Windows.Forms.TextBox textBox_LoginId;
        private System.Windows.Forms.Label label_LoginId;
    }
}

