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
    
    public partial class Categoria : Form
    {
        categoria cat = new categoria();
        public Categoria()
        {
            InitializeComponent();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String Men = "";
            cat.Name = bunifuTextBox5.Text;
            Men = cat.Agregar();
            MessageBox.Show(Men, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Men == "Categoria registrada exitosamente")
            {
                Listar();
                Panel1.Enabled = false;
            }

        }

        public void Listar()
        {
            dataGridView1.DataSource = cat.Listar();
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            Panel2.Enabled = true;
            bunifuTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            cat.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cat.Name = bunifuTextBox1.Text;
            string Men = cat.Editar();

            MessageBox.Show(Men, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Men == "La categoria se edito de manera exitosa")
            {
                Listar();
                Panel2.Enabled = false;
            }
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {


            DialogResult R;

            R = MessageBox.Show("Esta seguro que desea eliminar esta categoria", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (R == DialogResult.Yes)
            {
                cat.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cat.Eliminar();
                Listar();

            }
        }
    }
}
