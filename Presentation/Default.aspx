<%@ Page Title="" Language="C#" MasterPageFile="~/Planner.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PlannerWeb.Default" %>
<asp:Content ID="DefaultContentHead" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Pages/Login.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Pages/Default.js" type="text/javascript"></script>
    <link href="Css/Pages/Default.css" rel="stylesheet" type="text/css" />
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
    <input type="hidden" name="IsAll" id="IsAll" value="false" />
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
                        <select id="SlcService" name="SlcService">
                            <option value="0">-- Seleccione un taller --</option>
                            <%=HtmlWorkShops %>
                        </select>
                    </div>

                    <div class="row">
                        <label>Entrar como:</label>
                        <select id="SlcAccess" name="SlcAccess">
                            <option value="0">-- Seleccione el tipo de acceso --</option>
                            <%=HtmlAccessAs %>
                        </select>
                    </div>

                    <div class="row">
                        <label>Tipo de orden:</label>
                        <select id="SlcOrder" name="SlcOrder">
                            <option value="0">-- Seleccione un tipo de orden --</option>
                            <%=HtmlOrderType %>
                        </select>
                    </div>

                    <div class="row">
                        <label>Estado:</label>
                        <select id="SlcStatus" name="SlcStatus">
                            <option value="0">-- Seleccione un estado --</option>
                            <%=HtmlSituations %>
                        </select>
                    </div>

                    <div class="row">
                        <label>Asesores:</label>
                        <select id="SlcAsesors" name="SlcAsesors">
                            <option value="0">-- Seleccione un asesor --</option>
                            <%=HtmlAsesors%>
                        </select>
                    </div>

                    <div class="row">                        
                        <input type="text" id="TxtOrder_Client_Plates" name="TxtOrder_Client_Plates" />                        
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
