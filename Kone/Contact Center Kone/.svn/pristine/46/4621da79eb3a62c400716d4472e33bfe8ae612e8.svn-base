using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Report
{
    public class ReportProperty
    {
        internal ExcelWorksheet CreateSheet(ExcelPackage excelPackage, string sheetName)
        {
            excelPackage.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet excelWorkSheet = excelPackage.Workbook.Worksheets[1];
            excelWorkSheet.Name = sheetName; //Setting Sheet's name
            excelWorkSheet.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            excelWorkSheet.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet
            return excelWorkSheet;
        }
        internal void SetWorkbookProperties(ExcelPackage excelPackage, string author, string title)
        {
            //Here setting some document properties
            excelPackage.Workbook.Properties.Author = author;
            excelPackage.Workbook.Properties.Title = title;
        }
        internal void CreateHeader(ExcelWorksheet excelWorkSheet, string[] columns, ref int rowIndex)
        {
            int colIndex = 1;
            foreach (string kolom in columns) //Creating Headings
            {

                var cell = excelWorkSheet.Cells[rowIndex, colIndex];

                //Setting the background color of header cells to Gray
                var fill = cell.Style.Fill;
                cell.Style.Font.Color.SetColor(Color.White);
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.DodgerBlue);
                //Setting Top/left,right/bottom borders.
                var border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                //Setting Value in cell
                cell.Value = kolom; cell.AutoFitColumns(20);
                colIndex++;
            }
        }

        internal void CreateHeader(ExcelWorksheet excelWorkSheet, DataTable dt, ref int rowIndex)
        {
            int colIndex = 1;
            foreach (DataColumn kolom in dt.Columns) //Creating Headings
            {

                var cell = excelWorkSheet.Cells[rowIndex, colIndex];

                //Setting the background color of header cells to Gray
                var fill = cell.Style.Fill;
                cell.Style.Font.Color.SetColor(Color.White);
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.DodgerBlue);
                //Setting Top/left,right/bottom borders.
                var border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                //Setting Value in cell
                cell.Value = kolom; cell.AutoFitColumns(20);
                colIndex++;
            }
        }
    }
}
