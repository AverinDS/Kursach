using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;


namespace Coursework
{
    class MakeReportIntoFile //создание отчёта в файл
    {
        public void Diagram(int a)
        {
            switch (a)
            {
                case 1:
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
                        excelcells = excelworksheet.get_Range("F29", "V40"); //диапазон ячеек
                        excelcells.Select();

                        Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        excelapp.ActiveChart.HasTitle = true;
                        excelapp.ActiveChart.ChartTitle.Text = "Продаваемость товаров";

                        excelapp.ActiveChart.ChartTitle.Font.Size = 13;
                        excelapp.ActiveChart.ChartTitle.Font.Color = 254;

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "ID Товара";

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Количество проданного товара";

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;

                        excelapp.ActiveChart.HasLegend = true;
                        excelapp.ActiveChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionLeft;
                        ((Excel.LegendEntry)excelapp.ActiveChart.Legend.LegendEntries(1)).Font.Size = 12; ((Excel.LegendEntry)excelapp.ActiveChart.Legend.LegendEntries(2)).Font.Size = 13;

                        Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)excelapp.ActiveChart.SeriesCollection(Type.Missing);
                        Excel.Series series = seriesCollection.Item(1);
                       // series.Name = "Первый ряд";

                        excelapp.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, "Лист1"); excelsheets = excelappworkbook.Worksheets;
                        excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1); break;
                    }
                case 2:
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
                        excelcells = excelworksheet.get_Range("F4", "J9");
                        excelcells.Select();

                        Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        excelapp.ActiveChart.HasTitle = true;
                        excelapp.ActiveChart.ChartTitle.Text = "Предложения товаров от поставщиков";

                        excelapp.ActiveChart.ChartTitle.Font.Size = 13;
                        excelapp.ActiveChart.ChartTitle.Font.Color = 254;

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Поставщики";

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Товары";

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;

                        excelapp.ActiveChart.HasLegend = true;
                        excelapp.ActiveChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionLeft;
                        ((Excel.LegendEntry)excelapp.ActiveChart.Legend.LegendEntries(1)).Font.Size = 12; ((Excel.LegendEntry)excelapp.ActiveChart.Legend.LegendEntries(2)).Font.Size = 13;

                        Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)excelapp.ActiveChart.SeriesCollection(Type.Missing);
                        Excel.Series series = seriesCollection.Item(1);
                        //series.Name = "Первый ряд";

                        excelapp.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, "Лист1"); excelsheets = excelappworkbook.Worksheets;
                        excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                        break;
                    }
                case 3:
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
                        excelcells = excelworksheet.get_Range("S18","F12" ); //диапазон ячеек
                        excelcells.Select();

                        Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        excelapp.ActiveChart.HasTitle = true;
                        excelapp.ActiveChart.ChartTitle.Text = "Диаграмма 3";

                        excelapp.ActiveChart.ChartTitle.Font.Size = 13;
                        excelapp.ActiveChart.ChartTitle.Font.Color = 254;

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Реализация";

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Филиалы";

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
                        break;

                    }
                case 4:
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
                        excelcells = excelworksheet.get_Range("F21", "J25"); //диапазон ячеек
                        excelcells.Select();

                        Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        excelapp.ActiveChart.HasTitle = true;
                        excelapp.ActiveChart.ChartTitle.Text = "Результативность менеджеров";

                        excelapp.ActiveChart.ChartTitle.Font.Size = 13;
                        excelapp.ActiveChart.ChartTitle.Font.Color = 254;

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Кол-во продаж";

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Менеджеры";

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
                        break;
                    }
            }

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
    }
}
