
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.DateStructure
{
    internal class DateStructureInformation : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        [ProtocolField("WeekDay", 0, 8)]
        public byte WeekDay { get; set; }

        [ProtocolField("Month", 8, 8)]
        public byte Month { get; set; }

        [ProtocolField("Date", 16, 8)]
        public byte Date { get; set; }

        [ProtocolField("Year", 24, 8)]
        public byte Year { get; set; }



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
