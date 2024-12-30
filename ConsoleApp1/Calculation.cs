using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class Calculation
    {

        public static int int32Size = sizeof(Int32);
        public static int int64Size = sizeof(Int64);
        public static int int16Size = sizeof(Int16);
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
            return startBit + length;//-1 vardi
        }
        public static BigInteger GetRawValueLittle8(ReadOnlyMemory<byte> data, Info info)
        {
            return data.Span[info.lsbBitByte] & info.mask;
        }
        public static BigInteger GetRawValueLittle16(ReadOnlyMemory<byte> data, Info info)
        {
            return (BinaryPrimitives.ReadInt16LittleEndian(data.Slice(info.lsbBitByte, int16Size).Span) & info.mask) >> info.shiftAmount;

        }
        public static BigInteger GetRawValueLittle32(ReadOnlyMemory<byte> data, Info info)
        {
            return (BinaryPrimitives.ReadInt32LittleEndian(data.Slice(info.lsbBitByte, int32Size).Span) & info.mask) >> info.shiftAmount;
        }
        public static BigInteger GetRawValueLittle64(ReadOnlyMemory<byte> data, Info info)
        {
            return (BinaryPrimitives.ReadInt64LittleEndian(data.Slice(info.lsbBitByte, int64Size).Span) & info.mask) >> info.shiftAmount;
        }
        public static BigInteger GetRawValueBig8(ReadOnlyMemory<byte> data, Info info)
        {
            return data.Span[info.msbBitByte] & info.mask;
        }
        public static BigInteger GetRawValueBig16(ReadOnlyMemory<byte> data, Info info)
        {
            return (BinaryPrimitives.ReadInt16BigEndian(data.Slice(info.msbBitByte, 2).Span) & info.mask) >> info.shiftAmount;
        }
        public static BigInteger GetRawValueBig32(ReadOnlyMemory<byte> data, Info info)
        {
            return (BinaryPrimitives.ReadInt32BigEndian(data.Slice(info.msbBitByte, 4).Span) & info.mask) >> info.shiftAmount;
        }
        public static BigInteger GetRawValueBig64(ReadOnlyMemory<byte> data, Info info)
        {
            return (BinaryPrimitives.ReadInt64BigEndian(data.Slice(info.msbBitByte, 8).Span) & info.mask) >> info.shiftAmount;
        }
        public static BigInteger GetRawValueBigAllocated8(ReadOnlyMemory<byte> data, Info info)
        {
            return data.Span[info.msbBitByte] & info.mask;
        }
        public static BigInteger GetRawValueBigAllocated16(ReadOnlyMemory<byte> data, Info info)
        {
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;
            byte[] rentedArray = pool.Rent(int16Size);

            ReadOnlyMemory<byte> residualBytes = data.Slice(info.msbBitByte, info.dataSizeAsByte);
            residualBytes.CopyTo(rentedArray);
            BigInteger value = (BinaryPrimitives.ReadInt32BigEndian(rentedArray.AsSpan(0, 2)) & info.mask) >> info.shiftAmount;
            pool.Return(rentedArray);
            return value;
        }
        public static BigInteger GetRawValueBigAllocated32(ReadOnlyMemory<byte> data, Info info)
        {
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;
            byte[] rentedArray = pool.Rent(int32Size);

            ReadOnlyMemory<byte> residualBytes = data.Slice(info.msbBitByte, info.dataSizeAsByte);
            residualBytes.CopyTo(rentedArray);
            BigInteger value = (BinaryPrimitives.ReadInt32BigEndian(rentedArray.AsSpan(0, 4)) & info.mask) >> info.shiftAmount;
            pool.Return(rentedArray);
            return value;
        }
        public static BigInteger GetRawValueBigAllocated64(ReadOnlyMemory<byte> data, Info info)
        {
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;
            byte[] rentedArray = pool.Rent(int64Size);

            ReadOnlyMemory<byte> residualBytes = data.Slice(info.msbBitByte, info.dataSizeAsByte);
            residualBytes.CopyTo(rentedArray.AsMemory(0, info.dataSizeAsByte));
            BigInteger value = (BinaryPrimitives.ReadInt64BigEndian(rentedArray.AsSpan(0, 8)) & info.mask) >> info.shiftAmount; ;
            pool.Return(rentedArray);
            return value;
        }
        public static BigInteger GetRawValueLittleAllocated8(ReadOnlyMemory<byte> data, Info info)
        {
            return data.Span[info.msbBitByte] & info.mask;
        }
        public static BigInteger GetRawValueLittleAllocated16(ReadOnlyMemory<byte> data, Info info)
        {
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;
            byte[] rentedArray = pool.Rent(int16Size);

            ReadOnlyMemory<byte> residualBytes = data.Slice(info.lsbBitByte, info.dataSizeAsByte);
            residualBytes.CopyTo(rentedArray);
            BigInteger value = (BinaryPrimitives.ReadInt16LittleEndian(rentedArray.AsSpan(0, int16Size)) & info.mask) >> info.shiftAmount;


            pool.Return(rentedArray);
            return value;
        }
        public static BigInteger GetRawValueLittleAllocated32(ReadOnlyMemory<byte> data, Info info)
        {
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;
            byte[] rentedArray = pool.Rent(int32Size);

            ReadOnlyMemory<byte> residualBytes = data.Slice(info.lsbBitByte, info.dataSizeAsByte);
            residualBytes.CopyTo(rentedArray);
            BigInteger value = (BinaryPrimitives.ReadInt16LittleEndian(rentedArray.AsSpan(0, int32Size)) & info.mask) >> info.shiftAmount;


            pool.Return(rentedArray);
            return value;
        }
        public static BigInteger GetRawValueLittleAllocated64(ReadOnlyMemory<byte> data, Info info)
        {
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;
            byte[] rentedArray = pool.Rent(int64Size);

            ReadOnlyMemory<byte> residualBytes = data.Slice(info.lsbBitByte, info.dataSizeAsByte);
            residualBytes.CopyTo(rentedArray);
            BigInteger value = (BinaryPrimitives.ReadInt16LittleEndian(rentedArray.AsSpan(0, int64Size)) & info.mask) >> info.shiftAmount;


            pool.Return(rentedArray);
            return value;
        }

        public static BigInteger GetMask(int lsbBitIndex, int length)
        {
            int zeroLSBs = lsbBitIndex % 8;
            BigInteger mask = (1 << length) - 1;
            mask = mask << zeroLSBs;
            return mask;
        }

        public static Tuple<BigInteger, int> NewGetMask(int lsbBitIndex, int length, int paddingBits)
        {
            int zeroLSBs = lsbBitIndex % 8 + paddingBits;//lsbBitIndex % 8;
            BigInteger mask = (BigInteger.One << length) - 1;
            mask = mask << zeroLSBs;
            return new Tuple<BigInteger, int>(mask, zeroLSBs);
        }
    }
}
