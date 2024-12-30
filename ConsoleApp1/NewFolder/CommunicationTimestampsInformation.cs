using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace AselsanController.Models.Protocol.AllInformation
{
    internal class CommunicationTimestampsInformation : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        [ProtocolField("AnahtarInformations", 0, 288,Variable =ProtocolField.VariableType.Collection,ItemLength =24)]
        public List<object> Anahtarlar { get; set; } = [];


        [ProtocolField("GYBInformation", 288, 24)]
        public TimeInformation GYB { get; set; } = new();

        [ProtocolField("SABInformation", 312, 24)]
        public TimeInformation SAB { get; set; } = new();

        [ProtocolField("SAEBInformation", 336, 24)]
        public TimeInformation SAEB { get; set; } = new();


        public CommunicationTimestampsInformation()
        {
            for (int i = 0; i < 12; i++)
            {
                Anahtarlar.Add(new TimeInformation());
            }

            
        }
        public void CreateData()
        {
            throw new NotImplementedException();
        }
        public void ReadData()
        {

        }
    }
}
