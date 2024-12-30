using DBCParser.Enums;
using DBCParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCParser
{
    public interface IMessage
    {
        public uint CanId { get; set; }
        public string Name { get; set; }
        public MessageType Type { get; set; }
        public int CycleTime { get; set; }
        public int Length { get; set; }

        public List<SignalModel> Signals { get; set; } 
    }
}
