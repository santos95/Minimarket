using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCompras
    {
        private int _IdCompra;
        private int _IdPerosna;
        private int _IdProveedor;
        private string _Tipo_compra;
        private decimal _Subtotal;
        private float _Iva;
        private float _Total;
        private DateTime _Fecharegistro;
        private string _Estado;
        private string _TextoBuscar;

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

        public int IdPerosna
        {
            get
            {
                return _IdPerosna;
            }

            set
            {
                _IdPerosna = value;
            }
        }


        public int IdProveedor
        {
            get
            {
                return _IdProveedor;
            }

            set
            {
                _IdProveedor = value;
            }
        }
        public string Tipo_compra
        {
            get
            {
                return _Tipo_compra;
            }

            set
            {
                _Tipo_compra = value;
            }
        }
        public decimal Subtotal
        {
            get
            {
                return _Subtotal;
            }

            set
            {
                _Subtotal = value;
            }
        }



        public float Iva
        {
            get
            {
                return _Iva;
            }

            set
            {
                _Iva = value;
            }
        }

        public float Total
        {
            get
            {
                return _Total;
            }

            set
            {
                _Total = value;
            }
        }

        public DateTime Fecharegistro
        {
            get
            {
                return _Fecharegistro;
            }

            set
            {
                _Fecharegistro = value;
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

       

        public DCompras()
        {
            
        }
        public DCompras(int id_compra,int id_persona,int id_proveedor,string tipo_compra,decimal subtotal,float IVA,float total,DateTime fecharegistro,string estado,string textobuscar)
        {
            this.IdCompra = id_compra;
            this.IdProveedor = id_persona;
            this.IdProveedor = id_proveedor;
            this.Tipo_compra = tipo_compra;
            this.Subtotal = subtotal;
            this.Iva = IVA;
            this.Total = total;
            this.Fecharegistro = fecharegistro;
            this.Estado = estado;
            this.TextoBuscar = textobuscar;
        }
        public string Insertar(DCompras compras)
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
                SqlCmd.CommandText = "spinsertar_compra";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCompra = new SqlParameter();
                ParIdCompra.ParameterName = "@id_compra";
                ParIdCompra.SqlDbType = SqlDbType.Int;
                ParIdCompra.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCompra);

                SqlParameter ParIdpersona = new SqlParameter();
                ParIdpersona.ParameterName = "@id_persona";
                ParIdpersona.SqlDbType = SqlDbType.Int;
                ParIdpersona.Value = compras.IdPerosna;
                SqlCmd.Parameters.Add(ParIdpersona);

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@id_proveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = compras.IdProveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter Partipocompra = new SqlParameter();
                Partipocompra.ParameterName = "@tipo_compra";
                Partipocompra.SqlDbType = SqlDbType.VarChar;
                Partipocompra.Size = 4;
                Partipocompra.Value = compras.Tipo_compra;
                SqlCmd.Parameters.Add(Partipocompra);

                SqlParameter Parsubtotal = new SqlParameter();
                Parsubtotal.ParameterName = "@subtotal";
                Parsubtotal.SqlDbType = SqlDbType.Decimal;
                Parsubtotal.Value = compras.Subtotal;
                SqlCmd.Parameters.Add(Parsubtotal);

                SqlParameter Pariva = new SqlParameter();
                Pariva.ParameterName = "@IVA";
                Pariva.SqlDbType = SqlDbType.Float;
                Pariva.Value = compras.Iva;
                SqlCmd.Parameters.Add(Pariva);

                SqlParameter Partotal = new SqlParameter();
                Partotal.ParameterName = "@total";
                Partotal.SqlDbType = SqlDbType.Float;
                Partotal.Value = compras.Total;
                SqlCmd.Parameters.Add(Partotal);

                SqlParameter ParFecharegistro = new SqlParameter();
                ParFecharegistro.ParameterName = "@fecharegistro";
                ParFecharegistro.SqlDbType = SqlDbType.Date;
                ParFecharegistro.Size = 50;
                ParFecharegistro.Value = compras.Fecharegistro;
                SqlCmd.Parameters.Add(ParFecharegistro);

                SqlParameter Parestado = new SqlParameter();
                Parestado.ParameterName = "@estado";
                Parestado.SqlDbType = SqlDbType.VarChar;
                Parestado.Size = 1;
                Parestado.Value = compras.Estado;
                SqlCmd.Parameters.Add(Parestado);
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

        public string Editar(DCompras compras)
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
                SqlCmd.CommandText = "speditar_compra";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdCompra = new SqlParameter();
                ParIdCompra.ParameterName = "@id_compra";
                ParIdCompra.SqlDbType = SqlDbType.Int;
                ParIdCompra.Value = compras.IdCompra;
                SqlCmd.Parameters.Add(ParIdCompra);

                SqlParameter ParIdpersona = new SqlParameter();
                ParIdpersona.ParameterName = "@id_persona";
                ParIdpersona.SqlDbType = SqlDbType.Int;
                ParIdpersona.Value = compras.IdPerosna;
                SqlCmd.Parameters.Add(ParIdpersona);

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@id_proveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = compras.IdProveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter Partipocompra = new SqlParameter();
                Partipocompra.ParameterName = "@tipo_compra";
                Partipocompra.SqlDbType = SqlDbType.VarChar;
                Partipocompra.Size = 4;
                Partipocompra.Value = compras.Tipo_compra;
                SqlCmd.Parameters.Add(Partipocompra);

                SqlParameter Parsubtotal = new SqlParameter();
                Parsubtotal.ParameterName = "@subtotal";
                Parsubtotal.SqlDbType = SqlDbType.Decimal;
                Parsubtotal.Value = compras.Subtotal;
                SqlCmd.Parameters.Add(Parsubtotal);

                SqlParameter Pariva = new SqlParameter();
                Pariva.ParameterName = "@IVA";
                Pariva.SqlDbType = SqlDbType.Float;
                Pariva.Value = compras.Iva;
                SqlCmd.Parameters.Add(Pariva);

                SqlParameter Partotal = new SqlParameter();
                Partotal.ParameterName = "@total";
                Partotal.SqlDbType = SqlDbType.Float;
                Partotal.Value = compras.Total;
                SqlCmd.Parameters.Add(Partotal);

                SqlParameter ParFecharegistro = new SqlParameter();
                ParFecharegistro.ParameterName = "@fecharegistro";
                ParFecharegistro.SqlDbType = SqlDbType.Date;
                ParFecharegistro.Size = 50;
                ParFecharegistro.Value = compras.Fecharegistro;
                SqlCmd.Parameters.Add(ParFecharegistro);

                SqlParameter Parestado = new SqlParameter();
                Parestado.ParameterName = "@estado";
                Parestado.SqlDbType = SqlDbType.VarChar;
                Parestado.Size = 1;
                Parestado.Value = compras.Estado;
                SqlCmd.Parameters.Add(Parestado);

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

        public string Eliminar(DCompras compras)
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
                SqlCmd.CommandText = "speliminar_compra";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcompra = new SqlParameter();
                ParIdcompra.ParameterName = "@id_compra";
                ParIdcompra.SqlDbType = SqlDbType.Int;
                ParIdcompra.Value = compras.IdCompra;
                SqlCmd.Parameters.Add(ParIdcompra);


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
                SqlCmd.CommandText = "spmostrar_compra";
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

        public DataTable BuscarCompra(DCompras compras)
        {
            DataTable DtResultado = new DataTable("compra");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbusca_compra";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = compras.TextoBuscar;
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
