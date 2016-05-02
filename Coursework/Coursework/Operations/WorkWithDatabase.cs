using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace Coursework
{
    class WorkWithDatabase //работа с БД
    {
        SQLiteConnection connect = new SQLiteConnection(@"Data Source = E:\Database.sqlite; Version = 3");
        SQLiteCommand command;

        public void InsertInDB(string table, string line1, string line2, string line3, string line4, string line5, string line6)
        {
            string lineCommand = String.Format("insert into {0} values (", table);//создание строки sql запроса
            if (line1 != "") lineCommand += " \'" + line1+ "\'";
            if (line2 != "") lineCommand += ", \'" + line2 + "\'";
            if (line3 != "") lineCommand += ", \'" + line3 + "\'";
            if (line4 != "") lineCommand += ", \'" + line4 + "\'";
            if (line5 != "") lineCommand += ", \'" + line5 + "\'";
            if (line6 != "") lineCommand += ", \'" + line6 + "\'";
            lineCommand += ")";

            command = new SQLiteCommand(lineCommand, connect);

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void DeleteFromDB(string table, string id)
        {
            command = new SQLiteCommand(String.Format("delete from {0} where ID = {1}", table,id), connect);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void UpdateDB(string table, string nameOfLine, string value, string id )
        {
            command = new SQLiteCommand(String.Format("update {0} set {1} = {2} where ID = {3}", table, nameOfLine,value, id), connect);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }

        public string GettingInfo(string table, string query )
        {
            command = new SQLiteCommand(String.Format("select * from {0} where {1}", table, query), connect);
            connect.Open();
            SQLiteDataReader reader = command.ExecuteReader();
          
            DataTable TableForResult = new DataTable();//для получения данных из БД
            TableForResult.Load(reader);
            connect.Close();
            string values = "";
            try
            {
                for (int i = 0; i < TableForResult.Columns.Count; i++)
                {
                    values += TableForResult.Rows[0][i] + " ";
                }
            }
            catch { values = ""; }
           
            return values;
        }

        public void CreatingOrFindingTable()
        {
            //SQLiteConnection.CreateFile(@"D:\ООП\git\Kursach\Coursework\Coursework\bin\Debug\Database.sqlite"); // просто адрес папки
            if (!File.Exists(@"E:\Database.sqlite"))
            {
                SQLiteConnection.CreateFile(@"E:\Database.sqlite");
                SQLiteCommand product = new SQLiteCommand("create table if not exists product (id INTEGER PRIMARY KEY, Name TEXT, Price INTEGER, ProviderID INTEGER, CONSTRAINT Product_Providerfk FOREIGN KEY (ProviderID) REFERENCES Provider(ProviderID))", connect);
                SQLiteCommand manager = new SQLiteCommand("create table if not exists manager (id INTEGER PRIMARY KEY, FIO TEXT)", connect);
                SQLiteCommand provider = new SQLiteCommand("create table if not exists provider (id INTEGER PRIMARY KEY, Name TEXT, Currensy TEXT)", connect);
                SQLiteCommand sale = new SQLiteCommand("create table if not exists sale (id INTEGER PRIMARY KEY, Date TEXT, Price INTEGER, ProductID INTEGER, ManagerID INTEGER, CONSTRAINT Sale_Productfk FOREIGN KEY (ProductID) REFERENCES Product(ProductID),CONSTRAINT Sale_Managerfk FOREIGN KEY (ManagerID) REFERENCES Manager(ManagerID) )", connect);
                SQLiteCommand storage = new SQLiteCommand("create table if not exists storage (id INTEGER PRIMARY KEY, Adress TEXT)", connect);
                SQLiteCommand balance = new SQLiteCommand("create table if not exists balance (id INTEGER PRIMARY KEY, Number INTEGER, ProductID INTEGER, StorageID INTEGER, CONSTRAINT Balance_Productfk FOREIGN KEY (ProductID) REFERENCES Product(ProductID), CONSTRAINT Balance_Storagefk FOREIGN KEY (StorageID) REFERENCES Storage(StorageID) )", connect);

                connect.Open();
                product.ExecuteNonQuery();
                manager.ExecuteNonQuery();
                provider.ExecuteNonQuery();
                sale.ExecuteNonQuery();
                storage.ExecuteNonQuery();
                balance.ExecuteNonQuery();
                connect.Close();
            }
        }
    }
}
