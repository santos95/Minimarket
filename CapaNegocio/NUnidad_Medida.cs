using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class NUnidad_Medida
    {
        public static string Insertar(string UnidadMedida, string Descripcion)
        {
            DUnidad_Medida Obj = new DUnidad_Medida();
            Obj.unidadmedida = UnidadMedida;
            Obj.unidadmedida = Descripcion;

            return Obj.Insertar(Obj);

        }

        public static string Editar(int idUnidMed, string UnidadMedida, string Descripcion)
        {
            DUnidad_Medida Obj = new DUnidad_Medida();
            Obj.IdUnidMed = idUnidMed;
            Obj.unidadmedida = UnidadMedida;
            Obj.Descripcion = Descripcion;

            return Obj.Editar(Obj);

        }

        public static string Eliminar(int idUnidMed)
        {
            DUnidad_Medida Obj = new DUnidad_Medida();
            Obj.IdUnidMed = idUnidMed;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DUnidad_Medida().Mostrar();
        }

        public static DataTable BuscarUnidad(String textobuscar)
        {
            DUnidad_Medida Obj = new DUnidad_Medida();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarUnidad(Obj); 
        }
    }
}
