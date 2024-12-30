using ConsoleApp1;

namespace AselsanController.Models.Protocol.AllInformation.CommunicationTimeoutInformation
{
    internal class CommunicationTimeoutInformation : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [ProtocolField("CommunicationThresholds", 0, 80)]
        public CommunicationThresholdsInformation Thresholds { get; set; } = new();


        [ProtocolField("CommunicationTimestamps", 80, 360)]
        public CommunicationTimestampsInformation Timestamps { get; set; } = new();

        [ProtocolField("CommunicationValues", 440, 256)]
        public CommunicationValueInformation Values { get; set; } = new();

        [ProtocolField("CommunicationFlags", 696, 120)]
        public CommunicationFlagInformation Flags { get; set; } = new();


        public void CreateData()
        {
            throw new NotImplementedException();
        }

        public void ReadData()
        {

        }


    }
}
