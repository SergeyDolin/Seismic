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
        Double B1 = new Double();
        Double e2 = new Double();
        Double el2 = new Double();
        Double E = new Double();
        Double q0 = new Double();
        List<Double> m = new List<Double>();
        List<Double> J2 = new List<Double>();
        List<Double> C20 = new List<Double>();
        List<Double> q = new List<Double>();
        List<Double> AvV = new List<Double>();
        int caseForces = 0;
        double Ye = 0.0;
        public FormSeismic()
        {
            InitializeComponent();
        }

        private void Utc_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Чтение выбранного файла
                    List<string> vs = new List<string>();
                    var sr = new StreamReader(openFileDialog1.FileName);
                    vs.Add(sr.ReadToEnd());
                    //Конвертация текста в выбранный тип
                    foreach (var t in vs)
                    {
                        textBox1.Text = t;
                        var db = t.Split('\r');
                        foreach (var dbd in db)
                        {
                            ETime.Add(Double.Parse(dbd));
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
            //Линейная и угловая скорости Земли
            foreach (Double ET in ETime)
            {
                Angular.Add(line_Speed_Earth.Angular_velocity(ET));
            }
            //Приращений осей эллипсоида
            B1 = wGS_84.B();
            e2 = wGS_84.e2();
            el2 = wGS_84.el2(e2);
            E = wGS_84.E(e2);
            q0 = wGS_84.QZero(el2);
            foreach (var ang in Angular)
            {
                m.Add(wGS_84.m(ang, B1));
                q.Add(wGS_84.q(ang));

            }
            foreach (var M in m)
            {
                J2.Add(wGS_84.J2(e2, M, el2, q0));
            }
            foreach (var j2 in J2)
            {
                foreach (var Q in q)
                {
                    AvV.Add(wGS_84.a_Angular_velocity(Q, j2));
                }
            }
            foreach (var avv in AvV)
            {
                dAlpha.Add(wGS_84.delta_Alpha(avv));
            }
            foreach (var dAl in dAlpha)
            {
                A.Add(wGS_84.NEW_A(wGS_84.Delta_A(dAl)));
                foreach (var a in A)
                {
                    B.Add(wGS_84.NEW_B(wGS_84.Delta_B(a, dAl)));
                }
            }

            //Сжатие эллипсоида
            foreach (var a in A)
            {
                foreach (var b in B)
                {
                    ALPHA.Add(wGS_84.Alpha(a, b));
                }
            }
            for (int i = 0; i < Angular.Count() && i < A.Count() && i < ALPHA.Count(); i++)
            {
                FTWO = forces.Ftwo(Angular[i], A[i], ALPHA[i]);
            }
            foreach (var ftwo in FTWO)
            {
                fk = forces.Fk(FTWO);
                fn = forces.Fn(FTWO);
            }
            for (int i = 0; i < fk.Count() && i < fn.Count() && i < ALPHA.Count(); i++)
            {
                FTWO = forces.Ftwo(fk[i], fn[i], ALPHA[i]);
            }
            textBox1.Clear();
            for (int i = 0; i < Angular.Count(); i++)
            {
                //Решить проблему с переносом строки, почему то в текстбоксе не работет \n, \r.
                textBox1.Text += "ω " + Angular[i].ToString() + " рад/сек";
            }
            

        }

        private void Derivatives_Click(object sender, EventArgs e)
        {

        }
    }
}