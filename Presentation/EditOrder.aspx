<%@ Page Title="" Language="C#" MasterPageFile="~/Edit.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="PlannerWeb.EditOrder" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- Script -->
    <script src="Scripts/Pages/EditOrder.js" type="text/javascript"></script>
    <!-- Css -->
    <link href="Css/Pages/EditOrders.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="ContentEditTitle" ContentPlaceHolderID="ContentPlaceHolderEditTitle" runat="server">
 <div>Editar Ordenes</div>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">    
<input type="hidden" id="ReturnUrl" name="ReturnUrl"  value="<%=ReturnUrl %>"/>
    <div class="row">
        <div class="inputdescription">
            <label>Tipo de orden:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtOrderType" value="<%=C.OrderToSave.OrderType %>" disabled="disabled" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>No. de orden:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtOrderNum" value="<%=C.OrderToSave.OrderNumber %>" disabled="disabled" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Fecha de ingreso:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtEntryDate" name="EntryDate" value="<%=C.OrderToSave.EntryDate.ToShortDateString() %>" disabled="disabled" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Fecha promesa:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtPromiseDate" name="PromiseDate" value="<%=C.OrderToSave.PromiseDate.ToShortDateString() %>" disabled="disabled"/>
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Fecha promesa 2:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtPromiseDate2" name="PromiseDate2" value="<%=C.OrderToSave.PromiseDate2.ToShortDateString() %>" disabled="disabled"/>
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Cliente:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtClient" value="<%=C.OrderToSave.Client %>" disabled="disabled" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Vehículo:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtVehicle" value="<%=C.OrderToSave.Vehicle %>" disabled="disabled" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Placas:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtPlates" value="<%=C.OrderToSave.Plates %>" disabled="disabled"/>
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Días de estancia:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtStayDay" value="<%=C.OrderToSave.StayDays %>" disabled="disabled" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Estatus:</label>
        </div>
        <div class="input">
            <select id="SlcStatus" disabled="disabled">
                <option value="1">Calidad</option>
                <option value="2">Otros</option>
                <option value="3">Simón</option>
            </select>            
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Días para entrega:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtDeliverDay" value="<%=C.OrderToSave.DeliveryDays %>" disabled="disabled" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Asesor:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtAsessor" name="Asessor" value="<%=C.OrderToSave.Asessor %>" disabled="disabled" />
        </div>
    </div>

    <div class="row">
        <div class="inputdescription">
            <label>Teléfono celular:</label>
        </div>
        <div class="input">
            <input type="text" id="TxtPhone" name="Phone" value="<%=C.OrderToSave.CellPhone  %>" />
        </div>
    </div>

    <div class="row smsbox">
        <div class="inputdescription">
            <label>Mensaje SMS:</label>
        </div>
        <div class="input">            
            <textarea id="TxtSms" name="Sms" cols="50" rows="4" maxlength="<%=SmsLength %>"><%=C.OrderToSave.Sms %></textarea>
            <div class="button active" id="BtnSendMessage"><div>ENVIAR</div></div>
        </div>
    </div>

    <div class="row actions">
        <%--<div class="button active" id="BtnSaveOrder"><div>GUARDAR</div></div>--%>
        <div class="button active cancel" id="BtnCancel"><div>CANCELAR</div></div>
    </div>
</asp:Content>
