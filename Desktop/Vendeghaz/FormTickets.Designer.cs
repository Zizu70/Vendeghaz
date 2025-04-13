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
            this.textBox_TicketName = new System.Windows.Forms.TextBox();
            this.button_TicketInsert = new System.Windows.Forms.Button();
            this.button_TicketUpdate = new System.Windows.Forms.Button();
            this.button_TicketDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_TicketDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_TicketTime = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_TicketEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_TicketPiece = new System.Windows.Forms.TextBox();
            this.textBox_TicketAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_TicketId = new System.Windows.Forms.ComboBox();
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
            // textBox_TicketName
            // 
            this.textBox_TicketName.Location = new System.Drawing.Point(110, 158);
            this.textBox_TicketName.Name = "textBox_TicketName";
            this.textBox_TicketName.Size = new System.Drawing.Size(361, 34);
            this.textBox_TicketName.TabIndex = 5;
            // 
            // button_TicketInsert
            // 
            this.button_TicketInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(225)))));
            this.button_TicketInsert.Location = new System.Drawing.Point(23, 497);
            this.button_TicketInsert.Name = "button_TicketInsert";
            this.button_TicketInsert.Size = new System.Drawing.Size(152, 44);
            this.button_TicketInsert.TabIndex = 14;
            this.button_TicketInsert.Text = "Felvitel";
            this.button_TicketInsert.UseVisualStyleBackColor = false;
            this.button_TicketInsert.Click += new System.EventHandler(this.button_TicketInsert_Click);
            // 
            // button_TicketUpdate
            // 
            this.button_TicketUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(165)))), ((int)(((byte)(240)))));
            this.button_TicketUpdate.Location = new System.Drawing.Point(196, 497);
            this.button_TicketUpdate.Name = "button_TicketUpdate";
            this.button_TicketUpdate.Size = new System.Drawing.Size(152, 44);
            this.button_TicketUpdate.TabIndex = 4;
            this.button_TicketUpdate.Text = "Módosítás";
            this.button_TicketUpdate.UseVisualStyleBackColor = false;
            this.button_TicketUpdate.Click += new System.EventHandler(this.button_TicketUpdate_Click);
            // 
            // button_TicketDelete
            // 
            this.button_TicketDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.button_TicketDelete.Location = new System.Drawing.Point(364, 497);
            this.button_TicketDelete.Name = "button_TicketDelete";
            this.button_TicketDelete.Size = new System.Drawing.Size(152, 44);
            this.button_TicketDelete.TabIndex = 3;
            this.button_TicketDelete.Text = "Törlés";
            this.button_TicketDelete.UseVisualStyleBackColor = false;
            this.button_TicketDelete.Click += new System.EventHandler(this.button_TicketDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Név";
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
            this.label3.Location = new System.Drawing.Point(125, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Óra";
            // 
            // dateTimePicker_TicketDate
            // 
            this.dateTimePicker_TicketDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_TicketDate.Location = new System.Drawing.Point(179, 269);
            this.dateTimePicker_TicketDate.Name = "dateTimePicker_TicketDate";
            this.dateTimePicker_TicketDate.Size = new System.Drawing.Size(164, 34);
            this.dateTimePicker_TicketDate.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 26);
            this.label4.TabIndex = 18;
            this.label4.Visible = false;
            // 
            // comboBox_TicketTime
            // 
            this.comboBox_TicketTime.FormattingEnabled = true;
            this.comboBox_TicketTime.Items.AddRange(new object[] {
            "de_9_óra",
            "de_10_óra",
            "de_11_óra",
            "de_12_óra",
            "du_13_óra",
            "du_14_óra",
            "du_15_óra",
            "du_16_óra"});
            this.comboBox_TicketTime.Location = new System.Drawing.Point(179, 324);
            this.comboBox_TicketTime.Name = "comboBox_TicketTime";
            this.comboBox_TicketTime.Size = new System.Drawing.Size(164, 34);
            this.comboBox_TicketTime.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 26);
            this.label8.TabIndex = 25;
            this.label8.Text = "Email cím";
            // 
            // textBox_TicketEmail
            // 
            this.textBox_TicketEmail.Location = new System.Drawing.Point(110, 214);
            this.textBox_TicketEmail.Name = "textBox_TicketEmail";
            this.textBox_TicketEmail.Size = new System.Drawing.Size(361, 34);
            this.textBox_TicketEmail.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(386, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 26);
            this.label5.TabIndex = 27;
            this.label5.Text = "HUF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(386, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 26);
            this.label6.TabIndex = 28;
            this.label6.Text = "darab";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(82, 444);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 26);
            this.label7.TabIndex = 29;
            this.label7.Text = "Fizetendő";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(49, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 26);
            this.label10.TabIndex = 30;
            this.label10.Text = "Jegyek száma";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(105, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 26);
            this.label12.TabIndex = 32;
            this.label12.Text = "Dátum";
            // 
            // textBox_TicketPiece
            // 
            this.textBox_TicketPiece.Location = new System.Drawing.Point(179, 378);
            this.textBox_TicketPiece.Name = "textBox_TicketPiece";
            this.textBox_TicketPiece.Size = new System.Drawing.Size(200, 34);
            this.textBox_TicketPiece.TabIndex = 33;
            this.textBox_TicketPiece.TextChanged += new System.EventHandler(this.textBox_TicketPiece_TextChanged);
            // 
            // textBox_TicketAmount
            // 
            this.textBox_TicketAmount.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_TicketAmount.Location = new System.Drawing.Point(179, 436);
            this.textBox_TicketAmount.Name = "textBox_TicketAmount";
            this.textBox_TicketAmount.ReadOnly = true;
            this.textBox_TicketAmount.Size = new System.Drawing.Size(200, 39);
            this.textBox_TicketAmount.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 26);
            this.label9.TabIndex = 36;
            this.label9.Text = "Id";
            // 
            // comboBox_TicketId
            // 
            this.comboBox_TicketId.FormattingEnabled = true;
            this.comboBox_TicketId.Location = new System.Drawing.Point(110, 104);
            this.comboBox_TicketId.Name = "comboBox_TicketId";
            this.comboBox_TicketId.Size = new System.Drawing.Size(104, 34);
            this.comboBox_TicketId.TabIndex = 37;
            this.comboBox_TicketId.SelectedIndexChanged += new System.EventHandler(this.comboBox_TicketId_SelectedIndexChanged);
            // 
            // FormTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vendeghaz.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(559, 559);
            this.Controls.Add(this.comboBox_TicketId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_TicketAmount);
            this.Controls.Add(this.textBox_TicketPiece);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_TicketEmail);
            this.Controls.Add(this.comboBox_TicketTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker_TicketDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_TicketDelete);
            this.Controls.Add(this.button_TicketUpdate);
            this.Controls.Add(this.button_TicketInsert);
            this.Controls.Add(this.textBox_TicketName);
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
        private System.Windows.Forms.TextBox textBox_TicketName;
        private System.Windows.Forms.Button button_TicketInsert;
        private System.Windows.Forms.Button button_TicketUpdate;
        private System.Windows.Forms.Button button_TicketDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TicketDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_TicketTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_TicketEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_TicketPiece;
        private System.Windows.Forms.TextBox textBox_TicketAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_TicketId;
    }
}