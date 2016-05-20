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
            switch(a)
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
                        //!!!excelcells = excelworksheet.get_Range("B4", "H7"); //диапазон ячеек
                        excelcells.Select();

                        Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        excelapp.ActiveChart.HasTitle = true;
                        excelapp.ActiveChart.ChartTitle.Text = "Диаграмма 2";

                        excelapp.ActiveChart.ChartTitle.Font.Size = 13;
                        excelapp.ActiveChart.ChartTitle.Font.Color = 254;

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Кол-во продаж";

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Товары";

                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMajorGridlines = true;
                        ((Excel.Axis)excelapp.ActiveChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasMinorGridlines = false;

                        excelapp.ActiveChart.HasLegend = true;
                        excelapp.ActiveChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionLeft;
                        ((Excel.LegendEntry)excelapp.ActiveChart.Legend.LegendEntries(1)).Font.Size = 12; ((Excel.LegendEntry)excelapp.ActiveChart.Legend.LegendEntries(2)).Font.Size = 13;

                        Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)excelapp.ActiveChart.SeriesCollection(Type.Missing);
                        Excel.Series series = seriesCollection.Item(1);
                        series.Name = "Первый ряд";

                        excelapp.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, "Лист1"); excelsheets = excelappworkbook.Worksheets;
                        excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1); break;
                    }
                case 2: {
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
                        excelcells = excelworksheet.get_Range("B4", "H7");
                        excelcells.Select();

                        Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        excelapp.ActiveChart.HasTitle = true;
                        excelapp.ActiveChart.ChartTitle.Text = "Диаграмма 1";

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
                        series.Name = "Первый ряд";

                        excelapp.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, "Лист1"); excelsheets = excelappworkbook.Worksheets;
                        excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                        break; }
                case 3: {
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
                        ///!!! excelcells = excelworksheet.get_Range("B4", "H7"); //диапазон ячеек
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
                        break; }
                case 4: {
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
                        ///!!!excelcells = excelworksheet.get_Range("B4", "H7"); //диапазон ячеек
                        excelcells.Select();

                        Excel.Chart excelchart = (Excel.Chart)excelapp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        excelapp.ActiveChart.HasTitle = true;
                        excelapp.ActiveChart.ChartTitle.Text = "Диаграмма 4";

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
                        break; }
            }
           
        }
    }
}
