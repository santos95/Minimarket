using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class Dproductos
    {
        private int _Idarticulo;
        private string _Nombre;
        private string _UnidadMedida;
        private string _Descripcion;
        private byte[] _Imagen;
        private string _CodigoBarra;
        private string _Marca;
        private int _CategoriaArticulo;
        private int _Idpresentacion;
        private string _TextoBuscar;

        public int Idarticulo
        {
            get { return _Idarticulo; }
            set { _Idarticulo = value; }
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
        public string UnidadMedida
        {
            get
            {
                return _UnidadMedida;
            }

            set
            {
                _UnidadMedida = value;
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

        public byte[] Imagen
        {
            get
            {
                return _Imagen;
            }

            set
            {
                _Imagen = value;
            }
        }
        public string CodigoBarra
        {
            get { return _CodigoBarra; }
            set { _CodigoBarra = value; }
        }

        public string Marca
        {
            get
            {
                return _Marca;
            }

            set
            {
                _Marca = value;
            }
        }

        public int CategoriaArticulo
        {
            get
            {
                return _CategoriaArticulo;
            }

            set
            {
                _CategoriaArticulo = value;
            }
        }

      

 

        public int Idpresentacion
        {
            get
            {
                return _Idpresentacion;
            }

            set
            {
                _Idpresentacion = value;
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

        //Constructores vacio
        public Dproductos()
        {

        }

        public Dproductos(int idarticulo, string nombre, string unidad_medida, string descripcion, byte[] imagen, string codigo_barra, string marca, int categoria_articulo, int id_presentacion, string textobuscar)
        {
            this.Idarticulo = idarticulo;
            this.Nombre = nombre;
            this.UnidadMedida = unidad_medida;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.CodigoBarra = codigo_barra;
            this.Marca = marca;
            this.CategoriaArticulo = categoria_articulo;
            this.Idpresentacion = id_presentacion;
            this.TextoBuscar = textobuscar;

        }

        //Métodos
        //Insertar
        public string Insertar(Dproductos Productos)
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
                SqlCmd.CommandText = "spinsertar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@id_articulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Productos.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParUnidadMedida = new SqlParameter();
                ParUnidadMedida.ParameterName = "@unidadMedida";
                ParUnidadMedida.SqlDbType = SqlDbType.VarChar;
                ParUnidadMedida.Size = 20;
                ParUnidadMedida.Value = Productos.UnidadMedida;
                SqlCmd.Parameters.Add(ParUnidadMedida);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Productos.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Productos.Imagen;
                SqlCmd.Parameters.Add(ParImagen);


                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo_barra";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 40;
                ParCodigo.Value = Productos.CodigoBarra;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 500;
                ParMarca.Value = Productos.CategoriaArticulo;
                SqlCmd.Parameters.Add(ParMarca);


                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@categoria_articulo";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Productos.CategoriaArticulo;
                SqlCmd.Parameters.Add(ParIdcategoria);

              

                
                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@id_presentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Productos.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

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
        public string Editar(Dproductos Productos)
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
                SqlCmd.CommandText = "speditar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@id_articulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Productos.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Productos.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParUnidadMedida = new SqlParameter();
                ParUnidadMedida.ParameterName = "@unidadMedida";
                ParUnidadMedida.SqlDbType = SqlDbType.VarChar;
                ParUnidadMedida.Size = 20;
                ParUnidadMedida.Value = Productos.UnidadMedida;
                SqlCmd.Parameters.Add(ParUnidadMedida);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Productos.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Productos.Imagen;
                SqlCmd.Parameters.Add(ParImagen);


                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo_barra";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Productos.CodigoBarra;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 500;
                ParMarca.Value = Productos.CategoriaArticulo;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@categoria_articulo";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Productos.CategoriaArticulo;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@id_presentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Productos.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

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
        public string Eliminar(Dproductos Productos)
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
                SqlCmd.CommandText = "speliminar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@id_articulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Productos.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);


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
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_articulo";
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
        public DataTable BuscarNombre(Dproductos Productos)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Productos.TextoBuscar;
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


      /*  public DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_articulos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
            
        }*/



    }
}
