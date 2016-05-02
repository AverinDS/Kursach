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
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
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
            f.ChooseProcess = "edit";
            f.ShowDialog();

        }
    }
}
