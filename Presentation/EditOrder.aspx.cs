using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Controllers;
using General.Enums;
using System.Configuration;
using PlannerWeb.App_Code.Base;
using System.Text.RegularExpressions;

namespace PlannerWeb
{
    public partial class EditOrder : PageBase
    {
        public string ReturnUrl;
        public EditOrderController C;
        public string SmsLength;
        public string SuccessMessage;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request["ReturnUrl"] == null) Response.Redirect("Default.aspx");
            else ReturnUrl = Request["ReturnUrl"];

            C = new EditOrderController();
            SmsLength = ConfigurationManager.AppSettings["SmsLength"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ExecuteAction(this))
            {
                C.OrderToSave.OrderType = Request["OrderType"];
                C.OrderToSave.OrderNumber = Request["OrderNum"];
                C.OrderToSave.EntryDate = Convert.ToDateTime(Request["EntryDate"] == null ? DateTime.Now.ToShortTimeString() : Request["EntryDate"]);
                C.OrderToSave.PromiseDate = Convert.ToDateTime(Request["PromiseDate"] == null ? DateTime.Now.ToShortTimeString() : Request["PromiseDate"]);
                //C.OrderToSave.PromiseDate2 = Convert.ToDateTime(Request["PromiseDate2"] == null ? DateTime.Now.ToShortTimeString() : Request["PromiseDate2"]);
                C.OrderToSave.Vehicle = Request["Vehicle"];
                C.OrderToSave.Client = Request["Client"];
                C.OrderToSave.Plates = Request["Plates"];
                C.OrderToSave.StayDays = Int32.Parse(Request["StayDays"] == null ? "0" : Request["StayDays"]);
                C.OrderToSave.Status = Request["Status"];
                C.OrderToSave.DeliveryDays = Int32.Parse(Request["DeliveryDays"] == null ? "0" : Request["DeliveryDays"]);
                C.OrderToSave.Asessor = Request["Asessor"];
                C.OrderToSave.CellPhone = Request["Cellphone"];
                C.OrderToSave.Sms = ConfigurationManager.AppSettings["SmsTxt"];
            }            
        }

        public void SendMessage()
        {
            try
            {
                string ClearPhone = string.Empty;
                string FinalPhone = string.Empty;

                if (Regex.IsMatch(Request["Phone"].ToString(), @"(?!\-|\s|\d|\(|\))."))
                {
                    SuccessMessage = "El télefono solo puede contener digitos, espacios, guiones y paréntesis.";
                }
                else
                {
                    ClearPhone = Regex.Replace(Request["Phone"].ToString(), @"(?!\d).", string.Empty);
                    FinalPhone = Regex.Match(ClearPhone, @"\d{10}$").Value;

                    if (FinalPhone.Length < 10)
                    {
                        SuccessMessage = "El número debe contener 10 digitos";
                    }
                    else
                    {
                        SMS.SmsGatewayPortClient Sender = new SMS.SmsGatewayPortClient("SmsGatewayApi");
                        SMS.Credentials Crd = new SMS.Credentials();
                        Crd.domainId = ConfigurationManager.AppSettings["DoaminIDSMS"];
                        Crd.login = ConfigurationManager.AppSettings["LoginSMS"];
                        Crd.passwd = ConfigurationManager.AppSettings["PasswordSMS"];
                        Sender.Open();

                        SMS.TextMessageRequest SMSRequest = new SMS.TextMessageRequest();
                        SMS.TextMessageResponse ResponseSMS = new SMS.TextMessageResponse();
                        SMS.TextMessage Msg = new SMS.TextMessage();
                        Msg.msg = Request["Sms"].ToString();
                        SMSRequest.credentials = Crd;
                        SMSRequest.destination = new string[] { String.Concat(ConfigurationManager.AppSettings["CountryCode"], FinalPhone) };
                        SMSRequest.message = Msg;
                        ResponseSMS = Sender.sendSms(SMSRequest);
                        Sender.Close();

                        if (ResponseSMS.status.Equals("000")) SuccessMessage = "Mensaje Enviado correctamente.";
                        else SuccessMessage = "El mensaje no fue enviado";
                    }
                }
            }
            catch (Exception E)
            {
                SuccessMessage = "Hubó un problema al enviar el mensaje.";
            }
        }
    }
}