using System;
using DataAccess.Bases;
using General.DTOs.Classes;
using DataAccess.General;

namespace DataAccess
{
    public class ActiveOrdersData : OrderDataBase<ActiveOrders>        
    {
        public ActiveOrdersData(){}

        public ActiveOrders GetOrders()
        {
            try
            {
                return base.GetOrders(QueriesCatalog.GetActiveOrders);
            }
            catch { throw; }
        }
    }
}
