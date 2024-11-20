using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp01
{
    public partial class TestEndForm : Form
    {
        public TestEndForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(TestEndForm_FormClosing); //Подписка на событие FormClosing
           
        }
       
        private void TestEndForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) //Проверка свойства CloseReason.
                                                          //Если значение равно UserClosing, значит закрыта форма вручную
            {
                Application.Exit(); //метод завершает работу всего приложения
            }
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            
         Application.Exit(); 
            
        }
    }
}
