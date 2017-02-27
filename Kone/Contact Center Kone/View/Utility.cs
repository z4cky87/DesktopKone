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
    public partial class Utility : Form
    {
        bool vCategory=false;
        bool vUsers = false;
       

        public Utility()
        {
            InitializeComponent();
        }

        private void Utility_Load(object sender, EventArgs e)
        {
            View.CallerType inboundCategoryForm = new CallerType();
            inboundCategoryForm.TopLevel = false;
            inboundCategoryForm.Dock = DockStyle.Fill;
            inboundCategoryForm.Visible = true;
            inboundCategoryForm.FormBorderStyle = FormBorderStyle.None;
            this.tabControl1.TabPages[0].Controls.Add(inboundCategoryForm);                      
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 1 && !vUsers)
                {
                    vUsers = true;
                    View.User user = new User();
                    user.TopLevel = false;
                    user.Dock = DockStyle.Fill;
                    user.Visible = true;
                    user.FormBorderStyle = FormBorderStyle.None;
                    this.tabControl1.TabPages[1].Controls.Add(user);
                }
                else if (tabControl1.SelectedIndex == 0 && !vCategory)
                {
                    View.CallerType inboundCategoryForm = new CallerType();
                    inboundCategoryForm.TopLevel = false;
                    inboundCategoryForm.Dock = DockStyle.Fill;
                    inboundCategoryForm.Visible = true;
                    inboundCategoryForm.FormBorderStyle = FormBorderStyle.None;
                    this.tabControl1.TabPages[0].Controls.Add(inboundCategoryForm); 
                }
               
            }
            catch { }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabProduct_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void btnAddInboundCallerType_Click(object sender, EventArgs e)
        {

        }
    }
}
