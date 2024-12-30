
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation
{
    internal class SwitchBoardInformation : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [ProtocolField("Response", 0, 8)]
        public SwitchBoardResponse Response { get; set; }

        [ProtocolField("ModeResponse", 8, 64)]
        public SwitchBoardModeResponse ModeResponse { get; set; } = new();

        [ProtocolField("CurrentResponse1", 72, 64)]
        public SwitchBoardCurrentResponse1 CurrentResponse1 { get; set; } = new();

        [ProtocolField("CurrentResponse2", 136, 64)]
        public SwitchBoardCurrentResponse2 CurrentResponse2 { get; set; } = new();

        [ProtocolField("CurrentResponse3", 200, 64)]
        public SwitchBoardCurrentResponse3 CurrentResponse3 { get; set; } = new();

        [ProtocolField("TemperatureResponse", 264, 64)]
        public SwitchBoardTemperatureResponse TemperatureResponse { get; set; } = new();

        [ProtocolField("ErrorDataResponse", 328, 64)]
        public SwitchBoardErrorDataResponse ErrorDataResponse { get; set; } = new();

        [ProtocolField("ConfigResponse", 392, 64)]
        public SwitchBoardConfigResponse ConfigResponse { get; set; } = new();

        [ProtocolField("EnterBootloaderResponse", 456, 64)]
        public SwitchBoardEnterBootloaderResponse EnterBootloaderResponse { get; set; } = new();

        [ProtocolField("ChannelModeResponse", 520, 64)]
        public SwitchBoardChannelModeResponse ChannelModeResponse { get; set; } = new();


        public void CreateData()
        {
            throw new NotImplementedException();
        }

        public void ReadData()
        {
            throw new NotImplementedException();
        }
    }



    public enum SwitchBoardResponse
    {
        Idle = 0,
        Busy = 1,
        Replied_OK = 2,
        Replied_NOK = 3,
        Timeout = 4
    }
}
