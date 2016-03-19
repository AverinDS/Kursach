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

namespace Coursework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\Database.sqlite"))//попытка найти БД. если её нет, создаём новую
            {
                SQLiteConnection.CreateFile(@"C:\Database.sqlite");
                SQLiteConnection connect = new SQLiteConnection(@"Data Source = C:\Database.sqlite; Version = 3");
                SQLiteCommand command = new SQLiteCommand(
                    "create table product(id integer primary key, name varchar(20)) ", connect);
            }

        }
    }
}
