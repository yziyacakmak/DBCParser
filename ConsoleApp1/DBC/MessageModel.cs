using DBCParser.Attributes;
using DBCParser.Enums;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace DBCParser.Models
{
    public class MessageModel : IMessage
    {

        public uint CanId { get; set; }
        public string CanIdHex { get; set; }
        public string Name { get; set; }
        public MessageType Type { get; set; }
        public int CycleTime { get; set; }
        public int Length { get; set; }
        public string? Sender { get; set; }
        public string? Comment { get; set; }
        public List<SignalModel> Signals { get; set; } = new();
        public Dictionary<string, SignalModel> SignalDictionary { get; set; } = new();

        public void CalculateValues(List<byte> msg_data)
        {
            foreach (var signal in Signals)
            {
                signal.GetPhysicalValue(msg_data);
            }
        }
        public void CalculateValues(List<byte> msg_data, List<object> attHolder)
        {
            foreach (var signal in Signals)
            {
                signal.GetPhysicalValue(msg_data, attHolder);
            }
        }

        public void CalculateValues(List<byte> message_data, Dictionary<string, List<ObjectPropertyModel>> Dict)
        {
            foreach (var signal in Signals)
            {
                signal.GetPhysicalValue(message_data, Dict);
            }
        }

        public List<byte> FrameGenarator()
        {
            int byteCount = Length;
            byte[] frame = new byte[byteCount];

            int bitIndex;
            int byteIndex;
            int byteCounter = 0;
            uint rawValue;
            int signalShift;
            foreach (var signal in Signals)
            {

                var signalByteLength = signal.Length / 8 == 0 ? 1 : signal.Length / 8;
                signalShift = (signal.StartBit % 8) - (signal.Length - 1);
                byteCounter = 0;
                bitIndex = signal.StartBit;
                byteIndex = bitIndex / 8;
                rawValue = (uint)((signal.SetValue + signal.Offset) / signal.Factor);
                if (signal.ByteOrder == ByteOrder.Motorola)
                {
                    byte[] values = GetValue(rawValue);
                    foreach (var value in values)
                    {
                        if (byteCounter <= signalByteLength)
                        {
                            if (signalShift > 0) { frame[byteIndex] |= (byte)(value << signalShift); }
                            else
                            { frame[byteIndex] |= value; }

                            byteIndex++;
                            byteCounter++;
                        }

                    }
                }
            }


            return frame.ToList();

        }


        public byte[] GenerateFrame()
        {
            var dataPgc64 = BigInteger.Zero;
            var totalSize = 0;
            foreach (var sgn in Signals)
            {
                totalSize += sgn.Length;

                dataPgc64 |= sgn.ByteOrder switch
                {
                    ByteOrder.Intel => LittleEndianFrameGenerator(sgn, dataPgc64),
                    ByteOrder.Motorola => BigEndianFrameGenerator(sgn, dataPgc64)
                };
            }
            var totalBytes = (int)Math.Ceiling(totalSize / 8.0);
            byte[] bytes = dataPgc64.ToByteArray();
            if(bytes.Length!= totalBytes)
            {
                Array.Resize(ref bytes, totalBytes);
            }

            return bytes;
        }

        private BigInteger BigEndianFrameGenerator(SignalModel sgn, BigInteger dataPgc64)
        {
            
            var lengthMask = (BigInteger.One << sgn.Length) - 1;//ayni kalicak
            var propertyValue = (sgn.SetValue+sgn.Offset)/sgn.Factor;
            BigInteger intValue = new(propertyValue);
            return dataPgc64 |= (intValue & lengthMask);

        }

        private BigInteger LittleEndianFrameGenerator(SignalModel sgn,BigInteger dataPgc64)
        {
            var lengthMask = (BigInteger.One << sgn.Length) - 1;
            var propertyValue = (sgn.SetValue + sgn.Offset) / sgn.Factor;
            BigInteger intValue = new BigInteger(Convert.ToInt64(propertyValue));
            return dataPgc64 |= (intValue & lengthMask) << sgn.StartBit;
        }

        private void FloatFrameGenerator()
        {

        }

        private void DoubleFrameGenerator()
        {

        }


        private byte[] GetValue(uint rawValue)
        {
            byte[] byteValues = new byte[4];
            uint bitValue = 0;
            byte value = 0;
            int byteIndex = 0;

            int bitCounter = 0;
            int zeroCounter = 0;
            for (int i = 31; i >= 0; i--)
            {
                bitValue = GetBit(rawValue, i);
                value = (byte)((value << 1) | bitValue);
                byteValues[byteIndex] = value;
                bitCounter++;
                if ((bitCounter & 7) == 0)
                {
                    if (value != 0)
                    {
                        byteIndex++;
                        value = 0;
                    }
                    else
                    {
                        zeroCounter++;
                    }
                }
            }

            return byteValues.Take(4 - zeroCounter).ToArray();
        }

        private int GetBit(int b, int index)
        {
            int mask = 1 << index;
            return (b & mask) >> index;
        }
        private uint GetBit(uint b, int index)
        {
            int mask = 1 << index;
            return (uint)(b & mask) >> index;
        }




    }
}
