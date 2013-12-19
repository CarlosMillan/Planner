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
        #endregion

        #region Properties
        public OrderType LoadedOrders 
        {
            get { return _orders; }
        }
        #endregion

        #region Public Methods
        public OrdersControllerBase() { }        

        public void GetSummary()
        { 
            //TODO
        }
        #endregion
    }
}
