using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV.RESULT
{
    public partial class AvgResultForm : Form
    {
        public AvgResultForm()
        {
            InitializeComponent();
        }
        QLSV.SCORE.SCORE Score = new QLSV.SCORE.SCORE();

        private void LoadDGV()
        {
            dgvResult.DataSource = Score.getAllScore(searchTextBox.Text);
            dgvResult.Tag = "2";
            dgvResult.Columns.Add("result", "Result");
            int c = dgvResult.Columns.Count - 1;
            float score = 0;
            for (int i = 0; i < dgvResult.Rows.Count - 1; i++)
            {
                if (dgvResult.Rows[i].Cells[c - 1].Value.ToString() == "")
                {
                    dgvResult.Rows[i].Cells[c].Value = "Chưa đăng kí môn";
                }
                else
                {
                    score = float.Parse(dgvResult.Rows[i].Cells[c - 1].Value.ToString());
                    if (score >= 8)
                    {
                        dgvResult.Rows[i].Cells[c].Value = "Giỏi";
                    }
                    else if (score >= 6.5)
                    {
                        dgvResult.Rows[i].Cells[c].Value = "Khá";
                    }
                    else if (score >= 5)
                    {
                        dgvResult.Rows[i].Cells[c].Value = "TB";
                    }
                    else
                    {
                        dgvResult.Rows[i].Cells[c].Value = "Kém";
                    }
                }


            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private bool checkID(string s)
        {
            if (s.Length == 0)
                return false;
            foreach (var item in s)
            {
                if (item < '0' || item > '9')
                    return false;
            }
            return true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResult.Tag == "2")
            {
                studentIDTtextBox.Text = dgvResult.CurrentRow.Cells[0].Value.ToString();
                fnameTextBox.Text = dgvResult.CurrentRow.Cells[1].Value.ToString();
                lnameTextBox.Text = dgvResult.CurrentRow.Cells[2].Value.ToString();
            }
        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;

                Document oDoc = new Document();
                oDoc.Application.Visible = true;

                oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;

                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                Object oMissing = System.Reflection.Missing.Value;
                for (int r = 0; r < RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DGV.Rows[r].Cells[c].Value + "\t";
                    }
                    //oTemp += "\n";
                }

                oRange.Text = oTemp;
                object Separator = WdTableFieldSeparator.wdSeparateByTabs;
                object borders = true;
                object AutoFit = true;
                object AutoFitBehavior = WdAutoFitBehavior.wdAutoFitContent;
                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                    Type.Missing, Type.Missing, ref borders,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);
                //save the file
                oRange.Select();
                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 6");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                foreach (Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh sách điểm theo môn học\n" +
                    "Khoa: CNTT\n" +
                    "Khoá 2019\n";
                    headerRange.Font.Color = WdColor.wdColorBlack;
                    headerRange.Font.Size = 18;
                    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }

                for (int c = 0; c < DGV.Columns.Count; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                oDoc.SaveAs2(filename);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = "*.docx";
            savefile.Filter = "Word documents files(*.docx)|*.docx";
            if (savefile.ShowDialog() == DialogResult.OK && savefile.FileName.Length > 0)
            {
                Export_Data_To_Word(dgvResult, savefile.FileName);
                MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AvgResultForm_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AvgResultForm_Resize(object sender, EventArgs e)
        {
            Size s = this.Size;
            s.Width = s.Width - 230;
            s.Height = 240;
            dgvResult.Size = s;
        }
    }
}
