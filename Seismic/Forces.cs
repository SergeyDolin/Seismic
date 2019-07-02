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
    class Forces
    {
        public List<Double> Ftwo(Double ang, Double a, Double alpha)
        {
            List<Double> fTwo = new List<Double>();
            
            fTwo.Add((Math.Pow(ang, 2) * a * (1 - alpha) * Math.Sqrt(1 + 4 * Math.Tan(35 * (Math.PI / 180)))) / (3 * (Math.Sqrt(Math.Pow((1 - alpha), 2) + Math.Tan(35 * (Math.PI / 180))))));
            return fTwo;
        }
        public List<Double> Fk(Double f2)
        {
            List<Double> FK = new List<Double>();
            double beta = Math.Atan(2 * Math.Tan(35 * (Math.PI / 180)));
            double alpha = (90 * (Math.PI / 180)) - ((35 * (Math.PI / 180)) + beta);
            FK.Add(f2 * Math.Cos(alpha));

            return FK;
        }
        public List<Double> Fn(Double f2)
        {
            List<Double> FN = new List<Double>();
            double beta = Math.Atan(2 * Math.Tan(35 * (Math.PI / 180)));
            double alpha = (90 * (Math.PI / 180)) - ((35 * (Math.PI / 180)) + beta);
            FN.Add(f2 * Math.Sin(alpha));
         
            return FN;
        }
        public List<Double> Fr(Double fk, Double fn, Double alpha)
        {
            List<Double> FR = new List<Double>();

            Double bEarth = Math.Atan(1 / (Math.Sqrt(2) * (1 - alpha)));

            FR.Add(fn * Math.Cos(bEarth) - fk * Math.Sin(bEarth));

            return FR;
        }
    }
}