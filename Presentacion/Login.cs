using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Intermedio;

namespace Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

           Users USE = new Users();

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        //cerrar
        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Iniciar Secion
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String mensaje = "";

            USE.Nombre = guna2TextBox1.Text;
            USE.contras = guna2TextBox2.Text;

            mensaje = USE.Verificaion();
            MessageBox.Show(mensaje);

            if (mensaje == "Por favor rellene todos los campos"  || mensaje == "Datos Incorrectos")
            {
              
            }
            else
            {
                this.Close();
            }
        }

        //Ayuda
        private void bunifuPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {           
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion aun no disponible","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
