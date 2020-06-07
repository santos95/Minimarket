using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using CapaNegocio;



namespace CapaPresentacion
{
    public partial class FrmVistaProveedor_ingreso : Form
    {
        public FrmVistaProveedor_ingreso()
        {
            InitializeComponent();
        }

        private void FrmVistaProveedor_ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = Nproveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            this.dataListado.DataSource = Nproveedor.BuscarProveeedor(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNum_Documento
       /* private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = Nproveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }*/

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("estado"))
            {
                this.BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("estado"))
            {
                this.BuscarRazon_Social();
            }
        }

       
        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            FrmIngreso form = FrmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["razon_social"].Value);
            form.setProveedor(par1, par2);
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
