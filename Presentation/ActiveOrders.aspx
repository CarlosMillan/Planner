<%@ Page Language="C#" MasterPageFile="~/Planner.Master" AutoEventWireup="true" CodeBehind="ActiveOrders.aspx.cs" Inherits="PlannerWeb.ActiveOrders" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- Css -->
    <link href="Css/Pages/ActiveOrders.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="ContenTitle" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <div class="headerTitle">PLANEADOR DE SERVICIO</div>
</asp:Content>

<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="ContentPlaceHolderPageTitle" runat="server">
    <div class="headerTitle subtitle">ÓRDENES ACTIVAS 105</div>
</asp:Content>

<asp:Content ID="ContentPagination" ContentPlaceHolderID="ContentPlaceHolderPagination" runat="server">
    <div class="headerTitle pages">1/8</div>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
<%--<table cellspacing="0" id="TbData">
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
        <tr class="odd">
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
            <td class="selected"></td>
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
            <td></td>
            <td class="selected"></td>
            <td></td>
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
            <td></td>
            <td></td>
            <td class="selected"></td>
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
--%>

<%--<div class="summarypanel">
<div class="subtitle">RESUMEN POR ESTATUS Y DÍAS PARA ENTREGA DE UNIDADES</div>

    <table cellspacing="0">
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
            <tr class="pair">
                <td class="rowtitle">ASIGNADA</td>
                <td>3</td>
                <td>5</td>
                <td>7</td>
                <td>99</td>
                <td>55</td>
                <td>32</td>
                <td>2</td>
                <td>6</td>
                <td>8</td>
                <td>89</td>            
            </tr>

            <tr class="odd">
                <td class="rowtitle">DIAGNOSTICO</td>
                <td>5</td>
                <td>7</td>
                <td>8</td>
                <td>2</td>
                <td>33</td>
                <td>4</td>
                <td>2</td>
                <td>4</td>
                <td>45</td>
                <td>54</td>            
            </tr>

            <tr class="pair">
                <td class="rowtitle">REPARACIÓN</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>            
            </tr>
            <tr class="odd">
                <td class="rowtitle">ASIGNADA</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>            
            </tr>

            <tr class="pair">
                <td class="rowtitle">PRUEBAS DE CALIDAD</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>            
            </tr>

            <tr class="odd">
                <td class="rowtitle">TOTAL</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>            
            </tr>
        </tbody>

        <tfoot>
        </tfoot>
    </table>
</div>

<div class="summarypanel">
<div class="subtitle">RESUMEN POR ASESOR Y DÍAS PARA ENTREGA DE UNIDADES</div>

    <table cellspacing="0">
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
            <tr class="pair">
                <td class="rowtitle">DRTYRY</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
                <td>7</td>
                <td>9</td>
                <td>4</td>
                <td>33</td>
                <td>55</td>
                <td>64</td>
                <td>34</td>            
            </tr>

            <tr class="odd">
                <td class="rowtitle">DFGSG</td>
                <td>34</td>
                <td>5</td>
                <td>76</td>
                <td>98</td>
                <td>12</td>
                <td>34</td>
                <td>6</td>
                <td>38</td>
                <td>3</td>
                <td>2</td>            
            </tr>

            <tr class="pair">
                <td class="rowtitle">FGHJDFGH</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>            
            </tr>

            <tr class="odd">
                <td class="rowtitle">GJGJH</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>            
            </tr>

            <tr class="pair">
                <td class="rowtitle">ASDFASDF</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>            
            </tr>

            <tr class="odd">
                <td class="rowtitle">TOTAL</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>            
            </tr>
        </tbody>

        <tfoot>
        </tfoot>
    </table>
</div>
--%>

<div class="summarypanel">
<div class="subtitle">RESUMEN POR ESTATUS Y POR ASESOR</div>

    <table cellspacing="0" class="medium">
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
            <tr class="pair">
                <td class="rowtitle">ASIGANDA</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
                <td>7</td>
                <td>9</td>
                <td>92</td>
            </tr>

            <tr class="odd">
                <td class="rowtitle">DIAGNOSTICO</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
                <td>7</td>
                <td>9</td>
                <td>92</td>
            </tr>

            <tr class="pair">
                <td class="rowtitle">REPARACIÓN</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
                <td>7</td>
                <td>9</td>
                <td>92</td>          
            </tr>

            <tr class="odd">
                <td class="rowtitle">PRUEAS DE CALIDAD</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
                <td>7</td>
                <td>9</td>
                <td>92</td>          
            </tr>

            <tr class="pair">
                <td class="rowtitle">TOTAL</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
                <td>7</td>
                <td>9</td>
                <td>92</td>
            </tr>
        </tbody>

        <tfoot>
        </tfoot>
    </table>
</div>


<div class="summarypanel">
<div class="subtitle">RESUMEN POR ESTATUS Y TIPO DE ORDEN</div>

    <table cellspacing="0" class="small">
        <thead>
            <tr>
                <th class="odd">ESTATUS</th>
                <th class="odd">ASDF</th>
                <th class="odd">FHFH</th>
                <th class="odd">TOTAL</th>
            </tr>
        </thead>

        <tbody>
            <tr class="pair">
                <td class="rowtitle">ASIGANDA</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
            </tr>

            <tr class="odd">
                <td class="rowtitle">DIAGNOSTICO</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
            </tr>

            <tr class="pair">
                <td class="rowtitle">REPARACIÓN</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
            </tr>

            <tr class="odd">
                <td class="rowtitle">PRUEAS DE CALIDAD</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
            </tr>

            <tr class="pair">
                <td class="rowtitle">TOTAL</td>
                <td>12</td>
                <td>34</td>
                <td>5</td>
            </tr>
        </tbody>

        <tfoot>
        </tfoot>
    </table>
</div>
</asp:Content>
