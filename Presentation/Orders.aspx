<%@ Page Language="C#" MasterPageFile="~/Edit.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="PlannerWeb.OrdersWeb" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Pages/Orders.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="ContentEditTitle" ContentPlaceHolderID="ContentPlaceHolderEditTitle" runat="server">
<div>Órdenes</div> <div>(<%=Path %>)</div>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
<input type="hidden" name="ReturnUrl" id="ReturnUrl" />
<table cellspacing="0" id="TbData">
    <thead>
        <tr>
            <th>Tipo de Orden</th>
            <th>No. de Orden</th>
            <th>Fecha de ingreso</th>
            <th>Fecha de promesa</th>
            <!--<th>Fecha de promesa 2</th>-->
            <th>Vehículo</th>
            <th>Cliente</th>            
            <th>Placas</th>
            <th>Días de Estancia</th>
            <th>Estatus</th>
            <th>Días para entrega</th>     
            <th>Asesor</th>     
            <th>telefono celular</th>
            <th>Acción</th>
        </tr>
    </thead>

    <tbody>
        <%=HtmlTable %>
    </tbody>

    <tfoot>
    </tfoot>
</table>
</asp:Content>
