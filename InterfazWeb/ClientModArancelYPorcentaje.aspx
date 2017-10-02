<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientModArancelYPorcentaje.aspx.cs" Inherits="InterfazWeb.ClientModArancelYPorcentaje" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>MODIFICAR ARANCEL/PORCENTAJE</p>
    <div>
        <label for="txtArancel">Ingrese arancel</label>
            <asp:TextBox ID="txtArancel" runat="server" width="70"></asp:TextBox>
        <br /><br />
        <label for="txtPorcentaje">Ingrese porcentaje</label>
            <asp:TextBox ID="txtPorcentaje" runat="server" width="70"></asp:TextBox>
        <br /><br />
            <asp:Button ID="btnModificar" runat="server" Text="Confirmar" OnClick="btnModificar_Click"></asp:Button>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
        <br /><br />
            <section id="mensajes">
                <asp:Label ID="LblMensajes" runat="server" Text=""></asp:Label>
            </section>
    </div>
</asp:Content>