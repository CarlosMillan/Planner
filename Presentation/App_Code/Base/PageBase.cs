using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General.Utils;
using System.Web.Security;
using System.Web.Configuration;
using System.Reflection;

namespace PlannerWeb.App_Code.Base
{
    public abstract class PageBase : Page
    {
        private string _action;

        public PageBase() {}
        
        public bool ExecuteAction<Presentation>(Presentation target) where Presentation : Page
        {
            /*
             * Executes a method in server side from client side with the Request.
             * In the HTML form must be a next structure (Must use a hidden type input):
             * <form id="FormID" method="POST">
             *      <input type="hidden" id="Action" name="Action" value="MethodName"/>
             *      ....more inputs....
             *      ....more inputs....
             * </form>
             */

            bool Executed = false;

            try
            {
                if (Request["Action"] != null)
                {
                    _action = Request["Action"];
                    MethodInfo MInfo = target.GetType().GetMethod(_action, BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod);

                    if (MInfo != null)
                    {
                        MInfo.Invoke(target, null);
                        Executed = true;
                    }
                }
            }
            catch{ throw; }

            return Executed;
        }    
    }
}