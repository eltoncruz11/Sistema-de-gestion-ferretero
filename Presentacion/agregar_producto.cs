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
    public partial class agregar_producto : Form
    {
        inventario inv = new inventario();

        DataTable dt = new DataTable();

        Inventario inven;

        categoria cat = new categoria();
        public agregar_producto(Inventario v)
        {
            InitializeComponent();
            inven = v;
        }

        private void agregar_producto_Load(object sender, EventArgs e)
        { 

            dt = cat.Listar();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                guna2ComboBox1.Items.Add(dt.Rows[i][1].ToString());
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string Men = "";
            int temp = guna2ComboBox1.SelectedIndex;
            inv.ID = Convert.ToInt32(bunifuTextBox5.Text);
            inv.Precio = Convert.ToInt32(bunifuTextBox3.Text);
            inv.Name = bunifuTextBox1.Text;
            inv.Marca = bunifuTextBox4.Text;
            inv.Descripcion = bunifuTextBox2.Text;
            if (checkBox1.Checked == true)
            {
                inv.Fecha = "";
            }
            else
            {
                inv.Fecha = guna2DateTimePicker1.Text;
            }
            inv.Categoria = Convert.ToInt32(dt.Rows[temp][0].ToString());
            Men = inv.Agregar();

            MessageBox.Show(Men, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            inven.Listar();

            if (Men == "Producto Registrado de manera exitosa")
            {

                this.Close();
            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
