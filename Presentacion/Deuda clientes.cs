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
    public partial class Deuda_clientes : Form
    {
        Clientes cli = new Clientes();

        string id = "";

        public Deuda_clientes(String I)
        {
            InitializeComponent();
            id = I;
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Deuda_clientes_Load(object sender, EventArgs e)
        {
            Listar();
        }
        public void Listar ()
        {
            cli.ID = id;
            DataTable de = cli.Listar_d();
            dataGridView1.DataSource = de;
            
            if (de.Rows.Count > 0)
            {
                int sum = 0;
                for (int i = 0; i < de.Rows.Count; i++)
                {
                    sum = sum + Convert.ToInt32(de.Rows[0][i]);
                }
                bunifuLabel3.Text = sum.ToString();
            }
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult R;

            R = MessageBox.Show("Esta seguro que desea eliminar la deuda", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (R == DialogResult.Yes)
            {
                cli.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cli.Eliminar_d(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()));

                Listar();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult R;

            R = MessageBox.Show("Esta seguro que desea eliminar todas las deudas", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (R == DialogResult.Yes)
            {
                cli.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cli.Eliminar_ds();

                Listar();
            }

        }
    }
}
