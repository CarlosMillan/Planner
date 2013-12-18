using System;
using System.Collections.Generic;
using General.Utils;
using General.DTOs;
using General.Bases;

namespace DataAccess
{
    public class OrdersData<OrdersType> 
        where OrdersType: OrdersBase
    {
        public OrdersData() { }

        public List<OrdersType> GetOrders()
        {
            DataBaseManager DB = new DataBaseManager();
            DB.GetTable("");


            return new List<OrdersType>();
        }
    }
}
