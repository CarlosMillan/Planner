using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General.Utils;

namespace PlannerWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Login";
            DataBaseManager db = new DataBaseManager();
            db.GetTable("Users");
        }
    }
}