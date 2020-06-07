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
    public partial class FrmProductos : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static FrmProductos _Instancia;
        //Clase de validacion para cajas de texto
        Validacion v = new Validacion();

        public static FrmProductos GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmProductos();
            }
            return _Instancia;
        }
        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtIdcategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }

        /*public void setUnidMed(string idUnidMed, string strUnidadMedida)
        {
            this.txtIdUnidMed.Text = idUnidMed;
            this.txtUnidadMedida.Text = strUnidadMedida;
        }
        public void setMarca(string id_marca, string Marca_Producto)
        {
            this.txtIdMarca.Text = id_marca;
            this.txtMarca.Text = Marca_Producto;
        }*/

        public FrmProductos()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Artículo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la Imagen del Artículo");
            this.ttMensaje.SetToolTip(this.txtIdcategoria, "Seleccione la Categoría del Artículo");
            this.ttMensaje.SetToolTip(this.cbIdpresentacion, "Seleccione la presentación del Artículo");

            
            this.LlenarComboPresentacion();
           // this.LlenarComboMarca();
           // this.LlenarComboCategoria();
         //   this.LlenarComboUnidad();
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo_barra.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtNombreMarca.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdarticulo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.cbIdUnidad.Enabled = valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtCodigo_barra.ReadOnly = !valor;
            this.txtNombreMarca.ReadOnly = !valor;
            this.txtIdcategoria.Enabled = valor;
            this.cbIdpresentacion.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
          
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
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = Nproductos.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = Nproductos.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void LlenarComboPresentacion()
        {
            cbIdpresentacion.DataSource = Npresentacion.Mostrar();
            cbIdpresentacion.ValueMember = "id_presentacion";
            cbIdpresentacion.DisplayMember = "nombre";

        }

        /*private void LlenarComboMarca()
        {
            cbIdMarca.DataSource = NMarca.Mostrar();
            cbIdMarca.ValueMember = "id_marca";
            cbIdMarca.DisplayMember = "Marca_Producto";

        }
        /*private void LlenarComboCategoria()
        {
            cbIdCategoria.DataSource = Ncategoria.Mostrar();
            cbIdCategoria.ValueMember = "id_categoria";
            cbIdCategoria.DisplayMember = "nombrecat";

        }
     /*   private void LlenarComboUnidad()
        {
            cbIdUnidad.DataSource = NUnidad_Medida.Mostrar();
            cbIdUnidad.ValueMember = "idUnidMed";
            cbIdUnidad.DisplayMember = "strUnidadMedida";

        }*/

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
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
                if (this.txtCodigo_barra.Text == string.Empty || this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtCodigo_barra, "Ingrese un Valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();


                    if (this.IsNuevo)
                    {
                        rpta = Nproductos.Insertar(this.txtNombre.Text.Trim().ToUpper(),cbIdUnidad.Text,
                            this.txtDescripcion.Text.Trim(),imagen,txtCodigo_barra.Text,this.txtNombreMarca.Text.Trim(),
                            Convert.ToInt32(this.txtIdcategoria.Text), Convert.ToInt32(this.cbIdpresentacion.SelectedValue));

                    }
                    else
                    {
                        rpta = Nproductos.Editar(Convert.ToInt32(this.txtIdarticulo.Text),this.txtNombre.Text.Trim().ToUpper(), cbIdUnidad.Text,
                            this.txtDescripcion.Text.Trim(), imagen,txtCodigo_barra.Text,txtNombreMarca.Text,
                             Convert.ToInt32(this.txtIdcategoria.Text), Convert.ToInt32(this.cbIdpresentacion.SelectedValue));
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
            if (!this.txtIdarticulo.Text.Equals(""))
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
            this.txtIdarticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_articulo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.cbIdUnidad.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["unidadMedida"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            this.txtCodigo_barra.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo_barra"].Value);
            this.txtNombreMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["marca"].Value);
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.txtCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["categoria_articulo"].Value);
            this.cbIdpresentacion.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_presentacion"].Value);
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
                            Rpta = Nproductos.Eliminar(Convert.ToInt32(Codigo));

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
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //FrmReporteArticulos frm = new FrmReporteArticulos();
            // frm.Texto = txtBuscar.Text;
            // frm.ShowDialog();
        }

        private void frmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            FrmRp f = new FrmRp();
            f.ShowDialog();

        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmProducto_vistaCategoria form = new FrmProducto_vistaCategoria();
            form.ShowDialog();
        }

        private void btnBuscarCategoria_Click_1(object sender, EventArgs e)
        {
            FrmProducto_vistaCategoria form = new FrmProducto_vistaCategoria();
            form.ShowDialog();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        /* private void btnBusarUM_Click(object sender, EventArgs e)
         {
             FrmVistaUnidad_Medida form = new FrmVistaUnidad_Medida();
             form.ShowDialog();
         }

         private void btnBuscarMarca_Click(object sender, EventArgs e)
         {

         }
         */
        /*private void btnBuscarCategoria_Click_1(object sender, EventArgs e)
        {
            FrmProducto_vistaCategoria form = new FrmProducto_vistaCategoria();
            form.ShowDialog();
        }

       /* private void btnBuscarMarca_Click_1(object sender, EventArgs e)
        {
            FrmVista_de_Marca form = new FrmVista_de_Marca();
            form.ShowDialog();
        }*/
    }   
}
