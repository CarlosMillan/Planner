using System;
using DataAccess.Bases;
using General.DTOs.Classes;
using DataAccess.General;
using System.Text;
using System.Data;
using General.Utils;
using System.Linq;

namespace DataAccess
{
    public class ActiveOrdersData : OrderDataBase<ActiveOrders>        
    {
        public ActiveOrdersData(){}

        public ActiveOrders GetOrdersPage(int pagenumber, int pagination, Filters filters)
        {
            try
            {
                ActiveOrders Current = base.GetOrders(BuildQuery(pagenumber, pagination, filters), GetFilterQuery(filters), GetServiceTypeQuery(filters));
                Current.TotalPages = (int)Math.Ceiling((decimal)Current.TotalOrders / (decimal)pagination);
                return Current;
            }
            catch { throw; }
        }

        public int GetTotalOrders(int pagenumber, int pagination, Filters filters, bool onlytotal)
        {
            try
            {
                return base.GetTotalOrders(BuildQuery(pagenumber, pagination, filters), GetFilterQuery(filters), GetServiceTypeQuery(filters), onlytotal);                                
            }
            catch { throw; }
        }

        public SummaryOrders GetSummaryPage(bool first, Filters filters)
        {
            StringBuilder FullQuery1 = new StringBuilder();
            StringBuilder FullQuery2 = new StringBuilder();
            SummaryOrders Summary = new SummaryOrders(first);
            DataTable SummaryTable = new DataTable();

            if (first)            
            {
                FullQuery1.AppendFormat(QueriesCatalog.GetSummaryStatusDays, GetFilterQuery(filters), GetServiceTypeQuery(filters));
                FullQuery2.AppendFormat(QueriesCatalog.GetSummaryAssesorDay, GetFilterQuery(filters), GetServiceTypeQuery(filters));
                SummaryTable = DataBaseManager.GetTable(FullQuery1.ToString());                

                foreach(DataRow S in SummaryTable.Rows)
                {
                    Summary.Sd.Add(new Status_Days() { 
                        Status = S["Situacion"].ToString(),
                        Range1 = Int32.Parse(S["Menor6"].ToString()),
                        Range2 = Int32.Parse(S["Menor3_5"].ToString()),
                        Range3 = Int32.Parse(S["Menor2_1"].ToString()),
                        Range4 = Int32.Parse(S["Hoy"].ToString()),
                        Range5 = Int32.Parse(S["Mayor1_3"].ToString()),
                        Range6 = Int32.Parse(S["Mayor4_8"].ToString()),
                        Range7 = Int32.Parse(S["Mayor9_20"].ToString()),
                        Range8 = Int32.Parse(S["Mayor21_30"].ToString()),
                        Range9 = Int32.Parse(S["Mayor31"].ToString())                        
                    });
                }

                //Totales
                Summary.Sd.Add(new Status_Days() {
                    Status = "TOTAL",
                    Range1 = Summary.Sd.Sum(x => x.Range1),
                    Range2 = Summary.Sd.Sum(x => x.Range2),
                    Range3 = Summary.Sd.Sum(x => x.Range3),
                    Range4 = Summary.Sd.Sum(x => x.Range4),
                    Range5 = Summary.Sd.Sum(x => x.Range5),
                    Range6 = Summary.Sd.Sum(x => x.Range6),
                    Range7 = Summary.Sd.Sum(x => x.Range7),
                    Range8 = Summary.Sd.Sum(x => x.Range8),
                    Range9 = Summary.Sd.Sum(x => x.Range9),
                    Total = Summary.Sd.Sum(x => x.Total)
                });

                SummaryTable = DataBaseManager.GetTable(FullQuery2.ToString());

                foreach (DataRow S in SummaryTable.Rows)
                {
                    Summary.Ad.Add(new Assesor_Days()
                    {
                        Assesor = S["AGENTE"].ToString(),
                        Range1 = Int32.Parse(S["Menor6"].ToString()),
                        Range2 = Int32.Parse(S["Menor3_5"].ToString()),
                        Range3 = Int32.Parse(S["Menor2_1"].ToString()),
                        Range4 = Int32.Parse(S["Hoy"].ToString()),
                        Range5 = Int32.Parse(S["Mayor1_3"].ToString()),
                        Range6 = Int32.Parse(S["Mayor4_8"].ToString()),
                        Range7 = Int32.Parse(S["Mayor9_20"].ToString()),
                        Range8 = Int32.Parse(S["Mayor21_30"].ToString()),
                        Range9 = Int32.Parse(S["Mayor31"].ToString())
                    });
                }

                //Totales
                Summary.Ad.Add(new Assesor_Days()
                {
                    Assesor = "TOTAL",
                    Range1 = Summary.Ad.Sum(x => x.Range1),
                    Range2 = Summary.Ad.Sum(x => x.Range2),
                    Range3 = Summary.Ad.Sum(x => x.Range3),
                    Range4 = Summary.Ad.Sum(x => x.Range4),
                    Range5 = Summary.Ad.Sum(x => x.Range5),
                    Range6 = Summary.Ad.Sum(x => x.Range6),
                    Range7 = Summary.Ad.Sum(x => x.Range7),
                    Range8 = Summary.Ad.Sum(x => x.Range8),
                    Range9 = Summary.Ad.Sum(x => x.Range9)                    
                });
            }
            else 
            {
                FullQuery1.AppendFormat(QueriesCatalog.GetSummaryAssesorStatus, GetCounterAsesorQuery(filters), GetCaseAsesorQuery(filters), GetServiceTypeQuery(filters), GetFilterQuery(filters));
                FullQuery2.AppendFormat(QueriesCatalog.GetSummaryStatusOrder, GetCounterOrderQuery(filters), GetCaseOrderQuery(filters), GetServiceTypeQuery(filters), GetFilterQuery(filters));
                SummaryTable = DataBaseManager.GetTable(FullQuery1.ToString());                

                foreach (DataRow S in SummaryTable.Rows)
                {
                    Assesor_Status Asesr = new Assesor_Status();
                    Asesr.Status = S["Situacion"].ToString();

                    foreach (var Asr in filters.Assesors.FindAll(A => A.WorkShop == filters.SeletedWorkShop.WorkShopId))
                    {
                        Asesr.Values.Add(Convert.ToInt32(S[Asr.AsesorId]));
                    }

                    Summary.As.Add(Asesr);
                }

                //Totales
                Assesor_Status as1 = new Assesor_Status();
                as1.Status = "TOTAL";

                for (int index = 0; index < filters.Assesors.FindAll(A => A.WorkShop == filters.SeletedWorkShop.WorkShopId).Count; index++ )
                {
                    as1.Values.Add(Summary.As.Sum(v => v.Values[index]));
                }

                Summary.As.Add(as1);

                SummaryTable = DataBaseManager.GetTable(FullQuery2.ToString());

                foreach (DataRow S in SummaryTable.Rows)
                {
                    Status_Order Ords = new Status_Order();
                    Ords.Status = S["Situacion"].ToString();

                    foreach (var O in filters.OrdersType.FindAll(O => !O.OrderTypeId.Contains("_")))
                    {
                        Ords.Values.Add(Convert.ToInt32(S[O.OrderTypeId]));
                    }

                    Summary.So.Add(Ords);
                }

                //Totales
                Status_Order or1 = new Status_Order();
                or1.Status = "TOTAL";

                for (int index = 0; index < filters.OrdersType.FindAll(O => !O.OrderTypeId.Contains("_")).Count; index++)
                {
                    or1.Values.Add(Summary.So.Sum(v => v.Values[index]));
                }

                Summary.So.Add(or1);
            }

            return Summary;
        }
 
        private string BuildQuery(int pagenumber, int pagination, Filters tobuild)
        {
            StringBuilder Query = new StringBuilder();
            Query.AppendFormat(QueriesCatalog.GetActiveOrdersPage, pagenumber, pagination, GetFilterQuery(tobuild), GetServiceTypeQuery(tobuild));
            /*DEJAR TEMPORALEMNTE*/
            //Query.Append(QueriesCatalog.GetActiveOrdersPage);
            return Query.ToString();
        }

        private string GetFilterQuery(Filters tobuild)
        { 
            StringBuilder FiltersString = new StringBuilder();
            FiltersString.AppendFormat(@"AND SUCURSAL = '{0}' {1} {2} {3} {4}",
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
                OrderFilter.Append("AND (");

                foreach (string f in SplitFromOrder)
                {
                    OrderFilter.AppendFormat("V.SERVICIOTIPOORDEN = '{0}' OR ", f);
                }
                
                OrderFilter.Append(")").Replace("OR )",")");
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
            string Garantia = string.Empty;
            string Seguro = string.Empty;

            if (tobuild.SelectedOrdersType != null)
            {
                string[] SplitFromOrder = tobuild.SelectedOrdersType.OrderTypeId.Split('_');

                if (SplitFromOrder.Length > 1)
                {                    
                    if (SplitFromOrder.Contains("Garantia")) Garantia = "MOV = 'Servicio Garantia'";                   
                    
                    if (SplitFromOrder.Contains("Seguro")) Seguro = "MOV = 'Servicio HYP'";

                    OrderFilter.AppendFormat("(MOV = 'Servicio' {0} {1})",
                                              String.IsNullOrEmpty(Garantia) ? Garantia : string.Concat("OR ", Garantia),
                                              String.IsNullOrEmpty(Seguro) ? Seguro : string.Concat("OR ", Seguro));
                }
                else if (tobuild.SelectedOrdersType.OrderTypeId.Equals("Garantia"))
                {
                    OrderFilter.Append("MOV = 'Servicio Garantia'");
                }
                else if (tobuild.SelectedOrdersType.OrderTypeId.Equals("Seguro"))
                {
                    OrderFilter.Append("MOV = 'Servicio HYP'");
                }
                else OrderFilter.Append("MOV = 'Servicio'");
            }
            else OrderFilter.Append("(MOV = 'Servicio' OR MOV = 'Servicio Garantia')");

            return OrderFilter.ToString();
        }

        private string GetCounterAsesorQuery(Filters tobuild) 
        {
            StringBuilder Counts = new StringBuilder();
            int index = 1;

            foreach (var As in tobuild.Assesors.FindAll(A => A.WorkShop == tobuild.SeletedWorkShop.WorkShopId))
            {                
                Counts.AppendFormat("COUNT(case A{0} when 1 then A{0} else null end) {1},", index, As.AsesorId);
                index++;
            }

            Counts.Remove(Counts.Length - 1, 1);
            return Counts.ToString();
        }

        private string GetCaseAsesorQuery(Filters tobuild)
        {            
            StringBuilder Cases = new StringBuilder();            
            int index = 1;

            foreach (var As in tobuild.Assesors.FindAll(A => A.WorkShop == tobuild.SeletedWorkShop.WorkShopId))
            {
                Cases.AppendFormat("case v.Agente when '{1}' then 1 else 0 end A{0},", index, As.AsesorId);
                index++;
            }

            Cases.Remove(Cases.Length - 1, 1);
            return Cases.ToString();
        }

        private string GetCounterOrderQuery(Filters tobuild)
        {
            StringBuilder Counts = new StringBuilder();
            int index = 1;

            foreach (var Or in tobuild.OrdersType.FindAll(O => !O.OrderTypeId.Contains("_")))
            {
                Counts.AppendFormat("COUNT(case A{0} when 1 then A{0} else null end) {1},", index, Or.OrderTypeId);
                index++;
            }

            Counts.Remove(Counts.Length - 1, 1);
            return Counts.ToString();
        }

        private string GetCaseOrderQuery(Filters tobuild)
        {
            StringBuilder Cases = new StringBuilder();
            int index = 1;

            foreach (var Or in tobuild.OrdersType.FindAll(O => !O.OrderTypeId.Contains("_")))
            {
                Cases.AppendFormat("case v.[ServicioTipoOrden] when '{1}' then 1 else 0 end A{0},", index, Or.OrderTypeId);
                index++;
            }

            Cases.Remove(Cases.Length - 1, 1);
            return Cases.ToString();
        }
    }
}
