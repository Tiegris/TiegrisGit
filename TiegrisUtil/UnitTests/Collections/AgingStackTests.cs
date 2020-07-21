using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiegrisUtil.Collections;

namespace UnitTests.Collections
{
    [TestClass]
    public class AgingStackTests
    {
        private void assertEmpty(AgingStack<int> stack) {
            try {
                stack.Pop();
                Assert.Fail();
            } catch (Exception e) {

            }
        }

        [TestMethod]
        public void TestMethod_NoOverflow() {
            AgingStack<int> agingStack = new AgingStack<int>(4);
            agingStack.Push(1);
            agingStack.Push(2);
            agingStack.Push(3);
            agingStack.Push(4);

            Assert.AreEqual(4, agingStack.Pop());
            Assert.AreEqual(3, agingStack.Pop());
            Assert.AreEqual(2, agingStack.Pop());
            Assert.AreEqual(1, agingStack.Pop());
        }

        [TestMethod]
        public void TestMethod_WithOverflow() {
            AgingStack<int> agingStack = new AgingStack<int>(3);
            agingStack.Push(1);
            agingStack.Push(2);
            agingStack.Push(3);
            agingStack.Push(4);

            Assert.AreEqual(4, agingStack.Pop());
            Assert.AreEqual(3, agingStack.Pop());
            Assert.AreEqual(2, agingStack.Pop());
            assertEmpty(agingStack);
        }

        [TestMethod]
        public void TestMethod_DoubleOverflow() {
            AgingStack<int> agingStack = new AgingStack<int>(2);
            agingStack.Push(1);
            agingStack.Push(2);
            agingStack.Push(3);
            agingStack.Push(4);
            agingStack.Push(5);
            agingStack.Push(6);
            agingStack.Push(7);
            agingStack.Push(8);

            Assert.AreEqual(8, agingStack.Pop());
            Assert.AreEqual(7, agingStack.Pop());
            assertEmpty(agingStack);
        }

        [TestMethod]
        public void TestMethod_Emtpy() {
            AgingStack<int> agingStack = new AgingStack<int>(2);
            assertEmpty(agingStack);
            agingStack.Push(1);
            agingStack.Push(2);

            Assert.AreEqual(2, agingStack.Pop());
            Assert.AreEqual(1, agingStack.Pop());

            assertEmpty(agingStack);
        }

        [TestMethod]
        public void TestMethod_Peek() {
            AgingStack<int> agingStack = new AgingStack<int>(2);
            agingStack.Push(1);
            agingStack.Push(2);

            Assert.AreEqual(2, agingStack.Peek());
            Assert.AreEqual(2, agingStack.Peek());
            Assert.AreEqual(2, agingStack.Pop());
            Assert.AreEqual(1, agingStack.Pop());

            assertEmpty(agingStack);
        }
    }
}
