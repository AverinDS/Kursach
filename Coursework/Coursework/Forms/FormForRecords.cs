using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Coursework.Forms
{
    public partial class FormForRecords : Form
    {
        int X0 = 10;
        int Y0 = 10;
        int value = 0;//переменная для количества полей
        int WidthOfLabels = 150;
        string entity = "";
        string[] rules;

       
        Label[] labels = new Label[6];
        TextBox[] texboxs = new TextBox[6];
        Button buttonOk = new Button();
        Button buttonCancel = new Button();
        Button buttonRules = new Button();
        
       
        public FormForRecords(string s)//пытаюсь создавать динамически поля (чтобы не городить множество форм)
        {
            entity = s;
            InitializeComponent();
            this.AutoSize = true;
            buttonOk.Click += new EventHandler(buttonOk_Click);
            buttonCancel.Click += new EventHandler(buttonCancel_Click);
            buttonRules.Click += new EventHandler(buttonRules_Click);

            for (int i = 0; i < 6; i++)
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

                        buttonCancel.Location = new Point(X0, Y0);
                        buttonCancel.Text = "Cancel";
                        buttonCancel.Name = "buttonCancel";
                        this.Controls.Add(buttonCancel);
                        break;
                    }
                case "provider": {
                        value = 3;
                        labels[0].Text = "ID";
                        labels[1].Text = "Наименование производителя";
                        labels[2].Text = "Валюта торговли";
                       

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

                        buttonCancel.Location = new Point(X0, Y0);
                        buttonCancel.Text = "Cancel";
                        buttonCancel.Name = "buttonCancel";
                        this.Controls.Add(buttonCancel);

                        break;
                    }
                case "sale": {
                        value = 6;
                        labels[0].Text = "ID";
                        labels[1].Text = "Дата продажи";
                        labels[2].Text = "Количество";
                        labels[3].Text = "id или наименование товара";
                        labels[4].Text = "id или ФИО менеджера";
                        labels[5].Text = "id склад-товар-остаток";


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

                        buttonCancel.Location = new Point(X0, Y0);
                        buttonCancel.Text = "Cancel";
                        buttonCancel.Name = "buttonCancel";
                        this.Controls.Add(buttonCancel);

                        break;
                    }
                case "manager": {
                        value = 2;
                        labels[0].Text = "ID";
                        labels[1].Text = "ФИО";
                        

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

                        buttonCancel.Location = new Point(X0, Y0);
                        buttonCancel.Text = "Cancel";
                        buttonCancel.Name = "buttonCancel";
                        this.Controls.Add(buttonCancel);

                        break;
                    }
                case "storage": {
                        value = 2;
                        labels[0].Text = "ID";
                        labels[1].Text = "Адрес";
                       


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

                        buttonCancel.Location = new Point(X0, Y0);
                        buttonCancel.Text = "Cancel";
                        buttonCancel.Name = "buttonCancel";
                        this.Controls.Add(buttonCancel);

                        break;
                    }
                case "redistribution":
                    {
                        if (!File.Exists(@"E:/rules.txt"))
                        {
                            value = 1;
                        }
                        else
                        {
                            value = 0;
                           
                            string line = "";
                            StreamReader reader = new StreamReader(@"E:/rules.txt");
                           

                            while (( line = reader.ReadLine())!= null )
                            {
                                value++;//считаем количество правил, уже существующих 
                               
                            }

                            reader.Close();

                            reader = new StreamReader(@"E:/rules.txt");
                            rules = new string[value];
                            value = 0;
                            while ((line = reader.ReadLine()) != null)
                            {
                                rules[value] = line;
                                value++;//считаем количество правил, уже существующих 

                            }

                        }

                        Label[] labels2 = new Label[value];//это для отражения записи Если товара с id =... осталось ...
                        TextBox[] texbox2 = new TextBox[value];
                        Label[] labels3 = new Label[value];

                        for (int i = 0; i < value; i++)
                        {
                           
                            labels[i].Location = new Point(X0, Y0);
                            labels[i].Text = "Если товара с id = ";
                            labels[i].Width = WidthOfLabels;

                            texboxs[i].Location = new Point(X0 + WidthOfLabels, Y0);
                            texboxs[i].Width = WidthOfLabels;

                            labels2[i] = new Label();
                            labels3[i] = new Label();
                            texbox2[i] = new TextBox();

                            labels2[i].Text = " осталось ";
                            labels2[i].Width = WidthOfLabels;
                            labels2[i].Location = new Point(X0 + 2 * WidthOfLabels, Y0);

                            texbox2[i].Width = WidthOfLabels;
                            texbox2[i].Location = new Point(X0 + 3 * WidthOfLabels, Y0);

                            labels3[i].Width = 2*WidthOfLabels;
                            labels3[i].Location = new Point(X0 + 4 * WidthOfLabels, Y0);
                            labels3[i].Text = " то запустить процедуру перераспределения товаров";

                            Y0 += 30;
                            this.Controls.Add(labels[i]);
                            this.Controls.Add(labels2[i]);
                            this.Controls.Add(labels3[i]);
                            this.Controls.Add(texboxs[i]);
                            this.Controls.Add(texbox2[i]);
                        }


                        buttonOk.Location = new Point(X0 + WidthOfLabels, Y0);
                        buttonOk.Text = "Ok";
                        buttonOk.Name = "buttonOk";
                        this.Controls.Add(buttonOk);

                        buttonCancel.Location = new Point(X0, Y0);
                        buttonCancel.Text = "Cancel";
                        buttonCancel.Name = "buttonCancel";
                        this.Controls.Add(buttonCancel);
                        break;

                        
                    }
            }

        }

        private void FormForRecords_Load(object sender, EventArgs e)
        {
           

        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();//ИЗМЕНИТЬ
        }
        private void buttonCancel_Click (object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonRules_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
