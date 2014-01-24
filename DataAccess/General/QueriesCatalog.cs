using System;
using General.Enums;

namespace DataAccess.General
{
    public class QueriesCatalog
    {                     
        #region Propierties        
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

        public static string GetOrders
        {
            get { return "SELECT * FROM ORDERS"; }
        }

        public static string GetSummaryStatusDays
        {
            get { return "select *, '30' Total from Summary1_1"; }
        }

        public static string GetSummaryAssesorDay
        {
            get { return "SELECT *, '333' Total FROM Summary1_2"; }
        }

        public static string GetSummaryAssesorStatus
        {
            get { return "SELECT *, '11' TOTAL FROM  Summary2_1"; }
        }

        public static string GetSummaryStatusOrder
        {
            get { return "SELECT *, '12' TOTAL FROM  Summary2_2"; }
        }
        #endregion
    }
}
