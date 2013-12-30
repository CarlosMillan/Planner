using System;
using DataAccess.Bases;
using General.DTOs.Classes;
using DataAccess.General;
using System.Text;

namespace DataAccess
{
    public class ActiveOrdersData : OrderDataBase<ActiveOrders>        
    {
        public ActiveOrdersData(){}

        public ActiveOrders GetOrdersPage(int pagenumber, int pagination)
        {
            try
            {
                StringBuilder FullQuery = new StringBuilder();
                FullQuery.AppendFormat(QueriesCatalog.GetActiveOrdersPage, pagenumber, pagination);
                ActiveOrders Current = base.GetOrders(FullQuery.ToString());
                Current.TotalPages = (int)Math.Ceiling((decimal)Current.TotalOrders / (decimal)pagination);
                return Current;
            }
            catch { throw; }
        }
    }
}
