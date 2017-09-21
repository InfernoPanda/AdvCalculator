using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvMathLib
{
    public class Algebraic
    {
        public static string SquareRoot(double a)
        {
            return Math.Sqrt(a).ToString();
        }

        public static string CubeRoot(double a)
        {
            return Math.Pow(a, 1.0 / 3.0).ToString();
        }

        public static string Inverse(double a)
        {
            return Math.Pow(a, -1).ToString();
        }
    }
}
