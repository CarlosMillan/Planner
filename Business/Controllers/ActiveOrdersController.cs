using System;
using General.DTOs.Classes;
using DataAccess.General;
using DataAccess;

namespace Business.Controllers
{
    public class ActiveOrdersController
    {        
        public ActiveOrdersController() {}

        public static ActiveOrders GetActiveOrdersPage(int pagenumber, int pagination, Filters filters)
        {
            return new ActiveOrdersData().GetOrdersPage(pagenumber, pagination, filters);
        }

        public static int GetTotalOrders(int pagenumber, int pagination, Filters filters, bool onlytotal)
        {
            return new ActiveOrdersData().GetTotalOrders(pagenumber, pagination, filters, onlytotal);
        }

        public static SummaryOrders GetSummaryOrders(bool first, Filters filters)
        {
            return new ActiveOrdersData().GetSummaryPage(first, filters);
        }
    }
}
