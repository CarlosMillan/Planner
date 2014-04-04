<%@ Page Title="" Language="C#" MasterPageFile="~/Planner.Master" AutoEventWireup="true" CodeBehind="Dates.aspx.cs" Inherits="PlannerWeb.Dates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Css -->
    <link href="Css/Pages/ActiveOrders.css" rel="stylesheet" type="text/css" />
    <link href="Css/Pages/Dates.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Pages/Dates.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Path" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <div class="headerTitle">ESTIMADO CLIENTE BIENVENIDO A SU CITA DE SERVICIO</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPagination" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderPageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
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
<%--            <tr class="odd">
                <td>sdf</td>
                <td>sdf</td>
                <td>sdf</td>
                <td>sdf</td>
                <td>sdf</td>
                <td>sdf</td>                
            </tr>--%>
            <%=DatesTableHtml %>
        <tfoot>
        </tfoot>
    </table>

    
    <div class="picturecontainer">
        <div class="pictitle">SU ASESOR DE SERVICIO</div>
        <div class="picture"></div>
        <div class="pictitle">ASDFF WERWER VDFF 3ERERERE</div>
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
          <%--      <tr class="odd">
                    <td>8:00</td>
                    <td>diponible</td>
                </tr>
                <tr class="pair">
                    <td>10:00</td>
                    <td>diponible</td>
                </tr>--%>
                <%=MorningTableHtml %>
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
         <%--       <tr class="odd">
                    <td>13:00</td>
                    <td>ocupado</td>
                </tr>
                <tr class="pair">
                    <td>18:00</td>
                    <td>disponible</td>
                </tr>--%>
                <%=EveningTableHtml %>
            <tfoot>
            </tfoot>
        </table>
    </div>
    <div class="headerTitle">NUESTRO OBJETIVO ES QUE UESTED ESTE TOTALMENTE SATISFECHO</div>
</div>
</asp:Content>
