using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos.GestionNegocio;

namespace CapaNegocio.GestionNegocio
{
    public class NTasaCambio
    {

        public static DataTable Importar(string ruta)
        {

            return new TasaCambio().Importar(ruta);

        }

        public static string Guardar()
        {

            return new TasaCambio().Guardar();

        }


    }
}
