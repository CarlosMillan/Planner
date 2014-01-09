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

            foreach(WorkShop W in C.F.Workshops)
            {
                HtmlWorkShops.AppendFormat("<option value='{0}'>{1}</option>", W.WorkSopId, W.Name);
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
                HtmlSituations.AppendFormat("<option value='{0}'>{1}</option>", S.StatusId, S.Name);
            }

            foreach (Asesor Asr in C.F.Asesors)
            {
                HtmlAsesors.AppendFormat("<option value='{0}'>{1}</option>", Asr.AsesorId, Asr.Name);
            }

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