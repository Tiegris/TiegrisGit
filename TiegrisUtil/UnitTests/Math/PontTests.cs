using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiegrisUtil.Math;

namespace UnitTests.Math
{
    [TestClass]
    public class PontTests
    {
        private void AssertPontEquals(Pont expected, Pont actual) {
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void TestMethod1() {
            //TODO: Implement Pont tests.
            Assert.Fail("Tests not implemented");
        }
    }
}
