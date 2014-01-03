using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlannerWeb.App_Code.Base;
using System.Web.Security;

namespace PlannerWeb
{
    public partial class Default : PageBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if(Session["Name"] != null) BtnLogOut.Text = Session["Name"] + ", Salir";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ExecuteAction(this);
        }

        public void Search()
        {
            if (Session["Name"] != null) Response.Redirect("Orders.aspx?Svc=1&Acc=3&Ord=6");
            else Response.Redirect("ActiveOrders.aspx?Svc=1&Acc=3&Ord=6");
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();            
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}