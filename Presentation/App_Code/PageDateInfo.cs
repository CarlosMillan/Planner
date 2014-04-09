using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlannerWeb.App_Code
{
    public struct PageDateInfo
    {
        #region Fields
        private string _assesorname;
        private string _assessorid;
        private int _totalpages;
        private string _datestable;
        private string _morningtable;
        private string _eveningtable;
        #endregion

        #region Propierties
        public string AssessorId
        {
            get { return _assessorid; }
        }

        public string AssessorName
        {
            get { return _assesorname; }
        }

        public int TotalPages
        {
            get { return _totalpages; }
        }

        public string DatesTable
        {
            get { return _datestable; }
        }

        public string MorningTable
        {
            get { return _morningtable; }
        }

        public string EveningTable
        {
            get { return _eveningtable; }
        }
        #endregion

        public PageDateInfo(string assessorid, string aname, int totalpages, string datestable, string morningtable, string eveningtable)
        {
            _assesorname = aname;
            _totalpages = totalpages;
            _datestable = datestable;
            _morningtable = morningtable;
            _eveningtable = eveningtable;
            _assessorid = assessorid;
        }
    }
}