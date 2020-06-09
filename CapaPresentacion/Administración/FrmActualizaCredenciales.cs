using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CapaNegocio.Administracion;

namespace CapaPresentacion.Administración
{
    public partial class FrmActualizaCredenciales : Form
    {
        public FrmActualizaCredenciales()
        {
            InitializeComponent();

            //Set ttmensaje
            ttMensaje.SetToolTip(txtUsuario, "Ingrese su nombre de usuario.");
            ttMensaje.SetToolTip(txtPass, "Ingrese su contraseña.");
            ttMensaje.SetToolTip(txtNUsuario, "Ingrese nuevo nombre de usuario.");
            ttMensaje.SetToolTip(txtNPass, "Ingrese nueva contraseña. Debe tener entre 8 a 20 caracteres, incluyendo al menos una letra mayúscula, un digito y un caracter especial.");
            ttMensaje.SetToolTip(txtConfirmar, "Ingrese nuevamente nueva contraseña.");
            ttMensaje.SetToolTip(btnGuardar, "Guardar nuevas credenciales.");
            ttMensaje.SetToolTip(btnSalir, "Cancelar|Salir de cambio de credenciales.");
        }

        private void FrmActualizaCredenciales_Load(object sender, EventArgs e)
        {

        }

        //validar requerimientos de contraseña
        private int validarContraseña()
        {

            bool errorFlag = false;
            int errorCode = 0;

            //Longitud, número, caracteres especiales y mayúsculas
            Match matchLongitud = Regex.Match(txtNPass.Text, @"^\w{8,20}\b");
            Match matchNumeros = Regex.Match(txtNPass.Text, @"\d");
            Match matchEspeciales = Regex.Match(txtNPass.Text, @"[ñÑ\-_¿.#¡]");
            Match matchMayusculas = Regex.Match(txtNPass.Text, @"[A-Z]");

            //Si no cumple longitud mínima
            if (!matchLongitud.Success)
            {

                errorCode = 1;
                errorFlag = true;

            } //Si no cumple incorporación de al menos un número.
            else if (errorFlag || !matchNumeros.Success)
            {

                errorCode = 2;
                errorFlag = true;

            } //al menos una letra mayúscula
            else if (errorFlag || !matchMayusculas.Success)
            {

                errorCode = 3;
                errorFlag = true;

            } //al menos un caracter especial
            else if (errorFlag || !matchEspeciales.Success)
            {

                errorCode = 4;
                errorFlag = true;

            } //Si la contraseña nueva es igual a la anterior
            else if (txtPass.Text == txtNPass.Text)
            {

                errorCode = 5;
                errorFlag = true;

            }

            return errorCode;

        }

        private void txtNPass_TextChanged(object sender, EventArgs e)
        {

            int errorCode = validarContraseña();

            switch (errorCode)
            {

                case 1:
                    error.SetError(txtNPass, "La contraseña debe medir entre 8 y 20 caracteres.");
                    break;
                case 2:
                    error.SetError(txtNPass, "La contraseña debe contener al menos un número.");
                    break;
                case 3:
                    error.SetError(txtNPass, "La contraseña debe contener al menos un caracter en mayúscula.");
                    break;
                case 4:
                    error.SetError(txtNPass, "La contraseña debe contener al menos un caracter especial");
                    break;
                case 5:
                    error.SetError(txtNPass, "La nueva contraseña debe ser distinta a la actual.");
                    break;
                default:
                    error.Clear();
                    break;
            }


        }

        private void txtConfirmar_TextChanged(object sender, EventArgs e)
        {

            if ((txtNPass.Text != "" && txtConfirmar.Text != "") && (txtNPass.Text != txtConfirmar.Text))
            {

                error.SetError(txtConfirmar, "La contraseña no coincide.");

            }
            else
            {

                error.Clear();

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string rpta = "";
            int errorCode = validarContraseña();

            //Verifica que los campos no esten vacios
            if (txtUsuario.Text != "" && txtPass.Text != "" && txtNUsuario.Text != "" && txtNPass.Text != "" && txtConfirmar.Text != "")
            {
                //Valida que la contraseña cumpla los requisitos
                if (errorCode == 0)
                {

                    if (txtNPass.Text == txtConfirmar.Text)
                    {

                        if (txtNPass != txtPass)
                        {

                            rpta = NUsuario.CambiarCredenciales(txtUsuario.Text.Trim(), txtPass.Text.Trim(), txtNUsuario.Text.Trim(), txtNPass.Text.Trim());

                            MessageBox.Show(rpta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        else
                        {

                            MessageBox.Show("Debe ingresar una nueva contraseña distinta a la activa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }
                    else
                    {

                        MessageBox.Show("Debe confirmar la contraseña. Debe coincidir la nueva contraseña con el campo confirmar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    }

                }
                else
                {

                    MessageBox.Show("La nueva contraseña no cumple con los requisitos. Ingrese una nueva que contenga de 8 a 20 caracteres, los cuales deben incluir al menos una letra mayúscula, un dígito y un caracter especial.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else
            {

                MessageBox.Show("No debe dejar ningún campo vacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }

        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text != "" || txtPass.Text != "" || txtNUsuario.Text != "" || txtNPass.Text != "" || txtConfirmar.Text != "")
            {

                if (MessageBox.Show("¿Tiene datos sin guardar, desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();

            }
            else
            {

                this.Close();

            }
               
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text != "" || txtPass.Text != "" || txtNUsuario.Text != "" || txtNPass.Text != "" || txtConfirmar.Text != "")
            {

                if (MessageBox.Show("¿Tiene datos sin guardar, desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();

            }
            else
            {

                this.Close();

            }


        }
    }
}
