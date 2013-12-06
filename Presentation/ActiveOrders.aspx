<%@ Page Title="" Language="C#" MasterPageFile="~/Planner.Master" AutoEventWireup="true" CodeBehind="ActiveOrders.aspx.cs" Inherits="PlannerWeb.ActiveOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Css -->
    <link href="Css/Pages/ActiveOrders.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="ContenTitle" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <div class="headerTitle">PLANEADOR DE SERVICIO</div>
</asp:Content>

<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="ContentPlaceHolderPageTitle" runat="server">
    <div class="headerTitle">ÓRDENES ACTIVAS 105</div>
</asp:Content>

<asp:Content ID="ContentPagination" ContentPlaceHolderID="ContentPlaceHolderPagination" runat="server">
    <div class="headerTitle pages">1/8</div>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
<table cellspacing="0" id="TbData">
    <thead>
        <tr>
            <th>Tipo de Orden</th>
            <th>No. de Orden</th>
            <th>Fecha</th>
            <th>Cliente</th>
            <th>Vehículo</th>
            <th>Placas</th>
            <th>Días de Estancia</th>
            <th>Estatus</th>
            <th>Días para Entrega</th>            
            <th colspan="5">
             ASESOR DE SERVICIO
                <table class="nested">
                    <thead>
                        <tr>
                            <th style="padding-left:0;padding-right:0;width:65px;">GALJU0</th>
                            <th style="padding-left:0;padding-right:0;width:65px;">GARCMA</th>
                            <th style="padding-left:0;padding-right:0;width:65px;">HERNAJ</th>
                            <th style="padding-left:0;padding-right:0;width:65px;">LORG9</th>
                            <th style="padding-left:0;padding-right:0;width:65px;">REYAL8</th>
                        </tr>  
                    </thead>                  
                </table>
            </th>           
        </tr>
    </thead>

    <tbody>
        <tr class="pair">
            <td>JRA </td>
            <td>367463</td>
            <td>03-JUL-13</td>
            <td>DESENTIS ASESORES CO</td>
            <td>POLICE INTERCEPTOR</td>
            <td>234FET2</td>
            <td class="highlight">10</td>
            <td>PRUEBAS DE CALIDAD</td>
            <td class="badhighlight">-2</td>
            <td class="selected"></td>
            <td></td>
            <td></td>
            <td class="selected"></td>
            <td></td>
        </tr>

        <tr class="odd">
            <td>celda1</td>
            <td>celda2</td>
            <td>celda3</td>
            <td>celda4</td>
            <td>celda5</td>
            <td>celda6</td>
            <td>celda7</td>
            <td>celda8</td>
            <td>celda9</td>
            <td></td>
            <td class="selected"></td>
            <td></td>
            <td class="selected"></td>
            <td></td>
        </tr>

        <tr class="pair">
            <td>celda1</td>
            <td>celda2</td>
            <td>celda3</td>
            <td>celda4</td>
            <td>celda5</td>
            <td>celda6</td>
            <td>celda7</td>
            <td>celda8</td>
            <td>celda9</td>
            <td></td>
            <td></td>
            <td class="selected"></td>
            <td></td>
            <td></td>
        </tr>

        <tr class="odd">
            <td>celda1</td>
            <td>celda2</td>
            <td>celda3</td>
            <td>celda4</td>
            <td>celda5</td>
            <td>celda6</td>
            <td>celda7</td>
            <td>celda8</td>
            <td>celda9</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td class="selected"></td>
        </tr>

        <tr class="pair">
            <td>celda1</td>
            <td>celda2</td>
            <td>celda3</td>
            <td>celda4</td>
            <td>celda5</td>
            <td>celda6</td>
            <td>celda7</td>
            <td>celda8</td>
            <td>celda9</td>
            <td class="selected"></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </tbody>

    <tfoot>
    </tfoot>
</table>
</asp:Content>
