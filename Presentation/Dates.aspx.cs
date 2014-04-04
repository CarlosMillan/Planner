using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Controllers;
using DTOs = General.DTOs.Classes;
using System.Text;

namespace PlannerWeb
{
    public partial class Dates : System.Web.UI.Page
    {
        public string DatesTableHtml;
        public string MorningTableHtml;
        public string EveningTableHtml; 

        protected void Page_Init(object seder, EventArgs e)
        {
            GetDates();
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        public void GetDates()
        {
            DTOs.Dates D = DatesController.GetDates();
            DatesTableHtml = GetHtmlDateTable(D);
            GetHtmlTurnTable(D, out MorningTableHtml, out EveningTableHtml);
        }

        #region Private Methods
        private string GetHtmlDateTable(DTOs.Dates dates)
        {
            StringBuilder Table = new StringBuilder();

            foreach (DTOs.Date D in dates.Dts)
            {
                Table.AppendFormat(@"<tr class='{0}'>
                                        <td>{1}</td>
                                        <td>{2}</td>
                                        <td>{3}</td>
                                        <td>{4}</td>
                                        <td>{5}</td>
                                        <td>{6}</td>
                                     </tr>",
                                     dates.Dts.IndexOf(D) % 2 == 0 ? "pair" : "odd",
                                     D.Hour,
                                     D.Client,
                                     D.Vehicle,
                                     D.Plates,
                                     D.ServiceDate,
                                     "Empty");
            }

            return Table.ToString();
        }

        private void GetHtmlTurnTable(DTOs.Dates dates, out string morningtable, out string eveningatable)
        {
            StringBuilder MorningTable = new StringBuilder();
            StringBuilder EveningTable = new StringBuilder();

            foreach (DTOs.Turn T in dates.Trns)
            {
                if (T.MorningTurn)
                {
                    MorningTable.AppendFormat(@"<tr class='{0}'>
                                                <td>{1}</td>
                                                <td>{2}</td>
                                             </tr>",
                                                 dates.Trns.IndexOf(T) % 2 == 0 ? "pair" : "odd",
                                                 T.Hour,
                                                 T.StatusDescription);
                    }
                else
                {
                    EveningTable.AppendFormat(@"<tr class='{0}'>
                                                <td>{1}</td>
                                                <td>{2}</td>
                                             </tr>",
                             dates.Trns.IndexOf(T) % 2 == 0 ? "pair" : "odd",
                             T.Hour,
                             T.StatusDescription);
                }
            }

            morningtable = MorningTable.ToString();
            eveningatable = EveningTable.ToString();
        }
        #endregion
    }
}