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
    public partial class Desc_act : Form
    {
        Descuento Des = new Descuento();
        Inventario inv = new Inventario();
        public Desc_act(Inventario i)
        {
            InitializeComponent();
            inv = i;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string Men = "";
            Men = Des.Terminar();
            MessageBox.Show(Men,"Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Desc_act_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Des.ID_p = Convert.ToInt32(inv.dataGridView1.CurrentRow.Cells[0].Value);
            dt = Des.Tiempo_restante();

            bunifuLabel2.Text = dt.Rows[0][0].ToString();
            bunifuLabel9.Text = dt.Rows[0][1].ToString();
            bunifuLabel5.Text = dt.Rows[0][2].ToString();
            bunifuLabel7.Text = dt.Rows[0][3].ToString();

        }
    }
}
