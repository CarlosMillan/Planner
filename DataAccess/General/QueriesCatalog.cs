using System;
using General.Enums;

namespace DataAccess.General
{
    public class QueriesCatalog
    {                     
        #region Propierties        
        public static string GetTotalOrdres
        {
            get
            {
                return @"SELECT COUNT(*)FROM Venta v, Art ar, Cte c
                             WHERE Mov = 'Servicio'
                             AND (v.Estatus = 'Pendiente' OR v.Estatus = 'Sinafectar')
                             and v.ServicioArticulo = ar.Articulo
                             and C.Cliente = v.Cliente";
            }
        }

        public static string GetActiveOrdersPage
        {
            get {
                return @"SELECT *
                         FROM (SELECT ROW_NUMBER() OVER (ORDER BY V.FECHAEMISION ASC) AS ROWNUM, V.[MOVID] ORDERNUMBER
                                                                                                ,AR.DESCRIPCION1 VEHICLE
                                                                                                ,C.NOMBRE CLIENT
                                                                                                ,V.[FECHAEMISION]
                                                                                                ,V.[SITUACION] CELLPHONE
                                                                                                ,V.[ESTATUS] 
                                                                                                ,V.[FECHAREQUERIDA] PROMISEDATE
                                                                                                ,V.[SERVICIOSERIE]
                                                                                                ,V.[SERVICIOIDENTIFICADOR]
                                                                                                ,V.[SERVICIOPLACAS] PLATES
                                                                                                ,V.[SERVICIOTIPOORDEN] ORDERTYPE
                                                                                                ,V.[SERVICIOTIPOOPERACION] ASESSOR
                             FROM VENTA V, ART AR, CTE C
	                         WHERE MOV = 'SERVICIO' 
	                         AND (V.ESTATUS = 'PENDIENTE' OR V.ESTATUS = 'SINAFECTAR') 
	                         AND V.SERVICIOARTICULO = AR.ARTICULO
	                         AND C.CLIENTE = V.CLIENTE
                             {2}) ORDERPAGE
                        WHERE ORDERPAGE.ROWNUM BETWEEN (({0}*{1})-{1}) + 1 AND ({0}*{1})";
            }
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
