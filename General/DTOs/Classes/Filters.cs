using System;
using System.Collections.Generic;

namespace General.DTOs.Classes
{
    public class Filters
    {
        public List<WorkShop> WorkShops;
        public List<Access> AccessAs;
        public List<OrderType> OrdersType;
        public List<Status> Situations;
        public List<Asesor> Assesors;
        public string OrderClientPlates;

        public WorkShop SelectedWorkShop
        {
            get
            {
                return WorkShops.Find(w => w.IsSelected == true);                
            }
        }

        public Access SelectedAccess
        {
            get 
            {
                return AccessAs.Find(A => A.IsSelected == true);
            }
        }

        public OrderType SelectedOrdersType
        {
            get 
            {
                return OrdersType.Find(O => O.IsSelected == true);
            }
        }

        public Status SelectedSituation
        {
            get
            {
                return Situations.Find(S => S.IsSelected == true);
            }
        }

        public Asesor SelectedAssesor
        {
            get
            {
                return Assesors.Find(A => A.IsSelected == true);
            }
        }

        public string SelectedOrderClientPlates
        {
            get { return OrderClientPlates; }
        }

        public Filters()
        {
            WorkShops = new List<WorkShop>();
            AccessAs = new List<Access>();
            OrdersType = new List<OrderType>();
            Situations = new List<Status>();
            Assesors = new List<Asesor>();
            OrderClientPlates = string.Empty;

            #region Workshops
            WorkShops.Add(new WorkShop() { 
                WorkShopId = 1,
                Name = "Pedregal",
                Min = 110000,
                Max = 179999
            });

            WorkShops.Add(new WorkShop()
            {
                WorkShopId = 2,
                Name = "Tlahuac",
                Min = 500000,
                Max = 599000
            });

            WorkShops.Add(new WorkShop()
            {
                WorkShopId = 5,
                Name = "Body Shop",
                Min = 180000,
                Max = 199999
            });
            #endregion

            #region Access
            AccessAs.Add(new Access() { 
                AccessId = 1,
                Name = "Taller"
            });

            AccessAs.Add(new Access()
            {
                AccessId = 2,
                Name = "Asesor"
            });

            AccessAs.Add(new Access()
            {
                AccessId = 3,
                Name = "Estatus o situación"
            });

            AccessAs.Add(new Access()
            {
                AccessId = 4,
                Name = "Orden de Servicio, Nombre de cliente o Placas"
            });
            #endregion

            #region Orders type
            OrdersType.Add(new OrderType() {
                OrderTypeId = "Publico",
                Name = "Público"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = "Garantia",
                Name = "Garantía"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = "Seguro",
                Name = "Seguro"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = "Flotilla",
                Name = "Flotilla"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = "Interno",
                Name = "Interno"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = "Publico_Garantia",
                Name = "Público y Garantía"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = "Publico_Seguro",
                Name = "Público y Seguro"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = "Publico_Flotilla",
                Name = "Público y Flotilla"
            });

            OrdersType.Add(new OrderType()
            {               
                OrderTypeId  = "Todo",
                Name = "Todo",
                isAll = true
            });
            #endregion

            #region Status
            Situations.Add(new Status() {                 
                Name = "Orden Abierta"
            });

            Situations.Add(new Status()
            {                
                Name = "En Proceso"
            });

            Situations.Add(new Status()
            {                
                Name = "Pendiente Autorizacion"
            });

            Situations.Add(new Status()
            {                
                Name = "Parada X Refacc"
            });

            Situations.Add(new Status()
            {                
                Name = "U Circulando"
            });

            Situations.Add(new Status()
            {                
                Name = "Pzas Surtidas"
            });

            Situations.Add(new Status()
            {                
                Name = "U En HyPB"
            });

            Situations.Add(new Status()
            {                
                Name = "Trabajo Fuera"
            });

            Situations.Add(new Status()
            {                
                Name = "U a Prueba"
            });

            Situations.Add(new Status()
            {                
                Name = "Reproceso"
            });

            Situations.Add(new Status()
            {                
                Name = "Espera Lavado"
            });

            Situations.Add(new Status()
            {                
                Name = "En Lavado"
            });

            Situations.Add(new Status()
            {                
                Name = "Lavado Terminado"
            });

            Situations.Add(new Status()
            {                
                Name = "Orden Cerrada"
            });

            Situations.Add(new Status()
            {                
                Name = "Unidad Salio"
            });
            #endregion

            #region Asesors

            #region Pedregal
            Assesors.Add(new Asesor() { 
                AsesorId = "GALJU0",
                Name = "GALJU0",
                WorkShop = 1
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "CASCA4",
                Name = "CASCA4",
                WorkShop = 1
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "HERNAJ",
                Name = "HERNAJ",
                WorkShop = 1
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "RODRI1",
                Name = "RODRI1",
                WorkShop = 1
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "SANIS9",
                Name = "SANIS9",
                WorkShop = 1
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "SIU",
                Name = "SIU",
                WorkShop = 1
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "HERJIM",
                Name = "HERJIM",
                WorkShop = 1
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "ALDO",
                Name = "ALDO",
                WorkShop = 1
            });
            #endregion

            #region Tlahuac
            Assesors.Add(new Asesor()
            {
                AsesorId = "CANTO6",
                Name = "CANTO6",
                WorkShop = 2
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "BAURO2",
                Name = "BAURO2",
                WorkShop = 2
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "JCARLO",
                Name = "JCARLO",
                WorkShop = 2
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "RODRIE",
                Name = "RODRIE",
                WorkShop = 2
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "GARHE9",
                Name = "GARHE9",
                WorkShop = 2
            });
            #endregion

            #region Body Shop
            Assesors.Add(new Asesor()
            {
                AsesorId = "JCARLO",
                Name = "JCARLO",
                WorkShop = 5
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "GARHE9",
                Name = "GARHE9",
                WorkShop = 5
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "RODRIE",
                Name = "RODRIE",
                WorkShop = 5
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "MALDOJ",
                Name = "MALDOJ",
                WorkShop = 5
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "GALJU0",
                Name = "GALJU0",
                WorkShop = 5
            });

            Assesors.Add(new Asesor()
            {
                AsesorId = "BAURO2",
                Name = "BAURO2",
                WorkShop = 5
            });
            #endregion
            #endregion
        }
    }

    public class WorkShop
    {
        public int WorkShopId {get; set;}
        public string Name {get; set;}
        public bool IsSelected { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class Access
    {
        public int AccessId { get; set; }
        public string Name { get; set; }        
        public bool IsSelected { get; set; }
    }

    public class OrderType
    {
        public string OrderTypeId {get; set;}
        public string Name {get; set;}        
        public bool IsSelected { get; set; }
        public bool isAll { get; set; }

        public OrderType()
        {
            isAll = false;
        }
            
    }

    public class Status
    {        
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }

    public class Asesor
    {
        public string AsesorId { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public int WorkShop { get; set; }
    }
}
