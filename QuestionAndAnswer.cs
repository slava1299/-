using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp01
{
    public class QuestionAndAnswer
    {
        public string Question { get; set; } // текст вопроса
        public List<string> Answers { get; set; } = new List<string>(); // список строк с ответами
        public int CorrectAnswer { get; set; } // правильный ответ

        //public static List<QuestionAndAnswer> ReadQuestionsFromExcel(string fileName)
        //{
        //    var questions = new List<QuestionAndAnswer>();

        //    using (var package = new ExcelPackage(new FileInfo(fileName)))
        //    {
        //        var worksheet = package.Workbook.Worksheets.First();

        //        int rowIndex = 2;
        //        int emptyRowsCounter = 0;

        //        while (rowIndex <= worksheet.Dimension.End.Row)
        //        {
        //            var question = new QuestionAndAnswer()
        //            {
        //                Question = worksheet.Cells[rowIndex, 1].Value?.ToString(),
        //                Answers = new List<string>()
        //            };

        //            if (string.IsNullOrWhiteSpace(question.Question))
        //            {
        //                emptyRowsCounter++;

        //                if (emptyRowsCounter >= 2)
        //                {
        //                    break; // Прервать чтение, если встретились две пустые строки подряд
        //                }
        //            }
        //            else
        //            {
        //                emptyRowsCounter = 0;

        //                rowIndex++;

        //                while (rowIndex <= worksheet.Dimension.End.Row &&
        //                       !string.IsNullOrWhiteSpace(worksheet.Cells[rowIndex, 1].Value?.ToString()))
        //                {
        //                    question.Answers.Add(worksheet.Cells[rowIndex, 1].Value.ToString());
        //                    rowIndex++;
        //                }

        //                questions.Add(question);

        //                // Переход к следующему вопросу
        //                rowIndex++; // Пропустить пустую строку
        //            }
        //        }

        //        MessageBox.Show($"Программа считала {questions.Count} вопросов.");
        
        //        return questions;
        //    }
        //}
        public static List<QuestionAndAnswer> ReadQuestionsFromExcel(string fileName, string sheetName)
        {
            var allQuestions = new List<QuestionAndAnswer>();

            using (var package = new ExcelPackage(new FileInfo(fileName)))
            {
               var  worksheet = package.Workbook.Worksheets[sheetName];

                int numberOfQuestions = Convert.ToInt32(worksheet.Cells[3, 3].Value); // подсчет количества вопросов

                int rowIndex = 2;
                int emptyRowsCounter = 0;

                while (rowIndex <= worksheet.Dimension.End.Row)
                {
                    var question = new QuestionAndAnswer()
                    {
                        Question = worksheet.Cells[rowIndex, 1].Value?.ToString(),
                        Answers = new List<string>(),
                        //CorrectAnswer = worksheet.Cells[rowIndex, 2].Value?.ToString() //// Здесь мы читаем правильный ответ
                    }; 

                    if (string.IsNullOrWhiteSpace(question.Question))
                    {
                        emptyRowsCounter++;

                        if (emptyRowsCounter >= 2)
                        {
                            break; // Прервать чтение, если встретились две пустые строки подряд
                        }
                    }
                    else
                    {
                        emptyRowsCounter = 0;
                        int correctAnswerIndex;
                        if (!int.TryParse(worksheet.Cells[rowIndex, 2].Value.ToString(), out correctAnswerIndex))
                        {
                            MessageBox.Show($"Ошибка при чтении правильного ответа для вопроса '{question.Question}'. Значение: {worksheet.Cells[rowIndex, 2].Value}");
                            continue; // Перейти к следующему вопросу, если ошибка
                        }

                        question.CorrectAnswer = correctAnswerIndex; // Присваивание правильного ответа


                        rowIndex++;

                        while (rowIndex <= worksheet.Dimension.End.Row &&
                               !string.IsNullOrWhiteSpace(worksheet.Cells[rowIndex, 1].Value?.ToString()))
                        {
                            question.Answers.Add(worksheet.Cells[rowIndex, 1].Value.ToString());
                            rowIndex++;
                        }
                       
                        allQuestions.Add(question);
                        

                        // Переход к следующему вопросу
                        rowIndex++; // Пропустить пустую строку
                    }
                }

                // Выбор случайных вопросов
                Random random = new Random();
                var selectedQuestions = new List<QuestionAndAnswer>(numberOfQuestions);

                for (int i = 0; i < numberOfQuestions && allQuestions.Count > 0; i++)
                {
                    int index = random.Next(allQuestions.Count);
                    selectedQuestions.Add(allQuestions[index]);
                    allQuestions.RemoveAt(index);
                }

               //MessageBox.Show($"Программа выбрала {selectedQuestions.Count} вопросов.");

                return selectedQuestions;
            }
        }
    }
    
}
