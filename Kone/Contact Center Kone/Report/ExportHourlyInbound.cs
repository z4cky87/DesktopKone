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
    public class ExportHourlyInbound : ReportProperty
    {
        public List<ReportHourlyInbound> myReport = new List<ReportHourlyInbound>();
        private string[] DataKolom = new string[] { };

        public DataTable dtreport = new DataTable(); 
        ReportHourlyDao rpothourlyDao = new ReportHourlyDao();

        public ExportHourlyInbound()
        {
            DataKolom = rpothourlyDao.ListHeaderReportInbound().ToArray(); 
        }

        public void GenerateReport(string fileName)
        {
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    //set the workbook properties and add a default sheet in it
                    SetWorkbookProperties(excelPackage, "JSM", "Report HOURLY INBOUND");
                    //Create a sheet
                    ExcelWorksheet excelWorkSheet = CreateSheet(excelPackage, "Report HOURLY INBOUND");


                    //Merging cells and create a center heading for out table
                    excelWorkSheet.Cells[1, 1].Value = "REPORT HOURLY INBOUND";
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

        //private void CreateData(ExcelWorksheet excelWorkSheet)
        //{

        //    for (int i = 0; i < myReport.Count; i++)
        //    {

        //        excelWorkSheet.Cells[i + 3, 1].Value = myReport[i].hour;
        //        excelWorkSheet.Cells[i + 3, 2].Value = myReport[i].total_recieve;
        //        excelWorkSheet.Cells[i + 3, 3].Value = myReport[i].total_answered;
        //        excelWorkSheet.Cells[i + 3, 4].Value = myReport[i].total_abandon;
        //        excelWorkSheet.Cells[i + 3, 5].Value = myReport[i].total_phantom;
        //        if (string.IsNullOrEmpty(myReport[i].total_callduration))
        //        { excelWorkSheet.Cells[i + 3, 6].Value = new TimeSpan(00, 00, 00); }
        //        else
        //        {
        //            excelWorkSheet.Cells[i + 3, 6].Value = new TimeSpan(Convert.ToInt16(myReport[i].total_callduration.Substring(0, 2)),
        //             Convert.ToInt16(myReport[i].total_callduration.Substring(3, 2)), Convert.ToInt16(myReport[i].total_callduration.Substring(6, 2)));
        //        }
        //        excelWorkSheet.Cells[i + 3, 6].Style.Numberformat.Format = "[h]:mm:ss";

        //        if (string.IsNullOrEmpty(myReport[i].total_avgcallduration))
        //        { excelWorkSheet.Cells[i + 3, 7].Value = new TimeSpan(00, 00, 00); }
        //        else
        //        {
        //            excelWorkSheet.Cells[i + 3, 7].Value = new TimeSpan(Convert.ToInt16(myReport[i].total_avgcallduration.Substring(0, 2)),
        //             Convert.ToInt16(myReport[i].total_avgcallduration.Substring(3, 2)), Convert.ToInt16(myReport[i].total_avgcallduration.Substring(6, 2)));
        //        }
        //        excelWorkSheet.Cells[i + 3, 7].Style.Numberformat.Format = "[h]:mm:ss";

        //        if (string.IsNullOrEmpty(myReport[i].total_acw))
        //        { excelWorkSheet.Cells[i + 3, 8].Value = new TimeSpan(00, 00, 00); }
        //        else
        //        {
        //            excelWorkSheet.Cells[i + 3, 8].Value = new TimeSpan(Convert.ToInt16(myReport[i].total_acw.Substring(0, 2)),
        //             Convert.ToInt16(myReport[i].total_acw.Substring(3, 2)), Convert.ToInt16(myReport[i].total_acw.Substring(6, 2)));
        //        }
        //        excelWorkSheet.Cells[i + 3, 8].Style.Numberformat.Format = "[h]:mm:ss";

        //        if (string.IsNullOrEmpty(myReport[i].total_avgacw))
        //        { excelWorkSheet.Cells[i + 3, 9].Value = new TimeSpan(00, 00, 00); }
        //        else
        //        {
        //            excelWorkSheet.Cells[i + 3, 9].Value = new TimeSpan(Convert.ToInt16(myReport[i].total_avgacw.Substring(0, 2)),
        //             Convert.ToInt16(myReport[i].total_avgacw.Substring(3, 2)), Convert.ToInt16(myReport[i].total_avgacw.Substring(6, 2)));
        //        }
        //        excelWorkSheet.Cells[i + 3, 9].Style.Numberformat.Format = "[h]:mm:ss";

        //        excelWorkSheet.Cells[i + 3, 10].Value = myReport[i].total_blankcall;
        //        excelWorkSheet.Cells[i + 3, 11].Value = myReport[i].total_wrongno;
        //        excelWorkSheet.Cells[i + 3, 12].Value = myReport[i].total_inquiry;
        //        excelWorkSheet.Cells[i + 3, 13].Value = myReport[i].total_complaint;
        //        excelWorkSheet.Cells[i + 3, 14].Value = myReport[i].total_prospectcust;
        //        excelWorkSheet.Cells[i + 3, 15].Value = myReport[i].total_request;
        //        excelWorkSheet.Cells[i + 3, 16].Value = myReport[i].total_testcall;
        //        excelWorkSheet.Cells[i + 3, 17].Value = myReport[i].total_others;
        //    }
        //    // ws.Column(2).Style.Numberformat.Format = "yyyy-MM-dd";
        //    var cell = excelWorkSheet.Cells[3, 1, myReport.Count + 2, 18];
        //    var border = cell.Style.Border;
        //    Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");
        //    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //    cell.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
        //    //cell.Style.WrapText = true;
        //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
        //}

        private void CreateData(ExcelWorksheet excelWorkSheet)
        {
            //Step 3 : Start loading datatable form A1 cell of worksheet.
            excelWorkSheet.Cells["A2"].LoadFromDataTable(dtreport, true, TableStyles.None);
            excelWorkSheet.Column(Array.IndexOf(DataKolom, "Duration") + 1).Style.Numberformat.Format = "[hh]:mm:ss";
            excelWorkSheet.Column(Array.IndexOf(DataKolom, "Total Avg Duration") + 1).Style.Numberformat.Format = "[hh]:mm:ss";
            excelWorkSheet.Column(Array.IndexOf(DataKolom, "Total ACW") + 1).Style.Numberformat.Format = "[hh]:mm:ss";
            excelWorkSheet.Column(Array.IndexOf(DataKolom, "Total Avg ACW") + 1).Style.Numberformat.Format = "[hh]:mm:ss";
            excelWorkSheet.Column(Array.IndexOf(DataKolom, "Total Speed Of Answer") + 1).Style.Numberformat.Format = "[hh]:mm:ss";
            excelWorkSheet.Column(Array.IndexOf(DataKolom, "Total Avg Speed Of Answer") + 1).Style.Numberformat.Format = "[hh]:mm:ss";
            // ws.Column(2).Style.Numberformat.Format = "yyyy-MM-dd";
            var cell = excelWorkSheet.Cells[3, 1, dtreport.Rows.Count + 2, dtreport.Columns.Count];
            var border = cell.Style.Border;
            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            //cell.Style.WrapText = true;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
        }

    
    }
}
