<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientProveedorXRut.aspx.cs" Inherits="InterfazWeb.ClientProveedorXRut" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>PROVEEDOR POR RUT</p>
    <div>
        <label for="DDLProveedor">Seleccione proveedor: </label>
            <asp:DropDownList ID="DDLProveedor" runat="server" CssClass="form-control"></asp:DropDownList>
        <br /><br />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" />
        <br /><br />
            <asp:GridView ID="grvProveedores" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Rut" HeaderText="Rut" />
                    <asp:BoundField DataField="NombreFantasia" HeaderText="Nombre" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Activo" HeaderText="Activo" />
                    <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" />
                </Columns>
            </asp:GridView><br />
            <asp:GridView ID="grvServicios" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Imagen" HeaderText="Imagen" />
                </Columns>
            </asp:GridView><br />
            <section id="mensajes">
                <asp:Label ID="LblMensajes" runat="server" Text=""></asp:Label>
            </section>
    </div>
</asp:Content>