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
using OfficeOpenXml.Table;
using Contact_Center_Kone.Dao;

namespace Contact_Center_Kone.Report
{
    public class ExportCallInbound : ReportProperty
    {
        public List<ReportCallInbound> myReport = new List<ReportCallInbound>();
        public DataTable dtreport = new DataTable();
        public string[] DataKolom = new string[] {  };
        ReportCallDao reportcalldao = new ReportCallDao();


        public ExportCallInbound()
        {
            DataKolom = reportcalldao.ListHeaderReportInbound().ToArray(); 
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
                    ExcelWorksheet excelWorkSheet = CreateSheet(excelPackage, "Report Call Inbound");


                    //Merging cells and create a center heading for out table
                    excelWorkSheet.Cells[1, 1].Value = "REPORT CALL INBOUND";
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
            //Step 3 : Start loading datatable form A1 cell of worksheet.
            excelWorkSheet.Cells["A2"].LoadFromDataTable(dtreport, true, TableStyles.None);

            // ws.Column(2).Style.Numberformat.Format = "yyyy-MM-dd";
            var cell = excelWorkSheet.Cells[3, 1, dtreport.Rows.Count + 2, dtreport.Columns.Count];
            var border = cell.Style.Border;
            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            //cell.Style.WrapText = true;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
        }
        //private void CreateData(ExcelWorksheet excelWorkSheet)
        //{

        //    for (int i = 0; i < myReport.Count; i++)
        //    {

        //        //excelWorkSheet.Cells[i + 3, 1].Value = Convert.ToDateTime(myReport[i].log_date).ToString("dd/MM/yyyy");
        //        excelWorkSheet.Cells[i + 3, 1].Value = Convert.ToDateTime(myReport[i].call_date).ToString("dd/MM/yyyy HH:mm:ss");
        //        excelWorkSheet.Cells[i + 3, 2].Value = myReport[i].customer;
        //        excelWorkSheet.Cells[i + 3, 3].Value = myReport[i].user_agent;
        //        excelWorkSheet.Cells[i + 3, 4].Value = myReport[i].direction;
        //        excelWorkSheet.Cells[i + 3, 5].Value = myReport[i].call_status;
        //        excelWorkSheet.Cells[i + 3, 6].Value = myReport[i].inbound_caller_type;
        //        excelWorkSheet.Cells[i + 3, 7].Value = myReport[i].inbound_type;
        //        excelWorkSheet.Cells[i + 3, 8].Value = myReport[i].inbound_type_detail;
        //        excelWorkSheet.Cells[i + 3, 9].Value = myReport[i].shift;
        //        excelWorkSheet.Cells[i + 3, 10].Value = myReport[i].payment_method;
        //        excelWorkSheet.Cells[i + 3, 11].Value = myReport[i].blank_call;
        //        excelWorkSheet.Cells[i + 3, 12].Value = myReport[i].wrong_number;
        //        excelWorkSheet.Cells[i + 3, 13].Value = myReport[i].host_addr;
        //        excelWorkSheet.Cells[i + 3, 14].Value = myReport[i].host_name;
        //        excelWorkSheet.Cells[i + 3, 15].Value = myReport[i].extension;
        //        if (string.IsNullOrEmpty(myReport[i].duration))
        //        { excelWorkSheet.Cells[i + 3, 16].Value = new TimeSpan(00, 00, 00); }
        //        else
        //        {
        //            excelWorkSheet.Cells[i + 3, 16].Value = new TimeSpan(Convert.ToInt16(myReport[i].duration.Substring(0, 2)),
        //             Convert.ToInt16(myReport[i].duration.Substring(3, 2)), Convert.ToInt16(myReport[i].duration.Substring(6, 2)));
        //        }
        //        excelWorkSheet.Cells[i + 3, 16].Style.Numberformat.Format = "[h]:mm:ss";

        //        if (string.IsNullOrEmpty(myReport[i].abandon))
        //        { excelWorkSheet.Cells[i + 3, 17].Value = new TimeSpan(00, 00, 00); }
        //        else
        //        {
        //            excelWorkSheet.Cells[i + 3, 17].Value = new TimeSpan(Convert.ToInt16(myReport[i].abandon.Substring(0, 2)),
        //            Convert.ToInt16(myReport[i].abandon.Substring(3, 2)), Convert.ToInt16(myReport[i].abandon.Substring(6, 2)));
        //        }
        //        excelWorkSheet.Cells[i + 3, 17].Style.Numberformat.Format = "[h]:mm:ss";

        //        if (string.IsNullOrEmpty(myReport[i].delay))
        //        { excelWorkSheet.Cells[i + 3, 18].Value = new TimeSpan(00, 00, 00); }
        //        else
        //        {
        //            excelWorkSheet.Cells[i + 3, 18].Value = new TimeSpan(Convert.ToInt16(myReport[i].abandon.Substring(0, 2)),
        //            Convert.ToInt16(myReport[i].abandon.Substring(3, 2)), Convert.ToInt16(myReport[i].abandon.Substring(6, 2)));
        //        }
        //        excelWorkSheet.Cells[i + 3, 18].Style.Numberformat.Format = "[h]:mm:ss";

        //        if (string.IsNullOrEmpty(myReport[i].busy))
        //        { excelWorkSheet.Cells[i + 3, 19].Value = new TimeSpan(00, 00, 00); }
        //        else
        //        {
        //            excelWorkSheet.Cells[i + 3, 19].Value = new TimeSpan(Convert.ToInt16(myReport[i].abandon.Substring(0, 2)),
        //            Convert.ToInt16(myReport[i].abandon.Substring(3, 2)), Convert.ToInt16(myReport[i].abandon.Substring(6, 2)));
        //        }
        //        excelWorkSheet.Cells[i + 3, 19].Style.Numberformat.Format = "[h]:mm:ss";

        //        excelWorkSheet.Cells[i + 3, 20].Value = myReport[i].callernumber;
        //        excelWorkSheet.Cells[i + 3, 21].Value = myReport[i].note; 
        //        excelWorkSheet.Cells[i + 3, 22].Value = myReport[i].phonenumber; 

        //    }
        //    // ws.Column(2).Style.Numberformat.Format = "yyyy-MM-dd";
        //    var cell = excelWorkSheet.Cells[3, 1, myReport.Count + 2, 22];
        //    var border = cell.Style.Border;
        //    Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");
        //    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //    cell.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
        //    //cell.Style.WrapText = true;
        //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
        //}
    }
}
