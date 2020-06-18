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
    }
}
