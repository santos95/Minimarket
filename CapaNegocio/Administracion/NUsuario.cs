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
    }
}
