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

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult R;

            R = MessageBox.Show("Esta seguro que desea eliminar a este cliente","Verificacion",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (R == DialogResult.Yes)
            {
                Clien.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Clien.Eliminar();
                Listar();

            }
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Deuda_clientes Deu = new Deuda_clientes(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Deu.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Deudas_clientes D = new Deudas_clientes();
            D.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt =Clien.Buscar(bunifuTextBox1.Text,guna2ComboBox1.SelectedIndex);
            dataGridView1.DataSource = dt;
        }
    }
}
