using System;
using General.DTOs.Classes;
using DataAccess.General;
using DataAccess;

namespace Business.Controllers
{
    public class OrdersController
    {
        public OrdersController() { }

        public Orders GetOrders()
        {
            return new OrdersData().GetOrders();
        }
    }
}
