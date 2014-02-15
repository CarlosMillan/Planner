using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Controllers;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using PlannerWeb.App_Code;
using General.DTOs.Classes;
using System.Configuration;
using System.Text;

namespace PlannerWeb
{
    public partial class ActiveOrdersPage : System.Web.UI.Page
    {        
        private static int CurrentPage;
        private static int TotalPages;
        private static int TotalOrders;
        private static Filters F;
        private string ThirdParameter;
        private static bool IsFirstSummary;
        public int Pagination;
        private bool IsAll;
        private static string Svc;
        public StringBuilder AsessorsHtml;
        public StringBuilder AsesorsHeadersHtml;
        public StringBuilder OrderTypeHeadersHtml;

        protected void Page_Init(object seder, EventArgs e)
        {
            if (Request["Acc"] == null || Request["Svc"] == null || !ThirdParameterIsValid())
               Response.Redirect("Default.aspx");

            Pagination = Int32.Parse(ConfigurationManager.AppSettings["Pagination"]);
            IsAll = Convert.ToBoolean(Request["IsAll"]);
            Svc = Request["Svc"];
            AsessorsHtml = new StringBuilder();
            AsesorsHeadersHtml = new StringBuilder();
            OrderTypeHeadersHtml = new StringBuilder();
            F = new Filters();
            SelectFilters();
            CurrentPage = 0;
            IsFirstSummary = true;
            GetHtmlAssesors();
            GetAsesorsHeaders();
            GetOrdersHeaders();
        }
            
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region WebMethod
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetPage(bool stop)
        {
            JavaScriptSerializer Json = new JavaScriptSerializer();
            PageInfo Info;

            if (!stop)
            {
                GetValidPage(stop);
                ActiveOrders CurrentPageData = ActiveOrdersController.GetActiveOrdersPage(CurrentPage, Int32.Parse(ConfigurationManager.AppSettings["Pagination"]), F);
                TotalPages = CurrentPageData.TotalPages + 2; // Por las dos páginas de resumen
                TotalOrders = CurrentPageData.TotalOrders;
                Info = new PageInfo(TotalPages, CurrentPage, TotalOrders, GetHtmlTable(CurrentPageData), IsNextPageSummary(stop));                
            }
            else Info = new PageInfo(TotalPages, CurrentPage, TotalOrders, null, IsNextPageSummary(stop)); 
            return Json.Serialize(Info);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetSummary(bool stop)
        {
            JavaScriptSerializer Json = new JavaScriptSerializer();
            PageInfo Info;

            if (!stop)
            {
                string HtmlSummary1;
                string HtmlSummary2;
                GetValidPage(stop);
                SummaryOrders Summary = ActiveOrdersController.GetSummaryOrders(IsFirstSummary, F);
                GetHtmlTable(Summary, out HtmlSummary1, out HtmlSummary2, IsFirstSummary);
                Info = new PageInfo(TotalPages, CurrentPage, TotalOrders, HtmlSummary1, HtmlSummary2, IsNextPageSummary(stop));
                IsFirstSummary = !IsFirstSummary;
            }
            else Info = new PageInfo(TotalPages, CurrentPage, TotalOrders, null, null, IsNextPageSummary(stop)); 

            return Json.Serialize(Info);
        }
        #endregion

        #region Private Methods
        private static string GetHtmlTable(ActiveOrders from)
        {
            StringBuilder Table = new StringBuilder();

            foreach (Order O in from.Orders)
            {
                Table.AppendFormat(@"<tr class='{0}'>
                                        <td>{1}</td>
                                        <td>{2}</td>
                                        <td>{3}</td>
                                        <td>{4}</td>
                                        <td>{5}</td>
                                        <td>{6}</td>
                                        <td class='highlight'>{7}</td>
                                        <td>{8}</td>
                                        <td class='{9}'>{10}</td>
                                        {11}
                                     </tr>",
                                     from.Orders.IndexOf(O) % 2 == 0 ? "pair" : "odd",
                                     O.OrderType,
                                     O.OrderNumber,
                                     O.EntryDate.ToShortDateString(),
                                     O.Client,
                                     O.Vehicle,
                                     O.Plates,
                                     O.StayDays,
                                     O.Status,
                                     O.DeliveryDays < 0 ? "badhighlight" : "highlight",
                                     O.DeliveryDays,
                                     MatchColumn(O.Asessor));
            }

            return Table.ToString();
        }

        private static void GetHtmlTable(SummaryOrders from, out string s1, out string s2, bool isfirstsummary)
        {
            StringBuilder Table = new StringBuilder();
            s1 = null;
            s2 = null;

            if (isfirstsummary)
            {
                if (from.Sd != null)
                {
                    foreach (var S in from.Sd)
                    {
                        Table.AppendFormat(@"<tr class='{0}'>
                                                <td class='rowtitle'>{1}</td>
                                                <td>{2}</td>
                                                <td>{3}</td>
                                                <td>{4}</td>
                                                <td>{5}</td>
                                                <td>{6}</td>
                                                <td>{7}</td>
                                                <td>{8}</td>
                                                <td>{9}</td>
                                                <td>{10}</td>
                                                <td>{11}</td>            
                                            </tr>",
                                            from.Sd.IndexOf(S) % 2 == 0 ? "pair" : "odd",
                                            S.Status,
                                            S.Range1,
                                            S.Range2,
                                            S.Range3,
                                            S.Range4,
                                            S.Range5,
                                            S.Range6,
                                            S.Range7,
                                            S.Range8,
                                            S.Range9,
                                            S.Total);
                    }

                    s1 = Table.ToString();
                }

                Table.Clear();

                if (from.Ad != null)
                {
                    foreach (var S in from.Ad)
                    {
                        Table.AppendFormat(@"<tr class='{0}'>
                                                <td class='rowtitle'>{1}</td>
                                                <td>{2}</td>
                                                <td>{3}</td>
                                                <td>{4}</td>
                                                <td>{5}</td>
                                                <td>{6}</td>
                                                <td>{7}</td>
                                                <td>{8}</td>
                                                <td>{9}</td>
                                                <td>{10}</td>
                                                <td>{11}</td>            
                                            </tr>",
                                                from.Ad.IndexOf(S) % 2 == 0 ? "pair" : "odd",
                                                S.Assesor,
                                                S.Range1,
                                                S.Range2,
                                                S.Range3,
                                                S.Range4,
                                                S.Range5,
                                                S.Range6,
                                                S.Range7,
                                                S.Range8,
                                                S.Range9,
                                                S.Total);
                    }

                    s2 = Table.ToString();
                }

            }
            else
            {
                if (from.As != null)
                {
                    foreach (var S in from.As)
                    {
                        Table.AppendFormat(@"<tr class='{0}'>
                                                <td class='rowtitle'>{1}</td>
                                                {2}
                                                <td>{3}</td>
                                            </tr>",
                                            from.As.IndexOf(S) % 2 == 0 ? "pair" : "odd",
                                            S.Status,
                                            GetValuesFromAsesor(S),
                                            S.Total);
                    }

                    s1 = Table.ToString();
                }

                Table.Clear();

                if (from.So != null)
                {
                    foreach (var S in from.So)
                    {
                        Table.AppendFormat(@"<tr class='{0}'>
                                                <td class='rowtitle'>{1}</td>
                                                {2}
                                                <td>{3}</td>
                                            </tr>",
                                            from.So.IndexOf(S) % 2 == 0 ? "pair" : "odd",
                                            S.Status,
                                            GetValuesFromOrder(S),
                                            S.Total);
                    }

                    s2 = Table.ToString();
                }
            }
        }

        private static void GetValidPage(bool stop)
        {
            if (!stop)
            {        
                CurrentPage++;

                if (CurrentPage > TotalPages) CurrentPage = 1;
            }
        }

        private static bool IsNextPageSummary(bool stop)
        {
            bool Response = false;

            if (!stop)
            {
                if(CurrentPage >= (TotalPages - 2) && CurrentPage < TotalPages) Response = true;               
            }

            return Response;
        }

        private bool ThirdParameterIsValid()
        {
            int counter = 0;

            if (Request["Ord"] != null)
            { 
                counter++;
                ThirdParameter = "Ord";
            }

            if (Request["Sts"] != null)
            { 
                counter++;
                ThirdParameter = "Sts";
            }

            if (Request["Asr"] != null)
            {
                counter++;
                ThirdParameter = "Asr";
            }

            if (Request["Ocp"] != null)
            {
                counter++;
                ThirdParameter = "Ocp";
            }

            if(counter != 1) return false;
                            
            return true;
        }

        private void SelectFilters()
        {
            try
            {
                F.WorkShops.Find(svc => svc.WorkShopId == Int32.Parse(Request["Svc"])).IsSelected = true;
                F.AccessAs.Find(Acc => Acc.AccessId == Int32.Parse(Request["Acc"])).IsSelected = true;

                switch (ThirdParameter)
                { 
                    case "Ord":
                        if (IsAll) 
                        { 
                            F.OrdersType.Find(Ord => Ord.OrderTypeId.Equals("Todo")).IsSelected = true;
                            F.OrdersType.Find(Ord => Ord.OrderTypeId.Equals("Todo")).OrderTypeId = Request[ThirdParameter];
                        }
                        else F.OrdersType.Find(Ord => Ord.OrderTypeId.Equals(Request[ThirdParameter])).IsSelected = true;

                        break;

                    case "Sts":
                        F.Situations.Find(Sts => Sts.Name.Equals(Request[ThirdParameter])).IsSelected = true;
                        break;

                    case "Asr":
                        F.Assesors.Find(Asr => Asr.AsesorId.Equals(Request[ThirdParameter])).IsSelected = true;
                        break;

                    case "Ocp":
                        F.OrderClientPlates = Request[ThirdParameter];
                        break;
                }
            }
            catch 
            {
                Response.Redirect("Default.aspx");
            }
        }

        private void GetHtmlAssesors()
        {
            switch (Svc)
            { 
                case "1":
                    foreach (Asesor A in F.Assesors.FindAll(Asr => Asr.WorkShop == 1))
                    {
                        AsessorsHtml.AppendFormat("<th style='padding-left:0;padding-right:0;width:65px;'>{0}</th>", A.AsesorId);                        
                    }
                    break;

                // Poner los CASE para los demas talleres
            }
        }

        private static string MatchColumn(string assesorid)
        { 
            StringBuilder Match = new StringBuilder();

            switch (Svc)
            {
                case "1":
                    foreach (Asesor A in F.Assesors.FindAll(Asr => Asr.WorkShop == 1))
                    {
                        if (A.AsesorId.Equals(assesorid.Trim())) Match.Append("<td class='selected'></td>");
                        else Match.Append("<td></td>");
                    }
                    break;

                // Poner los CASE para los demas talleres
            }

            return Match.ToString();
        }

        private static string GetValuesFromAsesor(Assesor_Status asr)
        {
            StringBuilder tds = new StringBuilder();

            foreach (var a in asr.Values)
            {
                tds.AppendFormat("<td>{0}</td>", a);
            }

            return tds.ToString();
        }

        private static string GetValuesFromOrder(Status_Order ord)
        {
            StringBuilder tds = new StringBuilder();

            foreach (var a in ord.Values)
            {
                tds.AppendFormat("<td>{0}</td>", a);
            }

            return tds.ToString();
        }

        private void GetAsesorsHeaders()
        {             
            foreach (var a in F.Assesors.FindAll(As => As.WorkShop == F.SeletedWorkShop.WorkShopId))
            {
                AsesorsHeadersHtml.AppendFormat("<th class='odd'>{0}</th>", a.AsesorId);
            }

            AsesorsHeadersHtml.Append("<th class='odd'>TOTAL</th>");
        }

        private void GetOrdersHeaders()
        {
            foreach (var o in F.OrdersType.FindAll(Or => !Or.OrderTypeId.Contains("_")))
            {
                OrderTypeHeadersHtml.AppendFormat("<th class='odd'>{0}</th>", o.OrderTypeId);
            }

            OrderTypeHeadersHtml.Append("<th class='odd'>TOTAL</th>");
        }
        #endregion
    }
}