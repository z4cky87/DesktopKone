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
    public partial class InfoDetail : Form
    {
        public InfoDetail()
        {
            InitializeComponent();

        }

        private void InfoDetail_Load(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("www.kone.com");
        }
    }
}
