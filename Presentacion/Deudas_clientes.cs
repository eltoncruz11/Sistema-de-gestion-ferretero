using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Deudas_clientes : Form
    {
        public Deudas_clientes()
        {
            InitializeComponent();
        }

        private void Deudas_clientes_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
           
        }
    }
}
