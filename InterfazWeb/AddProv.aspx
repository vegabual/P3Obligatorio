<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddProv.aspx.cs" Inherits="InterfazWeb.AddProv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:Label ID="Label6" runat="server" Text="REGISTRO DE PROVEEDORES"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Rut"></asp:Label>
&nbsp;<asp:TextBox ID="txtRut" runat="server" Width="118px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valNombre0" runat="server" ErrorMessage="Ingrese un rut" ControlToValidate="txtRut"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Clave"></asp:Label>
&nbsp;<asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;<asp:CustomValidator ID="valClave" runat="server" ControlToValidate="txtClave" ErrorMessage="La clave debe contener entre 8 y 15 caracteres, letras mayusculas y minusculas" OnServerValidate="valClave_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Nombre fantasia"></asp:Label>
&nbsp;<asp:TextBox ID="txtNombre" runat="server" Width="118px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valNombre" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
&nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="118px"></asp:TextBox>
            <asp:CustomValidator ID="valEmail" runat="server" ErrorMessage="Ingrese un mail valido" ControlToValidate="txtEmail" OnServerValidate="valEmail_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Telefono"></asp:Label>
&nbsp;<asp:TextBox ID="txtTel" runat="server" Width="118px"></asp:TextBox>
            <asp:CustomValidator ID="valTel" runat="server" ErrorMessage="Ingrese un telefono valido" ControlToValidate="txtTel" OnServerValidate="valTel_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <asp:GridView ID="grvServicios" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="idservicio" HeaderText="ID Servicio" />
                    <asp:BoundField DataField="NombreServicio" HeaderText="Nombre Servicio" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:CheckBox ID="chkVip" runat="server" Text="Vip" />
            <br />
            <br />
            <asp:Button ID="btnRegistro" runat="server" Text="Registrar" OnClick="btnRegistro_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
            <br />
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
</asp:Content>