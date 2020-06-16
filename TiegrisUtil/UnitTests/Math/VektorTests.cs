using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Media.Media3D;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiegrisUtil.Math;

namespace UnitTests.Math
{
    [TestClass]
    public class VektorTests
    {
        private void AssertVektorEquals(Vektor expected, Vektor actual) {
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
            Assert.AreEqual(expected.Z, actual.Z);
        }

        [TestMethod]
        public void CopyCtorTest() {
            Vektor v1 = new Vektor(1, 2, 3);
            Vektor v2 = new Vektor(v1);
            AssertVektorEquals(v1, v2);
            v1.X = 5;
            AssertVektorEquals(new Vektor(1, 2, 3), v2);
            AssertVektorEquals(new Vektor(5, 2, 3), v1);
        }

        [TestMethod]
        public void CrossProdTest() {
            Random ran = new Random(79776);

            for (int i = 0; i < 10; i++) {
                Vektor v1 = new Vektor(ran.Next(), ran.Next(), ran.Next());
                Vektor v2 = new Vektor(ran.Next(), ran.Next(), ran.Next());

                Vektor v3 = v1 ^ v2;

                Vector3D vector1 = new Vector3D(v1.X, v1.Y, v1.Z);
                Vector3D vector2 = new Vector3D(v2.X, v2.Y, v2.Z);
                Vector3D crossProduct = Vector3D.CrossProduct(vector1, vector2);

                AssertVektorEquals(new Vektor(crossProduct.X, crossProduct.Y, crossProduct.Z), v3);
            }
        }

        [TestMethod]
        public void ToStringTest() {
            Vektor v1 = new Vektor(1, 2, 3);
            Assert.AreEqual("(1; 2; 3)", v1.ToString());

            Vektor v2 = new Vektor(1.5, 2.250001, 3.0625);
            Assert.AreEqual("(1.5; 2.25; 3.0625)", v2.ToString());
        }
    }
}
