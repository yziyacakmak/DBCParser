using System;
using System.Buffers.Binary;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;

namespace ConsoleApp1;

public static class ProtocolFactory
{
    public static unsafe byte[] Create(List<Tuple<int, int, int>> fields)
    {
        //tuple eleman 1 degisken degeri
        //tuple eleman 2 eleman boyutu
        //tuple eleman 3 start index
        UInt64 dataPgc64 = 0;
        var totalSize = 0;
        foreach (var field in fields)
        {
            totalSize += field.Item2;
            var lengthMask = (1UL << field.Item2) - 1;
            dataPgc64 |= ((UInt64)field.Item1 & lengthMask) << field.Item3;
        }

        var totalBytes = (int)Math.Ceiling(totalSize / 8.0) * 8;
        Span<byte> bytes = stackalloc byte[8];
        BinaryPrimitives.WriteUInt64LittleEndian(bytes, dataPgc64);
        Console.WriteLine(dataPgc64.ToString("x"));

        return bytes.Slice(0, (totalBytes / 8)).ToArray();
    }


    public static byte[] Create(IProtoMessage messageProtocol)
    {
        var dataPgc64 = BigInteger.Zero;
        //Int64 dataPgc64 = 0;
        var totalSize = 0;

        Type type = messageProtocol.GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var field = property.GetCustomAttribute<ProtocolField>();
            if (field != null)
            {
                totalSize += (int)field.Length;
                var lengthMask = (BigInteger.One << (int)field.Length) - 1;
                var propertyValue = property.GetValue(messageProtocol);

                BigInteger intValue = new BigInteger(Convert.ToInt64(propertyValue));
                dataPgc64 |= (intValue & lengthMask) << (int)field.StartIndex;

            }
        }

        var totalBytes = (int)Math.Ceiling(totalSize / 8.0) * 8;
        //Span<byte> bytes = stackalloc byte[8];
        //BinaryPrimitives.WriteInt64LittleEndian(bytes, dataPgc64);
        Console.WriteLine(dataPgc64.ToString("x"));
        byte[] bytes = dataPgc64.ToByteArray();
        Array.Resize(ref bytes, totalBytes / 8);
        return bytes;
        //return bytes.Slice(0, (totalBytes / 8)).ToArray();
    }

    public static void Read(ref ReadOnlySpan<byte> data, IProtoMessage messageProtocol)
    {
        Type type = messageProtocol.GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<ProtocolField>();
            if (attribute != null)
            {
                if (attribute.FieldName == "EthernetConfigInformation")
                {
                    Console.WriteLine("buldum");
                }
                var fieldSize = (int)Math.Ceiling(attribute.Length / 8.0) * 8;
                ReadOnlySpan<byte> passingData;
                double value = 0;

                var propertyType = property.PropertyType;
                if (property.GetValue(messageProtocol) is IList<object> fields)
                {
                    Console.WriteLine($"{attribute.FieldName}");
                    Read(ref data, fields, ref attribute);


                }
                else if (property.GetValue(messageProtocol) is IProtoMessage nestedMessage) //(propertyType.IsClass && !propertyType.IsEnum)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{attribute.FieldName}");
                    passingData = data.Slice((int)attribute.StartIndex / 8, fieldSize / 8);
                    Read(ref passingData, nestedMessage);
                }
                else if (propertyType.IsPrimitive || propertyType.IsEnum)
                {
                    value = GetPrimativeValue(ref data, ref attribute);


                    if (property.CanWrite)
                    {
                        if (propertyType == typeof(byte))
                        {
                            property.SetValue(messageProtocol, (byte)value);
                        }
                        else if (propertyType == typeof(short))
                        {
                            property.SetValue(messageProtocol, (short)value);
                        }
                        else if (propertyType == typeof(ushort))
                        {
                            property.SetValue(messageProtocol, (ushort)value);
                        }

                    }

                    if(attribute.FieldName.ToLower().Contains("ch1"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (attribute.FieldName.ToLower().Contains("ch2"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (attribute.FieldName.ToLower().Contains("ch3"))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (attribute.FieldName.ToLower().Contains("ch4"))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (attribute.FieldName.ToLower().Contains("ch5"))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (attribute.FieldName.ToLower().Contains("ch6"))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine($"{attribute.FieldName} " + value.ToString());


                }
            }
        }
    }

    private static void Read(ref ReadOnlySpan<byte> data, IEnumerable<object> fieldList, ref ProtocolField attribute)
    {
        var itemLength = (int)attribute.ItemLength;
        var startIndex = (int)attribute.StartIndex;
        var size = (int)attribute.Length;
        var itemCount = (int)size / itemLength;
        foreach (var field in fieldList)
        {

            var type = field.GetType();
            if (field is IEnumerable<object> fields)
            {
                Read(ref data, fields, ref attribute);
            }

            else if (field is IProtoMessage msgProtocol)
            {
                var refData = data.Slice(startIndex / 8, itemLength / 8);
                Read(ref refData, msgProtocol);
                startIndex += itemLength;
            }

        }

    }

    private static double GetPrimativeValue(ref ReadOnlySpan<byte> data, ref ProtocolField attribute)
    {
        var fieldSize = (int)Math.Ceiling(attribute.Length / 8.0) * 8;
        var processedBitCounter = 0;
        var processedByteCounter = 0;
        double value = 0;
        var startIndex = (int)attribute.StartIndex / 8;

        if(attribute.FieldName== "CH1AnahtarCurrent")
        {
            Debug.WriteLine("CH1AnahtarCurrent");
        }
        if ((attribute.StartIndex + attribute.Length) % 8 == 0)
        {
            switch (attribute.Length)
            {
                case 8:
                    value = data[startIndex];
                    break;
                case 16:
                    value = BinaryPrimitives.ReadInt16LittleEndian(data.Slice(startIndex, fieldSize / 8));
                    break;
                case 32:
                    if (attribute.Value == ProtocolField.ValueType.Integer)
                    {
                        value = BinaryPrimitives.ReadInt32LittleEndian(data.Slice(startIndex, fieldSize / 8));
                    }
                    else
                    {
                        value = BinaryPrimitives.ReadSingleLittleEndian(data.Slice(startIndex, fieldSize / 8));
                    }
                    break;
                case 64:
                    value = BinaryPrimitives.ReadInt64LittleEndian(data.Slice(startIndex, fieldSize / 8));
                    break;

            }
            
        }
        else
        {

            var bitIndex = (int)attribute.StartIndex;
            for (int i = 0; i < attribute.Length; i++)
            {
                var byteIndex = bitIndex / 8;
                var bitInByteIndex = bitIndex % 8; 
                var bitValue = GetBit(data[byteIndex], bitInByteIndex);
                bitIndex++;
                value = ((int)value) | (bitValue << processedBitCounter);
                processedBitCounter++;

                if ((processedBitCounter & 7) == 0)
                {
                    processedByteCounter++;
                    bitIndex = (int)attribute.StartIndex + processedByteCounter * 8;
                }
            }
        }

        return (value * attribute.Factor) + attribute.Offset;

    }


    private static int GetBit(byte b, int index)
    {
        int mask = (1 << index);
        return (b & mask) >> index;
    }
    private static int NewGetBit(int b, int length)
    {
        //var shiftAmount = bitIndex % 8;
        //var byteIndex = bitIndex / 8;
        //value = NewGetBit(data[byteIndex] >> shiftAmount, (int)attribute.Length);

        int mask = (1 << length) - 1;
        return b & mask;
    }


}

public static class BoardProto
{
    public static ProtoField Id = new(0, 8);
    public static ProtoField DeviceNumber = new(8, 4);
    public static ProtoField Const = new(12, 4);
    public static ProtoField Mode = new(16, 3);
    public static ProtoField DurationTime1 = new(19, 16);
    public static ProtoField DurationTime2 = new(35, 16);

    public static List<ProtoField> Fields = new List<ProtoField>();

    static BoardProto()
    {
        Fields.Add(Id);
        Fields.Add(DeviceNumber);
        Fields.Add(Const);
        Fields.Add(Mode);
        Fields.Add(DurationTime1);
        Fields.Add(DurationTime2);
    }
}

public struct ProtoField(int _startIndex, int _length)
{
    public int StartIndex = _startIndex;
    public int Length = _length;
}