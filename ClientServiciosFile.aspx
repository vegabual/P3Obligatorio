<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientServiciosFile.aspx.cs" Inherits="InterfazWeb.ClientServiciosFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>CREAR ARCHIVO DE SERVICIOS</p>
    <div>
            <asp:Button ID="btnCrearFile" runat="server" Text="Crear archivo" OnClick="btnCrearFile_Click"></asp:Button>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
        <br /><br />
            <section id="mensajes">
                <asp:Label ID="LblMensajes" runat="server" Text=""></asp:Label>
            </section>
    </div>
</asp:Content>
