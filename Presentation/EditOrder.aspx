<%@ Page Title="" Language="C#" MasterPageFile="~/Edit.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="PlannerWeb.EditOrder" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
<!-- Css -->
<link href="Css/Pages/EditOrders.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="ContentEditTitle" ContentPlaceHolderID="ContentPlaceHolderEditTitle" runat="server">
 <div>Editar Ordenes</div>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">    
    <div class="row">
        <div class="inputdescription">
            <label>Tipo de orden:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtOrderType" name="OrderType" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>No. de orden:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtNoOrder" name="NoOrder" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Fecha de ingreso:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtInDate" name="InDate" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Fecha promesa:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtPromiseDate" name="PromiseDate" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Fecha promesa 2:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtPromise2Date" name="Promise2Date" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Cliente:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtClient" name="Client" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Vehículo:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtVehicle" name="Vehicle" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Placas:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtPlates" name="Plates" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Días de estancia:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtStayDay" name="StayDay" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Estatus:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtStatus" name="Status" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Días para entrega:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtDeliverDay" name="DeliverDay" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Asesor:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtAdviser" name="Adviser" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Teléfono celular:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtPhone" name="Phone" />
        </div>
    </div>

    <div class="row smsbox">
        <div class="inputdescription">
            <label>Mensaje SMS:</label>
        </div>
        <div class="input">            
            <textarea id="TxtSms" name="Sms" cols="50" rows="4"></textarea>
            <div class="button active" id="Div2"><div>ENVIAR</div></div>
        </div>
    </div>

    <div class="row actions">
        <div class="button active" id="BtnLogIn"><div>GUARDAR</div></div>
        <div class="button active cancel" id="BtnCancel"><div>CANCELAR</div></div>
    </div>
</asp:Content>
