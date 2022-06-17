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
    public class Descuento
    {
        Conexion_BD conex = new Conexion_BD();

        public string ID { get; set; }

        public int Porcentaje { get; set; }

        public string Inicio { get; set; }

        public string Final { get; set; }

        public decimal Precio { get; set; }

        public int ID_p { get; set; }

        public DataTable Estado()
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("id_p", ID_p));
            return conex.Ejecutar_Procedimientos_SPC("obtener_est", L);
        }

        public string Agregar()
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("id_p", ID_p));
            L.Add(new Parametros("ini", Inicio));
            L.Add(new Parametros("fin", Final));
            L.Add(new Parametros("Prec", Precio));
            L.Add(new Parametros("Porc", Porcentaje));
            L.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));
            conex.Ejecutar_Procedimientos_SP("Agregar_descuento", L);
            return L[5].Valor.ToString();
        }

        public void Actualizar_descuento()
        {
            conex.Ejecutar_Procedimientos_SP("Actualizar_des", null);
        }

        public DataTable Tiempo_restante()
        {
            List < Parametros> L = new List<Parametros>();
            L.Add(new Parametros("id_p",ID_p));
            return conex.Ejecutar_Procedimientos_SPC("Temp_res", L);
        }

        public string Terminar ()
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("id_p", ID_p));
            L.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));
            conex.Ejecutar_Procedimientos_SP("Fin_des", L);
            return L[1].Valor.ToString();
        }
    }
}
