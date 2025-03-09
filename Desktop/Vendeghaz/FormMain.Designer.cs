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
            this.button_Main = new System.Windows.Forms.Button();
            this.checkBox_MainChip = new System.Windows.Forms.CheckBox();
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
            this.groupBox_Main.Controls.Add(this.button_Main);
            this.groupBox_Main.Controls.Add(this.checkBox_MainChip);
            this.groupBox_Main.Controls.Add(this.checkBox_MainAdoption);
            this.groupBox_Main.Controls.Add(this.checkBox_MainChoice);
            this.groupBox_Main.Location = new System.Drawing.Point(88, 64);
            this.groupBox_Main.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox_Main.Name = "groupBox_Main";
            this.groupBox_Main.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox_Main.Size = new System.Drawing.Size(393, 269);
            this.groupBox_Main.TabIndex = 0;
            this.groupBox_Main.TabStop = false;
            this.groupBox_Main.Text = "Kérem válasszon!";
            // 
            // button_Main
            // 
            this.button_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button_Main.Location = new System.Drawing.Point(218, 212);
            this.button_Main.Name = "button_Main";
            this.button_Main.Size = new System.Drawing.Size(154, 35);
            this.button_Main.TabIndex = 4;
            this.button_Main.Text = "Választ";
            this.button_Main.UseVisualStyleBackColor = false;
            // 
            // checkBox_MainChip
            // 
            this.checkBox_MainChip.AutoSize = true;
            this.checkBox_MainChip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkBox_MainChip.Location = new System.Drawing.Point(98, 126);
            this.checkBox_MainChip.Name = "checkBox_MainChip";
            this.checkBox_MainChip.Size = new System.Drawing.Size(188, 30);
            this.checkBox_MainChip.TabIndex = 2;
            this.checkBox_MainChip.Text = "Chip alapján keresés";
            this.checkBox_MainChip.UseVisualStyleBackColor = false;
            // 
            // checkBox_MainAdoption
            // 
            this.checkBox_MainAdoption.AutoSize = true;
            this.checkBox_MainAdoption.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkBox_MainAdoption.Location = new System.Drawing.Point(98, 80);
            this.checkBox_MainAdoption.Name = "checkBox_MainAdoption";
            this.checkBox_MainAdoption.Size = new System.Drawing.Size(145, 30);
            this.checkBox_MainAdoption.TabIndex = 1;
            this.checkBox_MainAdoption.Text = "Örökbefogadás";
            this.checkBox_MainAdoption.UseVisualStyleBackColor = false;
            // 
            // checkBox_MainChoice
            // 
            this.checkBox_MainChoice.AutoSize = true;
            this.checkBox_MainChoice.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkBox_MainChoice.Location = new System.Drawing.Point(98, 39);
            this.checkBox_MainChoice.Name = "checkBox_MainChoice";
            this.checkBox_MainChoice.Size = new System.Drawing.Size(121, 30);
            this.checkBox_MainChoice.TabIndex = 0;
            this.checkBox_MainChoice.Text = "Vendégeink";
            this.checkBox_MainChoice.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Vendeghaz.Properties.Resources.rajzkacsak;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(144, 351);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 171);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vendeghaz.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(595, 583);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox_Main);
            this.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "Vendégház Vadaspark";
            this.groupBox_Main.ResumeLayout(false);
            this.groupBox_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Main;
        private System.Windows.Forms.CheckBox checkBox_MainChip;
        private System.Windows.Forms.CheckBox checkBox_MainAdoption;
        private System.Windows.Forms.CheckBox checkBox_MainChoice;
        private System.Windows.Forms.Button button_Main;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}