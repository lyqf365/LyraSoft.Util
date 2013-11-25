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

    }
}
