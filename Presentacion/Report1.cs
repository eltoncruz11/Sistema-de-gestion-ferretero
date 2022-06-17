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
    public partial class Report1 : Form
    {
        Informes inf = new Informes();
        public Report1()
        {
            InitializeComponent();
        }

        private void Report1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime fecha_i = Convert.ToDateTime(guna2DateTimePicker1.Text);


            DateTime fecha_f = Convert.ToDateTime(guna2DateTimePicker2.Text);



            DataTable dt = new DataTable();
            dt = inf.infor_c(fecha_i.ToString("yyyy/MM/dd"), fecha_f.ToString("yyyy/MM/dd"));
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            this.reportViewer1.RefreshReport();
        }
    }
}
