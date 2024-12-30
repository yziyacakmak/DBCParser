
using AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.EthernetConfigInformation
{
    internal class EthernetConfigInformation : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        
        [ProtocolField("IpAddress", 0, 32,Variable = ProtocolField.VariableType.Collection, ItemLength = 8)]
        public List<object> IpAddress { get; set; } = [];

        [ProtocolField("NetmaskAddress", 32, 32, Variable = ProtocolField.VariableType.Collection, ItemLength = 8)]
        public List<object> NetmaskAddress { get; set; } = [];

        [ProtocolField("GatewayAddress", 64, 32, Variable = ProtocolField.VariableType.Collection, ItemLength = 8)]
        public List<object> GatewayAddress { get; set; } = [];

        [ProtocolField("MacAddress", 96, 48, Variable = ProtocolField.VariableType.Collection, ItemLength = 8)]
        public List<object> MacAddress { get; set; } = [];

        [ProtocolField("PortUI", 144, 8)]
        public byte PortUI { get; set; }

        [ProtocolField("PortAselsan", 152, 8)]
        public byte PortAselsan { get; set; }

        public EthernetConfigInformation()
        {
            for (int i = 0; i < 6; i++)
            {
                if(i<4)
                {
                    IpAddress.Add(new CommonNetworkUnit());
                    NetmaskAddress.Add(new CommonNetworkUnit());
                    GatewayAddress.Add(new CommonNetworkUnit());
                }

                MacAddress.Add(new CommonNetworkUnit());
            }
        }

        public void CreateData()
        {
            throw new NotImplementedException();
        }

        public void ReadData()
        {
            throw new NotImplementedException();
        }
    }
    public class CommonNetworkUnit : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [ProtocolField("CommonNetworkUnit", 0, 8)]
        public byte Value { get; set; }
        public void CreateData()
        {
            throw new NotImplementedException();
        }
    }

}
