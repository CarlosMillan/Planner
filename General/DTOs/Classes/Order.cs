using System;
using General.Enums;

namespace General.DTOs.Classes
{
    public class Order
    {
        #region Propierties
        public string OrderType { get; set; }
        public string OrderNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public string Client { get; set; }
        public string Vehicle { get; set; }
        public string Plates { get; set; }
        public int StayDays { get; set; }
        public OrderStatus Status { get; set; }
        public int DeliveryDays { get; set; }
        #endregion

        public Order(){ }
    }
}
