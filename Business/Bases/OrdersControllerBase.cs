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
        private List<OrderType> _orders;
        #endregion

        #region Properties
        public List<OrderType> Orders 
        {
            get { return _orders; }
        }
        #endregion

        #region Public Methods
        public OrdersControllerBase() { }

        public void LoadOrders() 
        {
            _orders = new OrdersData<OrderType>().GetOrders();
        }

        public void GetSummary()
        { 
            //TODO
        }
        #endregion
    }
}
