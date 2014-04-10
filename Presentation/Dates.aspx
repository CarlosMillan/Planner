<%@ Page Title="" Language="C#" MasterPageFile="~/Planner.Master" AutoEventWireup="true" CodeBehind="Dates.aspx.cs" Inherits="PlannerWeb.Dates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Css -->
    <link href="Css/Pages/ActiveOrders.css" rel="stylesheet" type="text/css" />
    <link href="Css/Pages/Dates.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Pages/Dates.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Contenttitle" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <div class="headerTitle">ESTIMADO CLIENTE BIENVENIDO A SU CITA DE SERVICIO</div>
</asp:Content>
<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="ContentPlaceHolderPageTitle" runat="server">
    <a href="Default.aspx" title="Volver">Filtrar</a>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
<div id="DvTable">
    <table cellspacing="0" id="TbData">
    <thead>
        <tr>
            <th>Tipo de Orden</th>
            <th>No. de Orden</th>
            <th>Ingreso</th>
            <th>Cliente</th>
            <th>Vehículo</th>
            <th>Placas</th>     
        </tr>
    </thead>

        <tbody>
        </tbody>

        <tfoot>
        </tfoot>
    </table>
    
    <div class="picturecontainer">
        <div class="pictitle">SU ASESOR DE SERVICIO</div>
        <div class="picture"></div>
        <div class="pictitle name"></div>
    </div>
    
    <div class="schedules">        
        <table cellspacing="0" id="Morning">         
        <caption class="pictitle">TURNO MATUTINO</caption>
            <thead>            
                <tr>
                    <th>horario</th>
                    <th>estado</th>
                    </th>           
                </tr>
            </thead>

            <tbody>
            </tbody>

            <tfoot>
            </tfoot>
        </table>

        <table cellspacing="0" id="Evening">            
            <caption class="pictitle">TURNO VESPERTINO</caption>
            <thead>            
                <tr>
                    <th>horario</th>
                    <th>estado</th>
                    </th>           
                </tr>
            </thead>

            <tbody>
            </tbody>

            <tfoot>
            </tfoot>
        </table>
    </div>    
</div>
<div class="headerTitle">NUESTRO OBJETIVO ES QUE USTED ESTE TOTALMENTE SATISFECHO</div>
</asp:Content>
