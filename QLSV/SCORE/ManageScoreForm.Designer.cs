
namespace QLSV.SCORE
{
    partial class ManageScoreForm
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
            System.Windows.Forms.Button removeButton;
            System.Windows.Forms.Button avgScoreButton;
            System.Windows.Forms.Button showStdButton;
            System.Windows.Forms.Button showScoreButton;
            System.Windows.Forms.Button showScoreByCourseButton;
            System.Windows.Forms.Button EditButton;
            this.courseidComboBox = new System.Windows.Forms.ComboBox();
            this.scoreTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stdidTextBox = new System.Windows.Forms.TextBox();
            this.stdIDLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            addButton = new System.Windows.Forms.Button();
            removeButton = new System.Windows.Forms.Button();
            avgScoreButton = new System.Windows.Forms.Button();
            showStdButton = new System.Windows.Forms.Button();
            showScoreButton = new System.Windows.Forms.Button();
            showScoreByCourseButton = new System.Windows.Forms.Button();
            EditButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            addButton.BackColor = System.Drawing.Color.DarkTurquoise;
            addButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            addButton.Location = new System.Drawing.Point(21, 270);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(84, 39);
            addButton.TabIndex = 28;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            removeButton.BackColor = System.Drawing.Color.Red;
            removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            removeButton.Location = new System.Drawing.Point(202, 270);
            removeButton.Name = "removeButton";
            removeButton.Size = new System.Drawing.Size(95, 39);
            removeButton.TabIndex = 32;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = false;
            removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // avgScoreButton
            // 
            avgScoreButton.BackColor = System.Drawing.Color.DarkTurquoise;
            avgScoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            avgScoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            avgScoreButton.Location = new System.Drawing.Point(38, 325);
            avgScoreButton.Name = "avgScoreButton";
            avgScoreButton.Size = new System.Drawing.Size(222, 40);
            avgScoreButton.TabIndex = 33;
            avgScoreButton.Text = "Avg Score by Course";
            avgScoreButton.UseVisualStyleBackColor = false;
            avgScoreButton.Click += new System.EventHandler(this.avgScoreButton_Click);
            // 
            // showStdButton
            // 
            showStdButton.BackColor = System.Drawing.Color.DarkTurquoise;
            showStdButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            showStdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            showStdButton.Location = new System.Drawing.Point(389, 7);
            showStdButton.Name = "showStdButton";
            showStdButton.Size = new System.Drawing.Size(145, 39);
            showStdButton.TabIndex = 34;
            showStdButton.Text = "Show Student";
            showStdButton.UseVisualStyleBackColor = false;
            showStdButton.Click += new System.EventHandler(this.showStdButton_Click);
            // 
            // showScoreButton
            // 
            showScoreButton.BackColor = System.Drawing.Color.DarkTurquoise;
            showScoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            showScoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            showScoreButton.Location = new System.Drawing.Point(556, 7);
            showScoreButton.Name = "showScoreButton";
            showScoreButton.Size = new System.Drawing.Size(145, 39);
            showScoreButton.TabIndex = 35;
            showScoreButton.Text = "Show Scores";
            showScoreButton.UseVisualStyleBackColor = false;
            showScoreButton.Click += new System.EventHandler(this.showScoreButton_Click);
            // 
            // showScoreByCourseButton
            // 
            showScoreByCourseButton.BackColor = System.Drawing.Color.DarkTurquoise;
            showScoreByCourseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            showScoreByCourseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            showScoreByCourseButton.Location = new System.Drawing.Point(716, 7);
            showScoreByCourseButton.Name = "showScoreByCourseButton";
            showScoreByCourseButton.Size = new System.Drawing.Size(170, 39);
            showScoreByCourseButton.TabIndex = 35;
            showScoreByCourseButton.Text = "Scores By Course";
            showScoreByCourseButton.UseVisualStyleBackColor = false;
            showScoreByCourseButton.Click += new System.EventHandler(this.showScoreByCourseButton_Click);
            // 
            // EditButton
            // 
            EditButton.BackColor = System.Drawing.Color.Gold;
            EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            EditButton.Location = new System.Drawing.Point(111, 270);
            EditButton.Name = "EditButton";
            EditButton.Size = new System.Drawing.Size(85, 39);
            EditButton.TabIndex = 28;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = false;
            EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // courseidComboBox
            // 
            this.courseidComboBox.BackColor = System.Drawing.Color.Aqua;
            this.courseidComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.courseidComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.courseidComboBox.FormattingEnabled = true;
            this.courseidComboBox.Location = new System.Drawing.Point(119, 56);
            this.courseidComboBox.Name = "courseidComboBox";
            this.courseidComboBox.Size = new System.Drawing.Size(171, 32);
            this.courseidComboBox.TabIndex = 30;
            // 
            // scoreTextBox
            // 
            this.scoreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.scoreTextBox.Location = new System.Drawing.Point(119, 107);
            this.scoreTextBox.Name = "scoreTextBox";
            this.scoreTextBox.Size = new System.Drawing.Size(170, 29);
            this.scoreTextBox.TabIndex = 29;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.descriptionTextBox.Location = new System.Drawing.Point(119, 155);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(170, 96);
            this.descriptionTextBox.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(6, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 26;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(45, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(34, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Course";
            // 
            // stdidTextBox
            // 
            this.stdidTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.stdidTextBox.Location = new System.Drawing.Point(119, 11);
            this.stdidTextBox.Name = "stdidTextBox";
            this.stdidTextBox.Size = new System.Drawing.Size(170, 29);
            this.stdidTextBox.TabIndex = 23;
            // 
            // stdIDLabel
            // 
            this.stdIDLabel.AutoSize = true;
            this.stdIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.stdIDLabel.Location = new System.Drawing.Point(17, 16);
            this.stdIDLabel.Name = "stdIDLabel";
            this.stdIDLabel.Size = new System.Drawing.Size(96, 24);
            this.stdIDLabel.TabIndex = 22;
            this.stdIDLabel.Text = "Student ID";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(303, 48);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(613, 307);
            this.dataGridView.TabIndex = 36;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick_1);
            // 
            // ManageScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 364);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(showScoreByCourseButton);
            this.Controls.Add(showScoreButton);
            this.Controls.Add(showStdButton);
            this.Controls.Add(avgScoreButton);
            this.Controls.Add(removeButton);
            this.Controls.Add(this.courseidComboBox);
            this.Controls.Add(this.scoreTextBox);
            this.Controls.Add(EditButton);
            this.Controls.Add(addButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stdidTextBox);
            this.Controls.Add(this.stdIDLabel);
            this.Name = "ManageScoreForm";
            this.Text = "ManageScoreForm";
            this.Load += new System.EventHandler(this.ManageScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox courseidComboBox;
        private System.Windows.Forms.TextBox scoreTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stdidTextBox;
        private System.Windows.Forms.Label stdIDLabel;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}