
using AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation;
using ConsoleApp1;
using static AselsanController.Models.Protocol.AllInformation.CommunicationTimeoutInformation.CommunicationFlagInformation;
using static ConsoleApp1.ProtocolField;

namespace AselsanController.Models.Protocol.AllInformation
{
    internal class AllInformationMessage : IProtoMessage
    {

        public List<byte> Data { get; set; } = [];


        [ProtocolField("Id", 0, 8)]
        public MessageID Id { get; } = MessageID.AllInformation;

        [ProtocolField("BirimInfo", 8, 8)]
        public byte BirimInfo { get; set; }

        [ProtocolField("Fan1", 16, 8)]
        public byte Fan1 { get; set; }

        [ProtocolField("Fan2", 24, 8)]
        public byte Fan2 { get; set; }

        [ProtocolField("Fan3", 32, 8)]
        public byte Fan3 { get; set; }

        [ProtocolField("Fan1Duty", 40, 8)]
        public byte Fan1Duty { get; set; }

        [ProtocolField("Fan2Duty", 48, 8)]
        public byte Fan2Duty { get; set; }

        [ProtocolField("GYBData", 56, 8)]
        public byte GYBData { get; set; }

        [ProtocolField("SIBData", 64, 8)]
        public byte SIBData { get; set; }

        [ProtocolField("SAEBData", 72, 8)]
        public byte SAEBData { get; set; }

        [ProtocolField("SABData", 80, 8)]
        public byte SABData { get; set; }

        [ProtocolField("TTLData", 88, 8)]
        public byte TTLData { get; set; }

        [ProtocolField("LED1", 96, 8)]
        public byte LED1 { get; set; }

        [ProtocolField("LED2", 104, 8)]
        public byte LED2 { get; set; }

        [ProtocolField("LED3", 112, 8)]
        public byte LED3 { get; set; }

        [ProtocolField("LED4", 120, 8)]
        public byte LED4 { get; set; }

        [ProtocolField("LED5", 128, 8)]
        public byte LED5 { get; set; }

        [ProtocolField("LED6", 136, 8)]
        public byte LED6 { get; set; }

        [ProtocolField("LED7", 144, 8)]
        public byte LED7 { get; set; }

        [ProtocolField("LED8", 152, 8)]
        public byte LED8 { get; set; }

        [ProtocolField("LED9", 160, 8)]
        public byte LED9 { get; set; }

        [ProtocolField("LED10", 168, 8)]
        public byte LED10 { get; set; }

        [ProtocolField("Output1", 176, 8)]
        public byte Output1 { get; set; }

        [ProtocolField("Output2", 184, 8)]
        public byte Output2 { get; set; }

        [ProtocolField("Output3", 192, 8)]
        public byte Output3 { get; set; }

        [ProtocolField("Output4", 200, 8)]
        public byte Output4 { get; set; }

        [ProtocolField("Output5", 208, 8)]
        public byte Output5 { get; set; }

        [ProtocolField("Output6", 216, 8)]
        public byte Output6 { get; set; }

        [ProtocolField("Output7", 224, 8)]
        public byte Output7 { get; set; }

        [ProtocolField("Output8", 232, 8)]
        public byte Output8 { get; set; }

        [ProtocolField("Output9", 240, 8)]
        public byte Output9 { get; set; }

        [ProtocolField("Output10", 248, 8)]
        public byte Output10 { get; set; }

        [ProtocolField("Output11", 256, 8)]
        public byte Output11 { get; set; }

        [ProtocolField("Output12", 264, 8)]
        public byte Output12 { get; set; }

        [ProtocolField("Input1", 272, 8)]
        public byte Input1 { get; set; }

        [ProtocolField("Input2", 280, 8)]
        public byte Input2 { get; set; }

        [ProtocolField("Input3", 288, 8)]
        public byte Input3 { get; set; }

        [ProtocolField("Input4", 296, 8)]
        public byte Input4 { get; set; }

        [ProtocolField("Input5", 304, 8)]
        public byte Input5 { get; set; }

        [ProtocolField("Input6", 312, 8)]
        public byte Input6 { get; set; }

        [ProtocolField("Input7", 320, 8)]
        public byte Input7 { get; set; }

        [ProtocolField("Input8", 328, 8)]
        public byte Input8 { get; set; }

        [ProtocolField("Input9", 336, 8)]
        public byte Input9 { get; set; }

        [ProtocolField("Input10", 344, 8)]
        public byte Input10 { get; set; }

        [ProtocolField("Input11", 352, 8)]
        public byte Input11 { get; set; }

        [ProtocolField("Input12", 360, 8)]
        public byte Input12 { get; set; }

        [ProtocolField("Input13", 368, 8)]
        public byte Input13 { get; set; }

        [ProtocolField("Input14", 376, 8)]
        public byte Input14 { get; set; }

        [ProtocolField("Input15", 384, 8)]
        public byte Input15 { get; set; }

        [ProtocolField("Temperature1", 392, 32,Type=FieldType.Bit,Value =ProtocolField.ValueType.Float)]
        public double Temperature1 { get; set; }

        [ProtocolField("Temperature2", 424, 32, Type = FieldType.Bit, Value = ProtocolField.ValueType.Float)]
        public double Temperature2 { get; set; }

        [ProtocolField("ACVoltage", 456, 32, Type = FieldType.Bit, Value = ProtocolField.ValueType.Float)]
        public double ACVoltage { get; set; }

        [ProtocolField("ACCurrent", 488, 32, Type = FieldType.Bit, Value = ProtocolField.ValueType.Float)]
        public double ACCurrent { get; set; }

        [ProtocolField("Voltage1", 520, 32, Type = FieldType.Bit, Value = ProtocolField.ValueType.Float)]
        public double Voltage1 { get; set; }

        [ProtocolField("Voltage2", 552, 32, Type = FieldType.Bit, Value = ProtocolField.ValueType.Float)]
        public double Voltage2 { get; set; }

        [ProtocolField("Voltage3", 584, 32, Type = FieldType.Bit, Value = ProtocolField.ValueType.Float)]
        public double Voltage3 { get; set; }

        [ProtocolField("Voltage4", 616, 32, Type = FieldType.Bit, Value = ProtocolField.ValueType.Float)]
        public double Voltage4 { get; set; }

        [ProtocolField("CommunicationTimeoutInformation", 648, 816)]
        public CommunicationTimeoutInformation.CommunicationTimeoutInformation CommunicationTimeoutInformation { get; set; } = new();


        [ProtocolField("SwitchboardInformations", 1464, 7008, Variable = ProtocolField.VariableType.Collection, ItemLength = 584)]
        public List<object> SwitchboardInformations { get; set; } = [];


        [ProtocolField("EthernetConfigInformation", 8472, 160)]
        public EthernetConfigInformation.EthernetConfigInformation EthernetConfigInformation { get; set; } = new();

        [ProtocolField("DateStructureInformation", 8632, 32)]
        public DateStructure.DateStructureInformation DateStructureInformation { get; set; } = new();


        [ProtocolField("TimeInformation", 8664, 24)]
        public TimeInformation TimeInformation { get; set; }=new();

        [ProtocolField("FirmwareMajorVer", 8688, 8)]
        public byte FirmwareMajorVer { get; set; }

        [ProtocolField("FirmwareMinorVer", 8696, 8)]
        public byte FirmwareMinorVer { get; set; }

        //total 8808


        public AllInformationMessage()
        {
            for (int i = 0; i < 12; i++)
            {
                SwitchboardInformations.Add(new SwitchBoardInformation.SwitchBoardInformation());
            }
        }
        public void CreateData()
        {

        }

        public void ReadData()
        {

        }
    }
}
