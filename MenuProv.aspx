<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MenuProv.aspx.cs" Inherits="InterfazWeb.MenuProv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div>
        <asp:Label ID="lblMensaje" runat="server">No hay funcionalidades disponibles</asp:Label><br /><br />
          <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
      </div>
</asp:Content>