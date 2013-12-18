using System;
using System.Collections.Generic;
using General.General;

namespace General.Bases
{
    public abstract class OrdersBase
    {
        public List<Order> Orders;

        public OrdersBase()
        {
            Orders = new List<Order>();
        }
    }
}
