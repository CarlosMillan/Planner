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
        #endregion

        public PageInfo(int totalpages, int currentpage, int totalorders, string pagedata)
        {
            _totalpages = totalpages;
            _currentpage = currentpage;
            _totalorders = totalorders;
            _pagedata = pagedata;
        }
    }
}