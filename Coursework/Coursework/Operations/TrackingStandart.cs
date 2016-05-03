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
            if (!Em.GetInternet) return;
            else
            {
                //код для получения данных с ЦБ
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
