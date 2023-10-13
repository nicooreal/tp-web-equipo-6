using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {


        public List<Articulo> ListaArticulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            ArticuloNegocio artNegocio = new ArticuloNegocio();
            ListaArticulo = artNegocio.listar();

        

                
            Session.Add("listaArticulooos", ListaArticulo);
            ListaArticulo = (List<Articulo>)Session["listaArticulooos"];

                if (!IsPostBack)
                {
                    repetidor.DataSource = ListaArticulo;
                    repetidor.DataBind();

                }
            }
           
                
                catch (Exception ex)
            {

                throw ex;
            }
            
          
                
           
        }






        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string filtro = txtSearch.Text;

            if (filtro != null)
            {

                List<Articulo> resultados = ListaArticulo.FindAll(prod => prod.Nombre.ToLower().Contains(filtro.ToLower())).ToList();

                repetidor.DataSource = resultados;
                repetidor.DataBind();
            }
        }



        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Sesion sesion = new Sesion();
            CarritoNegocio negocio = new CarritoNegocio();

            string valor = ((Button)sender).CommandArgument;
            sesion.AgregarId(int.Parse(valor));
             negocio.AgregarAlCarrito(int.Parse(valor));

            sesion.ArticuloASession(int.Parse(valor));
        }
    }
}