<%@ Page Title="" Language="C#" MasterPageFile="~/Planner.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PlannerWeb.Default" %>
<asp:Content ID="DefaultContentHead" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Pages/Login.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Pages/Default.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="DefaultContentTitle" ContentPlaceHolderID="ContentPlaceHolderPageTitle" runat="server">
    <%if (Session["Name"] != null)
     { %>
    <div id="DvLogOut">                    
        <asp:Button ID="BtnLogOut" runat="server" Text="Salir" 
            onclick="BtnLogOut_Click" />  
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="DefaultContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div id="DvMessages"></div>

    <div id="DvLoginContainer">
        <div id="DvLoginContent">
            <div class="fill"></div>
                <div id="DvInputs" class="panel">
                    <div class="row">
                        <label class="title">Seleciona los filtros.</label>
                    </div>
                    <div class="row">
                        <label>Seleccione el taller de servicio:</label>
                        <select id="SlcService">
                            <option value="0">-- Seleccione un taller --</option>
                            <option value="1">Matriz</option>
                            <option value="2">Sucursal 1</option>
                            <option value="3">Sucursal 2</option>
                            <option value="4">Body Shop</option>
                        </select>
                    </div>
                    <div class="row">
                        <label>Entrar como:</label>
                        <select id="SlcAccess">
                            <option value="0">-- Seleccione el tipo de acceso --</option>
                            <option value="1">Taller</option>
                            <option value="2">Asesor</option>
                            <option value="3">Estatus o situación</option>
                            <option value="4">Orden de servicio Nombre de Cliente o Placas</option>
                        </select>
                    </div>
                    <div class="row">
                        <label>Tipo de orden:</label>
                        <select id="SlcOrder">
                            <option value="0">-- Seleccione un tipo de orden --</option>
                            <option value="1">Público</option>
                            <option value="2">Garantías</option>
                            <option value="3">Seguros</option>
                            <option value="4">Previas</option>
                            <option value="5">Internas</option>
                            <option value="6">Público y Garantías</option>
                            <option value="7">Público y Seguros</option>
                        </select>
                    </div>
                </div>
                <div id="DvButtons" class="panel">
                    <div class="row">
                        <div class="button active" id="BtnSearch"><div>BUSCAR</div></div>                    
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
