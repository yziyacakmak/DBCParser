using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation
{
    internal class SwitchBoardCurrentResponse1 : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        [ProtocolField("DeviceNumber", 0, 4)]
        public byte DeviceNumber { get; set; }

        [ProtocolField("MessageID", 4, 4)]
        public MessageID MessageID { get; set; }

        [ProtocolField("Mode", 8, 3)]
        public Mode Mode { get; set; }


        [ProtocolField("CH1AnahtarCurrent", 11, 16,Factor =0.001)]
        public byte CH1AnahtarCurrent { get; set; }

        [ProtocolField("CH1AlmacCurrent", 27, 10, Factor = 0.01)]
        public byte CH1AlmacCurrent { get; set; }



        [ProtocolField("CH2AnahtarCurrent", 37, 16, Factor = 0.001)]
        public byte CH2AnahtarCurrent { get; set; }

        [ProtocolField("CH2AlmacCurrent", 53, 10, Factor = 0.01)]
        public byte CH2AlmacCurrent { get; set; }

        [ProtocolField("ReservedForInt64", 63, 1)]
        public byte Reserved { get; set; }



        public void CreateData()
        {
            throw new NotImplementedException();
        }

        public void ReadData()
        {
            throw new NotImplementedException();
        }
    }
}
