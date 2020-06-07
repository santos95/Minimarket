using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPersona
    {
        public static string Insertar(string cedula_ruc, string nombre_pers_empresa, string apellido_razonsocial, DateTime fechanac_fechaconst, int telefono, string direccion)
        {
            DPersona Obj = new DPersona();
            Obj.CedulaRuc = cedula_ruc;
            Obj.NombrePersEmpresa = nombre_pers_empresa;
            Obj.ApellidoRazonSocial = apellido_razonsocial;
            Obj.FechaNacFechaConst = fechanac_fechaconst;
            Obj.Telefono = telefono;
            Obj.Direccion = direccion;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int id_persona, string cedula_ruc, string nombre_pers_empresa, string apellido_razonsocial, DateTime fechanac_fechaconst, int telefono, string direccion)
        {
            DPersona Obj = new DPersona();
            Obj.IdPersona = id_persona;
            Obj.CedulaRuc = cedula_ruc;
            Obj.NombrePersEmpresa = nombre_pers_empresa;
            Obj.ApellidoRazonSocial = apellido_razonsocial;
            Obj.FechaNacFechaConst = fechanac_fechaconst;
            Obj.Telefono = telefono;
            Obj.Direccion = direccion;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int id_persona)
        {
            DPersona Obj = new DPersona();
            Obj.IdPersona = id_persona;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DPersona().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DPersona Obj = new DPersona();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);

        }
    }
}
