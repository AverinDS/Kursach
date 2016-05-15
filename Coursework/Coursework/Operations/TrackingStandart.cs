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
        public DateTime date;
        private string RUB_dollar, RUB_euro, lastUpdate;
        public TrackingStandart()
        {
            RUB_dollar = " USD: неизвестно";
            RUB_euro = " EUR: неизвестно";
            lastUpdate = "Данные от: неизвестно";
        }
        public void updateStandart()
        {
            WorkWithEmail Em = new WorkWithEmail();
            Em.CheckingInternet();
            if (!Em.GetInternet) return;
            else
            {
                HttpWebRequest myReq =
           (HttpWebRequest)WebRequest.Create("http://www.cbr.ru");
                WebResponse response = myReq.GetResponse();
                StreamReader stream =
                    new StreamReader(response.GetResponseStream());
                string s = stream.ReadToEnd();
                string dollarEuro = s.Substring(s.IndexOf("Доллар США"), 200);
                dollarEuro = dollarEuro.Substring(dollarEuro.IndexOf("nbsp;")+5, 7);
                try
                {
                    double.Parse(dollarEuro);
                    RUB_dollar = "USD: " + dollarEuro;

                    dollarEuro = s.Substring(s.IndexOf("Евро"), 200);
                    dollarEuro = dollarEuro.Substring(dollarEuro.IndexOf("nbsp;") + 5, 7);
                    double.Parse(dollarEuro);
                    RUB_euro = " EUR: " + dollarEuro;
                    date = DateTime.Now;
                }
                catch
                {
                    RUB_dollar = "USD: Error";
                    RUB_euro = " EUR: Error";

                }


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
