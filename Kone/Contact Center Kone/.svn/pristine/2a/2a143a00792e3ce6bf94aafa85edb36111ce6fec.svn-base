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


namespace Contact_Center_Kone.Report
{
    public class ExportEmail : ReportProperty
    {
        public List<ReportEmail> myReport = new List<ReportEmail>();
        private string[] DataKolom = new string[] { 
            "DATE", "TIME", "STATUS", "DIRECTION", "USERNAME", "FROM", "TO", 
            "CC", "SUBJECT", "BODY", "TICKET NO", "CATEGORY"};

        public void GenerateReport(string fileName)
        {
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    //set the workbook properties and add a default sheet in it
                    SetWorkbookProperties(excelPackage, "JSM", "Report EMAIL");
                    //Create a sheet
                    ExcelWorksheet excelWorkSheet = CreateSheet(excelPackage, "Report EMAIL");


                    //Merging cells and create a center heading for out table
                    excelWorkSheet.Cells[1, 1].Value = "REPORT EMAIL";
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Merge = true;
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.Font.Bold = true;
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.Font.Size = 20;
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.Font.Color.SetColor(Color.Blue);
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int rowIndex = 2;

                    CreateHeader(excelWorkSheet, DataKolom, ref rowIndex);
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

            for (int i = 0; i < myReport.Count; i++)
            {

                excelWorkSheet.Cells[i + 3, 1].Value = myReport[i].mail_date;
                if (string.IsNullOrEmpty(myReport[i].mail_time))
                { excelWorkSheet.Cells[i + 3, 2].Value = new TimeSpan(00, 00, 00); }
                else
                {
                    excelWorkSheet.Cells[i + 3, 2].Value = new TimeSpan(Convert.ToInt16(myReport[i].mail_time.Substring(0, 2)),
                     Convert.ToInt16(myReport[i].mail_time.Substring(3, 2)), Convert.ToInt16(myReport[i].mail_time.Substring(6, 2)));
                }
                excelWorkSheet.Cells[i + 3, 2].Style.Numberformat.Format = "[h]:mm:ss";
                excelWorkSheet.Cells[i + 3, 3].Value = myReport[i].mail_status_name;
                excelWorkSheet.Cells[i + 3, 4].Value = myReport[i].direction_name;
                excelWorkSheet.Cells[i + 3, 5].Value = myReport[i].user_name;
                excelWorkSheet.Cells[i + 3, 6].Value = myReport[i].mail_from;
                excelWorkSheet.Cells[i + 3, 7].Value = myReport[i].mail_to;
                excelWorkSheet.Cells[i + 3, 8].Value = myReport[i].mail_cc;
                excelWorkSheet.Cells[i + 3, 9].Value = myReport[i].mail_subject;
                excelWorkSheet.Cells[i + 3, 10].Value = myReport[i].mail_text;
                excelWorkSheet.Cells[i + 3, 11].Value = myReport[i].ticket_no; 
                excelWorkSheet.Cells[i + 3, 12].Value = myReport[i].category_name; 

            }
            // ws.Column(2).Style.Numberformat.Format = "yyyy-MM-dd";
            var cell = excelWorkSheet.Cells[3, 1, myReport.Count + 2, 12];
            var border = cell.Style.Border;
            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            //cell.Style.WrapText = true;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
        }
    }
}
