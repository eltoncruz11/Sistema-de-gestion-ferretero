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
    public partial class Inventario : Form
    {
        inventario inv = new inventario();

        Descuento des = new Descuento();
        public Inventario()
        {
            InitializeComponent();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Inventario_Load(object sender, EventArgs e)
        {


            Listar();
           
        }

        public void Listar ()
        {
            DataTable Cp = new DataTable();
            Cp = inv.Contar_prod();
            bunifuLabel6.Text = Cp.Rows[0][0].ToString();

            DataTable Cc = new DataTable();
            Cc = inv.Contar_cat();
            bunifuLabel5.Text = Cc.Rows[0][0].ToString();

            DataTable Cm = new DataTable();
            Cm = inv.Contar_mar();
            if (Cm.Rows.Count > 0)
            {
                bunifuLabel4.Text = Cm.Rows[0][0].ToString();
            }
            else
            {
                bunifuLabel4.Text = "0";
            }
            dataGridView1.DataSource = inv.Listar();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
           agregar_producto agre = new agregar_producto(this);
            agre.ShowDialog();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult R;

            R = MessageBox.Show("Esta seguro que desea eliminar el producto", "Verificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (R == DialogResult.Yes)
            {
                inv.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                inv.Eliminar();
                Listar();

            }
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            editar_producto ed = new editar_producto(this);
            ed.ShowDialog();
        }

        private void guna2CirclePictureBox6_Click(object sender, EventArgs e)
        {
            Info_Producto inf = new Info_Producto(this);
            inf.ShowDialog();
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DataTable R = inv.Buscar(bunifuTextBox1.Text, guna2ComboBox1.SelectedIndex);
            dataGridView1.DataSource = R;
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int pre = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            des.ID_p = id;
            DataTable R = des.Estado();




            if (R.Rows.Count == 0)
            {
                Descuentos D = new Descuentos(this);
                D.ShowDialog();

            }
            else if (R.Rows[0][0].ToString() == "False")
            {
                Descuentos D = new Descuentos(this);
                D.ShowDialog();
            }
            else
            {
                Desc_act D = new Desc_act(this);
                D.ShowDialog();
            }
        }
    }
}
