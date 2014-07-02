using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyraSoft.Util.Code
{
     public struct BCDNumber
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
            throw new  NotImplementedException();
        }
        public static implicit operator float(BCDNumber num)
        {
            throw new NotImplementedException();
        }
        public static implicit operator sbyte(BCDNumber num)
        {
            throw new NotImplementedException();
        }
        public static implicit operator byte(BCDNumber num)
        {
            throw new NotImplementedException();
        }
        public static implicit operator short(BCDNumber num)
        {
            throw new NotImplementedException();
        }
        public static implicit operator ushort(BCDNumber num)
        {
            throw new NotImplementedException();
        }
        public static implicit operator int(BCDNumber num)
        {
            throw new NotImplementedException();
        }
        public static implicit operator uint(BCDNumber num)
        {
            throw new NotImplementedException();
        }
        public static implicit operator long(BCDNumber num)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ulong(BCDNumber num)
        {
            throw new NotImplementedException();
        }

        public static implicit operator System.Numerics.BigInteger(BCDNumber num)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 符号运算

        public static bool operator==(BCDNumber lhr,BCDNumber rhr)
        {

            throw new NotImplementedException();
        }


        public static bool operator !=(BCDNumber lhr, BCDNumber rhr)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        #endregion

       
    }
}
