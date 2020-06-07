using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NAnularCompra
    {
        public static string Insertar(int id_persona, int id_compra, DateTime fecha_anulacion, string obcervacion, string estado)
        {
            DAnular_Compra Obj = new DAnular_Compra();
            Obj.IdPersona = id_persona;
            Obj.IdCompra = id_compra;
            Obj.FechaAnulacion = fecha_anulacion;
            Obj.Observacion = obcervacion;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int id_compra_anular, int id_persona, int id_compra, DateTime fecha_anulacion, string obcervacion, string estado)
        {
            DAnular_Compra Obj = new DAnular_Compra();
            Obj.IdAnularCompra = id_compra_anular;
            Obj.IdPersona = id_persona;
            Obj.IdCompra = id_compra;
            Obj.FechaAnulacion = fecha_anulacion;
            Obj.Observacion = obcervacion;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int id_compra_anular)
        {
            DAnular_Compra Obj = new DAnular_Compra();
            Obj.IdAnularCompra = id_compra_anular;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DAnular_Compra().Mostrar();
        }
        public static DataTable BuscarCompraAnulada(string textobuscar)
        {
            DAnular_Compra Obj = new DAnular_Compra();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCompraAnulada(Obj);
        }
    }
}
