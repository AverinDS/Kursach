using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Coursework
{
    class WorkWithDatabase //работа с БД
    {
        SQLiteConnection connect = new SQLiteConnection(@"Data Source = E:\Database.sqlite; Version = 3");
        SQLiteCommand command;

        public void InsertInDB(string table, string line1, string line2, string line3, string line4, string line5)
        {
            string lineCommand = String.Format("insert in {0} values ", table);//создание строки sql запроса
            if (line1 != "") lineCommand += line1;
            if (line2 != "") lineCommand += "," + line2;
            if (line3 != "") lineCommand += "," + line3;
            if (line4 != "") lineCommand += "," + line4;
            if (line5 != "") lineCommand += "," + line5;

            command = new SQLiteCommand(lineCommand, connect);

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void DeleteFromDB(string table, string id)
        {
            command = new SQLiteCommand("delete from {0} where ID = {1}", connect);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void UpdateDB(string table, string nameOfLine, string value, string id )
        {
            command = new SQLiteCommand(String.Format("update {0} set {1} = {2} where ID = {3}", table, nameOfLine, id), connect);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }

        public int GettingId(string table, string query )
        {
            command = new SQLiteCommand(String.Format("select from {0} where {1}", table, query), connect);
            connect.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            connect.Close();
            return int.Parse(reader.ToString()) ;
        }
    }
}
