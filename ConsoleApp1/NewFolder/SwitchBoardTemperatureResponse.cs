
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation
{

    internal class SwitchBoardTemperatureResponse : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        [ProtocolField("DeviceNumber", 0, 4)]
        public byte DeviceNumber { get; set; }

        [ProtocolField("MessageID", 4, 4)]
        public MessageID MessageID { get; set; }

        [ProtocolField("Mode", 8, 3)]
        public Mode Mode { get; set; }


        [ProtocolField("Temperature1", 11, 16, Factor = 0.01)]
        public byte Temperature1 { get; set; }

        [ProtocolField("Temperature2", 27, 16,Factor = 0.01)]
        public byte Temperature2 { get; set; }

        [ProtocolField("NTC", 43, 16,Factor = 0.01)]
        public byte NTC { get; set; }

        [ProtocolField("ReservedForInt64", 59, 5)]
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
