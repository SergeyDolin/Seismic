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
using System.Diagnostics;
using Xceed.Words.NET;
//using System.Windows.Forms.DataVisualization.Charting;

namespace Seismic
{
    public partial class FormSeismic : Form
    {
        List<Double> fk = new List<Double>();
        List<Double> fn = new List<Double>();
        List<Double> fr = new List<Double>();
        List<Double> TAI_UTC = new List<Double>();
        List<Double> UT1_UTC = new List<Double>();
        List<Double> Angular = new List<Double>();
        List<Double> A = new List<Double>();
        List<Double> B = new List<Double>();
        List<Double> ALPHA = new List<Double>();
        List<Double> dAlpha = new List<Double>();
        List<Double> FTWO = new List<Double>();
        List<Double> EQF = new List<Double>();
        List<Double> C20 = new List<Double>();
        List<Double> momC_Af = new List<Double>();
        List<Double> geoCgeo = new List<Double>();
        List<Double> geoAgeo = new List<Double>();
        List<Double> geoHgeo = new List<Double>();
        List<Double> momCdyn = new List<Double>();
        List<Double> momAdyn = new List<Double>();
        List<Double> momBdyn = new List<Double>();
        Forces forces = new Forces();
        WGS_84 wGS_84 = new WGS_84();
        angular_speed_Earth AngSpeedEarth = new angular_speed_Earth();
        Double B1 = new Double();
        Double e2 = new Double();
        Double el2 = new Double();
        Double q0 = new Double();
        List<Double> m = new List<Double>();
        List<Double> J2 = new List<Double>();
        List<Double> q = new List<Double>();
        List<Double> AvV = new List<Double>();
        int Q0_10 = new int();
        int Q10_20 = new int();
        int Q20_30 = new int();
        int Q30_40 = new int();
        int Q40_50 = new int();
        int Q50_60 = new int();
        int Q60_70 = new int();
        int Q70_80 = new int();
        int Q80_90 = new int();

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
                        var db = t.Split('\r');
                        foreach (var dbd in db)
                        {
                            UT1_UTC.Add(Double.Parse(dbd));
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
            
        }
        private void Tai_Click(object sender, EventArgs e)
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
                        var db = t.Split('\r');
                        foreach (var dbd in db)
                        {
                            TAI_UTC.Add(Double.Parse(dbd));
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        private void Inertia_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            for (int i = 0; i < momC_Af.Count() && i < geoAgeo.Count() && i < geoCgeo.Count() && i < geoHgeo.Count() && i < momAdyn.Count() && 
                i < momBdyn.Count() && i < momCdyn.Count(); i++)
            {
                textBox1.Text += "(C-A)f" + i + " = " + momC_Af[i].ToString() + " kg m^2 " + "\r\n";
                textBox1.Text += "Ageo" + i + " = " + geoAgeo[i].ToString() + " kg m^2 " + "\r\n";
                textBox1.Text += "Cgeo" + i + " = " + geoCgeo[i].ToString() + " kg m^2 " + "\r\n";
                textBox1.Text += "Hgeo" + i + " = " + geoHgeo[i].ToString() + "\r\n";
                textBox1.Text += "Adyn" + i + " = " + momAdyn[i].ToString() + " kg m^2 " + "\r\n";
                textBox1.Text += "Bdyn" + i + " = " + momBdyn[i].ToString() + " kg m^2 " + "\r\n";
                textBox1.Text += "Cdyn" + i + " = " + momCdyn[i].ToString() + " kg m^2 " + "\r\n";
            }
            /*for (int i = 0; i < FTWO.Count() && i < fk.Count() && i < fn.Count() && i < fr.Count(); i++)
            {
                textBox1.Text += "Fk"+ i + " = " + fk[i].ToString() + " H " + "\r\n";
                textBox1.Text += "Fn" + i + " = " + fn[i].ToString() + " H " + "\r\n";
                textBox1.Text += "Fr" + i + " = " + fr[i].ToString() +" H " + "\r\n";
                textBox1.Text += "Fd" + i + " = " + FTWO[i].ToString() + " H " + "\r\n";
            }*/
        }
        private void Earthquakes_Click(object sender, EventArgs e)
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
                        var db = t.Split('\r');
                        foreach (var dbd in db)
                        {
                            EQF.Add(Double.Parse(dbd));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

            foreach (var qF in EQF)
            {
                if (qF >= 0 || qF < 10)
                {
                    Q0_10 += 1;
                }
                if (qF >= 10 || qF < 20)
                {
                    Q10_20 += 1;
                }
                if (qF >= 20 || qF < 30)
                {
                    Q20_30 += 1;
                }
                if (qF >= 30 || qF < 40)
                {
                    Q30_40 += 1;
                }
                if (qF >= 40 || qF < 50)
                {
                    Q40_50 += 1;
                }
                if (qF >= 50 || qF < 60)
                {
                    Q50_60 += 1;
                }
                if (qF >= 60 || qF < 70)
                {
                    Q60_70 += 1;
                }
                if (qF >= 70 || qF < 80)
                {
                    Q70_80 += 1;
                }
                if (qF >= 80 || qF <= 90)
                {
                    Q80_90 += 1;
                }
            }

            textBox1.Clear();
            textBox1.Text += "Количество землятрясений на один квадратный киллометр на сигментах с шагом в 10 градусов: " + "\r\n";
            textBox1.Text += "Сигмент от 0 до 10 = " + Q0_10 / wGS_84.SquareSegmentEarth(0,10) + " зем/м^2" + "\r\n";
            textBox1.Text += "Сигмент от 10 до 20 = " + Q10_20 / wGS_84.SquareSegmentEarth(10, 20) + " зем/м^2" + "\r\n";
            textBox1.Text += "Сигмент от 20 до 30 = " + Q20_30 / wGS_84.SquareSegmentEarth(20, 30) + " зем/м^2" + "\r\n";
            textBox1.Text += "Сигмент от 30 до 40 = " + Q30_40 / wGS_84.SquareSegmentEarth(30, 40) + " зем/м^2" + "\r\n";
            textBox1.Text += "Сигмент от 40 до 50 = " + Q40_50 / wGS_84.SquareSegmentEarth(40, 50) + " зем/м^2" + "\r\n";
            textBox1.Text += "Сигмент от 50 до 60 = " + Q50_60 / wGS_84.SquareSegmentEarth(50, 60) + " зем/м^2" + "\r\n";
            textBox1.Text += "Сигмент от 60 до 70 = " + Q60_70 / wGS_84.SquareSegmentEarth(60, 70) + " зем/м^2" + "\r\n";
            textBox1.Text += "Сигмент от 70 до 80 = " + Q70_80 / wGS_84.SquareSegmentEarth(70, 80) + " зем/м^2" + "\r\n";
            textBox1.Text += "Сигмент от 80 до 90 = " + Q80_90 / wGS_84.SquareSegmentEarth(80, 90) + " зем/м^2" + "\r\n";
        }
        private void Report_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\Serge\source\repos\Seismic\Report.docx";
            string headlineText = "Отчёт о корреляции частных производных и сейсмики Земли";
            //Подумать что писать и при каких условиях
            var headlineFormat = new Formatting();
            headlineFormat.Size = 18D;
            headlineFormat.Position = 12;

            var paraFormat = new Formatting();
            paraFormat.Size = 10D;

            var doc = DocX.Create(fileName);
            doc.InsertParagraph(headlineText, false, headlineFormat); 
            doc.Save();
            Process.Start("WINWORD.EXE", fileName);
        }
        private void Start_Click(object sender, EventArgs e)
        {
            //Угловая скорости Земли
            for (int i = 0; i < UT1_UTC.Count() && i < TAI_UTC.Count(); i++)
            {
                Angular.Add(AngSpeedEarth.Angular_velocity(TAI_UTC[i], UT1_UTC[i]));
            }
            //Приращений осей эллипсоида
            B1 = wGS_84.B();
            e2 = wGS_84.e2();
            el2 = wGS_84.el2(e2);
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
                C20.Add(wGS_84.C20(j2));
            }
            for (int i = 0; i < J2.Count() && i < q.Count(); i++)
            {
                AvV.Add(wGS_84.a_Angular_velocity(q[i], J2[i]));
            }
            foreach (var avv in AvV)
            {
                dAlpha.Add(wGS_84.delta_Alpha(avv));
            }
            foreach (var dAl in dAlpha)
            {
                A.Add(wGS_84.NEW_A(wGS_84.Delta_A(dAl)));
            }
            for (int i = 0; i < A.Count() && i < dAlpha.Count(); i++)
            {
                B.Add(wGS_84.NEW_B(wGS_84.Delta_B(A[i], dAlpha[i])));
            }
            //Сжатие эллипсоида
            for (int i = 0; i < A.Count() && i < B.Count(); i++)
            {
                ALPHA.Add(wGS_84.Alpha(A[i], B[i]));
            }
            //Моменты инерции
            //(С-А)f
            for (int i = 0; i < Angular.Count() && i < A.Count() && i < ALPHA.Count(); i++)
            {
                momC_Af.Add(wGS_84.main_momentC_Af(A[i], ALPHA[i], Angular[i]));
            }
            //geoCgeo
            for (int i = 0; i < A.Count() && i < m.Count(); i++)
            {
                geoCgeo.Add(wGS_84.geometric_momentCgeo(A[i],m[i]));
            }
            //geoAgeo
            for (int i = 0; i < A.Count() && i < C20.Count() && i < geoCgeo.Count(); i++)
            {
                geoAgeo.Add(wGS_84.geometric_momentAgeo(A[i],C20[i],geoCgeo[i]));
            }
            //geoHgeo
            for (int i = 0; i < geoAgeo.Count() && i < geoCgeo.Count(); i++)
            {
                geoHgeo.Add(wGS_84.geometric_momentHgeo(geoAgeo[i], geoCgeo[i]));
            }
            //dynCmom
            for (int i = 0; i < A.Count(); i++)
            {
                momCdyn.Add(wGS_84.dynamic_momentCdyn(A[i]));
            }
            //dynAmom
            for (int i = 0; i < A.Count(); i++)
            {
                momAdyn.Add(wGS_84.dynamic_momentAdyn(A[i]));
            }
            //dynBmom
            for (int i = 0; i < A.Count(); i++)
            {
                momBdyn.Add(wGS_84.dynamic_momentBdyn(A[i]));
            }
            //Частные производные
            for (int i = 0; i < Angular.Count() && i < A.Count() && i < ALPHA.Count(); i++)
            {
                List<Double> FtwoCount = new List<Double>();
                FtwoCount = forces.Ftwo(Angular[i], A[i], ALPHA[i]);
                foreach (var f in FtwoCount)
                {
                    FTWO.Add(f);
                }
            }
            for (int i = 0; i < FTWO.Count(); i++)
            {
                List<Double> FkCount = new List<Double>();
                List<Double> FnCount = new List<Double>();
                FkCount = forces.Fk(FTWO[i]);
                FnCount = forces.Fn(FTWO[i]);
                foreach (var f in FkCount)
                {
                    fk.Add(f);
                }
                foreach (var f in FnCount)
                {
                    fn.Add(f);
                }
            }
            for (int i = 0; i < fk.Count() && i < fn.Count() && i < ALPHA.Count(); i++)
            {
                List<Double> FrCount = new List<Double>();
                FrCount = forces.Fr(fk[i], fn[i], ALPHA[i]);
                foreach (var f in FrCount)
                {
                    fr.Add(f);
                }
            }
            textBox1.Clear();
            for (int i = 0; i < Angular.Count(); i++)
            {
                textBox1.Text += "ω " + Angular[i].ToString() + " рад/сек" + "\r\n";
            }
        }
    }
}