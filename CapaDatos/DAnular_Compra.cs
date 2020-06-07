using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAnular_Compra
    {
        private int _IdAnularCompra;
        private int _IdPersona;
        private int _IdCompra;
        private DateTime _FechaAnulacion;
        private string _Observacion;
        private string _Estado;
        private string _TextoBuscar;

        public int IdAnularCompra
        {
            get
            {
                return _IdAnularCompra;
            }

            set
            {
                _IdAnularCompra = value;
            }
        }

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

        public int IdCompra
        {
            get
            {
                return _IdCompra;
            }

            set
            {
                _IdCompra = value;
            }
        }

        public DateTime FechaAnulacion
        {
            get
            {
                return _FechaAnulacion;
            }

            set
            {
                _FechaAnulacion = value;
            }
        }

        public string Observacion
        {
            get
            {
                return _Observacion;
            }

            set
            {
                _Observacion = value;
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

        public DAnular_Compra() { }

        public DAnular_Compra(int id_compra_anular,int id_persona,int id_compra,DateTime fecha_anulacion,string obcervacion,string estado,string textobuscar)
        {
            this.IdAnularCompra = id_compra_anular;
            this.IdPersona = id_persona;
            this.IdCompra = id_compra;
            this.FechaAnulacion = fecha_anulacion;
            this.Observacion = obcervacion;
            this.Estado = estado;
            this.TextoBuscar = textobuscar;
        }
        public string Insertar(DAnular_Compra Anulacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {//Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_compra_anulada";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcompraAnular = new SqlParameter();
                ParIdcompraAnular.ParameterName = "@id_compra_anular";
                ParIdcompraAnular.SqlDbType = SqlDbType.Int;
                ParIdcompraAnular.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcompraAnular);

                SqlParameter ParIdpersona = new SqlParameter();
                ParIdpersona.ParameterName = "@id_persona";
                ParIdpersona.SqlDbType = SqlDbType.Int;
                ParIdpersona.Value = Anulacion.IdPersona;
                SqlCmd.Parameters.Add(ParIdpersona);

                SqlParameter ParIdCompra = new SqlParameter();
                ParIdCompra.ParameterName = "@id_compra";
                ParIdCompra.SqlDbType = SqlDbType.Int;
                ParIdCompra.Value = Anulacion.IdCompra;
                SqlCmd.Parameters.Add(ParIdCompra);

                SqlParameter ParFechaAnulacion = new SqlParameter();
                ParFechaAnulacion.ParameterName = "@fecha_anulacion";
                ParFechaAnulacion.SqlDbType = SqlDbType.Date;
                ParFechaAnulacion.Value = Anulacion.FechaAnulacion;
                SqlCmd.Parameters.Add(ParFechaAnulacion);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@obcervacion";
                ParObservacion.SqlDbType = SqlDbType.NVarChar;
                ParObservacion.Size = 200;
                ParObservacion.Value = Anulacion.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter Parestado = new SqlParameter();
                Parestado.ParameterName = "@estado";
                Parestado.SqlDbType = SqlDbType.VarChar;
                Parestado.Size = 1;
                Parestado.Value = Anulacion.Estado;
                SqlCmd.Parameters.Add(Parestado);

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

        public string Editar(DAnular_Compra Anulacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {//Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_compra_anulada";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcompraAnular = new SqlParameter();
                ParIdcompraAnular.ParameterName = "@id_compra_anular";
                ParIdcompraAnular.SqlDbType = SqlDbType.Int;
                ParIdcompraAnular.Value = Anulacion.IdAnularCompra;
                SqlCmd.Parameters.Add(ParIdcompraAnular);

                SqlParameter ParIdpersona = new SqlParameter();
                ParIdpersona.ParameterName = "@id_persona";
                ParIdpersona.SqlDbType = SqlDbType.Int;
                ParIdpersona.Value = Anulacion.IdPersona;
                SqlCmd.Parameters.Add(ParIdpersona);

                SqlParameter ParIdCompra = new SqlParameter();
                ParIdCompra.ParameterName = "@id_compra";
                ParIdCompra.SqlDbType = SqlDbType.Int;
                ParIdCompra.Value = Anulacion.IdCompra;
                SqlCmd.Parameters.Add(ParIdCompra);

                SqlParameter ParFechaAnulacion = new SqlParameter();
                ParFechaAnulacion.ParameterName = "@fecha_anulacion";
                ParFechaAnulacion.SqlDbType = SqlDbType.Date;
                ParFechaAnulacion.Value = Anulacion.FechaAnulacion;
                SqlCmd.Parameters.Add(ParFechaAnulacion);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@obcervacion";
                ParObservacion.SqlDbType = SqlDbType.NVarChar;
                ParObservacion.Size = 200;
                ParObservacion.Value = Anulacion.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter Parestado = new SqlParameter();
                Parestado.ParameterName = "@estado";
                Parestado.SqlDbType = SqlDbType.VarChar;
                Parestado.Size = 1;
                Parestado.Value = Anulacion.Estado;
                SqlCmd.Parameters.Add(Parestado);

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
        public string Eliminar(DAnular_Compra Anulacion)
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
                SqlCmd.CommandText = "speliminar_compra_anular";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcompraAnular = new SqlParameter();
                ParIdcompraAnular.ParameterName = "@id_compra_anular";
                ParIdcompraAnular.SqlDbType = SqlDbType.Int;
                ParIdcompraAnular.Value = Anulacion.IdAnularCompra;
                SqlCmd.Parameters.Add(ParIdcompraAnular);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";


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
            DataTable DtResultado = new DataTable("compra");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_compra_anulada";
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

        public DataTable BuscarCompraAnulada(DAnular_Compra Anular)
        {

            DataTable DtResultado = new DataTable("anular_compra");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbusca_compra_anulada";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Anular.TextoBuscar;
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
