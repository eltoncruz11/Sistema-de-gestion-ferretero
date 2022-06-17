using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enlace_datos;
using System.Data;

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

            conex.Ejecutar_Procedimientos_SP("Agregar_usuarios", Lista);

            return Lista[3].Valor.ToString();
        }

        public String Editar()
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("idp", id));
            Lista.Add(new Parametros("Nombr", Nombre));
            Lista.Add(new Parametros("contras", contras));

            conex.Ejecutar_Procedimientos_SP("Editar_usuarios", Lista);

            return Lista[3].Valor.ToString();
        }

        public void Eliminar()
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("idp", id));
            conex.Ejecutar_Procedimientos_SP("Eliminar_usuarios", Lista);

        }

        public DataTable Buscar(string dato, int ind)
        {
            List<Parametros> Lista = new List<Parametros>();
            Lista.Add(new Parametros("dato", dato));
            Lista.Add(new Parametros("ind", ind));

            return conex.Ejecutar_Procedimientos_SPC("Buscar_usuarios", Lista);
        }

    }
}
