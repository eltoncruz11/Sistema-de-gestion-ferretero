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
    public partial class Descuentos : Form
    {
        Descuento Des = new Descuento();

        int id = 0;

        int Pre = 0;

        int Pd = 0;

        Inventario cl = new Inventario();
        public Descuentos(Inventario r)
        {
            InitializeComponent();
            cl = r;
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String Men = "";
            Des.ID_p = Convert.ToInt32(cl.dataGridView1.CurrentRow.Cells[0].Value);
            DateTime inic = Convert.ToDateTime(guna2DateTimePicker1.Text);
            DateTime fin = Convert.ToDateTime(guna2DateTimePicker2.Text);
            Des.Inicio = inic.ToString("yyyy/MM/dd");
            Des.Final = fin.ToString("yyyy/MM/dd");
            Des.Porcentaje = Convert.ToInt32(bunifuTextBox5.Text);
            Des.Precio = Pd;
            Men = Des.Agregar();
            MessageBox.Show(Men, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Men == "El descuento se ha aplicado con exito")
            {
                this.Close();
            }
        }

        private void Descuentos_Load(object sender, EventArgs e)
        {

            bunifuLabel5.Text = cl.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bunifuLabel2.Text = cl.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Pre = Convert.ToInt32(bunifuLabel5.Text);
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (bunifuTextBox5.Text.Length == 0)
            {
                bunifuLabel7.Text = "0";
            }
            else
            {

                double div = Convert.ToDouble(bunifuTextBox5.Text) / Pre;
                Pd = Convert.ToInt32(div * 100);
                Pd = Pre - Pd;
                bunifuLabel7.Text = Convert.ToString(Pd);
            }
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
