
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace AselsanController.Models.Protocol.AllInformation.CommunicationTimeoutInformation
{
    internal class CommunicationFlagInformation : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        [ProtocolField("AnahtarlarFlag", 0, 96,Variable = ProtocolField.VariableType.Collection, ItemLength = 8)]
        public List<object> Anahtarlar { get; set; } = [];

        [ProtocolField("GYBFlag", 96, 8)]
        public byte GYB { get; set; }

        [ProtocolField("SABFlag", 104, 8)]
        public byte SAB { get; set; }

        [ProtocolField("SAEBFlag", 112, 8)]
        public byte SAEB { get; set; }

        public CommunicationFlagInformation()
        {
            for (int i = 0; i < 12; i++)
            {
                Anahtarlar.Add(new TimeoutFlagAnahtar());
            }
        }

        public void CreateData()
        {
            throw new NotImplementedException();
        }

        public void ReadData()
        {
            throw new NotImplementedException();
        }

        public class TimeoutFlagAnahtar : IProtoMessage
        {
            [ProtocolField("Flag", 0, 8)]
            public byte Value { get; set; }

            public MessageID Id => throw new NotImplementedException();

            public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void CreateData()
            {
                throw new NotImplementedException();
            }
        }
    }
}
