using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos.Administracion
{
    public class Usuario
    {


        private int CodUsuario { get; set; }
        private int CodEmpleado { get; set; }
        private int CodRol { get; set; }
        private string NombreUsuario { get; set; }
        private string Contraseña { get; set; }
        private string Registrado { get; set; }
        private string Autorizado { get; set; }
        private string Observacion { get; set; }
        private char Estado { get; set; }

        public Usuario()
        {

        }

        public Usuario(int codEmpleado, int codRol, string nombreUsuario, string contraseña, string registrado, string autorizado, string observacion, char estado)
        {

            CodEmpleado = codEmpleado;
            CodRol = codRol;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Registrado = registrado;
            Autorizado = autorizado;
            Observacion = observacion;
            Estado = estado;

        }

        public Usuario(int codUsuario, int codRol, string nombreUsuario, string contraseña, string autorizado, string observacion, char estado)
        {

            this.CodUsuario = codUsuario;
            this.CodRol = codRol;
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            this.Autorizado = autorizado;
            this.Observacion = observacion;
            this.Estado = estado;

        }

        //Método para encriptar contraseña
        public string EncriptarContraseña(string contraseña)
        {

            return Encrypt.GetSHA256(contraseña);

        }




    }
}
