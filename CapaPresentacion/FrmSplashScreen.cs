using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmSplashScreen : Form
    {
        int contador = 0;

        public FrmSplashScreen()
        {

            InitializeComponent();
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            contador += 1;
            label3.Text = "Cargando " + contador + "%";

            progressBar1.Increment(1);

            if (progressBar1.Value == 100)
            {

                timer1.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();

            }

        }
    }
}
