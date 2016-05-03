using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Coursework
{
    class WorkWithEmail //работа с электронной почтой
    {
        bool Internet = false;
        public bool GetInternet
        {
            get { return Internet; }
        }
        public bool CheckingInternet()
        {
            WebClient Client = new WebClient();
          
            string s ="";
            try
            {
                s = Client.DownloadString("http://www.google.com");
                Internet = true;
            }
            catch { Internet = false; }
            if (s == "") return false;
            else return true;
        }
    }
}
