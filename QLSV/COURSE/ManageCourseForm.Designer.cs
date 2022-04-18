
namespace QLSV.COURSE
{
    partial class ManageCourseForm
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
            this.editButton = new System.Windows.Forms.Button();
            this.periodNumericUD = new System.Windows.Forms.NumericUpDown();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeEdit = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.firstButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.preButton = new System.Windows.Forms.Button();
            this.lastButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.totalCourseLabel = new System.Windows.Forms.Label();
            this.semesterComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbContact = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.periodNumericUD)).BeginInit();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.Gold;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.editButton.Location = new System.Drawing.Point(118, 347);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(95, 39);
            this.editButton.TabIndex = 18;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // periodNumericUD
            // 
            this.periodNumericUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.periodNumericUD.Location = new System.Drawing.Point(119, 112);
            this.periodNumericUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.periodNumericUD.Name = "periodNumericUD";
            this.periodNumericUD.Size = new System.Drawing.Size(120, 29);
            this.periodNumericUD.TabIndex = 17;
            this.periodNumericUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.descriptionTextBox.Location = new System.Drawing.Point(119, 198);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(170, 96);
            this.descriptionTextBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(11, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(50, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Period";
            // 
            // labelTextBox
            // 
            this.labelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTextBox.Location = new System.Drawing.Point(119, 67);
            this.labelTextBox.Name = "labelTextBox";
            this.labelTextBox.Size = new System.Drawing.Size(170, 29);
            this.labelTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(59, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Label";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Course ID";
            // 
            // idTextBox
            // 
            this.idTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.idTextBox.Location = new System.Drawing.Point(119, 24);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(170, 29);
            this.idTextBox.TabIndex = 21;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.addButton.Location = new System.Drawing.Point(17, 347);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(95, 39);
            this.addButton.TabIndex = 22;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeEdit
            // 
            this.removeEdit.BackColor = System.Drawing.Color.Red;
            this.removeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.removeEdit.Location = new System.Drawing.Point(219, 347);
            this.removeEdit.Name = "removeEdit";
            this.removeEdit.Size = new System.Drawing.Size(95, 39);
            this.removeEdit.TabIndex = 23;
            this.removeEdit.Text = "Remove";
            this.removeEdit.UseVisualStyleBackColor = false;
            this.removeEdit.Click += new System.EventHandler(this.removeEdit_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Aquamarine;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.resetButton.Location = new System.Drawing.Point(325, 347);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(95, 39);
            this.resetButton.TabIndex = 24;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // firstButton
            // 
            this.firstButton.BackColor = System.Drawing.Color.SpringGreen;
            this.firstButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.firstButton.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstButton.Location = new System.Drawing.Point(119, 299);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(40, 39);
            this.firstButton.TabIndex = 25;
            this.firstButton.Text = "<<";
            this.firstButton.UseVisualStyleBackColor = false;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.SpringGreen;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.nextButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nextButton.Location = new System.Drawing.Point(193, 299);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(20, 39);
            this.nextButton.TabIndex = 26;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // preButton
            // 
            this.preButton.BackColor = System.Drawing.Color.SpringGreen;
            this.preButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.preButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.preButton.Location = new System.Drawing.Point(167, 299);
            this.preButton.Name = "preButton";
            this.preButton.Size = new System.Drawing.Size(20, 39);
            this.preButton.TabIndex = 27;
            this.preButton.Text = "<";
            this.preButton.UseVisualStyleBackColor = false;
            this.preButton.Click += new System.EventHandler(this.preButton_Click);
            // 
            // lastButton
            // 
            this.lastButton.BackColor = System.Drawing.Color.SpringGreen;
            this.lastButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lastButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lastButton.Location = new System.Drawing.Point(219, 299);
            this.lastButton.Name = "lastButton";
            this.lastButton.Size = new System.Drawing.Size(40, 39);
            this.lastButton.TabIndex = 28;
            this.lastButton.Text = ">>";
            this.lastButton.UseVisualStyleBackColor = false;
            this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 24;
            this.listBox.Location = new System.Drawing.Point(320, 60);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(312, 268);
            this.listBox.TabIndex = 29;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // totalCourseLabel
            // 
            this.totalCourseLabel.AutoSize = true;
            this.totalCourseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.totalCourseLabel.Location = new System.Drawing.Point(445, 362);
            this.totalCourseLabel.Name = "totalCourseLabel";
            this.totalCourseLabel.Size = new System.Drawing.Size(122, 24);
            this.totalCourseLabel.TabIndex = 30;
            this.totalCourseLabel.Text = "Total Course:";
            // 
            // semesterComboBox
            // 
            this.semesterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterComboBox.FormattingEnabled = true;
            this.semesterComboBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.semesterComboBox.Location = new System.Drawing.Point(426, 19);
            this.semesterComboBox.Name = "semesterComboBox";
            this.semesterComboBox.Size = new System.Drawing.Size(68, 32);
            this.semesterComboBox.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(330, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 31;
            this.label5.Text = "Semester";
            // 
            // cbContact
            // 
            this.cbContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContact.FormattingEnabled = true;
            this.cbContact.Location = new System.Drawing.Point(119, 154);
            this.cbContact.Name = "cbContact";
            this.cbContact.Size = new System.Drawing.Size(121, 28);
            this.cbContact.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(40, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 24);
            this.label6.TabIndex = 33;
            this.label6.Text = "Contact";
            // 
            // ManageCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(653, 403);
            this.Controls.Add(this.cbContact);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.semesterComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totalCourseLabel);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.lastButton);
            this.Controls.Add(this.preButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.removeEdit);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.periodNumericUD);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManageCourseForm";
            this.Text = "ManageCourseForm";
            this.Load += new System.EventHandler(this.ManageCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.periodNumericUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.NumericUpDown periodNumericUD;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox labelTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeEdit;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button preButton;
        private System.Windows.Forms.Button lastButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label totalCourseLabel;
        private System.Windows.Forms.ComboBox semesterComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbContact;
        private System.Windows.Forms.Label label6;
    }
}