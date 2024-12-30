
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation
{
    internal class SwitchBoardModeResponse : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        [ProtocolField("DeviceNumber", 0, 4)]
        public byte DeviceNumber { get; set; }

        [ProtocolField("MessageID", 4, 4)]
        public MessageID MessageID { get; set; }

        [ProtocolField("Mode", 8, 3)]
        public Mode Mode { get; set; }

        [ProtocolField("AllFeedBackStatus", 11, 1)]
        public byte AllFeedBackStatus { get; set; }

        [ProtocolField("CH1FeedBackStatus", 12, 8)]
        public byte CH1FeedBackStatus { get; set; }

        [ProtocolField("CH2FeedBackStatus", 20, 8)]
        public byte CH2FeedBackStatus { get; set; }

        [ProtocolField("CH3FeedBackStatus", 28, 8)]
        public byte CH3FeedBackStatus { get; set; }

        [ProtocolField("CH4FeedBackStatus", 36, 8)]
        public byte CH4FeedBackStatus { get; set; }

        [ProtocolField("CH5FeedBackStatus", 44, 8)]
        public byte CH5FeedBackStatus { get; set; }

        [ProtocolField("CH6FeedBackStatus", 52, 8)]
        public byte CH6FeedBackStatus { get; set; }

        [ProtocolField("Reserved", 60, 4)]
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
