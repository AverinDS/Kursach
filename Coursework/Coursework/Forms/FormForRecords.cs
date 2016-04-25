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
        int X01 = 10;
        int X0 = 10;
        int Y01 = 10;
        int Y0 = 10;
        int value = 0;//переменная для количества полей
        int value1 = 0;
        int WidthOfLabels = 150;
        string entity = "";
        string[] rules;


        Label[] labels = new Label[6];
        TextBox[] texboxs = new TextBox[6];
        Button buttonOk = new Button();
        Button buttonCancel = new Button();
        Button buttonRules = new Button();
        Label[] labels2;//это для отражения записи Если товара с id =... осталось ...
        TextBox[] texbox2 ;
        Label[] labels3;

        public int setting
        {
            set { this.value = value; }
        }

        public FormForRecords(string s)//пытаюсь создавать динамически поля (чтобы не городить множество форм)
        {
            entity = s;
            InitializeComponent();
            this.AutoSize = true; ;
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
                case "provider":
                    {
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
                case "sale":
                    {
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
                case "manager":
                    {
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
                case "storage":
                    {
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


                            while ((line = reader.ReadLine()) != null)
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

                            labels3[i].Width = 2 * WidthOfLabels;
                            labels3[i].Location = new Point(X0 + 4 * WidthOfLabels, Y0);
                            labels3[i].Text = " то запустить процедуру перераспределения товаров";

                            Y0 += 30;
                            try
                            {
                                string[] items = new string[2];
                                items = rules[i].Split(' ');
                                texboxs[i].Text = items[0];
                                texbox2[i].Text = items[1];
                                int.Parse(items[0]);
                                int.Parse(items[1]);

                            }
                            catch
                            {
                                MessageBox.Show("Файл правил повреждён или имеет неверный формат. Операция будет прервана");
                                this.Close();
                            }


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

                        buttonRules.Location = new Point(X0 + 2 * WidthOfLabels, Y0);
                        buttonRules.Text = "Добавить ещё строку для правила";
                        buttonRules.Width = 2*WidthOfLabels;
                        buttonRules.Name = "buttonRules";
                        this.Controls.Add(buttonRules);
                        value1 = value;
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
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonRules_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            value++;
            texboxs = new TextBox[value];//увеличивается value и пересоздается массив texboxов
            texbox2 = new TextBox[value];
            labels = new Label[value];
            labels2 = new Label[value];
            labels3 = new Label[value];

            for (int i = 0; i < value; i++)
            {
                texboxs[i] = new TextBox();
                texbox2[i] = new TextBox();
                labels[i] = new Label();
                labels2[i] = new Label();
                labels3[i] = new Label();
                
            }

            
            X0 = X01;
            Y0 = Y01;
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

                    labels3[i].Width = 2 * WidthOfLabels;
                    labels3[i].Location = new Point(X0 + 4 * WidthOfLabels, Y0);
                    labels3[i].Text = " то запустить процедуру перераспределения товаров";

                    Y0 += 30;
                
                    this.Controls.Add(labels[i]);
                    this.Controls.Add(labels2[i]);
                    this.Controls.Add(labels3[i]);
                    this.Controls.Add(texboxs[i]);
                    this.Controls.Add(texbox2[i]);
              
                }
                for (int i = 0; i < value1; i++)
            {
                string[] items = new string[2];
                items = rules[i].Split(' ');
                texboxs[i].Text = items[0];
                texbox2[i].Text = items[1];
            }

           
            buttonOk.Location = new Point(X0, Y0);
            buttonCancel.Location = new Point(X0 + WidthOfLabels, Y0);
            buttonRules.Location = new Point(X0+ 2 * WidthOfLabels, Y0);
            this.Controls.Add(buttonOk);
            this.Controls.Add(buttonCancel);
            this.Controls.Add(buttonRules);
        }
    }
}
