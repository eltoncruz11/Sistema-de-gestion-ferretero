using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Enlace_datos;

namespace Intermedio
{
    public class Informes
    {
        Conexion_BD conex = new Conexion_BD();

        public DataTable infor_v(string fecha_i, string fecha_f)
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("fecha_i", fecha_i));
            L.Add(new Parametros("fecha_f", fecha_f));
            return conex.Ejecutar_Procedimientos_SPC("Infor_venta", L);
        }
        public DataTable infor_c(string fecha_i, string fecha_f)
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("fecha_i", fecha_i));
            L.Add(new Parametros("fecha_f", fecha_f));
            return conex.Ejecutar_Procedimientos_SPC("Infor_compra", L);
        }

    }
}
