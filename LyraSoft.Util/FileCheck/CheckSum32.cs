using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace LyraSoft.Util.FileCheck
{


    /*****************************************************************************
     ***** CheckSum生成：
     * 将发送数据逐个累加，再对累加和取反，该值即为CheckSum校验码。
     * 取反的方式在C语言中可以使用按位取反“~”来实现，再Vb.net上可以吃用与0xFF异或(XOR)的方式得到。
     *****CheckSum校验：
     *将接收到的数据与校验码连续累加，将结果取反，若取反后的值为0，则表示校验正确，数据有效；
     *否则，校验错误，数据无效。
     ***** 举例:
     *如：带传送的数据串为：0x01，0x12，0x55，0xF0，则该校验码为以上累加，
     *累加值等于0x158，在一个字节中对256取模，结果为 0x58，所以校验码为0x58 ^ 0xFF =  0xA7 。
     *在接收端，如果数据接受正确，则 传送数据 + 校验值 = 0x58 + 0xA7 = 0xFF，
     *因此对该值取反的结果为0，因此校验正确。

     ******总结:
     *CheckSum校验算法相较于CRC校验算法，实现起来更简单，
     *但出现数据碰撞的概率更高，上面举例校验字节是单字节，
     *当校验字节越多，出现数据重叠的机会就越少，因为溢出的机会少。
     *但是因为原理上只是累加和，所以不像CRC那样，
     *是逐位判断，根据0/1做移位(异或)操作。
     *在数据波特率比较低，要求不是很严格的时候，可以选用校验和的方法。
     * 
    **********************************************************************************/
    ///////////////////////////////////////////////
    ////   未完成，请匆使用
    /////////////////////////////////////////////
    /// <summary>
    ///  未完成，请匆使用
    /// </summary>
    public class CheckSum
    {



        public static int CheckSum32(Stream input)
        {

            unchecked
            {
                const int bytesLen = 4;
                int sum = 0;
                long len = input.Length;
                var packs = (len + bytesLen -1) / bytesLen;
                byte[] buff = new byte[bytesLen];
                for (long i = 0; i < packs - 1; ++i)
                {
                    input.Read(buff, 0, bytesLen);
                    sum ^=  BitConverter.ToInt32(buff, 0);
                }
                buff = new byte[bytesLen];
                input.Read(buff, 0, bytesLen);
                sum ^=  BitConverter.ToInt32(buff, 0);
                return ~sum;
            }//unchecked
        }//func

    }//class
}
