using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.Math
{
    /// <summary>
    /// Represents a 3D vector, and provides the most common operations on them.
    /// </summary>
    public class Vektor
    {
        private double x, y, z;
        private static readonly Random ran = new Random();        

        /// <summary>
        /// First coordinate of the Vektor.
        /// </summary>
        public double X {
            get => x;
            set => x = value;
        }

        /// <summary>
        /// Second coordinate of the Vektor.
        /// </summary>
        public double Y {
            get => y;
            set => y = value;
        }

        /// <summary>
        /// Third coordinate of the Vektor.
        /// </summary>
        public double Z {
            get => z;
            set => z = value;
        }


        /// <summary>
        /// Creates a new instance of the Vektor class with the specified coordinates.
        /// </summary>
        public Vektor(double x, double y, double z) {
            if (double.IsNaN(x) || double.IsNaN(y) || double.IsNaN(z))
                throw new Exception("Vektor coordinate can not be NaN");

            if (double.IsInfinity(x) || double.IsInfinity(y) || double.IsInfinity(z))
                throw new Exception("Vektor coordinate can not be Infinity");

            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Creates a new instance of the Vektor class with the (0, 0, 0) coordinates.
        /// </summary>
        public Vektor() : this(0.0, 0.0, 0.0) { }

        /// <summary>
        /// Creates a new instance of the Vektor class by cloning the given Vektor.
        /// </summary>
        public Vektor(Vektor v) : this(v.x, v.y, v.z) { }

        /// <summary>
        /// Negate the Vektor.
        /// </summary>
        /// <returns>-1 * v</returns>
        public static Vektor operator -(Vektor v1) {
            return new Vektor(-v1.x, -v1.y, -v1.z);
        }

        /// <summary>
        /// Substracts 2 Vektors.
        /// </summary>
        /// <returns>LHS - RHS</returns>
        public static Vektor operator -(Vektor v1, Vektor v2) {
            return new Vektor(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        /// <summary>
        /// Adds 2 Vektors.
        /// </summary>
        /// <returns>LHS + RHS</returns>
        public static Vektor operator +(Vektor v1, Vektor v2) {
            return new Vektor(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        /// Length of the Vektor.
        /// </summary>
        public double Length {
            get { return System.Math.Sqrt(x * x + y * y + z * z); }
        }

        /// <summary>
        /// Vektor pointing from the RHS to the LHS.
        /// </summary>
        /// <returns>LHS - RHS</returns>
        public static Vektor operator <(Vektor v1, Vektor v2) {
            return v1 - v2;
        }

        /// <summary>
        /// Vektor pointing from the LHS to the RHS.
        /// </summary>
        /// <returns>RHS - LHS</returns>
        public static Vektor operator >(Vektor v1, Vektor v2) {
            return v2 - v1;
        }

        /// <summary>
        /// Multiply Vektor with scalar.
        /// </summary>
        public static Vektor operator *(Vektor v, double c) {
            return new Vektor(v.x * c, v.y * c, v.z * c);
        }

        /// <summary>
        /// Multiply Vektor with scalar.
        /// </summary>
        public static Vektor operator *(double c, Vektor v) {
            return new Vektor(v.x * c, v.y * c, v.z * c);
        }

        /// <summary>
        /// Dot product of 2 Vektors.
        /// </summary>
        /// <returns>LHS * RHS^T</returns>
        public static double operator *(Vektor v1, Vektor v2) {
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        /// <summary>
        /// Distance between the ends of 2 Vektors.
        /// </summary>
        /// <returns>(LHS - RHS).Length</returns>
        public static double Distance(Vektor v1, Vektor v2) {
            return (v1 - v2).Length;
        }

        /// <summary>
        /// Cross product of 2 Vektors.
        /// </summary>
        /// <returns>LHS x RHS</returns>
        public static Vektor CrossProduct(Vektor v1, Vektor v2) => v1 ^ v2;

        /// <summary>
        /// Cross product of 2 Vektors.
        /// </summary>
        /// <returns>LHS x RHS</returns>
        public static Vektor operator ^(Vektor v1, Vektor v2) {
            return new Vektor(
                v1.y * v2.z - v1.z * v2.y,
                -v1.x * v2.z + v1.z * v2.x,
                v1.x * v2.y - v1.y * v2.x
                );
        }


        private static void rotate(ref double x, ref double y, double beta) {
            double temp_x = x * System.Math.Cos(beta) - y * System.Math.Sin(beta);
            y = x * System.Math.Sin(beta) + y * System.Math.Cos(beta);
            x = temp_x;
        }

        /// <summary>
        /// Rotates this Vektor on the X axis. It DOES modify the Vektor.
        /// </summary>
        /// <param name="beta">Angle of rotation in radians.</param>
        /// <returns>this</returns>
        public Vektor RotateThisOnX(double beta) {
            rotate(ref y, ref z, beta);
            return this;
        }

        /// <summary>
        /// Rotates this Vektor on the Y axis. It DOES modify the Vektor.
        /// </summary>
        /// <param name="beta">Angle of rotation in radians.</param>
        /// /// <returns>this</returns>
        public Vektor RotateThisOnY(double beta) {
            rotate(ref x, ref z, beta);
            return this;
        }

        /// <summary>
        /// Rotates this Vektor on the Z axis. It DOES modify the Vektor.
        /// </summary>
        /// <param name="beta">Angle of rotation in radians.</param>
        /// /// <returns>this</returns>
        public Vektor RotateThisOnZ(double beta) {
            rotate(ref x, ref y, beta);
            return this;
        }

        /// <summary>
        /// Rotates the given Vektor on the X axis. Does NOT modify the given Vektor.
        /// </summary>
        /// <param name="v">Vektor</param>
        /// <param name="beta">Angle of rotation in radians.</param>
        /// <returns>Rotated new Vektor.</returns>
        public static Vektor RotateOnX(Vektor v, double beta) {
            Vektor tmp = new Vektor(v);
            rotate(ref tmp.y, ref tmp.z, beta);
            return tmp;
        }

        /// <summary>
        /// Rotates the given Vektor on the Y axis. Does NOT modify the given Vektor.
        /// </summary>
        /// <param name="v">Vektor</param>
        /// <param name="beta">Angle of rotation in radians.</param>
        /// <returns>Rotated new Vektor.</returns>
        public static Vektor RotateOnY(Vektor v, double beta) {
            Vektor tmp = new Vektor(v);
            rotate(ref tmp.x, ref tmp.z, beta);
            return tmp;
        }

        /// <summary>
        /// Rotates the given Vektor on the Z axis. Does NOT modify the given Vektor.
        /// </summary>
        /// <param name="v">Vektor</param>
        /// <param name="beta">Angle of rotation in radians.</param>
        /// <returns>Rotated new Vektor.</returns>
        public static Vektor RotateOnZ(Vektor v, double beta) {
            Vektor tmp = new Vektor(v);
            rotate(ref tmp.x, ref tmp.y, beta);
            return tmp;
        }

        /// <summary>
        /// Rounds the coordinates of this Vektor. It DOES modify the Vektor.
        /// </summary>
        /// <param name="decimals">The number of decimal places in the new value.</param>
        /// <returns>this</returns>
        public Vektor RoundThis(int decimals = 12) {
            this.x = System.Math.Round(this.x, decimals);
            this.y = System.Math.Round(this.y, decimals);
            this.z = System.Math.Round(this.z, decimals);
            return this;
        }

        /// <summary>
        /// Rounds the coordinates of the given Vektor. It does NOT modify the Vektor.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns>Rounded new Vektor.</returns>
        public static Vektor Round(Vektor v, int decimals = 12) {
            Vektor tmp = new Vektor(v);
            return tmp.RoundThis(decimals);
        }

        /// <summary>
        /// Converts the Vektor to a string in the format defined by FormatingInfo.OutNumberFormat.
        /// </summary>
        public override string ToString() {
            return ToString(FormatingInfo.OutNumberFormat);
        }

        /// <summary>
        /// Converts the Vektor to a string in the specified format.
        /// </summary>
        public string ToString(NumberFormatInfo format) {
            return $@"({x.ToString(format)}; {
                y.ToString(format)}; {z.ToString(format)})";
        }

        /// <summary>
        /// Calls ToString() when casted to string.
        /// </summary>
        /// <param name="v">The Vektor to be casted.</param>
        public static explicit operator string(Vektor v) {
            return v.ToString();
        }

        /// <summary>
        /// Random Vektor with a specified length.
        /// </summary>
        /// <param name="length">Length of the random Vektor.</param>
        public static Vektor Random(double length = 1.0) {
            Vektor v = new Vektor(length, 0, 0);

            v.RotateThisOnX(ran.NextDouble() * 2 * System.Math.PI);
            v.RotateThisOnY(ran.NextDouble() * 2 * System.Math.PI);
            v.RotateThisOnZ(ran.NextDouble() * 2 * System.Math.PI);

            return v;
        }
    }
}
