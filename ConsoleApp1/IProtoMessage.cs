namespace ConsoleApp1;

public interface IProtoMessage
{
    public MessageID Id { get; }

    public List<byte> Data { get; set; }

    public void CreateData();
}