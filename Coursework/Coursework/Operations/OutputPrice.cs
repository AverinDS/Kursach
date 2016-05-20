using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Coursework
{
    class OutPutPrice
        //загрузка прайсов
    {
        public void output()
        {
            WorkWithDatabase DB = new WorkWithDatabase();
            DB.CreatingOrFindingTable();
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

            WorkSheet.Cells[2, 2] = "__________________ПРАЙС-ЛИСТ__________________";
            WorkSheet.Cells[3, 2] = "Товар";
            WorkSheet.Cells[3, 5] = "Поставщик";
            WorkSheet.Cells[3, 8] = "Цена";
            WorkSheet.Cells[3, 11] = "Валюта";
            string ID_prod = DB.Getting_id("product");

            int indexFirst = 4;
            int index2 = 2;
            int index3 = 5;
            int index4 = 8;
            int index5 = 11;

            while (ID_prod != "")
            {
                string id = ID_prod.Substring(0, ID_prod.IndexOf(' '));
                string name = DB.Getting_smth("product", "Name", "id =" + id);
                WorkSheet.Cells[indexFirst, index2] = name;
                string id_provid = DB.Getting_smth("product", "ProviderID", "id =" + id);
                string name2 = DB.Getting_smth("provider", "Name", "id =" + id_provid);
                WorkSheet.Cells[indexFirst, index3] = name2;
                string price = DB.Getting_smth("product", "Price", "id =" + id);
                WorkSheet.Cells[indexFirst, index4] = price;
                string val = DB.Getting_smth("provider", "Currensy", "id =" + id_provid);
                WorkSheet.Cells[indexFirst, index5] = val;
                indexFirst++;
                ID_prod = ID_prod.Remove(0, ID_prod.IndexOf(' ') + 1);
            }
        }


}
}
