using System;
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
    public partial class Seleccionar_cliente : Form
    {
        Ventas C = new Ventas();
        Clientes cl = new Clientes();
      
        public Seleccionar_cliente(Ventas d)
        {
            InitializeComponent();
            C = d;
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            C.ID_cli(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
            this.Close();
        }

        private void Seleccionar_cliente_Load(object sender, EventArgs e)
        {
             dataGridView1.DataSource= cl.Listar();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
