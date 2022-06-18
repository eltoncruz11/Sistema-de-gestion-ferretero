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
    public partial class Proveedore : Form
    {
        //Instancia para acceder a los metodos de la capa Intermedio
        Proveedores Prov = new Proveedores();

        public Proveedore()
        {
            InitializeComponent();
        }

        #region Funciones automaticas
        private void Proveedore_Load(object sender, EventArgs e)
        {
            //Invocando la ejecucion del metodo
            Listar_provedores();
        }

        public void Listar_provedores()
        {
            //Agrenado lista de datos al dataGridView
            DataTable dt = Prov.Listar();
            dataGridView1.DataSource = dt;
        }
        #endregion

        #region Funciones de la barraLateral

        //Instancia para acceder a los componentes del formulario
        Editar_Agregar_Proveedor P = new Editar_Agregar_Proveedor();
        #endregion

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Prov.Buscar(bunifuTextBox1.Text, guna2ComboBox1.SelectedIndex);
            dataGridView1.DataSource = dt;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            P.guna2GradientButton1.Text = "Agregar";

            P.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            Prov.idProveedor = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Prov.Eliminar();

            if (Mensaje == "proveedor eliminado con exito")
            {
                Listar_provedores();

            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            P.guna2GradientButton1.Text = "Actualizar";
            P.guna2TextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            P.Show();

        }
    }
}
