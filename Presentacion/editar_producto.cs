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
    public partial class editar_producto : Form
    {
        inventario inv = new inventario();

        Inventario inve;

        DataTable dt = new DataTable();


        categoria cat = new categoria();

        public editar_producto(Inventario c)
        {
            InitializeComponent();
            inve = c;
        }

        private void editar_producto_Load(object sender, EventArgs e)
        {
            inv.ID = Convert.ToInt32(inve.dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DataTable inf = inv.Informacion();


            dt = cat.Listar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                guna2ComboBox1.Items.Add(dt.Rows[i][1].ToString());
            }

            bunifuTextBox3.Text = inf.Rows[0][3].ToString();
            bunifuTextBox1.Text = inf.Rows[0][1].ToString();
            bunifuTextBox4.Text = inf.Rows[0][4].ToString();
            bunifuTextBox2.Text = inf.Rows[0][2].ToString();
            if (inf.Rows[0][6].ToString() == "NONE")
            {
                checkBox1.Checked = true;
            }
            else
            {
                guna2DateTimePicker1.Text = inf.Rows[0][6].ToString();
            }
            guna2ComboBox1.Text = inf.Rows[0][7].ToString();



        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string Men = "";
            int temp = guna2ComboBox1.SelectedIndex;
            inv.ID = Convert.ToInt32(inve.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            inv.Name = bunifuTextBox1.Text;
            inv.Precio = Convert.ToInt32(bunifuTextBox3.Text);
            inv.Marca = bunifuTextBox4.Text;
            inv.Descripcion = bunifuTextBox2.Text;
            inv.Fecha = guna2DateTimePicker1.Text;
            inv.Categoria = Convert.ToInt32(dt.Rows[temp][0].ToString());

            Men = inv.Editar();


            MessageBox.Show(Men, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            inve.Listar();

     
            if (Men == "Producto editado de manera exitosa")
            {

                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                guna2DateTimePicker1.Enabled = false;
            }
            else
            {
                guna2DateTimePicker1.Enabled = true;
            }
        }
    }
}
