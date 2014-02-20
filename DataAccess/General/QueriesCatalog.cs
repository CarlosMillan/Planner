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
                             WHERE {1}
                             AND V.ESTATUS = 'PENDIENTE'
                             AND V.SERVICIOARTICULO = AR.ARTICULO
                             AND C.CLIENTE = V.CLIENTE
                             {0}";

                /*DEJAR TEMPORALEMNTE*/
                //return @"select count(*) from orders v";
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

/*DEJAR TEMPORALEMNTE*/
//                return @"select [SERVICIOTIPOORDEN] ORDERTYPE
//                        ,[OrderNumber] ORDERNUMBER
//                        ,[OrderDate] ORDERDATE
//                        ,[Client] CLIENT
//                        ,[Vehicle] VEHICLE
//                        ,[Plates] PLATES
//                        ,[PromiseDate] PROMISEDATE
//                        ,[Situacion] SITUATION
//                        ,[CellPhone] CELLPHONE
//                        ,[Agente] ASESSOR
//                        from orders v";
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
	                         WHERE {1}
	                         AND V.ESTATUS = 'PENDIENTE'
	                         AND V.SERVICIOARTICULO = AR.ARTICULO
	                         AND C.CLIENTE = V.CLIENTE
                             {0}"; 
            }
        }

        public static string GetSummaryStatusDays
        {
            get {
                return @"select [Situacion],
	                        COUNT(case Menor6 when 1 then Menor6 else null end) Menor6,
	                        COUNT(case Menor3_5 when 1 then Menor3_5 else null end) Menor3_5,
	                        COUNT(case Menor2_1 when 1 then Menor2_1 else null end) Menor2_1,
	                        COUNT(case Hoy when 1 then Hoy else null end) Hoy,
	                        COUNT(case Mayor1_3 when 1 then Mayor1_3 else null end) Mayor1_3,
	                        COUNT(case Mayor4_8 when 1 then Mayor4_8 else null end) Mayor4_8,
	                        COUNT(case Mayor9_20 when 1 then Mayor9_20 else null end) Mayor9_20,
	                        COUNT(case Mayor21_30 when 1 then Mayor21_30 else null end) Mayor21_30,
	                        COUNT(case Mayor31 when 1 then Mayor31 else null end) Mayor31	
                        from (select v.[Situacion],
	                        case when datediff(DD, getDate(), v.[FechaRequerida]) <= -6 then 1 else 0 end Menor6,
	                        case when datediff(DD, getDate(), v.[FechaRequerida]) <= -3 and datediff(DD, getDate(), v.[FechaRequerida]) >= -5 then 1 else 0 end Menor3_5,
	                        case when datediff(DD, getDate(), v.[FechaRequerida]) <= -1 and datediff(DD, getDate(), v.[FechaRequerida]) >= -2 then 1 else 0 end Menor2_1,
	                        case when datediff(DD, getdate(), v.FechaRequerida) = 0 then 1 else 0 end Hoy,
	                        case when datediff(DD, getDate(), v.[FechaRequerida]) >= 1 and datediff(DD, getDate(), v.[FechaRequerida]) <= 3 then 1 else 0 end Mayor1_3,
	                        case when datediff(DD, getDate(), v.[FechaRequerida]) >= 4 and datediff(DD, getDate(), v.[FechaRequerida]) <= 8 then 1 else 0 end Mayor4_8,
	                        case when datediff(DD, getDate(), v.[FechaRequerida]) >= 9 and datediff(DD, getDate(), v.[FechaRequerida]) <= 20 then 1 else 0 end Mayor9_20,
	                        case when datediff(DD, getDate(), v.[FechaRequerida]) >= 21 and datediff(DD, getDate(), v.[FechaRequerida]) <= 30 then 1 else 0 end Mayor21_30,
	                        case when datediff(DD, getDate(), v.[FechaRequerida]) >= 31 then 1 else 0 end Mayor31	
                        from Venta V, ART AR, CTE C
                        where {1} {0}
                        AND V.ESTATUS = 'PENDIENTE'
                        AND V.SERVICIOARTICULO = AR.ARTICULO
                        AND C.CLIENTE = V.CLIENTE
                        AND v.[Situacion] IS NOT NULL) summary
                        group by [Situacion]";
            }
        }

        public static string GetSummaryAssesorDay
        {
            get
            {
                return @"select Agente,
	                            COUNT(case Menor6 when 1 then Menor6 else null end) Menor6,
	                            COUNT(case Menor3_5 when 1 then Menor3_5 else null end) Menor3_5,
	                            COUNT(case Menor2_1 when 1 then Menor2_1 else null end) Menor2_1,
	                            COUNT(case Hoy when 1 then Hoy else null end) Hoy,
	                            COUNT(case Mayor1_3 when 1 then Mayor1_3 else null end) Mayor1_3,
	                            COUNT(case Mayor4_8 when 1 then Mayor4_8 else null end) Mayor4_8,
	                            COUNT(case Mayor9_20 when 1 then Mayor9_20 else null end) Mayor9_20,
	                            COUNT(case Mayor21_30 when 1 then Mayor21_30 else null end) Mayor21_30,
	                            COUNT(case Mayor31 when 1 then Mayor31 else null end) Mayor31	
                            from (select v.Agente,
	                            case when datediff(DD, getDate(), v.[FechaRequerida]) <= -6 then 1 else 0 end Menor6,
	                            case when datediff(DD, getDate(), v.[FechaRequerida]) <= -3 and datediff(DD, getDate(), v.[FechaRequerida]) >= -5 then 1 else 0 end Menor3_5,
	                            case when datediff(DD, getDate(), v.[FechaRequerida]) <= -1 and datediff(DD, getDate(), v.[FechaRequerida]) >= -2 then 1 else 0 end Menor2_1,
	                            case when datediff(DD, getdate(), v.FechaRequerida) = 0 then 1 else 0 end Hoy,
	                            case when datediff(DD, getDate(), v.[FechaRequerida]) >= 1 and datediff(DD, getDate(), v.[FechaRequerida]) <= 3 then 1 else 0 end Mayor1_3,
	                            case when datediff(DD, getDate(), v.[FechaRequerida]) >= 4 and datediff(DD, getDate(), v.[FechaRequerida]) <= 8 then 1 else 0 end Mayor4_8,
	                            case when datediff(DD, getDate(), v.[FechaRequerida]) >= 9 and datediff(DD, getDate(), v.[FechaRequerida]) <= 20 then 1 else 0 end Mayor9_20,
	                            case when datediff(DD, getDate(), v.[FechaRequerida]) >= 21 and datediff(DD, getDate(), v.[FechaRequerida]) <= 30 then 1 else 0 end Mayor21_30,
	                            case when datediff(DD, getDate(), v.[FechaRequerida]) >= 31 then 1 else 0 end Mayor31	
                            from Venta V, ART AR, CTE C
                            where {1} {0}
                            AND V.ESTATUS = 'PENDIENTE'
                            AND V.SERVICIOARTICULO = AR.ARTICULO
                            AND C.CLIENTE = V.CLIENTE) summary
                            group by Agente";
            }
        }

        public static string GetSummaryAssesorStatus
        {
            get {
                return @"SELECT [SITUACION],
                	        {0}
                        FROM (SELECT V.[SITUACION],
                	        {1}
                        FROM VENTA V, ART AR, CTE C
                        WHERE
                        {2}
                        {3}
                        AND SITUACION IS NOT NULL
                        AND V.ESTATUS = 'PENDIENTE'
                        AND V.SERVICIOARTICULO = AR.ARTICULO
                        AND C.CLIENTE = V.CLIENTE) SUMMARY
                        GROUP BY [SITUACION]"; 
            }
        }

        public static string GetSummaryStatusOrder
        {
            get {
                return @"SELECT [SITUACION],
                	        {0}
                        FROM (SELECT V.[SITUACION],
                	        {1}
                        FROM VENTA V, ART AR, CTE C
                        WHERE                     
                        {2}
                        {3}
                        AND SITUACION IS NOT NULL
                        AND V.ESTATUS = 'PENDIENTE'
                        AND V.SERVICIOARTICULO = AR.ARTICULO
                        AND C.CLIENTE = V.CLIENTE) SUMMARY
                        GROUP BY [SITUACION]"; 
            }
        }
        #endregion
    }
}
