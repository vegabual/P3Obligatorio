﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientListaProveedores.aspx.cs" Inherits="InterfazWeb.ClientListaProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>LISTADO DE PROVEEDORES</p>
    <asp:GridView ID="grvProveedores" runat="server">
    </asp:GridView>
    <div>
        <br />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
        <br /><br />
    </div>
</asp:Content>