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
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.uno;
using unoidl.com.sun.star.bridge;
using unoidl.com.sun.star.frame;


namespace Coursework
{
    class Redistribution //перераспределение
    {
        public Redistribution()
        {
            // countOfNeeded = 100;
        }
        DateTime Last;
        //int countOfNeeded;
        int[,] rules;
        WorkWithDatabase DB = new WorkWithDatabase();
        int valueOfOrder = 121;
        int valueOfOrder2 = 121;
        int valueOnStorage;


        public void BeginRedistribution()//происходит выяснение срабатывания системы продукции и если да, то передача id товара в метод ниже
        {
            StreamWriter write = new StreamWriter(@"E:\lastredistribution.txt");
            write.WriteLine(DateTime.Now.ToString());
            write.Close();

         

            if (DB.Count("storage") == "0 ") { MessageBox.Show("Отсутствуют склады!"); return; }
            valueOnStorage = valueOfOrder / int.Parse(DB.Count("storage"));
            valueOfOrder = valueOnStorage * int.Parse(DB.Count("storage"));

            StreamReader reader = new StreamReader(@"E:/rules.txt");
            string line = "";
            int count = 0;

            while ((line = reader.ReadLine()) != null)//считаем количество правил
            {
                count++;
            }
            rules = new int[count, 2];
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
            // count--;
            reader.Close();
            string NeededAllId = "";

            for (int i = 0; i < count; i++)// получаем информацию записям, удовлетворяющим системе продукции
            {
                NeededAllId += DB.Getting_smth("balance", "ProductID", "Number<=" + rules[i, 1] + " and ProductID ==" + rules[i, 0] + " Group by ProductID");
            }
         
            

            if (NeededAllId == "")
            { MessageBox.Show("Уже всё оптимизированно"); return; }

           while( NeededAllId != "")
            {
                string idProduct = NeededAllId.Substring(0, NeededAllId.IndexOf(' '));
                NeededAllId =  NeededAllId.Remove(0, NeededAllId.IndexOf(' ') + 1);
              
                BodyOfRedistribution(idProduct);
            }
          
                
      }

        

        private void BodyOfRedistribution(string idOfProduct)
        {
            valueOfOrder = valueOfOrder2;
            if (File.Exists(String.Format(@"E:/Redistribution{0}.pdf", idOfProduct)))
            {
                File.Delete(String.Format(@"E:/Redistribution{0}.pdf", idOfProduct));
            }
            string Name = DB.GettingInfo("product", "ID = " + idOfProduct);
            Name = Name.Remove(0, Name.IndexOf(' ') + 1);
            Name = Name.Substring(0, Name.IndexOf(' '));

            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            var doc = new Document();
           
            PdfWriter.GetInstance(doc, new FileStream(String.Format(@"E:/Redistribution{0}.pdf", idOfProduct), FileMode.Create));


            unoidl.com.sun.star.uno.XComponentContext localContext = uno.util.Bootstrap.bootstrap();
            unoidl.com.sun.star.lang.XMultiServiceFactory multiServiceFactory = (unoidl.com.sun.star.lang.XMultiServiceFactory)localContext.getServiceManager();
            XComponentLoader componentLoader = (XComponentLoader)multiServiceFactory.createInstance("com.sun.star.frame.Desktop");
            XComponent xComponent = componentLoader.loadComponentFromURL("private:factory/swriter", "_blank", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().setString("                                               Сеть розничных магазинов \"Подопытная сеть\" "+ Environment.NewLine);

            doc.Open();
            iTextSharp.text.Phrase head = new Phrase(new Chunk(string.Format("                                               Сеть розничных магазинов \"Подопытная сеть\" "), font));
            Paragraph headparagraph = new Paragraph(head);
            headparagraph.Add(Environment.NewLine);
            doc.Add(headparagraph);

            unoidl.com.sun.star.text.XTextRange x = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x, "                                                            Приказ начальнику складов "+Environment.NewLine, true);

            head = new Phrase(new Chunk(string.Format("                                                            Приказ начальнику складов "), font));
            headparagraph = new Paragraph(head);
            headparagraph.Add(Environment.NewLine);
            doc.Add(headparagraph);

            x = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x, "                                                               От  " + DateTime.Now.ToString() + Environment.NewLine, true);

            //head = new Phrase(new Chunk(string.Format("                                               О перераспределении товаров между складами   "), font));
            //headparagraph = new Paragraph(head);
            //headparagraph.Add(Environment.NewLine);
            //doc.Add(headparagraph);

            x = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x, "                                               О перераспределении товаров между складами"    + DateTime.Now.ToString() + Environment.NewLine, true);

            head = new Phrase(new Chunk(string.Format("                                               О перераспределении товаров между складами   "), font));
            headparagraph = new Paragraph(head);
            headparagraph.Add(Environment.NewLine);
            doc.Add(headparagraph);

            iTextSharp.text.Phrase phrase = new Phrase(new Chunk(string.Format("List of redistribution for product with ID = {0} ({1}) on storages:", idOfProduct, Name), font));
            Paragraph pararaph = new Paragraph(phrase);
            pararaph.Add(Environment.NewLine);
            doc.Add(pararaph);

            x = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x, string.Format("List of redistribution for product with ID = {0} ({1}) on storages:", idOfProduct, Name) + Environment.NewLine, true);



            StreamReader read = new StreamReader(@"E:\rules.txt");
            string line = "";
            while ((line = read.ReadLine()) != "")
            {
                if (idOfProduct == line.Substring(0, line.IndexOf(' ')))

                {
                    break;
                }
            }
          
            string NeededStorage = DB.Getting_smth("balance", "StorageID", "Number <= " + line.Remove(0, line.IndexOf(' ')+1) + " and ProductID =" + idOfProduct);
            int count = 0;//считаем количество складов
            while (NeededStorage != "")
            {
                count++;
                NeededStorage = NeededStorage.Remove(0, NeededStorage.IndexOf(' ') + 1);
            }
            NeededStorage = DB.Getting_smth("balance", "StorageID", "Number <= " + line.Remove(0, line.IndexOf(' ') + 1) + " and ProductID =" + idOfProduct);

            while (valueOfOrder%count != 0)
            {
                valueOfOrder--;
            }
            valueOnStorage = valueOfOrder / count;


            iTextSharp.text.Phrase phrase2 = new Phrase(new Chunk("All ordered product:" + valueOfOrder.ToString(), font));
            Paragraph paragraph2 = new Paragraph(phrase2);
            paragraph2.Add(Environment.NewLine);
            doc.Add(paragraph2);

            x = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
            ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x, "All ordered product:" + valueOfOrder.ToString() + Environment.NewLine, true);



            while (NeededStorage != "")
            {
                string id = NeededStorage.Substring(0, NeededStorage.IndexOf(' '));
                string adress = DB.Getting_smth("storage", "adress", "ID = " + id);
                Phrase phrase3 = new Phrase(new Chunk("For storage with id = " + id + ", with adress " + adress + " getting in value = " + valueOnStorage.ToString(), font));
                Paragraph paragraph3 = new Paragraph(phrase3);
                paragraph3.Add(Environment.NewLine);
                doc.Add(paragraph3);

                x = ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().getEnd();  // в конец
                ((unoidl.com.sun.star.text.XTextDocument)xComponent).getText().insertString(x, "For storage with id = " + id + ", with adress " + adress + " getting in value = " + valueOnStorage.ToString() + Environment.NewLine, true);


                string oldValue = DB.Getting_smth("balance", "Number", "StorageID = " + id + " and ProductID =  " + idOfProduct);
                string idBalance = DB.Getting_id("balance", "ProductID = " + idOfProduct + " and StorageID = " + id);
                DB.UpdateDB("balance", "Number", (valueOnStorage + int.Parse(oldValue)).ToString(), idBalance);


                NeededStorage = NeededStorage.Remove(0, NeededStorage.IndexOf(' ') + 1);
            }

            doc.Close();
            string FileName = string.Format(@"\E:\redistribution{0}.odt", idOfProduct);
            
            ((XStorable)xComponent).storeToURL( "file://"+FileName.Replace(@"\", "/"),
   new unoidl.com.sun.star.beans.PropertyValue[0]);
            xComponent.dispose();

            Last = DateTime.Now;

        }


      

    }
}
