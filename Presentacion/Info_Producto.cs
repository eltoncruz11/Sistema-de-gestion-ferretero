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
    public partial class Info_Producto : Form
    {
        Inventario inve;
        inventario inv = new inventario();
        public Info_Producto(Inventario V)
        {
            InitializeComponent();
            inve = V;
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void Info_Producto_Load(object sender, EventArgs e)
        {
            inv.ID = Convert.ToInt32(inve.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DataTable R = inv.Informacion();
            bunifuLabel2.Text = R.Rows[0][1].ToString();
            bunifuTextBox5.Text = R.Rows[0][2].ToString();
            bunifuLabel6.Text = R.Rows[0][6].ToString();
            bunifuLabel8.Text = R.Rows[0][3].ToString();
            bunifuLabel12.Text = R.Rows[0][5].ToString();
            bunifuLabel10.Text = R.Rows[0][7].ToString();
        }
    }
}
