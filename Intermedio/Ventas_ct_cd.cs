using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enlace_datos;
using System.Data;
using MySql.Data.MySqlClient;


namespace Intermedio
{
    public class Ventas_ct_cd
    {
        Conexion_BD conex = new Conexion_BD();

        #region Ventas Credito - Contado

        public DateTime Fecha { get; set; }
        public Double Total_Monto { get; set; }
        public Double Ganancia_Total { get; set; }
        
        public String Agregar_cd()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("Fech", Fecha));
            lista.Add(new Parametros("Total_Mont", Total_Monto));
            lista.Add(new Parametros("Ganancia_Tot", Ganancia_Total));
            lista.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));

            conex.Ejecutar_Procedimientos_SP("Agregar_venta_cd", lista);

            return lista[3].Valor.ToString();
        }

        public String Agregar_ct()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("Fech", Fecha));
            lista.Add(new Parametros("Total_Mont", Total_Monto));
            lista.Add(new Parametros("Ganancia_Tot", Ganancia_Total));
            lista.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));

            conex.Ejecutar_Procedimientos_SP("Agregar_venta_ct", lista);

            return lista[3].Valor.ToString();
        }
        #endregion

        #region detalles Credito - Contado

        public Int32 Cantidad { get; set; }
        public Double Monto { get; set; }
        public Int32 Venta_Cd_idVentas { get; set; }
        public Int32 Producto_idProducto { get; set; }

        public String Nombre { get; set; }


        public void Agregar_D_ct()
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("Cantid", Cantidad));
            Lista.Add(new Parametros("Mont", Monto));
            Lista.Add(new Parametros("Venta_Ct_idVent", Venta_Cd_idVentas));
            Lista.Add(new Parametros("Producto_idProduct", Producto_idProducto));
            conex.Ejecutar_Procedimientos_SP("Agregar_detalle_venta_ct", Lista);
        }

        public void Agregar_D_cd()
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("Cantid", Cantidad));
            Lista.Add(new Parametros("Mont", Monto));
            Lista.Add(new Parametros("Venta_Cd_idVenta", Venta_Cd_idVentas));
            Lista.Add(new Parametros("Producto_idProduct", Producto_idProducto));
            conex.Ejecutar_Procedimientos_SP("Agregar_detalle_venta_cd", Lista);
        }

        public DataTable Extraer_datos()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("Nombr", Nombre));

            return conex.Ejecutar_Procedimientos_SPC("List_productos", lista);

        }

        public DataTable ID_V_CD()
        {
            return conex.Ejecutar_Procedimientos_SPC("Capturar_idVenta_Cd", null);
        }

        public DataTable ID_V_CT()
        {
            return conex.Ejecutar_Procedimientos_SPC("Capturar_idVenta_Ct", null);
        }

        public DataTable DETALLECT(int R)
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("id", R));
            return conex.Ejecutar_Procedimientos_SPC("dvct", L);
        }
        #endregion

    }
}
