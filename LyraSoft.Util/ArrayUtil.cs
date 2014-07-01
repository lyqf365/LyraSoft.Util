using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyraSoft.Util
{
    public class ArrayUtil
    {


        public static bool   ArrayEqule<T>(T[] lhs,T[] rhs)
        {
            if (object.ReferenceEquals(lhs, rhs))
                return true;
            if (object.ReferenceEquals(lhs, null) ||
                object.ReferenceEquals(rhs, null))
                return false;

            if (lhs.Length != rhs.Length)
                return false;

            for(int i = 0; i<lhs.Length; ++i)
            {
                if (!lhs[i].Equals(rhs[i]))
                    return false;
            }
            return true;
        }


        public static byte[] StringToBinary(string input)
        {
            if (input.Length % 2 != 0)
                throw new ArgumentException();

            byte[] data = new byte[(input.Length) / 2];

            for (int i = 0; i < data.Length; ++i)
            {
                data[i]= byte.Parse(input.Substring(2*i,2), System.Globalization.NumberStyles.HexNumber);
            }
            return data;
        }

        public static string BinaryToString(byte[] input)
        {
            StringBuilder _ret = new StringBuilder(input.Length * 2);

            foreach (var ch in input)
            {
                _ret.AppendFormat("{0:X2}", ch);
            }

            return _ret.ToString();
        }


    }
}
