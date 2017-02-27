using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contact_Center_Kone.View
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private void tabControlInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlInformation.SelectedIndex == 0)
            {

                View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"Addres Branch Toshiba.pdf");
                infoDetail.TopLevel = false;
                infoDetail.Dock = DockStyle.Fill;
                infoDetail.Visible = true;
                infoDetail.FormBorderStyle = FormBorderStyle.None;
                this.tabControlInformation.TabPages[0].Controls.Add(infoDetail);
            }
            else if (tabControlInformation.SelectedIndex == 1)
            {

                View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"symtom code.pdf");
                infoDetail.TopLevel = false;
                infoDetail.Dock = DockStyle.Fill;
                infoDetail.Visible = true;
                infoDetail.FormBorderStyle = FormBorderStyle.None;
                this.tabControlInformation.TabPages[1].Controls.Add(infoDetail);
            }
            else if (tabControlInformation.SelectedIndex == 2)
            {
                View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"Repair Code.pdf");
                infoDetail.TopLevel = false;
                infoDetail.Dock = DockStyle.Fill;
                infoDetail.Visible = true;
                infoDetail.FormBorderStyle = FormBorderStyle.None;
                this.tabControlInformation.TabPages[2].Controls.Add(infoDetail);
            }
            else if (tabControlInformation.SelectedIndex == 3)
            {
                View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"Status Repair Code.pdf");
                infoDetail.TopLevel = false;
                infoDetail.Dock = DockStyle.Fill;
                infoDetail.Visible = true;
                infoDetail.FormBorderStyle = FormBorderStyle.None;
                this.tabControlInformation.TabPages[3].Controls.Add(infoDetail);
            }
            else if (tabControlInformation.SelectedIndex == 4)
            {
                View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"List all dealer Toshiba.pdf");
                infoDetail.TopLevel = false;
                infoDetail.Dock = DockStyle.Fill;
                infoDetail.Visible = true;
                infoDetail.FormBorderStyle = FormBorderStyle.None;
                this.tabControlInformation.TabPages[4].Controls.Add(infoDetail);
            }
            else if (tabControlInformation.SelectedIndex == 5)
            {
                View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"top 10 Dealers.pdf");
                infoDetail.TopLevel = false;
                infoDetail.Dock = DockStyle.Fill;
                infoDetail.Visible = true;
                infoDetail.FormBorderStyle = FormBorderStyle.None;
                this.tabControlInformation.TabPages[5].Controls.Add(infoDetail);
            }
           
         
            //else if (tabControlInformation.SelectedIndex == 6)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(@"http://172.16.3.42/toshiba-info/top 10 Dealers .pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[6].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 7)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(@"http://172.16.3.42/toshiba-info/top 10 Dealers .pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[7].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 8)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Daftar Saluran.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[8].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 9)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Database Admin dan CS Cabang.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[9].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 10)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Deskripsi Channel - Genre 2015.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[10].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 11)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Distributor Jual Putus Dist Utama.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[11].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 12)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Email Agent.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[12].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 13)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Freeze Boot up Logo.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[13].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 14)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Info Tagihan.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[14].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 15)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\KPI SALES PRE PAID.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[15].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 16)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Layanan Pelanggan Topas TV.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[16].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 17)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Maitenance Fox Sport.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[17].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 18)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\No Telp Kacab.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[18].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 19)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Old Package.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[19].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 20)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Panduan Pembayaran TV Berlangganan melalui PPOB Chipsakti.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[20].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 21)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Panduan Pembelian Paket TV Voucher melalui PPOB Chipsakti.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[21].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 22)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Panduan Pendaftaran Agen PPOB Chipsakti.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[22].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 23)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Panduan Registrasi dan Aktivasi Decoder.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[23].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 24)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Panduan Transaksi Sistim Duosoft.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[24].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 25)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Penanganan Troubleshoot Prepaid.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[25].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 26)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Sine Film Indonesia.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[26].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 27)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Status Ilegal.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[27].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 28)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Topas TV Dist Center Revisi.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[28].Controls.Add(infoDetail);
            //}
            //else if (tabControlInformation.SelectedIndex == 29)
            //{
            //    View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"\Tutorial Penanganan Gangguan Topas TV.pdf");
            //    infoDetail.TopLevel = false;
            //    infoDetail.Dock = DockStyle.Fill;
            //    infoDetail.Visible = true;
            //    infoDetail.FormBorderStyle = FormBorderStyle.None;
            //    this.tabControlInformation.TabPages[29].Controls.Add(infoDetail);
            //}
          
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void Information_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("Test");
            View.InformationDetail infoDetail = new InformationDetail(AppDomain.CurrentDomain.BaseDirectory + @"Addres Branch Toshiba.pdf");
            infoDetail.TopLevel = false;
            infoDetail.Dock = DockStyle.Fill;
            infoDetail.Visible = true;
            infoDetail.FormBorderStyle = FormBorderStyle.None;
            this.tabControlInformation.TabPages[0].Controls.Add(infoDetail);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }
    }
}
