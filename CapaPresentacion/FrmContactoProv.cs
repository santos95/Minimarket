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
    public partial class FrmContactoProv : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmContactoProv()
        {
            InitializeComponent();

            this.ttMensaje.SetToolTip(this.txtNombre, "Dijite un nombre por favor");
            this.ttMensaje.SetToolTip(this.txtCelular, "Digite el numero celular del proveedor");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Digite el numero convencional de la empresa del proveedor");
            this.ttMensaje.SetToolTip(this.txtEmail, "Digite el correo que le proporciona el proveedor");
            this.ttMensaje.SetToolTip(this.cbEstado, "Seleccione un estado por favor");

        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpiar()
        {
            this.txtCelular.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.txtIdContactoProv.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtCelular.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cbEstado.Enabled = valor;
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NContactoProv.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarContacto()
        {
            this.dataListado.DataSource = NContactoProv.BuscarContacto(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmContactoProv_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarContacto();
        }

        private void chkEliminar_Click(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NContactoProv.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
            this.txtCelular.Focus();
            this.txtTelefono.Focus();
            this.txtDescripcion.Focus();
            this.txtEmail.Focus();
            this.cbEstado.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtCelular.Text == string.Empty || this.txtTelefono.Text == string.Empty ||this.txtDescripcion.Text == string.Empty ||this.txtEmail.Text == string.Empty || this.cbEstado.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtCelular, "Ingrese un Valor");
                    errorIcono.SetError(txtTelefono, "Ingrese un Valor");
                    errorIcono.SetError(txtEmail, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NContactoProv.Insertar(this.txtNombre.Text.Trim().ToUpper(), Convert.ToInt32(this.txtCelular.Text),
                         Convert.ToInt32(this.txtTelefono.Text),txtDescripcion.Text,txtEmail.Text,cbEstado.Text);

                    }
                    else
                    {
                        rpta = NContactoProv.Editar(Convert.ToInt32(this.txtIdContactoProv.Text), this.txtNombre.Text.Trim().ToUpper(), Convert.ToInt32(this.txtCelular.Text),
                         Convert.ToInt32(this.txtTelefono.Text), txtDescripcion.Text, txtEmail.Text, cbEstado.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdContactoProv.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtCelular.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdContactoProv.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_Contacto"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtCelular.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Celular"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            this.cbEstado.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (txtCelular.Text != "" || txtTelefono.Text != "" || txtEmail.Text != "")
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarContacto();
        }
    }
}
