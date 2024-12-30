using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace AselsanController.Models.Protocol
{
    internal class TimeInformation : IProtoMessage
    {
        public MessageID Id { get; set;}

        public List<byte> Data { get;set; }

        [ProtocolField("TimeHour", 0, 8)]
        public byte Hours { get; set; }

        [ProtocolField("TimeMinute", 8, 8)]
        public byte Mintues { get; set; }

        [ProtocolField("TimeSecond", 16, 8)]
        public byte Seconds { get; set; }


        public void CreateData()
        {
            throw new NotImplementedException();
        }

        public void ReadData(byte[] data)
        {
            // ProtocolFactory.Read(data,this);
        }
    }
}
