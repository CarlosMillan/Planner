using System;
using System.Collections.Generic;
using DataAccess;
using General.Bases;

namespace Business.Bases
{
    public abstract class OrdersControllerBase<OrderType>
        where OrderType: OrdersBase
    {
        #region Fields
        protected OrderType _orders;        
        protected int _totalpages;        
        #endregion

        #region Properties
        public OrderType LoadedOrders 
        {
            get { return _orders; }
        }

        public int Pagination { get; set; }

        public int TotalOrders
        {
            get { return _orders.Orders.Count; }
        }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((double)_orders.Orders.Count / (double)Pagination); }
        }
        #endregion
        
        public OrdersControllerBase() { }
    }
}
