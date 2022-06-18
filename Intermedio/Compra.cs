using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Enlace_datos;
using System.Data;


namespace Intermedio
{
    public class Compra
    {

        Conexion_BD conex = new Conexion_BD();

        #region Metodos de compra

        public Int32 idCompra { get; set; }
        public DateTime Fecha { get; set; }
        public Double Total_Monto { get; set; }
        public Int32 Proveedor_idProveedor { get; set; }

        public DataTable Listar()
        {
            return conex.Ejecutar_Procedimientos_SPC("Mostrar_compra", null);
        }

        public String Agregar()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("Fech", Fecha));
            lista.Add(new Parametros("Total_Mont", Total_Monto));
            lista.Add(new Parametros("Proveedor_idProveedo", Proveedor_idProveedor));
            conex.Ejecutar_Procedimientos_SP("Agregar_compra", lista);

            return lista[4].Valor.ToString();
        }

        public String Eliminar()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("idCompr", idCompra));
            conex.Ejecutar_Procedimientos_SP("Eliminar_compra", lista);

            return lista[3].Valor.ToString();
        }
        public DataTable Buscar(string dato, int ind)
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("dato", dato));
            Lista.Add(new Parametros("ind", ind));

            return conex.Ejecutar_Procedimientos_SPC("Buscar_compra", Lista);
        }

        public DataTable IDC()
        {
            return conex.Ejecutar_Procedimientos_SPC("Capturar_idcompra", null);
        }

        #endregion

        #region Metodo de detalles de compra
        public Int32 Cantidad { get; set; }
        public Double Precio { get; set; }
        public Double Monto { get; set; }
        public Int32 Compra_idCompra { get; set; }
        public Int32 Producto_idProducto { get; set; }

        public String Nombre { get; set; }

        public DataTable Extraer_datos()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("Nombr", Nombre));

            return conex.Ejecutar_Procedimientos_SPC("List_productos", lista);

        }

        public void Agregar_DC()
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("Cantida", Cantidad));
            Lista.Add(new Parametros("Preci", Precio));
            Lista.Add(new Parametros("Mont", Monto));
            Lista.Add(new Parametros("Compra_idCompr", Compra_idCompra));
            Lista.Add(new Parametros("Producto_idProduct", Producto_idProducto));
            conex.Ejecutar_Procedimientos_SP("Agregar_detalle_compra", Lista);

        }

        public DataTable Mostrar_detalles_C()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("idCompr", idCompra));

            return conex.Ejecutar_Procedimientos_SPC("mostrar_detalles_por_Compra", lista);
        }

        #endregion
    }
}
