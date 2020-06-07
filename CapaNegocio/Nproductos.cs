using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;


namespace CapaNegocio
{
   public class Nproductos
    {

        public static string Insertar(string nombre, string unidad_medida, string descripcion, byte[] imagen, string codigo_barra, string marca, int categoria_articulo,   int id_presentacion)
        {
            Dproductos Obj = new Dproductos();
            Obj.Nombre = nombre;
            Obj.UnidadMedida = unidad_medida;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.CodigoBarra = codigo_barra;
            Obj.Marca = marca;
            Obj.CategoriaArticulo = categoria_articulo;
            Obj.Idpresentacion = id_presentacion;

            return Obj.Insertar(Obj);
        }
        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int id_articulo, string nombre, string unidad_medida, string descripcion, byte[] imagen, string codigo_barra, string marca, int categoria_articulo, int id_presentacion)
        {
            Dproductos Obj = new Dproductos();
            Obj.Idarticulo = id_articulo;
            Obj.Nombre = nombre;
            Obj.UnidadMedida = unidad_medida;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.CodigoBarra = codigo_barra;
            Obj.Marca = marca;
            Obj.CategoriaArticulo = categoria_articulo;
            Obj.Idpresentacion = id_presentacion;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idarticulo)
        {
            Dproductos Obj = new Dproductos();
            Obj.Idarticulo = idarticulo;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DArticulo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dproductos().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DArticulo de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            Dproductos Obj = new Dproductos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        /*public static DataTable Stock_Articulos()
        {
            return new Dproductos().Stock_Articulos();
        }*/

    }
}
