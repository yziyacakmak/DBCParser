
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselsanController.Models.Protocol.AllInformation.SwitchBoardInformation
{
    internal class SwitchBoardErrorDataResponse : IProtoMessage
    {
        public MessageID Id => throw new NotImplementedException();

        public List<byte> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        [ProtocolField("DeviceNumber", 0, 4)]
        public byte DeviceNumber { get; set; }

        [ProtocolField("MessageID", 4, 4)]
        public MessageID MessageID { get; set; }

        [ProtocolField("Mode", 8, 3)]
        public Mode Mode { get; set; }

        [ProtocolField("TempSensor1ErrorStatus", 11, 2)]
        public byte TempSensor1ErrorStatus { get; set; }

        [ProtocolField("TempSensor2ErrorStatus", 13, 2)]
        public byte TempSensor2ErrorStatus { get; set; }

        [ProtocolField("TempSensorNTCErrorStatus", 15, 2)]
        public byte TempSensorNTCErrorStatus { get; set; }


        [ProtocolField("CH1AnahtarErrorStatus", 17, 2)]
        public byte CH1AnahtarErrorStatus { get; set; }

        [ProtocolField("CH1AlmacCurrentStatus", 19, 2)]
        public byte CH1AlmacCurrentStatus { get; set; }



        [ProtocolField("CH2AnahtarErrorStatus", 21, 2)]
        public byte CH2AnahtarErrorStatus { get; set; }

        [ProtocolField("CH2AlmacCurrentStatus", 23, 2)]
        public byte CH2AlmacCurrentStatus { get; set; }

        [ProtocolField("CH3AnahtarErrorStatus", 25, 2)]
        public byte CH3AnahtarErrorStatus { get; set; }

        [ProtocolField("CH3AlmacCurrentStatus", 27, 2)]
        public byte CH3AlmacCurrentStatus { get; set; }


        [ProtocolField("CH4AnahtarErrorStatus", 29, 2)]
        public byte CH4AnahtarErrorStatus { get; set; }

        [ProtocolField("CH4AlmacCurrentStatus", 31, 2)]
        public byte CH4AlmacCurrentStatus { get; set; }


        [ProtocolField("CH5AnahtarErrorStatus", 33, 2)]
        public byte CH5AnahtarErrorStatus { get; set; }

        [ProtocolField("CH5AlmacCurrentStatus", 35, 2)]
        public byte CH5AlmacCurrentStatus { get; set; }



        [ProtocolField("CH6AnahtarErrorStatus", 37, 2)]
        public byte CH6AnahtarErrorStatus { get; set; }

        [ProtocolField("CH6AlmacCurrentStatus", 39, 2)]
        public byte CH6AlmacCurrentStatus { get; set; }





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
