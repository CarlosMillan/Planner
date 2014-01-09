using System;
using System.Collections.Generic;

namespace General.DTOs.Classes
{
    public class Filters
    {
        public List<WorkShop> Workshops;
        public List<Access> AccessAs;
        public List<OrderType> OrdersType;
        public List<Status> Situations;
        public List<Asesor> Asesors;

        public Filters()
        {
            Workshops = new List<WorkShop>();
            AccessAs = new List<Access>();
            OrdersType = new List<OrderType>();
            Situations = new List<Status>();
            Asesors = new List<Asesor>();

            #region Workshops
            Workshops.Add(new WorkShop() { 
                WorkSopId = 1,
                Name = "Matriz"
            });

            Workshops.Add(new WorkShop()
            {
                WorkSopId = 2,
                Name = "Sucursal 1"
            });

            Workshops.Add(new WorkShop()
            {
                WorkSopId = 3,
                Name = "Sucursal 2"
            });

            Workshops.Add(new WorkShop()
            {
                WorkSopId = 4,
                Name = "Body Shop"
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
                OrderTypeId = 1,
                Name = "Público"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = 2,
                Name = "Garantías"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = 3,
                Name = "Seguros"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = 4,
                Name = "Previas"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = 5,
                Name = "Internas"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = 6,
                Name = "Público y Garantías"
            });

            OrdersType.Add(new OrderType()
            {
                OrderTypeId = 7,
                Name = "Público y Seguros"
            });
            #endregion

            #region Status
            Situations.Add(new Status() { 
                StatusId = 1,
                Name = "Pendiente"
            });

            Situations.Add(new Status()
            {
                StatusId = 2,
                Name = "Lavado"
            });

            Situations.Add(new Status()
            {
                StatusId = 3,
                Name = "Reparación"
            });

            Situations.Add(new Status()
            {
                StatusId = 4,
                Name = "Espera"
            });

            Situations.Add(new Status()
            {
                StatusId = 5,
                Name = "Otro"
            });

            Situations.Add(new Status()
            {
                StatusId = 6,
                Name = "Quien sabe!"
            });
            #endregion

            #region Asesors
            Asesors.Add(new Asesor() { 
                AsesorId = 1,
                Name = "xxx"
            });

            Asesors.Add(new Asesor()
            {
                AsesorId = 2,
                Name = "yyy"
            });

            Asesors.Add(new Asesor()
            {
                AsesorId = 3,
                Name = "aaa"
            });

            Asesors.Add(new Asesor()
            {
                AsesorId = 4,
                Name = "hhh"
            });
            #endregion
        }
    }

    public class WorkShop
    {
        public int WorkSopId {get; set;}
        public string Name {get; set;}
    }

    public class Access
    {
        public int AccessId { get; set; }
        public string Name { get; set; }
    }

    public class OrderType
    {
        public int OrderTypeId {get; set;}
        public string Name {get; set;}
    }

    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
    }

    public class Asesor
    {
        public int AsesorId { get; set; }
        public string Name { get; set; }
    }
}
