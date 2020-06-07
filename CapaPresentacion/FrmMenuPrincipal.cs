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
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.iconminimizar, "Minimizar");
            this.ttMensaje.SetToolTip(this.iconcerrar, "Cerrar");
            this.ttMensaje.SetToolTip(this.btnMenu, "Minimizar iconos");
            //this.ttMensaje.SetToolTip(this.pictureBox1, "Cerrar sesion ");
            this.ttMensaje.SetToolTip(this.btnMcaja, "Despleglar modulos de caja");
            this.ttMensaje.SetToolTip(this.btnaperturacaja, "Abrir caja");
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

        
        }
        private void colorClaro()
        {

            //principal
            panel1.BackColor = Color.FromArgb(52, 73, 94);
            panel2.BackColor = Color.FromArgb(52, 73, 94);
            pnlUser.BackColor = Color.FromArgb(52, 73, 94);
            btnCerrarSesion.BackColor = Color.FromArgb(93, 109, 126); btnCerrarSesion.ForeColor = Color.FromArgb(0, 0, 0);


            BarraTitulo.BackColor = Color.FromArgb(52, 73, 94);
            MenuVertical.BackColor = Color.FromArgb(255, 255, 255);
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
            btnMcompras.BackColor = Color.FromArgb(52, 73, 94); btnMcompras.ForeColor = Color.FromArgb(0, 0, 0);
            btnMcaja.BackColor = Color.FromArgb(52, 73, 94); btnMcaja.ForeColor = Color.FromArgb(0, 0, 0);
            btnMadmin.BackColor = Color.FromArgb(52, 73, 94); btnMadmin.ForeColor = Color.FromArgb(0, 0, 0);
            btnMGestion.BackColor = Color.FromArgb(52, 73, 94); btnMGestion.ForeColor = Color.FromArgb(0, 0, 0);
            btnMventas.BackColor = Color.FromArgb(52, 73, 94); btnMventas.ForeColor = Color.FromArgb(0, 0, 0);

            //Modulo caja
            btnaperturacaja.BackColor = Color.FromArgb(93, 109, 126); btnaperturacaja.ForeColor = Color.FromArgb(0, 0, 0);
            btncierracaja.BackColor = Color.FromArgb(93, 109, 126); btncierracaja.ForeColor = Color.FromArgb(0, 0, 0);
            btningresos.BackColor = Color.FromArgb(93, 109, 126); btningresos.ForeColor = Color.FromArgb(0, 0, 0);
            btnegresos.BackColor = Color.FromArgb(93, 109, 126); btnegresos.ForeColor = Color.FromArgb(0, 0, 0);
            btnmovimientocaja.BackColor = Color.FromArgb(93, 109, 126); btnmovimientocaja.ForeColor = Color.FromArgb(0, 0, 0);


            //Modulo compra
            btnnuevacompra.BackColor = Color.FromArgb(93, 109, 126); btnnuevacompra.ForeColor = Color.FromArgb(0, 0, 0);
            btnanularcompra.BackColor = Color.FromArgb(93, 109, 126); btnanularcompra.ForeColor = Color.FromArgb(0, 0, 0);
            btnordencompra.BackColor = Color.FromArgb(93, 109, 126); btnordencompra.ForeColor = Color.FromArgb(0, 0, 0);
            btnrecepcioncompra.BackColor = Color.FromArgb(93, 109, 126); btnrecepcioncompra.ForeColor = Color.FromArgb(0, 0, 0);
            btncuentasxpagar.BackColor = Color.FromArgb(93, 109, 126); btncuentasxpagar.ForeColor = Color.FromArgb(0, 0, 0);
            btncotizacion.BackColor = Color.FromArgb(93, 109, 126); btncotizacion.ForeColor = Color.FromArgb(0, 0, 0);

            //Modulo ventas
            btnnuevaventa.BackColor = Color.FromArgb(93, 109, 126); btnnuevaventa.ForeColor = Color.FromArgb(0, 0, 0);
            btnanularventa.BackColor = Color.FromArgb(93, 109, 126); btnanularventa.ForeColor = Color.FromArgb(0, 0, 0);
            btnconsultasventa.BackColor = Color.FromArgb(93, 109, 126); btnconsultasventa.ForeColor = Color.FromArgb(0, 0, 0);
            btncliente.BackColor = Color.FromArgb(93, 109, 126); btncliente.ForeColor = Color.FromArgb(0, 0, 0);

            //Modulo Gestion de negocio
            btnproductos.BackColor = Color.FromArgb(93, 109, 126); btnproductos.ForeColor = Color.FromArgb(0, 0, 0);
            btnProveedor.BackColor = Color.FromArgb(93, 109, 126); btnProveedor.ForeColor = Color.FromArgb(0, 0, 0);
            btnCategoria.BackColor = Color.FromArgb(93, 109, 126); btnCategoria.ForeColor = Color.FromArgb(0, 0, 0);
            btnPresentacion.BackColor = Color.FromArgb(93, 109, 126); btnPresentacion.ForeColor = Color.FromArgb(0, 0, 0);

            //Modulo Administracion
            btnEmpleado.BackColor = Color.FromArgb(93, 109, 126); btnEmpleado.ForeColor = Color.FromArgb(0, 0, 0);
            btnCargo.BackColor = Color.FromArgb(93, 109, 126); btnCargo.ForeColor = Color.FromArgb(0, 0, 0);
            btnroles.BackColor = Color.FromArgb(93, 109, 126); btnroles.ForeColor = Color.FromArgb(0, 0, 0);
            btnusuario.BackColor = Color.FromArgb(93, 109, 126); btnusuario.ForeColor = Color.FromArgb(0, 0, 0);

            //tools
            HerramientasToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            QuiaToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            AyudaToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            //lbl pnlBottom
            //userlbl.ForeColor = Color.FromArgb(0, 0, 0);
            lblf.ForeColor = Color.FromArgb(0, 0, 0);
            lblh.ForeColor = Color.FromArgb(0, 0, 0);
            label3.ForeColor = Color.FromArgb(0, 0, 0);
            label4.ForeColor = Color.FromArgb(0, 0, 0);
            label5.ForeColor = Color.FromArgb(0, 0, 0);
            label6.ForeColor = Color.FromArgb(0, 0, 0);
            label7.ForeColor = Color.FromArgb(0, 0, 0);

        }
        //color oscuro de fondo
        private void ColorOscuro()
        {

            //principal
            panel1.BackColor = Color.FromArgb(23, 32 ,42);
            panel2.BackColor = Color.FromArgb(23, 32, 42);
            pnlUser.BackColor = Color.FromArgb(23, 32, 42);
            btnCerrarSesion.BackColor = Color.FromArgb(28, 40, 51); btnCerrarSesion.ForeColor = Color.FromArgb(255, 255, 255);
            

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
            btnproductos.BackColor = Color.FromArgb(93, 109, 126); btnproductos.ForeColor = Color.FromArgb(255, 255, 255);
            btnProveedor.BackColor = Color.FromArgb(93, 109, 126); btnProveedor.ForeColor = Color.FromArgb(255, 255, 255);
            btnCategoria.BackColor = Color.FromArgb(93, 109, 126); btnCategoria.ForeColor = Color.FromArgb(255, 255, 255);
            btnPresentacion.BackColor = Color.FromArgb(93, 109, 126); btnPresentacion.ForeColor = Color.FromArgb(255, 255, 255);

            //Modulo Administracion
            btnEmpleado.BackColor = Color.FromArgb(93, 109, 126); btnEmpleado.ForeColor = Color.FromArgb(255, 255, 255);
            btnCargo.BackColor = Color.FromArgb(93, 109, 126); btnCargo.ForeColor = Color.FromArgb(255, 255, 255);
            btnroles.BackColor = Color.FromArgb(93, 109, 126); btnroles.ForeColor = Color.FromArgb(255, 255, 255);
            btnusuario.BackColor = Color.FromArgb(93, 109, 126); btnusuario.ForeColor = Color.FromArgb(255, 255, 255);

            //tools
            HerramientasToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            QuiaToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            AyudaToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            //cALCULADORAToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            //exelToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);

            //lbl pnlBottom
            //userlbl.ForeColor = Color.FromArgb(255, 255, 255);
            lblf.ForeColor = Color.FromArgb(255, 255, 255);
            lblh.ForeColor = Color.FromArgb(255, 255, 255);
            label3.ForeColor = Color.FromArgb(255, 255, 255);
            label4.ForeColor = Color.FromArgb(255, 255, 255);
            label5.ForeColor = Color.FromArgb(255, 255, 255);
            label6.ForeColor = Color.FromArgb(255, 255, 255);
            label7.ForeColor = Color.FromArgb(255, 255, 255);


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
            if (MessageBox.Show("¿Desea cerrar la aplicación?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
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
            lblh.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblf.Text = DateTime.Now.ToShortDateString();
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
            if (MessageBox.Show("¿Desea cerrar la sesión?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Restart();

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
            AyudaToolStripMenuItem.Text = "Help";
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
            AyudaToolStripMenuItem.Text = "Ayuda";
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
            AbrirFormEnPanel(new FrmEmpleado());
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            
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
    }
}