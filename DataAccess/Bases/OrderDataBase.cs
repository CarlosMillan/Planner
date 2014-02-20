using System;
using System.Collections.Generic;
using General.Utils;
using General.DTOs;
using General.Bases;
using DataAccess.General;
using System.Data;
using General.DTOs.Classes;
using General.Enums;
using System.Text;

namespace DataAccess.Bases
{
    public class OrderDataBase<OrdersType>
        where OrdersType : OrdersBase, new()
    {
        public OrderDataBase() { }

        public OrdersType GetOrders(string query, string filters, string service)
        {
            OrdersType Result = new OrdersType();

            try
            {                
                DataTable Orders = DataBaseManager.GetTable(query);
                Result.TotalOrders = (int)DataBaseManager.GetValue(new StringBuilder().AppendFormat(QueriesCatalog.GetTotalOrdres, filters, service).ToString());

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
                    NewOrder.Status = O["SITUATION"].ToString();
                    NewOrder.DeliveryDays = Convert.ToDateTime(Convert.ToDateTime(O["PROMISEDATE"].ToString()).ToShortDateString()).Subtract(Convert.ToDateTime(DateTime.Now.ToShortDateString())).Days;
                    NewOrder.CellPhone = O["CELLPHONE"].ToString();
                    NewOrder.PromiseDate = Convert.ToDateTime(O["PROMISEDATE"].ToString());
                    NewOrder.PromiseDate2 = Convert.ToDateTime(O["PROMISEDATE"].ToString());
                    NewOrder.Asessor = O["ASESSOR"].ToString();
                    Result.Orders.Add(NewOrder);
                }

            }
            catch { throw; }

            return Result;
        }

        public int GetTotalOrders(string query, string filters, string service, bool onlytotal)
        {
            int Result = 0;

            try
            {                
                Result = (int)DataBaseManager.GetValue(new StringBuilder().AppendFormat(QueriesCatalog.GetTotalOrdres, filters, service).ToString());
            }
            catch { throw; }

            return Result;
        }
    }
}
