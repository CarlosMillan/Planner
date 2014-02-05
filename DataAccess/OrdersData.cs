using System;
using DataAccess.Bases;
using General.DTOs.Classes;
using DataAccess.General;
using System.Text;

namespace DataAccess
{
    public class OrdersData : OrderDataBase<Orders>
    {
        public OrdersData(){}

        public Orders GetOrders(Filters filters)
        {
            try
            {
                StringBuilder FullQuery = new StringBuilder();
                FullQuery.AppendFormat(QueriesCatalog.GetOrders, GetFilterQuery(filters));
                Orders Current = base.GetOrders(FullQuery.ToString(), string.Empty);
                return Current;
            }
            catch { throw; }
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

            if (SplitFromOrder.Length > 1) OrderFilter.AppendFormat("AND (V.SERVICIOTIPOORDEN = '{0}' OR V.SERVICIOTIPOORDEN = '{1}')", SplitFromOrder[0], SplitFromOrder[1]);
            else OrderFilter.AppendFormat("AND V.SERVICIOTIPOORDEN = '{0}'", SplitFromOrder[0]);

            return OrderFilter.ToString();
        }
    }
}
