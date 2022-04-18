
namespace QLSV.COURSE
{
    partial class AddCourseForm
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
            System.Windows.Forms.Button addButton;
            this.label1 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.labelTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.periodNumericUD = new System.Windows.Forms.NumericUpDown();
            this.semesterComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbContact = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.periodNumericUD)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            addButton.BackColor = System.Drawing.Color.DarkTurquoise;
            addButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            addButton.Location = new System.Drawing.Point(157, 284);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(145, 39);
            addButton.TabIndex = 9;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course ID";
            // 
            // idTextBox
            // 
            this.idTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.idTextBox.Location = new System.Drawing.Point(122, 39);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(84, 29);
            this.idTextBox.TabIndex = 1;
            // 
            // labelTextBox
            // 
            this.labelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTextBox.Location = new System.Drawing.Point(122, 74);
            this.labelTextBox.Name = "labelTextBox";
            this.labelTextBox.Size = new System.Drawing.Size(266, 29);
            this.labelTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(60, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(51, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Period";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.descriptionTextBox.Location = new System.Drawing.Point(122, 183);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(266, 80);
            this.descriptionTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // periodNumericUD
            // 
            this.periodNumericUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.periodNumericUD.Location = new System.Drawing.Point(122, 109);
            this.periodNumericUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.periodNumericUD.Name = "periodNumericUD";
            this.periodNumericUD.Size = new System.Drawing.Size(120, 29);
            this.periodNumericUD.TabIndex = 8;
            this.periodNumericUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // semesterComboBox
            // 
            this.semesterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterComboBox.FormattingEnabled = true;
            this.semesterComboBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.semesterComboBox.Location = new System.Drawing.Point(320, 34);
            this.semesterComboBox.Name = "semesterComboBox";
            this.semesterComboBox.Size = new System.Drawing.Size(68, 32);
            this.semesterComboBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(224, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Semester";
            // 
            // cbContact
            // 
            this.cbContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContact.FormattingEnabled = true;
            this.cbContact.Location = new System.Drawing.Point(122, 145);
            this.cbContact.Name = "cbContact";
            this.cbContact.Size = new System.Drawing.Size(121, 28);
            this.cbContact.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(43, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Contact";
            // 
            // AddCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(424, 362);
            this.Controls.Add(this.cbContact);
            this.Controls.Add(this.semesterComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(addButton);
            this.Controls.Add(this.periodNumericUD);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddCourseForm";
            this.Text = "AddCousreForm";
            this.Load += new System.EventHandler(this.AddCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.periodNumericUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox labelTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown periodNumericUD;
        private System.Windows.Forms.ComboBox semesterComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbContact;
        private System.Windows.Forms.Label label6;
    }
}