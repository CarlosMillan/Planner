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

        public static Dates GetDates(int page)
        {
            DatesData D = new DatesData();
            return D.GetDates(page);
        }
    }
}
