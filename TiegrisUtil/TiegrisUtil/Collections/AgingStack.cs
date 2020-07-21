using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.Collections
{
    /// <summary>
    /// Generic stack with a maximum size. If a Push request exceeds the item limit, it overwrites old elements.
    /// </summary>
    /// <typeparam name="T">Type of elemtes in the stack.</typeparam>
    public class AgingStack<T>
    {
        private T[] elements;
        private int top, count;

        /// <summary>
        /// Creates a new instance if AgingStack with a given length.
        /// </summary>
        /// <param name="size">Maximum size of the stack.</param>
        public AgingStack(int size) {
            elements = new T[size];
            top = 0;
            count = 0;
        }

        #region private helper functions
        private void incr(ref int a) {
            a = (a + 1) % elements.Length;
        }

        private void decr(ref int a) {
            a = (a - 1);
            if (a < 0)
                a += elements.Length;
        }
        #endregion

        /// <summary>
        /// Pushes a new element to top of the stack.
        /// </summary>
        /// <param name="item">New element.</param>
        public void Push(T item) { 
            elements[top] = item;
            incr(ref top);
            if (count < elements.Length)
                count++;
        }

        /// <summary>
        /// Returnes, than removes the youngest element of the stack.
        /// </summary>
        public T Pop() {
            if (!HasAny)
                throw new IndexOutOfRangeException("The AgingStack is empty.");
            count--;
            decr(ref top);
            return elements[top];
        }

        /// <summary>
        /// Returnes the youngest element of the stack.
        /// </summary>
        public T Peek() {
            if (!HasAny)
                throw new IndexOutOfRangeException("The AgingStack is empty.");
            int tmp = top;
            decr(ref tmp);
            return elements[tmp];
        }

        /// <summary>
        /// Clears the stack, and releases all object references.
        /// </summary>
        public void Clear() {
            count = 0;
            int size = elements.Length;
            elements = new T[size];
        }

        /// <summary>
        /// False, if the stack is empty.
        /// </summary>
        public bool HasAny => (count > 0);

        /// <summary>
        /// Gets the number of elements stored in the stack.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Gets the total size of the stack.
        /// </summary>
        public int Size => elements.Length;
    }
}
