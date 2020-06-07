using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
   public class NContactoProv
    {
        public static string Insertar(string nombre, int celular, int telefono,string descripcion, string email, string estado)
        {
            DContactoProv Obj = new DContactoProv();
            Obj.Nombre=nombre;
            Obj.Celular = celular;
            Obj.Telefono = telefono;
            Obj.Descripcion = descripcion;
            Obj.Email = email;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }
        public static string Editar(int id_contactoProv, string nombre, int celular, int telefono,string descripcion, string email, string estado)
        {
            DContactoProv Obj = new DContactoProv();
            Obj.IdContactoProvedor = id_contactoProv;
            Obj.Nombre = nombre;
            Obj.Celular = celular;
            Obj.Telefono = telefono;
            Obj.Descripcion = descripcion;
            Obj.Email = email;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int id_contactoProv)
        {
            DContactoProv Obj = new DContactoProv();
            Obj.IdContactoProvedor = id_contactoProv;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DContactoProv().Mostrar();
        }

        public static DataTable BuscarContacto(string textobuscar)
        {
            DContactoProv Obj = new DContactoProv();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarContacto(Obj);
        }
    }
}
