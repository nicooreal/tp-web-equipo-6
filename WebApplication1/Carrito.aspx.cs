using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Drawing.Imaging;

namespace CarritoDeCompras
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
