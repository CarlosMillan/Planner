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
                return @"SELECT COUNT(*) FROM VENTA V, ART AR, CTE C
                             WHERE MOV = 'SERVICIO'
                             AND (V.ESTATUS = 'PENDIENTE' OR V.ESTATUS = 'SINAFECTAR')
                             AND V.SERVICIOARTICULO = AR.ARTICULO
                             AND C.CLIENTE = V.CLIENTE
                             {0}";
            }
        }

        public static string GetActiveOrdersPage
        {
            get {
                return @"SELECT *
                         FROM (SELECT ROW_NUMBER() OVER (ORDER BY V.FECHAEMISION ASC) AS ROWNUM, v.[MovID] ORDERNUMBER
																								,ar.Descripcion1 VEHICLE
																								,v.Agente ASESSOR
                                                                                                ,c.Nombre CLIENT
																								,c.PersonalTelefonoMovil CELLPHONE
                                                                                                ,v.[FechaEmision] ORDERDATE
                                                                                                ,v.[Situacion] SITUATION
                                                                                                ,v.[FechaRequerida] PROMISEDATE
                                                                                                ,v.[ServicioSerie]
                                                                                                ,v.[ServicioIdentificador]
                                                                                                ,v.[ServicioPlacas] PLATES
                                                                                                ,v.[ServicioTipoOrden] ORDERTYPE
                                                                                                ,v.[ServicioTipoOperacion] 
                             FROM VENTA V, ART AR, CTE C
	                         WHERE {3} 
	                         AND V.ESTATUS = 'PENDIENTE' 
	                         AND V.SERVICIOARTICULO = AR.ARTICULO
	                         AND C.CLIENTE = V.CLIENTE
                             {2}) ORDERPAGE
                        WHERE ORDERPAGE.ROWNUM BETWEEN (({0}*{1})-{1}) + 1 AND ({0}*{1})";
            }
        }

        public static string GetOrders
        {
            get {
                return @"SELECT v.[MovID] ORDERNUMBER
								,ar.Descripcion1 VEHICLE
								,v.Agente ASESSOR
                                ,c.Nombre CLIENT
								,c.PersonalTelefonoMovil CELLPHONE
                                ,v.[FechaEmision] ORDERDATE
                                ,v.[Situacion] SITUATION
                                ,v.[FechaRequerida] PROMISEDATE
                                ,v.[ServicioSerie]
                                ,v.[ServicioIdentificador]
                                ,v.[ServicioPlacas] PLATES
                                ,v.[ServicioTipoOrden] ORDERTYPE
                                ,v.[ServicioTipoOperacion] 
                             FROM VENTA V, ART AR, CTE C
	                         WHERE MOV = 'SERVICIO' 
	                         AND (V.ESTATUS = 'PENDIENTE' OR V.ESTATUS = 'SINAFECTAR') 
	                         AND V.SERVICIOARTICULO = AR.ARTICULO
	                         AND C.CLIENTE = V.CLIENTE
                            {0}"; 
            }
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
