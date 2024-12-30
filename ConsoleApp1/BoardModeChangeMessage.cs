namespace ConsoleApp1;

internal class BoardModeChangeMessage : IProtoMessage
{
    [ProtocolField("Id",0,8)]
    public MessageID Id { get; } = MessageID.ModeChange;
    public List<byte> Data { get; set; } = new();


    [ProtocolField("DeviceNumber",8,4)]
    public byte DeviceNumber { get; set; }


    [ProtocolField("Const", 12, 4)] public byte Const { get; } = 0x01;
    
    [ProtocolField("Mode", 16, 3)]
    public Mode Mode { get; set; }


    [ProtocolField("DurationTime1", 19, 16)]
    public ushort DurationTime1 { get; set; }


    [ProtocolField("DurationTime2", 35, 16)]
    public ushort DurationTime2 { get; set; }


    public void CreateData()
    {
        Data = new(ProtocolFactory.Create(this));
        
    }
}

public enum Mode
{
    Reserved = 0x00,
    Transduser = 0x1,
    TaklitYuk = 0x2,
    Almac = 0x3,
    Off = 0x4,
    Channel = 0x5,
    TYTest = 0x6,
    Test = 0x7
}
