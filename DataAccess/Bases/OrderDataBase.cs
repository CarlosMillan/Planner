using System;
using System.Collections.Generic;
using General.Utils;
using General.DTOs;
using General.Bases;
using DataAccess.General;
using System.Data;
using General.DTOs.Classes;
using General.Enums;

namespace DataAccess.Bases
{
    public class OrderDataBase<OrdersType>
        where OrdersType : OrdersBase, new()
    {
        public OrderDataBase() { }

        public OrdersType GetOrders(string query)
        {
            OrdersType Result = new OrdersType();

            try
            {
                DataTable Orders = DataBaseManager.GetTable(query);                
                Result.TotalOrders = (int)DataBaseManager.GetValue(QueriesCatalog.GetTotalOrdres);                
                
                foreach (DataRow O in Orders.Rows)
                {
                    Order NewOrder = new Order();
                    NewOrder.OrderType = O["ORDERTYPE"].ToString();
                    NewOrder.OrderNumber = O["ORDERNUMBER"].ToString();
                    NewOrder.EntryDate = Convert.ToDateTime(O["ORDERDATE"].ToString());
                    NewOrder.Client = O["CLIENT"].ToString();
                    NewOrder.Vehicle = O["VEHICLE"].ToString();
                    NewOrder.Plates = O["PLATES"].ToString();
                    NewOrder.StayDays = DateTime.Now.Subtract(NewOrder.EntryDate).Days;
                    NewOrder.Status = OrderStatus.QualityTesting;
                    NewOrder.DeliveryDays = Convert.ToDateTime(Convert.ToDateTime(O["PROMISEDATE"].ToString()).ToShortDateString()).Subtract(Convert.ToDateTime(DateTime.Now.ToShortDateString())).Days;
                    Result.Orders.Add(NewOrder);
                }

            }
            catch { throw; }

            return Result;
        }
    }
}
