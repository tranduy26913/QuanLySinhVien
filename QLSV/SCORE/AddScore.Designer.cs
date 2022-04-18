
namespace QLSV.SCORE
{
    partial class AddScore
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
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stdidTextBox = new System.Windows.Forms.TextBox();
            this.stdIDLabel = new System.Windows.Forms.Label();
            this.scoreTextBox = new System.Windows.Forms.TextBox();
            this.courseidComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            addButton.BackColor = System.Drawing.Color.DarkTurquoise;
            addButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            addButton.Location = new System.Drawing.Point(111, 279);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(145, 39);
            addButton.TabIndex = 18;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.descriptionTextBox.Location = new System.Drawing.Point(146, 165);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(170, 96);
            this.descriptionTextBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(13, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(52, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(41, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Course";
            // 
            // stdidTextBox
            // 
            this.stdidTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.stdidTextBox.Location = new System.Drawing.Point(146, 21);
            this.stdidTextBox.Name = "stdidTextBox";
            this.stdidTextBox.Size = new System.Drawing.Size(170, 29);
            this.stdidTextBox.TabIndex = 11;
            // 
            // stdIDLabel
            // 
            this.stdIDLabel.AutoSize = true;
            this.stdIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.stdIDLabel.Location = new System.Drawing.Point(24, 26);
            this.stdIDLabel.Name = "stdIDLabel";
            this.stdIDLabel.Size = new System.Drawing.Size(96, 24);
            this.stdIDLabel.TabIndex = 10;
            this.stdIDLabel.Text = "Student ID";
            // 
            // scoreTextBox
            // 
            this.scoreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.scoreTextBox.Location = new System.Drawing.Point(146, 117);
            this.scoreTextBox.Name = "scoreTextBox";
            this.scoreTextBox.Size = new System.Drawing.Size(170, 29);
            this.scoreTextBox.TabIndex = 19;
            // 
            // courseidComboBox
            // 
            this.courseidComboBox.BackColor = System.Drawing.Color.Aqua;
            this.courseidComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.courseidComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.courseidComboBox.FormattingEnabled = true;
            this.courseidComboBox.Location = new System.Drawing.Point(146, 66);
            this.courseidComboBox.Name = "courseidComboBox";
            this.courseidComboBox.Size = new System.Drawing.Size(171, 32);
            this.courseidComboBox.TabIndex = 20;
            this.courseidComboBox.SelectedIndexChanged += new System.EventHandler(this.idComboBox_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.student_id,
            this.fname,
            this.lname});
            this.dataGridView.Location = new System.Drawing.Point(323, 21);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 30;
            this.dataGridView.Size = new System.Drawing.Size(365, 312);
            this.dataGridView.TabIndex = 21;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // student_id
            // 
            this.student_id.DataPropertyName = "id";
            this.student_id.FillWeight = 120F;
            this.student_id.HeaderText = "Student ID";
            this.student_id.Name = "student_id";
            this.student_id.Width = 120;
            // 
            // fname
            // 
            this.fname.DataPropertyName = "fname";
            this.fname.HeaderText = "First Name";
            this.fname.Name = "fname";
            this.fname.Width = 120;
            // 
            // lname
            // 
            this.lname.DataPropertyName = "lname";
            this.lname.HeaderText = "Last Name";
            this.lname.Name = "lname";
            this.lname.Width = 120;
            // 
            // AddScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 347);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.courseidComboBox);
            this.Controls.Add(this.scoreTextBox);
            this.Controls.Add(addButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stdidTextBox);
            this.Controls.Add(this.stdIDLabel);
            this.Name = "AddScore";
            this.Text = "AddScore";
            this.Load += new System.EventHandler(this.AddScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stdidTextBox;
        private System.Windows.Forms.Label stdIDLabel;
        private System.Windows.Forms.TextBox scoreTextBox;
        private System.Windows.Forms.ComboBox courseidComboBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fname;
        private System.Windows.Forms.DataGridViewTextBoxColumn lname;
    }
}