using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCParser.Parsers
{
    public static class ValueConverters
    {
        public static uint GetUIntBigEndian(byte[] data,int startIndex)
        {
            byte[] array = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                array[i] = data[startIndex + i];
            }

            Array.Reverse(array);
            return BitConverter.ToUInt32(array, 0);
        }

        public static uint GetUIntLittleEndian()
        {
            return 12;
        }

    }
}
