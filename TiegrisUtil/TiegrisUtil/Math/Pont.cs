using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.Math
{
    /// <summary>
    /// This struct represents a 2D vector, and provides the most common operations on them.
    /// </summary>
    public struct Pont
    {
        /// <summary>
        /// The first coordinate of the Point.
        /// </summary>
        public double X;
        /// <summary>
        /// The second coordinate of the Point.
        /// </summary>
        public double Y;

        /// <summary>
        /// Creates a new instance of the Pont struct with the specified coordinates.
        /// </summary>
        public Pont(double x, double y) {
            if (double.IsNaN(x) || double.IsNaN(y))
                throw new Exception("Vektor coordinate can not be NaN");

            if (double.IsInfinity(x) || double.IsInfinity(y))
                throw new Exception("Vektor coordinate can not be Infinity");

            X = x;
            Y = y;
        }

        /// <summary>
        /// Mirror the Pont on the Origin.
        /// </summary>
        /// <returns>-1 * v</returns>
        public static Pont operator -(Pont pont) {
            return new Pont(-pont.X, -pont.Y);
        }

        /// <summary>
        /// Substracts 2 Ponts.
        /// </summary>
        /// <returns>LHS - RHS</returns>
        public static Pont operator -(Pont pont1, Pont pont2) {
            return new Pont(pont1.X - pont2.X, pont1.Y - pont2.Y);
        }

        /// <summary>
        /// Adds 2 Ponts.
        /// </summary>
        /// <returns>LHS + RHS</returns>
        public static Pont operator +(Pont pont1, Pont pont2) {
            return new Pont(pont1.X + pont2.X, pont1.Y + pont2.Y);
        }

        /// <summary>
        /// Distance between 2 Ponts.
        /// </summary>
        /// <returns>(LHS - RHS).Length</returns>
        public static double Distance(Pont pont1, Pont pont2) {
            return (pont1 - pont2).Length;
        }

        /// <summary>
        /// Distance from the Origin.
        /// </summary>
        public double Length {
            get => System.Math.Sqrt(X * X + Y * Y);
        }

        private static void rotate(ref double x, ref double y, double beta) {
            double temp_x = x * System.Math.Cos(beta) - y * System.Math.Sin(beta);
            y = x * System.Math.Sin(beta) + y * System.Math.Cos(beta);
            x = temp_x;
        }

        /// <summary>
        /// Rotates this Pont on the X axis. It DOES modify the Pont.
        /// </summary>
        /// <param name="beta">Angle of rotation in radians.</param>
        /// <returns>this</returns>
        public Pont RotateThis(double beta) {
            rotate(ref X, ref Y, beta);
            return this;
        }

        /// <summary>
        /// Converts the Pont to a string in the format defined by FormatingInfo.OutNumberFormat.
        /// </summary>
        public override string ToString() {
            return ToString(FormatingInfo.NumberFormat);
        }

        /// <summary>
        /// Converts the Pont to a string in the specified format.
        /// </summary>
        public string ToString(NumberFormatInfo format) {
            return $@"({X.ToString(format)}; {Y.ToString(format)})";
        }
    }
}
