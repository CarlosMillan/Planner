using System;
using General.Enums;

namespace DataAccess.General
{
    public class QueriesCatalog
    {                     
        #region Propierties
        public static string ValidateUser
        {
            get { return "SELECT [User_Id] FROM Users WHERE [User_Id] = '{0}' AND Rol_Id = '{1}' "; }
        }

        public static string GetActiveOrders
        {
            get { return "select * from orders"; }
        }
        #endregion

        #region Public Methods
        public static string GetDataQuery(OrderType type)
        {
            switch(type)
            {
                case OrderType.Active:
                    return "";
                case OrderType.Stopped:
                    return "";
                default: return "";
            }
        }
        #endregion
    }
}
