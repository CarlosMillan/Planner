using System;
using System.Collections.Generic;
using System.Linq;

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
        private int _total;

        public int Total
        {
            get {
                _total =  Range1 + Range2 + Range3 + Range4 + Range5 + Range6 + Range7 + Range8 + Range9;
                return _total;
            }
            set { _total = value; }
        }
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
        private int _total;

        public int Total
        {
            get
            {
                _total = Range1 + Range2 + Range3 + Range4 + Range5 + Range6 + Range7 + Range8 + Range9;
                return _total;
            }
            set { _total = value; }
        }
    }

    public class Assesor_Status
    {
        public string Status { get; set; }
        public List<int> Values { get; set; }
        public int Total 
        {
            get { return Values.Sum(); }
        }

        public Assesor_Status()
        {
            Values = new List<int>();
        }
    }

    public class Status_Order
    {
        public string Status { get; set; }
        public List<int> Values { get; set; }
        public int Total 
        {
            get { return Values.Sum(); }
        }

        public Status_Order()
        {
            Values = new List<int>();
        }
    }
}
