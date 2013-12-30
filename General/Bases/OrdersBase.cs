using System;
using System.Collections.Generic;
using General.DTOs.Classes;

namespace General.Bases
{
    public abstract class OrdersBase
    {
        public List<Order> Orders;        
        public int TotalOrders {get; set; }
        public int TotalPages { get; set; }
        
        public OrdersBase()
        {
            Orders = new List<Order>();
            TotalOrders = 0;
        }
    }
}
