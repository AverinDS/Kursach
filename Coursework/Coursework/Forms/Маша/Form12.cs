using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.SQLite;

namespace Coursework
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        Bitmap bmp = new Bitmap(500, 50);
        SolidBrush fon;

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // DataBase db = new DataBase();
            pictureBox1.Image = bmp;
            bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
            //gr.DrawRectangle(Pens.Black, 20, 20, 45, 15);
            //gr.DrawString("Look at this text!", Font., Brushes.Black, new RectangleF(20, 20, 45, 15));
            gr.DrawLine(Pens.Black, 266 ,29, 39, 100);
            gr.DrawLine(Pens.Black, 34, 116, 34, 240);

            WorkWithDatabase DB = new WorkWithDatabase();
            if (radioButton1.Checked == true)
            {
                gr.DrawString("PROVIDER", Font, Brushes.Black, new RectangleF(266, 16, 65, 13));
                gr.DrawString("PROVIDER", Font, Brushes.Black, new RectangleF(34, 103, 65, 13));
                gr.DrawString("PROVIDER", Font, Brushes.Black, new RectangleF(30, 246, 65, 13));
                gr.DrawString("FILIAL", Font, Brushes.Black, new RectangleF(474, 16, 65, 13));
                gr.DrawString("FILIAL", Font, Brushes.Black, new RectangleF(266, 103, 65, 13));
                gr.DrawString("FILIAL", Font, Brushes.Black, new RectangleF(34, 318, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(632, 16, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(455, 103, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(34, 399, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(733, 75, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(455, 199, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(226, 399, 65, 13));
                //label1.Text = "Provider".ToUpper();
                // label2.Text = "Provider".ToUpper();
                // label3.Text = "Provider".ToUpper();
                //label4.Text = "Filial".ToUpper();
                //label5.Text = "Filial".ToUpper();
                // label6.Text = "Filial".ToUpper();
                // label7.Text = "Manager".ToUpper();
                // label8.Text = "Manager".ToUpper();
                // label9.Text = "Manager".ToUpper();
               // label10.Text = "Product".ToUpper();
               // label11.Text = "Product".ToUpper();
               // label12.Text = "Product".ToUpper();

                gr.DrawLine(Pens.Blue, 326, 20, 474, 20);
                gr.DrawLine(Pens.Blue, 92, 110, 266, 110);
                gr.DrawLine(Pens.Blue, 40, 260, 40, 318);
                gr.DrawLine(Pens.LightGreen, 520, 20, 632, 20);
                gr.DrawLine(Pens.LightGreen, 317, 109, 455, 109);
                gr.DrawLine(Pens.LightGreen, 38, 330, 38, 399);
                gr.DrawLine(Pens.Red, 670, 25, 733, 75);
                gr.DrawLine(Pens.Red, 460, 115, 460, 199);
                gr.DrawLine(Pens.Red, 115, 405, 226, 405);

                gr.DrawLine(Pens.Black, 600, 400, 750, 400);
                gr.DrawString("More Popular", Font, Brushes.Black, new RectangleF(750, 400, 50, 40));
                gr.DrawLine(Pens.Blue, 600, 430, 750, 430);
                gr.DrawString("Work", Font, Brushes.Blue, new RectangleF(750, 430, 50, 40));
                gr.DrawLine(Pens.LightGreen, 600, 460, 750, 460);
                gr.DrawString("Employee", Font, Brushes.LightGreen, new RectangleF(750, 460, 55, 40));
                gr.DrawLine(Pens.Red, 600, 490, 750, 490);
                gr.DrawString("Sells", Font, Brushes.Red, new RectangleF(750, 490, 50, 40));
            }

            if (radioButton2.Checked == true)
            {
                gr.DrawString("FILIAL", Font, Brushes.Black, new RectangleF(266, 16, 65, 13));
                gr.DrawString("FILIAL", Font, Brushes.Black, new RectangleF(34, 103, 65, 13));
                gr.DrawString("FILIAL", Font, Brushes.Black, new RectangleF(30, 246, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(474, 16, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(266, 103, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(34, 318, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(632, 16, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(455, 103, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(34, 399, 65, 13));

                gr.DrawLine(Pens.LightGreen, 326, 20, 474, 20);
                gr.DrawLine(Pens.LightGreen, 92, 110, 266, 110);
                gr.DrawLine(Pens.LightGreen, 40, 260, 40, 318);
                gr.DrawLine(Pens.Red, 530, 20, 632, 20);
                gr.DrawLine(Pens.Red, 327, 109, 455, 109);
                gr.DrawLine(Pens.Red, 38, 330, 38, 399);

                gr.DrawLine(Pens.Black, 600, 400, 750, 400);
                gr.DrawString("Better sells", Font, Brushes.Black, new RectangleF(750, 400, 50, 40));
               // gr.DrawLine(Pens.Blue, 600, 430, 750, 430);
               // gr.DrawString("Work", Font, Brushes.Blue, new RectangleF(750, 430, 50, 40));
                gr.DrawLine(Pens.LightGreen, 600, 460, 750, 460);
                gr.DrawString("Employee", Font, Brushes.LightGreen, new RectangleF(750, 460, 55, 40));
                gr.DrawLine(Pens.Red, 600, 490, 750, 490);
                gr.DrawString("Sells", Font, Brushes.Red, new RectangleF(750, 490, 50, 40));
            }

            if (radioButton3.Checked == true)
            {
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(266, 16, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(34, 103, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(30, 246, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(474, 16, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(266, 103, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(34, 318, 65, 13));

                gr.DrawLine(Pens.Red, 326, 20, 474, 20);
                gr.DrawLine(Pens.Red, 92, 110, 266, 110);
                gr.DrawLine(Pens.Red, 40, 260, 40, 318);

                gr.DrawLine(Pens.Black, 600, 400, 750, 400);
                gr.DrawString("More Popular", Font, Brushes.Black, new RectangleF(750, 400, 50, 40));
               /* gr.DrawLine(Pens.Blue, 600, 430, 750, 430);
                gr.DrawString("Work", Font, Brushes.Blue, new RectangleF(750, 430, 50, 40));
                gr.DrawLine(Pens.LightGreen, 600, 460, 750, 460);
                gr.DrawString("Employee", Font, Brushes.LightGreen, new RectangleF(750, 460, 55, 40));*/
                gr.DrawLine(Pens.Red, 600, 490, 750, 490);
                gr.DrawString("Sells", Font, Brushes.Red, new RectangleF(750, 490, 50, 40));
            }

            if (radioButton4.Checked == true)
            {
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(266, 16, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(34, 103, 65, 13));
                gr.DrawString("PRODUCT", Font, Brushes.Black, new RectangleF(30, 246, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(474, 16, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(266, 103, 65, 13));
                gr.DrawString("MANAGER", Font, Brushes.Black, new RectangleF(34, 318, 65, 13));

                gr.DrawLine(Pens.Red, 326, 20, 474, 20);
                gr.DrawLine(Pens.Red, 92, 110, 266, 110);
                gr.DrawLine(Pens.Red, 40, 260, 40, 318);

                gr.DrawLine(Pens.Black, 600, 400, 750, 400);
                gr.DrawString("More Popular", Font, Brushes.Black, new RectangleF(750, 400, 50, 40));
                /* gr.DrawLine(Pens.Blue, 600, 430, 750, 430);
                 gr.DrawString("Work", Font, Brushes.Blue, new RectangleF(750, 430, 50, 40));
                 gr.DrawLine(Pens.LightGreen, 600, 460, 750, 460);
                 gr.DrawString("Employee", Font, Brushes.LightGreen, new RectangleF(750, 460, 55, 40));*/
                gr.DrawLine(Pens.Red, 600, 490, 750, 490);
                gr.DrawString("Sold by", Font, Brushes.Red, new RectangleF(750, 490, 50, 40));
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // создание документа

            Excel.Application App = new Excel.Application();
            Excel.Workbook WorkBook = App.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet WorkSheet = (Excel.Worksheet)App.ActiveSheet;
            WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            App.Visible = true;

            var cells = WorkSheet.get_Range("B2", "L31");
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

            WorkWithDatabase DB = new WorkWithDatabase();
            DB.CreatingOrFindingTable();
            string ID = DB.Getting_id("provider");
            int indexFirst = 4;
            int index2 = 2;

            while (ID != "")
            {
                int indexSecond = 6;
                string id = ID.Substring(0, ID.IndexOf(' '));
                WorkSheet.Cells[indexFirst, index2] = id;
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

            WorkSheet.Cells[7, 2] = "Филиалы";
            WorkSheet.Cells[8, 2] = "ID филиала";
            WorkSheet.Cells[8, 6] = "Количество проданных товаров";

            string ID_Storage = DB.Getting_id("storage");
            int index3 = 9;

            while (ID_Storage != "")//id филиала
             {
                 int indexx = 6;
                 string id = ID_Storage.Substring(0, ID_Storage.IndexOf(' '));
                 WorkSheet.Cells[index3, 2] = id;
                 string balance = DB.Getting_id("balance", "StorageId = " + id);
                 while (balance != "")
                 {
                     string CountSale = DB.Getting_smth("sale", "Count", "BalanceID =" + balance.Substring(0, balance.IndexOf(' ')));
                     WorkSheet.Cells[index3, indexx] = CountSale;
                     indexx++;
                     balance = balance.Remove(0, balance.IndexOf(' ') + 1);
                 }
                 ID_Storage = ID_Storage.Remove(0, ID_Storage.IndexOf(' ') + 1);
                 index3++;
             }

            WorkSheet.Cells[12, 2] = "Данные о популярности менеджеров.";
            WorkSheet.Cells[13, 2] = "ID филиала";
            WorkSheet.Cells[13, 6] = "Количество проданных товаров";
            string ID_manager = DB.Getting_id("manager");
            int index4 = 14;

            while (ID_manager != "")
            {
                int index5 = 6;
                string id_m = ID_manager.Substring(0, ID_manager.IndexOf(' '));
                WorkSheet.Cells[index4, 2] = id_m;
                string id_product = DB.Getting_id("sale", "ManagerId = " + id_m);
                while (id_product != "")
                {
                    string id_Product2 = id_product.Substring(0, id_product.IndexOf(' '));
                    WorkSheet.Cells[index4, index5] = id_Product2;
                    id_product = id_product.Remove(0, id_product.IndexOf(' ') + 1);
                    index5++;
                }
                index4++;
                ID_manager  = ID_manager.Remove(0, ID_manager.IndexOf(' ') + 1);
            }

            WorkSheet.Cells[18, 2] = "Данные о продаваемости товаров.";
            WorkSheet.Cells[19, 2] = "ID товара";
            WorkSheet.Cells[19, 6] = "Количество проданных товаров";

            string ID_prod = DB.Getting_id("product");
            int index6 = 20;

            while (ID_prod != "")
            {
                int index7 = 6;
                string id_p = ID_prod.Substring(0, ID_prod.IndexOf(' '));
                WorkSheet.Cells[index6, 2] = id_p;
                string id_sale = DB.Getting_id("sale", "ProductId = " + id_p);
                while (id_sale != "")
                {
                    string id_s = id_sale.Substring(0, id_sale.IndexOf(' '));
                    WorkSheet.Cells[index6, index7] = id_s;
                    id_sale = id_sale.Remove(0, id_sale.IndexOf(' ') + 1);
                    index7++;
                }
                index6++;
                ID_prod = ID_prod.Remove(0, ID_prod.IndexOf(' ') + 1);
            }
           // WorkBook.SaveCopyAs(@"E:\a1.xls");

            Excel.Chart excelchart = (Excel.Chart)App.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            App.ActiveChart.HasTitle = true;
            App.ActiveChart.ChartTitle.Text = "Диаграмма 1";

            App.ActiveChart.ChartTitle.Font.Size = 13;
            App.ActiveChart.ChartTitle.Font.Color = 254;

            ((Excel.Axis)App.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)App.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Поставщик";

            ((Excel.Axis)App.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)App.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Востребованность товара";

            ((Excel.Axis)App.ActiveChart.Axes(Excel.XlAxisType.xlSeriesAxis, Excel.XlAxisGroup.xlPrimary)).HasTitle = false;

            ((Excel.Axis)App.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
           // ((Excel.Axis)App.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;


            Excel.SeriesCollection seriesCollection =
            (Excel.SeriesCollection)App.ActiveChart.SeriesCollection(Type.Missing);
            Excel.Series series = seriesCollection.Item(1);
            series.Name = "Первый ряд";

         /*  App.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, "Лист1");
            WorkSheet = WorkBook.Worksheets;
            WorkSheet = (Excel.Worksheet)Worksheet.get_Item(1);
            WorkSheet.Shapes.Item(1).IncrementLeft(-200);
            WorkSheet.Shapes.Item(1).IncrementTop((float)18.5);
            WorkSheet.Shapes.Item(1).Height = 450;
            WorkSheet.Shapes.Item(1).Width = 450;*/

            // еще вариант
         /*   Excel.ChartObjects chartsobjrcts =(Excel.ChartObjects)WorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject chartsobjrct = chartsobjrcts.Add(10, 200, 500, 400);
            WorkSheet.Cells = WorkSheet.get_Range("А1", "I3");
            Excel.Chart excelchart1 = chartsobjrct.Chart;
            excelchart.SetSourceData(excelcells, Type.Missing);*/




        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkWithDatabase DB = new WorkWithDatabase();
            DB.CreatingOrFindingTable();
            if (radioButton1.Checked == true)
            {
                Excel.Application App = new Excel.Application();
                Excel.Workbook WorkBook = App.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)App.ActiveSheet;
                WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                App.Visible = true;
                var cells = WorkSheet.get_Range("B2", "N48");
                cells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;// внутренние вертикальные
                cells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;// внутренние горизонтальные  
                cells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;// верхняя внешняя
                cells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble; // правая внешняя
                cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;// левая внешняя
               // cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;// нижняя внешняя
               //  WorkSheet.Cells.Font.Italic = true;
                WorkSheet.Cells[2, 2] = "Данные о популярности поставщиков.";
                WorkSheet.Cells[3, 2] = "ID поставщика";
                WorkSheet.Cells[3, 5] = "ID предлагаемых товаров";
                WorkSheet.Cells[3, 8] = "ID филиалов";
                WorkSheet.Cells[3, 10] = "ID менеджеров-работников";
                string ID = DB.Getting_id("provider");

                int index1 = 4;
                int index11 = 4;
                int index2 = 2;
                int index22 = 5;
                int index3 = 8;
                int index4 = 10;
                while (ID != "")
                {
                   
                    string id = ID.Substring(0, ID.IndexOf(' '));
                    WorkSheet.Cells[index1, index2] = id;
                    string id_product = DB.Getting_id("product", "ProviderId = " + id);
                    while (id_product != "")
                    {
                        string id_Product2 = id_product.Substring(0, id_product.IndexOf(' '));
                        WorkSheet.Cells[index1, index22] = id_Product2;

                        string id_man = DB.Getting_smth("sale", "ManagerID" , "ProductId = " + id_Product2);
                        while (id_man != "")
                        {
                            string id_m2 = id_man.Substring(0, id_man.IndexOf(' '));
                            WorkSheet.Cells[index1, index4] = id_m2;
                            id_man = id_man.Remove(0, id_man.IndexOf(' ') + 1);
                            index4++;
                        }
                        string id_fil = DB.Getting_smth("balance", "StorageID", "ProductId = " + id_Product2);
                        while (id_fil != "")
                        {
                            string id_f2 = id_fil.Substring(0, id_fil.IndexOf(' '));
                            WorkSheet.Cells[index1, index3] = id_f2;
                            id_fil = id_fil.Remove(0, id_fil.IndexOf(' ') + 1);
                            index3++;
                        }


                        id_product = id_product.Remove(0, id_product.IndexOf(' ') + 1);

                       index22++;
                    }
                    index1++;
                    index11++;
                    ID = ID.Remove(0, ID.IndexOf(' ') + 1);
                }
            }
            if (radioButton2.Checked == true)
            {
                Excel.Application App = new Excel.Application();
                Excel.Workbook WorkBook = App.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)App.ActiveSheet;
                WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                App.Visible = true;
                var cells = WorkSheet.get_Range("B2", "N48");
                cells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;// внутренние вертикальные
                cells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;// внутренние горизонтальные  
                cells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;// верхняя внешняя
                cells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble; // правая внешняя
                cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;// левая внешняя
               // cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;// нижняя внешняя
               //  WorkSheet.Cells.Font.Italic = true;
                WorkSheet.Cells[2, 2] = "Данные о работе филиалов.";
                WorkSheet.Cells[3, 2] = "ID филиала";
                WorkSheet.Cells[3, 5] = "Количество товаров";
                WorkSheet.Cells[3, 8] = "Менеджеры-работники";
             //   WorkSheet.Cells[3, 10] = "ID менеджеров-работников";
                string ID_Storage = DB.Getting_id("storage");
                int index3 = 4;

                while (ID_Storage != "")//id филиала
                {
                    int indexx = 5;
                    int ind = 8;
                    string id = ID_Storage.Substring(0, ID_Storage.IndexOf(' '));
                    WorkSheet.Cells[index3, 2] = id;
                    string balance = DB.Getting_id("balance", "StorageId = " + id);
                    while (balance != "")
                    {
                        string CountSale = DB.Getting_smth("sale", "Count", "BalanceID =" + balance.Substring(0, balance.IndexOf(' ')));
                        string Manag = DB.Getting_smth("sale", "ManagerID", "BalanceID =" + balance.Substring(0, balance.IndexOf(' ')));
                        WorkSheet.Cells[index3, indexx] = CountSale;
                        WorkSheet.Cells[index3, ind] = Manag;
                        indexx++;
                        balance = balance.Remove(0, balance.IndexOf(' ') + 1);
                    }
                    ID_Storage = ID_Storage.Remove(0, ID_Storage.IndexOf(' ') + 1);
                    index3++;
                }
            }
            if (radioButton3.Checked == true)
            {
                Excel.Application App = new Excel.Application();
                Excel.Workbook WorkBook = App.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)App.ActiveSheet;
                WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                App.Visible = true;
                var cells = WorkSheet.get_Range("B2", "N48");
                cells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;// внутренние вертикальные
                cells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;// внутренние горизонтальные  
                cells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;// верхняя внешняя
                cells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble; // правая внешняя
                cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;// левая внешняя
              // cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;// нижняя внешняя
              //  WorkSheet.Cells.Font.Italic = true;
                WorkSheet.Cells[2, 2] = "Данные о популярности менеджеров.";
                WorkSheet.Cells[3, 2] = "Менеджер";
                WorkSheet.Cells[3, 5] = "Количество реализуемых товаров";
                //  WorkSheet.Cells[3, 8] = "Менеджеры-работники";

                string ID_manager = DB.Getting_id("manager");
                int index4 = 4;

                while (ID_manager != "")
                {
                    int index5 = 6;
                    string id_m = ID_manager.Substring(0, ID_manager.IndexOf(' '));
                    WorkSheet.Cells[index4, 2] = id_m;
                    string id_product = DB.Getting_id("sale", "ManagerId = " + id_m);
                    while (id_product != "")
                    {
                        string id_Product2 = id_product.Substring(0, id_product.IndexOf(' '));
                        WorkSheet.Cells[index4, index5] = id_Product2;
                        id_product = id_product.Remove(0, id_product.IndexOf(' ') + 1);
                        index5++;
                    }
                    index4++;
                    ID_manager = ID_manager.Remove(0, ID_manager.IndexOf(' ') + 1);
                }
            }
            if (radioButton4.Checked == true)
            {

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WorkWithDatabase DB = new WorkWithDatabase();
            DB.CreatingOrFindingTable();
            string temp = textBox1.Text.ToString();
            if (temp == "")
            { MessageBox.Show("Введите требуемый id"); }
            else
            {

                if (radioButton1.Checked == true)
                {
                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Add(System.Reflection.Missing.Value);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)App.ActiveSheet;
                    WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    App.Visible = true;

                    var cells = WorkSheet.get_Range("B2", "N51");
                    cells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;// внутренние вертикальные
                    cells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;// внутренние горизонтальные  
                    cells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;// верхняя внешняя
                    cells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble; // правая внешняя
                    cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;// левая внешняя
                 // cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;// нижняя внешняя
                    //  WorkSheet.Cells.Font.Italic = true;
                    WorkSheet.Cells[2, 2] = "Данные о запрошенном поставщике.";
                    WorkSheet.Cells[3, 2] = "Имя поставщика";
                    WorkSheet.Cells[3, 5] = "Название товаров";
                    WorkSheet.Cells[3, 8] = "ID филиалов-сотрудников";
                    WorkSheet.Cells[3, 11] = "Менеджеры-работники";
                    int indexSecond = 5;
                    int index3 = 8;
                    int index4 = 11;
             
                    WorkSheet.Cells[4, 2] = DB.Getting_smth("provider", "Name", "id = " + temp); ;
                    string id_product = DB.Getting_id("product", "ProviderId = " + temp);
                    while (id_product != "")
                    {
                        string id_Product2 = id_product.Substring(0, id_product.IndexOf(' '));
                        string name = DB.Getting_smth("product","Name", "id = " + id_product.Substring(0, id_product.IndexOf(' ')));
                        WorkSheet.Cells[4, indexSecond] = name;

                        string id_man = DB.Getting_smth("sale", "ManagerID", "ProductId = " + id_Product2);
                        while (id_man != "")
                        {
                            string id_m2 = id_man.Substring(0, id_man.IndexOf(' '));
                            string fio = DB.Getting_smth("manager", "FIO", "id =" + id_m2);
                            WorkSheet.Cells[4, index4] = fio;
                            id_man = id_man.Remove(0, id_man.IndexOf(' ') + 1);
                            index4++;
                        }
                        string id_fil = DB.Getting_smth("balance", "StorageID", "ProductId = " + id_Product2);
                        while (id_fil != "")
                        {
                            string id_f2 = id_fil.Substring(0, id_fil.IndexOf(' '));
                            WorkSheet.Cells[4, index3] = id_f2;
                            id_fil = id_fil.Remove(0, id_fil.IndexOf(' ') + 1);
                            
                        }
                      //  index3++;

                        id_product = id_product.Remove(0, id_product.IndexOf(' ') + 1);
                        indexSecond++;
                    }

                }
                if (radioButton2.Checked == true)
                {
                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Add(System.Reflection.Missing.Value);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)App.ActiveSheet;
                    WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    App.Visible = true;
                    var cells = WorkSheet.get_Range("B2", "N51");
                    cells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;// внутренние вертикальные
                    cells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;// внутренние горизонтальные  
                    cells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;// верхняя внешняя
                    cells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble; // правая внешняя
                    cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;// левая внешняя
                   // cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;// нижняя внешняя
                    //  WorkSheet.Cells.Font.Italic = true;
                    WorkSheet.Cells[2, 2] = "Данные о запрошенном филиале.";
                    WorkSheet.Cells[3, 2] = "ID филиала";
                    WorkSheet.Cells[3, 5] = "Кол-во товаров";
                    WorkSheet.Cells[3, 8] = "ID менеджеров";
                    WorkSheet.Cells[3, 11] = "ФИО менеджеров";

                    WorkSheet.Cells[4, 2] = temp;
 
                        int indexx = 5;
                    int ind = 8;
                    int ind1 = 11;
 
                        string balance = DB.Getting_id("balance", "StorageId = " + temp);
                        while (balance != "")
                        {
                            string CountSale = DB.Getting_smth("sale", "Count", "BalanceID =" + balance.Substring(0, balance.IndexOf(' ')));
                        string Manag = DB.Getting_smth("sale", "ManagerID", "BalanceID =" + balance.Substring(0, balance.IndexOf(' ')));
                        string fio = DB.Getting_smth("manager", "FIO", "id =" + Manag);
                        WorkSheet.Cells[4, indexx] = CountSale;
                        WorkSheet.Cells[4, ind] = Manag;
                        WorkSheet.Cells[4, ind1] = fio;
                        indexx++;
                        ind++;
                            balance = balance.Remove(0, balance.IndexOf(' ') + 1);       
                        }
                }
                if (radioButton3.Checked == true)
                {
                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Add(System.Reflection.Missing.Value);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)App.ActiveSheet;
                    WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    App.Visible = true;
                    var cells = WorkSheet.get_Range("B2", "N51");
                    cells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;// внутренние вертикальные
                    cells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;// внутренние горизонтальные  
                    cells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;// верхняя внешняя
                    cells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble; // правая внешняя
                    cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;// левая внешняя
                    // cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;// нижняя внешняя
                    //  WorkSheet.Cells.Font.Italic = true;
                    WorkSheet.Cells[2, 2] = "Данные о запрошенном менеджере.";
                    WorkSheet.Cells[3, 2] = "Менеджер";
                    WorkSheet.Cells[3, 5] = "Реализуемые товары";

                        int index5 = 5;
                        WorkSheet.Cells[4, 2] = DB.Getting_smth("manager", "FIO", "id = " + temp);
                        string id_product = DB.Getting_smth("sale","ProductID" ,"ManagerId = " + temp);
                
                    while (id_product != "")
                        {
                        string CountSale = DB.Getting_smth("sale", "Count", "ProductID =" + id_product.Substring(0, id_product.IndexOf(' ')));
                            WorkSheet.Cells[4, index5] = CountSale;
                        id_product = id_product.Remove(0, id_product.IndexOf(' ') + 1);
                            index5++;
                        }
                }
                if (radioButton4.Checked == true)
                {
                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Add(System.Reflection.Missing.Value);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)App.ActiveSheet;
                    WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    App.Visible = true;
                    var cells = WorkSheet.get_Range("B2", "N51");
                    cells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;// внутренние вертикальные
                    cells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;// внутренние горизонтальные  
                    cells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDouble;// верхняя внешняя
                    cells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDouble; // правая внешняя
                    cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDouble;// левая внешняя
                    // cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;// нижняя внешняя
                    //  WorkSheet.Cells.Font.Italic = true;
                    WorkSheet.Cells[2, 2] = "Данные о запрошенном товаре.";
                    WorkSheet.Cells[3, 2] = "Товар";
                    WorkSheet.Cells[3, 5] = "Ответственный менеджер";

                    int index5 = 5;
                    WorkSheet.Cells[4, 2] = DB.Getting_smth("product", "Name", "id = " + temp);;
                    string id_man = DB.Getting_smth("sale", "ManagerID", "ProductId = " + temp);

                    while (id_man != "")
                    {
                        string name = DB.Getting_smth("manager", "FIO", "id =" + id_man.Substring(0, id_man.IndexOf(' ')));
                        WorkSheet.Cells[4, index5] = name;
                        id_man = id_man.Remove(0, id_man.IndexOf(' ') + 1);
                        index5++;
                    }

                }
            }
            }

        private void button5_Click(object sender, EventArgs e)
        {
            Excel.Application excelapp = null;
            Excel.Workbooks excelappworkbooks = null;
            Excel.Workbook excelappworkbook = null;
            Excel.Sheets excelsheets = null;
            Excel.Worksheet excelworksheet = null;
            Excel.Range excelcells = null;
            Excel.Window excelWindow = null;

            excelapp = new Excel.Application();
            excelapp.Visible = true;
            excelappworkbooks = excelapp.Workbooks; excelappworkbook = excelapp.Workbooks.Open(@"E:\a1.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
            excelcells = excelworksheet.get_Range("B4", "N40");
            excelcells.Select();

            Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelapp.ActiveChart.HasTitle = true;
            excelapp.ActiveChart.ChartTitle.Text = "Диаграмма 1";

            excelapp.ActiveChart.ChartTitle.Font.Size = 13;
            excelapp.ActiveChart.ChartTitle.Font.Color = 254;

            ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory,Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Поставщики";

            ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Товары";

            ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlSeriesAxis, Excel.XlAxisGroup.xlPrimary)).HasTitle = false;

            ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
            ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;

            excelapp.ActiveChart.HasLegend = true;
            excelapp.ActiveChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionLeft;
            ((Excel.LegendEntry)excelapp.ActiveChart.Legend.LegendEntries(1)).Font.Size = 12; ((Excel.LegendEntry)excelapp.ActiveChart.Legend.LegendEntries(2)).Font.Size = 13;

            Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)excelapp.ActiveChart.SeriesCollection(Type.Missing);
            Excel.Series series = seriesCollection.Item(1);
            series.Name = "Первый ряд";

            excelapp.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, "Лист1"); excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
            excelworksheet.Shapes.Item(1).IncrementLeft(-200);
            excelworksheet.Shapes.Item(1).IncrementTop((float)18.5);
            excelworksheet.Shapes.Item(1).Height = 450;
            excelworksheet.Shapes.Item(1).Width = 450;



        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Form1
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "Form1";
        //    this.Load += new System.EventHandler(this.Form1_Load_1);
        //    this.ResumeLayout(false);

        //}

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
