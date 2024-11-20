using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp01
{
    public partial class QuestionsForm : Form
    {

        int timeLeftsec, timeLeft;
        private readonly string _sheetName; // Переменная для хранения переданного значения листа

        // для отображение вопросов и ответов в форме
        private readonly List<QuestionAndAnswer> _questions;
        private Dictionary<int, int?> _answersState = new Dictionary<int, int?>(); // Словарь для хранения состояний ответов
        private int _currentQuestionIndex = 0;



        public QuestionsForm(string sheetName)
        {
            InitializeComponent();
            _sheetName = sheetName; // Сохранение значения sheetName в приватной переменной
            



            FormClosing += new FormClosingEventHandler(QuestionsForm_FormClosing); //Подписка на событие FormClosing
            string fileName = "Questions.xlsx";

            _questions = QuestionAndAnswer.ReadQuestionsFromExcel(fileName, _sheetName);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DisplayCurrentQuestion();



            int Time_row = 1; // ячейка количества минут в файле
            int Time_column = 3; // ячейка количества минут в файле

            using (ExcelPackage package = new ExcelPackage(new FileInfo(fileName)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[_sheetName];

                if (worksheet != null)
                {
                    object cellValue = worksheet.Cells[Time_row, Time_column].Value;

                    int.TryParse(cellValue.ToString(), out timeLeft);


                }
                else
                {
                    MessageBox.Show($"Лист {sheetName} не найден в файле.");
                }
            }

            // timeLeft = 1; // количество времени на тест в минутах
            timeLeftsec = timeLeft * 60;
            // timeLeftsec = 945; // для тестов быстрых
            timer1.Start();
            // Сохраняем исходный размер шрифта

        }

        // Метод для сброса состояния радио-кнопок
        private void ResetRadioButtons()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;

        }
        private void DisplayCurrentQuestion()
        {
            // if (_currentQuestionIndex < _questions.Count)
            //{
            var currentQuestion = _questions[_currentQuestionIndex];

            lblQuestion.Text = currentQuestion.Question;

            // Очистка предыдущих вариантов ответов
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;


            for (int i = 0; i < currentQuestion.Answers.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        radioButton1.Text = currentQuestion.Answers[i];
                        radioButton1.Visible = true;
                        break;
                    case 1:
                        radioButton2.Text = currentQuestion.Answers[i];
                        radioButton2.Visible = true;
                        break;
                    case 2:
                        radioButton3.Text = currentQuestion.Answers[i];
                        radioButton3.Visible = true;
                        break;
                    case 3:
                        radioButton4.Text = currentQuestion.Answers[i];
                        radioButton4.Visible = true;
                        break;
                    case 4:
                        radioButton5.Text = currentQuestion.Answers[i];
                        radioButton5.Visible = true;
                        break;

                }
            }

            // Проверяем, был ли выбран ответ для данного вопроса
            if (_answersState.ContainsKey(_currentQuestionIndex))
            {
                int? answerIndex = _answersState[_currentQuestionIndex];
                if (answerIndex.HasValue)
                {
                    switch (answerIndex.Value)
                    {
                        case 0:
                            radioButton1.Checked = true;
                            break;
                        case 1:
                            radioButton2.Checked = true;
                            break;
                        case 2:
                            radioButton3.Checked = true;
                            break;
                        case 3:
                            radioButton4.Checked = true;
                            break;
                        case 4:
                            radioButton5.Checked = true;
                            break;

                    }
                }
            }
            else
            {
                ResetRadioButtons(); // Если нет сохраненного ответа, сбрасываем все кнопки
            }
            // Обновляем текст в lblQuestionNumber
            lblQuestionNumber.Text = $"Вопрос {_currentQuestionIndex + 1}/{_questions.Count}";
            //}
            //else
            //{
            //    MessageBox.Show("Тест завершён.");
            //    // Завершить тест
            //}

        }

        private void SaveUserAnswer() // сохранение выбранного ответа
        {
            // Проверяем, выбрана ли хоть одна кнопка
            bool anyChecked = false;

            for (int i = 0; i < 6; i++)
            {
                Control[] controls = Controls.Find($"radioButton{i + 1}", true);
                RadioButton radioButton = controls.Length > 0 ? (RadioButton)controls[0] : null;

                if (radioButton != null && radioButton.Checked)
                {
                    _answersState[_currentQuestionIndex] = i;
                    anyChecked = true;
                    return;
                }
            }

            // Если ни одна кнопка не выбрана, удаляем запись из словаря
            if (!anyChecked)
            {
                _answersState.Remove(_currentQuestionIndex);
            }
        }

        //private void ShowResults()
        //{
        //    // Логика показа результатов
        //}

        private void QuestionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) //Проверка свойства CloseReason.
                                                          //Если значение равно UserClosing, значит закрыта форма вручную
            {
                Application.Exit(); //метод завершает работу всего приложения
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            string fileName = "Results.xlsx";
            string ResultsName = "Итоговые результаты";

            string time_result_fail = "Время закончилось";
            if (timeLeftsec > 0)
            {

                timeLeftsec = timeLeftsec - 1;
                int minutes = timeLeftsec / 60;
                int seconds = timeLeftsec % 60;
                timeLabel.Text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "00:00";
                this.Hide();
                TestEndForm test_end = new TestEndForm();
                test_end.Show();
                AppendToExistingExcel(fileName, _sheetName, time_result_fail); // если время закончилось - в файл
                                                                               // идет соответствующая запись
                AppendToExistingExcel2(fileName, ResultsName, time_result_fail);
            }
        }

        private void AppendToExistingExcel(string fileName, string sheetName, string time_result_fail)
        {
            FileInfo existingFile = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName];
                int firstEmptyRow = worksheet.Dimension.End.Row;
                worksheet.Cells[firstEmptyRow, 4].Value = time_result_fail;
                package.Save();
            }
        }
        private void AppendToExistingExcel2(string fileName, string ResultsName, string time_result_fail)
        {
            FileInfo existingFile = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[ResultsName];
                int firstEmptyRow = worksheet.Dimension.End.Row;
                worksheet.Cells[firstEmptyRow, 3].Value = time_result_fail;
                package.Save();
            }
        }

        private void timeleftLabel_Click(object sender, EventArgs e)
        {
            AutoScaleMode = AutoScaleMode.Font;
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {
            AutoScaleMode = AutoScaleMode.Font;
        }





        private void QuestionsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            SaveUserAnswer(); // Сохраняем выбранный пользователем ответ
            if (_currentQuestionIndex > 0)
            {
                _currentQuestionIndex--;
                DisplayCurrentQuestion();
            }
            else
            {
                MessageBox.Show("Нельзя вернуться к первому вопросу.");
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {


            SaveUserAnswer(); // Сохраняем выбранный пользователем ответ
            _currentQuestionIndex++;

            if (_currentQuestionIndex < _questions.Count)
            {
                DisplayCurrentQuestion();
            }
            else
            {
                MessageBox.Show("Нет больше вопросов.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // EndTest(); // Показываем результаты теста
            }
        }

        //private int CalculateScore()
        //{
        //    int score = 0;

        //    for (int i = 0; i < _questions.Count; i++)
        //    {
        //        if (_answersState.ContainsKey(i)) // Если был дан ответ на данный вопрос
        //        {
        //            int? userAnswerIndex = _answersState[i]; // Индекс ответа пользователя
        //            if (userAnswerIndex.HasValue) // Если ответ был выбран
        //            {
        //                string userAnswer = _questions[i].Answers[userAnswerIndex.Value]; // Ответ пользователя
        //                string correctAnswer = _questions[i].CorrectAnswer; // Правильный ответ

        //                if (userAnswer == correctAnswer) // Сравниваем ответы
        //                {
        //                    score++; // Начисляем балл за правильный ответ
        //                }

        //            }
        //        }
        //    }

        //    return score;
        //}
        private int CalculateScore()
        {
            int score = 0;

            for (int i = 0; i < _questions.Count; i++)
            {
                if (_answersState.ContainsKey(i)) // Если был дан ответ на данный вопрос
                {
                    int? userAnswerIndex = _answersState[i]; // Индекс ответа пользователя
                    if (userAnswerIndex.HasValue) // Если ответ был выбран
                    {
                        int correctAnswerIndex = _questions[i].CorrectAnswer; // Номер правильного ответа

                        if (userAnswerIndex.Value == correctAnswerIndex - 1) // Сравниваем ответы
                        {
                            score++; // Начисляем балл за правильный ответ
                        }
                    }
                }
            }

            return score;
        }

        // Завершение теста - отправка баллов в Exel
        private void EndTest()
        {
            string fileName = "Results.xlsx";
            string ResultsName = "Итоговые результаты";
            int totalScore = CalculateScore();
            timer1.Stop();
            double resultScore = (double)totalScore / _questions.Count;
            if (resultScore > 0.7)
            {

                MessageBox.Show($"Ваш результат: {totalScore} из {_questions.Count} баллов." +
                    $" Тест сдан.");
            }
            else
            {

                MessageBox.Show($"Ваш результат: {totalScore} из {_questions.Count} баллов." +
                      $" Тест не сдан.");
            }
            // Дополнительные действия после завершения теста, например, закрытие окна
            this.Close();
            ScoreToExel(fileName, _sheetName, resultScore);
            ScoreToExel2(fileName, ResultsName, resultScore);

        }
        private void Test_FinalButton_Click(object sender, EventArgs e)
        {
            SaveUserAnswer();
            EndTest();

            Application.Exit();
        }
        private void ScoreToExel(string fileName, string sheetName, double resultScore)
        {
            FileInfo existingFile = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName];
                int firstEmptyRow = worksheet.Dimension.End.Row;


                //
                // Цикл по каждому вопросу и ответу
                for (int i = 0; i < _questions.Count; i++)
                {
                    //int? userAnswerIndex = _answersState[i];
                    int? userAnswerIndex = _answersState.ContainsKey(i) ? _answersState[i] : null;
                    // Записываем вопрос в первый столбец
                    worksheet.Cells[firstEmptyRow, 5].Value = _questions[i].Question;

                    if (userAnswerIndex.HasValue)
                    {
                        // Запись выбранного варианта ответа
                        string userAnswer = _questions[i].Answers[userAnswerIndex.Value];

                        if (userAnswerIndex == _questions[i].CorrectAnswer-1)
                        {
                            worksheet.Cells[firstEmptyRow, 6].Value = userAnswer + " + ";
                        }
                        else
                        {
                            worksheet.Cells[firstEmptyRow, 6].Value = userAnswer + " - ";
                        }
                    }

                    firstEmptyRow++;
                }

                //worksheet.Cells[firstEmptyRow - 1, 4].Value = resultScore.ToString("F2"); // ггчт
                worksheet.Cells[firstEmptyRow, 4].Value = Math.Round(resultScore * 100, 2).ToString("F2") + "%";

                package.Save();
            }

        }
        private void ScoreToExel2(string fileName, string ResultsName, double resultScore)
        {
            FileInfo existingFile = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[ResultsName];
                int firstEmptyRow = worksheet.Dimension.End.Row;
                worksheet.Cells[firstEmptyRow, 3].Value = Math.Round(resultScore * 100, 2).ToString("F2") + "%";
                package.Save();
            }
        }

    }

}
