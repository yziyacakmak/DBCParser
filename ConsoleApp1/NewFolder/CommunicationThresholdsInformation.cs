
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace AselsanController.Models.Protocol.AllInformation.CommunicationTimeoutInformation
{
    internal class CommunicationThresholdsInformation : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [ProtocolField("AnahtarThreshold", 0, 16)]
        public ushort AnahtarThreshold { get; set; }

        [ProtocolField("GYBThreshold", 16, 16)]
        public ushort GYBThreshold { get; set; }

        [ProtocolField("SABThreshold", 32, 16)]
        public ushort SABThreshold { get; set; }

        [ProtocolField("SAEBThreshold", 48, 16)]
        public ushort SAEBThreshold { get; set; }

        [ProtocolField("UIThreshold", 64, 16)]
        public ushort UIThreshold { get; set; }


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
