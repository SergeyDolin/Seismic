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

namespace Seismic
{
    class WGS_84
    {
        public double a = 6378137;
        public double b = 6356752.3142;
        public double Meart_f = 398600441800000;
        public double M = 5.9721864;
        public double alphA = 0.00335281066474;
        public double Ye_true = 9.7803253359;
        public double Yp_true = 9.8321849379;
        public double f = 0.0033528106647475;
        public double BETA = 0.005302441403420636;
        
        public Double B()
        {
            return a * (1 - f);
        }
        public Double e2()
        {
            return 2 * f - Math.Pow(f, 2);
        }
        public Double el2(Double e2)
        {
            return e2 / (1 - e2);
        }
        public Double E(Double e2)
        {
            return Math.Sqrt(e2) * a;
        }
        public Double QZero(Double el2)
        {
            Double q = 0.5*((1 + (3 / el2)) * Math.Atan(Math.Sqrt(el2)) - (3 / Math.Sqrt(el2)));
            return q;
        }
        public Double m(Double Ang, Double B)
        {
            return (Math.Pow(Ang, 2) * Math.Pow(a, 2) * B) / Meart_f;
        }
        public Double q(Double Ang)
        {
            return (Math.Pow(Ang, 2) * Math.Pow(a, 3)) / Meart_f;
        }
        public Double J2(Double e2, Double m, Double el2, Double q0)
        {
            return (e2 / 3) * (1 - (2 * m * Math.Sqrt(el2)) / (15 * q0));
        }
        public Double a_Angular_velocity(Double q, Double J2)
        {
            return 1.5 * J2 + 0.5 * q + (9 / 8) * Math.Pow(J2, 2) - (11 / 56) * Math.Pow(q, 2) - (3 / 14) * J2 * q; ;
        }
        public Double delta_Alpha(Double alpha_angular)
        {
            return alphA - alpha_angular;
        }
        public Double Delta_A(Double dAlpha)
        {
            return (a/(3*(1-alphA)))*dAlpha;
        }
        public Double NEW_A(Double da)
        {
            return a + da;
        }
        public Double Delta_B(Double newA, Double dAlpha)
        {
            return ((-2 / 3) * newA) * dAlpha;
        }
        public Double NEW_B(Double db)
        {
            return b + db;
        }
        public Double Alpha(Double A, Double B)
        {
            return ((A - B) / A);
        }
        //Отношение центробежной силы к силе тяжести на экваторе
        public Double Centrifugal_Force(Double Angular, Double A)
        {
            double q = (Math.Pow(Angular, 2) * A) / Ye_true;
            return q;
        }
        //Моменты инерции
        public Double main_momentC_Af(Double A, Double Alpha, Double Angular)
        {
            Double C_Af = Meart_f * (Math.Pow(A, 2) / 3) * (2 * Alpha - Math.Pow(Alpha, 2)) - ((Math.Pow(Angular, 2) * Math.Pow(A, 5)) / 3) * (1 - (9 / 7) * Alpha + (25 / 49) * Math.Pow(Alpha, 2));
            return C_Af;
        }
        public Double main_momentCgeo(Double A, Double Alpha, Double m)
        {
            Double Cgeo = (0.66666666666666666666 * (M * Math.Pow(10, 24)) * Math.Pow(A, 2)) * (1 - 0.4 * Math.Sqrt(((5 * m) / (2 * f)) - 1));
            return Cgeo;
        }
        public Double main_momentAgeo(Double A, Double C20, Double Cgeo)
        {
            Double Ageo = Cgeo + Math.Sqrt(5) * (M * Math.Pow(10, 24)) * Math.Pow(A, 2) * C20;
            return Ageo;
        }
        public Double main_momentHgeo(Double Ageo, Double Cgeo)
        {
            Double Hgeo = (Cgeo - Ageo) / Cgeo;
            return Hgeo;
        }
        //Параметр фигуры Земли
        public Double parm_Earth(Double q)
        {
            Double alp = (((5 / 2) * q) - BETA) / (1 + (17 / 14) * q);
            Double u = alp - ((1 / 2) * q) - ((1 / 2) * Math.Pow(alp, 2)) + ((3 / 4) * Math.Pow(q, 2)) + ((1 / 7) * alp * q) - ((11 / 98) * Math.Pow(alp, 2) * q) - ((9 / 8) * Math.Pow(q, 3));
            return u;
        }
        //Потенциал поверхности уровенного эллипсоида
        public Double potential(Double E, Double el2, Double Ang, Double newA)
        {
            Double U = (Meart_f / E) * Math.Atan(Math.Sqrt(el2)) + (Math.Pow(Ang, 2) * Math.Pow(newA, 2)) / 3;
            return U;
        }

        public Double SquareSegmentEarth(double fi_1, double fi_2)
        {
            Double S = new double();
            return S = 2 * Math.PI * Math.Pow(6378.137, 2) * Math.Abs((Math.Sin(fi_1) - Math.Sin(fi_2)));
        }
    }
}