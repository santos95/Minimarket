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
    public partial class FrmAnulacionCompra : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static FrmAnulacionCompra _Instancia;
        //Clase de validacion para cajas de texto
        Validacion v = new Validacion();
        public static FrmAnulacionCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmAnulacionCompra();
            }
            return _Instancia;
        }

        public void setCompra(string idcompra, string idpersona)
        {
            this.txtIdCompra.Text = idcompra;
            this.txtCompra.Text = idpersona;
        }

        public FrmAnulacionCompra()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cbIdPersona, "Seleccione al proveedor");
            this.ttMensaje.SetToolTip(this.txtCompra, "Busque la compra correcta");
            this.ttMensaje.SetToolTip(this.txtObservacion, "Digitar una observacion");
            this.ttMensaje.SetToolTip(this.dtFechaAnulacion, "Seleccione la fecha correspondiente");
            this.ttMensaje.SetToolTip(this.cbEstado, "Seleccione el estado de la anulacion");

            this.LlenarComboPersona();
            this.txtIdCompra.Visible = false;
            this.txtCompra.ReadOnly = true;
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {

            this.txtIdCompra.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtIdCompraAnular.ReadOnly = !valor;
            this.txtIdCompra.Enabled = valor;
            this.cbIdPersona.Enabled = valor;
            this.txtObservacion.ReadOnly = !valor;
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
            this.dataListado.DataSource = NAnularCompra.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarCompraAnulada()
        {
            this.dataListado.DataSource = NAnularCompra.BuscarCompraAnulada(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void LlenarComboPersona()
        {
            cbIdPersona.DataSource = NPersona.Mostrar();
            cbIdPersona.ValueMember = "id_persona";
            cbIdPersona.DisplayMember = "nombre_pers_empresa";

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtObservacion.Focus();
        }

        private void FrmAnulacionCompra_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarCompraAnulada();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarCompraAnulada();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtObservacion.Text == string.Empty || this.cbEstado.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtObservacion, "Ingrese un Valor");
                    errorIcono.SetError(cbEstado, "Ingrese un Valor");
                }
                else
                {



                    if (this.IsNuevo)
                    {
                        rpta = NAnularCompra.Insertar(Convert.ToInt32(this.cbIdPersona.SelectedValue),
                            Convert.ToInt32(this.txtIdCompra.Text), dtFechaAnulacion.Value,this.txtObservacion.Text,
                            cbEstado.Text);

                    }
                    else
                    {
                        rpta = NAnularCompra.Editar(Convert.ToInt32(this.txtIdCompraAnular.Text), Convert.ToInt32(this.cbIdPersona.SelectedValue),
                            Convert.ToInt32(this.txtIdCompra.Text), dtFechaAnulacion.Value, this.txtObservacion.Text,
                            cbEstado.Text);
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

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            FrmVistasCompra_Anular form = new FrmVistasCompra_Anular();
            form.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtObservacion.Text.Equals(""))
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
        private void frmCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
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
            this.txtIdCompraAnular.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_compra_anular"].Value);
            this.cbIdPersona.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_persona"].Value);
            this.txtCompra.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_compra"].Value);
            this.dtFechaAnulacion.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_anulacion"].Value);
            this.txtObservacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["obcervacion"].Value);
            this.cbEstado.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["estado"].Value);
            this.tabControl1.SelectedIndex = 1;
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
                            Rpta = NAnularCompra.Eliminar(Convert.ToInt32(Codigo));

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

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text != "" || cbEstado.Text != "")
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
