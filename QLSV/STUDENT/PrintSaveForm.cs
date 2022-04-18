using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;


namespace QLSV
{
    public partial class PrintSaveForm : Form
    {
        public PrintSaveForm()
        {
            InitializeComponent();
        }

        STUDENT Student = new STUDENT();
        Bitmap memoryImage;
        private void PrintSaveForm_Load(object sender, EventArgs e)
        {

            SqlCommand command = new SqlCommand("SELECT * FROM std");
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowTemplate.Height = 100;
            dataGridView.DataSource = Student.getStudent(command);

            DataGridViewImageColumn Pic = new DataGridViewImageColumn();
            Pic = (DataGridViewImageColumn)dataGridView.Columns[7];
            Pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void rBMale_CheckedChanged(object sender, EventArgs e)
        {
            String query = "SELECT * FROM std WHERE gender='Male'";
            SqlCommand command = new SqlCommand(query);
            LoadDataGrid(Student.getStudent(command));
        }

        private void LoadDataGrid(System.Data.DataTable data)
        {
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowTemplate.Height = 100;
            dataGridView.DataSource = data;

            DataGridViewImageColumn Pic = new DataGridViewImageColumn();
            Pic = (DataGridViewImageColumn)dataGridView.Columns[7];
            Pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void rBFemale_CheckedChanged(object sender, EventArgs e)
        {
            String query = "SELECT * FROM std WHERE gender='Female'";
            SqlCommand command = new SqlCommand(query);
            LoadDataGrid(Student.getStudent(command));
        }

        private void rBAll_CheckedChanged(object sender, EventArgs e)
        {
            String query = "SELECT * FROM std";
            SqlCommand command = new SqlCommand(query);
            LoadDataGrid(Student.getStudent(command));
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string gender = "", con = "";
            string query = "SELECT * FROM std";

            if (rBMale.Checked == true)
            {
                gender = "Male";
            }
            else if (rBFemale.Checked == true)
            {
                gender = "Female";
            }
            if (gender != "")
                con = con + " gender='" + gender + "'";
            if (rBYes.Checked)
            {
                query += " where";
                if (con != "")
                    con += " and";
                query += con;
                query += " bdate>=@bdate1 and bdate<=@bdate2";
                command = new SqlCommand(query);
                command.Parameters.Add("@bdate1", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                command.Parameters.Add("@bdate2", SqlDbType.DateTime).Value = dateTimePicker2.Value;

            }
            else
            {
                if (con != "")
                {
                    query = query + " where" + con;
                }
                command = new SqlCommand(query);
            }

            LoadDataGrid(Student.getStudent(command));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            PrintDialog print = new PrintDialog();
            print.Document = printDocument1;
            
            if(print.ShowDialog()==DialogResult.OK)
                printDocument1.Print();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = "*.docx";
            savefile.Filter = "Word documents files(*.docx)|*.docx";
            if (savefile.ShowDialog() == DialogResult.OK && savefile.FileName.Length > 0)
            {
                Export_Data_To_Word(dataGridView, savefile.FileName);
                MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string oTemp ="";
                Object oMissing = System.Reflection.Missing.Value;
                for (int r = 0; r <= RowCount - 1; r++)
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
                oRange.ConvertToTable(ref Separator,ref RowCount,ref ColumnCount,
                    Type.Missing,Type.Missing,ref borders, 
                    Type.Missing, Type.Missing,Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, ref AutoFit,ref AutoFitBehavior,Type.Missing);
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
                
                foreach(Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh sách sinh viên Lớp 191102\n" +
                    "Khoa: CNTT\n" +
                    "Khoá 2019\n";
                    headerRange.Font.Color = WdColor.wdColorBlack;
                    headerRange.Font.Size = 18;
                    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }

                for (int c=0; c < DGV.Columns.Count; c++) {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;    
                }
                for (int r = 0; r < DGV.Rows.Count; r++)
                {
                    byte[] imgbyte = (byte[])dataGridView.Rows[r].Cells[7].Value;
                    MemoryStream ms = new MemoryStream(imgbyte);
                    Image finalPic = (Image)(new Bitmap(Image.FromStream(ms), new Size(50, 50)));
                    Clipboard.SetDataObject(finalPic);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 8).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 8).Range.InsertParagraphAfter();
                }
                oDoc.SaveAs2(filename);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }
    }
}
