using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvMathLib
{
    public class Trigonometric
    {
        public static string Tan(double a)
        {
            if (a == 90)
            {
                return "undefined";
            }
            return Math.Tan(RadianToDegree(a)).ToString();
        }

        public static string Sin(double a)
        {
            return Math.Sin(RadianToDegree(a)).ToString();
        }

        public static string Cos(double a)
        {
            return Math.Cos(RadianToDegree(a)).ToString();
        }

        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
    }
}
