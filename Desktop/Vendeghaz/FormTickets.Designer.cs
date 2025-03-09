namespace Vendeghaz
{
    partial class FormTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTickets));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_ChipNumber = new System.Windows.Forms.TextBox();
            this.textBoxChipName = new System.Windows.Forms.TextBox();
            this.button_TicketUpdate = new System.Windows.Forms.Button();
            this.button_ChipControl = new System.Windows.Forms.Button();
            this.button_TicketDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_ChipSpecies = new System.Windows.Forms.Label();
            this.label_ChipOther = new System.Windows.Forms.Label();
            this.label_ChipName = new System.Windows.Forms.Label();
            this.dateTimePicker_TicketDate = new System.Windows.Forms.DateTimePicker();
            this.textBox_TicketPieces = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_TicketTime = new System.Windows.Forms.ComboBox();
            this.comboBox_TicketType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Vendeghaz.Properties.Resources.rajzfarkas;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(279, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 127);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_ChipNumber
            // 
            this.textBox_ChipNumber.Location = new System.Drawing.Point(162, 215);
            this.textBox_ChipNumber.Name = "textBox_ChipNumber";
            this.textBox_ChipNumber.Size = new System.Drawing.Size(262, 34);
            this.textBox_ChipNumber.TabIndex = 5;
            // 
            // textBoxChipName
            // 
            this.textBoxChipName.Location = new System.Drawing.Point(162, 160);
            this.textBoxChipName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxChipName.Name = "textBoxChipName";
            this.textBoxChipName.ReadOnly = true;
            this.textBoxChipName.Size = new System.Drawing.Size(201, 34);
            this.textBoxChipName.TabIndex = 1;
            this.textBoxChipName.Visible = false;
            // 
            // button_TicketUpdate
            // 
            this.button_TicketUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_TicketUpdate.Location = new System.Drawing.Point(30, 517);
            this.button_TicketUpdate.Name = "button_TicketUpdate";
            this.button_TicketUpdate.Size = new System.Drawing.Size(152, 44);
            this.button_TicketUpdate.TabIndex = 14;
            this.button_TicketUpdate.Text = "Új lekérdezés";
            this.button_TicketUpdate.UseVisualStyleBackColor = false;
            // 
            // button_ChipControl
            // 
            this.button_ChipControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(165)))), ((int)(((byte)(240)))));
            this.button_ChipControl.Location = new System.Drawing.Point(203, 517);
            this.button_ChipControl.Name = "button_ChipControl";
            this.button_ChipControl.Size = new System.Drawing.Size(152, 44);
            this.button_ChipControl.TabIndex = 4;
            this.button_ChipControl.Text = "Módosítás";
            this.button_ChipControl.UseVisualStyleBackColor = false;
            // 
            // button_TicketDelete
            // 
            this.button_TicketDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.button_TicketDelete.Location = new System.Drawing.Point(371, 517);
            this.button_TicketDelete.Name = "button_TicketDelete";
            this.button_TicketDelete.Size = new System.Drawing.Size(152, 44);
            this.button_TicketDelete.TabIndex = 3;
            this.button_TicketDelete.Text = "Törlés";
            this.button_TicketDelete.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Email cím";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(52, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Jegyrendelés";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(108, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Óra";
            // 
            // label_ChipSpecies
            // 
            this.label_ChipSpecies.AutoSize = true;
            this.label_ChipSpecies.Location = new System.Drawing.Point(34, 436);
            this.label_ChipSpecies.Name = "label_ChipSpecies";
            this.label_ChipSpecies.Size = new System.Drawing.Size(115, 26);
            this.label_ChipSpecies.TabIndex = 13;
            this.label_ChipSpecies.Text = "Jegyek típusa";
            this.label_ChipSpecies.Visible = false;
            // 
            // label_ChipOther
            // 
            this.label_ChipOther.AutoSize = true;
            this.label_ChipOther.Location = new System.Drawing.Point(88, 276);
            this.label_ChipOther.Name = "label_ChipOther";
            this.label_ChipOther.Size = new System.Drawing.Size(64, 26);
            this.label_ChipOther.TabIndex = 9;
            this.label_ChipOther.Text = "Dátum";
            this.label_ChipOther.Visible = false;
            // 
            // label_ChipName
            // 
            this.label_ChipName.AutoSize = true;
            this.label_ChipName.Location = new System.Drawing.Point(127, 167);
            this.label_ChipName.Name = "label_ChipName";
            this.label_ChipName.Size = new System.Drawing.Size(27, 26);
            this.label_ChipName.TabIndex = 2;
            this.label_ChipName.Text = "Id";
            this.label_ChipName.Visible = false;
            // 
            // dateTimePicker_TicketDate
            // 
            this.dateTimePicker_TicketDate.Location = new System.Drawing.Point(162, 268);
            this.dateTimePicker_TicketDate.Name = "dateTimePicker_TicketDate";
            this.dateTimePicker_TicketDate.Size = new System.Drawing.Size(200, 34);
            this.dateTimePicker_TicketDate.TabIndex = 15;
            // 
            // textBox_TicketPieces
            // 
            this.textBox_TicketPieces.Location = new System.Drawing.Point(162, 375);
            this.textBox_TicketPieces.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_TicketPieces.Name = "textBox_TicketPieces";
            this.textBox_TicketPieces.Size = new System.Drawing.Size(201, 34);
            this.textBox_TicketPieces.TabIndex = 16;
            this.textBox_TicketPieces.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 26);
            this.label4.TabIndex = 18;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 26);
            this.label5.TabIndex = 19;
            this.label5.Text = "Jegyek száma";
            this.label5.Visible = false;
            // 
            // comboBox_TicketTime
            // 
            this.comboBox_TicketTime.FormattingEnabled = true;
            this.comboBox_TicketTime.Location = new System.Drawing.Point(162, 321);
            this.comboBox_TicketTime.Name = "comboBox_TicketTime";
            this.comboBox_TicketTime.Size = new System.Drawing.Size(200, 34);
            this.comboBox_TicketTime.TabIndex = 20;
            // 
            // comboBox_TicketType
            // 
            this.comboBox_TicketType.FormattingEnabled = true;
            this.comboBox_TicketType.Location = new System.Drawing.Point(161, 428);
            this.comboBox_TicketType.Name = "comboBox_TicketType";
            this.comboBox_TicketType.Size = new System.Drawing.Size(200, 34);
            this.comboBox_TicketType.TabIndex = 21;
            // 
            // FormTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vendeghaz.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(559, 599);
            this.Controls.Add(this.comboBox_TicketType);
            this.Controls.Add(this.comboBox_TicketTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_TicketPieces);
            this.Controls.Add(this.dateTimePicker_TicketDate);
            this.Controls.Add(this.label_ChipOther);
            this.Controls.Add(this.label_ChipSpecies);
            this.Controls.Add(this.label_ChipName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_TicketDelete);
            this.Controls.Add(this.button_ChipControl);
            this.Controls.Add(this.button_TicketUpdate);
            this.Controls.Add(this.textBoxChipName);
            this.Controls.Add(this.textBox_ChipNumber);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTickets";
            this.Text = "Vendégház Vadaspark";
            this.Load += new System.EventHandler(this.FormTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_ChipNumber;
        private System.Windows.Forms.TextBox textBoxChipName;
        private System.Windows.Forms.Button button_TicketUpdate;
        private System.Windows.Forms.Button button_ChipControl;
        private System.Windows.Forms.Button button_TicketDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_ChipSpecies;
        private System.Windows.Forms.Label label_ChipOther;
        private System.Windows.Forms.Label label_ChipName;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TicketDate;
        private System.Windows.Forms.TextBox textBox_TicketPieces;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_TicketTime;
        private System.Windows.Forms.ComboBox comboBox_TicketType;
    }
}