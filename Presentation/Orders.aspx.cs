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

        protected void Page_Init(object sender, EventArgs e) 
        {
            if (Request["Acc"] == null || Request["Ord"] == null || Request["Svc"] == null)
                Response.Redirect("Default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlTable = string.Empty;
            ExecuteAction<OrdersWeb>(this);
            C = new OrdersController();
            HtmlTable = GetHtmlTable(C.GetOrders());
        }
        
        private static string GetHtmlTable(General.DTOs.Classes.Orders from)
        {
            StringBuilder Table = new StringBuilder();

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
                                        <td>{8}</td>
                                        <td class='highlight'>{9}</td>
                                        <td>{10}</td>
                                        <td class='{11}'>{12}</td>
                                        <td>{13}</td>
                                        <td>{14}</td>            
                                        <td><input type='button' value='Editar' /></td>
                                    </tr>",
                                     from.Orders.IndexOf(O) % 2 == 0 ? "pair" : "odd",
                                     O.OrderType,
                                     O.OrderNumber,
                                     O.EntryDate.ToShortDateString(),
                                     O.PromiseDate.ToShortDateString(),
                                     O.PromiseDate2.ToShortDateString(),                                     
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

            return Table.ToString();
        }

        public void LogOut()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}