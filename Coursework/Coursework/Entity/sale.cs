using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class sale//продажа
    {
        public sale(int id, string date, double price, int IdOfProduct, int IdOfManager)
        {
            ID = id;
            Date = date;
            Price = price;
            idOfProduct = IdOfProduct;
            idOfManager = IdOfManager;
        }
        public int ID;
        public string Date;
        public double Price;
        public int idOfProduct;
        public int idOfManager;
    }
}
