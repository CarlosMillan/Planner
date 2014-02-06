using System;
using DataAccess.Bases;
using General.DTOs.Classes;
using DataAccess.General;
using System.Text;
using System.Data;
using General.Utils;

namespace DataAccess
{
    public class ActiveOrdersData : OrderDataBase<ActiveOrders>        
    {
        public ActiveOrdersData(){}

        public ActiveOrders GetOrdersPage(int pagenumber, int pagination, Filters filters)
        {
            try
            {
                ActiveOrders Current = base.GetOrders(BuildQuery(pagenumber, pagination, filters), GetFilterQuery(filters));
                Current.TotalPages = (int)Math.Ceiling((decimal)Current.TotalOrders / (decimal)pagination);
                return Current;
            }
            catch { throw; }
        }

        public SummaryOrders GetSummaryPage(bool first)
        {
            StringBuilder FullQuery1 = new StringBuilder();
            StringBuilder FullQuery2 = new StringBuilder();
            SummaryOrders Summary = new SummaryOrders(first);
            DataTable SummaryTable = new DataTable();            

            if (first)
            {
                FullQuery1.AppendFormat(QueriesCatalog.GetSummaryStatusDays);
                FullQuery2.AppendFormat(QueriesCatalog.GetSummaryAssesorDay);
                SummaryTable = DataBaseManager.GetTable(FullQuery1.ToString());

                foreach(DataRow S in SummaryTable.Rows)
                {
                    Summary.Sd.Add(new Status_Days() { 
                        Status = S["STATUS"].ToString(),
                        Range1 = Int32.Parse(S["RANGE1"].ToString()),
                        Range2 = Int32.Parse(S["RANGE2"].ToString()),
                        Range3 = Int32.Parse(S["RANGE3"].ToString()),
                        Range4 = Int32.Parse(S["RANGE4"].ToString()),
                        Range5 = Int32.Parse(S["RANGE5"].ToString()),
                        Range6 = Int32.Parse(S["RANGE6"].ToString()),
                        Range7 = Int32.Parse(S["RANGE7"].ToString()),
                        Range8 = Int32.Parse(S["RANGE8"].ToString()),
                        Range9 = Int32.Parse(S["RANGE9"].ToString()),
                        Total = Int32.Parse(S["TOTAL"].ToString())
                    });
                }

                SummaryTable = DataBaseManager.GetTable(FullQuery2.ToString());

                foreach (DataRow S in SummaryTable.Rows)
                {
                    Summary.Ad.Add(new Assesor_Days()
                    {
                        Assesor = S["ASSESOR"].ToString(),
                        Range1 = Int32.Parse(S["RANGE1"].ToString()),
                        Range2 = Int32.Parse(S["RANGE2"].ToString()),
                        Range3 = Int32.Parse(S["RANGE3"].ToString()),
                        Range4 = Int32.Parse(S["RANGE4"].ToString()),
                        Range5 = Int32.Parse(S["RANGE5"].ToString()),
                        Range6 = Int32.Parse(S["RANGE6"].ToString()),                        
                        Range8 = Int32.Parse(S["RANGE8"].ToString()),
                        Range9 = Int32.Parse(S["RANGE9"].ToString()),
                        Total = Int32.Parse(S["TOTAL"].ToString())
                    });
                }
            }
            else 
            {
                FullQuery1.AppendFormat(QueriesCatalog.GetSummaryAssesorStatus);
                FullQuery2.AppendFormat(QueriesCatalog.GetSummaryStatusOrder);
                SummaryTable = DataBaseManager.GetTable(FullQuery1.ToString());

                foreach (DataRow S in SummaryTable.Rows)
                {
                    Summary.As.Add(new Assesor_Status()
                    {
                        Status = S["STATUS"].ToString(),
                        AssesorName1 = S["AssesorName1"].ToString(),
                        AssesorName2 = S["AssesorName2"].ToString(),
                        AssesorName3 = S["AssesorName3"].ToString(),
                        AssesorName4 = S["AssesorName4"].ToString(),
                        AssesorName5 = S["AssesorName5"].ToString()                        
                    });
                }

                SummaryTable = DataBaseManager.GetTable(FullQuery2.ToString());

                foreach (DataRow S in SummaryTable.Rows)
                {
                    Summary.So.Add(new Status_Order()
                    {
                        Status = S["STATUS"].ToString(),
                        OrderName1 = S["ORDERNAME"].ToString()
                    });
                }
            }

            return Summary;
        }
 
        private string BuildQuery(int pagenumber, int pagination, Filters tobuild)
        {
            StringBuilder Query = new StringBuilder();
            Query.AppendFormat(QueriesCatalog.GetActiveOrdersPage, pagenumber, pagination, GetFilterQuery(tobuild), GetServiceTypeQuery(tobuild));
            return Query.ToString();
        }

        private string GetFilterQuery(Filters tobuild)
        { 
            StringBuilder FiltersString = new StringBuilder();
            FiltersString.AppendFormat(@"AND SUCURSAL = '{0}'{1}{2}{3}{4}",
                                         tobuild.SeletedWorkShop.WorkShopId,
                /*Taller*/tobuild.SelectedAccess.AccessId == 1 ? GetOrderType(tobuild.SelectedOrdersType.OrderTypeId) : string.Empty,
                /*Asesor*/tobuild.SelectedAccess.AccessId == 2 ? String.Concat("AND V.AGENTE = '", tobuild.SelectedAssesor.AsesorId, "'") : string.Empty,
                /*Situación*/tobuild.SelectedAccess.AccessId == 3 ? String.Concat("AND V.SITUACION = '", tobuild.SelectedSituation.Name, "'") : string.Empty,
                /*Orden,Nombre,Placas*/tobuild.SelectedAccess.AccessId == 4 ? String.Concat("AND (V.MOVID LIKE '%", tobuild.SelectedOrderClientPlates, "%' OR C.NOMBRE LIKE '%", tobuild.SelectedOrderClientPlates, "%' OR V.SERVICIOPLACAS LIKE '%", tobuild.SelectedOrderClientPlates, "%')") : string.Empty);

            return FiltersString.ToString();
        }

        private string GetOrderType(string selectedorders)
        {            
            string[] SplitFromOrder = selectedorders.Split('_');
            StringBuilder OrderFilter = new StringBuilder();

            if (SplitFromOrder.Length > 1)
            {
                if (SplitFromOrder[1].Equals("Garantias"))
                {
                    OrderFilter.AppendFormat("AND V.SERVICIOTIPOORDEN = '{0}'", SplitFromOrder[0]);
                }
                else
                {
                    OrderFilter.AppendFormat("AND (V.SERVICIOTIPOORDEN = '{0}' OR V.SERVICIOTIPOORDEN = '{1}')", SplitFromOrder[0], SplitFromOrder[1]);
                }
            }
            else if (!selectedorders.Equals("Garantias"))
            {
                OrderFilter.AppendFormat("AND V.SERVICIOTIPOORDEN = '{0}'", SplitFromOrder[0]);
            }

            return OrderFilter.ToString();
        }

        private string GetServiceTypeQuery(Filters tobuild)
        {
            StringBuilder OrderFilter = new StringBuilder();

            if (tobuild.SelectedOrdersType != null)
            {
                string[] SplitFromOrder = tobuild.SelectedOrdersType.OrderTypeId.Split('_');

                if (SplitFromOrder.Length > 1)
                {
                    if (!SplitFromOrder[1].Equals("Garantia"))
                    {
                        OrderFilter.Append("MOV = 'Servicio'");
                    }
                    else
                    {
                        OrderFilter.Append("(MOV = 'Servicio' OR MOV = 'Servicio Garantia')");
                    }
                }
                else if (tobuild.SelectedOrdersType.OrderTypeId.Equals("Garantia"))
                {
                    OrderFilter.Append("MOV = 'Servicio Garantia'");
                }
                else OrderFilter.Append("MOV = 'Servicio'");
            }
            else OrderFilter.Append("(MOV = 'Servicio' OR MOV = 'Servicio Garantia')");

            return OrderFilter.ToString();
        }
    }
}
