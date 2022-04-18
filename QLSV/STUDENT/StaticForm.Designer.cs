
namespace QLSV
{
    partial class StaticForm
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
            this.panMale = new System.Windows.Forms.Panel();
            this.lbMale = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panFemale = new System.Windows.Forms.Panel();
            this.lbFemale = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panTotal = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.panMale.SuspendLayout();
            this.panFemale.SuspendLayout();
            this.panTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMale
            // 
            this.panMale.BackColor = System.Drawing.Color.LimeGreen;
            this.panMale.Controls.Add(this.lbMale);
            this.panMale.Controls.Add(this.panel2);
            this.panMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.panMale.Location = new System.Drawing.Point(1, 120);
            this.panMale.Name = "panMale";
            this.panMale.Size = new System.Drawing.Size(208, 117);
            this.panMale.TabIndex = 0;
            this.panMale.MouseLeave += new System.EventHandler(this.panMale_MouseLeave);
            // 
            // lbMale
            // 
            this.lbMale.AutoSize = true;
            this.lbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lbMale.ForeColor = System.Drawing.Color.White;
            this.lbMale.Location = new System.Drawing.Point(11, 42);
            this.lbMale.Name = "lbMale";
            this.lbMale.Size = new System.Drawing.Size(85, 31);
            this.lbMale.TabIndex = 1;
            this.lbMale.Text = "Male:";
            this.lbMale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMale.MouseEnter += new System.EventHandler(this.lbMale_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(205, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 117);
            this.panel2.TabIndex = 1;
            // 
            // panFemale
            // 
            this.panFemale.BackColor = System.Drawing.Color.Pink;
            this.panFemale.Controls.Add(this.lbFemale);
            this.panFemale.Controls.Add(this.panel4);
            this.panFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.panFemale.Location = new System.Drawing.Point(209, 120);
            this.panFemale.Name = "panFemale";
            this.panFemale.Size = new System.Drawing.Size(208, 117);
            this.panFemale.TabIndex = 2;
            this.panFemale.MouseEnter += new System.EventHandler(this.panFemale_MouseEnter);
            this.panFemale.MouseLeave += new System.EventHandler(this.panFemale_MouseLeave);
            // 
            // lbFemale
            // 
            this.lbFemale.AutoSize = true;
            this.lbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lbFemale.ForeColor = System.Drawing.Color.White;
            this.lbFemale.Location = new System.Drawing.Point(6, 42);
            this.lbFemale.Name = "lbFemale";
            this.lbFemale.Size = new System.Drawing.Size(119, 31);
            this.lbFemale.TabIndex = 2;
            this.lbFemale.Text = "Female:";
            this.lbFemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(205, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(208, 117);
            this.panel4.TabIndex = 1;
            // 
            // panTotal
            // 
            this.panTotal.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panTotal.Controls.Add(this.lbTotal);
            this.panTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.panTotal.Location = new System.Drawing.Point(1, 0);
            this.panTotal.Name = "panTotal";
            this.panTotal.Size = new System.Drawing.Size(416, 120);
            this.panTotal.TabIndex = 2;
            this.panTotal.MouseLeave += new System.EventHandler(this.panTotal_MouseLeave);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lbTotal.ForeColor = System.Drawing.Color.White;
            this.lbTotal.Location = new System.Drawing.Point(83, 44);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(194, 31);
            this.lbTotal.TabIndex = 0;
            this.lbTotal.Text = "Total student:";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTotal.MouseEnter += new System.EventHandler(this.lbTotal_MouseEnter);
            // 
            // StaticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 242);
            this.Controls.Add(this.panTotal);
            this.Controls.Add(this.panFemale);
            this.Controls.Add(this.panMale);
            this.Name = "StaticForm";
            this.Text = "StaticForm";
            this.Load += new System.EventHandler(this.StaticForm_Load);
            this.panMale.ResumeLayout(false);
            this.panMale.PerformLayout();
            this.panFemale.ResumeLayout(false);
            this.panFemale.PerformLayout();
            this.panTotal.ResumeLayout(false);
            this.panTotal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMale;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panFemale;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panTotal;
        private System.Windows.Forms.Label lbMale;
        private System.Windows.Forms.Label lbFemale;
        private System.Windows.Forms.Label lbTotal;
    }
}