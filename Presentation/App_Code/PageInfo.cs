using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlannerWeb.App_Code
{
    public struct PageInfo
    {
        #region Fields
        private int _totalpages;
        private int _currentpage;
        private int _totalorders;
        private string _pagedata;
        private string _summarydata1;
        private string _summarydata2;
        private bool _summary;
        #endregion

        #region Propierties
        public int TotalPages
        {
            get { return _totalpages; }
        }

        public int CurrentPage
        {
            get { return _currentpage; }
        }

        public int TotalOrders
        {
            get { return _totalorders; }
        }

        public string PageData
        {
            get { return _pagedata; }
        }

        public bool Summary
        {
            get { return _summary; }
        }

        public string SummaryData1
        {
            get {return _summarydata1;}
        }

        public string SummaryData2
        {
            get {return _summarydata2;}
        }
        #endregion

        public PageInfo(int totalpages, int currentpage, int totalorders, string pagedata, bool summary)
        {
            _totalpages = totalpages;
            _currentpage = currentpage;
            _totalorders = totalorders;
            _pagedata = pagedata;
            _summary = summary;
            _summarydata1 = null;
            _summarydata2 = null;
        }

        public PageInfo(int totalpages, int currentpage, int totalorders, string summary1, string summary2, bool summary)
            :this(totalpages, currentpage, totalorders, null, summary)
        {
            _summarydata1 = summary1;
            _summarydata2 = summary2;
        }
    }
}