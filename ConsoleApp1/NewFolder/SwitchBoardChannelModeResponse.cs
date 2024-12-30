
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation
{
    internal class SwitchBoardChannelModeResponse : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        [ProtocolField("DeviceNumber", 0, 4)]
        public byte DeviceNumber { get; set; }

        [ProtocolField("MessageID", 4, 4)]
        public MessageID MessageID { get; set; }

        [ProtocolField("Mode", 8, 3)]
        public Mode Mode { get; set; }

        [ProtocolField("ChannelNumber", 11, 3)]
        public byte ChannelNumber { get; set; }

        [ProtocolField("AllFeedbackStatus", 14, 1)]
        public byte AllFeedbackStatus { get; set; }

        [ProtocolField("ChannelFeedbackStatus", 15, 8)]
        public byte ChannelFeedbackStatus { get; set; }




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
