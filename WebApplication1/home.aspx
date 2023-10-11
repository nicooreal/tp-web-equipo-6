<%@ Page Title="" Language="C#" MasterPageFile="~/maestro.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication1.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 

  <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container">
    
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
      <form class="form-inline">
 
          <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" placeholder="Search" aria-label="Search"></asp:TextBox>
       
   <asp:Button ID="btnBuscar" CssClass="btn btn-outline-success my-2 my-sm-0" runat="server" Text="Buscar prod" Onclick="btnBuscar_Click" />
      
      </form>
    </div>
  </div>
</nav>


    <div class="row row-cols-1 row-cols-md-3 g-4">     

    <asp:Repeater runat="server" ID="repetidor"   >
        <ItemTemplate>

          
           

    
    <div class="col">
    <div class="card ">
    <img src='<%# string.IsNullOrEmpty(Eval("Imagen").ToString()) ? "https://cdn.icon-icons.com/icons2/3487/PNG/512/status_magnify_negative_error_search_icon_220325.png" : Eval("Imagen").ToString() %>' alt="no se pudo cargar" class="card-img-top" />
      
      <div class="card-body ">
      
          <h5 class="card-title"><%#Eval("Nombre")%></h5>
          <p class="card-text"><%#Eval("Marca")%></p>
          <p class ="card- text" > <%#Eval("Descripcion")%> </p>
         <p class ="card- text" > <%#Eval("Categoria")%> </p>
         <p class ="card- text" > $ <%#Eval("Precio")%> </p> 
          <button class="btn btn-primary" > comprar </button> 
          

      </div>
    </div>
  </div>

       
        </ItemTemplate>
    </asp:Repeater>
</div>

   
    
    
    
   
</asp:Content>
