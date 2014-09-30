using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Configuration;
using System.Threading;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace global
{
    public partial class Variable
    {

        private static IPAddress _ip;
        public static IPAddress IP
        {
            get
            {
                if (_ip == null)
                {
                    try
                    {
                        _ip = IPAddress.Parse(ConfigurationManager.AppSettings[Const.IPKEY]);
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.StackTrace);
                        _ip = null;
                    }
                }
                return _ip;
            }
            set
            {
                try
                {
                    Function.SetConfigValue(Const.IPKEY, value.ToString());
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                    _ip = null;
                }

                _ip = value;

            }
        }

        private static int _port;
        public static int Port
        {
            get
            {
                if (_port == 0)
                {
                    _port = 8123;
                }
                return _port;
            }
            set { _port = value; }
        }

        private static string _user;
        public static string USER
        {
            get
            {
                if (_user == null)
                {
                    try
                    {
                        _user = ConfigurationManager.AppSettings[Const.USERKEY];
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.StackTrace);
                        _user = null;
                    }
                }
                return _user;
            }
            set
            {
                try
                {
                    Function.SetConfigValue(Const.USERKEY, value.ToString());
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                    _user = null;
                }

                _user = value;

            }
        }

        private static string _password;
        public static string PASSWORD
        {
            get
            {
                if (_password == null)
                {
                    try
                    {
                        _password = ConfigurationManager.AppSettings[Const.PASSWORDKEY];
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.StackTrace);
                        _password = null;
                    }
                }
                return _password;
            }
            set
            {
                try
                {
                    Function.SetConfigValue(Const.PASSWORDKEY, value.ToString());
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                    _password = null;
                }

                _password = value;

            }
        }

        private static int _rowcount;
        public static int RowCount
        {
            get
            {
                if (_rowcount == 0)
                {
                    try
                    {
                        _rowcount = int.Parse(ConfigurationManager.AppSettings[Const.ROWCOUNT]);
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.StackTrace);
                        _rowcount = 11;
                    }
                }
                return _rowcount;
            }
            set
            {
                try
                {
                    Function.SetConfigValue(Const.ROWCOUNT, value.ToString());
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                    _rowcount = 0;
                }

                _rowcount = value;

            }
        }

        private static string _gate;
        public static string GATE
        {
            get
            {
                if (_gate == null)
                {
                    try
                    {
                        _gate = ConfigurationManager.AppSettings[Const.GATE];
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.StackTrace);
                        _gate = "";
                    }
                }
                return _gate;
            }
            set
            {
                try
                {
                    Function.SetConfigValue(Const.GATE, value.ToString());
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                    _gate = "";
                }

                _gate = value;

            }
        }

        private static string _cssstyle;
        public static string CSSSTYLE
        {
            get
            {
                if (_cssstyle == null)
                {
                    try
                    {
                        _cssstyle = ConfigurationManager.AppSettings[Const.CSSSTYLE];
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.StackTrace);
                        _cssstyle = null;
                    }
                }
                return _cssstyle;
            }
            set
            {
                try
                {
                    Function.SetConfigValue(Const.CSSSTYLE, value.ToString());
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                    _cssstyle = null;
                }

                _cssstyle = value;

            }
        }

        private static string _carouseld;
        public static string CAROUSELD
        {
            get
            {
                if (_carouseld == null)
                {
                    try
                    {
                        _carouseld = ConfigurationManager.AppSettings[Const.CAROUSELD];
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.StackTrace);
                        _carouseld = null;
                    }
                }
                return _carouseld;
            }
            set
            {
                try
                {
                    Function.SetConfigValue(Const.CAROUSELD, value.ToString());
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                    _carouseld = null;
                }

                _carouseld = value;

            }
        }
        public static int GetFlightDynamic_Interval { get; set; }
        public static global.SubsystemType Subsystem { get; set; }
        public static TimeSpan TIMESPLIT { get; set; }
        public static Thread GetDynamicThread { get; set; }
        public static Thread GetPlanThread { get; set; }
        public static string LOGOFolder
        {
            get
            {
                return Application.StartupPath + "\\image\\logo";
            }
        }
        public static string ADFolder
        {
            get
            {
                return Application.StartupPath + "\\image\\ad";
            }
        }
        public static Dictionary<string, Image> ImageDictionary = new Dictionary<string, Image>();
        public static Dictionary<string, Image> ImageLogoDictionary = new Dictionary<string, Image>();

        public static data.FIDSDataset.remarkinfoviewDataTable ColorTable;
        public static string WEBSERVICEERROR { get; set; }

        public static int ERRORTIMECOUNT = 0;

        public static bool APPLICATIONRUN = false;

        public static bool ADMIN = false;
    }
}
