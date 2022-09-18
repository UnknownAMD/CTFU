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
        public int fileNameMORELIKEUNKNOWNINT;
        public int width;
        public int height;
        public int flaggyflag;
        public int frameNum;
        public override void Read()
        {
            base.Read();
            reader.ReadInt32();
        }
            

        public override void Write(ByteWriter Writer)
        {
            base.Write(Writer);
            Writer.WriteInt32(fileNameMORELIKEUNKNOWNINT);
            Writer.WriteInt32(width);
            Writer.WriteInt32(height);
            Writer.WriteInt32(flaggyflag);
            Writer.WriteInt32(frameNum);
            //Writer.WriteInt32(-1);
        }

        public MFASubApplication(ByteReader reader) : base(reader) { }
    }
}
