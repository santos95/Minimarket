using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPersona
    {
        private int _IdPersona;
        private string _CedulaRuc;
        private string _NombrePersEmpresa;
        private string _ApellidoRazonSocial;
        private DateTime _FechaNacFechaConst;
        private int _Telefono;
        private string _Direccion;
        private string _TextoBuscar;
 

        public int IdPersona
        {
            get
            {
                return _IdPersona;
            }

            set
            {
                _IdPersona = value;
            }
        }

        public string CedulaRuc
        {
            get
            {
                return _CedulaRuc;
            }

            set
            {
                _CedulaRuc = value;
            }
        }

        public string NombrePersEmpresa
        {
            get
            {
                return _NombrePersEmpresa;
            }

            set
            {
                _NombrePersEmpresa = value;
            }
        }

        public string ApellidoRazonSocial
        {
            get
            {
                return _ApellidoRazonSocial;
            }

            set
            {
                _ApellidoRazonSocial = value;
            }
        }

        public DateTime FechaNacFechaConst
        {
            get
            {
                return _FechaNacFechaConst;
            }

            set
            {
                _FechaNacFechaConst = value;
            }
        }

        public int Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }

        public DPersona()
        {

        }

        public DPersona(int id_persona, string cedula_ruc, string nombre_pers_empresa, string apellido_razonsocial, DateTime fechanac_fechaconst, int telefono, string direccion, string textobuscar)
        {
            this.IdPersona = id_persona;
            this.CedulaRuc = cedula_ruc;
            this.NombrePersEmpresa = nombre_pers_empresa;
            this.ApellidoRazonSocial = apellido_razonsocial;
            this.FechaNacFechaConst = fechanac_fechaconst;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.TextoBuscar = textobuscar;
            
        }

        public string Insertar(DPersona Persona)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCodpersona = new SqlParameter();
                ParCodpersona.ParameterName = "@id_persona";
                ParCodpersona.SqlDbType = SqlDbType.Int;
                ParCodpersona.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCodpersona);

                SqlParameter ParcedulaRuc = new SqlParameter();
                ParcedulaRuc.ParameterName = "@cedula_ruc";
                ParcedulaRuc.SqlDbType = SqlDbType.VarChar;
                ParcedulaRuc.Size = 50;
                ParcedulaRuc.Value = Persona.CedulaRuc;
                SqlCmd.Parameters.Add(ParcedulaRuc);

                SqlParameter Parnombrepersempresa = new SqlParameter();
                Parnombrepersempresa.ParameterName = "@nombre_pers_empresa";
                Parnombrepersempresa.SqlDbType = SqlDbType.VarChar;
                Parnombrepersempresa.Size = 50;
                Parnombrepersempresa.Value = Persona.NombrePersEmpresa;
                SqlCmd.Parameters.Add(Parnombrepersempresa);

                SqlParameter Parapellidorazonsocial = new SqlParameter();
                Parapellidorazonsocial.ParameterName = "@apellido_razonsocial";
                Parapellidorazonsocial.SqlDbType = SqlDbType.NVarChar;
                Parapellidorazonsocial.Size = 50;
                Parapellidorazonsocial.Value = Persona.ApellidoRazonSocial;
                SqlCmd.Parameters.Add(Parapellidorazonsocial);

                SqlParameter ParFechaNacConst = new SqlParameter();
                ParFechaNacConst.ParameterName = "@fechanac_fechaconst";
                ParFechaNacConst.SqlDbType = SqlDbType.Date;
                ParFechaNacConst.Value = Persona.FechaNacFechaConst;
                SqlCmd.Parameters.Add(ParFechaNacConst);

                /* SqlParameter ParGenero = new SqlParameter();
                 ParGenero.ParameterName = "@Genero";
                 ParGenero.SqlDbType = SqlDbType.VarChar;
                 ParGenero.Size = 1;
                 ParGenero.Value = Persona.Genero;
                 SqlCmd.Parameters.Add(ParGenero);*/


                /*SqlParameter ParEstadoCivilNat = new SqlParameter();
                ParEstadoCivilNat.ParameterName = "@EstadoCivilNat";
                ParEstadoCivilNat.SqlDbType = SqlDbType.VarChar;
                ParEstadoCivilNat.Size = 2;
                ParGenero.Value = Persona.EstadoCivilNat;
                SqlCmd.Parameters.Add(ParEstadoCivilNat);*/

                SqlParameter Partelefon = new SqlParameter();
                Partelefon.ParameterName = "@telefono";
                Partelefon.SqlDbType = SqlDbType.Int;
                Partelefon.Value = Persona.Telefono;
                SqlCmd.Parameters.Add(Partelefon);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 300;
                ParDireccion.Value = Persona.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public string Editar(DPersona Persona)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParCodPersona = new SqlParameter();
                ParCodPersona.ParameterName = "@id_persona";
                ParCodPersona.SqlDbType = SqlDbType.Int;
                ParCodPersona.Value = Persona.IdPersona;
                SqlCmd.Parameters.Add(ParCodPersona);

                SqlParameter ParcedulaRuc = new SqlParameter();
                ParcedulaRuc.ParameterName = "@cedula_ruc";
                ParcedulaRuc.SqlDbType = SqlDbType.VarChar;
                ParcedulaRuc.Size = 50;
                ParcedulaRuc.Value = Persona.CedulaRuc;
                SqlCmd.Parameters.Add(ParcedulaRuc);

                SqlParameter Parnombrepersempresa = new SqlParameter();
                Parnombrepersempresa.ParameterName = "@nombre_pers_empresa";
                Parnombrepersempresa.SqlDbType = SqlDbType.VarChar;
                Parnombrepersempresa.Size = 50;
                Parnombrepersempresa.Value = Persona.NombrePersEmpresa;
                SqlCmd.Parameters.Add(Parnombrepersempresa);

                SqlParameter Parapellidorazonsocial = new SqlParameter();
                Parapellidorazonsocial.ParameterName = "@apellido_razonsocial";
                Parapellidorazonsocial.SqlDbType = SqlDbType.NVarChar;
                Parapellidorazonsocial.Size = 50;
                Parapellidorazonsocial.Value = Persona.ApellidoRazonSocial;
                SqlCmd.Parameters.Add(Parapellidorazonsocial);

                SqlParameter ParFechaNacConst = new SqlParameter();
                ParFechaNacConst.ParameterName = "@fechanac_fechaconst";
                ParFechaNacConst.SqlDbType = SqlDbType.Date;
                ParFechaNacConst.Value = Persona.FechaNacFechaConst;
                SqlCmd.Parameters.Add(ParFechaNacConst);

                /* SqlParameter ParGenero = new SqlParameter();
                 ParGenero.ParameterName = "@Genero";
                 ParGenero.SqlDbType = SqlDbType.VarChar;
                 ParGenero.Size = 1;
                 ParGenero.Value = Persona.Genero;
                 SqlCmd.Parameters.Add(ParGenero);


                 SqlParameter ParEstadoCivilNat = new SqlParameter();
                 ParEstadoCivilNat.ParameterName = "@EstadoCivilNat";
                 ParEstadoCivilNat.SqlDbType = SqlDbType.VarChar;
                 ParEstadoCivilNat.Size = 2;
                 ParGenero.Value = Persona.EstadoCivilNat;
                 SqlCmd.Parameters.Add(ParEstadoCivilNat);*/


                SqlParameter Partelefon = new SqlParameter();
                Partelefon.ParameterName = "@telefono";
                Partelefon.SqlDbType = SqlDbType.Int;
                Partelefon.Value = Persona.Telefono;
                SqlCmd.Parameters.Add(Partelefon);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 300;
                ParDireccion.Value = Persona.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        public string Eliminar(DPersona Persona)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCodPersona = new SqlParameter();
                ParCodPersona.ParameterName = "@id_persona";
                ParCodPersona.SqlDbType = SqlDbType.Int;
                ParCodPersona.Value = Persona.IdPersona;
                SqlCmd.Parameters.Add(ParCodPersona);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("persona");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable BuscarNombre(DPersona Persona)
        {
            DataTable DtResultado = new DataTable("persona");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Persona.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
