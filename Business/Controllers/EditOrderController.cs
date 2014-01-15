using System;
using General.DTOs.Classes;
using General.Utils;

namespace Business.Controllers
{
    public class EditOrderController
    {
        public Order OrderToSave { get; set; }

        public EditOrderController()
        {
            OrderToSave = new Order();
        }

        public void SendMessage()
        {
            Messaging Sender = new Messaging();
            //TODO
        }
    }
}
