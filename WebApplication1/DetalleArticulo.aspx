<%@ Page Title="" Language="C#" MasterPageFile="~/maestro.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="WebApplication1.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2 style="padding: 15px">Detalles del articulo </h2>



    <asp:Label ID="LblArticulo" runat="server" Text=""></asp:Label>

    <asp:GridView runat="server" ID="dgvDetalleArticulo">
    </asp:GridView>

    <asp:Repeater ID="repImagen" runat="server">

        <ItemTemplate>
            <div class="card" style="width: 18rem;">
                <img src="<%#Eval("url")%>" class="card-img-top" alt="...">
                <div class="card-body">
                    
                </div>
            </div>

            
        </ItemTemplate>

    </asp:Repeater>



</asp:Content>
















