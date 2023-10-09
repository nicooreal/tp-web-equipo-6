using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
       
        public List<Articulo> listaDeProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
        
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            listaDeProductos = artNegocio.listar();
        }
    }
}