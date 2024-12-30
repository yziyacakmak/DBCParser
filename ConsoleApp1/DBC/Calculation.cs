using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DBCParser.Helpers
{
    internal static class Calculation
    {
        internal static int GetBigEndianLSB(int startBit, int length)
        {
            int bitIndex = startBit;
            for (int i = 0; i < length - 1; i++)
            {
                if ((bitIndex & 7) == 0)
                    bitIndex = bitIndex + 15;
                else
                {
                    --bitIndex;
                }

            }
            return bitIndex;
        }
        internal static int GetLittleEndianMSB(int startBit, int length)
        {
            return startBit + length - 1;
        }

        public static BigInteger GetRawValueLittle8(ReadOnlyMemory<byte> data,Info info)
        {
            return data.Span[info.lsbBitByte] & info.mask;

        }

        public static BigInteger GetRawValueLittle16(ReadOnlyMemory<byte> data, Info info)
        {
            return BinaryPrimitives.ReadInt16LittleEndian(data.Slice(info.lsbBitByte, 2).Span) & info.mask;
        }
        public static BigInteger GetRawValueLittle32(ReadOnlyMemory<byte> data, Info info)
        {
            return BinaryPrimitives.ReadInt32BigEndian(data.Slice(info.lsbBitByte, 4).Span) & info.mask;
        }
        public static BigInteger GetRawValueLittle64(ReadOnlyMemory<byte> data, Info info)
        {
            return BinaryPrimitives.ReadInt64BigEndian(data.Slice(info.lsbBitByte, 8).Span) & info.mask;
        }




        private static BigInteger GetMask(int lsbBitIndex,int length)
        {
            int zeroLSBs = lsbBitIndex % 8;
            BigInteger mask = ((uint)1 << length) - (uint)1;
            mask = mask << zeroLSBs;
            return mask;
        }


    }
}
