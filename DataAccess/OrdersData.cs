using System;
using DataAccess.Bases;
using General.DTOs.Classes;
using DataAccess.General;
using System.Text;
using System.Linq;

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
                FullQuery.AppendFormat(QueriesCatalog.GetOrders, GetFilterQuery(filters), GetServiceTypeQuery(filters));
                Orders Current = base.GetOrders(FullQuery.ToString(), string.Empty, string.Empty);
                return Current;
            }
            catch { throw; }
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

                OrderFilter.Append(")").Replace("OR )", ")");
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
                    if (!SplitFromOrder.Contains("Garantia"))
                    {
                        OrderFilter.Append("MOV = 'Servicio'");
                    }
                    else if (SplitFromOrder.Contains("Seguro"))
                    {
                        OrderFilter.Append("(MOV = 'Servicio' OR MOV = 'Servicio Garantia' OR MOV = 'Servicio HYP')");
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
                else if (tobuild.SelectedOrdersType.OrderTypeId.Equals("Seguro"))
                {
                    OrderFilter.Append("MOV = 'Servicio HYP'");
                }
                else OrderFilter.Append("MOV = 'Servicio'");
            }
            else OrderFilter.Append("(MOV = 'Servicio' OR MOV = 'Servicio Garantia')");

            return OrderFilter.ToString();
        }
    }
}
