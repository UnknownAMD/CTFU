using System.Collections.Generic;
using System.Drawing;
using System.Xml.Schema;
using CTFAK.Memory;
using CTFAK.Utils;

namespace CTFAK.CCN.Chunks.Objects
{
    public class SubApplication : ChunkLoader
    {
        public int width;
        public int height;
        public short FrameNumber;
        public int flags;

        public SubApplication(ByteReader reader) : base(reader)
        { 
        } 
        public override void Read()
        {
            width = reader.ReadInt32();
            height = reader.ReadInt32();
            flags = reader.ReadInt32();
            FrameNumber = reader.ReadInt16();
        }

        public override void Write(ByteWriter Writer)
        {
            
        }


    }
}