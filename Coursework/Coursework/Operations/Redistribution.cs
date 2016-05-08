using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Coursework
{
    class Redistribution //перераспределение
    {
        public Redistribution()
        {
             countOfNeeded = 100;
        }
        int countOfNeeded;
        int[,] rules;
        WorkWithDatabase DB = new WorkWithDatabase();
        
        public void BeginRedistribution()
        {
            StreamReader reader = new StreamReader(@"E:/rules.txt");
            string line = "";
            int count = 0;

            while ((line = reader.ReadLine())!= null)//считаем количество правил
            {
                count++;
            }
            rules = new int[count,2];
            reader.Close();

            reader = new StreamReader(@"E:/rules.txt");
            count = 0;
            while ((line = reader.ReadLine()) != null)//и записываем их в память
            {
                rules[count, 0] = int.Parse(line.Substring(0, line.IndexOf(' ')));
                line = line.Remove(0, line.IndexOf(' ') + 1);
                rules[count, 1] = int.Parse(line);
                count++;

            }

        }  
         

       
    }
}
