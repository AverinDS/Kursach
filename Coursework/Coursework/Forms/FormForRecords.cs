using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework.Forms
{
    public partial class FormForRecords : Form
    {
        int X0 = 10;
        int Y0 = 10;
        int value = 0;//переменная для количества полей
        int WidthOfLabels = 100;


        Label[] labels = new Label[5];
        TextBox[] texboxs = new TextBox[5];
        Button buttonOk = new Button();
        
       
        public FormForRecords(string s)//пытаюсь создавать динамически поля (чтобы не городить множество форм)
        {
            InitializeComponent();
            this.AutoSize = true;
            buttonOk.Click += new EventHandler(buttonOk_Click);

            for (int i = 0; i < 5; i++)
            {
                labels[i] = new Label();
                labels[i].Width = WidthOfLabels;
                texboxs[i] = new TextBox();
                texboxs[i].Width = WidthOfLabels;
            }

            switch (s)
            {
                case "product":
                    {
                        value = 4;
                        labels[0].Text = "ID";
                        labels[1].Text = "Наименование товара";
                        labels[2].Text = "Цена товара";
                        labels[3].Text = "ID поставщика";

                        for (int i = 0; i < value; i++)
                        {
                            labels[i].Location = new Point(X0, Y0);
                            texboxs[i].Location = new Point(X0 + WidthOfLabels, Y0);
                            Y0 += 30;
                            this.Controls.Add(labels[i]);
                            this.Controls.Add(texboxs[i]);
                        }


                        buttonOk.Location = new Point(X0 + WidthOfLabels, Y0);
                        buttonOk.Text = "Ok";
                        buttonOk.Name = "buttonOk";
                        this.Controls.Add(buttonOk);
                        break;
                    }
                case "provider": { break; }
                case "sale": { break; }
                case "manager": { break; }
                case "storage": { break; }
            }

        }

        private void FormForRecords_Load(object sender, EventArgs e)
        {

        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
