﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Intermedio;

namespace Presentacion
{
    public partial class Deudas_clientes : Form
    {
        Clientes cli = new Clientes();
        public Deudas_clientes()
        {
            InitializeComponent();
        }

        private void Deudas_clientes_Load(object sender, EventArgs e)
        {
            DataTable h = cli.Informe();

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", h));
            this.reportViewer1.RefreshReport();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
