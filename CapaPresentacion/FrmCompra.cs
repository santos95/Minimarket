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
    public partial class FrmCompra : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static FrmCompra _Instancia;
        //Clase de validacion para cajas de texto
        Validacion v = new Validacion();
        public static FrmCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmCompra();
            }
            return _Instancia;
        }
        public void setPersona(string IdPersona, string nombre_pers_empresa)
        {
            this.txtIdPersona.Text = IdPersona;
            this.txtNombreP.Text = nombre_pers_empresa;
        }
        public FrmCompra()
        {
            InitializeComponent();

           // this.ttMensaje.SetToolTip(this.cbIdPersona, "selecinar una casilla");
            this.ttMensaje.SetToolTip(this.cbIdproveedor, "Seleccione un proveedor");
            this.ttMensaje.SetToolTip(this.cbTipoCompra, "Seleccione un tipo de compra");
            this.ttMensaje.SetToolTip(this.txtsubtotal, "Dijite el monto");
            this.ttMensaje.SetToolTip(this.txtiva, "iva es del 15%");
            this.ttMensaje.SetToolTip(this.txttotal, "Dijite el total");
            this.ttMensaje.SetToolTip(this.dtFecharegistro, "Seleccione la fecha de la compra");
            this.ttMensaje.SetToolTip(this.cbEstado, "Seleccione el estado de la compra");

            //this.LlenarcomboPersona();
            this.Llenarcomboproveedor();
            this.txtIdPersona.Visible = false;
            this.txtNombreP.ReadOnly = true;
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
            this.txtsubtotal.Text = string.Empty;
            this.txtiva.Text = string.Empty;
            this.txttotal.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txtIdCompra.ReadOnly = !valor;
            this.txtIdPersona.Enabled = valor;
            //this.cbIdPersona.Enabled = valor;
            this.cbIdproveedor.Enabled = valor;
            this.cbTipoCompra.Enabled = valor;
            this.txtsubtotal.ReadOnly = !valor;
            this.txtiva.ReadOnly = !valor;
            this.txttotal.ReadOnly = !valor;
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
            this.dataListado.DataSource = Ncompras.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarNombre()
        {
            this.dataListado.DataSource = Ncompras.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        /*private void LlenarcomboPersona()
        {
            cbIdPersona.DataSource = NPersona.Mostrar();
            cbIdPersona.ValueMember = "id_persona";
            cbIdPersona.DisplayMember = "nombre_pers_empresa";
        }*/

        private void Llenarcomboproveedor()
        {
            cbIdproveedor.DataSource = Nproveedor.Mostrar();
            cbIdproveedor.ValueMember = "id_proveedor";
            cbIdproveedor.DisplayMember = "id_persona";
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtsubtotal.Focus();
            this.txtiva.Focus();
            this.txttotal.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
                this.BuscarNombre();
            
    
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtsubtotal.Text == string.Empty ||
                this.txtiva.Text == string.Empty ||
                this.txttotal.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    //errorIcono.SetError(cbIdPersona, "Seleccione un dato");
                    errorIcono.SetError(cbIdproveedor, "Seleccione un dato");
                    errorIcono.SetError(cbTipoCompra, "Seleccione un dato");
                    errorIcono.SetError(txtsubtotal, "Dijite un dato");
                    errorIcono.SetError(txtiva, "Dijite un dato");
                    errorIcono.SetError(txttotal, "Dijite un dato");
                    errorIcono.SetError(dtFecharegistro, "Seleccionar una fecha");
                    errorIcono.SetError(cbEstado, "Dijite un dato");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = Ncompras.Insertar(Convert.ToInt32(this.txtIdPersona.Text), Convert.ToInt32(this.cbIdproveedor.SelectedValue),
                            cbTipoCompra.Text, Convert.ToDecimal(this.txtsubtotal.Text), Convert.ToInt32(this.txtiva.Text), Convert.ToInt32(this.txttotal.Text)
                            ,dtFecharegistro.Value,cbEstado.Text);

                    }
                    else
                    {
                        rpta = Ncompras.Editar(Convert.ToInt32(this.txtIdCompra.Text), Convert.ToInt32(this.txtIdPersona.Text), Convert.ToInt32(this.cbIdproveedor.SelectedValue),
                            cbTipoCompra.Text, Convert.ToDecimal(this.txtsubtotal.Text), Convert.ToInt32(this.txtiva.Text), Convert.ToInt32(this.txttotal.Text)
                            ,dtFecharegistro.Value,cbEstado.Text);
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
            if (!this.txtIdCompra.Text.Equals(""))
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
            this.txtIdCompra.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_compra"].Value);
            this.txtNombreP.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_persona"].Value);
            this.cbIdproveedor.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_proveedor"].Value);
            this.cbTipoCompra.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_compra"].Value);
            this.txtsubtotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["subtotal"].Value);
            this.txtiva.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IVA"].Value);
            this.txttotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.dtFecharegistro.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecharegistro"].Value);
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
                            Rpta = Ncompras.Eliminar(Convert.ToInt32(Codigo));

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
            if (txtsubtotal.Text != "" || txttotal.Text != "")
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

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            FrmVistaCompra_Persona form = new FrmVistaCompra_Persona();
            form.ShowDialog();
        }

        private void frmpersona_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
