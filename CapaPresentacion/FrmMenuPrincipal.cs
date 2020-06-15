using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;//manda a llmar los recursos del process.stark


namespace CapaPresentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        public string Cod_trabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public int Acceso;
        public string usuario;
        LoginDataContext conexionLinq = new LoginDataContext();
        public float tasa { set; get; }

        



        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.iconminimizar, "Minimizar");
            this.ttMensaje.SetToolTip(this.iconcerrar, "Cerrar");
            this.ttMensaje.SetToolTip(this.btnMenu, "Minimizar iconos");
            //this.ttMensaje.SetToolTip(this.pictureBox1, "Cerrar sesion ");
            this.ttMensaje.SetToolTip(this.btnMcaja, "Despleglar modulos de caja");
            this.ttMensaje.SetToolTip(this.btnaperturacaja, "Abrir caja");

            //
           
           
            this.lblValorTasa.Text = "C$" + tasa;

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //clase para mandar a llamar a los formularios dentro de un panel hijo

        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.StartPosition = FormStartPosition.CenterScreen;
            fh.TopLevel = false;
            fh.Dock = DockStyle.None;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

            //   btnUser.Text = usuario;
            //Permisos
            //administrador
            if (Acceso == 1)
            {

                //Módulo Caja
                btnMcaja.Enabled = false;

                //Módulo Compras
                btnMcompras.Enabled = false;

                //Módulo de venta
                btnMventas.Enabled = false;

                //Módulo gestión negocio
                btnMGestion.Enabled = true;
                btnproductos.Enabled = false;
                btnProveedor.Enabled = false;
                btnContacto.Enabled = false;
                btnMarca.Enabled = false;
                btnUnidMed.Enabled = false;
                btnPresentacion.Enabled = false;
                btnCategoria.Enabled = false;
                btnTasaCambio.Enabled = true;

                //Administración
                btnMadmin.Enabled = true;

            } //cajero
            else if (Acceso == 2)
            {

                //Módulo Caja
                btnMcaja.Enabled = true;


                //Módulo Compras
                btnMcompras.Enabled = false;

                //Módulo de venta
                btnMventas.Enabled = true;
                btnanularventa.Enabled = false;

                //Módulo gestión negocio
                btnMGestion.Enabled = true;
                btnproductos.Enabled = true;
                btnProveedor.Enabled = false;
                btnContacto.Enabled = false;
                btnMarca.Enabled = false;
                btnUnidMed.Enabled = false;
                btnPresentacion.Enabled = false;
                btnCategoria.Enabled = false;
                btnTasaCambio.Enabled = true;

                //Administración
                btnMadmin.Enabled = false;

            }//gerente
            else if (Acceso == 3)
            {

                //Módulo Caja
                btnMcaja.Enabled = true;

                //Módulo Compras
                btnMcompras.Enabled = true;

                //Módulo de venta
                btnMventas.Enabled = true;

                //Módulo gestión negocio
                btnMGestion.Enabled = true;

                //Administración
                btnMadmin.Enabled = true;
                btnroles.Enabled = false;
                btnusuario.Enabled = false;
                btnConexiones.Enabled = false;

            }//bodeguero
            else if (Acceso == 4)
            {
                //caja
                btnMcaja.Enabled = false;

                //Ventas
                btnMventas.Enabled = false;

                //Compras
                btnMcompras.Enabled = true;

                //Gestion negocio
                btnMGestion.Enabled = true;
                btnTasaCambio.Enabled = false;

                //Administracioon
                btnMadmin.Enabled = false;

            }//Supervisor venta
            else if (Acceso == 5)
            {

                //caja
                btnMcaja.Enabled = true;

                //venta
                btnMventas.Enabled = true;

                //gestion negocio
                btnMGestion.Enabled = true;
                btnProveedor.Enabled = false;
                btnContacto.Enabled = false;

                //Compras
                btnMcompras.Enabled = false;

                //Administracion
                btnMadmin.Enabled = false;
                

            }

          





        }
        private void colorClaro()
        {

            //principal
            /*panel1.BackColor = Color.FromArgb(52, 73, 94);
            panel2.BackColor = Color.FromArgb(52, 73, 94);
            pnlUser.BackColor = Color.FromArgb(52, 73, 94);
            btnCerrarSesion.BackColor = Color.FromArgb(93, 109, 126); 
            btnCerrarSesion.ForeColor = Color.FromArgb(0, 0, 0);
            */
            panel1.BackColor = Color.FromName("Control");
            panel2.BackColor = Color.FromName("Control");
            pnlUser.BackColor = Color.FromName("Control");
            btnCerrarSesion.BackColor = Color.FromName("Control");
            btnCerrarSesion.ForeColor = Color.FromName("ControlText");
            btnCredenciales.BackColor = Color.FromName("Control");
            btnCredenciales.ForeColor = Color.FromName("ControlText");
            btnUser.BackColor = Color.FromName("Control");
            btnUser.ForeColor = Color.FromName("ControlText");
            /* BarraTitulo.BackColor = Color.FromArgb(52, 73, 94);
             MenuVertical.BackColor = Color.FromArgb(255, 255, 255);
             btnMenu.BackColor = Color.FromArgb(93, 109, 126);
             */
            BarraTitulo.BackColor = Color.FromName("Control");
            MenuVertical.BackColor = Color.FromName("Control");
            btnMenu.BackColor = Color.FromArgb(93, 109, 126);

            //paneles
            pnlcaja.BackColor = Color.FromArgb(229, 232, 232);
            pnlcompras.BackColor = Color.FromArgb(229, 232, 232);
            pnlventas.BackColor = Color.FromArgb(229, 232, 232);
            btnPresentacion.BackColor = Color.FromArgb(229, 232, 232);
            pnlnegocio.BackColor = Color.FromArgb(229, 232, 232);
            pnladmin.BackColor = Color.FromArgb(229, 232, 232);

            //Btn modulos
            label1.ForeColor = Color.FromArgb(0, 0, 0);
            label2.ForeColor = Color.FromArgb(0, 0, 0);
            btnMcompras.BackColor = Color.FromName("Control");
            btnMcompras.ForeColor = Color.FromArgb(0, 0, 0);
            btnMcaja.BackColor = Color.FromName("Control");
            btnMcaja.ForeColor = Color.FromArgb(0, 0, 0);
            btnMadmin.BackColor = Color.FromName("Control");
            btnMadmin.ForeColor = Color.FromArgb(0, 0, 0);
            btnMGestion.BackColor = Color.FromName("Control");
            btnMGestion.ForeColor = Color.FromArgb(0, 0, 0);
            btnMventas.BackColor = Color.FromName("Control");
            btnMventas.ForeColor = Color.FromArgb(0, 0, 0);

            //Modulo caja
            btnaperturacaja.BackColor = Color.FromName("Control");
            btnaperturacaja.ForeColor = Color.FromArgb(0, 0, 0);
            btncierracaja.BackColor = Color.FromName("Control");
            btncierracaja.ForeColor = Color.FromArgb(0, 0, 0);
            btningresos.BackColor = Color.FromName("Control");
            btningresos.ForeColor = Color.FromArgb(0, 0, 0);
            btnegresos.BackColor = Color.FromName("Control");
            btnegresos.ForeColor = Color.FromArgb(0, 0, 0);
            btnmovimientocaja.BackColor = Color.FromName("Control");
            btnmovimientocaja.ForeColor = Color.FromArgb(0, 0, 0);


            //Modulo compra
            btnnuevacompra.BackColor = Color.FromName("Control");
            btnnuevacompra.ForeColor = Color.FromArgb(0, 0, 0);
            btnanularcompra.BackColor = Color.FromName("Control");
            btnanularcompra.ForeColor = Color.FromArgb(0, 0, 0);
            btnordencompra.BackColor = Color.FromName("Control");
            btnordencompra.ForeColor = Color.FromArgb(0, 0, 0);
            btnrecepcioncompra.BackColor = Color.FromName("Control");
            btnrecepcioncompra.ForeColor = Color.FromArgb(0, 0, 0);
            btncuentasxpagar.BackColor = Color.FromName("Control");
            btncuentasxpagar.ForeColor = Color.FromArgb(0, 0, 0);
            btncotizacion.BackColor = Color.FromName("Control");
            btncotizacion.ForeColor = Color.FromArgb(0, 0, 0);

            //Modulo ventas
            btnnuevaventa.BackColor = Color.FromName("Control");
            btnnuevaventa.ForeColor = Color.FromArgb(0, 0, 0);
            btnanularventa.BackColor = Color.FromName("Control");
            btnanularventa.ForeColor = Color.FromArgb(0, 0, 0);
            btnconsultasventa.BackColor = Color.FromName("Control");
            btnconsultasventa.ForeColor = Color.FromArgb(0, 0, 0);
            btncliente.BackColor = Color.FromName("Control");
            btncliente.ForeColor = Color.FromArgb(0, 0, 0);

            //Modulo Gestion de negocio
            btnproductos.BackColor = Color.FromName("Control");
            btnproductos.ForeColor = Color.FromArgb(0, 0, 0);
            btnProveedor.BackColor = Color.FromName("Control");
            btnProveedor.ForeColor = Color.FromArgb(0, 0, 0);
            btnCategoria.BackColor = Color.FromName("Control");
            btnCategoria.ForeColor = Color.FromArgb(0, 0, 0);
            btnPresentacion.BackColor = Color.FromName("Control");
            btnPresentacion.ForeColor = Color.FromArgb(0, 0, 0);
            btnTasaCambio.BackColor = Color.FromName("Control");
            btnTasaCambio.ForeColor = Color.FromArgb(0, 0, 0);
            btnContacto.BackColor = Color.FromName("Control");
            btnContacto.ForeColor = Color.FromName("ControlText");
            btnMarca.BackColor = Color.FromName("Control");
            btnMarca.ForeColor = Color.FromName("ControlText");
            btnUnidMed.BackColor = Color.FromName("Control");
            btnUnidMed.ForeColor = Color.FromName("ControlText");


            //Modulo Administracion
            btnEmpleado.BackColor = Color.FromName("Control");
            btnEmpleado.ForeColor = Color.FromArgb(0, 0, 0);
            btnCargo.BackColor = Color.FromName("Control");
            btnCargo.ForeColor = Color.FromArgb(0, 0, 0);
            btnroles.BackColor = Color.FromName("Control");
            btnroles.ForeColor = Color.FromArgb(0, 0, 0);
            btnusuario.BackColor = Color.FromName("Control");
            btnusuario.ForeColor = Color.FromArgb(0, 0, 0);
            btnPersona.BackColor = Color.FromName("Control");
            btnPersona.ForeColor = Color.FromArgb(0, 0, 0);
            btnHistorialEmpleado.BackColor = Color.FromName("Control");
            btnHistorialEmpleado.ForeColor = Color.FromArgb(0, 0, 0);
            btnConexiones.BackColor = Color.FromName("Control");
            btnConexiones.ForeColor = Color.FromArgb(0, 0, 0);

            //tools
            HerramientasToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            QuiaToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            PreferenciaToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            ayudaToolStripMenu.ForeColor = Color.FromName("ControlText");
            //lbl pnlBottom
            //userlbl.ForeColor = Color.FromArgb(0, 0, 0);
            lblValorFecha.ForeColor = Color.FromArgb(0, 0, 0);
            lblValorHora.ForeColor = Color.FromArgb(0, 0, 0);
            lblCaja.ForeColor = Color.FromArgb(0, 0, 0);
            lblMontoCaja.ForeColor = Color.FromArgb(0, 0, 0);
            lblTasa.ForeColor = Color.FromArgb(0, 0, 0);
            lblValorTasa.ForeColor = Color.FromArgb(0, 0, 0);
            lblFecha.ForeColor = Color.FromArgb(0, 0, 0);

        }
        //color oscuro de fondo
        private void ColorOscuro()
        {

            //principal
            panel1.BackColor = Color.FromArgb(23, 32 ,42);
            panel2.BackColor = Color.FromArgb(23, 32, 42);
            pnlUser.BackColor = Color.FromArgb(23, 32, 42);
            btnCerrarSesion.BackColor = Color.FromArgb(28, 40, 51);
            btnCerrarSesion.ForeColor = Color.FromArgb(255, 255, 255);
            btnUser.BackColor = Color.FromArgb(28, 40, 51);
            btnUser.ForeColor = Color.FromName("Control");
            btnCredenciales.BackColor = Color.FromArgb(28, 40, 51);
            btnCredenciales.ForeColor = Color.FromArgb(255, 255, 255);


            BarraTitulo.BackColor = Color.FromArgb(23, 32, 42);
            MenuVertical.BackColor = Color.FromArgb(23, 32, 42);
            btnMenu.BackColor = Color.FromArgb(28, 40, 51);
           

            //paneles
            pnlcaja.BackColor = Color.FromArgb(28, 40, 51);
            pnlcompras.BackColor = Color.FromArgb(28, 40, 51 );
            pnlventas.BackColor = Color.FromArgb(28, 40, 51);
            btnPresentacion.BackColor = Color.FromArgb(28, 40, 51);
            pnlnegocio.BackColor = Color.FromArgb(28, 40, 51);
            pnladmin.BackColor = Color.FromArgb(28, 40, 51);

            //Btn modulos
            label1.ForeColor = Color.FromArgb(255, 255, 255);
            label2.ForeColor = Color.FromArgb(255, 255, 255);
            btnMcompras.BackColor = Color.FromArgb(23, 32, 42); btnMcompras.ForeColor = Color.FromArgb(255, 255, 255);
            btnMcaja.BackColor = Color.FromArgb(23, 32, 42); btnMcaja.ForeColor = Color.FromArgb(255, 255, 255);
            btnMadmin.BackColor = Color.FromArgb(23, 32, 42); btnMadmin.ForeColor = Color.FromArgb(255, 255, 255);
            btnMGestion.BackColor = Color.FromArgb(23, 32, 42); btnMGestion.ForeColor = Color.FromArgb(255, 255, 255);
            btnMventas.BackColor = Color.FromArgb(23, 32, 42); btnMventas.ForeColor = Color.FromArgb(255, 255, 255);

            //Modulo caja
            btnaperturacaja.BackColor = Color.FromArgb(28, 40, 51); btnaperturacaja.ForeColor = Color.FromArgb(255, 255, 255);
            btncierracaja.BackColor = Color.FromArgb(28, 40, 51); btncierracaja.ForeColor = Color.FromArgb(255, 255, 255);
            btningresos.BackColor = Color.FromArgb(28, 40, 51); btningresos.ForeColor = Color.FromArgb(255, 255, 255);
            btnegresos.BackColor = Color.FromArgb(28, 40, 51); btnegresos.ForeColor = Color.FromArgb(255, 255, 255);
            btnmovimientocaja.BackColor = Color.FromArgb(28, 40, 51); btnmovimientocaja.ForeColor = Color.FromArgb(255, 255, 255);


            //Modulo compra
            btnnuevacompra.BackColor = Color.FromArgb(93, 109, 126); btnnuevacompra.ForeColor = Color.FromArgb(255, 255, 255);
            btnanularcompra.BackColor = Color.FromArgb(93, 109, 126); btnanularcompra.ForeColor = Color.FromArgb(255, 255, 255);
            btnordencompra.BackColor = Color.FromArgb(93, 109, 126); btnordencompra.ForeColor = Color.FromArgb(255, 255, 255);
            btnrecepcioncompra.BackColor = Color.FromArgb(93, 109, 126); btnrecepcioncompra.ForeColor = Color.FromArgb(255, 255, 255);
            btncuentasxpagar.BackColor = Color.FromArgb(93, 109, 126); btncuentasxpagar.ForeColor = Color.FromArgb(255, 255, 255);
            btncotizacion.BackColor = Color.FromArgb(93, 109, 126); btncotizacion.ForeColor = Color.FromArgb(255, 255, 255);

            //Modulo ventas
            btnnuevaventa.BackColor = Color.FromArgb(28, 40, 51); btnnuevaventa.ForeColor = Color.FromArgb(255, 255, 255);
            btnanularventa.BackColor = Color.FromArgb(28, 40, 51); btnanularventa.ForeColor = Color.FromArgb(255, 255, 255);
            btnconsultasventa.BackColor = Color.FromArgb(28, 40, 51); btnconsultasventa.ForeColor = Color.FromArgb(255, 255, 255);
            btncliente.BackColor = Color.FromArgb(28, 40, 51); btncliente.ForeColor = Color.FromArgb(255, 255, 255);

            //Modulo Gestion de negocio
            btnproductos.BackColor = Color.FromArgb(93, 109, 126);
            btnproductos.ForeColor = Color.FromArgb(255, 255, 255);
            btnProveedor.BackColor = Color.FromArgb(93, 109, 126);
            btnProveedor.ForeColor = Color.FromArgb(255, 255, 255);
            btnCategoria.BackColor = Color.FromArgb(93, 109, 126);
            btnCategoria.ForeColor = Color.FromArgb(255, 255, 255);
            btnPresentacion.BackColor = Color.FromArgb(93, 109, 126);
            btnPresentacion.ForeColor = Color.FromArgb(255, 255, 255);
            btnContacto.BackColor = Color.FromArgb(93, 109, 126);
            btnContacto.ForeColor = Color.FromArgb(255, 255, 255);
            btnMarca.BackColor = Color.FromArgb(93, 109, 126);
            btnMarca.ForeColor = Color.FromArgb(255, 255, 255);
            btnUnidMed.BackColor = Color.FromArgb(93, 109, 126);
            btnUnidMed.ForeColor = Color.FromArgb(255, 255, 255);
            btnTasaCambio.BackColor = Color.FromArgb(93, 109, 126);
            btnTasaCambio.ForeColor = Color.FromArgb(255, 255, 255);




            //Modulo Administracion
            btnEmpleado.BackColor = Color.FromArgb(93, 109, 126);
            btnEmpleado.ForeColor = Color.FromArgb(255, 255, 255);
            btnCargo.BackColor = Color.FromArgb(93, 109, 126);
            btnCargo.ForeColor = Color.FromArgb(255, 255, 255);
            btnroles.BackColor = Color.FromArgb(93, 109, 126);
            btnroles.ForeColor = Color.FromArgb(255, 255, 255);
            btnusuario.BackColor = Color.FromArgb(93, 109, 126);
            btnusuario.ForeColor = Color.FromArgb(255, 255, 255);
            btnPersona.BackColor = Color.FromArgb(93, 109, 126);
            btnPersona.ForeColor = Color.FromArgb(255, 255, 255);
            btnHistorialEmpleado.BackColor = Color.FromArgb(93, 109, 126);
            btnHistorialEmpleado.ForeColor = Color.FromName("Control");
            btnConexiones.ForeColor = Color.FromArgb(255, 255, 255);
            btnConexiones.BackColor = Color.FromArgb(93, 109, 126);
            

            //tools
            HerramientasToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            QuiaToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            PreferenciaToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            ayudaToolStripMenu.ForeColor = Color.FromArgb(255, 255, 255);
            //cALCULADORAToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            //exelToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);

            //lbl pnlBottom
            //userlbl.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorFecha.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorHora.ForeColor = Color.FromArgb(255, 255, 255);
            lblCaja.ForeColor = Color.FromArgb(255, 255, 255);
            lblMontoCaja.ForeColor = Color.FromArgb(255, 255, 255);
            lblTasa.ForeColor = Color.FromArgb(255, 255, 255);
            lblValorTasa.ForeColor = Color.FromArgb(255, 255, 255);
            lblFecha.ForeColor = Color.FromArgb(255, 255, 255);
            lblHora.ForeColor = Color.FromArgb(255, 255, 255);
            btnUser.ForeColor = Color.FromArgb(255, 255, 255);


        }
       
        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmEmpleado());
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(FrmProductos.GetInstancia());
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            //Cerrar aplicación y cerrar sesión
            if (MessageBox.Show("¿Desea cerrar la aplicación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                //Cerrar sesión
                conexionLinq.spCerrarCesion(usuario);
                //Cerrar aplicación
                Application.Exit();

            }

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 224)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 224;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMadmin_Click(object sender, EventArgs e)
        {
            if (pnladmin.Visible == false)
            {
                pnladmin.Visible = true;
            }
            else
                pnladmin.Visible = false;
            pnlventas.Visible = false;
            pnlcompras.Visible = false;
            pnlcaja.Visible = false;
            pnlnegocio.Visible = false;
            pnlUser.Visible = false;
        }

        private void btnMGestion_Click(object sender, EventArgs e)
        {
            if (pnlnegocio.Visible == false)
            {
                pnlnegocio.Visible = true;
            }
            else
                pnlnegocio.Visible = false;
            pnlventas.Visible = false;
            pnlcompras.Visible = false;
            pnlcaja.Visible = false;
            pnladmin.Visible = false;
            pnlUser.Visible = false;
        }

        private void btnMventas_Click(object sender, EventArgs e)
        {
            if (pnlventas.Visible == false)
            {
                pnlventas.Visible = true;
            }
            else
                pnlventas.Visible = false;
            pnlcompras.Visible = false;
            pnlcaja.Visible = false;
            pnladmin.Visible = false;
            pnlnegocio.Visible = false;
            pnlUser.Visible = false;
        }

        private void btnMcompras_Click(object sender, EventArgs e)
        {
            if (pnlcompras.Visible == false)
            {
                pnlcompras.Visible = true;
            }
            else
                pnlcompras.Visible = false;
            pnlcaja.Visible = false;
            pnladmin.Visible = false;
            pnlnegocio.Visible = false;
            pnlventas.Visible = false;
            pnlUser.Visible = false;
        }

        private void btnMcaja_Click(object sender, EventArgs e)
        {
            if (pnlcaja.Visible == false)
            {
                pnlcaja.Visible = true;
            }
            else
                pnlcaja.Visible = false;
            pnlcompras.Visible = false;
            pnladmin.Visible = false;
            pnlnegocio.Visible = false;
            pnlventas.Visible = false;
            pnlUser.Visible = false;
        }

        private void cALCULADORAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea abrir la calculadora?", "Advertencia",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Process.Start(@"calc.exe");
        }

        private void exelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea abrir Excel?", "Advertencia",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Process.Start(@"excel.exe");
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblValorHora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblValorFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmCliente());
        }

        private void btningresos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(FrmIngreso.GetInstancia());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.panelContenedor.Controls.Add(pnlUser);
            //desplegar boton Cerrar sesion
            if (this.pnlUser.Visible == false)
                this.pnlUser.Visible = true;
            else
                this.pnlUser.Visible = false;
            pnlcompras.Visible = false;
            pnladmin.Visible = false;
            pnlnegocio.Visible = false;
            pnlventas.Visible = false;
            pnlcaja.Visible = false;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //Cerrar sesión y mostrar login
            if (MessageBox.Show("¿Desea cerrar la sesión?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //Cerrar sesión
                conexionLinq.spCerrarCesion(usuario);

                //Reiniciar aplicación - Show Login
                Application.Restart();
            }

        }

        private void btnmovimientocaja_Click(object sender, EventArgs e)
        {

        }

 
        //cambio de idioma a ingles
        private void IdiomaIngles()
        {
            //toolstrip
            HerramientasToolStripMenuItem.Text = "Tools";
            QuiaToolStripMenuItem.Text = "Guide";
            PreferenciaToolStripMenuItem.Text = "Help";
            cALCULADORAToolStripMenuItem.Text = "Calculator";

            //Modulos
            btnMcaja.Text = "Cash register";
            btnMcompras.Text = "Purchases";
            btnMventas.Text = "Sales";
            btnMGestion.Text = "Business management";
            btnMadmin.Text = "management";

            //moduloProductos
            btnproductos.Text = "Products";
            btnProveedor.Text = "Providers";
            btnCategoria.Text = "Category";
            btnPresentacion.Text = "Presentation";
        }
        //cambio de ideoma a español
        private void IdiomaEspañol()
        {
            // toolstrip
            HerramientasToolStripMenuItem.Text = "Herramientas";
            QuiaToolStripMenuItem.Text = "Guia";
            PreferenciaToolStripMenuItem.Text = "Ayuda";
            cALCULADORAToolStripMenuItem.Text = "Calculadora";

            //Modulos
            btnMcaja.Text = "Caja";
            btnMcompras.Text = "Compras";
            btnMventas.Text = "Ventas";
            btnMGestion.Text = "Gestion de negocio";
            btnMadmin.Text = "Administracion";

            //moduloProductos
            btnproductos.Text = "Productos";
            btnProveedor.Text = "Proveedores";
            btnCategoria.Text = "Categoria";
            btnPresentacion.Text = "Presentacion";


        }
      

        private void HerramientasToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void inglesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.IdiomaIngles();
        }

        private void españolToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IdiomaEspañol();
        }

        private void oscuroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ColorOscuro();
        }

        private void claroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.colorClaro();
        }

       

         private void btnUnidMed_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmUnidad_Medida());
        }

        private void btnCategoria_Click_2(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmCategoria());
        }

        private void btnPresentacion_Click_2(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmPresentacion());
        }

        private void btnMarca_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmMarca());
        }

        private void btnProveedor_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmProveedor());
        }

        private void btnVistas_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEmpleado_Click_1(object sender, EventArgs e)
        {

            Administración.FrmEmpleado FrmE = new Administración.FrmEmpleado();
            AbrirFormEnPanel(FrmE);

        }

        private void btnCargo_Click(object sender, EventArgs e)
        {

            CapaPresentacion.Administración.FrmCargo FrmC = new Administración.FrmCargo();
            FrmC.usuario = usuario;
            AbrirFormEnPanel(FrmC);

        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmIngresoP());
        }

        private void btnContacto_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmContactoProv());
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnnuevacompra_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(FrmCompra.GetInstancia());
        }

        private void btnanularventa_Click(object sender, EventArgs e)
        {
           
        }

        private void btnanularcompra_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(FrmAnulacionCompra.GetInstancia());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            this.panelContenedor.Controls.Add(pnlUser);

            if (pnlUser.Visible == false)
                pnlUser.Visible = true;
            else
                pnlUser.Visible = false;
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            AbrirFormEnPanel(new Administración.FrmActualizaCredenciales());

        }

        private void btnroles_Click(object sender, EventArgs e)
        {
           
            Administración.FrmRoles frmR = new Administración.FrmRoles();
            frmR.usuario = usuario;
            AbrirFormEnPanel(frmR);

        }

        private void btnConexiones_Click(object sender, EventArgs e)
        {
            Administración.Conexiones frmC = new Administración.Conexiones();
            AbrirFormEnPanel(frmC);
        }

           

        private void btnusuario_Click(object sender, EventArgs e)
        {

            Administración.FrmUsuario frmU = new Administración.FrmUsuario();
            frmU.usuario = usuario;
            AbrirFormEnPanel(frmU);


        }

        private void pnladmin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnusuario_Click_1(object sender, EventArgs e)
        {

            Administración.FrmUsuario frmU = new Administración.FrmUsuario();
            frmU.usuario = usuario;
            AbrirFormEnPanel(frmU);

        }

        private void btnConexiones_Click_1(object sender, EventArgs e)
        {

            Administración.Conexiones frmC = new Administración.Conexiones();
           AbrirFormEnPanel(frmC);
            

        }

        private void btnHistorialEmpleado_Click(object sender, EventArgs e)
        {

            Administración.FrmHistorialEmpleado frmHE = new Administración.FrmHistorialEmpleado();
            frmHE.usuario = usuario;
            AbrirFormEnPanel(frmHE);

        }

        private void btnroles_Click_1(object sender, EventArgs e)
        {
            Administración.FrmRoles frmR = new Administración.FrmRoles();
            frmR.usuario = usuario;
            AbrirFormEnPanel(frmR);
        }

        private void btnTasaCambio_Click(object sender, EventArgs e)
        {

            GestionNegocio.FrmTasaCambio frmT = new GestionNegocio.FrmTasaCambio();
            AbrirFormEnPanel(frmT);


        }

        private void FrmMenuPrincipal_Activated(object sender, EventArgs e)
        {

  
        }
    }
}