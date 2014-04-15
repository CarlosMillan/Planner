using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.DTOs.Classes;
using DataAccess;

namespace Business.Controllers
{
    public class DatesController
    {
        public DatesController() { }

        public static Dates GetDates(int page, string service)
        {
            DatesData D = new DatesData();
            return D.GetDates(page, service);
        }

        public static int GetTotalDates(string service)
        {
            DatesData D = new DatesData();
            return D.GetTotalDates(service);
        }
    }
}
