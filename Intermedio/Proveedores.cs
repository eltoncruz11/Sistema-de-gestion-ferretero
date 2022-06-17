using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enlace_datos;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Intermedio
{
    public class Proveedores
    {
        Conexion_BD conex = new Conexion_BD();

        public Int32 idProveedor { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public String Correo { get; set; }
        public String Dirreccion { get; set; }

        public DataTable Listar()
        {
            return conex.Ejecutar_Procedimientos_SPC("Mostrar_Proveedor", null);
        }

        public String Agregar()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("idProveed", idProveedor));
            lista.Add(new Parametros("Nombr", Nombre));
            lista.Add(new Parametros("Telefo", Telefono));
            lista.Add(new Parametros("Corrc", Correo));
            lista.Add(new Parametros("Dirrec", Dirreccion));
            lista.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));
            conex.Ejecutar_Procedimientos_SP("Agregar_Proveedor", lista);

            return lista[5].Valor.ToString();
        }

        public String Editar()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("idProveed", idProveedor));
            lista.Add(new Parametros("Nombr", Nombre));
            lista.Add(new Parametros("Telefo", Telefono));
            lista.Add(new Parametros("Corrc", Correo));
            lista.Add(new Parametros("Dirrec", Dirreccion));
            lista.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));
            conex.Ejecutar_Procedimientos_SP("Editar_Proveedor", lista);

            return lista[5].Valor.ToString();
        }

        public void Eliminar()
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("idProveed", idProveedor));
            conex.Ejecutar_Procedimientos_SP("Eliminar_proveedor", Lista);
        }

        public DataTable Buscar(string dato , int ind)
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("dato", dato));
            Lista.Add(new Parametros("ind", ind));

            return conex.Ejecutar_Procedimientos_SPC("Buscar_proveedor", Lista);
        }
    }
}
