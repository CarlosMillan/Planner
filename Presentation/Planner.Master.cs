using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

namespace Planner
{
    public partial class Planner : System.Web.UI.MasterPage
    {
        public int TimePagination;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Planeador";
            TimePagination = Int32.Parse(ConfigurationManager.AppSettings["TimepPagination"]) * 1000;
        }
    }
}