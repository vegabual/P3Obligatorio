<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="InterfazWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div>
        <asp:Login ID="login" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px"
        FailureText="Usuario y/o contraseña incorrectas" Font-Names="Verdana" Font-Size="10pt" OnAuthenticate="Login_Authenticate">
        </asp:Login><br />
          <asp:LinkButton ID="LbRegistro" Text="No estoy registrado" Command="Command" CommandArgument="CommandArgument" OnClick="LinkButton_Register" runat="server"/>
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
      </div>
</asp:Content>