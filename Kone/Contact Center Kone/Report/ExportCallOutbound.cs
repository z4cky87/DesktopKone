using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;
using System.IO;
using System.Data;
using Contact_Center_Kone.Dao;
using OfficeOpenXml.Table;

namespace Contact_Center_Kone.Report
{
    public class ExportCallOutbound : ReportProperty
    {
         
        public DataTable dtreport = new DataTable(); 
        ReportCallDao reportcalldao = new ReportCallDao();
        private string[] DataKolom = new string[] { };

        public ExportCallOutbound()
        {
            DataKolom = reportcalldao.ListHeaderReportOutbound().ToArray();
        }

        public void GenerateReport(string fileName)
        {
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    //set the workbook properties and add a default sheet in it
                    SetWorkbookProperties(excelPackage, "JSM", "Report Call");
                    //Create a sheet
                    ExcelWorksheet excelWorkSheet = CreateSheet(excelPackage, "Report Call Outbound");


                    //Merging cells and create a center heading for out table
                    excelWorkSheet.Cells[1, 1].Value = "REPORT CALL OUTBOUND";
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Merge = true;
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.Font.Bold = true;
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.Font.Size = 20;
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.Font.Color.SetColor(Color.Blue);
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int rowIndex = 2;
                    CreateHeader(excelWorkSheet, dtreport, ref rowIndex);
                    CreateData(excelWorkSheet);
                    //CreateFooter(ws, ref rowIndex);

                    //Generate A File with Random name
                    Byte[] bin = excelPackage.GetAsByteArray();
                    string file = fileName + ".xlsx";
                    File.WriteAllBytes(file, bin);

                }
            }
            catch (Exception ex) { Global.WriteLog(Global.GetCurrentMethod(ex)); }
        }

        private void CreateData(ExcelWorksheet excelWorkSheet)
        {
            //Step 3 : Start loading datatable form A1 cell of worksheet.
            excelWorkSheet.Cells["A2"].LoadFromDataTable(dtreport, true, TableStyles.None);

            // ws.Column(2).Style.Numberformat.Format = "yyyy-MM-dd";
            var cell = excelWorkSheet.Cells[3, 1, dtreport.Rows.Count + 3, dtreport.Columns.Count];
            var border = cell.Style.Border;
            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            //cell.Style.WrapText = true;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
        }


    }
}
