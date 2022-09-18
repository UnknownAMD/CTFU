using CTFAK.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFAK.MFA.MFAObjectLoaders
{
    public class MFASubApplication : ObjectLoader
    {
        public int FrameNumber;

        public override void Read()
        {
            base.Read();
            FrameNumber = reader.ReadInt32();
            reader.ReadInt64();
            reader.ReadInt32();
            reader.ReadInt32();
            reader.ReadInt64();
            reader.ReadInt64();
            reader.ReadUInt64();
            reader.ReadUInt64();
            reader.ReadInt32();
            reader.Skip(1);
            reader.ReadInt64();
            reader.ReadInt32();
            reader.ReadUInt16();
        }

        public override void Write(ByteWriter Writer)
        {
            base.Write(Writer);
            Writer.WriteInt32(1);
            Writer.Skip(8);
            Writer.WriteInt64(2305843009213693952);
            Writer.WriteInt32(16777216);
            Writer.WriteInt32(234881024);
            Writer.WriteInt64(44053479555072);
            Writer.WriteInt64(72057589742960648);
            Writer.WriteUInt64(18446744073709551615);
            Writer.WriteUInt64(18446744073709551615);
            Writer.WriteInt32(65535);
            Writer.Skip(1);
            Writer.WriteInt64(72057594037927936);
            Writer.WriteInt32(184549376);
            Writer.WriteUInt16(0);
        }

        public MFASubApplication(ByteReader reader) : base(reader) { }
    }
}
