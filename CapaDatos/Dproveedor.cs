using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
   public class Dproveedor
    {
        private int _Idproveedor;
        private int _Idpersona;
        private string _PoliticaVenta;
        private string _Observacion;
        private string _SitioWeb;
        private string _Estado;
        private string _TextoBuscar;



        //Propiedades
        public int Idproveedor
        {
            get { return _Idproveedor; }
            set { _Idproveedor = value; }
        }

        
    

        public int Idpersona
        {
            get
            {
                return _Idpersona;
            }

            set
            {
                _Idpersona = value;
            }
        }

        public string PoliticaVenta
        {
            get
            {
                return _PoliticaVenta;
            }

            set
            {
                _PoliticaVenta = value;
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

        public string SitioWeb
        {
            get
            {
                return _SitioWeb;
            }

            set
            {
                _SitioWeb = value;
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
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        //Constructores
        public Dproveedor()
        {

        }
        public Dproveedor(int id_proveedor,int id_persona,string poplitica_venta,string observacion,string sitioWeb,string estado ,string textobuscar)
        {
            this.Idproveedor = id_proveedor;
            this.Idpersona = id_persona;
            this.PoliticaVenta = poplitica_venta;
            this.Observacion = observacion;
            this.SitioWeb = sitioWeb;
            this.Estado = estado;           
            this.TextoBuscar = textobuscar;

        }

        public string Insertar(Dproveedor Proveedor)
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
                SqlCmd.CommandText = "spinsertar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@id_proveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter ParIdPersona = new SqlParameter();
                ParIdPersona.ParameterName = "@id_persona";
                ParIdPersona.SqlDbType = SqlDbType.Int;
                ParIdPersona.Value = Proveedor.Idpersona;
                SqlCmd.Parameters.Add(ParIdPersona);

                SqlParameter ParPoliticaVenta = new SqlParameter();
                ParPoliticaVenta.ParameterName = "@politica_venta";
                ParPoliticaVenta.SqlDbType = SqlDbType.VarChar;
                ParPoliticaVenta.Size = 3;
                ParPoliticaVenta.Value = Proveedor.PoliticaVenta;
                SqlCmd.Parameters.Add(ParPoliticaVenta);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 200;
                ParObservacion.Value = Proveedor.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParSitioWeb = new SqlParameter();
                ParSitioWeb.ParameterName = "@sitioWeb";
                ParSitioWeb.SqlDbType = SqlDbType.VarChar;
                ParSitioWeb.Size = 100;
                ParSitioWeb.Value = Proveedor.SitioWeb;
                SqlCmd.Parameters.Add(ParSitioWeb);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 100;
                ParEstado.Value = Proveedor.Estado;
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

        //Método Editar
        public string Editar(Dproveedor Proveedor)
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
                SqlCmd.CommandText = "speditar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@id_proveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);


                SqlParameter ParIdPersona = new SqlParameter();
                ParIdPersona.ParameterName = "@id_persona";
                ParIdPersona.SqlDbType = SqlDbType.Int;
                ParIdPersona.Value = Proveedor.Idpersona;
                SqlCmd.Parameters.Add(ParIdPersona);

                SqlParameter ParPoliticaVenta = new SqlParameter();
                ParPoliticaVenta.ParameterName = "@politica_venta";
                ParPoliticaVenta.SqlDbType = SqlDbType.VarChar;
                ParPoliticaVenta.Size = 3;
                ParPoliticaVenta.Value = Proveedor.PoliticaVenta;
                SqlCmd.Parameters.Add(ParPoliticaVenta);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 200;
                ParObservacion.Value = Proveedor.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParSitioWeb = new SqlParameter();
                ParSitioWeb.ParameterName = "@sitioWeb";
                ParSitioWeb.SqlDbType = SqlDbType.VarChar;
                ParSitioWeb.Size = 100;
                ParSitioWeb.Value = Proveedor.SitioWeb;
                SqlCmd.Parameters.Add(ParSitioWeb);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 100;
                ParEstado.Value = Proveedor.Estado;
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

        //Método Eliminar
        public string Eliminar(Dproveedor Proveedor)
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
                SqlCmd.CommandText = "speliminar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@id_proveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);


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

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_proveedor";
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


        //Método BuscarNombre
       /* public DataTable BuscarRazon_Social(Dproveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_razon_social";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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




       /* public DataTable BuscarNum_Documento(Dproveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }*/

        public DataTable BuscarProveedor(Dproveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
