using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Enlace_datos
{
    public class Conexion_BD
    {
        MySqlConnection Conexion = new MySqlConnection("Server=localhost; Database=sgf;Uid=root;Pwd=rewrite11");

        #region Metodo para abrir conexion
        void Abrir_Conexion()
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
        }
        #endregion

        #region Metodo para Cerrar conexion
        void Cerrar_Conexion()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
        }
        #endregion

        //Metodos para ejecutar los procesos

        #region Metodo para ejecutar los procesos almacenados (SP) con parametros (Insert,Delete,Update)
        public void Ejecutar_Procedimientos_SP(String Nombre_SP,List<Parametros> Lista)
        {
            MySqlCommand cmd;

            try
            {
              
                Abrir_Conexion();
                cmd = new MySqlCommand(Nombre_SP,Conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                if (Lista != null)
                {
                    for (int i = 0; i < Lista.Count; i++)
                    {
                        if (Lista[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(Lista[i].Nombre, Lista[i].Valor);

                        }

                        if (Lista[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(Lista[i].Nombre, Lista[i].TipoDato, Lista[i].Tamaño).Direction = ParameterDirection.Output;
                        }
                    }
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < Lista.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                        {
                            Lista[i].Valor = cmd.Parameters[i].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            Cerrar_Conexion();
        }
        #endregion

        #region Metodo para ejecutar los procesos almacenados (SP) sin parametros (Select)
        public DataTable Ejecutar_Procedimientos_SPC(String Nombre_SP,List<Parametros> Lista)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da;

            try
            {
                da = new MySqlDataAdapter(Nombre_SP,Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (Lista != null)
                {
                    for (int i = 0; i < Lista.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(Lista[i].Nombre, Lista[i].Valor);
                    }
                }
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dt;
        }
        #endregion
    }
}