using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiegrisUtil.Math;

namespace UnitTests.Math
{
    [TestClass]
    public class CsMathTests
    {
        [TestMethod]
        public void Modulo() {
            Assert.AreEqual(3, CsMath.Modulo(10, 7));
            Assert.AreEqual(4, CsMath.Modulo(-10, 7));
            Assert.AreEqual(0, CsMath.Modulo(0, 2));
            Assert.AreEqual(1, CsMath.Modulo(-1, 2));

            Assert.AreEqual(1, CsMath.Modulo(51, 2));
            Assert.AreEqual(1, CsMath.Modulo(-51, 2));
        }
    }
}
