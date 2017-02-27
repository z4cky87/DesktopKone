using Contact_Center_Kone.Utility;
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
    public partial class TicketManagment : Form
    {
        private bool fillFormReminder = false;
        public TicketManagment()
        {
            InitializeComponent(); 
        }

        private void TicketManagment_Load(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate(Global.web_ticket_managment + "&user_id=" + Global.userAccount.id + "&password=" + Global.hashPassword); 
        }


        private void LoadFromReminder()
        { 
            
        }

        private void geckoWebBrowser1_Click(object sender, EventArgs e)
        {

        }

        private void TicketManagment_Activated(object sender, EventArgs e)
        {
           
        }
    }
}
