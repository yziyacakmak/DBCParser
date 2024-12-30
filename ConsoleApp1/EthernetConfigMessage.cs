using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace ConsoleApp1;

internal partial class EthernetConfigMessage : IProtoMessage
{
    [ProtocolField("Id", 0, 8)] public MessageID Id { get; } = MessageID.EthernetConfig;
    public List<byte> Data { get; set; } = new();


    private byte[] IpAddress { get; set; } = new byte[4];
    private byte[] NetMaskAddress { get; set; } = new byte[4];
    private byte[] GatewayAddress { get; set; } = new byte[4];
    private byte[] MacAddress { get; set; } = new byte[6];


    public string Ip { get; set; }
    public string NetMask { get; set; }
    public string Gateway { get; set; }
    public string Mac { get; set; }


    [ProtocolField("Ip0", 0, 8)] public byte Ip0 { get; set; }

    [ProtocolField("Ip1", 8, 8)] public byte Ip1 { get; set; }

    [ProtocolField("Ip2", 16, 8)] public byte Ip2 { get; set; }

    [ProtocolField("Ip3", 24, 8)] public byte Ip3 { get; set; }


    [ProtocolField("NetMask0", 32, 8)] public byte NetMask0 { get; set; }

    [ProtocolField("NetMask1", 40, 8)] public byte NetMask1 { get; set; }

    [ProtocolField("NetMask2", 48, 8)] public byte NetMask2 { get; set; }

    [ProtocolField("NetMask3", 56, 8)] public byte NetMask3 { get; set; }


    [ProtocolField("Gateway0", 64, 8)] public byte Gateway0 { get; set; }

    [ProtocolField("Gateway1", 72, 8)] public byte Gateway1 { get; set; }

    [ProtocolField("Gateway2", 80, 8)] public byte Gateway2 { get; set; }

    [ProtocolField("Gateway3", 88, 8)] public byte Gateway3 { get; set; }


    [ProtocolField("Mac0", 96, 8)] public byte Mac0 { get; set; }

    [ProtocolField("Mac1", 104, 8)] public byte Mac1 { get; set; }

    [ProtocolField("Mac2", 112, 8)] public byte Mac2 { get; set; }

    [ProtocolField("Mac3", 120, 8)] public byte Mac3 { get; set; }

    [ProtocolField("Mac4", 128, 8)] public byte Mac4 { get; set; }

    [ProtocolField("Mac5", 136, 8)] public byte Mac5 { get; set; }

    [ProtocolField("UserInterfacePort", 144, 8)]
    public byte UserInterfacePort { get; set; }

    [ProtocolField("UserInterfacePort", 152, 8)]
    public byte AselsanPort { get; set; }

    public void CreateData()
    {
        Data = new(ProtocolFactory.Create(this));
        // ParseNetwork();
        // Data.Add((byte)Id);
        // foreach (var ipByte in IpAddress)
        // {
        //     Data.Add(ipByte);
        // }
        //
        // foreach (var netByte in IpAddress)
        // {
        //     Data.Add(netByte);
        // }
        //
        // foreach (var gatewayByte in GatewayAddress)
        // {
        //     Data.Add(gatewayByte);
        // }
        //
        // foreach (var macByte in MacAddress)
        // {
        //     Data.Add(macByte);
        // }
        //
        // Data.Add(UserInterfacePort);
        // Data.Add(AselsanPort);
    }

    private void ParseNetwork()
    {
        if (IPAddress.TryParse(Ip, out IPAddress? ipAddress))
        {
            IpAddress = ipAddress.GetAddressBytes();
        }
        else
        {
            Debug.WriteLine("ip parse edilemedi");
        }

        if (IPAddress.TryParse(NetMask, out IPAddress? netMask))
        {
            NetMaskAddress = netMask.GetAddressBytes();
        }
        else
        {
            Debug.WriteLine("net mask parse edilemedi");
        }

        if (IPAddress.TryParse(Gateway, out IPAddress? gateway))
        {
            GatewayAddress = gateway.GetAddressBytes();
        }
        else
        {
            Debug.WriteLine("gateway parse edilemedi");
        }

        if (macRegex.IsMatch(Mac))
        {
            string[] hex = Mac.Split([':', '-']);
            byte[] bytes = new byte[hex.Length];

            for (int i = 0; i < hex.Length; i++)
            {
                MacAddress[i] = Convert.ToByte(hex[i], 16);
            }
        }
    }

    // Regex nesnesi oluştur
    static readonly Regex macRegex = MacAddR();

    [GeneratedRegex(@"^([0-9A-Fa-f]{2}[-:]){5}([0-9A-Fa-f]{2})$")]
    private static partial Regex MacAddR();
}