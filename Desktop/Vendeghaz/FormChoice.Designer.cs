namespace Vendeghaz
{
    partial class FormChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChoice));
            this.button_ChoiceInsert = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_Choice = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBox_ChoiceLarge = new System.Windows.Forms.CheckBox();
            this.button_ChoiceChoice = new System.Windows.Forms.Button();
            this.checkBox_ChoiceSmall = new System.Windows.Forms.CheckBox();
            this.checkBox_ChoiceStroking = new System.Windows.Forms.CheckBox();
            this.checkBox_ChoiceYard = new System.Windows.Forms.CheckBox();
            this.checkBox_ChoiceBird = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_ChoicePick = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ChoiceInsert
            // 
            this.button_ChoiceInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(225)))));
            this.button_ChoiceInsert.Location = new System.Drawing.Point(207, 76);
            this.button_ChoiceInsert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ChoiceInsert.Name = "button_ChoiceInsert";
            this.button_ChoiceInsert.Size = new System.Drawing.Size(94, 41);
            this.button_ChoiceInsert.TabIndex = 1;
            this.button_ChoiceInsert.Text = "Felvitel";
            this.button_ChoiceInsert.UseVisualStyleBackColor = false;
            this.button_ChoiceInsert.Click += new System.EventHandler(this.button_ChoiceInsert_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Vendeghaz.Properties.Resources.rajzhattyu;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(339, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 126);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Új vendég felvitele:";
            // 
            // listView_Choice
            // 
            this.listView_Choice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_Choice.HideSelection = false;
            this.listView_Choice.Location = new System.Drawing.Point(339, 176);
            this.listView_Choice.Name = "listView_Choice";
            this.listView_Choice.Size = new System.Drawing.Size(220, 264);
            this.listView_Choice.TabIndex = 7;
            this.listView_Choice.UseCompatibleStateImageBehavior = false;
            this.listView_Choice.View = System.Windows.Forms.View.Details;
            this.listView_Choice.SelectedIndexChanged += new System.EventHandler(this.listView_Choice_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Név";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Faj";
            this.columnHeader3.Width = 90;
            // 
            // checkBox_ChoiceLarge
            // 
            this.checkBox_ChoiceLarge.AutoSize = true;
            this.checkBox_ChoiceLarge.Location = new System.Drawing.Point(16, 33);
            this.checkBox_ChoiceLarge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_ChoiceLarge.Name = "checkBox_ChoiceLarge";
            this.checkBox_ChoiceLarge.Size = new System.Drawing.Size(104, 27);
            this.checkBox_ChoiceLarge.TabIndex = 5;
            this.checkBox_ChoiceLarge.Text = "nagyvadak";
            this.checkBox_ChoiceLarge.UseVisualStyleBackColor = true;
            // 
            // button_ChoiceChoice
            // 
            this.button_ChoiceChoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_ChoiceChoice.Location = new System.Drawing.Point(313, 332);
            this.button_ChoiceChoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ChoiceChoice.Name = "button_ChoiceChoice";
            this.button_ChoiceChoice.Size = new System.Drawing.Size(94, 41);
            this.button_ChoiceChoice.TabIndex = 7;
            this.button_ChoiceChoice.Text = "Választás";
            this.button_ChoiceChoice.UseVisualStyleBackColor = false;
            // 
            // checkBox_ChoiceSmall
            // 
            this.checkBox_ChoiceSmall.AutoSize = true;
            this.checkBox_ChoiceSmall.Location = new System.Drawing.Point(16, 63);
            this.checkBox_ChoiceSmall.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_ChoiceSmall.Name = "checkBox_ChoiceSmall";
            this.checkBox_ChoiceSmall.Size = new System.Drawing.Size(102, 27);
            this.checkBox_ChoiceSmall.TabIndex = 6;
            this.checkBox_ChoiceSmall.Text = "apróvadak";
            this.checkBox_ChoiceSmall.UseVisualStyleBackColor = true;
            // 
            // checkBox_ChoiceStroking
            // 
            this.checkBox_ChoiceStroking.AutoSize = true;
            this.checkBox_ChoiceStroking.Location = new System.Drawing.Point(16, 139);
            this.checkBox_ChoiceStroking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_ChoiceStroking.Name = "checkBox_ChoiceStroking";
            this.checkBox_ChoiceStroking.Size = new System.Drawing.Size(90, 27);
            this.checkBox_ChoiceStroking.TabIndex = 8;
            this.checkBox_ChoiceStroking.Text = "simogató";
            this.checkBox_ChoiceStroking.UseVisualStyleBackColor = true;
            // 
            // checkBox_ChoiceYard
            // 
            this.checkBox_ChoiceYard.AutoSize = true;
            this.checkBox_ChoiceYard.Location = new System.Drawing.Point(16, 113);
            this.checkBox_ChoiceYard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_ChoiceYard.Name = "checkBox_ChoiceYard";
            this.checkBox_ChoiceYard.Size = new System.Drawing.Size(126, 27);
            this.checkBox_ChoiceYard.TabIndex = 10;
            this.checkBox_ChoiceYard.Text = "paraszt udvar";
            this.checkBox_ChoiceYard.UseVisualStyleBackColor = true;
            // 
            // checkBox_ChoiceBird
            // 
            this.checkBox_ChoiceBird.AutoSize = true;
            this.checkBox_ChoiceBird.Location = new System.Drawing.Point(16, 88);
            this.checkBox_ChoiceBird.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_ChoiceBird.Name = "checkBox_ChoiceBird";
            this.checkBox_ChoiceBird.Size = new System.Drawing.Size(93, 27);
            this.checkBox_ChoiceBird.TabIndex = 12;
            this.checkBox_ChoiceBird.Text = "madarak";
            this.checkBox_ChoiceBird.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ChoicePick);
            this.groupBox1.Controls.Add(this.checkBox_ChoiceBird);
            this.groupBox1.Controls.Add(this.checkBox_ChoiceYard);
            this.groupBox1.Controls.Add(this.checkBox_ChoiceStroking);
            this.groupBox1.Controls.Add(this.checkBox_ChoiceSmall);
            this.groupBox1.Controls.Add(this.button_ChoiceChoice);
            this.groupBox1.Controls.Add(this.checkBox_ChoiceLarge);
            this.groupBox1.Location = new System.Drawing.Point(36, 204);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(284, 201);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Válasszon csoportot!";
            // 
            // button_ChoicePick
            // 
            this.button_ChoicePick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_ChoicePick.Location = new System.Drawing.Point(171, 80);
            this.button_ChoicePick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ChoicePick.Name = "button_ChoicePick";
            this.button_ChoicePick.Size = new System.Drawing.Size(94, 41);
            this.button_ChoicePick.TabIndex = 13;
            this.button_ChoicePick.Text = "Választás";
            this.button_ChoicePick.UseVisualStyleBackColor = false;
            this.button_ChoicePick.Click += new System.EventHandler(this.button_ChoicePick_Click);
            // 
            // FormChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vendeghaz.Properties.Resources.Háttér;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(606, 464);
            this.Controls.Add(this.listView_Choice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_ChoiceInsert);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe Print", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormChoice";
            this.Text = "Vendégház Vadaspark";
            this.Load += new System.EventHandler(this.FormChoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_ChoiceInsert;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_Choice;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox checkBox_ChoiceLarge;
        private System.Windows.Forms.Button button_ChoiceChoice;
        private System.Windows.Forms.CheckBox checkBox_ChoiceSmall;
        private System.Windows.Forms.CheckBox checkBox_ChoiceStroking;
        private System.Windows.Forms.CheckBox checkBox_ChoiceYard;
        private System.Windows.Forms.CheckBox checkBox_ChoiceBird;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_ChoicePick;
    }
}