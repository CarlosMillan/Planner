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

        public static string GetTotalOrdres
        {
            get { return "SELECT COUNT(*) FROM ORDERS"; }
        }

        public static string GetActiveOrdersPage
        {
            get { return @"SELECT * 
                           FROM (SELECT ROW_NUMBER() OVER (ORDER BY P.Client DESC) AS rownum,P.* 
                                 FROM dbo.ORDERS AS P) OrderPage 
                           WHERE OrderPage.ROWNUM BETWEEN (({0}*{1})-{1}) + 1 AND ({0}*{1})"; }
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
