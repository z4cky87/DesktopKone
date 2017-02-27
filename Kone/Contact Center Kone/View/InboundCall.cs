﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.View
{
    public partial class InboundCall : Form
    {
        public View.Main mainForm;
        public View.CallCenter callCenterForm;

        Dao.InboundTypeDao inboundTypeDao = new Dao.InboundTypeDao();
        Dao.InboundTypeDetailDao inboundTypeDetailDao = new Dao.InboundTypeDetailDao();
        Dao.InboundCallerTypeDao inboundCallerTypeDao = new Dao.InboundCallerTypeDao();
        Dao.CallMonitorsDao callmonitordao = new Dao.CallMonitorsDao();//0702

        List<City> myCities = new List<City>();
        Dao.CallDao callDao = new Dao.CallDao();
        Dao.TicketDao ticketDao = new Dao.TicketDao();
        Dao.AreaDao areaDao = new Dao.AreaDao();

        Entity.Call call = new Call();

        public string modelId = null;

        internal bool fromRinging = false;
        internal bool fromOpenTicket = false;
        internal string tempCustomerId;
        internal string tempVehicleId;
        internal bool valueButtonTicket = false;

        bool modeEdit = false;
        string timeCall = "";    
        bool isHangup = false;
        bool isHiden = false;
        string voiceFile = "";
        string lastCallId = "";
        public List<string> listOfTicketToTag = new List<string>();

        #region Grid Design
      
        void ChangeColumnHeaderCall()
        {

            dtgrid_CallDetail.Columns[0].Visible = false;

            dtgrid_CallDetail.Columns[1].Width = 200;
            dtgrid_CallDetail.Columns[1].HeaderText = "Call Date";

            dtgrid_CallDetail.Columns[2].Width = 200;
            dtgrid_CallDetail.Columns[2].HeaderText = "Ticket No";
            dtgrid_CallDetail.Columns[2].DefaultCellStyle.ForeColor = Color.Red;


            dtgrid_CallDetail.Columns[3].Width = 200;
            dtgrid_CallDetail.Columns[3].HeaderText = "Caller Name";


            dtgrid_CallDetail.Columns[4].Width = 200;
            dtgrid_CallDetail.Columns[4].HeaderText = "Username";

            dtgrid_CallDetail.Columns[5].Width = 200;
            dtgrid_CallDetail.Columns[5].HeaderText = "Direction";

            dtgrid_CallDetail.Columns[6].Width = 200;
            dtgrid_CallDetail.Columns[6].HeaderText = "Call Status";

            dtgrid_CallDetail.Columns[7].Width = 200;
            dtgrid_CallDetail.Columns[7].HeaderText = "Caller Type";

            dtgrid_CallDetail.Columns[8].Width = 200;
            dtgrid_CallDetail.Columns[8].HeaderText = "Caller Type Detail";

            dtgrid_CallDetail.Columns[9].Width = 200;
            dtgrid_CallDetail.Columns[9].HeaderText = "Outbond Status Detail";

            dtgrid_CallDetail.Columns[10].Width = 200;
            dtgrid_CallDetail.Columns[10].HeaderText = "Shift";

            dtgrid_CallDetail.Columns[11].Width = 200;
            dtgrid_CallDetail.Columns[11].HeaderText = "Transfer Reason";

            dtgrid_CallDetail.Columns[12].Width = 200;
            dtgrid_CallDetail.Columns[12].HeaderText = "Test Call";

            dtgrid_CallDetail.Columns[13].Width = 200;
            dtgrid_CallDetail.Columns[13].HeaderText = "Blank Call";


            dtgrid_CallDetail.Columns[14].Width = 200;
            dtgrid_CallDetail.Columns[14].HeaderText = "Wrong Number";

            dtgrid_CallDetail.Columns[15].Width = 200;
            dtgrid_CallDetail.Columns[15].HeaderText = "Prank Call";

            dtgrid_CallDetail.Columns[16].Width = 200;
            dtgrid_CallDetail.Columns[16].HeaderText = "Inquiry";

            dtgrid_CallDetail.Columns[17].Width = 200;
            dtgrid_CallDetail.Columns[17].HeaderText = "Complaint";

            dtgrid_CallDetail.Columns[18].Width = 200;
            dtgrid_CallDetail.Columns[18].HeaderText = "Request";

            dtgrid_CallDetail.Columns[19].Width = 200;
            dtgrid_CallDetail.Columns[19].HeaderText = "Prospect Customer";

            dtgrid_CallDetail.Columns[20].Width = 200;
            dtgrid_CallDetail.Columns[20].HeaderText = "Others";

            dtgrid_CallDetail.Columns[21].Width = 200;
            dtgrid_CallDetail.Columns[21].HeaderText = "Host Address";

            dtgrid_CallDetail.Columns[22].Width = 200;
            dtgrid_CallDetail.Columns[22].HeaderText = "Hostname";

            dtgrid_CallDetail.Columns[23].Width = 200;
            dtgrid_CallDetail.Columns[23].HeaderText = "Extension";

            dtgrid_CallDetail.Columns[24].Width = 200;
            dtgrid_CallDetail.Columns[24].HeaderText = "Duration";

            dtgrid_CallDetail.Columns[25].Width = 200;
            dtgrid_CallDetail.Columns[25].HeaderText = "Abandon";

            dtgrid_CallDetail.Columns[26].Width = 200;
            dtgrid_CallDetail.Columns[26].HeaderText = "Speed Of Answer";

            dtgrid_CallDetail.Columns[27].Width = 200;
            dtgrid_CallDetail.Columns[27].HeaderText = "After Call Work";

            dtgrid_CallDetail.Columns[28].Width = 200;
            dtgrid_CallDetail.Columns[28].HeaderText = "Caller Number";

            dtgrid_CallDetail.Columns[29].Width = 200;
            dtgrid_CallDetail.Columns[29].HeaderText = "Note";

            dtgrid_CallDetail.Columns[30].Width = 200;
            dtgrid_CallDetail.Columns[30].HeaderText = "Voice File";

            dtgrid_CallDetail.Columns[31].Visible = false;
            dtgrid_CallDetail.Columns[32].Visible = false;
            dtgrid_CallDetail.Columns[33].Visible = false;
            dtgrid_CallDetail.Columns[34].Visible = false;
            dtgrid_CallDetail.Columns[35].Visible = false;
            dtgrid_CallDetail.Columns[36].Visible = false;
            dtgrid_CallDetail.Columns[37].Visible = false;
            dtgrid_CallDetail.Columns[38].Visible = false;
            dtgrid_CallDetail.Columns[39].Visible = false;
            dtgrid_CallDetail.Columns[40].Visible = false;


            dtgrid_CallDetail.Columns[41].Visible = false;
            dtgrid_CallDetail.Columns[42].Visible = false;
            dtgrid_CallDetail.Columns[43].Visible = false;
            dtgrid_CallDetail.Columns[44].Visible = false;
            dtgrid_CallDetail.Columns[45].Visible = false;
            dtgrid_CallDetail.Columns[46].Visible = false;
            dtgrid_CallDetail.Columns[47].Visible = false;
            dtgrid_CallDetail.Columns[48].Visible = false;
            dtgrid_CallDetail.Columns[49].Visible = false;
            dtgrid_CallDetail.Columns[50].Visible = false;
            dtgrid_CallDetail.Columns[51].Visible = false;
            dtgrid_CallDetail.Columns[52].Visible = false;
            dtgrid_CallDetail.Columns[53].Visible = false;
            dtgrid_CallDetail.Columns[54].Visible = false;
            dtgrid_CallDetail.Columns[55].Visible = false;
            dtgrid_CallDetail.Columns[56].Visible = false;

            dtgrid_CallDetail.Columns[57].Visible = false;  
        }
        //void ChangeColumnHeaderTicket()
        //{

        //    this.dtgridTicket.Columns[0].Visible = false;

        //    dtgridTicket.Columns[1].Width = 200;
        //    dtgridTicket.Columns[1].HeaderText = "Ticket No";

        //    dtgridTicket.Columns[2].Width = 200;
        //    dtgridTicket.Columns[2].HeaderText = "Department";

        //    dtgridTicket.Columns[3].Width = 200;
        //    dtgridTicket.Columns[3].HeaderText = "Status";

        //    dtgridTicket.Columns[4].Width = 200;
        //    dtgridTicket.Columns[4].HeaderText = "Open Date";

        //    dtgridTicket.Columns[5].Width = 200;
        //    dtgridTicket.Columns[5].HeaderText = "Open By";

        //    dtgridTicket.Columns[6].Width = 200;
        //    dtgridTicket.Columns[6].HeaderText = "Process Date";

        //    dtgridTicket.Columns[7].Width = 200;
        //    dtgridTicket.Columns[7].HeaderText = "Process By";

        //    dtgridTicket.Columns[8].Width = 200;
        //    dtgridTicket.Columns[8].HeaderText = "Submit Date";

        //    dtgridTicket.Columns[9].Width = 200;
        //    dtgridTicket.Columns[9].HeaderText = "Submit By";

        //    dtgridTicket.Columns[10].Width = 200;
        //    dtgridTicket.Columns[10].HeaderText = "Done Date";

        //    dtgridTicket.Columns[11].Width = 200;
        //    dtgridTicket.Columns[11].HeaderText = "Done By";

        //    dtgridTicket.Columns[12].Width = 200;
        //    dtgridTicket.Columns[12].HeaderText = "Close Date";

        //    dtgridTicket.Columns[13].Width = 200;
        //    dtgridTicket.Columns[13].HeaderText = "Close By";

        //}
        //void ChangeColumnHeaderTicketCallerNumber()
        //{

        //    this.dtGridTicketByCallerNo.Columns[0].Visible = false;

        //    dtGridTicketByCallerNo.Columns[1].Width = 200;
        //    dtGridTicketByCallerNo.Columns[1].HeaderText = "Ticket No";

        //    dtGridTicketByCallerNo.Columns[2].Width = 200;
        //    dtGridTicketByCallerNo.Columns[2].HeaderText = "Department";

        //    dtGridTicketByCallerNo.Columns[3].Width = 200;
        //    dtGridTicketByCallerNo.Columns[3].HeaderText = "Status";

        //    dtGridTicketByCallerNo.Columns[4].Width = 200;
        //    dtGridTicketByCallerNo.Columns[4].HeaderText = "Open Date";

        //    dtGridTicketByCallerNo.Columns[5].Width = 200;
        //    dtGridTicketByCallerNo.Columns[5].HeaderText = "Open By";

        //    dtGridTicketByCallerNo.Columns[6].Width = 200;
        //    dtGridTicketByCallerNo.Columns[6].HeaderText = "Process Date";

        //    dtGridTicketByCallerNo.Columns[7].Width = 200;
        //    dtGridTicketByCallerNo.Columns[7].HeaderText = "Process By";

        //    dtGridTicketByCallerNo.Columns[8].Width = 200;
        //    dtGridTicketByCallerNo.Columns[8].HeaderText = "Submit Date";

        //    dtGridTicketByCallerNo.Columns[9].Width = 200;
        //    dtGridTicketByCallerNo.Columns[9].HeaderText = "Submit By";

        //    dtGridTicketByCallerNo.Columns[10].Width = 200;
        //    dtGridTicketByCallerNo.Columns[10].HeaderText = "Done Date";

        //    dtGridTicketByCallerNo.Columns[11].Width = 200;
        //    dtGridTicketByCallerNo.Columns[11].HeaderText = "Done By";

        //    dtGridTicketByCallerNo.Columns[12].Width = 200;
        //    dtGridTicketByCallerNo.Columns[12].HeaderText = "Close Date";

        //    dtGridTicketByCallerNo.Columns[13].Width = 200;
        //    dtGridTicketByCallerNo.Columns[13].HeaderText = "Close By";

           

        //}

   
        #endregion
        #region LoadData
        //void LoadArea()
        //{
        //    try
        //    {
        //        this.cmbArea.DataSource = areaDao.GetAllArea();
        //        this.cmbArea.DisplayMember = "name";
        //        this.cmbArea.ValueMember = "id";
        //    }
        //    catch { }
        //}

        void LoadCallerTypeDetail()
        {
            try
            {
                this.cmbCallerTypeDetail.DataSource = null;
                this.cmbCallerTypeDetail.DataSource = new Dao.CallerTypeDetailDao().GetAllByCallerType(this.cmbCallerType.SelectedValue.ToString());
                this.cmbCallerTypeDetail.ValueMember = "id";
                this.cmbCallerTypeDetail.DisplayMember = "name";
            }
            catch { }
        }
     
        void LoadCallerType()
        {
            try
            {
                this.cmbCallerType.DataSource = new Dao.CallerTypeDao().GetListCallerType("1");
                this.cmbCallerType.DisplayMember = "type";
                this.cmbCallerType.ValueMember = "id";
            }
            catch { }
        }
        //void LoadTvSize()
        //{
        //    try
        //    {
        //        this.cmbSize.DataSource = new Dao.TvSizeDao().GetAllTvSize();
        //        this.cmbSize.DisplayMember = "name";
        //        this.cmbSize.ValueMember = "id";
        //    }
        //    catch { }
        //}
        //void LoadSymptomCode()
        //{
        //    try
        //    {
        //        this.cmbSymptonCode.DataSource = new Dao.SymptomDao().GetAllSymptomCode();
        //        this.cmbSymptonCode.DisplayMember = "code";
        //        this.cmbSymptonCode.ValueMember = "id";
        //    }
        //    catch { }
        //}
        //void LoadWarrantyStatus()
        //{
        //    try
        //    {
        //        this.cmbWarrantyStatus.DataSource = new Dao.WarrantyStatusDao().GetAllWarrantyStatus();
        //        this.cmbWarrantyStatus.DisplayMember = "name";
        //        this.cmbWarrantyStatus.ValueMember = "id";
        //    }
        //    catch { }
        //}
        //void LoadProductLocation()
        //{
        //    try
        //    {
        //        this.cmbProductLocation.DataSource = new Dao.ProductLocationDao().GetAllProductLocation();
        //        this.cmbProductLocation.DisplayMember = "name";
        //        this.cmbProductLocation.ValueMember = "id";
        //    }
        //    catch { }
        //}
        void LoadCities()
        {
            try
            {
                myCities = new Dao.CityDao().GetAllCities();
                this.cmbCity.DataSource = myCities;
                this.cmbCity.DisplayMember = "name";
                this.cmbCity.ValueMember = "id";
                cmbCity.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbCity.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch { }
        }
        void LoadDataCallHistory()
        {

            this.dtgrid_CallDetail.DataSource = callDao.GetAll(this.txtCallerNumber.Text,this.txtHandphone.Text,this.txtTelepone.Text);
            ChangeColumnHeaderCall();
        }
       
        //void LoadDataTicketByCallId()
        //{

        //    this.dtgridTicket.DataSource = ticketDao.GetByCallId(call.id.ToString());
        //    ChangeColumnHeaderTicket();
        //}
        //void LoadDataTicketByCallNo()
        //{

        //    this.dtGridTicketByCallerNo.DataSource = ticketDao.GetByCallNumber(this.txtCallerNumber.Text,this.txtTelepone.Text,this.txtHandphone.Text);
        //    ChangeColumnHeaderTicketCallerNumber();
        //}

        
        #endregion
        #region DML
        public void SaveInboundDetailTag(string callId)
        {
            if (this.chkComplain.Checked) { new Dao.CallTagDao().Insert(callId, "1"); }
            if (this.chkInquiry.Checked) { new Dao.CallTagDao().Insert(callId, "2"); }
            if (this.chkBlankCall.Checked) { new Dao.CallTagDao().Insert(callId, "5"); }
            //if (this.chkProspectCustomer.Checked) { new Dao.CallTagDao().Insert(callId, "3"); }
            if (this.chkRequest.Checked) { new Dao.CallTagDao().Insert(callId, "4"); }
            if (this.chkWrongNo.Checked) { new Dao.CallTagDao().Insert(callId, "6"); }
            if (this.chkTestCall.Checked) { new Dao.CallTagDao().Insert(callId, "7"); }
            if (this.chkOthers.Checked) { new Dao.CallTagDao().Insert(callId, "8"); }
            if (this.chkPrankCall.Checked) { new Dao.CallTagDao().Insert(callId, "9"); }
      
        }

        public void SaveTicketTag(string callId)
        {
            //if (callDao.isThisCallInboundHasTicket(callId))
            //{ return; }

            var insertTags = new Dao.TagTicketDao();

            for (int i = 0; i < listOfTicketToTag.Count; i++)
            {
                insertTags.Insert(new TagTicket() {

                    media_id = Convert.ToInt32(callId),
                    source_media_id=4,
                    ticket_id = Convert.ToInt32(listOfTicketToTag[i])
                });
            }
            listOfTicketToTag.Clear();
        }
        #endregion
        public InboundCall(bool editMode,Entity.Call call=null)
        {
            InitializeComponent();
            modeEdit = editMode;
            this.call = call;
        }
        public InboundCall()
        {
            InitializeComponent();
            
        }

        private void InboundCall_Load(object sender, EventArgs e)
        {
            // this.tabControl2.TabPages.RemoveAt(3);

                if (Global.unique_id == null)
                {
                   Global.unique_id=callDao.CheckCurrUniqeID(Global.userAccount.id);
                }
                
                if (!modeEdit)
                {
                    if (!isHiden)
                    {
                        //LoadArea();
                        LoadCallerType();
                        LoadCallerTypeDetail();
                        //LoadTvSize();
                        //LoadSymptomCode();
                        //LoadProductLocation();
                        //LoadWarrantyStatus();
                        LoadCities();
                        this.tableLayoutPanel3.Visible = false;
                       
                        timeCall = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        this.txtCallerNumber.Text = mainForm.myTelepon.CallerNumber;
                        //this.txtName.Text = customer.name;
                        //LoadDataTicketByCallNo();
                        //LoadDataTicketByCallId();
                        LoadDataCallHistory();
                        Global.DisabledLabel(this.tableLayoutPanel3);
                        this.lblTimerCall.Visible = true;
                    // this.txtNote.Size = new Size(390, 129);
                        this.btnSaveDataCall.Visible = false;
                        callmonitordao.UpdateStatusCallMonitors(Global.unique_id);//0702
                        var insertCall = callDao.Insert(new Entity.Call()
                         {
                             callDate = mainForm.myTelepon.dateTimeCall,
                             //callerName = this.txtName.Text,
                             callerTypeDetail = new Entity.CallerTypeDetail() { id =null},
                             user = new Entity.User() { id = Global.userAccount.id },
                             direction = new Direction() { id = 1 },
                             inboundStatus = new InboundStatus() { id = 1 },                            
                             outbondStatusDetailName = null,
                             shift = new Shift() { id = Global.shiftId },                            
                             hostAddress = Global.LocalIPAddress(),
                             hostName = Global.LocalCompName(),
                             extension = Global.userAccount.inbound_ext,                                                       
                             delay = mainForm.myTelepon.durationDelay,
                             busy = "00:00:00",

                             unique_id = Global.unique_id,//15-11
                                                         //duration = mainForm.myTelepon.GetDurasi(mainForm.myTelepon.timerStampCall),
                            callerNumber = mainForm.myTelepon.CallerNumber,
                         }, out lastCallId);
                    }
                }
                else
                {
                    
                    if (Global.userAccount.username != callCenterForm.dtgrid_CallDetail.SelectedCells[4].Value.ToString() && Global.userAccount.level != "6" && Global.userAccount.level != "2" && Global.userAccount.level != "3" && Global.userAccount.level != "5")
                    {
                        btnSaveDataCall.Enabled = false;
                    }

                    //if(callDao.isThisCallInboundHasTicket(call.id.ToString()))
                    //{ this.btnTicket.Enabled = false; }
                    //LoadArea();
                    LoadCallerType();
                    LoadCallerTypeDetail();
                    //LoadTvSize();
                    //LoadSymptomCode();
                    //LoadProductLocation();
                    //LoadWarrantyStatus();
                    LoadCities();
                    //this.cmbBrand.SelectedIndex = 0;

                    this.btnHide.Visible = false;
                    Global.EnabledLabel(this.panel2);
                    this.lblTimerCall.Visible = false;
                    this.timerDurasiCall.Enabled = false;
                    this.timerDurasiBusy.Enabled = false;
                    this.btnMute.Visible = false;
                    this.btnHangup.Visible = false;
                    this.btnHold.Visible = false;
                    this.btn_transfer.Visible = false;
                   // this.btnTicket.Visible =!callDao.isThisCallInboundHasTicket(call.id.ToString());
                     

                    this.lblCallDate.Text = call.callDate;
                    this.lblCallStatus.Text = call.inboundStatusName;
                    this.lblDelay.Text = call.delay;
                    this.lblDuration.Text = call.duration;
                    this.lblAbandon.Text = call.abandon;
                    this.lblReceivedBy.Text = call.username;
                    this.lblAcw.Text = call.busy;

                   // this.cmbArea.SelectedValue = call.areaName;
                    this.txtName.Text = call.callerName;
                    this.txtCallerNumber.Text = call.callerNumber;

                    //if (String.IsNullOrEmpty(call.areaName)) { this.cmbArea.SelectedIndex = -1; }
                    //else { this.cmbArea.Text = call.areaName; }

                    if (String.IsNullOrEmpty(call.CallerTypeName)) { this.cmbCallerType.SelectedIndex = 0; }
                    else { this.cmbCallerType.Text = call.CallerTypeName; }

                    if (String.IsNullOrEmpty(call.callerTypeDetailName)) { this.cmbCallerTypeDetail.SelectedIndex = 0; }
                    else { this.cmbCallerTypeDetail.Text = call.callerTypeDetailName; }

                    if (String.IsNullOrEmpty(call.city)) { this.cmbCity.SelectedIndex = 0; }
                    else { this.cmbCity.SelectedValue = call.city; }

                    //if (string.IsNullOrEmpty(call.city))
                    //{ this.cmbCity.SelectedIndex = -1; }
                    //else { this.cmbCity.SelectedValue = call.city; }
                    
                    this.chkTestCall.Checked = call.isTestCall == "Yes" ? true : false;
                    this.chkBlankCall.Checked = call.isBlankCall == "Yes" ? true : false;
                    this.chkWrongNo.Checked = call.isWrongNumber == "Yes" ? true : false;
                    this.chkPrankCall.Checked = call.isPrankCall == "Yes" ? true : false;
                    this.chkInquiry.Checked = call.isInquiry == "Yes" ? true : false;
                    this.chkComplain.Checked = call.isComplaint == "Yes" ? true : false;
                    this.chkRequest.Checked = call.isRequest == "Yes" ? true : false;                 
                    //this.chkProspectCustomer.Checked = call.isProspectCustomer == "Yes" ? true : false;
                    this.chkOthers.Checked = call.isOthers == "Yes" ? true : false;

                    CheckBox obj = new CheckBox();

                    if (chkTestCall.Checked) { obj = chkTestCall; }
                    else if (chkBlankCall.Checked) { obj = chkBlankCall; }
                    else if (chkWrongNo.Checked) { obj = chkWrongNo; }
                    else if (chkPrankCall.Checked) { obj = chkPrankCall; }
                    checklistEnabled(obj);

                    this.txtAlamat.Text = call.address;
                    this.txt_bulding.Text = call.building;
                    
                   
                    this.txtTelepone.Text = call.telephone;           
                    this.txtHandphone.Text = call.handphone;
                    this.txtNote.Text = call.note;
                    this.txtEmail.Text = call.email;
                   // this.txtNote.Size = new Size(390, 129);
                    this.modelId = call.modelId;

                    //if(!string.IsNullOrEmpty(modelId))
                    //{
                    //    this.cmbWarrantyStatus.Enabled = true;
                    //    this.cmbProductLocation.Enabled = true;
                    //    this.cmbSymptonCode.Enabled = true;
                    //    this.cmbSize.Enabled = true;
                    //    this.dtProblemDate.Enabled = true;
                    //    this.dtPurchaseDate.Enabled = true;
                    //    this.txtSerialNo.Enabled = true;

                    //    var modelName=new Dao.ModelDao().GetModel(call.modelId);
                    //    this.txtModel.Text = modelName.ProductType + " - " + modelName.Name;

                    //    this.btnDeleteModel.Visible = true;
                    //    this.txtSerialNo.Text = call.serialNo;
                    //    this.cmbSymptonCode.SelectedValue = call.symptomCodeId;
                    //    this.cmbProductLocation.SelectedValue = call.productLocationId;
                    //    this.cmbWarrantyStatus.SelectedValue = call.warrantyStatusId;
                    //    this.cmbSize.SelectedValue = call.tvSizeId;
                    //    this.dtProblemDate.Value = Convert.ToDateTime(call.problemDate);
                    //    this.dtPurchaseDate.Value = Convert.ToDateTime(call.purchaseDate);

                    //    if (String.IsNullOrEmpty(call.tvSizeId)) { this.cmbSize.SelectedIndex = 0; }
                    //    else { this.cmbSize.Text = call.tvSizeId; }

                    //    if (String.IsNullOrEmpty(call.symptomCodeId)) { this.cmbSymptonCode.SelectedIndex = 0; }
                    //    else { this.cmbSymptonCode.Text = call.symptomCodeId; }

                    //    if (String.IsNullOrEmpty(call.productLocationId)) { this.cmbProductLocation.SelectedIndex = 0; }
                    //    else { this.cmbProductLocation.Text = call.productLocationId; }

                    //    if (String.IsNullOrEmpty(call.warrantyStatusId)) { this.cmbWarrantyStatus.SelectedIndex = 0; }
                    //    else { this.cmbWarrantyStatus.Text = call.warrantyStatusId; }

                    //}
                    //else
                    //{
                    //    this.cmbProductLocation.Enabled = false;
                    //    this.cmbWarrantyStatus.Enabled = false;
                    //    this.cmbSymptonCode.Enabled = false;
                    //    this.cmbSize.Enabled = false;
                    //    this.dtProblemDate.Enabled = false;
                    //    this.dtPurchaseDate.Enabled = false;
                    //    this.txtSerialNo.Enabled = false;

                    //    this.txtSerialNo.Clear();
                    //    this.cmbSize.SelectedIndex = 0;
                    //    this.cmbSymptonCode.SelectedIndex = 0;

                    //    this.dtProblemDate.Value = DateTime.Now;
                    //    this.dtPurchaseDate.Value = DateTime.Now;
                    //}
                 

                    LoadDataCallHistory();
                    
                    //LoadDataTicketByCallNo();
                    //LoadDataTicketByCallId();

                  
                    //LoadCustomerData();
                }
            
            
        }

        private void cmbCallCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCallerTypeDetail();
        }

        private void InboundCall_Resize(object sender, EventArgs e)
        {
            this.lblTimerCall.Left = (this.panel1.Width - lblTimerCall.Width) / 2;
            lblTimerCall.Top = (this.panel1.Height - lblTimerCall.Height) / 2;
        }

        private void timerDurasi_Tick(object sender, EventArgs e)
        {
            var timenow = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            //this.lblTimerCall.Text = "Call Duration : " + durasi.ToString();

            if (Global.callState == Global.CallState.INCALL)
            {
                
                var durasi = timenow.Subtract(Convert.ToDateTime(timeCall));
                this.lblTimerCall.Text = "Call Duration : " + durasi.ToString();
                
        }
            else
                if (Global.callState == Global.CallState.BUSY)
            {
                this.lblTimerCall.Text = "After call work : " + timenow.Subtract(Convert.ToDateTime(mainForm.myTelepon.timerStampBusy)).ToString();
            }

           
        }     
        private void chkInquiry_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chkComplain_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void chkOthers_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (this.btnMute.Text == "Mute")
            {
                this.btnMute.Text = "Un Mute";
            mainForm.myTelepon.Mute();
        }
            else
            {
                this.btnMute.Text = "Mute";
                mainForm.myTelepon.UnMute(); 
            }
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            if (this.btnHold.Text == "Hold")
            {
                this.btnHold.Text = "Un Hold";
            mainForm.myTelepon.Hold();
        }
            else
            {
                this.btnHold.Text = "Hold";
                mainForm.myTelepon.UnHold(); 
            }
        }

        private void btnHangup_Click(object sender, EventArgs e)
        {
          
            if (MessageBox.Show("Ready to receive call and save data call ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.chkBlankCall.Checked == false && this.chkComplain.Checked == false && this.chkInquiry.Checked == false && this.chkOthers.Checked == false && this.chkRequest.Checked == false && this.chkTestCall.Checked == false 
                    && this.chkWrongNo.Checked == false && this.chkPrankCall.Checked == false && this.chkProspectCustomer.Checked == false)
                { 
                    MessageBox.Show("Please select Inbound Type.");
                    return;
                }
               
                voiceFile = "CallCenter" + System.DateTime.Now.ToString("yyyy-MM-dd") + "IN" + Global.userAccount.username + System.DateTime.Now.ToString("hh.mm.ss") + this.txtName.Text + ".wav";
                mainForm.myTelepon.Hangup(voiceFile);

                var updateCall = callDao.Update(new Entity.Call()
                 {
                    // callDate = mainForm.myTelepon.dateTimeCall,
                     id=Convert.ToInt32(lastCallId),
                     callerName = this.txtName.Text,

                    // user = new Entity.User() { id = Global.userAccount.id },
                     //direction = new Direction() { id = 1 },
                     //inboundStatus = new InboundStatus() { id = 1 },
                    // area=new Area(){id=this.cmbArea.SelectedValue.ToString()},
                     inboundCallerType = new Entity.CallerType() { id= this.cmbCallerType.SelectedIndex == 0 ? null : this.cmbCallerType.SelectedValue.ToString() },
                     callerTypeDetail = new Entity.CallerTypeDetail() { id = this.cmbCallerTypeDetail.SelectedIndex==0 ? null : this.cmbCallerTypeDetail.SelectedValue.ToString() },
                    // outbondStatusDetailName = null,
                    // shift = new Shift() { id = Global.shiftId },

                     isTestCall = this.chkTestCall.Checked ? "2" : "1",
                     isBlankCall = this.chkBlankCall.Checked ? "2" : "1",
                     isPrankCall = this.chkPrankCall.Checked ? "2" : "1",
                     isWrongNumber = this.chkWrongNo.Checked ? "2" : "1",
                     isComplaint = this.chkComplain.Checked ? "2" : "1",
                     isInquiry = this.chkInquiry.Checked ? "2" : "1",
                     isRequest = this.chkRequest.Checked ? "2" : "1",
                     isProspectCustomer = this.chkProspectCustomer.Checked ? "2" : "1",
                     isOthers = this.chkOthers.Checked ? "2" : "1",


                     city = this.cmbCity.SelectedIndex == 0 ? null : this.cmbCity.SelectedValue.ToString(),
                   //  zipCode = this.txtKodePos.Text,
                     email=this.txtEmail.Text,
                     address = this.txtAlamat.Text,
                     building = this.txt_bulding.Text,
                     telephone = this.txtTelepone.Text,
                     handphone = this.txtHandphone.Text,

                     modelId = string.IsNullOrEmpty(modelId) ? null : this.modelId,

                     //tvSizeId = this.cmbSize.SelectedIndex == 0 ? null : this.cmbSize.SelectedValue.ToString(),
                     //serialNo = this.txtSerialNo.Text,
                     //purchaseDate = string.IsNullOrEmpty(modelId) ? null : this.dtPurchaseDate.Value.ToString("yyyy-MM-dd"),
                     //problemDate = string.IsNullOrEmpty(modelId) ? null : this.dtProblemDate.Value.ToString("yyyy-MM-dd"),
                     //symptomCodeId = this.cmbSymptonCode.SelectedIndex == 0 ? null : this.cmbSymptonCode.SelectedValue.ToString(),
                     //warrantyStatusId = this.cmbWarrantyStatus.SelectedIndex == 0 ? null : this.cmbWarrantyStatus.SelectedValue.ToString(),
                     //productLocationId = this.cmbProductLocation.SelectedIndex == 0 ? null : this.cmbProductLocation.SelectedValue.ToString(),

                    // hostAddress = Global.LocalIPAddress(),
                    // hostName = Global.LocalCompName(),
                    // extension = Global.userAccount.inbound_ext,
                     voiceFile = this.voiceFile,
                     note = this.txtNote.Text,
                     //delay = mainForm.myTelepon.durationDelay,
                     duration = mainForm.myTelepon.GetDurasi(mainForm.myTelepon.timerStampCall),
                    // callerNumber = mainForm.myTelepon.CallerNumber,


                 });
                callDao.UpdateCurrUniqeID(Global.userAccount.id);//15-11
                if (updateCall)
               {
                   var deleteTag = new Dao.CallTagDao().Delete(lastCallId);
                   SaveTicketTag(lastCallId);
                   SaveInboundDetailTag(lastCallId);    
                   MessageBox.Show("Saved success.");
                   var updateReadyUser=new Dao.UserDao().ChangeActivityUser(Global.userAccount.id, "2");
                   mainForm.myTelepon.RegisterToPabx(Global.userAccount.pbx_inbound, Global.userAccount.inbound_ext, Global.userAccount.inbound_ext_pwd);
                   mainForm.inboundCallForm = null;
                   mainForm.btn_main_logout.Enabled = true;
                   mainForm.TableLayoutPanel19.Enabled = true;
                   Global.callState = Global.CallState.READY;
                   Dispose();
                }
               else
               {
                   MessageBox.Show("Saved data unsuccessfull.");
               }
            }
            else
            {
                callDao.UpdateCurrUniqeID(Global.userAccount.id);//15-11
                voiceFile = "CallCenter" + System.DateTime.Now.ToString("yyyy-MM-dd") + "IN" + Global.userAccount.username + System.DateTime.Now.ToString("hh.mm.ss") + this.txtName.Text + ".wav";
                this.btnHangup.Visible = false; this.btnMute.Visible = false; this.btnHold.Visible = false;
                mainForm.myTelepon.Hangup(voiceFile);
                isHangup = true;
                this.btnSaveDataCall.Visible = true;
                Global.callState = Global.CallState.BUSY;

                var userDao=new Dao.UserDao().ChangeActivityUser(Global.userAccount.id, "5");
                mainForm.timerBusy.Enabled = true;
                call.duration = mainForm.myTelepon.GetDurasi(mainForm.myTelepon.timerStampCall);
                mainForm.myTelepon.timerStampBusy = Convert.ToDateTime(System.DateTime.Now).ToString("dd/MM/yyyy HH:mm:ss");

                
                //callDao.UpdateDuration(new Entity.Call()
                //{
                //    id = Convert.ToInt32(lastCallId),
                //    duration = call.duration 
                //});

            }
            
        }

        private void btnSaveDataCall_Click(object sender, EventArgs e)
        {
            try
            {
               // var lastCallId = "";

                if (fromRinging)
                {
                    if (this.chkBlankCall.Checked == false && this.chkComplain.Checked == false && this.chkInquiry.Checked == false && this.chkOthers.Checked == false && this.chkRequest.Checked == false 
                        && this.chkTestCall.Checked == false && this.chkWrongNo.Checked == false && this.chkPrankCall.Checked == false)
                    { MessageBox.Show("Please select Inbound Type."); return; }
                       // if (!isHangup) { MessageBox.Show("Hang up call first"); }
                    else
                    {
                       //var tempCall=new Entity.Call();
                          
                        call.id = Convert.ToInt32(lastCallId);
                        call.callerName = this.txtName.Text;


                        call.inboundCallerType = new Entity.CallerType() { id = this.cmbCallerType.SelectedIndex == 0 ? null : this.cmbCallerType.SelectedValue.ToString() };
                        call.callerTypeDetail = new Entity.CallerTypeDetail() { id = this.cmbCallerTypeDetail.SelectedIndex == 0 ? null : this.cmbCallerTypeDetail.SelectedValue.ToString() };


                        call.isTestCall = this.chkTestCall.Checked ? "2" : "1";
                        call.isPrankCall = this.chkPrankCall.Checked ? "2" : "1";
                        call.isBlankCall = this.chkBlankCall.Checked ? "2" : "1";
                        call.isWrongNumber = this.chkWrongNo.Checked ? "2" : "1";
                        call.isComplaint = this.chkComplain.Checked ? "2" : "1";
                        call.isInquiry = this.chkInquiry.Checked ? "2" : "1";
                        call.isRequest = this.chkRequest.Checked ? "2" : "1";
                        call.isProspectCustomer = this.chkProspectCustomer.Checked ? "2" : "1";
                        call.isOthers = this.chkOthers.Checked ? "2" : "1";
                      //  call.area = new Area() { id = this.cmbArea.SelectedValue.ToString() };
                        call.city = this.cmbCity.SelectedIndex == 0 ? null : this.cmbCity.SelectedValue.ToString();
                       // call.zipCode = this.txtKodePos.Text;
                        call.email = this.txtEmail.Text;
                        call.address = this.txtAlamat.Text;
                        call.building = this.txt_bulding.Text;
                        call.telephone = this.txtTelepone.Text;
                        call.handphone = this.txtHandphone.Text;

                        call.modelId = string.IsNullOrEmpty(modelId) ? null : this.modelId;

                        //call.tvSizeId = this.cmbSize.SelectedIndex == 0 ? null : this.cmbSize.SelectedValue.ToString();
                        //call.serialNo = this.txtSerialNo.Text;
                        //call.purchaseDate = string.IsNullOrEmpty(modelId) ? null : this.dtPurchaseDate.Value.ToString("yyyy-MM-dd");
                        //call.problemDate = string.IsNullOrEmpty(modelId) ? null : this.dtProblemDate.Value.ToString("yyyy-MM-dd");
                        //call.symptomCodeId = this.cmbSymptonCode.SelectedIndex == 0 ? null : this.cmbSymptonCode.SelectedValue.ToString();
                        //call.warrantyStatusId = this.cmbWarrantyStatus.SelectedIndex == 0 ? null : this.cmbWarrantyStatus.SelectedValue.ToString();
                        //call.productLocationId = this.cmbProductLocation.SelectedIndex == 0 ? null : this.cmbProductLocation.SelectedValue.ToString();

                        call.voiceFile = this.voiceFile;
                        call.note = this.txtNote.Text;


                        var updateCall = callDao.Update(call);
                        if (updateCall)
                        {
                     
                            SaveTicketTag(lastCallId);
                            var deleteTag = new Dao.CallTagDao().Delete(lastCallId);
                            SaveInboundDetailTag(lastCallId);    
                            mainForm.tempCallId = lastCallId;
                            if (!fromOpenTicket) { MessageBox.Show("Saved success."); }
                            mainForm.inboundCallForm = null;
                            mainForm.btn_main_logout.Enabled = true;
                            mainForm.TableLayoutPanel19.Enabled = true;
                            if (isHangup) { Dispose(); }
                        }
                        else
                        {
                            MessageBox.Show("Saved error.");

                        }

                    }
                }
                //mode edit
                else
                {
                    if (this.chkBlankCall.Checked == false && this.chkComplain.Checked == false && this.chkInquiry.Checked == false && this.chkOthers.Checked == false && this.chkRequest.Checked == false
                       && this.chkTestCall.Checked == false && this.chkWrongNo.Checked == false && this.chkPrankCall.Checked == false )
                    { MessageBox.Show("Please select Inbound Type."); return; }

                    call.direction = new Entity.Direction() { id = 1 };


                    call.inboundCallerType = new Entity.CallerType() { id = this.cmbCallerType.SelectedIndex == 0 ? null : this.cmbCallerType.SelectedValue.ToString() };
                    call.callerTypeDetail = new Entity.CallerTypeDetail() { id = this.cmbCallerTypeDetail.SelectedIndex == 0 ? null : this.cmbCallerTypeDetail.SelectedValue.ToString() };

                    call.isTestCall = this.chkTestCall.Checked ? "2" : "1";
                    call.isBlankCall = this.chkBlankCall.Checked ? "2" : "1";
                    call.isPrankCall = this.chkPrankCall.Checked ? "2" : "1";
                    call.isWrongNumber = this.chkWrongNo.Checked ? "2" : "1";
                    call.isInquiry = this.chkInquiry.Checked ? "2" : "1";
                    call.isComplaint = this.chkComplain.Checked ? "2" : "1";
                    call.isRequest = this.chkRequest.Checked ? "2" : "1";
                    //call.isProspectCustomer = this.chkProspectCustomer.Checked ? "2" : "1";
                    call.isOthers = this.chkOthers.Checked ? "2" : "1";

                  //  call.area = new Area() { id = this.cmbArea.SelectedValue.ToString() };
                    call.city = this.cmbCity.SelectedIndex == 0 ? null : this.cmbCity.SelectedValue.ToString();
                   // call.zipCode = this.txtKodePos.Text;
                    call.email = this.txtEmail.Text;
                    call.address = this.txtAlamat.Text;
                    call.building = this.txt_bulding.Text;
                    call.telephone = this.txtTelepone.Text;
                    call.handphone = this.txtHandphone.Text;

                    call.modelId =string.IsNullOrEmpty(modelId) ? null : this.modelId;

                    //call.tvSizeId = this.cmbSize.SelectedIndex == 0 ? null : this.cmbSize.SelectedValue.ToString();
                    //call.serialNo = this.txtSerialNo.Text;
                    //call.purchaseDate = string.IsNullOrEmpty(modelId) ? null : this.dtPurchaseDate.Value.ToString("yyyy-MM-dd");
                    //call.problemDate = string.IsNullOrEmpty(modelId) ? null : this.dtProblemDate.Value.ToString("yyyy-MM-dd");
                    //call.symptomCodeId = this.cmbSymptonCode.SelectedIndex == 0 ? null : this.cmbSymptonCode.SelectedValue.ToString();
                    //call.warrantyStatusId = this.cmbWarrantyStatus.SelectedIndex == 0 ? null : this.cmbWarrantyStatus.SelectedValue.ToString();
                    //call.productLocationId = this.cmbProductLocation.SelectedIndex == 0 ? null : this.cmbProductLocation.SelectedValue.ToString();
                    
                    call.note = this.txtNote.Text;
                    call.callerName = this.txtName.Text;
                  

                    if (callDao.Update(call))
                    {
                        var deleteTag = new Dao.CallTagDao().Delete(call.id.ToString());
                        SaveInboundDetailTag(call.id.ToString());                       
                        SaveTicketTag(call.id.ToString());
                        if (!fromOpenTicket) { MessageBox.Show("Update success."); }
                    }
                    else { MessageBox.Show("Saved error."); }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "Saved error."); }

        }

        private void chkService_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            fromOpenTicket = true;
            this.btnSaveDataCall.PerformClick();

            Entity.TempTicket tmpticket = new TempTicket()
            {
                tempUserId = Global.userAccount.id,
                tempPasswd = Global.hashPassword,
                tempSourceMediaId = "4",
                tempModelId=this.modelId,
                tempCity=this.cmbCity.Text,
                tempCustMobilePhone=this.txtHandphone.Text,
                tempCustomerAddrs=this.txtAlamat.Text,
                tempCustomerName=this.txtName.Text, 
                //tempSerialNo=this.txtSerialNo.Text,
                tempCustPhone=this.txtTelepone.Text,
                //tempPurchaseDate=string.IsNullOrEmpty(this.modelId)?"":this.dtPurchaseDate.Value.ToString("yyyy-MM-dd"),
                //tempPorblemDate = string.IsNullOrEmpty(this.modelId) ? "" : this.dtProblemDate.Value.ToString("yyyy-MM-dd"),
                tempMediaId = (string.IsNullOrEmpty(call.id.ToString()) || call.id.ToString()=="0" ? lastCallId : call.id.ToString()),
                //tempSymthomId = string.IsNullOrEmpty(this.modelId)?"":this.cmbSymptonCode.SelectedValue.ToString(),
                //tempSizeId = string.IsNullOrEmpty(this.modelId) ? "" : this.cmbSize.SelectedValue.ToString(),
                //tempWarrantyStatusId = string.IsNullOrEmpty(this.modelId) ? "" : this.cmbWarrantyStatus.SelectedValue.ToString(),
                //tempProductLocationId = string.IsNullOrEmpty(this.modelId) ? "" : this.cmbProductLocation.SelectedValue.ToString(),
                tempProductTypeId = string.IsNullOrEmpty(this.modelId) ? "" : new Dao.ModelDao().GetProductTypeId(this.modelId)
                //tempProductTypeId = 
            };
                var createTicket = new View.CreateTicket(tmpticket);
               // var createTicket = new View.CreateTicket(this.txtName.Text,this.txtAlamat.Text,this.txtKota.Text,this.txtTelepone.Text,this.txtHandphone.Text);
                createTicket.StartPosition = FormStartPosition.CenterScreen;
                createTicket.WindowState = FormWindowState.Maximized;
                createTicket.inboundForm = this;
                createTicket.Show();

            
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(tabControl2.SelectedIndex==1)
            {
                //LoadCustomerData();
            }
            if (tabControl2.SelectedIndex == 2)
            {
              //LoadVehicleData();
            }
            if (tabControl2.SelectedIndex == 3) {  }
        }

        private void InboundCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!modeEdit)
            {
                e.Cancel = true;
            }
            else
            {
                if (listOfTicketToTag.Count>1)
                {
                    if (listOfTicketToTag[0] != null)
                    {
                        if (listOfTicketToTag.Count > 0)
                        {
                            MessageBox.Show("Save all data first.");
                            e.Cancel = true;
                        }
                    }
                }
               
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //LoadProductVehicle(this.cmbBrand.SelectedIndex, this.txtSearch.Text);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
            isHiden = true;
            mainForm.btn_maximize.BackColor = Color.Yellow;
            mainForm.btn_maximize.Text = "Inbound Call";
            mainForm.btn_maximize.Font = new Font("Verdana", 8, FontStyle.Regular);
           mainForm.btn_maximize.ForeColor = Color.OrangeRed;
        }

        private void dtgridTicket_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    var result = new Dao.TicketDao().GetByTicketId(this.dtgridTicket.SelectedCells[0].Value.ToString());
            //    var ticketPreview=new View.TicketPreview(result);
            //    ticketPreview.StartPosition=FormStartPosition.CenterScreen;
            //    ticketPreview.ShowDialog();
            //}
            //catch
            //{                              
            ////}
        }

        private void dtGridTicketByCallerNo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void dtGridTicketByCallerNo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        var result = new Dao.TicketDao().GetByTicketId(this.dtGridTicketByCallerNo.SelectedCells[0].Value.ToString());
        //        var ticketPreview = new View.TicketPreview(result);
        //        ticketPreview.StartPosition = FormStartPosition.CenterScreen;
        //        ticketPreview.ShowDialog();
        //    }
        //    catch
        //    {
        //    }
        //}

        private void chkTestCall_Click(object sender, EventArgs e)
        {
            checklistEnabled((CheckBox)sender);
        }

        private void checklistEnabled()
        {
            if (this.chkTestCall.Checked || this.chkBlankCall.Checked || this.chkWrongNo.Checked || this.chkPrankCall.Checked)
            {
                this.chkOthers.Enabled = false; this.chkOthers.Checked = false;
                this.chkProspectCustomer.Enabled = false; this.chkProspectCustomer.Checked = false;
                this.chkRequest.Enabled = false; this.chkRequest.Checked = false;
                this.chkComplain.Enabled = false; this.chkComplain.Checked = false;
                this.chkInquiry.Enabled = false; this.chkInquiry.Checked = false;
            }
            else if (!this.chkTestCall.Checked && !this.chkBlankCall.Checked && !this.chkWrongNo.Checked && !this.chkPrankCall.Checked)
            {
                this.chkOthers.Enabled = true;
                this.chkProspectCustomer.Enabled = true;
                this.chkRequest.Enabled = true;
                this.chkComplain.Enabled = true;
                this.chkInquiry.Enabled = true;
            }
        }
        private void checklistEnabled(CheckBox notAffectedObject)
        {
            if (this.chkTestCall.Checked || this.chkBlankCall.Checked || this.chkWrongNo.Checked || this.chkPrankCall.Checked)
            {

                this.chkTestCall.Enabled = false; this.chkTestCall.Checked = false;
                this.chkBlankCall.Enabled = false; this.chkBlankCall.Checked = false;
                this.chkWrongNo.Enabled = false; this.chkWrongNo.Checked = false;
                this.chkPrankCall.Enabled = false; this.chkPrankCall.Checked = false;

                this.chkOthers.Enabled = false; this.chkOthers.Checked = false;
                this.chkProspectCustomer.Enabled = false; this.chkProspectCustomer.Checked = false;
                this.chkRequest.Enabled = false; this.chkRequest.Checked = false;
                this.chkComplain.Enabled = false; this.chkComplain.Checked = false;
                this.chkInquiry.Enabled = false; this.chkInquiry.Checked = false;
               

                notAffectedObject.Enabled = true; notAffectedObject.Checked = true;
            }
            else if (!this.chkTestCall.Checked && !this.chkBlankCall.Checked && !this.chkWrongNo.Checked && !this.chkPrankCall.Checked)
            {
                this.chkTestCall.Enabled = true;
                this.chkBlankCall.Enabled = true;
                this.chkWrongNo.Enabled = true;
                this.chkPrankCall.Enabled = true;

                this.chkOthers.Enabled = true;
                this.chkProspectCustomer.Enabled = true;
                this.chkRequest.Enabled = true;
                this.chkComplain.Enabled = true;
                this.chkInquiry.Enabled = true;
                
            }
        }

        private void chkBlankCall_Click(object sender, EventArgs e)
        {
            checklistEnabled((CheckBox)sender);

        }

        private void chkWrongNo_Click(object sender, EventArgs e)
        {
            checklistEnabled((CheckBox)sender);
        }

        private void chkTestCall_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_transfer_Click(object sender, EventArgs e)
        {
            var monitoring = new View.Monitor(true, Convert.ToInt32(lastCallId));
            monitoring.monitoringOpenBy = Monitor.MonitoringOpenBy.InboundCall; 
            

            monitoring.ShowDialog();
        }

        private void chkRequest_CheckedChanged(object sender, EventArgs e)
        {

            //if (Global.callState == Global.CallState.INCALL)
            //{
            //    if (chkRequest.Checked == true)
            //    {
            //        string templateRequest = string.Empty;
            //        templateRequest += "- Model :\r\n";
            //        templateRequest += "- Symptom Code :\r\n";
            //        templateRequest += "- Warranty Status : \r\n";
            //        templateRequest += "- Serial Number :\r\n";
            //        templateRequest += "- Purchase Date :\r\n";
            //        templateRequest += "- Problem Date :\r\n";
            //        templateRequest += "- Product Location :\r\n";
            //        txtNote.Text = templateRequest;
            //    }
            //    else
            //        txtNote.Clear();
            //}
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTelepone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHandphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKota_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchModel_Click(object sender, EventArgs e)
        {
            var searchModelForm = new View.Model();
            searchModelForm.StartPosition = FormStartPosition.CenterScreen;
            searchModelForm.formInboundCall = this;
            searchModelForm.ShowDialog();

            //if(searchModelForm.DialogResult==DialogResult.OK)
            //{
            //    this.btnDeleteModel.Visible = true;
            //    this.cmbProductLocation.Enabled = true;
            //    this.cmbWarrantyStatus.Enabled = true;
            //    this.cmbSymptonCode.Enabled = true;
            //    this.cmbSize.Enabled = true;
            //    this.dtProblemDate.Enabled = true;
            //    this.dtPurchaseDate.Enabled = true;
            //    this.txtSerialNo.Enabled = true;

            //}

        }

        //private void btnDeleteModel_Click(object sender, EventArgs e)
        //{
        //    this.modelId = null;
        //    this.txtModel.Clear();
        //    this.btnDeleteModel.Visible = false;
        //    this.cmbProductLocation.Enabled = false;
        //    this.cmbWarrantyStatus.Enabled = false;
        //    this.cmbSymptonCode.Enabled = false;
        //    this.cmbSize.Enabled = false;
        //    this.dtProblemDate.Enabled = false;
        //    this.dtPurchaseDate.Enabled = false;
        //    this.txtSerialNo.Enabled = false;

        //    this.txtSerialNo.Clear();
        //    this.cmbSize.SelectedIndex = 0;
        //    this.cmbSymptonCode.SelectedIndex = 0;
        //    this.cmbWarrantyStatus.SelectedIndex = 0;
        //    this.cmbProductLocation.SelectedIndex = 0;

        //    this.dtProblemDate.Value = DateTime.Now;
        //    this.dtPurchaseDate.Value = DateTime.Now;
        //}

        private void chkPrankCall_Click(object sender, EventArgs e)
        {
            checklistEnabled((CheckBox)sender);
        }

        private void txtCallerNumber_KeyUp(object sender, KeyEventArgs e)
        {
            //LoadDataTicketByCallNo();
        }

        private void cmbCity_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void timerDurasiBusy_Tick(object sender, EventArgs e)
        {

        }
    }
}
