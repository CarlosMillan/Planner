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
                    <th class="odd underline">MENOR A -6 DÍAS</th>
                    <th class="odd underline">DE -5 A -3 DÍAS</th>
                    <th class="odd underline">DE -2 A -1 DÍAS</th>
                    <th class="odd">por st c5</th>
                    <th class="odd">por st c6</th>
                    <th class="odd">por st c7</th>
                    <th class="odd">por st c8</th>
                    <th class="odd">por st c9</th>
                    <th class="odd">por st c10</th>
                    <th class="odd">TOTAL</th>            
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
                    <th class="odd underline">Por asc c2</th>
                    <th class="odd underline">Por asc c3</th>
                    <th class="odd underline">Por asc c4</th>
                    <th class="odd">Por asc c5</th>
                    <th class="odd">Por asc c6</th>
                    <th class="odd">Por asc c7</th>
                    <th class="odd">Por asc c8</th>
                    <th class="odd">Por asc c9</th>
                    <th class="odd">Por asc c10</th>
                    <th class="odd">TOTAL</th>
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
                    <th class="odd">ASDF</th>
                    <th class="odd">FHFH</th>
                    <th class="odd">FGDFG</th>
                    <th class="odd">DGDFGH</th>
                    <th class="odd">FGSFG</th>
                    <th class="odd">TOTAL</th>
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
                    <th class="odd">ASDF</th>
                </tr>
            </thead>

            <tbody>

            </tbody>

            <tfoot>
            </tfoot>
        </table>
    </div>
</div>
<div class="button active cancel" id="BtnStop"><div>DETENER</div></div>
</asp:Content>
