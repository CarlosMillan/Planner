using System;
using Business.Bases;
using General.DTOs.Classes;
using DataAccess.General;
using DataAccess;

namespace Business.Controllers
{
    public class ActiveOrdersController : OrdersControllerBase<ActiveOrders>
    {
        public ActiveOrdersController()
        {
            try
            {
                _orders = new ActiveOrdersData().GetOrders();
            }
            catch { throw; }
        }
    }
}
