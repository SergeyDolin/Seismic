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
    class line_speed_Earth
    {
        public Double Angular_velocity(Double eTime)
        { 
            Double ASpeed = (2 * Math.PI) / (86164 + eTime);
            return ASpeed;
        }
        public Double Line_Speed(Double ASpeed)
        {
            WGS_84 _84 = new WGS_84();
            Double lineS = (((_84.a * _84.b) / Math.Sqrt((Math.Pow(_84.b, 2) + Math.Pow(_84.a, 2) * Math.Pow(Math.Tan(0*(Math.PI/180)),2)))) *
                    (Math.Pow(_84.b, 2) / (Math.Sqrt(Math.Pow(_84.b,4) + Math.Pow(_84.a,4) * Math.Pow(Math.Tan(0 * (Math.PI/180)), 2)))))*ASpeed;       
            return lineS;
        }
       
    }
}
