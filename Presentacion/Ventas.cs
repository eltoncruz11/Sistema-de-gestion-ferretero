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
        Clientes Cli = new Clientes();
        public int idv = 0;
        public double pre = 0;
        public double pres = 0;
        public string Nombrec = "";
        public string idc = "";
        public bool des = false;
        public Ventas()
        {
            InitializeComponent();

        }

        //Selecionar Cliente
        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            Seleccionar_cliente Selec = new Seleccionar_cliente(this);
            Selec.Show();
        }

        public void ID_cli(string id,string n)
        {
            Cli.ID = id;
            idc = id;
            Nombrec = n;
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Datos_prod();

            //invocacion de metodos
            MontoTotal();
            Ganancia_V();

        }

        //boton agregar
        private void bunifuButton21_Click(object sender, EventArgs e)
        {


            //Agregar el producto seleccionado a el carrito
            dataGridView1.DataSource =D_T;

            //mostrar el subtotal de la venta
            label9.Text = sumaTotal.ToString();

            //mostrar el total de la venta
            label10.Text = Convert.ToString(sumaTotal);
            pre = Convert.ToDouble(sumaTotal);



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
                DataTable dtC = Vent.ID_V_CT();
                guna2TextBox2.Text = dtC.Rows[0][0].ToString();
                idv = Convert.ToInt32(dtC.Rows[0][0].ToString());
                if (mensaje == "venta registrada exitosamente")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //Detalles de ventas al contado
                        Vent.Cantidad = Int32.Parse(dt.Rows[i][1].ToString());
                        Vent.Monto = double.Parse(dt.Rows[i][0].ToString());
                        Vent.Venta_Cd_idVentas = Int32.Parse(dtC.Rows[0][0].ToString());
                        Vent.Producto_idProducto = Int32.Parse(D_T.Rows[i][0].ToString());

                        Vent.Agregar_D_ct();
                    }
                }

                Fac_lis fa = new Fac_lis(this);
                fa.ShowDialog();
            }
            //ventas al credito
            else if (guna2ComboBox3.Text == "Credito")
            {
    
                String mensaje = "";

                Vent.Fecha = guna2DateTimePicker1.Value;
                Vent.Total_Monto = double.Parse(label10.Text);
                Vent.Ganancia_Total = gananciaTotal;
                mensaje = Vent.Agregar_cd();
                DataTable dtCD = Vent.ID_V_CD();
               
                guna2TextBox2.Text = dtCD.Rows[0][0].ToString();
                idv = Convert.ToInt32(dtCD.Rows[0][0].ToString());

                if (mensaje == "venta registrada exitosamente")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //Detalles de ventas al credito
                        Vent.Cantidad = Int32.Parse(dt.Rows[i][1].ToString());
                        Vent.Monto =  double.Parse(dt.Rows[i][0].ToString());
                        Vent.Venta_Cd_idVentas = Int32.Parse(dtCD.Rows[0][0].ToString());
                        Vent.Producto_idProducto = Int32.Parse(D_T.Rows[i][0].ToString());

                        Vent.Agregar_D_cd();
                    }
                }
                Cli.inser_deuda(int.Parse(dtCD.Rows[0][0].ToString()));

                Fac_lis fa = new Fac_lis(this);
                fa.ShowDialog();
            }
        }

        #region metodos de apoyo para la funcionalidad



        private void Ventas_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Monto",typeof(Double));
            dt.Columns.Add("Cantidad",typeof (Double));
        }

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

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (guna2ComboBox3.SelectedItem.ToString() == "Credito")
            {
                guna2Panel1.Height = 72;
                guna2Panel2.Location = new Point(7,447);
            }
            else
            {
               guna2Panel1.Height = 0;
                guna2Panel2.Location= new Point(7,368);
            }



        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            double div = Convert.ToDouble(Convert.ToDouble(guna2ComboBox2.SelectedItem)) / pre;
            pres = Convert.ToInt32(div * 100);
            pres = pre - pres;
            label10.Text= Convert.ToString(pres);
            des = true;
        }
    }
}