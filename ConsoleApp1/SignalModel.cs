using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum ByteOrder
    {
        Motorola,
        Intel
    }

    public struct Info
    {
        public int lsbBitIndex;
        public int msbBitIndex;
        public int lsbBitByte;
        public int msbBitByte;
        public BigInteger mask;
        public int spanStartIndex;
        public int spanSize;
        public bool EndPadding;
        public int paddingBits;
        public int shiftAmount;
        public int allocationSize;
        public int dataSizeAsByte;


    }


    public record class SignalModel
    {
        public int StartBit;
        public int Length;
        public ByteOrder Order;
        public Info SignalInfo { get; set; }
        public Func<ReadOnlyMemory<byte>, Info, BigInteger>? CalculateData = null;

        public int MsgDLC;


        public SignalModel(int startBit, int length, ByteOrder order, int msgDLC)
        {
            StartBit = startBit;
            Length = length;
            Order = order;
            MsgDLC = msgDLC;
            FillIndexes();

        }

        public BigInteger GetRawValueLittle(ReadOnlyMemory<byte> data)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Little");
            Console.WriteLine("--------");
            BigInteger value;
            int bitIndex = StartBit;
            int startByteIndex = bitIndex / 8;

            int zeroLSBs = bitIndex % 8;
            Console.WriteLine("lsb mask bit sayisi: " + zeroLSBs);
            BigInteger mask = (1 << Length) - 1;

            //mask = mask << zeroLSBs;
            Console.WriteLine("mask: 0x" + mask.ToString("X"));

            if (Length <= 8)
            {
                value = data.Span[startByteIndex] & mask;
            }
            else if (Length <= 16)
            {
                var val1 = BinaryPrimitives.ReadInt16LittleEndian(data.Slice(startByteIndex, 2).Span);
                Console.WriteLine("before mask: 0x" + val1.ToString("X") + "     " + val1);
                value = (val1 & mask) >> zeroLSBs;
                Console.WriteLine("after mask: 0x" + value.ToString("X") + "     " + value);
            }
            else if (Length <= 32)
            {
                value = BinaryPrimitives.ReadInt32BigEndian(data.Slice(startByteIndex, 4).Span) & mask;
            }
            else
            {
                //32 ve 64bit arasindaki sinyaller
                value = BinaryPrimitives.ReadInt64BigEndian(data.Slice(startByteIndex, 8).Span) & mask;
            }
            return value;

        }

        private void FillIndexes()
        {
            if (Order == ByteOrder.Motorola)
            {

                int _msbBitIndex = StartBit;
                int _msbBitByte = _msbBitIndex / 8;
                int _lsbBitIndex = Calculation.GetBigEndianLSB(_msbBitIndex, Length);
                int _lsbBitByte = _lsbBitIndex / 8;

                int diff = _lsbBitByte - _msbBitByte;
                int byteCount = diff + 1;
                int paddingBytes = 0;

                if (byteCount <= MsgDLC && (byteCount != 1 && byteCount != 2))
                {
                    CalculateData = diff switch
                    {
                        <= 3 => Calculation.GetRawValueBigAllocated32,
                        <= 7 => Calculation.GetRawValueBigAllocated64,
                        _ => null
                    };
                }
                else
                {

                    CalculateData = diff switch
                    {
                        0 => Calculation.GetRawValueBig8,
                        1 => Calculation.GetRawValueBig16,
                        <= 3 => Calculation.GetRawValueBig32,
                        <= 7 => Calculation.GetRawValueBig64,
                        _ => null
                    };
                }
                paddingBytes = diff switch
                {
                    0 => 0,
                    1 => 0,
                    <= 3 => Calculation.int32Size - byteCount,
                    <= 7 => Calculation.int64Size - byteCount,
                    _ => 0
                };


                (var mask, var shiftAmount) = Calculation.NewGetMask(_lsbBitIndex, Length, paddingBytes * 8);
                SignalInfo = new()
                {
                    msbBitIndex = _msbBitIndex,
                    msbBitByte = _msbBitByte,
                    lsbBitIndex = _lsbBitIndex,
                    lsbBitByte = _lsbBitByte,
                    mask = mask,
                    shiftAmount = shiftAmount,
                    paddingBits = paddingBytes * 8,
                    dataSizeAsByte = byteCount
                };




            }
            else
            {
                int _msbBitIndex = Calculation.GetLittleEndianMSB(StartBit, Length);
                int _msbBitByte = _msbBitIndex / 8;
                int _lsbBitIndex = StartBit;
                int _lsbBitByte = _lsbBitIndex / 8;


                int diff = _msbBitByte - _lsbBitByte;
                int byteCount = diff + 1;
                int paddingBytes = 0;

                if (byteCount <= MsgDLC && (byteCount != 1 && byteCount != 2))
                {
                    CalculateData = diff switch
                    {
                        <= 3 => Calculation.GetRawValueLittle32,
                        <= 7 => Calculation.GetRawValueLittle64,
                        _ => null
                    };
                }
                else
                {

                    CalculateData = diff switch
                    {
                        0 => Calculation.GetRawValueLittle8,
                        1 => Calculation.GetRawValueLittle16,
                        <= 3 => Calculation.GetRawValueLittle32,
                        <= 7 => Calculation.GetRawValueLittle64,
                        _ => null
                    };
                }
                paddingBytes = diff switch
                {
                    0 => 0,
                    1 => Calculation.int16Size - byteCount,
                    <= 3 => Calculation.int32Size - byteCount,
                    <= 7 => Calculation.int64Size - byteCount,
                    _ => 0
                };
                (var mask, var shiftAmount) = Calculation.NewGetMask(_lsbBitIndex, Length, paddingBytes * 8);
                SignalInfo = new()
                {
                    msbBitIndex = _msbBitIndex,
                    msbBitByte = _msbBitByte,
                    lsbBitIndex = _lsbBitIndex,
                    lsbBitByte = _lsbBitByte,
                    mask = mask,
                    shiftAmount = shiftAmount,
                    paddingBits = paddingBytes * 8,
                    dataSizeAsByte = byteCount
                };

            }
        }
    }

}
