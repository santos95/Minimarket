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
    public partial class FrmProveedor_VisatPersona : Form
    {
        public FrmProveedor_VisatPersona()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NPersona.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NPersona.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmProveedor_VisatPersona_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        /*private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmProveedor form = FrmProveedor.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["id_persona"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["cedula_ruc"].Value);

            form.setPersona(par1, par2);
            this.Hide();
        }*/

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
    }
}
