using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.FIDSDatasetTableAdapters;

namespace data
{
    public partial class FIDSAdapter
    {
        private static airlineTableAdapter _airlineAdapter;
        private static configTableAdapter _configAdapter;
        private static dictionaryTableAdapter _dictionaryAdapter;
        private static flightdynamicTableAdapter _flightdynamicAdapter;
        private static flightplanTableAdapter _flightplanAdapter;
        private static ipcstatusTableAdapter _ipcstatusAdapter;
        private static subsystemTableAdapter _subsystemAdapter;

        public static airlineTableAdapter AirlineAdapter
        {
            get
            {
                if (_airlineAdapter == null)
                {
                    _airlineAdapter = new airlineTableAdapter();
                }
                return _airlineAdapter;
            }
            set
            {
                _airlineAdapter = value;
            }
        }
        public static configTableAdapter ConfigAdapter
        {
            get
            {
                if (_configAdapter == null)
                {
                    _configAdapter = new configTableAdapter();
                }
                return _configAdapter;
            }
            set
            {
                _configAdapter = value;
            }
        }
        public static dictionaryTableAdapter DictionaryAdapter
        {
            get
            {
                if (_dictionaryAdapter == null)
                {
                    _dictionaryAdapter = new dictionaryTableAdapter();
                }
                return _dictionaryAdapter;
            }
            set
            {
                _dictionaryAdapter = value;
            }
        }
        public static flightdynamicTableAdapter FlightDynamicAdapter
        {
            get
            {
                if (_flightdynamicAdapter == null)
                {
                    _flightdynamicAdapter = new flightdynamicTableAdapter();
                }
                return _flightdynamicAdapter;
            }
            set
            {
                _flightdynamicAdapter = value;
            }
        }
        public static flightplanTableAdapter FlightPlanAdapter
        {
            get
            {
                if (_flightplanAdapter == null)
                {
                    _flightplanAdapter = new flightplanTableAdapter();
                }
                return _flightplanAdapter;
            }
            set
            {
                _flightplanAdapter = value;
            }
        }
        public static ipcstatusTableAdapter IPCStatusAdapter
        {
            get
            {
                if (_ipcstatusAdapter == null)
                {
                    _ipcstatusAdapter = new ipcstatusTableAdapter();
                }
                return _ipcstatusAdapter;
            }
            set
            {
                _ipcstatusAdapter = value;
            }
        }
        public static subsystemTableAdapter SubsystemAdapter
        {
            get
            {
                if (_subsystemAdapter == null)
                {
                    _subsystemAdapter = new subsystemTableAdapter();
                }
                return _subsystemAdapter;
            }
            set
            {
                _subsystemAdapter = value;
            }
        }
    }
}
