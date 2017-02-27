using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Utility
{
    /// <summary>
    /// teste
    /// </summary>
    ///  
    /// 
   
    
    public class CustomTextBox:System.Windows.Forms.TextBox
    {

        string defaultValidString = "0987654321";

        #region ExtendedProperties
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("NUmeric only.")]
       // [DefaultValue(true)]
        public bool IsNumber 
        { 
            get; set;
        }
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Title Case.")]
        //[DefaultValue(true)]
        public bool IsProperCase
        {
            get;
            set;
        }
        public bool IsMoneyFormat
        { get; set; }
        public string ValidString
        {
            set { defaultValidString = value; }
            get { return defaultValidString; }
        }

        #endregion
        #region Overriding
        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (IsProperCase && e.KeyCode!=System.Windows.Forms.Keys.Back)
            {
                base.Text =  System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(base.Text);
                base.SelectionStart=base.Text.Length;               
            }
            
        }
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if(IsNumber)
            {
                //var validString = "0123456789";
                if (ValidString.IndexOf(e.KeyChar) != -1 || e.KeyChar == Convert.ToChar(System.Windows.Forms.Keys.Back))
                { 
                    e.Handled = false; 
                }
                else { 
                    e.Handled = true; 
                }
            }
            
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            try
            {
                if (IsMoneyFormat && IsNumber)
                {
                    base.Text = Convert.ToDouble(base.Text).ToString("N");
                }
            }
            catch { }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (IsMoneyFormat && IsNumber)
                {
                    base.Text = Convert.ToDouble(value).ToString("N");
                }
                else
                {
                    base.Text = value;
                }
            }
        }

        #endregion
    }
}
