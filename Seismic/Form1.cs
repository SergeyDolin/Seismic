using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization;
using System.Configuration;
//using System.Windows.Forms.DataVisualization.Charting;

namespace Seismic
{
    public partial class FormSeismic : Form
    {
        List<Double> fk = new List<Double>();
        List<Double> fn = new List<Double>();
        List<Double> fr = new List<Double>();
        List<Double> ETime = new List<Double>();
        List<Double> Angular = new List<Double>();
        List<Double> A = new List<Double>();
        List<Double> B = new List<Double>();
        List<Double> ALPHA = new List<Double>();
        List<Double> dAlpha = new List<Double>();
        List<Double> FTWO = new List<Double>();
        List<string> list = new List<string>();
        Forces forces = new Forces();
        WGS_84 wGS_84 = new WGS_84();
        line_speed_Earth line_Speed_Earth = new line_speed_Earth();
        Double B1 = new double();
        Double e2 = new double();
        Double el2 = new double();
        Double E = new double();
        Double q0 = new double();
        Double m = new double();
        Double J2 = new double();
        Double C20 = new double();
        Double q = new double();
        Double AvV = new double();
        int caseForces = 0;
        double Ye = 0.0;
        public FormSeismic()
        {
            InitializeComponent();
        }

        private void Utc_Click(object sender, EventArgs e)
        {

        }
    }
}
