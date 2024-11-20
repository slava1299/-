
using System;
using System.Windows.Forms;

namespace TestApp01
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.Fon = new System.Windows.Forms.Panel();
            this.GroupQuestnBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SpecializationBox = new System.Windows.Forms.ComboBox();
            this.StartTestButton = new System.Windows.Forms.Button();
            this.SHcodeBox = new System.Windows.Forms.TextBox();
            this.FioBox = new System.Windows.Forms.TextBox();
            this.SpecializationText = new System.Windows.Forms.Label();
            this.SHcodeText = new System.Windows.Forms.Label();
            this.FioText = new System.Windows.Forms.Label();
            this.TopFon = new System.Windows.Forms.Panel();
            this.AutorizationText = new System.Windows.Forms.Label();
            this.Fon.SuspendLayout();
            this.TopFon.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fon
            // 
            this.Fon.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Fon.Controls.Add(this.GroupQuestnBox);
            this.Fon.Controls.Add(this.label1);
            this.Fon.Controls.Add(this.SpecializationBox);
            this.Fon.Controls.Add(this.StartTestButton);
            this.Fon.Controls.Add(this.SHcodeBox);
            this.Fon.Controls.Add(this.FioBox);
            this.Fon.Controls.Add(this.SpecializationText);
            this.Fon.Controls.Add(this.SHcodeText);
            this.Fon.Controls.Add(this.FioText);
            this.Fon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fon.Location = new System.Drawing.Point(0, 0);
            this.Fon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fon.Name = "Fon";
            this.Fon.Size = new System.Drawing.Size(693, 539);
            this.Fon.TabIndex = 0;
            this.Fon.Paint += new System.Windows.Forms.PaintEventHandler(this.Fon_Paint);
            // 
            // GroupQuestnBox
            // 
            this.GroupQuestnBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupQuestnBox.FormattingEnabled = true;
            this.GroupQuestnBox.Items.AddRange(new object[] {
            "Общий мониторинг сб",
            "Общий мониторинг монтаж",
            "Общий мониторинг регулировка",
            "Общий мониторинг радиомеханик",
            "Электробезопасность 2 группа",
            "Электробезопасность 3 группа",
            "КД и ТД",
            "СМК и БП",
            "Статика и ОТ"});
            this.GroupQuestnBox.Location = new System.Drawing.Point(201, 314);
            this.GroupQuestnBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupQuestnBox.Name = "GroupQuestnBox";
            this.GroupQuestnBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GroupQuestnBox.Size = new System.Drawing.Size(460, 30);
            this.GroupQuestnBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "Вопросы:";
            // 
            // SpecializationBox
            // 
            this.SpecializationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpecializationBox.FormattingEnabled = true;
            this.SpecializationBox.Items.AddRange(new object[] {
            "Монтажник РЭАиП 2разряда",
            "Монтажник РЭАиП 3разряда",
            "Слесарь-сборщик РЭАиП 2разряда",
            "Слесарь-сборщик РЭАиП 3разряда",
            "Регулировщик РЭАиП 2разряда",
            "Регулировщик РЭАиП 3разряда",
            "Радиомеханик по ремонту радиоэл. оборуд. 2разряда",
            "Радиомеханик по ремонту радиоэл. оборуд. 3разряда",
            "Бригадир",
            "Начальник смены",
            "Сменный мастер ",
            "Наладчик ТО 2 разряда",
            "Инженер по ОИ"});
            this.SpecializationBox.Location = new System.Drawing.Point(201, 242);
            this.SpecializationBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SpecializationBox.Name = "SpecializationBox";
            this.SpecializationBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SpecializationBox.Size = new System.Drawing.Size(460, 30);
            this.SpecializationBox.TabIndex = 10;
            // 
            // StartTestButton
            // 
            this.StartTestButton.AutoSize = true;
            this.StartTestButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StartTestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartTestButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartTestButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.StartTestButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.StartTestButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.StartTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartTestButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StartTestButton.Location = new System.Drawing.Point(0, 457);
            this.StartTestButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartTestButton.Name = "StartTestButton";
            this.StartTestButton.Size = new System.Drawing.Size(693, 82);
            this.StartTestButton.TabIndex = 9;
            this.StartTestButton.Text = "Начать тестирование";
            this.StartTestButton.UseVisualStyleBackColor = false;
            this.StartTestButton.Click += new System.EventHandler(this.StartTestButton_Click);
            // 
            // SHcodeBox
            // 
            this.SHcodeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SHcodeBox.Location = new System.Drawing.Point(201, 178);
            this.SHcodeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SHcodeBox.Name = "SHcodeBox";
            this.SHcodeBox.Size = new System.Drawing.Size(460, 28);
            this.SHcodeBox.TabIndex = 7;
            this.SHcodeBox.TextChanged += new System.EventHandler(this.SHcodeBox_TextChanged);
            // 
            // FioBox
            // 
            this.FioBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FioBox.Location = new System.Drawing.Point(201, 117);
            this.FioBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FioBox.Name = "FioBox";
            this.FioBox.Size = new System.Drawing.Size(460, 28);
            this.FioBox.TabIndex = 6;
            this.FioBox.TextChanged += new System.EventHandler(this.FioBox_TextChanged);
            // 
            // SpecializationText
            // 
            this.SpecializationText.AutoSize = true;
            this.SpecializationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpecializationText.Location = new System.Drawing.Point(12, 242);
            this.SpecializationText.Name = "SpecializationText";
            this.SpecializationText.Size = new System.Drawing.Size(162, 31);
            this.SpecializationText.TabIndex = 12;
            this.SpecializationText.Text = "Должность:";
            this.SpecializationText.Click += new System.EventHandler(this.SpecializationText_Click);
            // 
            // SHcodeText
            // 
            this.SHcodeText.AutoSize = true;
            this.SHcodeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SHcodeText.Location = new System.Drawing.Point(12, 178);
            this.SHcodeText.Name = "SHcodeText";
            this.SHcodeText.Size = new System.Drawing.Size(145, 31);
            this.SHcodeText.TabIndex = 4;
            this.SHcodeText.Text = "Штрихкод:";
            this.SHcodeText.Click += new System.EventHandler(this.SHcodeText_Click);
            // 
            // FioText
            // 
            this.FioText.AutoSize = true;
            this.FioText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FioText.Location = new System.Drawing.Point(12, 117);
            this.FioText.Name = "FioText";
            this.FioText.Size = new System.Drawing.Size(86, 31);
            this.FioText.TabIndex = 3;
            this.FioText.Text = "ФИО:";
            this.FioText.Click += new System.EventHandler(this.FioText_Click);
            // 
            // TopFon
            // 
            this.TopFon.BackColor = System.Drawing.Color.PapayaWhip;
            this.TopFon.Controls.Add(this.AutorizationText);
            this.TopFon.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.TopFon.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopFon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TopFon.Location = new System.Drawing.Point(0, 0);
            this.TopFon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TopFon.Name = "TopFon";
            this.TopFon.Size = new System.Drawing.Size(693, 82);
            this.TopFon.TabIndex = 1;
            // 
            // AutorizationText
            // 
            this.AutorizationText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AutorizationText.Cursor = System.Windows.Forms.Cursors.Default;
            this.AutorizationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutorizationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutorizationText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AutorizationText.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AutorizationText.Location = new System.Drawing.Point(0, 0);
            this.AutorizationText.Name = "AutorizationText";
            this.AutorizationText.Size = new System.Drawing.Size(693, 82);
            this.AutorizationText.TabIndex = 2;
            this.AutorizationText.Text = "Авторизация";
            this.AutorizationText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AutorizationText.Click += new System.EventHandler(this.AutorizationText_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 539);
            this.Controls.Add(this.TopFon);
            this.Controls.Add(this.Fon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Тестирование";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Fon.ResumeLayout(false);
            this.Fon.PerformLayout();
            this.TopFon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       


        #endregion

        private System.Windows.Forms.Panel Fon;
        private System.Windows.Forms.Panel TopFon;
        private System.Windows.Forms.Label AutorizationText;
        private System.Windows.Forms.Label SHcodeText;
        private System.Windows.Forms.Label FioText;
        private System.Windows.Forms.Label SpecializationText;
        private System.Windows.Forms.TextBox SHcodeBox;
        private System.Windows.Forms.TextBox FioBox;
        private System.Windows.Forms.Button StartTestButton;
        private ComboBox SpecializationBox;
        private Label label1;
        private ComboBox GroupQuestnBox;
    }
}