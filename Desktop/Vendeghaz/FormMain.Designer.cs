﻿namespace Vendeghaz
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox_Main = new System.Windows.Forms.GroupBox();
            this.checkBox_MainServices = new System.Windows.Forms.CheckBox();
            this.button_Main = new System.Windows.Forms.Button();
            this.checkBox_MainTickets = new System.Windows.Forms.CheckBox();
            this.checkBox_MainAdoption = new System.Windows.Forms.CheckBox();
            this.checkBox_MainChoice = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Main
            // 
            this.groupBox_Main.BackgroundImage = global::Vendeghaz.Properties.Resources.Háttér;
            this.groupBox_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox_Main.Controls.Add(this.checkBox_MainServices);
            this.groupBox_Main.Controls.Add(this.button_Main);
            this.groupBox_Main.Controls.Add(this.checkBox_MainTickets);
            this.groupBox_Main.Controls.Add(this.checkBox_MainAdoption);
            this.groupBox_Main.Controls.Add(this.checkBox_MainChoice);
            this.groupBox_Main.Location = new System.Drawing.Point(94, 64);
            this.groupBox_Main.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox_Main.Name = "groupBox_Main";
            this.groupBox_Main.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox_Main.Size = new System.Drawing.Size(292, 251);
            this.groupBox_Main.TabIndex = 6;
            this.groupBox_Main.TabStop = false;
            this.groupBox_Main.Text = "Kérem válasszon!";
            // 
            // checkBox_MainServices
            // 
            this.checkBox_MainServices.AutoSize = true;
            this.checkBox_MainServices.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkBox_MainServices.Location = new System.Drawing.Point(75, 155);
            this.checkBox_MainServices.Name = "checkBox_MainServices";
            this.checkBox_MainServices.Size = new System.Drawing.Size(88, 30);
            this.checkBox_MainServices.TabIndex = 4;
            this.checkBox_MainServices.Text = "Szervíz";
            this.checkBox_MainServices.UseVisualStyleBackColor = false;
            // 
            // button_Main
            // 
            this.button_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button_Main.Location = new System.Drawing.Point(120, 195);
            this.button_Main.Name = "button_Main";
            this.button_Main.Size = new System.Drawing.Size(154, 35);
            this.button_Main.TabIndex = 5;
            this.button_Main.Text = "Választ";
            this.button_Main.UseVisualStyleBackColor = false;
            this.button_Main.Click += new System.EventHandler(this.button_Main_Click);
            // 
            // checkBox_MainTickets
            // 
            this.checkBox_MainTickets.AutoSize = true;
            this.checkBox_MainTickets.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkBox_MainTickets.Location = new System.Drawing.Point(75, 115);
            this.checkBox_MainTickets.Name = "checkBox_MainTickets";
            this.checkBox_MainTickets.Size = new System.Drawing.Size(131, 30);
            this.checkBox_MainTickets.TabIndex = 3;
            this.checkBox_MainTickets.Text = "Jegyrendelés";
            this.checkBox_MainTickets.UseVisualStyleBackColor = false;
            // 
            // checkBox_MainAdoption
            // 
            this.checkBox_MainAdoption.AutoSize = true;
            this.checkBox_MainAdoption.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkBox_MainAdoption.Location = new System.Drawing.Point(75, 75);
            this.checkBox_MainAdoption.Name = "checkBox_MainAdoption";
            this.checkBox_MainAdoption.Size = new System.Drawing.Size(145, 30);
            this.checkBox_MainAdoption.TabIndex = 2;
            this.checkBox_MainAdoption.Text = "Örökbefogadás";
            this.checkBox_MainAdoption.UseVisualStyleBackColor = false;
            // 
            // checkBox_MainChoice
            // 
            this.checkBox_MainChoice.AutoSize = true;
            this.checkBox_MainChoice.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkBox_MainChoice.Location = new System.Drawing.Point(75, 35);
            this.checkBox_MainChoice.Name = "checkBox_MainChoice";
            this.checkBox_MainChoice.Size = new System.Drawing.Size(121, 30);
            this.checkBox_MainChoice.TabIndex = 1;
            this.checkBox_MainChoice.Text = "Vendégeink";
            this.checkBox_MainChoice.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Vendeghaz.Properties.Resources.rajzkacsak;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(94, 356);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 171);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vendeghaz.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(474, 558);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox_Main);
            this.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(60, 30);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Vendégház Vadaspark";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox_Main.ResumeLayout(false);
            this.groupBox_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Main;
        private System.Windows.Forms.CheckBox checkBox_MainTickets;
        private System.Windows.Forms.CheckBox checkBox_MainAdoption;
        private System.Windows.Forms.CheckBox checkBox_MainChoice;
        private System.Windows.Forms.Button button_Main;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox_MainServices;
    }
}