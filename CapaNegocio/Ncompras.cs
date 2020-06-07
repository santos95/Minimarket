using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Ncompras
    {
        public static string Insertar(int id_persona, int id_proveedor, string tipo_compra, decimal subtotal, float IVA, float total,DateTime fecharegistro ,string estado)
        {
            DCompras Obj = new DCompras();
            Obj.IdPerosna = id_persona;
            Obj.IdProveedor = id_proveedor;
            Obj.Tipo_compra = tipo_compra;
            Obj.Subtotal = subtotal;
            Obj.Iva = IVA;
            Obj.Total = total;
            Obj.Fecharegistro = fecharegistro;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int id_compra, int id_persona, int id_proveedor, string tipo_compra, decimal subtotal, float IVA, float total, DateTime fecharegistro, string estado)
        {
            DCompras Obj = new DCompras();
            Obj.IdCompra = id_compra;
            Obj.IdPerosna = id_persona;
            Obj.IdProveedor = id_proveedor;
            Obj.Tipo_compra = tipo_compra;
            Obj.Subtotal = subtotal;
            Obj.Iva = IVA;
            Obj.Total = total;
            Obj.Fecharegistro = fecharegistro;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int id_compra)
        {
            DCompras Obj = new DCompras();
            Obj.IdCompra = id_compra;
            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DCompras().Mostrar();
        }
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCompras Obj = new DCompras();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCompra(Obj);
        }
    }
}
