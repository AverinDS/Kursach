using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class StorageProductBalance//Склад-товар-остаток
    {
        public StorageProductBalance(int ID, int Balance, int IdOfProduct, int IdOfStorage)
        {
            id = ID;
            balance = Balance;
            idOfProduct = IdOfProduct;
            idOfStorage = IdOfStorage;
        }
        public int id;
        public int balance;
        public int idOfProduct;
        public int idOfStorage;
    }
}
