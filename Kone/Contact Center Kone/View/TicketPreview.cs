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
    public partial class TicketPreview : Form
    {
        List<string> ticket = new List<string>();
        public TicketPreview(List<string> paramTicket)
        {
            InitializeComponent();
            ticket = paramTicket;
        }

        private void TicketPreview_Load(object sender, EventArgs e)
        {
            this.txtTicketNo.Text = ticket[0];
            this.txtStatusTicket.Text = ticket[1];
            this.txtTicketType.Text = ticket[2];
            this.txtUsername.Text = ticket[3];
            this.txtOpenAt.Text = ticket[4];
            this.txtOpenBy.Text = ticket[5];
            this.txtProcessAt.Text = ticket[6];
            this.txtProcessedBy.Text = ticket[7];
            this.txtAssignedAt.Text = ticket[8];
            this.txtAssignedBy.Text = ticket[9];
            this.txtAcceptedAt.Text = ticket[10];
            this.txtAcceptedBy.Text = ticket[11];
            this.txtRejectAt.Text = ticket[12];
            this.txtRejectBy.Text = ticket[13];
            this.txtDoneAt.Text = ticket[14];
            this.txtDoneBy.Text = ticket[15];
            this.txtClosedAt.Text = ticket[16];
            this.txtClosedBy.Text = ticket[17];
            this.txtCanceledAt.Text = ticket[18];
            this.txtCanceledBy.Text = ticket[19];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
