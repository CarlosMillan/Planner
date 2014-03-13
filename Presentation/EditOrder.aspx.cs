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
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

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
                string Message = Request["Sms"].ToString();
                JavaScriptSerializer json;
                
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
                        if (Regex.IsMatch(Message, @"^[A-Za-z,.0-9\s]+$"))
                        {
                            string urlcredito = "http://69.65.45.180/api.credito.new.php?";
                            string urlenviomensaje = "http://69.65.45.180/api.envio.new.php?";
                            Message = HttpContext.Current.Server.UrlEncode(Message);
                            string apikey = "72f0bf2f9876a56eaffac4bbcb8f05f1a065e844";
                            string postString = "apikey=" + apikey + "&mensaje=" + Message + "&numcelular=" + FinalPhone + "&numregion=" + ConfigurationManager.AppSettings["CountryCode"] + "";
                            const string contentType = "application/x-www-form-urlencoded";
                            System.Net.ServicePointManager.Expect100Continue = false;

                            CookieContainer cookies = new CookieContainer();
                            HttpWebRequest webRequest = WebRequest.Create(urlenviomensaje) as HttpWebRequest;
                            webRequest.Method = "POST";
                            webRequest.ContentType = contentType;
                            webRequest.CookieContainer = cookies;
                            webRequest.ContentLength = postString.Length;

                            StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                            requestWriter.Write(postString);
                            requestWriter.Close();

                            StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                            string responseData = responseReader.ReadToEnd();
                            responseReader.Close();
                            webRequest.GetResponse().Close();
                            string[] rs1 = responseData.Split(',');
                            string[] rs2 = rs1[1].Split(':');
                            SuccessMessage = rs2[1].Substring(1, rs2[1].Length - 2);
                        }
                        else SuccessMessage = "El mensaje solo puede tener letras (sin acento), números, puntos y comas.";
                    }
                }
            }
            catch (Exception E)
            {
                SuccessMessage = new StringBuilder().AppendFormat(@"Hubó un problema al enviar el mensaje.\n\rError: {0}", E.Message).ToString();
            }
        }
    }
}