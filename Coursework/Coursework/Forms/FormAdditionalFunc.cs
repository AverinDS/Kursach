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
            StatusOfNetwork.Text = "Состояние сети: проверка...";
            tracking.updateStandart();
            StatusOfUpdatingStandarts.Text = "Курс валют: " + tracking.dollar + tracking.euro + "  Данные от " + DateTime.Now.ToString();
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
                RedistributionLabel.Text = "Последнее перераспределение товара: " + DateTime.Now.ToString();
            }
            catch { }
        }
    }

       
}
