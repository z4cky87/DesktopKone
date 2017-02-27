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
    public partial class InformationDetail : Form
    {
        string url = "";
        public InformationDetail(string urlPdf)
        {
            InitializeComponent();
            url = urlPdf;
        }

        private void geckoWebBrowser1_Click(object sender, EventArgs e)
        {

        }

        private void InformationDetail_Load(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate(@url);

        }
    }
}
