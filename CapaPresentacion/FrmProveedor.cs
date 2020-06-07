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
    public partial class FrmProveedor : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;
  

        private static FrmProveedor _Instancia;
        //Clase de validacion para cajas de texto
        Validacion v = new Validacion();

        public static FrmProveedor GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmProveedor();
            }
            return _Instancia;
        }
       /*public void setPersona(string id_Persona, string cedula_ruc)
        {
            this.txtIdPersona.Text = id_Persona;
            this.txtPersona.Text = cedula_ruc;
        }*/

        public FrmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cbIdpersona, "Seleccione la persona");
            this.ttMensaje.SetToolTip(this.txtObservacion, "Ingrese una observacion");
            this.ttMensaje.SetToolTip(this.txtSitioWeb, "Ingrese el sitio web del proveedor");

            

            this.LlenarComboPersona();
        }
        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {

            this.txtObservacion.Text = string.Empty;
            this.txtSitioWeb.Text = string.Empty;
            this.txtIdproveedor.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdproveedor.ReadOnly = !valor;
            this.cbIdpersona.Enabled = valor;
           this.cbPoliticaVenta.Enabled = valor;
            this.txtObservacion.ReadOnly = !valor;
            this.txtSitioWeb.ReadOnly = !valor;
            this.cbEstado.Enabled = valor;


        }

        private void LlenarComboPersona()
        {
            cbIdpersona.DataSource = NPersona.Mostrar();
            cbIdpersona.ValueMember = "id_persona";
            cbIdpersona.DisplayMember = "nombre_pers_empresa";

        }

        //Habilitar los botones
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
        private void Buscarproveedor()
        {
            this.dataListado.DataSource = Nproveedor.BuscarProveeedor(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNum_Documento
      /*  private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = Nproveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }*/

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            this.Buscarproveedor();
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
                            Rpta = Nproveedor.Eliminar(Convert.ToInt32(Codigo));

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtObservacion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.cbIdpersona.Text == string.Empty || this.txtObservacion.Text == string.Empty || this.txtSitioWeb.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtObservacion, "Ingrese un Valor");
                    errorIcono.SetError(txtSitioWeb, "Ingrese un Valor");
   
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = Nproveedor.Insertar(Convert.ToInt32(this.cbIdpersona.SelectedValue), cbPoliticaVenta.Text,
                            this.txtObservacion.Text.Trim().ToUpper(),this.txtSitioWeb.Text.Trim(),cbEstado.Text);

                    }
                    else
                    {
                        rpta = Nproveedor.Editar(Convert.ToInt32(this.txtIdproveedor.Text), Convert.ToInt32(this.cbIdpersona.SelectedValue), cbPoliticaVenta.Text,
                            this.txtObservacion.Text.Trim().ToUpper(), this.txtSitioWeb.Text.Trim(), cbEstado.Text);
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


            if (!this.txtIdproveedor.Text.Equals(""))
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
            this.txtIdproveedor.Text = string.Empty;
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
            
            this.txtIdproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_proveedor"].Value);
            this.cbIdpersona.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_persona"].Value);
            this.cbPoliticaVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["politica_venta"].Value);
            this.txtObservacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["observacion"].Value);
            this.txtSitioWeb.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sitioWeb"].Value);
            this.txtObservacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["observacion"].Value);
            this.cbEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["estado"].Value);
       
          


            this.tabControl1.SelectedIndex = 1;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text != "" ||txtSitioWeb.Text != "")
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmRProove F = new FrmRProove();
            F.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Buscarproveedor();
        }

        /*private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            FrmProveedor_VisatPersona form = new FrmProveedor_VisatPersona();
            form.ShowDialog();
        }*/
    }
}
