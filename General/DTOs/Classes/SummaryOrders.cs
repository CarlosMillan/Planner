using System;
using System.Collections.Generic;

namespace General.DTOs.Classes
{
    public class SummaryOrders
    {
        public List<Status_Days> Sd;
        public List<Assesor_Days> Ad;
        public List<Assesor_Status> As;
        public List<Status_Order> So;

        public SummaryOrders(bool first) 
        {
            if (first)
            {
                Sd = new List<Status_Days>();
                Ad = new List<Assesor_Days>();
                As = null;
                So = null;
            }
            else
            {
                As = new List<Assesor_Status>();
                So = new List<Status_Order>();
                Sd = null;
                Ad = null;
            }
        }
    }

    public class Status_Days
    {
        public string Status { get; set; }
        public int Range1 { get; set; }
        public int Range2 { get; set; }
        public int Range3 { get; set; }
        public int Range4 { get; set; }
        public int Range5 { get; set; }
        public int Range6 { get; set; }
        public int Range7 { get; set; }
        public int Range8 { get; set; }
        public int Range9 { get; set; }
        public int Total { get; set; }
    }

    public class Assesor_Days
    {
        public string Assesor { get; set; }
        public int Range1 { get; set; }
        public int Range2 { get; set; }
        public int Range3 { get; set; }
        public int Range4 { get; set; }
        public int Range5 { get; set; }
        public int Range6 { get; set; }
        public int Range7 { get; set; }
        public int Range8 { get; set; }
        public int Range9 { get; set; }
        public int Total { get; set; }
    }

    public class Assesor_Status
    {
        public string Status { get; set; }
        public string AssesorName1 { get; set; }
        public string AssesorName2 { get; set; }
        public string AssesorName3 { get; set; }
        public string AssesorName4 { get; set; }
        public string AssesorName5 { get; set; }
    }

    public class Status_Order
    {
        public string Status { get; set; }
        public string OrderName1 { get; set; }
    }
}
