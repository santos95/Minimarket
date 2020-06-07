using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DContactoProv
    {
        private int _IdContactoProvedor;
        private string _Nombre;
        private int _Celular;
        private int _Telefono;
        private string _Descripcion;
        private string _Email;
        private string _Estado;
        private string _TextoBuscar;

        public int IdContactoProvedor
        {
            get
            {
                return _IdContactoProvedor;
            }

            set
            {
                _IdContactoProvedor = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public int Celular
        {
            get
            {
                return _Celular;
            }

            set
            {
                _Celular = value;
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
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
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

      

        public DContactoProv()
        {

        }

        public DContactoProv(int id_contactoProv, string nombre, int celular, int telefono,string descripcion,string email,string estado, string textobuscar)
        {
            this.IdContactoProvedor = id_contactoProv;
            this.Nombre=nombre;
            this.Celular = celular;
            this.Telefono = telefono;
            this.Descripcion = descripcion;
            this.Email = email;
            this.Estado = estado;
            this.TextoBuscar = textobuscar;
        }

        public string Insertar(DContactoProv contacto)
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
                SqlCmd.CommandText = "spinsertar_contacto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdContaPro = new SqlParameter();
                ParIdContaPro.ParameterName = "@id_Contacto";
                ParIdContaPro.SqlDbType = SqlDbType.Int;
                ParIdContaPro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdContaPro);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 200;
                ParNombre.Value = contacto.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCelular = new SqlParameter();
                ParCelular.ParameterName = "@Celular";
                ParCelular.SqlDbType = SqlDbType.Int;
                ParCelular.Value = contacto.Celular;
                SqlCmd.Parameters.Add(ParCelular);


                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = contacto.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = contacto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 80;
                ParEmail.Value = contacto.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 1;
                ParEstado.Value = contacto.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecutamos nuestro comando

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

        public string Editar(DContactoProv contacto)
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
                SqlCmd.CommandText = "speditar_contacto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdContaPro = new SqlParameter();
                ParIdContaPro.ParameterName = "@id_Contacto";
                ParIdContaPro.SqlDbType = SqlDbType.Int;
                ParIdContaPro.Value = contacto.IdContactoProvedor;
                SqlCmd.Parameters.Add(ParIdContaPro);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 200;
                ParNombre.Value = contacto.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCelular = new SqlParameter();
                ParCelular.ParameterName = "@Celular";
                ParCelular.SqlDbType = SqlDbType.Int;
                ParCelular.Value = contacto.Celular;
                SqlCmd.Parameters.Add(ParCelular);


                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = contacto.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = contacto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 80;
                ParEmail.Value = contacto.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 1;
                ParEstado.Value = contacto.Estado;
                SqlCmd.Parameters.Add(ParEstado);
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

        public string Eliminar(DContactoProv contacto)
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
                SqlCmd.CommandText = "speliminar_contacto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdContaPro = new SqlParameter();
                ParIdContaPro.ParameterName = "@id_Contacto";
                ParIdContaPro.SqlDbType = SqlDbType.Int;
                ParIdContaPro.Value = contacto.IdContactoProvedor;
                SqlCmd.Parameters.Add(ParIdContaPro);

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
            DataTable DtResultado = new DataTable("contactoproveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_contacto";
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

        public DataTable BuscarContacto(DContactoProv contacto)
        {
            DataTable DtResultado = new DataTable("contactoproveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_contacto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = contacto.TextoBuscar;
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
