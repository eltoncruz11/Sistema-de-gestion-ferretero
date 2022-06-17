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
    public class inventario
    {
        Conexion_BD conex = new Conexion_BD();

        public int ID { get; set; }

        public string Name { get; set; }

        public string Descripcion { get; set; }

        public int Precio { get; set; }

        public String Marca { get; set; }

        public int Categoria { get; set; }

        public string Fecha { get; set; }


        public DataTable Contar_cat()
        {
            return conex.Ejecutar_Procedimientos_SPC("Contar_categoria", null);
        }

        public DataTable Contar_mar()
        {
            return conex.Ejecutar_Procedimientos_SPC("Contar_Marca", null);
        }

        public DataTable Contar_prod()
        {
            return conex.Ejecutar_Procedimientos_SPC("Contar_producto", null);
        }
        public DataTable Listar()
        {
            return conex.Ejecutar_Procedimientos_SPC("Listar_producto", null);
        }
       
        public string Agregar()
        {
            List<Parametros> Lis = new List<Parametros>();
            Lis.Add(new Parametros("Id", ID));
            Lis.Add(new Parametros("Nom", Name));
            Lis.Add(new Parametros("Descrip",Descripcion));
            Lis.Add(new Parametros("Prec",Precio));
            Lis.Add(new Parametros("Marc",Marca));
            Lis.Add(new Parametros("Fec", Fecha));
            Lis.Add(new Parametros("Cat",Categoria));
            Lis.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));
            conex.Ejecutar_Procedimientos_SP("Agregar_producto", Lis);
            return Lis[7].Valor.ToString();
        }

        public void Eliminar()
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("id", ID));
            conex.Ejecutar_Procedimientos_SP("Eliminar_producto", L);
        }
        public  string Editar()
        {
            List<Parametros> Lis = new List<Parametros>();
            Lis.Add(new Parametros("Id", ID));
            Lis.Add(new Parametros("Nom", Name));
            Lis.Add(new Parametros("Descrip", Descripcion));
            Lis.Add(new Parametros("Prec", Precio));
            Lis.Add(new Parametros("Marc", Marca));
            Lis.Add(new Parametros("Fec", Fecha));
            Lis.Add(new Parametros("Cat", Categoria));
            Lis.Add(new Parametros("Mensaje", "", MySqlDbType.VarChar, 80));
            conex.Ejecutar_Procedimientos_SP("Editar_producto", Lis);
            return Lis[7].Valor.ToString();
        }

        public DataTable Informacion ()
        {
            List<Parametros> L = new List<Parametros> ();
            L.Add(new Parametros("Id", ID));
            return conex.Ejecutar_Procedimientos_SPC("Informacion_c", L);
        }
        public DataTable Buscar (string dat, int id)
        {
            List<Parametros> L = new List<Parametros>();
            L.Add(new Parametros("dato", dat));
            L.Add(new Parametros("ind", id));
            return conex.Ejecutar_Procedimientos_SPC("Buscar_prod", L);
        }



    }
}
