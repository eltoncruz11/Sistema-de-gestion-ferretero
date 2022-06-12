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
    public partial class Cliente : Form
    {
        Clientes Clien = new Clientes();
        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {


            Listar();
            
        }

        public void Listar()
        {
            DataTable dt = Clien.Listar();
            dataGridView1.DataSource = dt;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Agregar_Cliente Agre = new Agregar_Cliente(this);
            Agre.ShowDialog();
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            Editar_Client Client = new Editar_Client(this);
            Client.ShowDialog();
        }
    }
}
