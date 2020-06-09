using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio.Administracion;

namespace CapaPresentacion.Administración
{
    public partial class FrmRoles : Form
    {

        public string usuario;
        private int IdRol = 0;
        private bool nuevo = false;
        private bool editar = false;

        public FrmRoles()
        {
            InitializeComponent();

            //set tooltips
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del rol.");
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese la descripción del rol.");
            this.ttMensaje.SetToolTip(this.cmbEstado, "Seleccione un estado.");
            this.ttMensaje.SetToolTip(this.txtBuscar, "Ingrese nombre del rol a buscar.");
            this.ttMensaje.SetToolTip(btnNuevo, "Agregar nuevo rol");
            this.ttMensaje.SetToolTip(btnGuardar, "Guardar rol.");
            this.ttMensaje.SetToolTip(btnEditar, "Editar rol");
            this.ttMensaje.SetToolTip(btnDeshacer, "Deshacer editar o agregar rol.");
            this.ttMensaje.SetToolTip(btnSalir, "Cerrar catalogo.");

        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {

            this.Top = 0;
            this.Left = 0;

            //mostrar datos en la tabla
            this.rbtnTodos.Select();
            //this.Mostrar();

            this.Habilitar(false);
            this.Botones();

            cmbEstado.Text = "Estado";

        }

        public void Botones()
        {

            if (nuevo || editar)
            {

                Habilitar(true);
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnDeshacer.Enabled = true;
                btnGuardar.Enabled = true;

            }
            else
            {

                Habilitar(false);
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnDeshacer.Enabled = false;


            }


        }

        public void Habilitar(bool valor)
        {

            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;

        }

        public void Limpiar()
        {

            txtNombre.Clear();
            txtDescripcion.Clear();
            cmbEstado.Text = "Estado";

        }

        


        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Limpiar();
            nuevo = true;
            this.Botones();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string rpta = "";

            if (txtNombre.Text != "" && txtDescripcion.Text != "" && cmbEstado.Text != "")
            {

                if (nuevo)
                {
                    //Guardar nuevo registro
                    char estado;

                    if (this.cmbEstado.SelectedIndex == 0)
                        estado = 'A';
                    else
                    {
                        estado = 'I';
                    }


                    //obtiene la respuesta de la ejecución del procedimiento.
                    rpta = CapaNegocio.Administracion.NRol.Guardar(this.txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), usuario.Trim(), estado);

                }
                else
                {
                    //Actualizar registro
                    char estado;

                    if (this.cmbEstado.SelectedIndex == 0)
                        estado = 'A';
                    else
                    {
                        estado = 'I';
                    }

                    if (IdRol != 0)
                        rpta = NRol.Actualizar(IdRol, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), estado);


                }

                //Desplegue del mensaje del resultado del procedimiento
                MessageBox.Show(rpta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Limpiar campos || actualizar listado.
                Mostrar();
                Limpiar();
                nuevo = false;
                editar = false;
                Botones();
                error.Clear();

            }
            else
            {
                //Mensaje de error por falta de campos llenados
                MessageBox.Show("Necesita ingresar datos en los campos remarcados. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                error.SetError(txtNombre, "Ingrese el nombre del rol.");
                error.SetError(txtDescripcion, "Ingrese la descripción del rol.");

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (IdRol == 0)
            {

                MessageBox.Show("Debe seleccionar un registro para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                editar = true;
                Botones();
                Habilitar(true);

            }


        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {

            nuevo = false;
            editar = false;
            Botones();
            Limpiar();
            Habilitar(false);
            error.Clear();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text != "" || txtDescripcion.Text != "")
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

        public void TotalRegistro()
        {

            int filas = tblListado.Rows.Count;
            lblTotal.Text = "Total de Registros: " + filas;

        }

        //Método para mostrar datos en la tabla.
        private void Mostrar()
        {

            this.tblListado.DataSource = NRol.Mostrar();
            TotalRegistro();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            tblListado.DataSource = NRol.BuscarNombre(this.txtBuscar.Text);
            TotalRegistro();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            tblListado.DataSource = NRol.BuscarNombre(this.txtBuscar.Text);
            TotalRegistro();

        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {

            Mostrar();

        }

        private void rbtnActivo_CheckedChanged(object sender, EventArgs e)
        {

            this.tblListado.DataSource = NRol.MostrarA();
            TotalRegistro();

        }

        private void rbtnInactivo_CheckedChanged(object sender, EventArgs e)
        {

            this.tblListado.DataSource = NRol.MostrarI();
            TotalRegistro();
        }

        private void tblListado_DoubleClick(object sender, EventArgs e)
        {

            //Obtener datos del registro seleccionado
            IdRol = Convert.ToInt32(tblListado.CurrentRow.Cells["ID"].Value);
            txtNombre.Text = Convert.ToString(tblListado.CurrentRow.Cells["Rol"].Value);
            txtDescripcion.Text = Convert.ToString(tblListado.CurrentRow.Cells["Descripción"].Value);

            //seleccionar cmbEstado
            if (Convert.ToChar(tblListado.CurrentRow.Cells["Estado"].Value) == 'A')
                cmbEstado.SelectedItem = "Activo";
            else
                cmbEstado.SelectedItem = "Inactivo";

        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text != "" || txtDescripcion.Text != "")
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
