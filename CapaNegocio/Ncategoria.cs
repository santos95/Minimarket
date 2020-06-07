using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class Ncategoria
    {
            //Método Insertar que llama al método Insertar de la clase DCategoría
            //de la CapaDatos
            public static string Insertar(string nombre, string observacion, DateTime fecharegistro)
            {
                Dcategoria Obj = new Dcategoria();
                Obj.Nombrecat = nombre;
                Obj.Observacion = observacion;
                Obj.Fecharegistro = fecharegistro;
                return Obj.Insertar(Obj);
            }

        //Método Editar que llama al método Editar de la clase DCategoría
        //de la CapaDatos
        public static string Editar(int idcategoria, string nombrecat, string observacion,DateTime fecharegistro)
        {
            Dcategoria Obj = new Dcategoria();
            Obj.Id_categoria = idcategoria;
            Obj.Nombrecat = nombrecat;
            Obj.Observacion = observacion;
            Obj.Fecharegistro = fecharegistro;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría
        //de la CapaDatos
        public static string Eliminar(int idcategoria)
        {
            Dcategoria Obj = new Dcategoria();
            Obj.Id_categoria = idcategoria;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dcategoria().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DCategoría de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            Dcategoria Obj = new Dcategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }



    }
}
