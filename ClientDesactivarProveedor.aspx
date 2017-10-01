<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientDesactivarProveedor.aspx.cs" Inherits="InterfazWeb.ClientDesactivarProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>ACTIVAR/DESACTIVAR PROVEEDOR</p>
    <div>
        <label for="DDLProveedor">Seleccione proveedor: </label>
            <asp:DropDownList ID="DDLProveedor" runat="server" CssClass="form-control"></asp:DropDownList>
        <br /><br />
        <label for="DDLActivo">Estado: </label>
            <asp:DropDownList ID="DDLProductos" runat="server" CssClass="form-control"></asp:DropDownList>
        <br /><br />
            <asp:Button ID="btnDesactivarProv" runat="server" Text="Confirmar" OnClick="btnDesactivarProv_Click"></asp:Button>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
        <br /><br />
            <section id="mensajes">
                <asp:Label ID="LblMensajes" runat="server" Text=""></asp:Label>
            </section>
    </div>
</asp:Content>