using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contact_Center_Kone.Utility
{
    public class FilterUtil
    {
        public static void checkboxFilter(CheckBox checkBox)
        {
            bool e = false;

            foreach (object item in checkBox.Parent.Controls)
            {
                if (!checkBox.Checked)
                {
                    if (item.GetType().Name.Equals("TextBox"))
                    {
                        ((TextBox)item).Text = "";
                    }

                    if (item.GetType().Name.Equals("ComboBox"))
                    {
                        ((ComboBox)item).SelectedIndex = -1;
                    }
                }
                else
                {
                    if (!item.GetType().Name.Equals("CheckBox"))
                    {
                        e = false;
                        if (item.GetType().Name.Equals("TextBox"))
                        {
                            e = (((TextBox)item).Text == "");
                        }

                        if (item.GetType().Name.Equals("ComboBox"))
                        {
                            e = (((ComboBox)item).Text == "");
                        }

                        if (e)
                        {
                            checkBox.Checked = false;
                        }
                    }
                }
            }
        }


        public static void updateFilter(Panel filterPanel)
        {
            try
            {
                string f = "";
                string e = "";

                CheckBox checkBox;
                object obj;

                foreach (object ctl in filterPanel.Controls)
                {
                    if (ctl.GetType().Name.Equals("Panel"))
                    {
                        checkBox = null;
                        obj = null;

                        foreach (object item in ((Panel)ctl).Controls)
                        {
                            if (item.GetType().Name.Equals("CheckBox"))
                            {
                                checkBox = (CheckBox)item;
                            }
                            else
                            {
                                obj = (Object)item;
                            }
                        }


                        if (checkBox != null && obj != null)
                        {
                            if (obj.GetType().Name.Equals("TextBox"))
                            {
                                checkBox.Checked = (((TextBox)obj).Text != "");
                                if (checkBox.Checked)
                                    e = (string)((TextBox)obj).Tag + " like '%" + ((TextBox)obj).Text.Trim() + "%'";
                            }

                            if (obj.GetType().Name.Equals("ComboBox"))
                            {
                                Console.WriteLine("obj name : " + obj.GetType().Name.ToString());
                                Console.WriteLine("obj name : " + ((ComboBox)obj).Name.ToString());
                                Console.WriteLine("obj text : " + ((ComboBox)obj).Text.ToString());

                                checkBox.Checked = (((ComboBox)obj).Text.Trim() != "");
                                if (checkBox.Checked)
                                    e = (string)((ComboBox)obj).Tag + " = " + ((ComboBox)obj).SelectedValue.ToString();
                            }
                        }

                        if (checkBox != null)
                        {
                            if (checkBox.Checked)
                            {
                                /*
                                if (f != "")
                                {
                                    f += " and ";
                                }
                                */

                                f += " and " + e;
                            }
                        }
                    }
                }

                filterPanel.Tag = f;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

    }
}
