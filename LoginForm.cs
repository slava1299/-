using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace TestApp01
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


        }


        private void AutorizationText_Click(object sender, EventArgs e)
        {

        }

        private void SHcodeText_Click(object sender, EventArgs e)
        {

        }

        private void FioBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartTestButton_Click(object sender, EventArgs e)
        {   //записываем в Exel
            //  string fileName = "C:\\Users\\slava\\source\\repos\\TestApp01\\bin\\Results.xlsx";
            string fileName = "Results.xlsx";
            // Данные из  FioBox

            string value1 = FioBox.Text;

            // Данные из SHcodeBox

            string value2 = SHcodeBox.Text;

            // Данные из SpecializationBox

            string value3 = SpecializationBox.Text;

            // Данные из GroupQuestnBox

            string value4 = GroupQuestnBox.Text;

            string sheetName = value4;
            string ResultsName = "Итоговые результаты";

           

            if (value1 == "" | value2 == "" | value3 == "" | value4 =="")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                AppendToExistingExcel(fileName, sheetName, value1, value2, value3);
                AppendToExistingExcel2(fileName, ResultsName, value1, value3); // Сохраняем данные в итоги


                MessageBox.Show("Данные успешно сохранены!");
                this.Hide();
                QuestionsForm questions_test = new QuestionsForm(sheetName);
                questions_test.Show();
            }

        }
        private void Fon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SHcodeBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void FioText_Click(object sender, EventArgs e)
        {

        }

        private void SpecializationText_Click(object sender, EventArgs e)
        {

        }
        public void AppendToExistingExcel(string fileName, string sheetName, string cellValue1, string cellValue2, string cellValue3)
        {
            FileInfo existingFile = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName];

                if (worksheet == null)
                {
                    throw new ArgumentException($"Лист '{sheetName}' не найден в файле.");
                }
                int firstEmptyRow = worksheet.Dimension.End.Row + 2;
                worksheet.Cells[firstEmptyRow, 1].Value = cellValue1;
                worksheet.Cells[firstEmptyRow, 2].Value = cellValue2;
                worksheet.Cells[firstEmptyRow, 3].Value = cellValue3;
                package.Save();
            }
        }
        public void AppendToExistingExcel2(string fileName, string ResultsName, string cellValue1, string cellValue3)
        {
            FileInfo existingFile = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[ResultsName];

                if (worksheet == null)
                {
                    throw new ArgumentException($"Лист '{ResultsName}' не найден в файле.");
                }
                int firstEmptyRow = worksheet.Dimension.End.Row+2;
                worksheet.Cells[firstEmptyRow, 1].Value = cellValue1;
                worksheet.Cells[firstEmptyRow, 2].Value = cellValue3;
                package.Save();
            }
        }



    }
}

