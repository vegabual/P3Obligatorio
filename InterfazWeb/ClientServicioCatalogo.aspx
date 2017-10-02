<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientServicioCatalogo.aspx.cs" Inherits="InterfazWeb.ClientServicioCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>LISTAR CATÁLOGO DE SERVICIOS</p>
    <div>
            <asp:GridView ID="grvServicios" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                    <asp:ImageField DataImageUrlField="imagen" HeaderText="Imagen">
                    </asp:ImageField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click"></asp:Button>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
        <br /><br />
            <section id="mensajes">
                <asp:Label ID="LblMensajes" runat="server" Text=""></asp:Label>
            </section>
    </div>
</asp:Content>