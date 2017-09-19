<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProv.aspx.cs" Inherits="InterfazWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label6" runat="server" Text="Registro de proveedores"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Rut"></asp:Label>
&nbsp;<asp:TextBox ID="txtRut" runat="server" Width="118px"></asp:TextBox>
            <asp:CustomValidator ID="valRut" runat="server" ControlToValidate="txtRut" ErrorMessage="Ingrese un rut valido" OnServerValidate="ValRut_ServerValidate" SetFocusOnError="True" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Clave"></asp:Label>
&nbsp;<asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;<asp:CustomValidator ID="valClave" runat="server" ControlToValidate="txtClave" ErrorMessage="La clave debe contener entre 8 y 15 caracteres, letras mayusculas y minusculas" OnServerValidate="valClave_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Nombre fantasia"></asp:Label>
&nbsp;<asp:TextBox ID="txtNombre" runat="server" Width="118px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valNombre" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
&nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="118px"></asp:TextBox>
            <asp:CustomValidator ID="valEmail" runat="server" ErrorMessage="Ingrese un mail valido" ControlToValidate="txtEmail" OnServerValidate="valEmail_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Telefono"></asp:Label>
&nbsp;<asp:TextBox ID="txtTel" runat="server" Width="118px"></asp:TextBox>
            <asp:CustomValidator ID="valTel" runat="server" ErrorMessage="Ingrese un telefono valido" ControlToValidate="txtTel" OnServerValidate="valTel_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <asp:CheckBox ID="chkVip" runat="server" Text="Vip" />
            <br />
            <br />
            <asp:Button ID="btnRegistro" runat="server" Text="Registrar" OnClick="btnRegistro_Click" />
            <br />
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
