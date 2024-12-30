using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logReporter
{
    public class DBCClass
    {
        public List<Message> Messages= new List<Message> { };
        public Dictionary<string, Message> MessageDict = new Dictionary<string, Message>();
        public string path;
        public string name;
   
    }
    public class Message 
    {
        public string id;
        public string name;
        public string length;
        public string node;
        public int message_order;
        public Dictionary<string, Signal> SignalDict = new Dictionary<string, Signal>();
        public List<Signal> Signals=new List<Signal>{ };
    }
    public class Signal
    {
        public string signal_name;
        public string start_pos_bit_length;
        public string endianness;
        public string scaling_offset;
        public string minimum_maximum;
        public string unit;
        public string node;
        public string dbc_name;
        public string message_name;
        public string message_id;
        public int signal_order;
    }

}
