<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientNuevoProveedor.aspx.cs" Inherits="InterfazWeb.ClientNuevoProveedor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>INGRESAR NUEVO PROVEEDOR</p>
    <div>
        <label for="txtRut">RUT </label>
            <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
        <br /><br />
        <label for="txtClave">Clave </label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="(La clave debe contener entre 8 y 15 caracteres, letras mayusculas y minusculas)"></asp:Label>
        <br />
        <br />
        <label for="txtNombre">Nombre </label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br /><br />
        <label for="txtEmail">Email </label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br /><br />
        <label for="txtTelefono">Teléfono </label>
            <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:GridView ID="grvServicios" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Seleccionar">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="idservicio" HeaderText="ID" />
                <asp:BoundField DataField="NombreServicio" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:CheckBox ID="chkVip" runat="server" Text="Vip" />
        <br />
        <br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"></asp:Button>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
        <br /><br />
            <section id="mensajes">
                <asp:Label ID="LblMensajes" runat="server" Text=""></asp:Label>
            </section>
    </div>
</asp:Content>