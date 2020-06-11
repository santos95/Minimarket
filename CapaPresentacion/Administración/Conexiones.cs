using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Administración
{
    public partial class Conexiones : Form
    {

        int idConexion;
        char estado;

        DataDataContext cnLinq = new DataDataContext();

        public Conexiones()
        {
            InitializeComponent();
        }

        private void Conexiones_Load(object sender, EventArgs e)
        {

            //Filtro por defecto
            rbtnTodos.Select();

        }

        private void TotalRegistros()
        {
            int registros = dataListado.Rows.Count;
            this.lblTotal.Text = "Total de Registros: " + registros;

        }

        private void ListarTodos()
        {

            dataListado.DataSource = cnLinq.spMostrarHistorialAcceso();
            TotalRegistros();

        }


        private void FrmControlAcceso_Load(object sender, EventArgs e)
        {

            //Listar todos el historial - Investigar como paginar para no dañar el rendimiento
            ListarTodos();

            //Filtro todos por defecto
            rbtnTodos.Select();

         

        }

        
        private void rbtnBloqueados_CheckedChanged(object sender, EventArgs e)
        {
            dataListado.DataSource = cnLinq.spMostrarHistorialBloqueado();
            TotalRegistros();

        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            ListarTodos();
        }

        private void rbtnConectados_CheckedChanged(object sender, EventArgs e)
        {
            dataListado.DataSource = cnLinq.spMostrarHistorialConectado();
            TotalRegistros();
        }

        private void rbtnDesconectados_CheckedChanged(object sender, EventArgs e)
        {
            dataListado.DataSource = cnLinq.spMostrarHistorialDesconectado();
            TotalRegistros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtBuscar.Text != "")
            {

                if (rbtnTodos.Checked)
                    dataListado.DataSource = cnLinq.spBuscarConexion(txtBuscar.Text, 0);
                else if (rbtnBloqueados.Checked)
                    dataListado.DataSource = cnLinq.spBuscarConexion(txtBuscar.Text, 1);
                else if (rbtnConectados.Checked)
                    dataListado.DataSource = cnLinq.spBuscarConexion(txtBuscar.Text, 2);
                else if (rbtnDesconectados.Checked)
                    dataListado.DataSource = cnLinq.spBuscarConexion(txtBuscar.Text, 3);

            }
            else
            {

                if (rbtnTodos.Checked)
                    dataListado.DataSource = cnLinq.spMostrarHistorialAcceso();
                else if (rbtnBloqueados.Checked)
                    dataListado.DataSource = cnLinq.spMostrarHistorialBloqueado();
                else if (rbtnConectados.Checked)
                    dataListado.DataSource = cnLinq.spMostrarHistorialConectado();
                else if (rbtnDesconectados.Checked)
                    dataListado.DataSource = cnLinq.spMostrarHistorialDesconectado();

            }

        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Tiene datos sin guardar, desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                this.Close();

            }

        }
    }
}
