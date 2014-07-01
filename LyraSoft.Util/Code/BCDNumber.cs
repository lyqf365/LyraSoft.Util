using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyraSoft.Util.Code
{
     struct BCDNumber
    {
        #region  数据存储
        private bool _sign;
        private byte _digit0;
        private byte _digit1;
        private byte _digit2;
        private byte _digit3;
        private byte _digit4;
        private byte _digit5;
        private byte _digit6;
        private byte _digit7;
        private byte[] _extDigit;
        #endregion

        public  int DigitsCount { get; set; }

        #region 构造
        


        #endregion


        #region parse


        #endregion



        #region 类型转换运算符

        public static implicit operator double(BCDNumber num)
        {
            
            return 0;
        }
        public static implicit operator float(BCDNumber num)
        {
            return 0;
        }
        public static implicit operator sbyte(BCDNumber num)
        {
            return 0;
        }
        public static implicit operator byte(BCDNumber num)
        {
            return 0;
        }
        public static implicit operator short(BCDNumber num)
        {
            return 0;
        }
        public static implicit operator ushort(BCDNumber num)
        {
            return 0;
        }
        public static implicit operator int(BCDNumber num)
        {
            return 0;
        }
        public static implicit operator uint(BCDNumber num)
        {
            return 0;
        }
        public static implicit operator long(BCDNumber num)
        {
            return 0;
        }

        public static implicit operator ulong(BCDNumber num)
        {
            return 0;
        }

        public static implicit operator System.Numerics.BigInteger(BCDNumber num)
        {
            return 0;
        }

        #endregion

        #region 符号运算

        public static bool operator==(BCDNumber lhr,BCDNumber rhr)
        {

            return false;
        }


        public static bool operator !=(BCDNumber lhr, BCDNumber rhr)
        {
            return true;
        }
        #endregion

        #region 重载类方法
        public override bool Equals(object obj)
        {
            if(obj is BCDNumber)
            {
                BCDNumber num = (BCDNumber)obj;
                return this == num;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
