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
    
    public partial class Report : Form
    {

        Informes inf = new Informes();
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime fecha_i = Convert.ToDateTime(guna2DateTimePicker1.Text);


            DateTime fecha_f = Convert.ToDateTime(guna2DateTimePicker2.Text);



            DataTable dt = new DataTable();
            dt = inf.infor_v(fecha_i.ToString("yyyy/MM/dd"), fecha_f.ToString("yyyy/MM/dd"));
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            this.reportViewer1.RefreshReport();
        }

        static string Reverse(string text)
        {
            char[] charArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                reverse += charArray[i];
            }
            return reverse;
        }
    }
}
