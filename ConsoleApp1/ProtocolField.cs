namespace ConsoleApp1;

[AttributeUsage(AttributeTargets.Field |
                AttributeTargets.Property)]
internal class ProtocolField : Attribute
{
    public string FieldName;
    public uint StartIndex;
    public uint Length;
    public FieldType Type=FieldType.Bit;
    public ValueType Value= ValueType.Integer;
    public VariableType Variable = VariableType.Variable;
    public uint ItemLength = 0;
    public double Factor=1;
    public double Offset=0;
    public ProtocolField(string key,uint idx,uint length)
    {
        FieldName = key;
        StartIndex = idx;
        Length = length;
    }

    public ProtocolField(string key, uint idx, uint length, double factor , double offset )
    {
        FieldName = key;
        StartIndex = idx;
        Length = length;
        Factor = factor;
        Offset = offset;
    }

    public ProtocolField(string key, uint idx, uint length, FieldType type, ValueType valType, double factor = 1, double offset =0,VariableType variable=VariableType.Variable,uint itemLength = 0)
    {
        FieldName = key;
        StartIndex = idx;
        Length = length;
        Type = type;
        Value = valType;
        Factor= factor;
        Offset = offset;
        Variable = variable;
        ItemLength = itemLength;
        if(Variable==VariableType.Collection)
        {
            if (ItemLength == 0) throw new Exception("Collection size defined must be defined greater than 0");
        }
    }

    public enum FieldType
    {
        Bit,
        Byte
        
    }
    public enum ValueType
    {
        Float,
        Integer      
    }
    public enum VariableType
    {
        Variable,
        Collection
    }

}