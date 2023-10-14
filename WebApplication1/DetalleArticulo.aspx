<%@ Page Title="" Language="C#" MasterPageFile="~/maestro.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="WebApplication1.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2 class="my-4 p-3 text-center bg-primary text-light">DETALLE DEL ARTICULO</h2>




   

    <asp:GridView runat="server" AutoGenerateColumns=false ID="dgvDetalleArticulo" CssClass="table-active table dark">
    <Columns>   
        <asp:BoundField  HeaderText = "NOMBRE" DataField ="Nombre"   />
        <asp:BoundField  HeaderText = "DESCRIPCION" DataField ="Descripcion"   />
         <asp:BoundField  HeaderText = "MARCA" DataField ="Marca"   />
        <asp:BoundField  HeaderText = "CATEGORIA" DataField ="Categoria"   />
    <asp:BoundField  HeaderText = "PRECIO" DataField ="Precio"   />
    
    </Columns>
    
    
    </asp:GridView>

    <asp:Repeater ID="repImagen" runat="server">

        <ItemTemplate>
            <div class="card" style="width: 60rem;">
                <img src="<%#Eval("url")%>" class="card-img-top" alt="...">
                <div class="card-body">
                    
                </div>
            </div>

            
        </ItemTemplate>

    </asp:Repeater>



</asp:Content>
















