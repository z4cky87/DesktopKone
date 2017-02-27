using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using System.Threading;



namespace Contact_Center_Kone.View
{
    public partial class Dashboard : Form
    {
       
        DirectionDao directiondao = new DirectionDao();
        DashboardDao dashboarddao = new DashboardDao();
        public Thread thread_loadchart;
        private static int directionid;
        public Dashboard()
        {
            InitializeComponent();  
        }

        private void loaddirecton()
        {
            cmb_direction.DataSource = directiondao.GetListDirection();
            cmb_direction.DisplayMember = "direction";
            cmb_direction.ValueMember = "id";
        } 

        private void GetChart()
        {
            try
            {
                
                    Chart barChart = new Chart();
                    Legend legend = new Legend();
                    ChartArea chartarea = new ChartArea();
                    Series series = new Series();
                    ///chart1.Titles.Add("TEST");
                while (true)
                {
                    Console.WriteLine(directionid);
                    string _datefrom = dte_from.Value.ToString("yyyy-MM-dd");
                    string _dateuntil = dte_until.Value.ToString("yyyy-MM-dd");

                    List<DynamicDashboard> listdyc = new List<DynamicDashboard>();

                    if (directionid == 1)
                        listdyc = dashboarddao.dynamicDashboardInbound(_datefrom, _dateuntil);
                    else if (directionid == 2)
                        listdyc = dashboarddao.dynamicDashboardOutbound(_datefrom, _dateuntil);

                    Font fonts = new System.Drawing.Font(this.Font.Name, 16, FontStyle.Bold);
                    dynamicSetChart(barChart, chart1, legend, fonts, chartarea, series, listdyc, directionid);

                    //DashboardEntity dash_enty = new DashboardEntity();
                    //dash_enty = dashboarddao.GetCount_DashboardInbound(_datefrom, _dateuntil, directionid); 

                    //Font fonts = new System.Drawing.Font(this.Font.Name, 16, FontStyle.Bold);
                    
                    //setChart(barChart, chart1, legend, fonts, chartarea, series,
                    //    dash_enty.total_complain, dash_enty.total_inquiry, dash_enty.total_prospect_customer, dash_enty.total_request,
                    //    dash_enty.total_blankcall, dash_enty.total_wrongnumber, dash_enty.total_testcall,dash_enty.total_others, 
                    //    dash_enty.total_customer,dash_enty.total_dealer,
                    //    "TESTT", directionid);
                    Thread.Sleep(2000);
                }
            }
            catch (Exception Ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(Ex));
            }

        }

        delegate void delegateDynamicChart(Chart chart, Chart charts, Legend legend, Font font, ChartArea chartarea, Series series, List<DynamicDashboard> listchart, int directionId);
        private void dynamicSetChart(Chart chart, Chart charts, Legend legend, Font font, ChartArea chartarea, Series series, List<DynamicDashboard> listchart, int directionId)
        {
            if (charts.InvokeRequired)
            {
                delegateDynamicChart ddc = new delegateDynamicChart(dynamicSetChart);
                this.Invoke(ddc, new Object[] { chart, charts, legend, font, chartarea, series, listchart, directionId });
            }
            else
            {

                series.Points.Clear();
                charts.Series.Clear();
                chart.Update();
                charts.Update();

                chartarea.Name = "BarChartArea";
                //charts.ChartAreas.Add(chartarea);
                charts.Dock = System.Windows.Forms.DockStyle.Fill;
                legend.Name = "Legend3";
                //charts.Legends.Add(legend);
                charts.Series.Clear();
                charts.BackColor = Color.GreenYellow;
                charts.Palette = ChartColorPalette.BrightPastel;
                //charts.Titles.Add("TEST"); 
                charts.ChartAreas[0].BackColor = Color.Transparent;
                charts.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                charts.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                series.Name = "series2";
                series.IsVisibleInLegend = false;
                series.ChartType = SeriesChartType.StackedBar;


                charts.Series.Add(series);
                if (directionId == 1)
                {
                    foreach (var _series in chart.Series)
                    {
                        _series.Points.Clear();
                    }


                    int count = 0;
                    foreach (var item in listchart)
                    {
                        series.Points.Add(Convert.ToInt32(item.total));
                        var _c = series.Points[count];
                        _c.Color = Color.Green;
                        _c.AxisLabel = item.name;
                        _c.LegendText = item.name;
                        _c.Label = item.total;
                        charts.Invalidate();
                        count++;
                    }
                }
                else if (directionId == 2)
                {
                    foreach (var _series in chart.Series)
                    {
                        _series.Points.Clear();
                    }


                    int count = 0;
                    foreach (var item in listchart)
                    {
                        series.Points.Add(Convert.ToInt32(item.total));
                        var _c = series.Points[count];
                        _c.Color = Color.Green;
                        _c.AxisLabel = item.name;
                        _c.LegendText = item.name;
                        _c.Label = item.total;
                        charts.Invalidate();
                        count++;
                    }
                }



            }
        }
         

        delegate void delegatesetChart(Chart chart,Chart charts, Legend legend, Font font, ChartArea chartarea, Series series,
            string ttl_complain, string ttl_inquiry, string ttl_prospectcustomer, string ttl_request, string ttl_blankcall, string ttl_wrongnumber, string ttl_testcall, string ttl_others,
            string ttl_customer, string ttl_dealer,
            string title,
            int direction);
       private void setChart(Chart chart, Chart charts, Legend legend, Font font, ChartArea chartarea, Series series,
            string ttl_complain, string ttl_inquiry, string ttl_prospectcustomer, string ttl_request, string ttl_blankcall, string ttl_wrongnumber, string ttl_testcall, string ttl_others,
            string ttl_customer, string ttl_dealer,
            string title,
            int direction)
        {
            if (charts.InvokeRequired)
            {
                delegatesetChart d = new delegatesetChart(setChart);
                this.Invoke(d, new Object[] { chart, charts, legend, font, chartarea, series, 
                    ttl_complain, ttl_inquiry, ttl_prospectcustomer, ttl_request, ttl_blankcall, ttl_wrongnumber, ttl_testcall, ttl_others, 
                    ttl_customer, ttl_dealer,
                    title,direction  });
            }else
            { 
                 
                series.Points.Clear();
                charts.Series.Clear();
                chart.Update();
                charts.Update();

                chartarea.Name = "BarChartArea";
                //charts.ChartAreas.Add(chartarea);
                charts.Dock = System.Windows.Forms.DockStyle.Fill;
                legend.Name = "Legend3";
                //charts.Legends.Add(legend);
                charts.Series.Clear();
                charts.BackColor = Color.GreenYellow;
                charts.Palette = ChartColorPalette.BrightPastel;
                //charts.Titles.Add("TEST"); 
                charts.ChartAreas[0].BackColor = Color.Transparent;
                charts.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                charts.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                
                series.Name = "series2";
                series.IsVisibleInLegend = false;
                series.ChartType = SeriesChartType.StackedBar;
                  
                charts.Series.Add(series);

                if (directionid == 2)
                {
                    

                    series.Points.Add(Convert.ToInt32(ttl_others));
                    var p2 = series.Points[0];
                    p2.Color = Color.Yellow;
                    p2.AxisLabel = "Other";
                    p2.LegendText = "Other";
                    p2.Label = ttl_others;

                    series.Points.Add(Convert.ToInt32(ttl_dealer));
                    var p3 = series.Points[1];
                    p3.Color = Color.Yellow;
                    p3.AxisLabel = "Dealer";
                    p3.LegendText = "Dealer";
                    p3.Label = ttl_dealer;

                    series.Points.Add(Convert.ToInt32(ttl_customer));
                    var p1 = series.Points[2];
                    p1.Color = Color.Red;
                    p1.AxisLabel = "Customer";
                    p1.LegendText = "Customer";
                    p1.Label = ttl_customer;
                }
                else
                { 
                     
                    series.Points.Add(Convert.ToInt32(ttl_others));
                    var p8 = series.Points[0];
                    p8.Color = Color.Green;
                    p8.AxisLabel = "Others";
                    p8.LegendText = "Others";
                    p8.Label = ttl_others;
                    charts.Invalidate();

                    series.Points.Add(Convert.ToInt32(ttl_testcall));
                    var p7 = series.Points[1];
                    p7.Color = Color.Green;
                    p7.AxisLabel = "TestCall";
                    p7.LegendText = "TestCall";
                    p7.Label = ttl_testcall;
                    charts.Invalidate();

                    series.Points.Add(Convert.ToInt32(ttl_wrongnumber));
                    var p6 = series.Points[2];
                    p6.Color = Color.Green;
                    p6.AxisLabel = "WrongNumber";
                    p6.LegendText = "WrongNumber";
                    p6.Label = ttl_wrongnumber;
                    charts.Invalidate();

                    series.Points.Add(Convert.ToInt32(ttl_blankcall));
                    var p5 = series.Points[3];
                    p5.Color = Color.Green;
                    p5.AxisLabel = "BlankCall";
                    p5.LegendText = "BlankCall";
                    p5.Label = ttl_blankcall;
                    charts.Invalidate();

                    series.Points.Add(Convert.ToInt32(ttl_request));
                    var p4 = series.Points[4];
                    p4.Color = Color.Green;
                    p4.AxisLabel = "Request";
                    p4.LegendText = "Request";
                    p4.Label = ttl_request;

                    series.Points.Add(Convert.ToInt32(ttl_prospectcustomer));
                    var p3 = series.Points[5];
                    p3.Color = Color.Green;
                    p3.AxisLabel = "ProspectCustomer";
                    p3.LegendText = "ProspectCustomer";
                    p3.Label = ttl_prospectcustomer;

                    series.Points.Add(Convert.ToInt32(ttl_complain));
                    var p1 = series.Points[6];
                    p1.Color = Color.Red;
                    p1.AxisLabel = "Complain";
                    p1.LegendText = "Complain";
                    p1.Label = ttl_complain;

                    series.Points.Add(Convert.ToInt32(ttl_inquiry));
                    var p2 = series.Points[7];
                    p2.Color = Color.Yellow;
                    p2.AxisLabel = "Inquiry";
                    p2.LegendText = "Inquiry";
                    p2.Label = ttl_inquiry;
                }
               

                //charts.Controls.Add(chart); 
            }

           
        }




        //void LoadBarChart()
        //{
        //    barChart = new Chart();
            
        //    Legend legend2 = new Legend();
        //    ChartArea chartArea1 = new ChartArea(); 
        //    //chartArea1 = new ChartArea();
            
        //    //====Bar Chart
        //    chartArea1.Name = "BarChartArea";
        //    barChart.ChartAreas.Add(chartArea1);
        //    barChart.Dock = System.Windows.Forms.DockStyle.Fill;
        //    legend2.Name = "Legend3";
        //    barChart.Legends.Add(legend2);


        //    barChart.Series.Clear();
        //    barChart.BackColor = Color.LightYellow;
        //    barChart.Palette = ChartColorPalette.Fire;
        //    barChart.Titles.Add("TEST");
        //    barChart.ChartAreas[0].BackColor = Color.Transparent;
        //    barChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        //    barChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
           
        //    Series series = new Series
        //    {
        //        Name = "series2",
        //        IsVisibleInLegend = false,
        //        ChartType = SeriesChartType.StackedBar
                
        //    };
          
        //    barChart.Series.Add(series); 

        //    series.Points.Add(70000);
        //    var p1 = series.Points[0];
        //    p1.Color = Color.Red;
        //    p1.AxisLabel = "Hiren Khirsaria";
        //    p1.LegendText = "Hiren Khirsarias";
        //    p1.Label = "70000";

        //    series.Points.Add(30000);
        //    var p2 = series.Points[1];
        //    p2.Color = Color.Yellow;
        //    p2.AxisLabel = "ABC XYZ";
        //    p2.LegendText = "ABC XYZs";
        //    p2.Label = "30000";
             
        //    series.Points.Add(30000);
        //    var p3 = series.Points[2];
        //    p3.Color = Color.Green;
        //    p3.AxisLabel = "ABC XYZ";
        //    p3.LegendText = "ABC XYZs";
        //    p3.Label = "INBOUND 30000";
             

        //    barChart.Invalidate();

        //    chart1.Controls.Add(barChart);
        //} 
        private void cmb_direction_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            if (cmb_direction.SelectedIndex == 0)
            {
                cmb_direction.SelectedIndex = 1; 
            }
        } 
         
        private void Dashboard_Load(object sender, EventArgs e)
        {
            loaddirecton();
            cmb_direction.SelectedIndex = 1;
            directionid = Convert.ToInt32(cmb_direction.SelectedValue);

            thread_loadchart = new System.Threading.Thread(new ThreadStart(GetChart));
            thread_loadchart.Start();

            geckoWebBrowser1.Navigate("www.kone.com");

        }

        private void cmb_direction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_direction.SelectedIndex == 0)
            {
                cmb_direction.SelectedIndex = 1;
            }
            directionid = Convert.ToInt32(cmb_direction.SelectedValue); 
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {

        }

        private void geckoWebBrowser1_Click(object sender, EventArgs e)
        {

        }
    }
}
