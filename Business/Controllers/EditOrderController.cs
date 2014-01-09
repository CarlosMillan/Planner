using System;
using General.DTOs.Classes;

namespace Business.Controllers
{
    public class EditOrderController
    {
        public Order OrderToSave { get; set; }

        public EditOrderController()
        {
            OrderToSave = new Order();
        }
    }
}
