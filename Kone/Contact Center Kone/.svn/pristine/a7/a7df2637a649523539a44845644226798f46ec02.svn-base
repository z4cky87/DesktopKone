using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Utility;
using Contact_Center_Kone.Entity;
using OfficeOpenXml.Style;
using System.IO;
using OfficeOpenXml;
using System.Drawing;

namespace Contact_Center_Kone.Report
{
    public class ExportPBX : ReportProperty
    {
        public List<ReportPBX> myReport = new List<ReportPBX>();
        private string[] DataKolom = new string[] {
            "DATE","TIME","UNIQUE ID","CALLER NUMBER", "DNID", "CHANNEL", "CALL STATUS", "ABANDON STATUS", "TALK DURATION",
            "USERNAME", "HOST ADDRESS", "EXTENTION", "IVR DURATION", "QUEUE DURATION", "TOTAL AGENT READY", "TOTAL AGENT BREAK", "TOTAL AGENT BUSY", "TOTAL AGENT ONLINE"};
        public void GenerateReport(string fileName)
        {
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    //set the workbook properties and add a default sheet in it
                    SetWorkbookProperties(excelPackage, "JSM", "Report PBX");
                    //Create a sheet
                    ExcelWorksheet excelWorkSheet = CreateSheet(excelPackage, "Report PBX");

                    //Merging cells and create a center heading for out table
                    excelWorkSheet.Cells[1, 1].Value = "Report PBX";
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Merge = true;
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.Font.Bold = true;
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.Font.Size = 20;
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.Font.Color.SetColor(Color.Blue);
                    excelWorkSheet.Cells[1, 1, 1, DataKolom.Length].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int rowIndex = 2;

                    CreateHeader(excelWorkSheet, DataKolom, ref rowIndex);
                    CreateData(excelWorkSheet);

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

                //excelWorkSheet.Cells[i + 3, 1].Value = myReport[i].mail_date;
                //if (string.IsNullOrEmpty(myReport[i].mail_time))
                //{ excelWorkSheet.Cells[i + 3, 2].Value = new TimeSpan(00, 00, 00); }
                //else
                //{
                //    excelWorkSheet.Cells[i + 3, 2].Value = new TimeSpan(Convert.ToInt16(myReport[i].mail_time.Substring(0, 2)),
                //     Convert.ToInt16(myReport[i].mail_time.Substring(3, 2)), Convert.ToInt16(myReport[i].mail_time.Substring(6, 2)));
                //}
                //excelWorkSheet.Cells[i + 3, 2].Style.Numberformat.Format = "[h]:mm:ss";
                excelWorkSheet.Cells[i + 3, 1].Value = myReport[i].date;
                excelWorkSheet.Cells[i + 3, 2].Value = myReport[i].time;
                //excelWorkSheet.Cells[i + 3, 1].Value = Convert.ToDateTime(myReport[i].date).ToString("dd/MM/yyyy HH:mm:ss");
                //excelWorkSheet.Cells[i + 3, 2].Value = Convert.ToDateTime(myReport[i].time).ToString("dd/MM/yyyy HH:mm:ss");
                excelWorkSheet.Cells[i + 3, 3].Value = myReport[i].unique_id;
                //excelWorkSheet.Cells[i + 3, 4].Value = myReport[i].source_name;
                excelWorkSheet.Cells[i + 3, 4].Value = myReport[i].callerid_no;
                excelWorkSheet.Cells[i + 3, 5].Value = myReport[i].dnid;
                excelWorkSheet.Cells[i + 3, 6].Value = myReport[i].channel;
                excelWorkSheet.Cells[i + 3, 7].Value = myReport[i].call_status;
                excelWorkSheet.Cells[i + 3, 8].Value = myReport[i].abandon_status;
                excelWorkSheet.Cells[i + 3, 9].Value = myReport[i].talk_duration;
                excelWorkSheet.Cells[i + 3, 10].Value = myReport[i].username;
                excelWorkSheet.Cells[i + 3, 11].Value = myReport[i].host_address;
                excelWorkSheet.Cells[i + 3, 12].Value = myReport[i].extention;
                excelWorkSheet.Cells[i + 3, 13].Value = myReport[i].ivr_duration;
                excelWorkSheet.Cells[i + 3, 14].Value = myReport[i].queue_duration;
                excelWorkSheet.Cells[i + 3, 15].Value = myReport[i].total_agent_ready;
                excelWorkSheet.Cells[i + 3, 16].Value = myReport[i].total_agent_break;
                excelWorkSheet.Cells[i + 3, 17].Value = myReport[i].total_agent_busy;
                excelWorkSheet.Cells[i + 3, 18].Value = myReport[i].total_agent_online;

            }
            // ws.Column(2).Style.Numberformat.Format = "yyyy-MM-dd";
            var cell = excelWorkSheet.Cells[3, 1, myReport.Count + 2, 18]; // grid garis
            var border = cell.Style.Border;
            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            //cell.Style.WrapText = true;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
        }

    }
}
