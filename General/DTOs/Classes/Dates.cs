using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.DTOs.Classes
{
    public class Dates
    {
        private List<Date> _dts;
        private List<Turn> _trns;
        private string _assessorname;
        private int _totalpages;

        #region Propierties
        public List<Date> Dts
        {
            get { return _dts; }
        }

        public List<Turn> Trns
        {
            get { return _trns; } 
        }

        public string AssessorName
        {
            get { return _assessorname; }
        }

        public int TotalPages
        {
            get { return _totalpages; }
        }
        #endregion

        public Dates(string aname, int totalpages)
        {
            _dts = new List<Date>();
            _trns = new List<Turn>();
            _assessorname = aname;
            _totalpages = totalpages;
        }
    }

    public class Date
    {
        private DateTime _hour;
        private string _client;
        private string _vehicle;
        private string _plates;
        private string _servicedate;

        #region Propierties
        public DateTime Hour
        {
            get{return _hour;}
        }

        public string Client
        {
            get{return _client;}
        }

        public string Vehicle
        {
            get{return _vehicle;}
        }

        public string Plates
        {
            get{return _plates;}
        }

        public string ServiceDate
        {
            get{return _servicedate;}
        }
        #endregion

        public Date(DateTime hour, string client, string vehicle, string plates, string servicedate )
        {
            _hour = hour;
            _client = client;
            _vehicle = vehicle;
            _plates = plates;
            _servicedate = servicedate;
        }
    }

    public class Turn
    {
        private DateTime _hour;
        private bool _available;
        private string _description;
        private bool _morningturn;

        #region Propierties
        public DateTime Hour
        {
            get {return _hour; } 
        }

        public bool Available
        {
            get{return _available;}
        }

        public string StatusDescription
        {
            get { return _description; }
        }

        public bool MorningTurn
        {
            get { return _morningturn; }
        }
        #endregion

        public Turn(DateTime hour, bool available, string statusdescription, bool morningturn = false)
        {
            _hour = hour;
            _available = available;
            _description = statusdescription;
            _morningturn = morningturn;
        }
    }
}
