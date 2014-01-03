using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Controllers;

namespace PlannerWeb
{
    public partial class EditOrder : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtOrderType.Text = Request["OrderType"];
        }
    }
}