using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;



namespace Coursework.Forms
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeReportIntoFile report = new MakeReportIntoFile();
            if (radioButton1.Checked == true)//товар
            {
                report.Diagram(1);
            }
            if (radioButton2.Checked == true)//поставшик
            {
                report.Diagram(2);
            }
            if (radioButton3.Checked == true)//Филиал
            {
                report.Diagram(3);
            }
            if (radioButton4.Checked == true)//Менеджер
            {
                report.Diagram(4);
            }
            Bitmap bm = new Bitmap(PB1.Width,PB1.Height);
            Graphics gr = Graphics.FromImage(bm);
            gr = Graphics.FromImage(bm);
            gr.CopyFromScreen(400, 400, 0, 0, bm.Size);
            PB1.Image = bm;

        }

        public void ExcellMaker()
        {
            Excel.Application App = new Excel.Application();
            Excel.Workbook WorkBook = App.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet WorkSheet = (Excel.Worksheet)App.ActiveSheet;
            WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            App.Visible = true;

            var cells = WorkSheet.get_Range("B2", "L40");
            cells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;// внутренние вертикальные
            cells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;// внутренние горизонтальные  
            cells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;// верхняя внешняя
            cells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble; // правая внешняя
            cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;// левая внешняя
            cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;// нижняя внешняя

            WorkSheet.Cells.Font.Italic = true;
            WorkSheet.Cells[2, 2] = "Данные о популярности поставщиков.";
            WorkSheet.Cells[3, 2] = "ID поставщика";
            WorkSheet.Cells[3, 6] = "ID предлагаемых товаров";
            //SQLiteConnection connect = new SQLiteConnection(@"Data Source = E:\Database.sqlite; Version = 3");
            //SQLiteCommand command = new SQLiteCommand("")
            WorkWithDatabase DB = new WorkWithDatabase();
            string ID = DB.Getting_id("provider");
            int indexFirst = 4;

            while (ID != "")
            {
                int indexSecond = 6;
                string id = ID.Substring(0, ID.IndexOf(' '));
                WorkSheet.Cells[indexFirst, 2] = id;
                string id_product = DB.Getting_id("product", "ProviderId = " + id);
                while (id_product != "")
                {
                    string id_Product2 = id_product.Substring(0, id_product.IndexOf(' '));
                    WorkSheet.Cells[indexFirst, indexSecond] = id_Product2;
                    id_product = id_product.Remove(0, id_product.IndexOf(' ') + 1);
                    indexSecond++;
                }
                indexFirst++;
                ID = ID.Remove(0, ID.IndexOf(' ') + 1);
            }
            //////////////////////////////////////////////////////////////////////////
            WorkSheet.Cells[10, 2] = "Данные о продаваемость товаров.";
            WorkSheet.Cells[11, 2] = "ID филиала";
            WorkSheet.Cells[11, 6] = "Количество проданных товаров";

            string ID_Storage = DB.Getting_id("storage");
            int index3 = 12;

            while (ID_Storage != "")//id филиала
            {
                int index4 = 6;
                string id = ID_Storage.Substring(0, ID_Storage.IndexOf(' '));
                WorkSheet.Cells[index3, 2] = id;
                string balance = DB.Getting_id("balance", "StorageId = " + id);
                while (balance != "")
                {
                    string CountSale = DB.Getting_smth("sale", "Count", "BalanceID =" + balance.Substring(0, balance.IndexOf(' ')));
                    if (CountSale != "")
                    {
                        while (CountSale != "")
                        {
                            WorkSheet.Cells[index3, index4] = CountSale.Substring(0, CountSale.IndexOf(' '));
                            index4++;
                            CountSale = CountSale.Remove(0, CountSale.IndexOf(' ') + 1);
                        }
                    }
                    balance = balance.Remove(0, balance.IndexOf(' ') + 1);
                }
                ID_Storage = ID_Storage.Remove(0, ID_Storage.IndexOf(' ') + 1);
                index3++;
            }
            ////////
            WorkSheet.Cells[19, 2] = "Данные о популярности менеджеров.";
            WorkSheet.Cells[20, 2] = "ID менеджера";
            WorkSheet.Cells[20, 6] = "Количество проданных товаров";
            string ID_manager = DB.Getting_id("manager");//получение id менеджеров
            int index42 = 21;

            while (ID_manager != "")
            {
                int index5 = 6;
                string id_m = ID_manager.Substring(0, ID_manager.IndexOf(' '));//берем первый
                WorkSheet.Cells[index42, 2] = id_m;
                string id_sale = DB.Getting_id("sale", "ManagerId = " + id_m);//находим все продажи
                while (id_sale != "")
                {
                    string id_ = id_sale.Substring(0, id_sale.IndexOf(' '));
                    WorkSheet.Cells[index42, index5] = DB.Getting_smth("sale", "Count", "ID=" + id_);
                    id_sale = id_sale.Remove(0, id_sale.IndexOf(' ') + 1);
                    index5++;
                }
                index42++;
                ID_manager = ID_manager.Remove(0, ID_manager.IndexOf(' ') + 1);
            }
            //////////////////////////////////////////////////////////
            WorkSheet.Cells[27, 2] = "Данные о продаваемости товаров.";
            WorkSheet.Cells[28, 2] = "ID товара";
            WorkSheet.Cells[28, 6] = "Количество проданных товаров";

            string ID_prod = DB.Getting_id("product");
            int index6 = 29;

            while (ID_prod != "")
            {
                int index7 = 6;
                string id_p = ID_prod.Substring(0, ID_prod.IndexOf(' '));
                WorkSheet.Cells[index6, 2] = id_p;
                string id_sale = DB.Getting_id("sale", "ProductId = " + id_p);
                while (id_sale != "")
                {
                    string id_s = id_sale.Substring(0, id_sale.IndexOf(' '));
                    WorkSheet.Cells[index6, index7] = DB.Getting_smth("sale", "Count", "ID = " + id_s);
                    id_sale = id_sale.Remove(0, id_sale.IndexOf(' ') + 1);
                    index7++;
                }
                index6++;
                ID_prod = ID_prod.Remove(0, ID_prod.IndexOf(' ') + 1);
            }
            if (File.Exists(@"E:\a1.xls"))
            {
                File.Delete(@"E:\a1.xls");
            }
            WorkBook.SaveCopyAs(@"E:\a1.xls");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ExcellMaker();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkWithEmail email = new WorkWithEmail();
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //foreach(string i in fileDialog.FileNames)
                //{
                string line = fileDialog.FileName;
                email.SendMail("Отчёты с центральной системы автоматизации сети розничных магазинов", "Отчет, отправленный " + DateTime.Now.ToString(), fileDialog.FileName);
              
            }
              
        }
    }
}
