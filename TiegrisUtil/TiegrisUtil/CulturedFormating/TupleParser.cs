using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiegrisUtil.CulturedFormating
{
    #region Splitters
    public interface ISplitter
    {
        string[] Split(string s);
    }

    public class CharSplitter : ISplitter
    {
        private char sep;

        public CharSplitter(char separator) {
            sep = separator;
        }

        public string[] Split(string s) => s.Split(sep);
    }

    public class StringSplitter : ISplitter
    {
        private string sep;

        public StringSplitter(string separator) {
            sep = separator;
        }

        public string[] Split(string s) => s.Split(new string[1] { sep }, StringSplitOptions.None);
    }
    #endregion

    public class TupleParser
    {
        ISplitter splitter;

        public TupleParser(char separator) {
            splitter = new CharSplitter(separator);
        }

        public TupleParser(string separator) {
            splitter = new StringSplitter(separator);
        }

        public TupleParser(ISplitter splitter) {
            this.splitter = splitter;
        }

        public float[] ToFloat(string s) {
            string[] arr = splitter.Split(s);
            int length = arr.Length;
            float[] retArr = new float[length];
            for (int i = 0; i < length; i++) 
                retArr[i] = Parser.ToFloat(arr[i]);           

            return retArr;
        }

        public double[] ToDouble(string s) {
            string[] arr = splitter.Split(s);
            int length = arr.Length;
            double[] retArr = new double[length];
            for (int i = 0; i < length; i++)
                retArr[i] = Parser.ToDouble(arr[i]);

            return retArr;
        }

        public int[] ToInt(string s) {
            string[] arr = splitter.Split(s);
            int length = arr.Length;
            int[] retArr = new int[length];
            for (int i = 0; i < length; i++)
                retArr[i] = Parser.ToInt(arr[i]);

            return retArr;
        }
    }
}
