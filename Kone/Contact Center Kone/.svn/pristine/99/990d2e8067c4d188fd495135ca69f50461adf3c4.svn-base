using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Utility
{
    public class Paging
    {
        private DbMyConnection myConn = new DbMyConnection();
        private string strSql = string.Empty;
        private string strSqljumlah = string.Empty;
        private int _jumlahdata;
        private int _startindex = 0;
        private int _absolutepage = 1;
        private int _jumlahpage = 0;
        private int _batasdata = 100;
        private int _jumlahkolom;

        public Paging()
        {
        }
        public int Startindex
        {
            get { return _startindex; }
            set { _startindex = value; }
        }
        public string SqlLoaddata
        {
            get { return strSql; }
            set { strSql = value; _absolutepage = 1; _startindex = 0; }
        }
        public string SqlCountData
        {
            get { return strSqljumlah; }
            set
            {
                strSqljumlah = value; GetJumlahData(); GetJumlahPage();
            }
        }
        public int JumlahKolom
        {
            get { return _jumlahkolom; }
            set { _jumlahkolom = value; }
        }
        public int BatasData
        {
            get { return _batasdata; }
            set { _batasdata = value; _startindex = 0; GetJumlahData(); GetJumlahPage(); }
        }
        public int JumlahPage
        {
            get { return _jumlahpage; }

        }
        public int AbsolutePage
        {
            get { return _absolutepage; }
            set { _absolutepage = value; }
        }
        public int JumlahData
        {
            get { return _jumlahdata; }
        }
        private void GetJumlahData()
        {
            try
            {

                myConn.MyConn.Open();
                myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(strSqljumlah, myConn.MyConn);
                int result = Convert.ToInt32(myConn.MyCommand.ExecuteScalar());
                _jumlahdata = result;
                //return result;
            }
            catch { }
            finally { myConn.MyConn.Close(); }
        }
        private void GetJumlahPage()
        {
            if (JumlahData > 0)
            {
                int tmp;
                int sisabagi = JumlahData % _batasdata;
                if (sisabagi != 0)
                {
                    tmp = ((JumlahData - sisabagi) / _batasdata) + 1;

                }
                else { tmp = (JumlahData / _batasdata); }
                _jumlahpage = tmp;
            }
            else { _jumlahpage = 0; }
        }
        public void NextPage()
        {
            if (JumlahPage > 0)
            {
                if (_absolutepage == _jumlahpage)
                {
                    _startindex = _batasdata * (_jumlahpage - 1); _absolutepage = _jumlahpage;
                }
                else
                {
                    _startindex += _batasdata; _absolutepage += 1;

                }
            }

        }
        public void PreviousPage()
        {
            if (JumlahPage > 0)
            {
                if (_absolutepage == 1)
                {
                    _startindex = 0; _absolutepage = 1;
                }
                else
                {
                    _startindex -= _batasdata; _absolutepage -= 1;
                }
            }
        }
        public void FirstPage()
        {
            _startindex = 0; _absolutepage = 1;
        }
        public void LastPage()
        {
            if (JumlahPage > 0)
            {
                _startindex = _batasdata * (_jumlahpage - 1); _absolutepage = _jumlahpage;
            }

        }
    }
}
