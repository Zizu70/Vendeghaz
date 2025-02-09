namespace Vendeghaz
{
    partial class FormGuest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGuest));
            this.textBox_GuestName = new System.Windows.Forms.TextBox();
            this.textBox_GuestWhere = new System.Windows.Forms.TextBox();
            this.textBox_GuestChip = new System.Windows.Forms.TextBox();
            this.richTextBox_GuestOther = new System.Windows.Forms.RichTextBox();
            this.pictureBox_GuestImage = new System.Windows.Forms.PictureBox();
            this.comboBox_GuestSpecies = new System.Windows.Forms.ComboBox();
            this.comboBox_GuestGender = new System.Windows.Forms.ComboBox();
            this.comboBox_GuestAdoption = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_GuestIn = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_GuestOut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_GuestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_GuestName
            // 
            this.textBox_GuestName.Location = new System.Drawing.Point(155, 143);
            this.textBox_GuestName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_GuestName.Name = "textBox_GuestName";
            this.textBox_GuestName.Size = new System.Drawing.Size(125, 30);
            this.textBox_GuestName.TabIndex = 2;
            // 
            // textBox_GuestWhere
            // 
            this.textBox_GuestWhere.Location = new System.Drawing.Point(212, 337);
            this.textBox_GuestWhere.Name = "textBox_GuestWhere";
            this.textBox_GuestWhere.Size = new System.Drawing.Size(316, 30);
            this.textBox_GuestWhere.TabIndex = 21;
            // 
            // textBox_GuestChip
            // 
            this.textBox_GuestChip.Location = new System.Drawing.Point(398, 248);
            this.textBox_GuestChip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_GuestChip.Name = "textBox_GuestChip";
            this.textBox_GuestChip.Size = new System.Drawing.Size(150, 30);
            this.textBox_GuestChip.TabIndex = 18;
            // 
            // richTextBox_GuestOther
            // 
            this.richTextBox_GuestOther.Location = new System.Drawing.Point(118, 421);
            this.richTextBox_GuestOther.Name = "richTextBox_GuestOther";
            this.richTextBox_GuestOther.Size = new System.Drawing.Size(504, 183);
            this.richTextBox_GuestOther.TabIndex = 27;
            this.richTextBox_GuestOther.Text = "";
            // 
            // pictureBox_GuestImage
            // 
            this.pictureBox_GuestImage.BackgroundImage = global::Vendeghaz.Properties.Resources.DefaultImage;
            this.pictureBox_GuestImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_GuestImage.Location = new System.Drawing.Point(306, 46);
            this.pictureBox_GuestImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox_GuestImage.Name = "pictureBox_GuestImage";
            this.pictureBox_GuestImage.Size = new System.Drawing.Size(135, 135);
            this.pictureBox_GuestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_GuestImage.TabIndex = 28;
            this.pictureBox_GuestImage.TabStop = false;
            // 
            // comboBox_GuestSpecies
            // 
            this.comboBox_GuestSpecies.FormattingEnabled = true;
            this.comboBox_GuestSpecies.Items.AddRange(new object[] {
            "kutya",
            "macska"});
            this.comboBox_GuestSpecies.Location = new System.Drawing.Point(35, 247);
            this.comboBox_GuestSpecies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_GuestSpecies.Name = "comboBox_GuestSpecies";
            this.comboBox_GuestSpecies.Size = new System.Drawing.Size(144, 31);
            this.comboBox_GuestSpecies.TabIndex = 14;
            // 
            // comboBox_GuestGender
            // 
            this.comboBox_GuestGender.FormattingEnabled = true;
            this.comboBox_GuestGender.Items.AddRange(new object[] {
            "hím",
            "nőstény",
            "ivartalan"});
            this.comboBox_GuestGender.Location = new System.Drawing.Point(207, 247);
            this.comboBox_GuestGender.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_GuestGender.Name = "comboBox_GuestGender";
            this.comboBox_GuestGender.Size = new System.Drawing.Size(150, 31);
            this.comboBox_GuestGender.TabIndex = 15;
            // 
            // comboBox_GuestAdoption
            // 
            this.comboBox_GuestAdoption.FormattingEnabled = true;
            this.comboBox_GuestAdoption.Items.AddRange(new object[] {
            "igen",
            "nem"});
            this.comboBox_GuestAdoption.Location = new System.Drawing.Point(564, 247);
            this.comboBox_GuestAdoption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_GuestAdoption.Name = "comboBox_GuestAdoption";
            this.comboBox_GuestAdoption.Size = new System.Drawing.Size(150, 31);
            this.comboBox_GuestAdoption.TabIndex = 16;
            // 
            // dateTimePicker_GuestIn
            // 
            this.dateTimePicker_GuestIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_GuestIn.Location = new System.Drawing.Point(35, 338);
            this.dateTimePicker_GuestIn.Name = "dateTimePicker_GuestIn";
            this.dateTimePicker_GuestIn.Size = new System.Drawing.Size(150, 30);
            this.dateTimePicker_GuestIn.TabIndex = 19;
            // 
            // dateTimePicker_GuestOut
            // 
            this.dateTimePicker_GuestOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_GuestOut.Location = new System.Drawing.Point(564, 334);
            this.dateTimePicker_GuestOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_GuestOut.Name = "dateTimePicker_GuestOut";
            this.dateTimePicker_GuestOut.Size = new System.Drawing.Size(150, 30);
            this.dateTimePicker_GuestOut.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label1.Location = new System.Drawing.Point(468, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "adatlapja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label2.Location = new System.Drawing.Point(31, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Faja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Neme";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label4.Location = new System.Drawing.Point(394, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Chipszáma";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label5.Location = new System.Drawing.Point(560, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Örökbeadhatóság";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label6.Location = new System.Drawing.Point(31, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Érkezés";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label7.Location = new System.Drawing.Point(208, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Honnan érkezett";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label8.Location = new System.Drawing.Point(560, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Távozás";
            // 
            // FormGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vendeghaz.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(755, 651);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_GuestOut);
            this.Controls.Add(this.dateTimePicker_GuestIn);
            this.Controls.Add(this.comboBox_GuestAdoption);
            this.Controls.Add(this.comboBox_GuestGender);
            this.Controls.Add(this.comboBox_GuestSpecies);
            this.Controls.Add(this.pictureBox_GuestImage);
            this.Controls.Add(this.richTextBox_GuestOther);
            this.Controls.Add(this.textBox_GuestChip);
            this.Controls.Add(this.textBox_GuestWhere);
            this.Controls.Add(this.textBox_GuestName);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGuest";
            this.Text = "Vendégház Menedék";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_GuestImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_GuestName;
        private System.Windows.Forms.TextBox textBox_GuestWhere;
        private System.Windows.Forms.TextBox textBox_GuestChip;
        private System.Windows.Forms.RichTextBox richTextBox_GuestOther;
        private System.Windows.Forms.PictureBox pictureBox_GuestImage;
        private System.Windows.Forms.ComboBox comboBox_GuestSpecies;
        private System.Windows.Forms.ComboBox comboBox_GuestGender;
        private System.Windows.Forms.ComboBox comboBox_GuestAdoption;
        private System.Windows.Forms.DateTimePicker dateTimePicker_GuestIn;
        private System.Windows.Forms.DateTimePicker dateTimePicker_GuestOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}