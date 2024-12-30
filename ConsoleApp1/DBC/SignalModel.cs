using DBCParser.Attributes;
using DBCParser.Enums;
using DBCParser.Helpers;
using DBCParser.Parsers;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DBCParser.Models
{
    public class SignalModel
    {
        public string Name { get; internal set; }
        public string? Unit { get; internal set; }
        public int Length { get; internal set; }
        public ByteOrder ByteOrder { get; internal set; }
        public SignalType SignalType { get; internal set; }
        public double Factor { get; internal set; }
        public double Offset { get; internal set; }
        public double Minimum { get; internal set; }
        public double Maximum { get; internal set; }
        public int StartBit { get; internal set; }
        public string? Reciever { get; internal set; }
        public MessageModel ParentMessage { get; internal set; } = new();
        public double PhysicalValue { get; internal set; }
        public int RawValue { get; internal set; }
        public double SetValue { get; set; }
        public string Key { get; internal set; }

        public ISignalConverter BoundedSignal { get; internal set; }

        public double GetPhysicalValue(List<byte> message_data)
        {
            var value = (Factor * GetRawValue(message_data)) + Offset;
            PhysicalValue = value;
            if (BoundedSignal != null)
            {
                BoundedSignal.Value = value;
            }

            return value;
        }

        Stopwatch performance = new Stopwatch();

        public double GetPhysicalValue(List<byte> message_data, Dictionary<string, List<ObjectPropertyModel>> Dict)
        {
            //performance.Restart();
            //double value = 0;
            var value = (Factor * GetRawValue(message_data)) + Offset;
            PhysicalValue = value;
            //performance.Stop();
            //Debug.WriteLine(performance.Elapsed.TotalMilliseconds);
            if (BoundedSignal != null)
            {
                BoundedSignal.Value = value;
                return value;
            }


            if (Dict.TryGetValue(Key, out var objModels))
            {
                foreach (var obj in objModels)
                {

                    obj.Prop.SetValue(obj.Obj, value);

                }
            }

            return value;
        }

        public void GetPhysicalValue(List<byte> message_data, List<object> attHolder)
        {

            var value = (Factor * GetRawValue(message_data)) + Offset;
            PhysicalValue = value;
            foreach (var att in attHolder)
            {

                Type type = att.GetType();
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                if (properties.Length > 0)
                {
                    if (type.IsClass)
                    {
                        foreach (var property in properties)
                        {
                            var attribute = property.GetCustomAttribute<DBCSignalAttribute>();

                            if (attribute != null && attribute.Key == Key)
                            {
                                property.SetValue(att, value);
                            }
                        }
                    }
                }



            }

        }



        private int GetRawValue(List<byte> message_data)
        {
            int value = 0;
            int bitIndex = StartBit;
            int processedBitCounter = 0;
            int processedByteCounter = 0;
            int bitValue;
            int byteIndex;
            int bitInByteIndex;

            for (int i = 0; i < Length; i++)
            {
                byteIndex = bitIndex / 8;
                bitInByteIndex = bitIndex % 8;

                bitValue = GetBit(message_data[byteIndex], bitInByteIndex);
                if (ByteOrder == ByteOrder.Motorola)
                {
                    bitIndex--;
                    value = (value << 1) | bitValue;
                }
                else
                {
                    bitIndex++;
                    value = (value >> 1) | bitValue;
                }


                processedBitCounter++;
                if ((processedBitCounter & 7) == 0)
                {
                    processedByteCounter++;
                    bitIndex = StartBit + processedByteCounter * 8;
                }


            }
            if (SignalType == SignalType.Signed && (value & (1 << (Length - 1))) != 0)
            {
                // Negatif sayıya dönüştür
                unchecked
                {
                    value = value - (1 << Length);
                }

            }
            RawValue = value;
            return value;

        }


        private int GetBit(byte b, int index)
        {
            int mask = 1 << index;
            return (b & mask) >> index;
        }
        public bool HasMaximumEror(double val)
        {
            return val > Maximum;

        }
        public bool HasMinimumError(double val)
        {
            return val < Minimum;

        }

        public void PropertyBounder(ISignalConverter _boundedProperty)
        {
            BoundedSignal = _boundedProperty;
        }


        private BigInteger GetRawValue(ReadOnlyMemory<byte> data)
        {
            BigInteger value;
            int bitIndex = StartBit;
            int startByteIndex = bitIndex / 8;
            int stopByteIndex = (bitIndex + Length) / 8;
            int startMask = 0;
            int stopMask = 0;
            int zeroLSBs = bitIndex % 8;

            int fullMask = startMask + stopMask;
            BigInteger mask= (1 << Length) - 1;
            mask = mask << zeroLSBs;

            if (Length <= 8)
            {
                value = data.Span[startByteIndex] & mask;
            }
            else if (Length <= 16)
            {
                value = BinaryPrimitives.ReadInt16BigEndian(data.Slice(startByteIndex, 2).Span) & mask;
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

        private int lsbBitIndex;
        private int msbBitIndex;
        private int lsbBitByte;
        private int msbBitByte;
        private void FillIndexes()
        {
            if (ByteOrder == ByteOrder.Intel)
            {
                msbBitIndex = StartBit;
                msbBitByte = msbBitIndex / 8;
                lsbBitIndex=Calculation.GetBigEndianLSB(StartBit, Length);
                lsbBitByte = lsbBitIndex / 8;

            }
            else
            {
                msbBitIndex = Calculation.GetLittleEndianMSB(StartBit, Length);
                msbBitByte = msbBitIndex/8;
                lsbBitIndex = StartBit;
                lsbBitByte = lsbBitIndex / 8;
            }
        }


    }
}
