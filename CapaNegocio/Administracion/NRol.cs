using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos.Administracion;

namespace CapaNegocio.Administracion
{
    public class NRol
    {

        public static DataTable Mostrar()
        {
            return new Rol().Mostrar();
        }

        public static DataTable MostrarA()
        {

            return new Rol().MostrarA();

        }

        public static DataTable MostrarI()
        {

            return new Rol().MostrarI();

        }

        public static string Guardar(string rol, string descripcion, string registrado, char estado)
        {

            Rol Rol = new Rol
            {
                Nombre = rol,
                Descripcion = descripcion,
                Registrado = registrado,
                Estado = estado
            };
            return Rol.Guardar(Rol);

        }

        public static string Actualizar(int id, string rol, string descripcion, char estado)
        {

            Rol Rol = new Rol
            {

                IdRol = id,
                Nombre = rol,
                Descripcion = descripcion,
                Estado = estado

            };

            return Rol.Actualizar(Rol);
        }

        public static DataTable BuscarNombre(String textoBuscar)
        {

            Rol Rol = new Rol();
            Rol.TextoBuscar = textoBuscar;

            return Rol.BuscarNombre(Rol);

        }

    }
}
