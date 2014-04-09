using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Controllers;
using DTOs = General.DTOs.Classes;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using PlannerWeb.App_Code;

namespace PlannerWeb
{
    public partial class Dates : System.Web.UI.Page
    {
        private static string DatesTableHtml;
        private static string MorningTableHtml;
        private static string EveningTableHtml;
        private static int TotalPages;
        private static int CurrentPage;

        protected void Page_Init(object seder, EventArgs e)
        {
            CurrentPage = 0;
            //GetDates();
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        public void GetDates()
        {
            DTOs.Dates D = DatesController.GetDates(1);
            GetHtmlDateTable(D);
            GetHtmlTurnTable(D);
        }

        #region WebMethods
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetDatesPage() 
        {
            JavaScriptSerializer Json = new JavaScriptSerializer();
            PageDateInfo Info;
            GetValidPage();
            DTOs.Dates D = DatesController.GetDates(CurrentPage);
            GetHtmlDateTable(D);
            GetHtmlTurnTable(D);
            TotalPages = D.TotalPages;
            Info = new PageDateInfo(D.AssessorId, D.AssessorName, TotalPages, DatesTableHtml, MorningTableHtml, EveningTableHtml);
            return Json.Serialize(Info);
        }
        #endregion

        #region Private Methods
        private static void GetHtmlDateTable(DTOs.Dates dates)
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

            DatesTableHtml = Table.ToString();
        }

        private static void GetHtmlTurnTable(DTOs.Dates dates)
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

            MorningTableHtml = MorningTable.ToString();
            EveningTableHtml = EveningTable.ToString();
        }

        private static void GetValidPage()
        {
            CurrentPage++;

            if (CurrentPage > TotalPages) CurrentPage = 1;            
        }
        #endregion
    }
}