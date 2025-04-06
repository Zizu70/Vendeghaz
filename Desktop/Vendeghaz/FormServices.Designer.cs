namespace Vendeghaz
{
    partial class FormServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServices));
            this.button_ServicesEntry = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox_ServicesRole = new System.Windows.Forms.ComboBox();
            this.textBox_ServicesName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ServicesPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_ServicesInsert = new System.Windows.Forms.Button();
            this.button_ServicesUpdate = new System.Windows.Forms.Button();
            this.button_ServicesDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ServicesEntry
            // 
            this.button_ServicesEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_ServicesEntry.Location = new System.Drawing.Point(227, 269);
            this.button_ServicesEntry.Name = "button_ServicesEntry";
            this.button_ServicesEntry.Size = new System.Drawing.Size(200, 30);
            this.button_ServicesEntry.TabIndex = 2;
            this.button_ServicesEntry.Text = "Szervíz belépés";
            this.button_ServicesEntry.UseVisualStyleBackColor = false;
            this.button_ServicesEntry.Click += new System.EventHandler(this.button_ServicesEntry_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::Vendeghaz.Properties.Resources.logoatlatszo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 125);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox_ServicesRole
            // 
            this.comboBox_ServicesRole.FormattingEnabled = true;
            this.comboBox_ServicesRole.Location = new System.Drawing.Point(227, 220);
            this.comboBox_ServicesRole.Name = "comboBox_ServicesRole";
            this.comboBox_ServicesRole.Size = new System.Drawing.Size(200, 31);
            this.comboBox_ServicesRole.TabIndex = 4;
            // 
            // textBox_ServicesName
            // 
            this.textBox_ServicesName.Location = new System.Drawing.Point(227, 129);
            this.textBox_ServicesName.Name = "textBox_ServicesName";
            this.textBox_ServicesName.Size = new System.Drawing.Size(200, 30);
            this.textBox_ServicesName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(185, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Név";
            // 
            // textBox_ServicesPass
            // 
            this.textBox_ServicesPass.Location = new System.Drawing.Point(227, 172);
            this.textBox_ServicesPass.Name = "textBox_ServicesPass";
            this.textBox_ServicesPass.Size = new System.Drawing.Size(200, 30);
            this.textBox_ServicesPass.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(170, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Jelszó";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(137, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Jogosultság";
            // 
            // button_ServicesInsert
            // 
            this.button_ServicesInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(225)))));
            this.button_ServicesInsert.Location = new System.Drawing.Point(189, 315);
            this.button_ServicesInsert.Name = "button_ServicesInsert";
            this.button_ServicesInsert.Size = new System.Drawing.Size(85, 35);
            this.button_ServicesInsert.TabIndex = 10;
            this.button_ServicesInsert.Text = "Felvitel";
            this.button_ServicesInsert.UseVisualStyleBackColor = false;
            this.button_ServicesInsert.Click += new System.EventHandler(this.button_ServicesInsert_Click);
            // 
            // button_ServicesUpdate
            // 
            this.button_ServicesUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(165)))), ((int)(((byte)(240)))));
            this.button_ServicesUpdate.Location = new System.Drawing.Point(280, 315);
            this.button_ServicesUpdate.Name = "button_ServicesUpdate";
            this.button_ServicesUpdate.Size = new System.Drawing.Size(85, 35);
            this.button_ServicesUpdate.TabIndex = 11;
            this.button_ServicesUpdate.Text = "Módosítás";
            this.button_ServicesUpdate.UseVisualStyleBackColor = false;
            this.button_ServicesUpdate.Click += new System.EventHandler(this.button_ServicesUpdate_Click);
            // 
            // button_ServicesDelete
            // 
            this.button_ServicesDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.button_ServicesDelete.Location = new System.Drawing.Point(371, 315);
            this.button_ServicesDelete.Name = "button_ServicesDelete";
            this.button_ServicesDelete.Size = new System.Drawing.Size(85, 35);
            this.button_ServicesDelete.TabIndex = 12;
            this.button_ServicesDelete.Text = "Törlés";
            this.button_ServicesDelete.UseVisualStyleBackColor = false;
            this.button_ServicesDelete.Click += new System.EventHandler(this.button_ServicesDelete_Click);
            // 
            // FormServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vendeghaz.Properties.Resources.Login___out;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(638, 544);
            this.Controls.Add(this.button_ServicesDelete);
            this.Controls.Add(this.button_ServicesUpdate);
            this.Controls.Add(this.button_ServicesInsert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_ServicesPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_ServicesName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_ServicesRole);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_ServicesEntry);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormServices";
            this.Text = "Vendégház Vadaspark";
            this.Load += new System.EventHandler(this.FormServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_ServicesEntry;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox_ServicesRole;
        private System.Windows.Forms.TextBox textBox_ServicesName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ServicesPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_ServicesInsert;
        private System.Windows.Forms.Button button_ServicesUpdate;
        private System.Windows.Forms.Button button_ServicesDelete;
    }
}