using System;
using DataAccess.Bases;
using General.DTOs.Classes;
using DataAccess.General;
using System.Text;

namespace DataAccess
{
    public class OrdersData : OrderDataBase<Orders>
    {
        public OrdersData(){}

        public Orders GetOrders()
        {
            try
            {
                StringBuilder FullQuery = new StringBuilder();
                FullQuery.Append(QueriesCatalog.GetOrders);
                Orders Current = base.GetOrders(FullQuery.ToString());                
                return Current;
            }
            catch { throw; }
        }
    }
}
