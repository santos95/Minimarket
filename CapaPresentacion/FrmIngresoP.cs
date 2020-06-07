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
    public partial class FrmIngresoP : Form
    {

        private bool IsNuevo = false;

        private bool IsEditar = false;

        Validacion v = new Validacion();
        public FrmIngresoP()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cbCedulaRuc, "Selecciones un dato");
            this.ttMensaje.SetToolTip(this.txtNombrePer, "Digite los datos en cada casilla");
            this.ttMensaje.SetToolTip(this.txtApellidoPer, "Digite los datos en cada casilla");
            this.ttMensaje.SetToolTip(this.dtFechaNacConst, "Digite los datos en cada casilla");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Digite los datos en cada casilla");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Digite los datos en cada casilla");
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
            this.cbCedulaRuc.Text = string.Empty;
            this.txtNombrePer.Text = string.Empty;
            this.txtApellidoPer.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;

        }

        private void Habilitar(bool valor)
        {
            this.cbCedulaRuc.Enabled = valor;
            this.txtNombrePer.ReadOnly = !valor;
            this.txtApellidoPer.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
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
            this.dataListado.Columns[2].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NPersona.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void BuscarNombre()
        {
            this.dataListado.DataSource = NPersona.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmIngresoP_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (txtNombrePer.Text != ""||txtApellidoPer.Text !=""||txtTelefono.Text !=""||txtDireccion.Text !="")
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cbCedulaRuc.Focus();
            this.txtNombrePer.Focus();
            this.txtApellidoPer.Focus();
            this.txtTelefono.Focus();
            this.txtDireccion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombrePer.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(cbCedulaRuc, "Ingrese un Valor");
                    errorIcono.SetError(txtNombrePer, "Ingrese un Valor");
                    errorIcono.SetError(txtApellidoPer, "Ingrese un Valor");
                    errorIcono.SetError(txtTelefono, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NPersona.Insertar(cbCedulaRuc.Text,
                            this.txtNombrePer.Text.Trim().ToUpper(),this.txtApellidoPer.Text.Trim(),
                            dtFechaNacConst.Value,Convert.ToInt32
                            (this.txtTelefono.Text),txtDireccion.Text);

                    }
                    else
                    {
                        rpta = NPersona.Editar(Convert.ToInt32(this.txtIdPersona.Text),                            cbCedulaRuc.Text,
                            this.txtNombrePer.Text.Trim().ToUpper(), this.txtApellidoPer.Text.Trim(),
                            dtFechaNacConst.Value, Convert.ToInt32
                            (this.txtTelefono.Text), txtDireccion.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se ingreso de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizo de forma correcta el registro");
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
            if (!this.txtIdPersona.Text.Equals(""))
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
            this.Habilitar(false);
            this.Limpiar();
            this.cbCedulaRuc.Text = string.Empty;
            this.txtNombrePer.Text = string.Empty;
            this.txtApellidoPer.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdPersona.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_persona"].Value);
            this.cbCedulaRuc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cedula_ruc"].Value);
            this.txtNombrePer.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_pers_empresa"].Value);
            this.txtApellidoPer.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido_razonsocial"].Value);
            this.dtFechaNacConst.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fechanac_fechaconst"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
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
                            Rpta = NPersona.Eliminar(Convert.ToInt32(Codigo));

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
    }
}
