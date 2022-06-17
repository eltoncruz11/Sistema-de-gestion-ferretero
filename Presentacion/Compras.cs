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
    public partial class Compras : Form
    {
        //Instancia para acceder a los metodos de la capa Intermedio
        Compra Comp = new Compra();

        public Compras()
        {
            InitializeComponent();
        }
        private void Compras_Load(object sender, EventArgs e)
        {
            //Invocando la ejecucion del metodo
            Listar_compras();
        }

        public void Listar_compras()
        {
            //Agrenado lista de datos al dataGridView
            DataTable dt = Comp.Listar();
            dataGridView1.DataSource = dt;
        }

        #region Funciones de la barraLateral

        //Instancia para acceder a los componentes del formulario
        Editar_Agregar_Compra C = new Editar_Agregar_Compra();

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            C.bunifuButton22.Text = "Agregar";
            C.Agregar = true;
            C.Show();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            String mensaje = "";
            Comp.idCompra = int.Parse(dataGridView1.CurrentRow.Cells[0].ToString());
            
            mensaje = Comp.Eliminar();

            if (mensaje == "compra eliminada con exito")
            {
                Listar_compras();
            }
        }
        #endregion


        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            dt = Comp.Buscar(bunifuTextBox1.Text, guna2ComboBox1.SelectedIndex);
            dataGridView1.DataSource = dt;
        }
    }
}
