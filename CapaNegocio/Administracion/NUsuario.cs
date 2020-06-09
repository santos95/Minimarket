using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Administracion;

namespace CapaNegocio.Administracion
{
    public class NUsuario
    {
        public static string Encriptar(string contraseña)
        {

            return new Usuario().EncriptarContraseña(contraseña);

        }

        public static string CambiarCredenciales(string usuario, string contraseña, string nUsuario, string nContraseña)
        {

            return new Usuario().CambiarCredenciales(usuario, contraseña, nUsuario, nContraseña);

        }
    }
}
