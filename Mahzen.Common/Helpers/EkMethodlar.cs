using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Common.Config
{
    public static class Yuzde
    {
        public static int YuzdeRandom(int[] Sans)
        {
            Random _Random = new Random();

            int toplamIhtimal = 0;
            for (int i = 0; i < Sans.Length; i++)
            {
                toplamIhtimal += Sans[i];
            }

            int cekilenTop = _Random.Next(1, toplamIhtimal + 1);

            int geciciToplam = 0;
            for (int i = 0; i < Sans.Length; i++)
            {
                geciciToplam += Sans[i];

                if (cekilenTop <= geciciToplam)
                {
                    return i;
                }
            }

            return -1; 
        }
    } 
}
