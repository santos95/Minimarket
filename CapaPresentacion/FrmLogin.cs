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
        FrmSplashScreen sps = new FrmSplashScreen();

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

                Login();

                if (Count < 3)
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

        private void TxtUsuario_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {

            if (this.TxtPassword.Text == "Contraseña")
            {

                this.TxtPassword.Text = "";
                this.TxtPassword.TextAlign = HorizontalAlignment.Left;
                this.TxtPassword.ForeColor = Color.Black;

            }

        }

        private void TxtUsuario_Click(object sender, EventArgs e)
        {

            if (this.TxtUsuario.Text == "Usuario")
            {

                this.TxtUsuario.Text = "";
                this.TxtUsuario.TextAlign = HorizontalAlignment.Left;
                this.TxtUsuario.ForeColor = Color.Black;

            }

        }

        private void Login()
        {

            try
            {
                //intento
                ++Count;

                //Verificación de credenciales
                data.DataSource = conexionLinq.accesologin(TxtUsuario.Text.Trim(), CapaNegocio.Administracion.NUsuario.Encriptar(TxtPassword.Text.Trim()));
                conexionLinq.spControlAcceso(TxtUsuario.Text.Trim(), CapaNegocio.Administracion.NUsuario.Encriptar(TxtPassword.Text.Trim()));

                //establecer variables para utilizar credenciales de acceso y conexion
                accesousuario = int.Parse(data[0, 0].Value.ToString());
                nombreusu = data[1, 0].Value.ToString();
                codigousu = int.Parse(data[3, 0].Value.ToString());
                passuser = data[2, 0].Value.ToString();

                estado.DataSource = conexionLinq.estadoconexion(codigousu);
                estadousu = char.Parse(estado[2, 0].Value.ToString());
                frm.Acceso = accesousuario;

                //Control de intentos
                if (data.RowCount != 0 && estadousu == 'B')
                {

                    if (MessageBox.Show("Su usuario ha sido bloqueado. Comuniquese con el administrador para obtener acceso", "Usuario Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                    {

                        Application.Exit();

                    }

                    /*
                    MessageBox.Show("Su usuario ha sido bloqueado. Comuniquese con el administrador para obtener acceso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.TxtPassword.Enabled = false;
                    this.TxtUsuario.Enabled = false;
                    this.BtnIngresar.Enabled = false;
                    */
                }
                else if (data.RowCount != 0 && estadousu == 'C')
                {

                    data.Visible = true;

                    if (accesousuario != 0 && accesousuario > 0)
                    {

                        this.Hide();
                        sps.ShowDialog();
                        frm.Show();
                        frm.usuario = nombreusu;
                        frm.btnUser.Text = nombreusu;
                        //this.Hide();

                    }/*
                    else if (accesousuario == 2)
                    {

                        frm.Show();
                        this.Hide();

                    }
                    else if (accesousuario == 3)
                    {

                        frm.Show();
                        this.Hide();

                    }*/
                    else
                    {

                        MessageBox.Show("Usuario o contraseña incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.pnlUsuario.BackColor = Color.Red;
                        this.pnlContraseña.BackColor = Color.Red;
                    }

                }
            }
            catch(Exception)
            {

                if (Count >= 3)
                {

                    this.TxtUsuario.Text = "Usuario";
                    this.TxtPassword.Text = "Contraseña";
                    this.TxtPassword.Enabled = false;
                    this.TxtUsuario.Enabled = false;


                    if (MessageBox.Show("Solicite ayude a soporte técnico para ingresar al Sistema", "Error: Se ha quedado sin intentos.", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                    {

                        Application.Exit();

                    }

                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.pnlUsuario.BackColor = Color.Red;
                    this.pnlContraseña.BackColor = Color.Red;

                }

            }

        }

        private void TxtUsuario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if ((this.TxtPassword.Text != "Contraseña" && this.TxtPassword.Text != "") && (this.TxtUsuario.Text != "Usuario" && this.TxtUsuario.Text != ""))
                {

                    Login();

                    if (Count < 3)
                    {

                        this.TxtUsuario.Text = "";
                        this.TxtUsuario.TextAlign = HorizontalAlignment.Left;
                        this.TxtUsuario.Focus();
                        this.TxtPassword.UseSystemPasswordChar = false;
                        this.TxtPassword.TextAlign = HorizontalAlignment.Center;
                        this.TxtPassword.ForeColor = Color.LightGray;
                        this.TxtPassword.Text = "Contraseña";

                    }

                }

            }

        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if ((this.TxtPassword.Text != "Contraseña" && this.TxtPassword.Text != "") && (this.TxtUsuario.Text != "Usuario" && this.TxtUsuario.Text != ""))
                {

                    Login();


                    if (Count < 3)
                    {


                        this.TxtUsuario.Text = "";
                        this.TxtUsuario.Focus();
                        this.TxtUsuario.TextAlign = HorizontalAlignment.Left;
                        this.TxtPassword.UseSystemPasswordChar = false;
                        this.TxtPassword.ForeColor = Color.LightGray;
                        this.TxtPassword.TextAlign = HorizontalAlignment.Center;
                        this.TxtPassword.Text = "Contraseña";

                    }

                }

            }

        }

    }

}
