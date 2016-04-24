using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;

namespace Coursework
{
    class TrackingStandart//отслеживание курса ЦБ
    {
        private string RUB_dollar, RUB_euro;
        public TrackingStandart()
        {
            RUB_dollar = " USD: неизвестно";
            RUB_euro = " EUR: неизвестно";
        }
        public void updateStandart()
        {
            try
            {
                HttpWebRequest RequeForBank = (HttpWebRequest)WebRequest.Create("http://www.cbr.ru/"); // // // // 
                WebResponse response = RequeForBank.GetResponse();                                              //тут получаем страницу с сайта ЦБ РФ
                StreamReader readerLine = new StreamReader(response.GetResponseStream());                       //
                string s = readerLine.ReadToEnd();                                                    // // // // 

                string USD = s.Substring((s.IndexOf("Доллар США <ins>$</ins>\r\n") + 306), 7);  //ищем значение доллара  
                RUB_dollar = " USD: " + USD;

                string EUR = s.Substring((s.IndexOf("Евро <ins>€</ins>") + 300), 7); // ищем значение евро
                RUB_euro = " EUR: " + EUR;
            }
            catch
            {
                RUB_dollar = " oшибка соединения с сервером";
                RUB_euro = "";
            }
        }

        public string dollar
        {
            get
            {
                return RUB_dollar;
            }
        }

        public string euro
        {
            get
            {
                return RUB_euro;
            }
        }
    }
}
