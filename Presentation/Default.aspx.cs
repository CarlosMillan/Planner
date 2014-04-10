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
using General.Utils;

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
        public string Message;

        protected void Page_Init(object sender, EventArgs e)
        {
            if(Session["Name"] != null) BtnLogOut.Text = Session["Name"] + ", Salir";

            if (Request["NoDataFound"] == "True") Message = "No se encontraron  datos";
            else Message = String.Empty;
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
                if (Session["Name"] != null)
                { 
                    if(new Users().HasAcceess(Session["Name"].ToString(), W.WorkShopId))
                    {
                        HtmlWorkShops.AppendFormat("<option value='{0}'>{1}</option>", W.WorkShopId, W.Name);
                        break;
                    }
                }
                else HtmlWorkShops.AppendFormat("<option value='{0}'>{1}</option>", W.WorkShopId, W.Name);
            }

            foreach(Access A in C.F.AccessAs)
            {
                HtmlAccessAs.AppendFormat("<option value='{0}'>{1}</option>", A.AccessId, A.Name);
            }

            foreach (OrderType O in C.F.OrdersType)
            {
                HtmlOrderType.AppendFormat("<option {2} value='{0}'>{1}</option>", O.OrderTypeId, O.Name, O.isAll ? "isall='True'" : string.Empty);
            }

            foreach (Status S in C.F.Situations)
            {
                HtmlSituations.AppendFormat("<option value='{0}'>{0}</option>", S.Name);
            }

            foreach (Asesor Asr in C.F.Assesors)
            {                
                HtmlAsesors.AppendFormat("<option value='{0}' ws='{2}'>{1}</option>", Asr.AsesorId, Asr.Name, Asr.WorkShop);
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
            string URL = null;
            if (Request["SlcModule"].Equals("1")) URL = GenerateDatesURL();
            else URL = GenerateOrdersURL();

            return URL;
        }

        private string GenerateOrdersURL()
        {
            StringBuilder SearchingUrl = new StringBuilder();

            if (Session["Name"] != null) SearchingUrl.Append("Orders.aspx");
            else SearchingUrl.Append("ActiveOrders.aspx");

            SearchingUrl.AppendFormat("?Svc={0}&Acc={1}", Request["SlcService"], Request["SlcAccess"]);

            if (!Request["SlcOrder"].Equals("0")) SearchingUrl.AppendFormat("&Ord={0}{1}", Request["SlcOrder"], Convert.ToBoolean(Request["IsAll"]) ? "&IsAll=True" : string.Empty);
            else if (!Request["SlcStatus"].Equals("0")) SearchingUrl.AppendFormat("&Sts={0}", HttpContext.Current.Server.UrlEncode(Request["SlcStatus"]));
            else if (!Request["SlcAsesors"].Equals("0")) SearchingUrl.AppendFormat("&Asr={0}", Request["SlcAsesors"]);
            else if (Request["TxtOrder_Client_Plates"] != String.Empty) SearchingUrl.AppendFormat("&Ocp={0}", Request["TxtOrder_Client_Plates"]);

            return SearchingUrl.ToString();
        }

        private string GenerateDatesURL()
        {            
            return String.Concat("Dates.aspx?Svc=", Request["SlcService"]);
        }
    }
}