using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace AselsanController.Models.Protocol.AllInformation.CommunicationTimeoutInformation
{
    internal class CommunicationValueInformation : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }





        [ProtocolField("AnahtarValues", 0, 192, Variable = ProtocolField.VariableType.Collection, ItemLength = 16)]
        public List<object> Anahtarlar { get; set; } = [];


        [ProtocolField("GYBValue", 192, 16)]
        public ushort GYB { get; set; }

        [ProtocolField("SABValue", 208, 16)]
        public ushort SAB { get; set; }

        [ProtocolField("SAEBValue", 224, 16)]
        public ushort SAEB { get; set; }

        [ProtocolField("UIValue", 240, 16)]
        public ushort UI { get; set; }

        public CommunicationValueInformation()
        {
            for (int i = 0; i < 12; i++)
            {
                Anahtarlar.Add(new TimeoutValueAnahtar());
            }
        }
        public void CreateData()
        {
            throw new NotImplementedException();
        }

        public void ReadData()
        {

        }


        public class TimeoutValueAnahtar : IProtoMessage
        {
            [ProtocolField("Value", 0, 16)]
            public ushort Value { get; set; }

            public MessageID Id => throw new NotImplementedException();

            public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void CreateData()
            {
                throw new NotImplementedException();
            }
        }
    }
}
