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
    public class Clientes
    {
        Conexion_BD conex = new Conexion_BD();
        public String ID { get; set; }
        public String Nombre { get; set; }

        public string Apellido { get; set; }
        public string Contacto { get; set; }

        public string Direccion { get; set; }

        public DataTable Listar ()
        {
            return conex.Ejecutar_Procedimientos_SPC("Listar_clientes", null);
        }

        public String Agregar()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("id", ID));
            lista.Add(new Parametros("Nom", Nombre));
            lista.Add(new Parametros("Apell", Apellido));
            lista.Add(new Parametros("Contac", Contacto));
            lista.Add(new Parametros("Dir", Direccion));
            lista.Add(new Parametros("Mensaje","", MySqlDbType.VarChar , 80));
            conex.Ejecutar_Procedimientos_SP("Agregar_Cliente", lista);

            return lista[5].Valor.ToString();
        }

        public String Editar()
        {
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros("id", ID));
            lista.Add(new Parametros("Nom", Nombre));
            lista.Add(new Parametros("Apell", Apellido));
            lista.Add(new Parametros("Contac", Contacto));
            lista.Add(new Parametros("Dir", Direccion));
            lista.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));
            conex.Ejecutar_Procedimientos_SP("Editar_cliente", lista);

            return lista[5].Valor.ToString();
        }

    }
}
