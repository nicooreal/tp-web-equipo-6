using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
    
        public  List <Articulo> listar () {
            
            
        List <Articulo> lista = new List<Articulo>();

            AccesoDatos Dat = new AccesoDatos();

            try
            {

                Dat.setearConsulta("Select a.Id as Id, a.Codigo as Codigo,a.Nombre as Nombre,a.Descripcion as Descripcion,c.Descripcion AS Categoria,m.Descripcion AS Marca,i.ImagenUrl AS UrlImagen, a.Precio as Precio from ARTICULOS as a left join IMAGENEs as i on i.IdArticulo = a.Id left join marcas as m on m.Id = a.IdMarca left join CATEGORIAS as c on c.Id = a.IdCategoria");
                Dat.ejecutarLectura();
                

                while (Dat.Lector.Read())
                {

                    Articulo art = new Articulo();
                    
                    art.Id = (int)Dat.Lector["Id"];
                    if (!(Dat.Lector["Codigo"] is DBNull)) { art.CodigoArticulo = (string)Dat.Lector["Codigo"]; }
                    if (!(Dat.Lector["Nombre"] is DBNull))  { art.Nombre = (string)Dat.Lector["Nombre"];  }
                    if (!(Dat.Lector["Descripcion"] is DBNull )) { art.Descripcion = (string)Dat.Lector["Descripcion"]; }
                    if (!(Dat.Lector["Precio"] is DBNull )) { art.Precio = (decimal)Dat.Lector["Precio"]; }
                 

                    
                    art.Categoria = new Categoria();
                    if (!(Dat.Lector["Categoria"] is DBNull )) { art.Categoria.nomCategoria = (string)Dat.Lector["Categoria"]; }
                    else
                        art.Categoria.nomCategoria = "Sin categoria";

                   art.Marca = new Marca();
                    if (!(Dat.Lector["Marca"] is DBNull )) { art.Marca.nomMarca = (string)Dat.Lector["Marca"];  }

                    else
                    art.Marca.nomMarca = "Sin Marca";


                    art.imagen = new Imagen();
                    if  (!(Dat.Lector["UrlImagen"] is DBNull)) { art.imagen.url = (string)Dat.Lector["UrlImagen"] ; }

                            lista.Add(art);
                    


                }
         
                   return lista; 


            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                Dat.cerrarConexion();
            }


        }
    
        public void agregarArticulo(Articulo nuevoArticulo)
        {

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {

                accesoDatos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)values('" + nuevoArticulo.CodigoArticulo + "','" + nuevoArticulo.Nombre + "','" + nuevoArticulo.Descripcion + "'," + nuevoArticulo.Marca.idMarca + "," + nuevoArticulo.Categoria.idCategoria + "," + nuevoArticulo.Precio + ") Insert into Imagenes (idArticulo,imagenurl) values (" + nuevoArticulo.Id + ",'" + nuevoArticulo.imagen.url + "')");
                accesoDatos.ejecutarAccion();

           
             }
            catch (Exception)
            {

                throw;
            }

            finally
            {

                accesoDatos.cerrarConexion();
            }
        }
        public void EliminarArticulo(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setParameters("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ModificarArticulo(Articulo modificar)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
               
                Datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria,  Precio = @precio  Where Id = @id");
                Datos.setParameters("@codigo", modificar.CodigoArticulo);
                Datos.setParameters("@nombre", modificar.Nombre);
                Datos.setParameters("@descripcion", modificar.Descripcion);
                Datos.setParameters("@IdMarca", modificar.Marca.idMarca);
                Datos.setParameters("@IdCategoria", modificar.Categoria.idCategoria);
                Datos.setParameters("@precio", modificar.Precio);
                Datos.setParameters("@id", modificar.Id);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }



        public int TraerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                int cont = 0;
                datos.setearConsulta("select id from ARTICULOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    cont++;
                }

                return cont + 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public List<Articulo> listarArticuloXid(string id)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select a.Id as Id, a.Codigo as Codigo,a.Descripcion as Descripcion,c.Descripcion as Categoria,m.Descripcion as Marca,a.Nombre as Nombre,a.Precio as Precio from ARTICULOS as a left join MARCAS as m on m.Id = a.IdMarca left join CATEGORIAS as c on c.Id = a.IdCategoria where a.id =  ";
                consulta += id;

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();


                if (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                   
                    else
                        aux.CodigoArticulo = (string)"sin codigo";

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    else
                        aux.Descripcion = "sin descripcion";

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.nomCategoria = (string)datos.Lector["Categoria"];
                    else
                        aux.Categoria.nomCategoria = "Sin categoria";


                    aux.Marca = new Marca();

                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.nomMarca = (string)datos.Lector["Marca"];
                    else
                        aux.Marca.nomMarca = "Sin marca";

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    else
                        aux.Nombre = "sin nombre";

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["Id"] is DBNull))
                        aux.Id = (int)datos.Lector["Id"];


                    lista.Add(aux);

                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }








    }
}
