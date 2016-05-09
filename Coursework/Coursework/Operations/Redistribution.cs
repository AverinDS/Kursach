using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;

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
        int valueOfOrder = 10;
        
        public void BeginRedistribution()//происходит выяснение срабатывания системы продукции и если да, то передача id товара в метод ниже
        {
            if(DB.Count("storage") == "0 ") { MessageBox.Show("Отсутствуют склады!"); return; }
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
            count--;
            string NeededAllId = "";

            for (int i = 0; i < count; i++)// получаем информацию записям, удовлетворяющим системе продукции
            {
                 NeededAllId += DB.GettingInfo("balance", "ProductId =" + rules[i,0].ToString() +" AND Number <=" + rules[i,1].ToString())+ " ";
            }

            if (NeededAllId == " ")
            { MessageBox.Show("Уже всё оптимизированно");return; }


            while (NeededAllId != "")
            {
                NeededAllId = NeededAllId.Remove(0, NeededAllId.IndexOf(' ')+1);//удаление id
                NeededAllId = NeededAllId.Remove(0, NeededAllId.IndexOf(' ') + 1);//удаление количества товаров
                string idProduct = NeededAllId.Substring(0, NeededAllId.IndexOf(' '));//получаем id продукта искомого
                NeededAllId = NeededAllId.Remove(0, NeededAllId.IndexOf(' ') + 1);//удаляем id продукта
                NeededAllId = NeededAllId.Remove(0, NeededAllId.IndexOf(' ') + 1);//удаляем id склада
                //NeededAllId = NeededAllId.Remove(0, 1);//удаляет пробел
                if (DB.GettingInfo("sale", "ProductId = "+ idProduct)== "")
                {
                    IfWithoutSales(idProduct);
                    return;
                }
                BodyOfRedistribution(idProduct);
            }

        }

        private void BodyOfRedistribution(string idOfProduct)
        {
            int Allcount = 0;
            string sales = DB.GettingInfo("sale", "ProductId = " + idOfProduct);

            while (sales != "")//считаем общее количество продаж
            {
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);//удаление id;
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);//удаление даты продажи
                Allcount += int.Parse(sales.Substring(0, sales.IndexOf(' ')));//прибавляем к общему количеству продаж 
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);//удаление к-ва продаж
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);//и трех внешних ключей
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);
            }

            sales = DB.GettingInfo("sale", "ProductId = " + idOfProduct);//начинаем считать количество продаж для каждого склада
            string countOf = DB.Count("storage");
            string[] storageSale = new string[int.Parse(countOf)];//формат такой: первое число - это id склада, остальные числа - продажи товара
            int i = 0;

            while (sales != "")//считаем количество продаж для каждого склада
            {
                int count = 0;
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);//удаление id;
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);//удаление даты продажи
                count += int.Parse(sales.Substring(0, sales.IndexOf(' ')));//запоминаем количество продаж для данного склада 
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);//удаление к-ва продаж
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);//удаление внешних ключей
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);

                for (int j = 0; j < i; j++)//ищем этот склад в уже существующих записях
                {
                    if (storageSale[j].Substring(0, storageSale[j].IndexOf(' ')) == sales.Substring(0, sales.IndexOf(' ')))
                    {
                        storageSale[j] += " " + count.ToString();
                        break;
                    }
                    else
                    {
                        if (j == i-1)//если не нашли
                        {
                            storageSale[i] = sales.Substring(0, sales.IndexOf(' '));//в начало строки вставляем номер склада
                            storageSale[i] += " " + count.ToString();//и значение продаж
                            i++;
                        }
                    }
                }
               
                sales = sales.Remove(0, sales.IndexOf(' ') + 1);
            }
            
            for (int j = 0; j < int.Parse(countOf); j++)// приводим к формату id - % от общего
            {
                string idStorage = storageSale[i].Substring(0, storageSale[i].IndexOf(' '));
                storageSale[i] = storageSale[i].Remove(0, storageSale[i].IndexOf(' ') + 1);
                int allSales = 0;
                double persent = 0;
                while (storageSale[i]!= "" )
                {
                    allSales += int.Parse(storageSale[i].Substring(0, storageSale[i].IndexOf(' ')));
                    storageSale[i] = storageSale[i].Remove(0, storageSale[i].IndexOf(' ') + 1);
                }
                persent = Math.Round((double)Allcount * 100 / allSales);
                storageSale[i] = idStorage.ToString() + " " + persent.ToString();

            }


        }

        private void IfWithoutSales(string idProduct)//обычно, это происходит, когда продаж нет совсем. Распределяется всё поровну
        {
            if (File.Exists(String.Format(@"E:/Redistribution{0}.pdf", idProduct)))
            {
                File.Delete(String.Format(@"E:/Redistribution{0}.pdf", idProduct));
            }
            string Name = DB.GettingInfo("product", "ID = " + idProduct);
            Name = Name.Remove(0, Name.IndexOf(' ') + 1);
            Name = Name.Substring(0, Name.IndexOf(' '));

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(String.Format(@"E:/Redistribution{0}.pdf", idProduct), FileMode.Create));
            doc.Open();
            iTextSharp.text.Phrase phrase = new Phrase(string.Format("List of redistribution for product with ID = {0} ({1}) on storages:", idProduct, Name));
            Paragraph pararaph = new Paragraph(phrase);
            pararaph.Add(Environment.NewLine);
            doc.Add(pararaph);

            iTextSharp.text.Phrase phrase2 = new Phrase("All ordered product:" + valueOfOrder.ToString());
            Paragraph paragraph2 = new Paragraph(phrase2);
            paragraph2.Add(Environment.NewLine);
            doc.Add(paragraph2);

            string storages = DB.GettingInfo("storage", "ID>0");
            for(int i = 0; i < int.Parse(DB.Count("storage")); i++)
            {
                string id = storages.Substring(0, storages.IndexOf(' '));
                storages = storages.Remove(0, storages.IndexOf(' ') + 1);
                string storages2 = storages.Substring(0, storages.IndexOf(' '));
                storages = storages.Remove(0, storages.IndexOf(' ') + 1);
                Phrase phrase3;
                if (i != int.Parse(DB.Count("storage")) - 1)
                {
                     phrase3 = new Phrase("For storage with id = " + id + ", with adress " + storages2.Substring(0, storages.IndexOf(' ')) + " getting in value = " + valueOfOrder.ToString());
                }
                else
                {
                     phrase3 = new Phrase("For storage with id = " + id + ", with adress " + storages2 + " getting in value " + valueOfOrder.ToString());
                }
                Paragraph paragraph3 = new Paragraph(phrase3);
                paragraph3.Add(Environment.NewLine);
                doc.Add(paragraph3);
            }
            doc.Close();
            System.Diagnostics.Process.Start(String.Format(@"E:/Redistribution{0}.pdf", idProduct));
            //добавить работу с БД (тип у нас всё моментально приходит)
        }
       
    }
}
