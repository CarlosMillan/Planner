<%@ Page Language="C#" MasterPageFile="~/Edit.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="PlannerWeb.OrdersWeb" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Pages/Orders.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="ContentEditTitle" ContentPlaceHolderID="ContentPlaceHolderEditTitle" runat="server">
<div>Órdenes</div>
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
            <th>Fecha de promesa 2</th>
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
<%--        <tr class="odd" id="ord1">
            <td>JRA</td>
            <td>367463</td>
            <td>03-JUL-13</td>
            <td>03-JUL-14</td>
            <td>03-JUL-15</td>
            <td>DESENTIS ASESORES CO</td>
            <td>POLICE INTERCEPTOR</td>
            <td>234FET2</td>
            <td class="highlight">10</td>
            <td>PRUEBAS DE CALIDAD</td>
            <td class="badhighlight">-2</td>
            <td>pepe pecas</td>
            <td>77723324</td>            
            <td><input type="button" value="Editar" /></td>
        </tr>

        <tr class="pair" id="ord2">
            <td>JRA</td>
            <td>367463</td>
            <td>03-MAR-10</td>
            <td>03-MAR-11</td>
            <td>03-MAR-12</td>
            <td>XXXXXX</td>
            <td>POLICE INTERCEPTOR</td>
            <td>234FET2</td>
            <td class="highlight">10</td>
            <td>PRUEBAS DE CALIDAD</td>
            <td class="badhighlight">-2</td>
            <td>pepe pecas</td>
            <td>77723324</td>            
            <td><input type="button" value="Editar" /></td>            
        </tr>

        <tr class="odd" id="ord3">
            <td>JRdA</td>
            <td>d463</td>
            <td>03-abr-13</td>
            <td>03-abr-14</td>
            <td>03-abr-15</td>
            <td>DESENTIS ASESORES CO</td>
            <td>POLICE INTERCEPTOR</td>
            <td>234FET2</td>
            <td class="highlight">10</td>
            <td>PRUEBAS DE CALIDAD</td>
            <td class="badhighlight">-2</td>
            <td>pablito</td>
            <td>77723324</td>            
            <td><input type="button" value="Editar" /></td>            
        </tr>

        <tr class="pair" id="ord4">
            <td>JRA</td>
            <td>367463</td>
            <td>03-JUL-13</td>
            <td>03-JUL-14</td>
            <td>03-JUL-15</td>
            <td>DESENTIS ASESORES CO</td>
            <td>POLICE INTERCEPTOR</td>
            <td>234FET2</td>
            <td class="highlight">10</td>
            <td>PRUEBAS DE CALIDAD</td>
            <td class="badhighlight">-2</td>
            <td>pepe pecas</td>
            <td>77723324</td>            
            <td><input type="button" value="Editar" /></td>            
        </tr>

        <tr class="odd" id="ord5">
            <td>JRA</td>
            <td>367463</td>
            <td>03-JUL-13</td>
            <td>03-JUL-14</td>
            <td>03-JUL-15</td>
            <td>DESENTIS ASESORES CO</td>
            <td>POLICE INTERCEPTOR</td>
            <td>234FET2</td>
            <td class="highlight">10</td>
            <td>PRUEBAS DE CALIDAD</td>
            <td class="badhighlight">-2</td>
            <td>pepe pecas</td>
            <td>77723324</td>            
            <td><input type="button" value="Editar" /></td>            
        </tr>--%>
    </tbody>

    <tfoot>
    </tfoot>
</table>
</asp:Content>
