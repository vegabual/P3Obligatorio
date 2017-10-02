<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientNuevoProveedor.aspx.cs" Inherits="InterfazWeb.ClientNuevoProveedor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>INGRESAR NUEVO PROVEEDOR</p>
    <div>
        <label for="txtRut">RUT </label>
            <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
        <br /><br />
        <label for="txtClave">Clave </label>
            <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
        <br /><br />
        <label for="txtNombre">Nombre </label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br /><br />
        <label for="txtEmail">Email </label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br /><br />
        <label for="txtTelefono">Teléfono </label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        <br /><br />
        <label for="DDLVIP">VIP </label>
            <asp:DropDownList ID="DDLVIP" runat="server"></asp:DropDownList>
        <br /><br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"></asp:Button>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
        <br /><br />
            <section id="mensajes">
                <asp:Label ID="LblMensajes" runat="server" Text=""></asp:Label>
            </section>
    </div>
</asp:Content>