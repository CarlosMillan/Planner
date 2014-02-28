using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlannerWeb.App_Code.Base;
using System.Web.Security;
using Business.Controllers;
using General.DTOs.Classes;
using System.Text;

namespace PlannerWeb
{
    public partial class OrdersWeb : PageBase
    {
        OrdersController C;
        public string HtmlTable;
        private static Filters F;
        private string ThirdParameter;
        private bool IsAll;
        private static string Svc;
        Orders Ords;
        public StringBuilder Path;

        protected void Page_Init(object sender, EventArgs e) 
        {
            if (Request["Action"] == null)
            {
                if (Request["Acc"] == null || Request["Svc"] == null || !ThirdParameterIsValid())
                    Response.Redirect("Default.aspx");

                IsAll = Convert.ToBoolean(Request["IsAll"]);                
                Svc = Request["Svc"];
                F = new Filters();
                SelectFilters();
                Path = new StringBuilder();
                C = new OrdersController();
                Ords = C.GetOrders(F);
                Path.AppendFormat("{0} > {1} > {2}", F.SelectedWorkShop.Name, F.SelectedAccess.Name, GetSelectedAccessOption());

                if (Ords.TotalOrders == 0)
                {
                    Response.Redirect("Default.aspx?NoDataFound=True");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlTable = string.Empty;
            ExecuteAction<OrdersWeb>(this);            
            HtmlTable = GetHtmlTable(Ords);
        }
        
        private static string GetHtmlTable(General.DTOs.Classes.Orders from)
        {
            StringBuilder Table = new StringBuilder();

            if (from != null)
            {
                foreach (Order O in from.Orders)
                {
                    Table.AppendFormat(@"<tr class={0}>
                                        <td>{1}</td>
                                        <td>{2}</td>
                                        <td>{3}</td>
                                        <td>{4}</td>                                        
                                        <td>{5}</td>
                                        <td>{6}</td>
                                        <td>{7}</td>
                                        <td class='highlight'>{8}</td>
                                        <td>{9}</td>
                                        <td class='{10}'>{11}</td>
                                        <td>{12}</td>
                                        <td>{13}</td>            
                                        <td><input type='button' value='SMS' /></td>
                                    </tr>",
                                         from.Orders.IndexOf(O) % 2 == 0 ? "pair" : "odd",
                                         O.OrderType,
                                         O.OrderNumber,
                                         O.EntryDate.ToShortDateString(),
                                         O.PromiseDate.ToShortDateString(),                                         
                                         O.Vehicle,
                                         O.Client,
                                         O.Plates,
                                         O.StayDays,
                                         O.Status,
                                         O.DeliveryDays < 0 ? "badhighlight" : "highlight",
                                         O.DeliveryDays,
                                         O.Asessor,
                                         O.CellPhone);
                }

            }
            return Table.ToString();
        }

        public void LogOut()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        #region Private
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

            if (counter != 1) return false;

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

        private string GetSelectedAccessOption()
        {
            if (F.SelectedAssesor != null) return F.SelectedAssesor.Name;
            else if (F.SelectedSituation != null) return F.SelectedSituation.Name;
            else if (F.SelectedOrdersType != null) return F.SelectedOrdersType.Name;
            else return F.SelectedOrderClientPlates;
        }
        #endregion
    }
}