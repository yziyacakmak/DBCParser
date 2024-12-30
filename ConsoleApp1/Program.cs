// See https://aka.ms/new-console-template for more information

using AselsanController.Models.Protocol;
using AselsanController.Models.Protocol.AllInformation;
using ConsoleApp1;
using ConsoleApp1.NewFolder;
using System.Buffers.Binary;
using System.Numerics;

Console.WriteLine("Hello, World!");


byte[] data8 = [0x41, 0x47, 0x62, 0x35, 0x34, 0x45, 0x51, 0x61];
byte[] data3 = [0x41, 0x47, 0x62];
byte[] data5 = [0x41, 0x47, 0x62, 0x35, 0x34];

//SignalModel sgn5 = new(1, 8, ByteOrder.Motorola, 3);
//Print3(sgn5);

//SignalModel sgn_64 = new(7, 37, ByteOrder.Motorola, 5);
//Print5(sgn_64);
 

SignalModel sgn_little_8 = new(1, 8, ByteOrder.Intel, 8);
Print8(sgn_little_8);



void Print8(SignalModel sgn)
{
    Console.WriteLine($"sgn {sgn.StartBit} , mask: 0x{sgn.SignalInfo.mask.ToString("X")} , deger: 0x{sgn.CalculateData(data8, sgn.SignalInfo).ToString("X")}");
}
void Print3(SignalModel sgn)
{
    Console.WriteLine($"sgn {sgn.StartBit} , mask: 0x{sgn.SignalInfo.mask.ToString("X")} , deger: 0x{sgn.CalculateData(data3, sgn.SignalInfo).ToString("X")}");
}

void Print5(SignalModel sgn)
{
    Console.WriteLine($"sgn {sgn.StartBit} , mask: 0x{sgn.SignalInfo.mask.ToString("X")} , deger: 0x{sgn.CalculateData(data5, sgn.SignalInfo).ToString("X")}");
}








