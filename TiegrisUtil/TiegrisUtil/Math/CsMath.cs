using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.Math
{
    /// <summary>
    /// Gyakran előforduló matematikai műveletek.
    /// </summary>
    static public class CsMath
    {
        /// <summary>
        /// Maradékos osztás maradéka, pozitív maradékkal negatív számok esetén is.
        /// </summary>
        /// <param name="a">Osztandó</param>
        /// <param name="m">Osztó</param>
        /// <returns>Maradék</returns>
        static public int Modulo(int a, int m) {
            a %= m;
            return a<0 ? a+m : a;
        }

        /// <summary>
        /// Converts a degree value to radians.
        /// </summary>
        /// <param name="degrees">Angle in degrees.</param>
        /// <returns>Angle in radians.</returns>
        static public double ToRadian(double degrees) {
            return degrees * System.Math.PI / 180.0;
        }

        /// <summary>
        /// Converts a radian value to degrees.
        /// </summary>
        /// <param name="radians">Angle in radians</param>
        /// <returns>Angle in degrees..</returns>
        static public double ToDegree(double radians) {
            return radians / System.Math.PI * 180.0;
        }
    }
}
