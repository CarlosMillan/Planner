using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Controllers;

namespace PlannerWeb
{
    public partial class ActiveOrders : System.Web.UI.Page
    {
        public ActiveOrdersController C;
        public string Errors;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                C = new ActiveOrdersController();                
            }
            catch (Exception E)
            {
                Errors = E.Message;
            }
        }
    }
}