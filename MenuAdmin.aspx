<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MenuAdmin.aspx.cs" Inherits="InterfazWeb.MenuAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Menu ID="MA" runat="server" Orientation="Vertical">
            <Items>
                <asp:MenuItem Text="Activar/Desactivar proveedor" Value="Activar/DesactivarProveedor" NavigateUrl="~/ClientDesactivarProveedor.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Crear nuevo proveedor" Value="CrearNuevoProveedor" NavigateUrl="~/ClientNuevoProveedor.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Listar proveedores" Value="Listarproveedores" NavigateUrl="~/ClientListaProveedores.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Modificar Arancel/Porcentaje" Value="ModificarArancel/Porcentaje" NavigateUrl="~/ClientModArancelYPorcentaje.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Catálogo de servicios" Value="CatalogoServicios" NavigateUrl="~/ClientServicioCatalogo.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Listar proveedor por RUT" Value="ListarProveedorXRUT" NavigateUrl="~/ClientProveedorXRut.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Crear archivo de proveedores" Value="CrearArchivoProveedores" NavigateUrl="~/ClientFileProveedores.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Crear archivo de servicios" Value="CrearArchivoServicios" NavigateUrl="~/ClientServiciosFile.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Listar proveedores (Web)" Value="ListarProvWeb" NavigateUrl="~/ListarProveedores.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
          <div><br />
          <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
      </div>
</asp:Content>