using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Contenedor : Form
    {
        Login US = new Login();

        public Contenedor()
        {  US.ShowDialog(); 
            InitializeComponent();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Abrir formularios dentro del panel contenedor
        private void AbrirFormHij(object formhij)
        {
            if (this.guna2Panel5.Controls.Count > 0)
            {
                this.guna2Panel5.Controls.RemoveAt(0);
            }
                Form FH = formhij as Form;
                FH.TopLevel = false;
                FH.Dock = DockStyle.Fill;
                this.guna2Panel5.Controls.Add(FH);
                this.guna2Panel5.Tag = FH;
                FH.Show();
            
        }

        //Usuarios
        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            AbrirFormHij(new Usuarios());
        }

        //Ventas

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbrirFormHij(new Ventas());
        }

        //Compras
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AbrirFormHij(new Compras());
        }

        //Inventario
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AbrirFormHij(new Inventario());
        }

        //Proveedores
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AbrirFormHij(new Proveedore());
        }

        //Clientes
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            AbrirFormHij(new Cliente());
        }

        //reporte
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2Panel4.Height = 142;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            AbrirFormHij(new Report());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            AbrirFormHij(new Report1());
        }
    }
}
