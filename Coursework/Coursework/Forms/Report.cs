using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;



namespace Coursework.Forms
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeReportIntoFile report = new MakeReportIntoFile();
            if(!File.Exists(@"E:\a1.xls"))
            {
                MessageBox.Show("Сначала необходимо создать файл Excell!");
            }
            if (radioButton1.Checked == true)//товар
            {
                report.Diagram(1);
            }
            if (radioButton2.Checked == true)//поставшик
            {
                report.Diagram(2);
            }
            if (radioButton3.Checked == true)//Филиал
            {
                report.Diagram(3);
            }
            if (radioButton4.Checked == true)//Менеджер
            {
                report.Diagram(4);
            }
            Bitmap bm = new Bitmap(PB1.Width,PB1.Height);
            Graphics gr = Graphics.FromImage(bm);
            gr = Graphics.FromImage(bm);
            gr.CopyFromScreen(420, 380, 0, 0, bm.Size);
            PB1.Image = bm;

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            
            MakeReportIntoFile report = new MakeReportIntoFile();
            report.ExcellMaker();

        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkWithEmail email = new WorkWithEmail();
            if (email.CheckingInternet())
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //foreach(string i in fileDialog.FileNames)
                    //{
                    string line = fileDialog.FileName;
                    email.SendMail("Отчёты с центральной системы автоматизации сети розничных магазинов", "Отчет, отправленный " + DateTime.Now.ToString(), fileDialog.FileName);

                }
            }
            else
            {
                MessageBox.Show("Нет подключения к интернету.");
            }
              
        }
    }
}
