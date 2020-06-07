using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
   public  class DUnidad_Medida
    {
        //Variables 

        private int _IdUnidMed;
        private string _unidadmedida;
        private string _Descripcion;
        private string _TextoBuscar;

        public int IdUnidMed
        {
            get
            {
                return _IdUnidMed;
            }

            set
            {
                _IdUnidMed = value;
            }
        }

        public string unidadmedida
        {
            get
            {
                return _unidadmedida;
            }

            set
            {
                _unidadmedida = value;
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

        public DUnidad_Medida()
        {

        }

        public DUnidad_Medida(int idUnidMed, string UnidadMedida, string Descripcion, string textobuscar)
        {
            this.IdUnidMed = idUnidMed;
            this.unidadmedida = UnidadMedida;
            this.Descripcion = Descripcion;
            this.TextoBuscar = textobuscar;

        }

        public string Insertar(DUnidad_Medida Unidadmedida)
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
                SqlCmd.CommandText = "spinsertar_unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidUnidMed = new SqlParameter();
                ParidUnidMed.ParameterName = "@idUnidMed";
                ParidUnidMed.SqlDbType = SqlDbType.Int;
                ParidUnidMed.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParidUnidMed);

                SqlParameter ParstrUnidadMedida = new SqlParameter();
                ParstrUnidadMedida.ParameterName = "@strUnidadMedida";
                ParstrUnidadMedida.SqlDbType = SqlDbType.NVarChar;
                ParstrUnidadMedida.Size = 10;
                ParstrUnidadMedida.Value = Unidadmedida.unidadmedida;
                SqlCmd.Parameters.Add(ParstrUnidadMedida);

                SqlParameter ParstrDescripcion = new SqlParameter();
                ParstrDescripcion.ParameterName = "@strDescripcion";
                ParstrDescripcion.SqlDbType = SqlDbType.NVarChar;
                ParstrDescripcion.Size = 120;
                ParstrDescripcion.Value = Unidadmedida.unidadmedida;
                SqlCmd.Parameters.Add(ParstrDescripcion);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ingreso el registro";
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

        public string Editar(DUnidad_Medida Unidadmedida)
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
                SqlCmd.CommandText = "speditar_unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidUnidMed = new SqlParameter();
                ParidUnidMed.ParameterName = "@idUnidMed";
                ParidUnidMed.SqlDbType = SqlDbType.Int;
                ParidUnidMed.Value = Unidadmedida.IdUnidMed;
                SqlCmd.Parameters.Add(ParidUnidMed);

                SqlParameter ParstrUnidadMedida = new SqlParameter();
                ParstrUnidadMedida.ParameterName = "@strUnidadMedida";
                ParstrUnidadMedida.SqlDbType = SqlDbType.VarChar;
                ParstrUnidadMedida.Size = 10;
                ParstrUnidadMedida.Value = Unidadmedida.unidadmedida;
                SqlCmd.Parameters.Add(ParstrUnidadMedida);

                SqlParameter ParstrDescripcion = new SqlParameter();
                ParstrDescripcion.ParameterName = "@strDescripcion";
                ParstrDescripcion.SqlDbType = SqlDbType.VarChar;
                ParstrDescripcion.Size = 120;
                ParstrDescripcion.Value = Unidadmedida.Descripcion;
                SqlCmd.Parameters.Add(ParstrDescripcion);

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

        public string Eliminar(DUnidad_Medida Unidadmedida)
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
                SqlCmd.CommandText = "speliminar_Unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidUnidMed = new SqlParameter();
                ParidUnidMed.ParameterName = "@idUnidMed";
                ParidUnidMed.SqlDbType = SqlDbType.Int;
                ParidUnidMed.Value = Unidadmedida.IdUnidMed;
                SqlCmd.Parameters.Add(ParidUnidMed);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";

            }
            catch(Exception ex)
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
            DataTable DtResultado = new DataTable("unidad_medida");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch(Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }

        public DataTable BuscarUnidad(DUnidad_Medida Unidadmedida)
        {
            DataTable DtResultado = new DataTable("unidad_medida");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Unidadmedida.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch(Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
