﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion//.Reportes
{
    public partial class FrmRClient : Form
    {
        public FrmRClient()
        {
            InitializeComponent();
        }

        private void FrmRClient_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_cliente' Puede moverla o quitarla según sea necesario.
            this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);

            this.reportViewer1.RefreshReport();
        }
    }
}
