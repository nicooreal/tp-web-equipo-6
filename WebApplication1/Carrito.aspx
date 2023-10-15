﻿<%@ Page  EnableEventValidation="false"    Title="" Language="C#" MasterPageFile="~/maestro.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApplication1.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <asp:Repeater ID="RepCarrito" runat="server" OnItemCommand="RepCarrito_ItemCommand">
        <ItemTemplate>
          
<div style="display: flex">
                <%--<p ><%#Eval("Id") %></p>--%>
                <h2><%#Eval("nombre") %></h2>
                <p style="padding:5px; font-size:20px"><%#Eval("marca") %></p>
                
                
                <div style="display:flex">
                    <div style="padding-left:20px;padding-right:10px; padding-bottom:5px">
                        <asp:Button ID="btnMenos" runat="server" Text=" - "  CssClass="btn btn-primary" style="" />
                    </div>
                    
                    <div  style="padding-right:5px;padding-left:10px">
                        <asp:Label ID="lblCantidad" ReadOnly="true" CommandName= tex Enabled="false" runat="server" style="width:35px;padding-top:5px;background-color:white">1</asp:Label>
                    </div>
                    <div style="padding-right:15px;padding-left:20px">
                        <asp:Button ID="btnMas" runat="server" Text=" + "  CssClass="btn btn-primary"/>
                    </div>
                    
                </div>
                
                <p style="padding-left:5px;padding-right:10px; font-size:20px">$ <%#Eval("precio") %></p>

                <div>
                    
                    <asp:Button autoPOSTBACK = "true" ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminar_Click"/>
                </div>
                
            </div>


        </ItemTemplate>

    </asp:Repeater>

        <div style="display:flex">
        <h3 style="padding:5px">TOTAL: $ </h3>
        <asp:Label ID="lblTotal" runat="server" Text="q" style="font-size:30px"></asp:Label>
    </div>


   <asp:Button ID="btnMostrarMensaje" runat="server" cssclass="btn btn-outline-success " Text="COMPRAR" OnClick="btnMostrarMensaje_Click" />
    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="badge bg-primary text-wrap fw-bold " style="width: 6rem;"></asp:Label>
</asp:Content>
