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
    class angular_speed_Earth
    {
        public Double Angular_velocity(Double TAI_UT1, Double UT1_UTC)
        {
            Double deltaT = 32.184 - (TAI_UT1) - (UT1_UTC);
            Double EarthAngularSpeed = (2 * Math.PI) / (86164.090530833 + deltaT);
            return EarthAngularSpeed;
        }
       
    }
}
