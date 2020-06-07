using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;


namespace CapaNegocio
{
   public class Nproveedor
    {


        //Método Insertar que llama al método Insertar de la clase DProveedor
        //de la CapaDatos
        public static string Insertar( int id_persona, string poplitica_venta, string observacion, string sitioWeb, string estado)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.Idpersona = id_persona;
            Obj.PoliticaVenta = poplitica_venta;
            Obj.Observacion = observacion;
            Obj.SitioWeb = sitioWeb;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DProveedor
        //de la CapaDatos
        public static string Editar(int id_proveedor, int id_persona, string poplitica_venta, string observacion, string sitioWeb, string estado)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.Idproveedor = id_proveedor;
            Obj.Idpersona = id_persona;
            Obj.PoliticaVenta = poplitica_venta;
            Obj.Observacion = observacion;
            Obj.SitioWeb = sitioWeb;
            Obj.Estado = estado;

            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DProveedor
        //de la CapaDatos
        public static string Eliminar(int id_proveedor)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.Idproveedor = id_proveedor;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DProveedor
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dproveedor().Mostrar();
        }

        //Método BuscarRazon_Social que llama al método BuscarRazon_Social
        //de la clase DProveedor de la CapaDatos

        public static DataTable BuscarProveeedor(string textobuscar)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProveedor(Obj);
        }

        //Método BuscarRazon_Social que llama al método BuscarRazon_Social
        //de la clase DProveedor de la CapaDatos

        /*public static DataTable BuscarNum_Documento(string textobuscar)
        {
            Dproveedor Obj = new Dproveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
        */
    }
}
