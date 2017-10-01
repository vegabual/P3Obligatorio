<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientProveedorXRut.aspx.cs" Inherits="InterfazWeb.ClientProveedorXRut" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>PROVEEDOR POR RUT</p>
    <div>
        <label for="txtRut">Ingrese RUT</label>
            <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
        <br /><br />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
        <br /><br />
            <section id="mensajes">
                <asp:Label ID="LblMensajes" runat="server" Text=""></asp:Label>
            </section>
    </div>
</asp:Content>