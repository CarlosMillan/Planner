using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace General.Utils
{
    public class Users
    {
        private const string MatrizUsr = "matrizadmin";
        private const string CholulaUsr = "cholulaadmin";
        private const string BodyUsr = "bodyadmin";

        public Users(){}

        public string AssignAPIKey(string user)
        {            
            switch (user)
            {
                case MatrizUsr:
                    return ConfigurationManager.AppSettings["MatrizAPIKey"];

                case CholulaUsr:
                    return ConfigurationManager.AppSettings["CholulaAPIKey"];

                case BodyUsr:
                    return ConfigurationManager.AppSettings["BodyShopAPIKey"];

                default: return string.Empty;
            }   
        }

        public bool HasAcceess(string user, int workshop)
        {
            // Revisar General.DTOs.Filters.cs region de 'WorkShops' para ver correspondencia.

            if (user.Equals(MatrizUsr) && workshop == 1) return true;  

            if (user.Equals(CholulaUsr) && workshop == 2) return true;

            if (user.Equals(BodyUsr) && workshop == 5) return true;

            return false;
        }
    }
}
