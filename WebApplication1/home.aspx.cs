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
            AccesoDatos datos = new AccesoDatos();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                datos.setearQuery("create PROCEDURE SPlistarArticulo\r\nAS\r\nSELECT min(I.IMAGENURL)as UrlImagen, A.ID as Id,A.CODIGO as Codigo,A.NOMBRE as Nombre,A.Descripcion as Descripcion, C.Descripcion as Categoria, M.Descripcion as Marca,A.Precio as Precio\r\nfrom ARTICULOS as a\r\nleft join\r\nIMAGENES as i\r\non i.IdArticulo=a.id\r\nleft join MARCAS as m\r\non m.id=a.IdMarca\r\nleft join CATEGORIAS as c\r\non c.id=a.IdCategoria\r\ngroup by i.IdArticulo,a.Nombre,a.codigo,a.Descripcion,a.precio,a.id,c.Descripcion,m.Descripcion ");
                datos.ejecutarLectura();
                datos.cerrarConexion();

                Session.Add("listaArticulooos", negocio.listarConSP());

                ListaArticulo = (List<Articulo>)Session["listaArticulooos"];





                if (!IsPostBack)
                {
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.setearQuery("drop PROCEDURE SPlistarArticulo");
                datos.ejecutarLectura();
                datos.cerrarConexion();
            }






        }







        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string filtro = txtSearch.Text;


            List<Articulo> resultados = listaDeProductos.FindAll(prod => prod.Nombre.ToLower().Contains(filtro.ToLower())).ToList();

            repetidor.DataSource = resultados;
            repetidor.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guardar id en la sesion?? sesion.Add("id", id)
        }
    }
}