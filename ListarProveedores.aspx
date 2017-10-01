﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ListarProveedores.aspx.cs" Inherits="InterfazWeb.ListarProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>LISTAR PROVEEDORES</p>
        <asp:GridView ID="grvProveedores" runat="server" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="rut"
        AllowPaging="True" PageSize="25" AutoGenerateSelectButton="True" 
            ShowHeaderWhenEmpty="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grvProveedores_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
                <emptydatatemplate>
                    No hay registros de proveedores
                </emptydatatemplate> 
            <Columns>
                <asp:BoundField DataField="Rut" HeaderText="RUT" />
                <asp:BoundField DataField="NombreFantasia" HeaderText="Nombre de Fantasía" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView><br />
    <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="false" /><br /><br />
</asp:Content>