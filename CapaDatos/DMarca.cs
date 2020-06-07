using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DMarca
    {
        //variables
        private int _id_marca;
        private string _Marca_producto;
        private string _TextoBuscar;

        public int Id_marca
        {
            get { return _id_marca; }

            set { _id_marca = value; }
        }

        public string Marca_producto
        {
            get { return _Marca_producto; }

            set { _Marca_producto = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        public DMarca()
        {

        }

        public DMarca(int id_marca, string Marca_Producto, string textoBuscar)
        {
            this.Id_marca = id_marca;
            this.Marca_producto = Marca_producto;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DMarca Marca)
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
                SqlCmd.CommandText = "spinsertar_marca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Parid_Marca = new SqlParameter();
                Parid_Marca.ParameterName = "@id_marca";
                Parid_Marca.SqlDbType = SqlDbType.Int;
                Parid_Marca.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(Parid_Marca);

                SqlParameter ParMarcaproducto = new SqlParameter();
                ParMarcaproducto.ParameterName = "@Marca_Producto";
                ParMarcaproducto.SqlDbType = SqlDbType.NVarChar;
                ParMarcaproducto.Size = 50;
                ParMarcaproducto.Value = Marca.Marca_producto;
                SqlCmd.Parameters.Add(ParMarcaproducto);
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

        public string Editar(DMarca Marca)
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
                SqlCmd.CommandText = "speditar_marca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Parid_Marca = new SqlParameter();
                Parid_Marca.ParameterName = "@id_marca";
                Parid_Marca.SqlDbType = SqlDbType.Int;
                Parid_Marca.Value = Marca.Id_marca;
                SqlCmd.Parameters.Add(Parid_Marca);

                SqlParameter ParMarcaproducto = new SqlParameter();
                ParMarcaproducto.ParameterName = "@Marca_Producto";
                ParMarcaproducto.SqlDbType = SqlDbType.NVarChar;
                ParMarcaproducto.Size = 50;
                ParMarcaproducto.Value = Marca.Marca_producto;
                SqlCmd.Parameters.Add(ParMarcaproducto);


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

        public string Eliminar(DMarca Marca)
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
                SqlCmd.CommandText = "speliminar_marca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdmarca = new SqlParameter();
                ParIdmarca.ParameterName = "@id_marca";
                ParIdmarca.SqlDbType = SqlDbType.Int;
                ParIdmarca.Value = Marca.Id_marca;
                SqlCmd.Parameters.Add(ParIdmarca);


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
            DataTable DtResultado = new DataTable("marca");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_marca";
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
        public DataTable BuscarMarca(DMarca Marca)
        {
            DataTable DtResultado = new DataTable("marca");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_marca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Marca.TextoBuscar;
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
