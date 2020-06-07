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

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {

        LoginDataContext conexionLinq = new LoginDataContext();
        public int accesousuario;
        string nombreusu;
        string passuser;
        int codigousu;
        int count = 0;
        char estadousu;

        FrmMenuPrincipal frm = new FrmMenuPrincipal();
        int Count = 0;


        public FrmLogin()
        {
            InitializeComponent();

            //Definición de los tooltips
            this.ttMensaje.SetToolTip(this.TxtUsuario, "Ingrese su nombre de usuario");
            this.ttMensaje.SetToolTip(this.TxtPassword, "Inserte su contraseña");
            this.ttMensaje.SetToolTip(this.BtnIngresar, "Para ingresar, introduzca su nombre de usuario y contraseña correctos");
            this.ttMensaje.SetToolTip(this.btnminimizar, "Minimizar");
            this.ttMensaje.SetToolTip(this.btnClose, "Cerrar");

            this.TxtUsuario.ForeColor = Color.LightGray;
            this.TxtPassword.ForeColor = Color.LightGray;


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void FrmLogin_Load(object sender, EventArgs e)
        {

            this.TxtPassword.UseSystemPasswordChar = false;
            this.TxtPassword.Text = "Contraseña";
            this.TxtUsuario.Text = "Usuario";
            this.TxtUsuario.TextAlign = HorizontalAlignment.Center;
            this.TxtPassword.TextAlign = HorizontalAlignment.Center;

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if ((this.TxtPassword.Text == "Contraseña" || this.TxtPassword.Text == "") && (this.TxtUsuario.Text == "Usuario" || this.TxtUsuario.Text == ""))
            {

                MessageBox.Show("No ha ingresado un nombre de usuario y contraseña.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                //Login();

                if (count < 3)
                {

                    //formatear textboxs
                    this.TxtPassword.UseSystemPasswordChar = false;
                    this.TxtPassword.ForeColor = Color.LightGray;
                    this.TxtPassword.Text = "Contraseña";
                    this.TxtUsuario.Text = "Usuario";
                    this.TxtUsuario.ForeColor = Color.LightGray;
                    this.TxtUsuario.TextAlign = HorizontalAlignment.Center;
                    this.TxtPassword.TextAlign = HorizontalAlignment.Center;

                }

            }

        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {

            if (TxtUsuario.Text == "Usuario")
            {

                TxtUsuario.Text = "";
                this.TxtUsuario.TextAlign = HorizontalAlignment.Left;
                this.TxtUsuario.ForeColor = Color.Black;
              
            }

        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {

            if (TxtUsuario.Text == "")
            {

                TxtUsuario.Text = "Usuario";
                this.TxtUsuario.TextAlign = HorizontalAlignment.Center;
                this.TxtUsuario.ForeColor = Color.LightGray;

            }

        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {

            if (TxtPassword.Text == "Contraseña")
            {

                TxtPassword.Text = "";
                TxtPassword.UseSystemPasswordChar = true;
                this.TxtPassword.TextAlign = HorizontalAlignment.Left;
                this.TxtPassword.ForeColor = Color.Black;

            }

        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {

            if (TxtPassword.Text == "")
            {

                TxtPassword.Text = "Contraseña";
                TxtPassword.UseSystemPasswordChar = false;
                TxtPassword.TextAlign = HorizontalAlignment.Center;
                TxtPassword.ForeColor = Color.LightGray;

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Desea salir?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Application.Exit();

            }

        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;

        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
    }

}
