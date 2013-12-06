<%@ Page Title="" Language="C#" MasterPageFile="~/Planner.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PlannerWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<!-- Css -->
<link href="Css/Pages/Login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div id="DvLoginContainer">
        <div id="DvLoginContent">
            <div class="fill"></div>                
            <div id="DvInputs" class="panel">
                <div class="row">
                    <label class="title">Ingresa tu cuenta registrada.</label>
                </div>
                <div class="row">
                    <label>Nombre:</label><input type="text" id="TxtName"/>
                </div>
                <div class="row">
                    <label>Contraseña:</label><input type="password" id="TxtPassword"/>
                </div>
                <div class="row">
                    <label>Centro de costos:</label>
                    <select id="SlcCostCenter">
                        <option>-- Seleccione un centro de costos --</option>
                        <option>2</option>
                        <option>3</option>
                    </select>
                </div>
                <div class="row">
                    <input type="checkbox" id="ChkRemember" />
                    <label class="check">Recordar mi contraseña</label>
                </div>
            </div>
            <div id="DvButtons" class="panel">
                <div class="row">
                    <div class="button active" id="BtnLogIn"><div>INGRESAR</div></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
