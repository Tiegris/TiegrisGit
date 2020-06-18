using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiegrisUtil.CulturedFormating;
using TiegrisUtil.Frameworks;

namespace UnitTests.CulturedParsing
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void DateTests() {
            string date = "2020.06.18. 3:41:02";
            DateTime dt = Parser.ToDate(date);            
            Assert.AreEqual(date, Parser.ToString(dt));
        }

        [TestMethod]
        public void DoubleTests() {
            double a;
            a = Parser.ToDouble("19,5");
            Assert.AreEqual("19,5", Parser.ToString(a));

            a = Parser.ToDouble("19,50001");
            Assert.AreEqual("19,5", Parser.ToString(a));

            a = Parser.ToDouble("19,5259");
            Assert.AreEqual("19,5259", Parser.ToString(a));

            try {
                Parser.ToDouble("5.3");
                Assert.Fail();
            } catch (Exception e) {

            }
        }

        [TestMethod]
        public void FloatTests() {
            float a;
            a = Parser.ToFloat("19,5");
            Assert.AreEqual("19,5", Parser.ToString(a));

            a = Parser.ToFloat("19,50001");
            Assert.AreEqual("19,5", Parser.ToString(a));

            a = Parser.ToFloat("19,5259");
            Assert.AreEqual("19,5259", Parser.ToString(a));

            try {
                Parser.ToFloat("5.3");
                Assert.Fail();
            } catch (Exception e) {

            }
        }
    }
}
