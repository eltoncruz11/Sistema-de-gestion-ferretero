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
    public class Users
    {
        Conexion_BD conex = new Conexion_BD();

        public Int32 id { get; set; }
        public String Nombre { get; set; }
        public String contras { get; set; }

        public DataTable Lista()
        {
            return conex.Ejecutar_Procedimientos_SPC("Mostrar_usuarios", null);
        }

        public String Agregar()
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("Nombr", Nombre));
            Lista.Add(new Parametros("contras", contras));
            Lista.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));

            conex.Ejecutar_Procedimientos_SP("Agregar_usuarios", Lista);

            return Lista[2].Valor.ToString();
        }

        public String Editar()
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("idp", id));
            Lista.Add(new Parametros("Nombr", Nombre));
            Lista.Add(new Parametros("contras", contras));
            Lista.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));

            conex.Ejecutar_Procedimientos_SP("Editar_usuarios", Lista);

            return Lista[3].Valor.ToString();
        }

        public String Eliminar()
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("idp", id));
            Lista.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));

            conex.Ejecutar_Procedimientos_SP("Eliminar_usuarios", Lista);

            return Lista[2].Valor.ToString();
        }

        public DataTable Buscar(string dato, int ind)
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("dato", dato));
            Lista.Add(new Parametros("ind", ind));

            return conex.Ejecutar_Procedimientos_SPC("Buscar_usuarios", Lista);
        }

        public String Verificaion()
        {

            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("idp", Nombre));
            Lista.Add(new Parametros("contrasp", contras));
            Lista.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));

            conex.Ejecutar_Procedimientos_SP("Validacion",Lista);

            return Lista[2].Valor.ToString();
            
        }

    }
}
