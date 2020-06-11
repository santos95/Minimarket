﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CapaDatos.GestionNegocio
{
    public class TasaCambio
    {

        int IDtasa { get; set; }
        float ValorCambio { get; set; }
        DateTime FechaRegistro { get; set; }
        DataTable valores = new DataTable();


        public TasaCambio()
        {

        }

        public TasaCambio(float valorCambio, DateTime fechaRegistro)
        {
            ValorCambio = valorCambio;
            FechaRegistro = fechaRegistro;
        }

        public DataTable Importar(string ruta)
        {
            
            OleDbConnection con;
            OleDbDataAdapter dtAdap;


            try
            {
                //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\myFolder\myOldExcelFile.xls;Extended Properties="Excel 8.0;HDR=YES
                //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\myFolder\myOldExcelFile.xls;Extended Properties="Excel 8.0;HDR=YES";
                /* con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties='Excel 12.0 xml; HDR = YES'");
                dtAdap = new OleDbDataAdapter("SELECT * FROM  [Archivo]", con);
                dtAdap.Fill(dt);*/
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=\"Excel 8.0; HDR = Yes\"");
                con.Open();

                string sheet = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["Table_Name"].ToString();

               valores.Columns.AddRange(new DataColumn[2] { new DataColumn ("Fecha", typeof(DateTime)),
                  new DataColumn("Córdobas por USD", typeof(decimal)) });

                // dtAdap = new OleDbDataAdapter("SELECT * FROM  [Archivo$A1:B]", con);
                dtAdap = new OleDbDataAdapter("SELECT * FROM [" + sheet + "]", con);
                dtAdap.Fill(valores);

                con.Close();
            }
            catch
            {

                valores = null;


            }

            return valores;

        }

        public string Guardar()
        {
            string rpta = "";

            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Administracion.Conexion.Cn;
                //sqlCon.Open();
                sqlCon.Open();

                SqlBulkCopy exportar = new SqlBulkCopy(sqlCon);
                exportar.DestinationTableName = "dbo.tblTasaCambio";
                exportar.ColumnMappings.Add("Fecha", "dtFechaVigencia");
                exportar.ColumnMappings.Add("Córdobas por USD", "flValorCambio");

                
                exportar.WriteToServer(valores);
                sqlCon.Close();

                rpta = "Se realizó la exportación.";

                /*
                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spInsertarTasa",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parFecha = new SqlParameter
                {

                    ParameterName = "@fecha",
                    DbType = DbType.Date,
                    Value = fecha

                };

                sqlCmd.Parameters.Add(parFecha);


                SqlParameter parValor = new SqlParameter
                {

                    ParameterName = "@valor",
                    DbType = DbType.Decimal,
                    Value = valor

                };

                sqlCmd.Parameters.Add(parValor);

                sqlCmd.ExecuteNonQuery();
                */
            }


            catch (Exception ex)
            {

                rpta = ex.ToString();

            }

            return rpta;
        }


    }
}
