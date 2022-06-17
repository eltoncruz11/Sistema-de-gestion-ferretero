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
    public partial class Editar_Agregar_Proveedor : Form
    {
        //Instancia para acceder a los metodos de la capa Intermedio
        Proveedores Prov = new Proveedores();

        public Editar_Agregar_Proveedor()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (guna2GradientButton1.Text == "Agregar")
            {
                String mensaje = "";
                Prov.idProveedor = int.Parse(guna2TextBox1.Text);
                Prov.Nombre = guna2TextBox2.Text;
                Prov.Telefono = guna2TextBox3.Text;
                Prov.Correo = guna2TextBox4.Text;
                Prov.Dirreccion = guna2TextBox5.Text;

                mensaje = Prov.Agregar();

                MessageBox.Show(mensaje,"Informacion",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);

                if (mensaje == "Proveedor registrado exitosamente")
                {
                    this.Close();
                }
            }
            else if (guna2GradientButton1.Text == "Actualizar")
            {
                String mensaje = "";
                Prov.idProveedor = int.Parse(guna2TextBox1.Text);
                Prov.Nombre = guna2TextBox2.Text;
                Prov.Telefono = guna2TextBox3.Text;
                Prov.Correo = guna2TextBox4.Text;
                Prov.Dirreccion = guna2TextBox5.Text;

                mensaje = Prov.Editar();

                MessageBox.Show(mensaje, "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (mensaje == "Los datos de actualizaron exitosamente")
                {
                    this.Close();
                }
            }
        }
    }
}
