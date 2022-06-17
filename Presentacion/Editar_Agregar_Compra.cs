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
    public partial class Editar_Agregar_Compra : Form
    {
        //Instancia para acceder a los metodos de la capa Intermedio
        Compra Comp = new Compra();

        public Editar_Agregar_Compra()
        {
            InitializeComponent();
        }

        public void Listar_detalles_C()
        {
            DataTable dt = Comp.Mostrar_detalles_C();
            dataGridView1.DataSource = dt;
        }

        //Variables para validar los click de cada boton
        public Boolean Agregar = false;

        //Buscar
        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Datos_prod();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(Datos_prod());

            label10.Text = Convert.ToString(sumaTotal);

            lista_Cal();
        }

        //Agregar / Actualizar
        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            if (Agregar == true)
            {
                String mensaje = "";
                Comp.Fecha = guna2DateTimePicker1.Value;
                Comp.Total_Monto = Double.Parse(label10.Text);
                Comp.Proveedor_idProveedor = Int32.Parse(guna2TextBox2.Text);

                mensaje = Comp.Agregar();

                MessageBox.Show(mensaje, "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (mensaje == "compra registrado exitosamente")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        Comp.Cantidad = Int32.Parse(Lista_Detalle_Compra.Rows[i][1].ToString());
                        Comp.Precio = double.Parse(Lista_Detalle_Compra.Rows[i][0].ToString());
                        Comp.Monto = double.Parse(Lista_Detalle_Compra.Rows[i][2].ToString());
                        Comp.Compra_idCompra = Int32.Parse(guna2TextBox1.Text);
                        Comp.Producto_idProducto = Int32.Parse(Datos_prod().Rows[0][0].ToString());

                        Comp.Agregar_DC();

                        Agregar = false;

                    }

                    this.Close();
                }
            }

        }


        public DataTable Datos_prod()
        {
            Comp.Nombre = bunifuTextBox1.Text;
            DataTable dt = new DataTable();
            dt = Comp.Extraer_datos();

            return dt;
        }

        DataTable Lista_Detalle_Compra = new DataTable();
        double sumaTotal = 0;
        private DataTable lista_Cal()
        {
            double precio_venta = double.Parse(Datos_prod().Rows[0][2].ToString());
            double precio_compra = precio_venta - (precio_venta * 0.15);
            int cantidad = int.Parse(guna2ComboBox1.Text);

            double Mont = cantidad * precio_compra;
            sumaTotal = sumaTotal + Mont;

            Lista_Detalle_Compra.Rows.Add(precio_compra,cantidad,Mont);

           return Lista_Detalle_Compra;
        }

        
    }
}
