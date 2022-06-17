using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Enlace_datos;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Intermedio
{
    public class categoria
    {
        Conexion_BD conex = new Conexion_BD();

        public int ID { get; set; }

        public string Name { get; set; }

        public DataTable Listar ()
        {
            return conex.Ejecutar_Procedimientos_SPC("Listar_categoria", null);
        }

        public String Agregar()
        {
            List<Parametros> L = new List<Parametros> ();
            L.Add(new Parametros("Nomb", Name));
            L.Add(new Parametros("Mensaje", "",MySqlDbType.VarChar,80));
            conex.Ejecutar_Procedimientos_SP("Agregar_categoria", L);
            return L[1].Valor.ToString();
        }

        public String Editar()
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("id", ID));
            L.Add(new Parametros("Nom",Name ));
            L.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));
            conex.Ejecutar_Procedimientos_SP("Editar_categoria", L);
            return L[2].Valor.ToString();
        }

        public void Eliminar()
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("id", ID));
            conex.Ejecutar_Procedimientos_SP("Eliminar_categoria", L);
        }

    }
}
