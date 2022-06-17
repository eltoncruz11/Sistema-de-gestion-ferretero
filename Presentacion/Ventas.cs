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
    public partial class Ventas : Form
    {
        Ventas_ct_cd Vent = new Ventas_ct_cd();
        public Ventas()
        {
            InitializeComponent();

        }

        //Selecionar Cliente
        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            Seleccionar_cliente Selec = new Seleccionar_cliente();
            Selec.Show();
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Datos_prod();
        }

        //boton agregar
        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            //invocacion de metodos
            MontoTotal();
            Ganancia_V();

            //Agregar el producto seleccionado a el carrito
            dataGridView1.Rows.Add(D_T);

            //mostrar el subtotal de la venta
            label9.Text = sumaTotal.ToString();

            //mostrar el total de la venta
            label10.Text = Convert.ToString(sumaTotal - double.Parse(guna2ComboBox2.Text));


        }

        //boton Vender
        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            //ventas al contado
            if (guna2ComboBox3.Text == "Contado")
            {
                String mensaje = "";

                Vent.Fecha = guna2DateTimePicker1.Value;
                Vent.Total_Monto = double.Parse(label10.Text);
                Vent.Ganancia_Total = gananciaTotal;
                mensaje = Vent.Agregar_ct();

                if (mensaje == "venta registrada exitosamente")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //Detalles de ventas al contado
                        Vent.Cantidad = Int32.Parse(dt.Rows[i][1].ToString());
                        Vent.Monto = double.Parse(dt.Rows[i][0].ToString());
                        Vent.Venta_Cd_idVentas = Int32.Parse(guna2TextBox2.Text);
                        Vent.Producto_idProducto = Int32.Parse(dataGridView1.Rows[i].Cells[0].ToString());

                        Vent.Agregar_D_ct();
                    }

                    this.Close();

                }
            }
            //ventas al credito
            else if (guna2ComboBox3.Text == "Credito")
            {
                String mensaje = "";

                Vent.Fecha = guna2DateTimePicker1.Value;
                Vent.Total_Monto = double.Parse(label10.Text);
                Vent.Ganancia_Total = gananciaTotal;
                mensaje = Vent.Agregar_cd();

                if (mensaje == "venta registrada exitosamente")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //Detalles de ventas al credito
                        Vent.Cantidad = Int32.Parse(dt.Rows[i][1].ToString());
                        Vent.Monto =  double.Parse(dt.Rows[i][0].ToString());
                        Vent.Venta_Cd_idVentas = Int32.Parse(guna2TextBox2.Text);
                        Vent.Producto_idProducto = Int32.Parse(dataGridView1.Rows[i].Cells[0].ToString());

                        Vent.Agregar_D_cd();
                    }

                    this.Close();
                }
            }
        }

        #region metodos de apoyo para la funcionalidad

        //variable para capturar los datos de cada producto
        DataTable D_T = new DataTable();

        //Consultar la exixtencia del producto
        public DataTable Datos_prod()
        {
            //enviando el nombre del producto
            Vent.Nombre = bunifuTextBox1.Text;

            //guardando la consulta del producto en la variable
            D_T = Vent.Extraer_datos();

            return D_T;
        }

        //Acumulador para sumar todos los totales
        double sumaTotal = 0;

        //Guardar montos totales de cada producto
        DataTable dt = new DataTable();

        //Calcular el total a pagar por cada producto
        private double MontoTotal()
        {
            //varibales para calcular los totales de cada producto
            double cantidad = Int32.Parse(guna2ComboBox4.Text);
            double PrecioProducto = double.Parse(D_T.Rows[0][2].ToString());

            //Calculo del total unitario
            double Mont = cantidad * PrecioProducto;

            //Guardando las cantidades y totales de cada producto
            dt.Rows.Add(Mont,cantidad);

            //asignando el incremento al acumulador
            sumaTotal = sumaTotal + Mont;

            return Mont;
        }

        //Acumulador para sumar la ganancia total
        double gananciaTotal = 0;

        //Calcular la ganancia total de cada producto vendido
        private void Ganancia_V()
        {
            double precio_Venta = double.Parse(D_T.Rows[0][2].ToString());
            double precio_compra = precio_Venta - (precio_Venta * 0.15);
            int cantidad = int.Parse(guna2ComboBox4.Text);

            double T1 = precio_Venta * cantidad;
            double T2 = precio_compra * cantidad;

            double Ganancia = T1 - T2;

            gananciaTotal = gananciaTotal + Ganancia;
           
        }


        #endregion

        
    }
}