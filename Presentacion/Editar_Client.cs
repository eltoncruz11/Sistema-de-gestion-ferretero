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
    public partial class Editar_Client : Form
    {
        Clientes Client = new Clientes();
        Cliente cli;
        public Editar_Client(Cliente r)
        {
            InitializeComponent();
            cli = r;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void Editar_Client_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = cli.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            bunifuTextBox2.Text = cli.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bunifuTextBox3.Text = cli.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            bunifuTextBox4.Text = cli.dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
