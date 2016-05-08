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
        int WidthOfLabels = 200;
        int idOfDeletingOrEditing;
        string entity = "";
        string process = "";
        string[] rules;
        bool cancel = false;
       // bool IsEdit, IsDelete;


        Label[] labels = new Label[6];
        TextBox[] texboxs = new TextBox[6];
        Button buttonOk = new Button();
        Button buttonCancel = new Button();
        Button buttonRules = new Button();
        
        Label[] labels2;//это для отражения записи Если товара с id =... осталось ...
        TextBox[] texbox2;//
        Label[] labels3;

        /* public int setting
         {
             set { this.value = value; }
         }*/

        public string ChooseProcess
        {
            set { this.process = value; }
        }

        public int GettingId
        {
            get { return this.idOfDeletingOrEditing; }
        }

        public bool GettingCancel
        {
            get { return this.cancel; }
        }

        public FormForRecords(string s)//пытаюсь создавать динамически поля (чтобы не городить множество форм)
        {
            //IsDelete = false;
            //IsEdit = false;
            entity = s;
            cancel = false;
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
                        labels[5].Text = "id филиала(склада)";


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
                            reader.Close();



                        }

                        labels2 = new Label[value];//это для отражения записи Если товара с id =... осталось ...
                        texbox2 = new TextBox[value];
                        labels3 = new Label[value];
                        labels = new Label[value];
                        texboxs = new TextBox[value];


                        for (int i = 0; i < value; i++)
                        {
                            labels[i] = new Label();
                            labels[i].Location = new Point(X0, Y0);
                            labels[i].Text = "Если товара с id = ";
                            labels[i].Width = WidthOfLabels;

                            texboxs[i] = new TextBox();
                            texboxs[i].Location = new Point(X0 + WidthOfLabels, Y0);
                            texboxs[i].Width = WidthOfLabels;

                            labels2[i] = new Label();
                            labels3[i] = new Label();


                            labels2[i].Text = " осталось ";
                            labels2[i].Width = WidthOfLabels;
                            labels2[i].Location = new Point(X0 + 2 * WidthOfLabels, Y0);

                            texbox2[i] = new TextBox();
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
                        buttonOk.Text = "Сохранение";
                        buttonOk.Name = "buttonOk";
                        this.Controls.Add(buttonOk);

                        buttonCancel.Location = new Point(X0, Y0);
                        buttonCancel.Text = "Отмена";
                        buttonCancel.Name = "buttonCancel";
                        this.Controls.Add(buttonCancel);

                        buttonRules.Location = new Point(X0 + 2 * WidthOfLabels, Y0);
                        buttonRules.Text = "Добавить ещё строку для правила";
                        buttonRules.Width =  WidthOfLabels;
                        buttonRules.Name = "buttonRules";
                        this.Controls.Add(buttonRules);

                        Button buttonStart = new Button();//для правил
                        buttonStart.Text = "Запуск свода правил";
                        buttonStart.Click += new EventHandler(buttonStart_Click);
                        buttonStart.Width = WidthOfLabels;
                        buttonStart.Location = new Point(X0 + 4 * WidthOfLabels, Y0);
                        this.Controls.Add(buttonStart);
                         
                        value1 = value;
                        break;


                    }
                case "edit":
                case "delete":
                    {
                        value = 1;
                        labels[0].Text = "Введите ID искомой записи:";
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
            }

        }

        public void Edit(string id)
        {
            WorkWithDatabase DB = new WorkWithDatabase();
            string information = "";
            switch (entity)
            {
                case "product": { information = DB.GettingInfo("product", "id = " + id.ToString()); break; }
                case "provider": { information = DB.GettingInfo("provider", "id = " + id.ToString()); break; }
                case "sale": { information = DB.GettingInfo("sale", "id = " + id.ToString()); break; }
                case "manager": { information = DB.GettingInfo("manager", "id = " + id.ToString()); break; }
                case "storage": { information = DB.GettingInfo("storage", "id = " + id.ToString()); break; }
            }
            for (int i = 0; i < value; i++)//в теории должно заполнять texboxы
            {
                texboxs[i].Text = information.Substring(0, information.IndexOf(' '));
                information = information.Remove(0, information.IndexOf(' ') - 1);
            }
        }

        private void FormForRecords_Load(object sender, EventArgs e)
        {
          

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("");
            Redistribution redistr = new Redistribution();
            redistr.BeginRedistribution();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
                if (process == "edit" || process == "delete")//проверка при вводе на число(работает при удалении или редактировании записи)
            {
                try
                {
                    idOfDeletingOrEditing = int.Parse(texboxs[0].Text);
                    //process = "";//мега костыль
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Неверный формат ввода");
                    return;
                }
            }
               
             switch (entity)
            {
                case "redistribution":
                    {
                        bool checkEmpty = false;

                        for (int i = 0; i < value; i++)//цикл проверки введённых данных в текстбоксах
                        {
                            texboxs[i].Text = texboxs[i].Text.Replace(' ', '_');
                            try
                            {
                                int.Parse(texboxs[i].Text);
                                int.Parse(texboxs[i].Text);
                            }
                            catch
                            {
                                checkEmpty = true;
                            }
                            if (texboxs[i].Text == "" || texbox2[i].Text == "")
                            {
                                checkEmpty = true;
                                break;

                            }
                        }
                        if (!checkEmpty)
                        {
                            buttonRules.Enabled = true;
                            StreamWriter write = new StreamWriter(@"E:/rules.txt");
                            for (int i = 0; i < value; i++)
                            {
                                try
                                {
                                    if (texboxs[i].Text != "" && texbox2[i].Text != "")
                                    {
                                        write.WriteLine(texboxs[i].Text + " " + texbox2[i].Text);
                                    }
                                }
                                catch { }
                            }
                            write.Close();
                            Redistribution redistr = new Redistribution();
                            
                        }
                        else
                        {
                            MessageBox.Show("Заполнены не все поля или неверный формат ввода, правила не сохранены");
                        }
                        break;
                    }
                case "product":
                    {
                        try //так же включает в себя проверку на заполненность всех полей
                        {
                            value = 4;
                            string[] query = new string[value];
                            for (int i = 0; i < value; i++)
                            {
                                texboxs[i].Text = texboxs[i].Text.Replace(' ', '_');
                                query[i] = texboxs[i].Text;
                                if (query[i] == "") { throw new System.ArgumentException("Не заполнены некоторые поля"); }
                            }

                            WorkWithDatabase DB = new WorkWithDatabase();//проверка существования вписанных внешних ключей
                            string s = DB.GettingInfo("provider", "id = " + texboxs[3].Text);

                            if (s == "") { throw new Exception("Не существует такого производителя"); }

                            double.Parse(texboxs[2].Text);
                            int.Parse(texboxs[0].Text + texboxs[3].Text);
                            InsertOrUpdate();
                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            
                        }
                        break;
                    }

                case "provider":
                    {
                        try //так же включает в себя проверку на заполненность всех полей
                        {
                            value = 3;
                            string[] query = new string[value];
                            for (int i = 0; i < value; i++)
                            {
                                texboxs[i].Text = texboxs[i].Text.Replace(' ', '_');
                                query[i] = texboxs[i].Text;
                                if (query[i] == "") { throw new System.ArgumentException("Не заполнены некоторые поля"); }
                            }
                            int.Parse(texboxs[0].Text);
                            texboxs[2].Text = texboxs[2].Text.ToLower();
                            if (texboxs[2].Text != "rub" && texboxs[2].Text != "eur" && texboxs[2].Text != "usd")
                                throw new Exception("Неверная валюта. Необходимо ввести rub eur или usd");  
                            InsertOrUpdate();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }

                case "sale":
                    {
                        try //так же включает в себя проверку на заполненность всех полей
                        {
                            value = 6;
                            string[] query = new string[value];
                            for (int i = 0; i < value; i++)
                            {
                                texboxs[i].Text = texboxs[i].Text.Replace(' ', '_');
                                query[i] = texboxs[i].Text;
                                if (query[i] == "") { throw new System.ArgumentException("Не заполнены некоторые поля"); }
                                if (i != 1) int.Parse(texboxs[i].Text);
                                else
                                {
                                    texboxs[i].Text = DateTime.Parse(texboxs[i].Text).ToString();
                                    texboxs[i].Text = texboxs[i].Text.Remove(texboxs[i].Text.IndexOf(' '), 8);
                                    
                                   
                                }
                            }

                            WorkWithDatabase DB = new WorkWithDatabase();
                            string s = DB.GettingInfo("product", "id = " + texboxs[3].Text);
                            if (s == "") { throw new Exception("Не существует такого товара!"); }

                            s = DB.GettingInfo("manager", "id = " + texboxs[4].Text);
                            if (s == "") { throw new Exception("Не существует такого менеджера!"); }

                            s = DB.GettingInfo("storage", "id = " + texboxs[5].Text);
                            if (s == "") { throw new Exception("Не существует такого склада!"); }

                            InsertOrUpdate();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                case "storage":
                case "manager": {
                        try //так же включает в себя проверку на заполненность всех полей
                        {
                            value = 2;
                            string[] query = new string[value];
                            for (int i = 0; i < value; i++)
                            {
                                texboxs[i].Text = texboxs[i].Text.Replace(' ', '_');
                                query[i] = texboxs[i].Text;
                                if (query[i] == "") { throw new System.ArgumentException("Не заполнены некоторые поля"); }
                            }
                            int.Parse(texboxs[0].Text);
                            InsertOrUpdate();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
               
                       
                   
            }
        }
        private void InsertOrUpdate()
        {
            switch (process)
            {
                case "insert":
                    {
                        try
                        {
                            WorkWithDatabase DB = new WorkWithDatabase();

                            if (entity == "sale")
                            {//получение информации по складу
                                string info = DB.GettingInfo("storage", "ID = " + texboxs[5].Text);
                                info = DB.GettingInfo("balance", "StorageID = " + info.Substring(0, info.IndexOf(' ')) + " AND ProductID =" + texboxs[3].Text);//получение ID сущности Склад-товар-остаток
                                if (info == "") throw new Exception("Не существует искомой сущности. Вы проводили перераспределение товаров?");

                                string value = info;//проверка на достаточность товара
                                value = value.Remove(0, value.IndexOf(' ')+1);
                                value = value.Substring(0, value.IndexOf(' '));
                                int value2 = int.Parse(value);
                                if (int.Parse(texboxs[2].Text) <= 0) throw new Exception("Количество товара не может быть меньше или равна нулю!");
                                if (value2 - int.Parse(texboxs[2].Text) < 0) throw new Exception("Нехватка товара на складе. Невозможно выполнить продажу такого количества.Необходимо выполнить перераспределение. Операция прервана. ");
                               
                                DB.InsertInDB(entity, texboxs[0].Text, texboxs[1].Text, texboxs[2].Text, texboxs[3].Text, texboxs[4].Text, info.Substring(0, info.IndexOf(' ')));
                            }
                            else
                            {
                                //также при создании товара или склада, нужно создавать новую сущность balance
                                switch (entity)
                                {
                                    case "product":
                                        {
                                            string allId = DB.Getting_id("storage");
                                            while(allId != "")
                                            {
                                                string idStorage = "";
                                              
                                                idStorage = allId.Substring(0, allId.IndexOf(' '));
                                                DB.InsertInDB("balance", (int.Parse(DB.GettingMaxId("balance"))+1).ToString(),"0", texboxs[0].Text, idStorage,"","");

                                                allId = allId.Remove(0, allId.IndexOf(' ')+1);
                                            }

                                            break;
                                        }
                                    case "storage":
                                        {
                                            string allId = DB.Getting_id("product");
                                            while (allId != "")
                                            {
                                                string idProduct = "";

                                                idProduct = allId.Substring(0, allId.IndexOf(' '));
                                                DB.InsertInDB("balance", (int.Parse(DB.GettingMaxId("balance")) + 1).ToString(), "0", idProduct, texboxs[0].Text, "", "");

                                                allId = allId.Remove(0, allId.IndexOf(' ') + 1);
                                            }
                                            break;
                                        }
                                }

                                DB.InsertInDB(entity, texboxs[0].Text, texboxs[1].Text, texboxs[2].Text, texboxs[3].Text, texboxs[4].Text, texboxs[5].Text);
                            }

                            MessageBox.Show("Успешно выполнено!");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!" + ex.Message );
                        }
                        break;

                    }
                case "edit":
                    {
                        try
                        {
                            WorkWithDatabase DB = new WorkWithDatabase();
                            switch (entity)
                            {
                                case "product":
                                    {
                                        DB.UpdateDB(entity, "name", texboxs[1].Text, texboxs[0].Text);
                                        DB.UpdateDB(entity, "price", texboxs[2].Text, texboxs[0].Text);
                                        DB.UpdateDB(entity, "ProviderID", texboxs[3].Text, texboxs[0].Text);
                                        break;
                                    }
                                case "provider":
                                    {
                                        DB.UpdateDB(entity, "name", texboxs[1].Text, texboxs[0].Text);    
                                        DB.UpdateDB(entity, "Currensy", texboxs[2].Text, texboxs[0].Text); 
                                        break;
                                    }
                                case "sale":
                                    {
                                        DB.UpdateDB(entity, "date", texboxs[1].Text, texboxs[0].Text);
                                        DB.UpdateDB(entity, "count", texboxs[2].Text, texboxs[0].Text);
                                        DB.UpdateDB(entity, "ProductID", texboxs[3].Text, texboxs[0].Text);
                                        DB.UpdateDB(entity, "ManagerID", texboxs[4].Text, texboxs[0].Text);
                                        DB.UpdateDB(entity, "BalanceID", texboxs[5].Text, texboxs[0].Text);
                                        break;
                                    }
                                case "manager":
                                    {
                                        DB.UpdateDB(entity, "FIO", texboxs[1].Text, texboxs[0].Text);
                                        break;
                                    }
                                case "storage":
                                    {
                                        DB.UpdateDB(entity, "Adress", texboxs[1].Text, texboxs[0].Text);
                                        break;
                                    }
                            }
                    
                            MessageBox.Show("Успех!");
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка ввода");
                        }
                        break;
                    }
            }
        }
        public void GetInformationForInserting(string id)
        {
            WorkWithDatabase DB = new WorkWithDatabase();
            string value = DB.GettingInfo(entity, "id =" + id);
            if( value =="")
            {
                MessageBox.Show("Записи не найдено");
                cancel = true;
                return;
            }
            int i = 0;
            while (value != "")
            {
                texboxs[i].Text = value.Substring(0, value.IndexOf(' '));
                value = value.Remove(0, value.IndexOf(' ')+1);
                i++;
            }
            texboxs[0].Enabled = false;


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }

        private void FormForRecords_FormClosing(object sender, FormClosingEventArgs e)
        {
           // cancel = true;
        }

        private void buttonRules_Click(object sender, EventArgs e)
        {

            bool checkEmpty = false;

            for (int i = 0; i < value; i++)
            {
                if (texboxs[i].Text == "" || texbox2[i].Text == "")
                {
                    checkEmpty = true;
                    break;

                }
            }
            if (!checkEmpty)
            {
                buttonRules.Enabled = false;
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
                for (int i = 0; i < value1; i++)//восстановление данных в textboxы
                {
                    string[] items = new string[2];
                    items = rules[i].Split(' ');
                    texboxs[i].Text = items[0];
                    texbox2[i].Text = items[1];
                }

                StreamReader read = new StreamReader(@"E:/rules.txt");
                string line = "";
                int j = 0;

                while ((line = read.ReadLine()) != null)//обновляем данные из файла
                {
                    string[] items = new string[2];
                    items = line.Split(' ');
                    texboxs[j].Text = items[0];
                    texbox2[j].Text = items[1];
                    j++;
                }

                read.Close();

                buttonOk.Location = new Point(X0, Y0);
                buttonCancel.Location = new Point(X0 + WidthOfLabels, Y0);
                buttonRules.Location = new Point(X0 + 2 * WidthOfLabels, Y0);
                this.Controls.Add(buttonOk);
                this.Controls.Add(buttonCancel);
                this.Controls.Add(buttonRules);
            }
            else
            {
                MessageBox.Show("Не заполнено по крайней мере одно поле");
            }
        }
        
       // public void Add()
        //{
        //    WorkWithDatabase DB = new WorkWithDatabase();
        //    try
        //    {
        //        DB.InsertInDB(entity, texboxs[0].Text, texboxs[1].Text, texboxs[2].Text, texboxs[3].Text, texboxs[4].Text, texboxs[5].Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

    }
}
    
