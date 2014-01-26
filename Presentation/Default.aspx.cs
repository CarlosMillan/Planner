using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlannerWeb.App_Code.Base;
using System.Web.Security;
using Business.Controllers;
using System.Text;
using General.DTOs.Classes;

namespace PlannerWeb
{
    public partial class Default : PageBase
    {
        public FiltersController C;
        public StringBuilder HtmlWorkShops;
        public StringBuilder HtmlAccessAs;
        public StringBuilder HtmlOrderType;
        public StringBuilder HtmlSituations;
        public StringBuilder HtmlAsesors;        

        protected void Page_Init(object sender, EventArgs e)
        {
            if(Session["Name"] != null) BtnLogOut.Text = Session["Name"] + ", Salir";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new FiltersController();
            HtmlWorkShops = new StringBuilder();
            HtmlAccessAs = new StringBuilder();
            HtmlOrderType = new StringBuilder();
            HtmlSituations = new StringBuilder();
            HtmlAsesors = new StringBuilder();

            foreach(WorkShop W in C.F.WorkShops)
            {
                HtmlWorkShops.AppendFormat("<option value='{0}'>{1}</option>", W.WorkShopId, W.Name);
            }

            foreach(Access A in C.F.AccessAs)
            {
                HtmlAccessAs.AppendFormat("<option value='{0}'>{1}</option>", A.AccessId, A.Name);
            }

            foreach (OrderType O in C.F.OrdersType)
            {
                HtmlOrderType.AppendFormat("<option value='{0}'>{1}</option>", O.OrderTypeId, O.Name);
            }

            foreach (Status S in C.F.Situations)
            {
                HtmlSituations.AppendFormat("<option value='{0}'>{0}</option>", S.Name);
            }

            foreach (Asesor Asr in C.F.Asesors)
            {                
                HtmlAsesors.AppendFormat("<option value='{0}'>{1}</option>", Asr.AsesorId, Asr.Name);
            }

            ExecuteAction(this);
        }

        public void Search()
        {            
            Response.Redirect(CreateURL());            
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();            
            FormsAuthentication.RedirectToLoginPage();
        }

        private string CreateURL() 
        {
            StringBuilder SearchingUrl = new StringBuilder();            

            if (Session["Name"] != null) SearchingUrl.Append("Orders.aspx");
            else SearchingUrl.Append("ActiveOrders.aspx");

            SearchingUrl.AppendFormat("?Svc={0}&Acc={1}", Request["SlcService"], Request["SlcAccess"]);

            if (Int32.Parse(Request["SlcOrder"]) != 0) SearchingUrl.AppendFormat("&Ord={0}", Request["SlcOrder"]);
            else if (!Request["SlcStatus"].Equals("0")) SearchingUrl.AppendFormat("&Sts={0}", HttpContext.Current.Server.UrlEncode(Request["SlcStatus"]));
            else if (!Request["SlcAsesors"].Equals("0")) SearchingUrl.AppendFormat("&Asr={0}", Request["SlcAsesors"]);
            else if (Request["TxtOrder_Client_Plates"] != String.Empty) SearchingUrl.AppendFormat("&Ocp={0}", Request["TxtOrder_Client_Plates"]);

            return SearchingUrl.ToString();
        }
    }
}