using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Net.NetworkInformation;
using System.Threading;
using Coursework.Forms;
using System.IO;

namespace Coursework.Forms
{
    public partial class FormAdditionalFunc : Form
    {
        TrackingStandart tracking = new TrackingStandart();
        Redistribution redistribution = new Redistribution();

        public FormAdditionalFunc()
        {
            InitializeComponent();
        }
       
       
        private void FormAdditionalFunc_Load(object sender, EventArgs e)
        {
            WorkWithEmail Email = new WorkWithEmail();
            if (!Email.CheckingInternet())
            {
                MessageBox.Show("Ошибка подключения к Интернету. Некоторый функционал может быть недоступен");
                StatusOfNetwork.Text = "Состояние сети: Ошибка подключения";
            }
            else
            {
                StatusOfNetwork.Text = "Состояние сети: Подключено";
            }
           // StatusOfNetwork.Text = "Состояние сети: проверка...";
            tracking.updateStandart();
            if (!Email.CheckingInternet())
            {
                StatusOfUpdatingStandarts.Text = "Курс валют: " + tracking.dollar + tracking.euro + "  Данные от: Неизвестно";
            }
            else {
                StatusOfUpdatingStandarts.Text = "Курс валют: " + tracking.dollar + tracking.euro + "  Данные от: " + tracking.date.ToString();
            }
                string last = "";
            if (File.Exists(@"E:\lastredistribution.txt"))
            {
                StreamReader read = new StreamReader(@"E:\lastredistribution.txt");
                last = read.ReadLine();
                read.Close();
            }
            else
            { last = "неизвестно"; }
            RedistributionLabel.Text = "Последнее перераспределение товаров: " + last;
            //TimerCheckingNetWork.Start();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tracking.updateStandart();
            StatusOfUpdatingStandarts.Text = "Курс валют: " + tracking.dollar + tracking.euro + "  Данные от " + DateTime.Now.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormForRecords formForRecords = new FormForRecords("redistribution");
            try
            {
                formForRecords.ShowDialog();
                string last = "";
                if (File.Exists(@"E:\lastredistribution.txt"))
                {
                    StreamReader read = new StreamReader(@"E:\lastredistribution.txt");
                    last = read.ReadLine();
                    read.Close();
                }
                else
                { last = "неизвестно"; }
                RedistributionLabel.Text = "Последнее перераспределение товаров: " + last;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            WorkWithEmail em = new WorkWithEmail();
            em.CheckingInternet();
            if (!em.CheckingInternet())
            {
                
                StatusOfNetwork.Text = "Состояние сети: Ошибка подключения";
            }
            else
            {
                StatusOfNetwork.Text = "Состояние сети: Подключено";
            }
        }

      
    }

       
}
