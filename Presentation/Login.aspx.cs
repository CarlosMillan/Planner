using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General.Utils;
using System.Web.Security;
using System.Web.Configuration;
using PlannerWeb.App_Code.Base;

namespace PlannerWeb
{
    public partial class Login :  PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Login";
            ExecuteAction(this);
        }

        public void UserLogIn()
        {            
            if (FormsAuthentication.Authenticate(TxtName.Value, TxtPassword.Value))
            {
               Session["Name"] = TxtName.Value;
               FormsAuthentication.SetAuthCookie(TxtName.Value, true);
               Response.Redirect("Default.aspx", true); 
            }            
        }
    }
}