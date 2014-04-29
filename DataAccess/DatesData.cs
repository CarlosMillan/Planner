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
        private int _totalpages;
        private string _assessorid;
        private string _assessorname;
        private string _service;

        public DatesData() { }

        #region Public Methods
        public DTOs.Dates GetDates(int page, string service)
        {
            _service = service;
            _totalpages = GetTotalDates(_service);
            GetAssessorData(page);
            string QueryDates = BuildQueryDates();
            string QueryTurns = BuildQueryTurns();

            DTOs.Dates Result = new DTOs.Dates(_assessorid, _assessorname, _totalpages);
            DataTable DatesTable = DataBaseManager.GetTable(QueryDates);
            //DataTable TurnsTable = DataBaseManager.GetTable(QueryTurns);

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

            //foreach (DataRow R in TurnsTable.Rows)
            //{
            //    DateTime t = Convert.ToDateTime(R["hora"]);
            //    string s = R["status"].ToString();
            //    string turn = R["turno"].ToString();
            //    bool a = s.Equals("ocupado") ? false : true;
            //    bool m = turn.Equals("matutino") ? true : false;

            //    Result.Trns.Add(new DTOs.Turn(t, a, s, m));
            //}

            return Result;
        }

        public int GetTotalDates(string service)
        {
            try
            {
                return (int)DataBaseManager.GetValue(new StringBuilder().AppendFormat(QueriesCatalog.GetTotalDatesPages, service).ToString());

            }catch(Exception E)
            {
                return 0;
            }
        }
        #endregion

        #region Private Methods
        private string BuildQueryDates()
        {
            return new StringBuilder().AppendFormat(QueriesCatalog.GetDates, _assessorid, _service).ToString();
        }

        private string BuildQueryTurns()
        {
            return new StringBuilder().AppendFormat(QueriesCatalog.GetTurns, _assessorid, _service).ToString();            
        }

        private void GetAssessorData(int page)
        {
            DataTable DatesTable = DataBaseManager.GetTable(new StringBuilder().AppendFormat(QueriesCatalog.GetDatesAssessors, _service).ToString());

            if (page > 0 && page <= _totalpages)
            {
                _assessorid = DatesTable.Rows[page - 1]["Asesor"].ToString();
                _assessorname = DatesTable.Rows[page - 1]["Name"].ToString();
            }
            else 
            {
                _assessorid = "ID";
                _assessorname = "NONE";
            }
        }
        #endregion
    }
}
