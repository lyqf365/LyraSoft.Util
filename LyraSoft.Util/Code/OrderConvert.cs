using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyraSoft.Util.Code
{
    public static class OrderConvert
    {

        #region NetworkToHostOrder

        public static int NetworkToHostOrder(int arg)
        {
            return System.Net.IPAddress.NetworkToHostOrder(arg);
        }

        public static short NetworkToHostOrder(short arg)
        {
            return System.Net.IPAddress.NetworkToHostOrder(arg);
        }


        public static long NetworkToHostOrder(long arg)
        {
            return System.Net.IPAddress.NetworkToHostOrder(arg);
        }


        public static uint NetworkToHostOrder(uint arg)
        {
            unchecked
            {
                return (uint)System.Net.IPAddress.NetworkToHostOrder(arg);
            }
        }

        public static ushort NetworkToHostOrder(ushort arg)
        {
            unchecked
            {
                return (ushort)System.Net.IPAddress.NetworkToHostOrder(arg);
            }
        }


        public static ulong NetworkToHostOrder(ulong arg)
        {
            unchecked
            {
                return (ulong)System.Net.IPAddress.NetworkToHostOrder((long)arg);
            }
        }

        #endregion

        #region HostToNetworkOrder
        public static int HostToNetworkOrder(int arg)
        {
            return System.Net.IPAddress.HostToNetworkOrder(arg);
        }

        public static short HostToNetworkOrder(short arg)
        {
            return System.Net.IPAddress.HostToNetworkOrder(arg);
        }


        public static long HostToNetworkOrder(long arg)
        {
            return System.Net.IPAddress.HostToNetworkOrder(arg);
        }


        public static uint HostToNetworkOrder(uint arg)
        {
            unchecked
            {
                return (uint)System.Net.IPAddress.HostToNetworkOrder(arg);
            }
        }

        public static ushort HostToNetworkOrder(ushort arg)
        {
            unchecked
            {
                return (ushort)System.Net.IPAddress.HostToNetworkOrder(arg);
            }
        }


        public static ulong HostToNetworkOrder(ulong arg)
        {
            unchecked
            {
                return (ulong)System.Net.IPAddress.HostToNetworkOrder((long)arg);
            }
        }
        #endregion


    }
}
