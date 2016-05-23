using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using Coursework.Forms;

namespace Coursework
{
    public partial class Form1 : Form
    {
        WorkWithDatabase WorkerDatabase = new WorkWithDatabase();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WorkerDatabase.CreatingOrFindingTable();
            dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("sale");
            


            /*if (!File.Exists(@"E:\Database.sqlite"))//попытка найти БД. если её нет, создаём новую
            {
                SQLiteConnection.CreateFile(@"E:\Database.sqlite");
                SQLiteConnection connect = new SQLiteConnection(@"Data Source = E:\Database.sqlite; Version = 3");
                connect.Open();
                SQLiteCommand command = new SQLiteCommand(
                    "create table product(id integer primary key, name varchar(20), price real, id_provider integer) ", connect);
                command.ExecuteNonQuery();
                command = new SQLiteCommand(
                    "create table provider(id integer primary key, name varchar(20), currency varchar(4)) ", connect);
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("File of database not found. New file was create");
            }*/

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormForRecords f = null;// в зависимости от передаваемого слова в форму генерируется нужное число полей

            if (radioProduct.Checked == true)
            f = new FormForRecords("product");

            if (radioManager.Checked == true)
                f = new FormForRecords("manager");

            if (radioProvider.Checked == true)
                f = new FormForRecords("provider");

            if (radioSale.Checked == true)
                f = new FormForRecords("sale");

            if (radioStorage.Checked == true)
                f = new FormForRecords("storage");
            f.ChooseProcess = "insert";
            f.ShowDialog();
            UpdatingGrid();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormForRecords f = null;// в зависимости от передаваемого слова в форму генерируется нужное число полей

            f = new FormForRecords("edit");
            f.ChooseProcess = "edit";
            f.ShowDialog();
            int id = f.GettingId;

            if (!f.GettingCancel)
            {
                if (radioProduct.Checked == true)
                    f = new FormForRecords("product");

                if (radioManager.Checked == true)
                    f = new FormForRecords("manager");

                if (radioProvider.Checked == true)
                    f = new FormForRecords("provider");

                if (radioSale.Checked == true)
                    f = new FormForRecords("sale");

                if (radioStorage.Checked == true)
                    f = new FormForRecords("storage");
                f.ChooseProcess = "edit";
                f.GetInformationForInserting(id.ToString());

                if (!f.GettingCancel)
                {
                    f.ShowDialog();
                }
            }
            UpdatingGrid();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            FormForRecords f = new FormForRecords("delete");
            f.ChooseProcess = "delete";
            f.ShowDialog();
           
            int id = f.GettingId;
            WorkWithDatabase DB = new WorkWithDatabase();
            try
            {
                if (!f.GettingCancel)
                {
                    if (radioProduct.Checked == true)
                        DB.DeleteFromDB("product", "ID ="+id.ToString());

                    if (radioManager.Checked == true)
                        DB.DeleteFromDB("manager", "ID ="+id.ToString());

                    if (radioProvider.Checked == true)
                        DB.DeleteFromDB("provider", "ID ="+id.ToString());

                    if (radioSale.Checked == true)
                        DB.DeleteFromDB("sale", "ID ="+id.ToString());

                    if (radioStorage.Checked == true)
                        DB.DeleteFromDB("storage", "ID =" + id.ToString());
                    MessageBox.Show("Успех");
                }
            }
            catch { MessageBox.Show("Ошибка, данная запись действительно существует?"); }
            UpdatingGrid();
        }

        private void radioSale_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("sale");
        }

        private void radioProduct_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("product");
        }

        private void radioProvider_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("provider");
        }

        private void radioManager_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("manager");
        }

        private void radioStorage_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("storage");
        }

        private void UpdatingGrid()
        {
            if (radioProduct.Checked == true)
                dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("product");

            if (radioManager.Checked == true)
                dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("manager");

            if (radioProvider.Checked == true)
                dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("provider");

            if (radioSale.Checked == true)
                dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("sale");

            if (radioStorage.Checked == true)
                dataGridViewDB.DataSource = WorkerDatabase.SelectForGrid("storage");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            WorkWithEmail email = new WorkWithEmail();
            if (!email.CheckingInternet())
            {
                MessageBox.Show("Нет доступа к интернету, проверьте соеединение и повторите попытку");
            }
            else
            {
                email.GetAttachImap();
        }
        }
    }
}
