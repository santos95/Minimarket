using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class NMarca
    {
        public static string Insertar(string Marca_producto)
        {
            DMarca Obj = new DMarca();
            Obj.Marca_producto = Marca_producto;
            return Obj.Insertar(Obj);

        }

        // Metodo Editar que llama al metodo Editar de la capa datos de la clase DMarca
        public static string Editar(int id_marca, string Marca_producto)
        {
            DMarca Obj = new DMarca();
            Obj.Id_marca = id_marca;
            Obj.Marca_producto = Marca_producto;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int id_marca)
        {
            DMarca Obj = new DMarca();
            Obj.Id_marca = id_marca;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DMarca().Mostrar();
        }

        public static DataTable BuscarMarca(string textobuscar)
        {
            DMarca Obj = new DMarca();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarMarca(Obj);
        }

    }
}
