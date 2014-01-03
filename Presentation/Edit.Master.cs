using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PlannerWeb
{
    public partial class Edit : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //if (Session["Name"] != null) BtnLogOut.Text = Session["Name"] + ", Salir";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}