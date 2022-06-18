using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        /// instancia creada para poder ocultar el formulario inicio despues de su carga
        //public static Login Frm;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //asignando el accarque de la aplicacion al la intancia Frm
            Application.Run(new Contenedor());
        }
    }
}
