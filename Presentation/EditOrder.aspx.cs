using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Controllers;
using General.Enums;
using System.Configuration;

namespace PlannerWeb
{
    public partial class EditOrder : System.Web.UI.Page
    {
        public string ReturnUrl;
        public EditOrderController C;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request["ReturnUrl"] == null) Response.Redirect("Default.aspx");
            else ReturnUrl = Request["ReturnUrl"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            C = new EditOrderController();

            C.OrderToSave.OrderType = Request["OrderType"];
            C.OrderToSave.OrderNumber = Request["OrderNum"];
            C.OrderToSave.EntryDate = Convert.ToDateTime(Request["EntryDate"] == null ? DateTime.Now.ToShortTimeString() : Request["EntryDate"]);
            C.OrderToSave.PromiseDate = Convert.ToDateTime(Request["PromiseDate"] == null ? DateTime.Now.ToShortTimeString() : Request["PromiseDate"]);
            C.OrderToSave.PromiseDate2 = Convert.ToDateTime(Request["PromiseDate2"] == null ? DateTime.Now.ToShortTimeString() : Request["PromiseDate2"]);
            C.OrderToSave.Vehicle = Request["Vehicle"];
            C.OrderToSave.Client = Request["Client"];
            C.OrderToSave.Plates = Request["Plates"];
            C.OrderToSave.StayDays = Int32.Parse(Request["StayDays"] == null ? "0" : Request["StayDays"]);
            C.OrderToSave.Status = OrderStatus.QualityTesting; // Request["Status"];
            C.OrderToSave.DeliveryDays = Int32.Parse(Request["DeliveryDays"] == null ? "0" : Request["DeliveryDays"]);
            C.OrderToSave.Asessor = Request["Asessor"];
            C.OrderToSave.CellPhone = Request["Cellphone"];
            C.OrderToSave.Sms = ConfigurationManager.AppSettings["SmsTxt"];
        }
    }
}