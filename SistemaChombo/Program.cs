using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion;


namespace SistemaChombo
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(FrmProductos.GetInstancia());
            //Application.Run(FrmAnulacionCompra.GetInstancia());
            Application.Run(new FrmLogin());
        }
    }
}
