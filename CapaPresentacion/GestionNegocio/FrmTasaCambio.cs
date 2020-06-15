using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio.GestionNegocio;
using System.Data;

namespace CapaPresentacion.GestionNegocio
{
    public partial class FrmTasaCambio : Form
    {

        private string ruta = "";
        private bool importar = false;
   
       
     

        public FrmTasaCambio()
        {
            InitializeComponent();
        }

        private void Botones()
        {

            if (importar)
            {

                btnImportar.Enabled = false;                
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;

            }
            else
            {


                btnImportar.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;

            }

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

            //string ruta = "";
            string nombre = "";

            //Botones
            importar = true;
            Botones();

            try
            {
                OpenFileDialog openFile = new OpenFileDialog
                {
                    Filter = "Excel Files | *.xls",
                    Title = "Seleccione el archivo de Excel."
                };

                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (openFile.FileName.Equals("") == false)
                    {

                        ruta = openFile.FileName;
                        nombre = openFile.SafeFileName;

                    }
                        
                }

                //MessageBox.Show(ruta + nombre, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //DataTable dt = new DataTable("TasaCambio");

                /*
                DataSet ds = new DataSet();
                OleDbConnection con;
                OleDbDataAdapter dtAdap;

                try
                {
                    //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties='Excel 12.0 xml; HDR = YES'
                    con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +  ruta + ";Extended Properties=\"Excel 8.0; HDR = Yes\"");
                    con.Open();

                    dtAdap = new OleDbDataAdapter("SELECT * FROM  [Archivo$A1:B]", con);
                    dtAdap.Fill(ds);
                    dgvImportar.DataSource = ds.Tables[0];

                    con.Close();
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                */

                DataTable DtTasa = new DataTable();
                
                DtTasa = NTasaCambio.Importar(ruta);

                dgvImportar.DataSource = DtTasa;

                lblTotalImportar.Text = "Total de registros: "  + dgvImportar.Rows.Count;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                importar = false;
                Botones();

            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = string.Empty;


            if (importar == true)
            {
                if (ruta != "")
                {

                    if (dgvImportar.DataSource != null)
                    {

                        rpta = NTasaCambio.Guardar(ruta);

                        //Muestra el resultado de la ejecución
                        MessageBox.Show(rpta, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    }

                }
                else
                {

                    MessageBox.Show("Importe un archivo con datos de los valores de cambio para poder almacenarlos en el sistema.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                
                importar = false;
                Botones();
                dgvImportar.DataSource = null;
                lblTotalImportar.Text = "";

                //Actualiza el listado
                Mostrar();


            }


        }

        public void TotalRegistros()
        {

            lblTotal.Text = "Total de registros: " + tblListado.Rows.Count;

        }

        

        private void Mostrar()
        {

            tblListado.DataSource = NTasaCambio.MostrarTasa();
            TotalRegistros();

        }

        private void FrmTasaCambio_Load(object sender, EventArgs e)
        {

            Botones();
            Mostrar();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            //cancelar
            importar = false;
            Botones();

            dgvImportar.DataSource = null;
            ruta = string.Empty;

            lblTotalImportar.Text = "";

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            if (importar)
            {
                if (MessageBox.Show("¿Tiene datos sin guardar, desea salir?", "Advertencia",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                Close();
            }

        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if(importar)
            {
                if (MessageBox.Show("¿Tiene datos sin guardar, desea salir?", "Advertencia",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                Close();
            }
        }
    }
}
