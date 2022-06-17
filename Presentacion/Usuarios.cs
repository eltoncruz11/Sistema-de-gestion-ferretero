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
    public partial class Usuarios : Form
    {
        Users use = new Users();
        public Usuarios()
        {
            InitializeComponent();
        }

        //Mostrar
        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar_User();
        }
        public void Listar_User()
        {
            DataTable dt = use.Lista();
            dataGridView1.DataSource = dt;
        }

        //Agregar
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            guna2GroupBox1.Enabled = false;
            guna2GroupBox1.Text = "Nuevo usuario";
            guna2Button1.Text = "Agregar";

            String mensaje = "";
            use.Nombre = bunifuTextBox3.Text;
            use.contras = bunifuTextBox2.Text;

            mensaje = use.Agregar();
        }

        //Actualizar
        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            guna2GroupBox1.Enabled = false;
            guna2GroupBox1.Text = "Editar usuario";
            guna2Button1.Text = "Actualizar";

            String mensaje = "";
            use.id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            use.Nombre = bunifuTextBox3.Text;
            use.contras = bunifuTextBox2.Text;

            mensaje=use.Editar();
        }

        //Eliminar
        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            use.id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            use.Eliminar();
        }

        //Buscar
        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = use.Buscar(bunifuTextBox1.Text, guna2ComboBox1.SelectedIndex);
            dataGridView1.DataSource = dt;
        }
    }
}
