using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class provider//поставщик
    {
        public provider(int id, string name, string Currensy)
        {
            ID = id;
            Name = name;
            currensy = Currensy;
        }
        public int ID;
        public string Name;
        public string currensy; //валюта
    }
}
