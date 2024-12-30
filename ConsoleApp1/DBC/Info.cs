using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DBCParser.Helpers
{
    internal struct Info
    {
        public int lsbBitIndex;
        public int msbBitIndex;
        public int lsbBitByte;
        public int msbBitByte;
        public BigInteger mask;
    }
}
