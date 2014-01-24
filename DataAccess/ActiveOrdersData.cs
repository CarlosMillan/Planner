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
                StringBuilder FullQuery = new StringBuilder();
                FullQuery.AppendFormat(QueriesCatalog.GetActiveOrdersPage, pagenumber, pagination);
                ActiveOrders Current = base.GetOrders(FullQuery.ToString());
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
    }
}
