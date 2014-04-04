using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTOs = General.DTOs.Classes;
using General.Utils;
using System.Data;
using DataAccess.General;

namespace DataAccess
{
    public class DatesData
    {
        public DatesData() { }

        public DTOs.Dates GetDates()
        {
            string QueryDates = BuildQueryDates();
            string QueryTurns = BuildQueryTurns();
            DTOs.Dates Result = new DTOs.Dates();
            DataTable DatesTable = DataBaseManager.GetTable(QueryDates);
            DataTable TurnsTable = DataBaseManager.GetTable(QueryTurns);

            foreach (DataRow R in DatesTable.Rows)
            {
                DateTime t = Convert.ToDateTime(R["hora"]);
                string c = R["cliente"].ToString();
                string v = R["vehiculo"].ToString();
                string p = R["placas"].ToString();
                string s = R["servicio"].ToString();
                string e = R["cita_efectiva"].ToString();

                Result.Dts.Add(new DTOs.Date(t,c,v,p,s));
            }

            foreach (DataRow R in TurnsTable.Rows)
            {
                DateTime t = Convert.ToDateTime(R["hora"]);
                string s = R["status"].ToString();
                string turn = R["turno"].ToString();
                bool a = s.Equals("ocupado") ? false : true;
                bool m = turn.Equals("matutino") ? true : false;

                Result.Trns.Add(new DTOs.Turn(t, a, s, m));
            }

            return Result;
        }

        public string BuildQueryDates()
        {
            return QueriesCatalog.GetDates;
        }

        public string BuildQueryTurns()
        {
            return QueriesCatalog.GetTurns;
        }
    }
}
