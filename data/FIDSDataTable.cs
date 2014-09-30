using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data
{
    public partial class FIDSDataTable
    {
        private static FIDSDataset.airlineDataTable _airline;
        private static FIDSDataset.configDataTable _config;
        private static FIDSDataset.dictionaryDataTable _dictionary;
        private static FIDSDataset.flightdynamicDataTable _flightdynamic;
        private static FIDSDataset.flightplanDataTable _flightplan;
        private static FIDSDataset.ipcstatusDataTable _ipcstatus;
        private static FIDSDataset.subsystemDataTable _subsystem;

        public static FIDSDataset.airlineDataTable Airline {
            get {
                if (_airline == null)
                {
                    _airline = new FIDSDataset.airlineDataTable();
                }
                return _airline;
            }
            set { _airline = value; }
        }
        public static FIDSDataset.configDataTable Config
        {
            get
            {
                if (_config == null)
                {
                    _config = new FIDSDataset.configDataTable();
                }
                return _config;
            }
            set { _config = value; }
        }
        public static FIDSDataset.dictionaryDataTable Dictionary
        {
            get
            {
                if (_dictionary == null)
                {
                    _dictionary = new FIDSDataset.dictionaryDataTable();
                }
                return _dictionary;
            }
            set { _dictionary = value; }
        }
        public static FIDSDataset.flightdynamicDataTable FlightDynamic
        {
            get
            {
                if (_flightdynamic == null)
                {
                    _flightdynamic = new FIDSDataset.flightdynamicDataTable();
                }
                return _flightdynamic;
            }
            set { _flightdynamic = value; }
        }
        public static FIDSDataset.flightplanDataTable FlightPlan
        {
            get
            {
                if (_flightplan == null)
                {
                    _flightplan = new FIDSDataset.flightplanDataTable();
                }
                return _flightplan;
            }
            set { _flightplan = value; }
        }
        public static FIDSDataset.ipcstatusDataTable IPCStatus
        {
            get
            {
                if (_ipcstatus == null)
                {
                    _ipcstatus = new FIDSDataset.ipcstatusDataTable();
                }
                return _ipcstatus;
            }
            set { _ipcstatus = value; }
        }
        public static FIDSDataset.subsystemDataTable Subsystem
        {
            get
            {
                if (_subsystem == null)
                {
                    _subsystem = new FIDSDataset.subsystemDataTable();
                }
                return _subsystem;
            }
            set { _subsystem = value; }
        }
    }
}
