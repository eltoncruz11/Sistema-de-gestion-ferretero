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
    public partial class Fac_lis : Form
    {
        Ventas_ct_cd ven = new Ventas_ct_cd();
        Ventas v = new Ventas();
        Clientes cl = new Clientes();
        public Fac_lis(Ventas d)
        {
            InitializeComponent();
            v = d;
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (v.guna2ComboBox3.SelectedItem.ToString() == "Contado")
            {
                clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();

                Ticket1.TextoCentro("Ferreteria Rey de Reyes"); //imprime una linea de descripcion
                Ticket1.TextoCentro("**********************************");

                Ticket1.TextoIzquierda("");
                Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
                Ticket1.TextoIzquierda("No Fac: "+v.guna2TextBox2.Text);
                Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                Ticket1.TextoIzquierda("Le Atendio: Yader Centeno");
                Ticket1.TextoIzquierda("");
                clsFactura.CreaTicket.LineasGuion();

                clsFactura.CreaTicket.EncabezadoVenta();
                clsFactura.CreaTicket.LineasGuion();
                DataTable dt = ven.DETALLECT(v.idv);
                //foreach (dt r in r.Rows)
                //{
                //    // PROD                     //PrECIO                                    CANT                         TOTAL
                //    Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), double.Parse(r.Cells[2].Value.ToString()), int.Parse(r.Cells[3].Value.ToString()), double.Parse(r.Cells[4].Value.ToString())); //imprime una linea de descripcion
                //}

              
                    for(int j = 0; j< dt.Rows.Count; j++)
                    {
                        Ticket1.AgregaArticulo(dt.Rows[j][0].ToString(), double.Parse(dt.Rows[j][1].ToString()), int.Parse(dt.Rows[j][2].ToString()), double.Parse(dt.Rows[j][3].ToString())); //imprime una linea de descripcion
                    }
                

                clsFactura.CreaTicket.LineasGuion();
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Total",Convert.ToDouble(v.pre.ToString())); // imprime linea con total
                Ticket1.TextoIzquierda(" ");
                if (v.des==false)
                {
                    Ticket1.AgregaTotales("Descuento:", Convert.ToDouble(Convert.ToString(0)));
                    Ticket1.AgregaTotales("Monto total:", Convert.ToDouble(v.pre.ToString()));
                   
                }
                else
                {
                    Ticket1.AgregaTotales("Descuento:", Convert.ToDouble(v.guna2ComboBox2.SelectedItem.ToString()));
                    Ticket1.AgregaTotales("Monto total:", Convert.ToDouble(v.pres.ToString()));
                }
        


                //Ticket1.LineasTotales("");  // imprime linea 

                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoCentro("**********************************");
                Ticket1.TextoCentro("*     Gracias por preferirnos    *");

                Ticket1.TextoCentro("**********************************");
                Ticket1.TextoIzquierda(" ");
                string impresora = "Microsoft XPS Document Writer";
                Ticket1.ImprimirTiket(impresora);

                this.Close();
            }
            else if (v.guna2ComboBox3.SelectedItem.ToString() == "Credito")
            {
                clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();

                Ticket1.TextoCentro("Ferreteria Rey de Reyes"); //imprime una linea de descripcion
                Ticket1.TextoCentro("**********************************");

                Ticket1.TextoIzquierda("");
                Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
                Ticket1.TextoIzquierda("No Fac: " + v.guna2TextBox2.Text);
                Ticket1.TextoIzquierda("Cliente: " + v.Nombrec);
                Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                Ticket1.TextoIzquierda("Le Atendio: Yader Centeno");
                Ticket1.TextoIzquierda("");
                clsFactura.CreaTicket.LineasGuion();

                clsFactura.CreaTicket.EncabezadoVenta();
                clsFactura.CreaTicket.LineasGuion();
                DataTable dt = ven.DETALLECT(v.idv);
                //foreach (dt r in r.Rows)
                //{
                //    // PROD                     //PrECIO                                    CANT                         TOTAL
                //    Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), double.Parse(r.Cells[2].Value.ToString()), int.Parse(r.Cells[3].Value.ToString()), double.Parse(r.Cells[4].Value.ToString())); //imprime una linea de descripcion
                //}


                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    Ticket1.AgregaArticulo(dt.Rows[j][0].ToString(), double.Parse(dt.Rows[j][1].ToString()), int.Parse(dt.Rows[j][2].ToString()), double.Parse(dt.Rows[j][3].ToString())); //imprime una linea de descripcion
                }


                clsFactura.CreaTicket.LineasGuion();
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Total", Convert.ToDouble(v.pre.ToString())); // imprime linea con total
                Ticket1.TextoIzquierda(" ");
                cl.ID = v.idc;
                DataTable d = cl.Listad();
                if (d.Rows.Count == 0)
                {
                    Ticket1.AgregaTotales("Monto anterior:", Convert.ToDouble("0"));
                }
                else
                {
                    Ticket1.AgregaTotales("Monto anterior:", Convert.ToDouble(d.Rows[0][0].ToString()));

                }
                if (v.des == false)
                {
                    Ticket1.AgregaTotales("Descuento:", Convert.ToDouble(Convert.ToString(0)));
                    Ticket1.AgregaTotales("Monto total:", Convert.ToDouble(v.pre.ToString()));

                }
                else
                {
                    Ticket1.AgregaTotales("Descuento:", Convert.ToDouble(v.guna2ComboBox2.SelectedItem.ToString()));
                    Ticket1.AgregaTotales("Monto total:", Convert.ToDouble(v.pres.ToString()));
                }



                //Ticket1.LineasTotales("");  // imprime linea 

                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoCentro("**********************************");
                Ticket1.TextoCentro("*     Gracias por preferirnos    *");

                Ticket1.TextoCentro("**********************************");
                Ticket1.TextoIzquierda(" ");
                string impresora = "Microsoft XPS Document Writer";
                Ticket1.ImprimirTiket(impresora);

                this.Close();
            }
        }
    }
}
