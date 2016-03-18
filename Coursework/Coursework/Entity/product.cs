using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class product  // Товар
    {
        public product(int id, string name, double price, int idOfProvider)
        {
            ID = id;
            Name = name;
            Price = price;
            IdOfProvider = idOfProvider;

        }
        public int ID;
        public string Name;
        public double Price;
        public int IdOfProvider;
    }
}
