using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebApplication1
{
    public partial class Carrito : System.Web.UI.Page
    {

        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            Sesion sesion = new Sesion();

            RepCarrito.DataSource = sesion.ListadeCarrito();
            RepCarrito.DataBind();

            float total = 0;

            foreach (var item in sesion.ListadeCarrito())
            {
                total += item.precio;
            }

            lblTotal.Text = total.ToString();

       
      
        
          }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Sesion sesion = new Sesion();
            CarritoNegocio negocio = new CarritoNegocio();

            string valor = ((Button)sender).CommandArgument;
            sesion.EliminarId(int.Parse(valor));
            //RepCarrito.DataSource = sesion.ListadeCarrito();
            //RepCarrito.DataBind();


            sesion.ArticuloEliminarEnSession(int.Parse(valor));


        }

        protected void Button1_Click(object sender, EventArgs e)
        {









        }


        protected void btnMostrarMensaje_Click(object sender, EventArgs e)
        {

            Sesion ses = new Sesion();
            CarritoNegocio carneg = new CarritoNegocio();


            if (ses.CantSession() > 0)
            {

                string mensaje = "COMPRA EXITOSA";
                lblMensaje.Text = mensaje;

                ses.ListadeCarrito().Clear();
                


            }
            else
            {
                string mensaje = "TU CARRITO ESTA VACIO, COMPRA RECHAZADA";
                lblMensaje.Text = mensaje;

            }
        }


















        protected void RepCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            Sesion sesion = new Sesion();
            CarritoNegocio negocio = new CarritoNegocio();

            string valor = ((Button)source).CommandArgument;
            sesion.AgregarId(int.Parse(valor));
            negocio.AgregarAlCarrito(int.Parse(valor));

            sesion.ArticuloASession(int.Parse(valor));




        }

        protected void btnMas_Click(object sender, EventArgs e)
        {

            lblMensaje.Text = "ERROR AL MODIFICAR CANTIDAD";
            
        }
    } 
}