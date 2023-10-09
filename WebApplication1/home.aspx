<%@ Page Title="" Language="C#" MasterPageFile="~/maestro.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication1.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 

    
    
    <div class="row row-cols-1 row-cols-md-2 g-4">

  <% foreach(dominio.Articulo articulo in listaDeProductos ) 
      { 
          
   %>     
        
        <div class="col">
    <div class="card">
      <img src="..." class="card-img-top" alt="...">
      <div class="card-body">
        <h5 class="card-title"><%: articulo.Nombre%></h5>
        <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
      </div>
    </div>
  </div>

      <%  } %>

</div>
   
    
    
    
   
</asp:Content>
