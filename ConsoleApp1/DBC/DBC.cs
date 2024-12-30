using DBCParser.Attributes;
using DBCParser.Enums;
using DBCParser.Models;
using logReporter;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace DBCParser
{

    public class DBC
    {
        public string Name { get; set; }
        public List<MessageModel> Messages { get; set; } = new();
        public Dictionary<uint, MessageModel> MessageDictionary { get; set;} = new();
        public Dictionary<string, SignalModel> AllSignals { get; set; } = new();


        public string Path { get; set; }

        private List<object> _source;
        public List<object> Source
        {
            get => _source;
            set 
            { 
                _source = value;
                Cache(_source);
            }
        }

        private Dictionary<string,List<ObjectPropertyModel>> Dict { get; set; } =new();


        public DBC() { }

        public DBC(string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
            DBCParse(path);
        } 

        private void Cache(IEnumerable<object> _source)
        {
            foreach (var att in _source)
            {
                Type type = att.GetType();
                if (att is IEnumerable<object> selam)
                    Cache(selam);
                else if (type.IsClass)
                {
                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var property in properties)
                    {
                        var attribute = property.GetCustomAttribute<DBCSignalAttribute>();
                        if (attribute != null)
                        {
                            if (Dict.TryGetValue(attribute.Key, out var val))
                            {
                                val.Add(new ObjectPropertyModel { Obj = att, Prop = property });
                            }
                            else
                            {
                                Dict.Add(attribute.Key, new List<ObjectPropertyModel> { new ObjectPropertyModel { Obj = att, Prop = property } });
                            }
                        }

                    }
                }
            }
        }


        private void DBCParse(string path)
        {
            Messages.Clear();
            MessageDictionary.Clear();
            AllSignals.Clear();

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.StartsWith("BO_"))
                    {
                        MessageModel msg = new();
                        string[] msgArray = line.Split(' ');
                        msg.CanId = ShiftValue(msgArray[1]);
                        msg.CanIdHex = ShiftValueString(msgArray[1]);
                        msg.Name = msgArray[2].Replace(":", "");
                        msg.Length = int.Parse(msgArray[3]);
                        msg.Sender = msgArray[4];
                        line = reader.ReadLine();
                        while (line.StartsWith(" SG_"))
                        {
                            SignalModel sgn = new SignalModel();
                            string[] sgnArray = line.Split(' ');
                            sgn.Name = sgnArray[2];
                            var start_length_end_sign = Regex.Matches(sgnArray[4], @"\d+|[|@+-]");
                            if (start_length_end_sign.Count > 0)
                            {
                                sgn.Length = int.Parse(start_length_end_sign[2].Value);
                                sgn.StartBit = int.Parse(start_length_end_sign[0].Value);


                                if (start_length_end_sign[4].Value == "0") { sgn.ByteOrder = ByteOrder.Motorola; }
                                else { sgn.ByteOrder = ByteOrder.Intel; }


                                if (start_length_end_sign[5].Value == "+") sgn.SignalType = SignalType.Unsigned;
                                else sgn.SignalType = SignalType.Signed;

                            }

                            var factor_offset_match = Regex.Match(sgnArray[5], @"\(([-+]?\d*\.?\d+),([-+]?\d*\.?\d+)\)");
                            if (factor_offset_match.Success)
                            {
                                sgn.Factor = double.Parse(factor_offset_match.Groups[1].Value);
                                sgn.Offset = double.Parse(factor_offset_match.Groups[2].Value);
                            }

                            var min_max_match = Regex.Match(sgnArray[6], @"\[(\-?\d*\.?\d+)\|(\-?\d*\.?\d+)\]");
                            if (min_max_match.Success)
                            {
                                sgn.Minimum = double.Parse(min_max_match.Groups[1].Value);
                                sgn.Maximum = double.Parse(min_max_match.Groups[2].Value);
                            }
                            sgn.Unit = sgnArray[7];
                            sgn.Reciever = sgnArray[8];
                            sgn.ParentMessage = msg;

                            string signal_key1 =/* sgn.PARENT_MESSAGE.CAN_ID_HEX_STRING +*/ sgn.Name;
                            string signal_key2 = sgn.ParentMessage.CanIdHex + sgn.Name;
                            sgn.Key = signal_key2;
                            msg.SignalDictionary.Add(signal_key1, sgn);
                            msg.Signals.Add(sgn);
                            try
                            {
                                AllSignals.Add(signal_key2, sgn);
                            }
                            catch { }

                            line = reader.ReadLine();
                        }
                        Messages.Add(msg);
                        //string new_msg_id = ShiftValue(msg.CAN_ID);
                        try
                        {
                            MessageDictionary.Add(msg.CanId, msg);
                        }
                        catch { }

                    }

                }


            }
        }

        private uint ShiftValue(string value)
        {
            UInt32 val = Convert.ToUInt32(value);
            UInt32 output = val & 0x1FFFFFFF;
            return output;
        }
        private string ShiftValueString(string value)
        {
            UInt32 val = Convert.ToUInt32(value);
            UInt32 output = val & 0x1FFFFFFF;
            return output.ToString("X");
        }


        public void CalculateValues(uint _id,List<byte> data)
        {
            if (MessageDictionary.TryGetValue(_id, out var msg))
            {
                msg.CalculateValues(data);
            }
        }

        public void CalculateSignalValue(string key,List<byte> data)
        {
            if (AllSignals.TryGetValue(key, out var signal))
            {
                signal.GetPhysicalValue(data);
            }
        }

        public void AutoSignalAttributeSetter(string key, List<byte> data)
        {
            if(AllSignals.TryGetValue(key,out var sgn))
            { 
                sgn.GetPhysicalValue(data, Source);
            }
            
        }

        public void AutoMapAll(uint id,List<byte> data)
        {

            if (MessageDictionary.TryGetValue(id, out var msg))
            {
                msg.CalculateValues(data, Dict);
            }   
        }

        public void AutoMapWithKey(string key,List<byte> message_data)
        {
            if (AllSignals.TryGetValue(key, out var signal))
            {
                signal.GetPhysicalValue(message_data,Dict);
            }
        }

        public List<byte> GenerateMessageFrame(uint id)
        {
            if (MessageDictionary.TryGetValue(id, out var msg))
            {
                return  msg.FrameGenarator();
            }
            else
            {
                throw new InvalidOperationException("The message id can't found in DBC file.");
            }
        }

        public ObservableCollection<MessageModel> ToObservableCollection()
        {
            ObservableCollection<MessageModel> MessageOB = new();

            foreach (var message in Messages)
            {
                MessageOB.Add(message);
            }


           return MessageOB;
        }
    }
}
