using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;



namespace Enlace_datos
{
    public class Parametros
    {
        //Parametros
        public String Nombre { get; set; }
        public Object Valor { get; set; }
        public MySqlDbType TipoDato { get; set; }
        public Int32  Tamaño { get; set; }
        public ParameterDirection Direccion { get; set; }


        //constructores

        #region Contructor de Entrada
        public Parametros(String Ojb_Nombre, object Obj_Valor)
        {
            Nombre = Ojb_Nombre;
            Valor = Obj_Valor;
            Direccion = ParameterDirection.Input;
        }
        #endregion

        #region Contructor de Salida
        public Parametros (String Obj_Nombre,object valor,MySqlDbType Obj_TipoDato, Int32 Obj_Tamaño)
        {
            Nombre=Obj_Nombre;
            TipoDato=Obj_TipoDato;
            Tamaño = Obj_Tamaño;
            Valor = valor;
            Direccion=ParameterDirection.Output;
        }
        #endregion
    }
}
