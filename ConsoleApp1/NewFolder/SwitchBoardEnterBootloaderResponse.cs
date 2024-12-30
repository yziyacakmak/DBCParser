
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation
{

    internal class SwitchBoardEnterBootloaderResponse : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        [ProtocolField("DeviceNumber", 0, 4)]
        public byte DeviceNumber { get; set; }

        [ProtocolField("MessageID", 4, 4)]
        public MessageID MessageID { get; set; }

        [ProtocolField("Mode", 8, 3)]
        public Mode Mode { get; set; }

        [ProtocolField("EnterBootloader", 11, 1)]
        public byte EnterBootloader { get; set; }

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
