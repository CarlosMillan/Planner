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
        private static Filters F;
        private string ThirdParameter;

        protected void Page_Init(object seder, EventArgs e)
        {            
            if(Request["Acc"] == null || Request["Svc"] == null || !ThirdParameterIsValid())
               Response.Redirect("Default.aspx");

            F = new Filters();
            SelectFilters();
        }
            
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentPage = 1;            
        }

        #region WebMethod
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetPage(bool stop)
        {
            JavaScriptSerializer Json = new JavaScriptSerializer();             

            ActiveOrders CurrentPageData = ActiveOrdersController.GetActiveOrdersPage(CurrentPage, Int32.Parse(ConfigurationManager.AppSettings["Pagination"]), F);
            PageInfo Info = new PageInfo(CurrentPageData.TotalPages, CurrentPage, CurrentPageData.TotalOrders, GetHtmlTable(CurrentPageData));
            GetValidPage(CurrentPageData.TotalPages, stop);
           
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
                                        <td class='selected'></td>
                                        <td></td>
                                        <td></td>
                                        <td class='selected'></td>
                                        <td></td>
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
                                     O.DeliveryDays);
            }

            return Table.ToString();
        }

        private static void GetValidPage(int boundarypage, bool stop)
        {
            if (!stop)
            {
                if (CurrentPage >= boundarypage) CurrentPage = 1;
                else CurrentPage++;
            }
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
                F.Workshops.Find(svc => svc.WorkSopId == Int32.Parse(Request["Svc"])).IsSelected = true;
                F.AccessAs.Find(Acc => Acc.AccessId == Int32.Parse(Request["Acc"])).IsSelected = true;

                switch (ThirdParameter)
                { 
                    case "Ord":
                        F.OrdersType.Find(Ord => Ord.OrderTypeId == Int32.Parse(Request[ThirdParameter])).IsSelected = true;
                        break;

                    case "Sts":
                        F.Situations.Find(Sts => Sts.StatusId == Int32.Parse(Request[ThirdParameter])).IsSelected = true;
                        break;

                    case "Asr":
                        F.Asesors.Find(Asr => Asr.AsesorId == Int32.Parse(Request[ThirdParameter])).IsSelected = true;
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
        #endregion
    }
}