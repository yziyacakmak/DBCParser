
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation
{
    internal class SwitchBoardConfigResponse : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        [ProtocolField("DeviceNumber", 0, 4)]
        public byte DeviceNumber { get; set; }

        [ProtocolField("MessageID", 4, 4)]
        public MessageID MessageID { get; set; }

        [ProtocolField("Mode", 8, 3)]
        public Mode Mode { get; set; }

        [ProtocolField("CurrentProtectionOn", 11, 1)]
        public byte CurrentProtectionOn { get; set; }

        [ProtocolField("CurrentProtectionMaxThreshold", 12, 8, Factor = 1000)]
        public byte CurrentProtectionMaxThreshold { get; set; }

        [ProtocolField("CurrentProtectionMinThreshold", 20, 8, Factor = 1000)]
        public byte CurrentProtectionMinThreshold { get; set; }

        [ProtocolField("TemperatureProtectionOn", 28, 1)]
        public byte TemperatureProtectionOn { get; set; }

        [ProtocolField("TemperatureProtectionMaxThreshold", 29, 8, Factor = 1000)]
        public byte TemperatureProtectionMaxThreshold { get; set; }

        [ProtocolField("TemperatureProtectionMinThreshold", 37, 8, Factor = 1000)]
        public byte TemperatureProtectionMinThreshold { get; set; }

        [ProtocolField("FirmwareMajValue", 45, 8)]
        public byte FirmwareMajValue { get; set; }

        [ProtocolField("FirmwareMinValue", 53, 8)]
        public byte FirmwareMinValue { get; set; }

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
