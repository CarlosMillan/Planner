<%@ Page Language="C#" MasterPageFile="~/Planner.Master" AutoEventWireup="true" CodeBehind="ActiveOrdersPage .aspx.cs" Inherits="PlannerWeb.ActiveOrdersPage " %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- Css -->
    <link href="Css/Pages/ActiveOrders.css" rel="stylesheet" type="text/css" />

    <!-- Scripts -->
    <script src="Scripts/Pages/ActiveOrders.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        ActiveOrders.Pagination = <%=Pagination %>;
    </script>
</asp:Content>

<asp:Content ID="ContenTitle" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <div class="headerTitle">PLANEADOR DE SERVICIO</div>
</asp:Content>

<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="ContentPlaceHolderPageTitle" runat="server">
    <div class="headerTitle subtitle">ÓRDENES ACTIVAS <span></span></div>
    <a href="Default.aspx" title="Volver">Filtrar</a>
</asp:Content>

<asp:Content ID="ContentPagination" ContentPlaceHolderID="ContentPlaceHolderPagination" runat="server">
    <div class="headerTitle pages"></div>        
    <!--<div id="DvMessages"></div>-->
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
            <th>Días de Estancia</th>
            <th>Estatus</th>
            <th>Días para Entrega</th>            
            <th colspan="5">
             ASESOR DE SERVICIO
                <table class="nested">
                    <thead>
                        <tr>
                           <%=AsessorsHtml%>
                        </tr>  
                    </thead>                  
                </table>
            </th>           
        </tr>
    </thead>

        <tbody>
        </tbody>

        <tfoot>
        </tfoot>
    </table>

    <div class="summarypanel">
        <div class="subtitle" id="TitleSummary1">RESUMEN POR ESTATUS Y DÍAS PARA ENTREGA DE UNIDADES</div>
        <table cellspacing="0" id="TableSummary1">
            <thead>
                <tr>
                    <th class="odd">ESTATUS</th>
                    <th class="odd underline data">MENOR A -6 DÍAS</th>
                    <th class="odd underline data">DE -5 A -3 DÍAS</th>
                    <th class="odd underline data">DE -2 A -1 DÍAS</th>
                    <th class="odd data">0 Días</th>
                    <th class="odd data">DE 1 A 3 DÍAS</th>
                    <th class="odd data">DE 4 A 8 DÍAS</th>
                    <th class="odd data">DE 9 A 20 DÍAS</th>
                    <th class="odd data">DE 21 A 30 DÍAS</th>
                    <th class="odd data">MÁS DE 31 DÍAS</th>
                    <th class="odd data">TOTAL</th>            
                </tr>
            </thead>

            <tbody>            
            </tbody>

            <tfoot>
            </tfoot>
        </table>

        <div class="subtitle" id="TitleSummary2">RESUMEN POR ASESOR Y DÍAS PARA ENTREGA DE UNIDADES</div>
        <table cellspacing="0" id="TableSummary2">
            <thead>
                <tr>
                    <th class="odd">ASESOR</th>
                    <th class="odd underline data">MENOR A -6 DÍAS</th>
                    <th class="odd underline data">DE -5 A -3 DÍAS</th>
                    <th class="odd underline data">DE -2 A -1 DÍAS</th>
                    <th class="odd data">0 Días</th>
                    <th class="odd data">DE 1 A 3 DÍAS</th>
                    <th class="odd data">DE 4 A 8 DÍAS</th>
                    <th class="odd data">DE 9 A 20 DÍAS</th>
                    <th class="odd data">DE 21 A 30 DÍAS</th>
                    <th class="odd data">MÁS DE 31 DÍAS</th>
                    <th class="odd data">TOTAL</th>         
                </tr>
            </thead>

            <tbody>

            </tbody>

            <tfoot>
            </tfoot>
          </table>

        <div class="subtitle" id="TitleSummary3">RESUMEN POR ESTATUS Y POR ASESOR</div>
        <table cellspacing="0" class="medium" id="TableSummary3">
            <thead>
                <tr>
                    <th class="odd">ESTATUS</th>
                    <%=AsesorsHeadersHtml%>
                </tr>
            </thead>

            <tbody>

            </tbody>

            <tfoot>
            </tfoot>
        </table>


        <div class="subtitle" id="TitleSummary4">RESUMEN POR ESTATUS Y TIPO DE ORDEN</div>
        <table cellspacing="0" class="small" id="TableSummary4">
            <thead>
                <tr>
                    <th class="odd">ESTATUS</th>
                    <%=OrderTypeHeadersHtml%>
                </tr>
            </thead>

            <tbody>

            </tbody>

            <tfoot>
            </tfoot>
        </table>
    </div>
</div>
<div style="width:100%;height:82px;clear:both;">
    <div class="button active cancel" id="BtnStop"><div>DETENER</div></div>
</div>
</asp:Content>
