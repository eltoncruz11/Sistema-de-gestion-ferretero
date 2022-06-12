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
    public partial class Agregar_Cliente : Form
    {
        Cliente C;

        Clientes client = new Clientes();
        public Agregar_Cliente(Cliente L)
        {
            InitializeComponent();
            C = L;
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String Men = "";
            client.ID = bunifuTextBox5.Text.ToString();
            client.Nombre = bunifuTextBox1.Text.ToString();
            client.Apellido = bunifuTextBox2.Text.ToString();
            client.Contacto = bunifuTextBox3.Text.ToString();
            client.Direccion = bunifuTextBox4.Text.ToString();

            Men = client.Agregar();

            MessageBox.Show(Men,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

            C.Listar();

            if (Men == "Cliente registrado exitosamente")
            {
                this.Close();
            }

        }
    }
}
