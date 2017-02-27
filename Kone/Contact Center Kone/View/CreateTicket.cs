using Contact_Center_Kone.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;
using Contact_Center_Kone.Entity;

namespace Contact_Center_Kone.View
{
    public partial class CreateTicket : Form
    { 
        TempTicket _tempTicket;

        public View.InboundCall inboundForm;
        public View.OutboundCall outboundForm;
        public View.Email mailForm;
        public View.Sms smsForm;
       
        string tempCustomerId, tempCustomerName, tempCustomerAddress, tempCity, tempPostalCode, tempCusPhone, tempCusMobilePhone;
        public CreateTicket(string customerName,string customerAddress,string city,string cusPhone,string cusMobilePhone)
        {
            InitializeComponent();
           
            tempCustomerName = customerName;
            tempCustomerAddress = customerAddress;
            tempCity = city;
            //tempPostalCode = postalCode;
            tempCusPhone = cusPhone;
            tempCusMobilePhone = cusMobilePhone;
        }

        public CreateTicket(TempTicket tempTicket)
        {
            InitializeComponent();

            _tempTicket = new TempTicket();
            _tempTicket = tempTicket;
        }

        private void CreateTicket_Load(object sender, EventArgs e)
        {
            //http:\\192.168.0.202\tickets\?action=create&user_id=10&password=39c9b671fd2958e5f53f000811228ed0&source_media_id=1&media_id=11&product_type_id=1&model_id=6&size_id=2&serial_no=PVF2132&purchase_date=20/11/2011&problem_date=20/08/2016&symptom_code_id=2
            //geckoWebBrowser1.Navigate(Global.web_create_ticket_inboundcall + Global.userAccount.id + "&&customer_id=" + tempCustomerId + "&&customer_name=" + tempCustomerName + "&&customer_address=" + tempCustomerAddress + "&&customer_city=" + tempCity + "&&customer_postal_code=" + tempPostalCode + "&&customer_phone=" + tempCusPhone + "&&customer_mobile_phone=" + tempCusMobilePhone);
            geckoWebBrowser1.Navigate(Global.web_create_ticket + "&user_id=" + _tempTicket.tempUserId + "&password=" + _tempTicket.tempPasswd
                + "&source_media_id=" + _tempTicket.tempSourceMediaId + "&media_id=" + _tempTicket.tempMediaId + "&product_type_id=" + _tempTicket.tempProductTypeId
                + "&model_id=" + _tempTicket.tempModelId + "&serial_no=" + _tempTicket.tempSerialNo + "&purchase_date=" + _tempTicket.tempPurchaseDate
                + "&problem_date=" + _tempTicket.tempPorblemDate + "&symptom_code_id=" + _tempTicket.tempSymthomId + "&size_id=" + _tempTicket.tempSizeId + "&warranty_status_id=" + _tempTicket.tempWarrantyStatusId + "&product_location_id=" + _tempTicket.tempProductLocationId); 
        }

        private void CreateTicket_FormClosing(object sender, FormClosingEventArgs e)
        {

            //MessageBox.Show(geckoWebBrowser1.Url.AbsoluteUri);
            var uri = new Uri(geckoWebBrowser1.Url.AbsoluteUri);

            NameValueCollection nvc = HttpUtility.ParseQueryString(geckoWebBrowser1.Url.AbsoluteUri);

            if (inboundForm != null)
            {
                inboundForm.listOfTicketToTag.Add(nvc["id"]);
                inboundForm.fromOpenTicket = false;
            }

            inboundForm.btnTicket.Visible =!( new Dao.CallDao().isThisCallInboundHasTicket(_tempTicket.tempMediaId));
            
            //MessageBox.Show(nvc["id"]);
        }
    }
}
