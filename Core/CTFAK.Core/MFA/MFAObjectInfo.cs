﻿using CTFAK.CCN.Chunks;
using CTFAK.Memory;
using CTFAK.MFA.MFAObjectLoaders;
using CTFAK.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFAK.MFA
{
    public class MFAObjectInfo : ChunkLoader
    {
        public int NonIdentified;
        public int NonIdentified2;
        public int ObjectType;
        public int Handle;
        public string Name;
        public int Transparent;
        public int InkEffect;
        public uint InkEffectParameter;
        public int AntiAliasing;
        public int Flags;
        public int IconType;
        public int IconHandle;
        public MFAChunkList Chunks;
        public ChunkLoader Loader;

        public override void Write(ByteWriter Writer)
        {
            //Debug.Assert(ObjectType==2);
            Writer.WriteInt32(this.ObjectType);
            Writer.WriteInt32(Handle);
            if (Name == "" || Name == null)
            {
                NonIdentified2++;
                Name = "Not identified object " + NonIdentified;
            }
            Writer.AutoWriteUnicode(Name);
            Writer.WriteInt32(Transparent);
            Writer.WriteInt32(InkEffect);
            Writer.WriteUInt32(InkEffectParameter);
            Writer.WriteInt32(AntiAliasing);
            Writer.WriteInt32(Flags);
            Writer.WriteInt32(1);
            Writer.WriteInt32(IconHandle);

            Chunks.Write(Writer);
            if (Loader == null)
            {
                Loader = new MFASubApplication(reader);
                Loader.Write(Writer);
            }
            else
            {
                Loader.Write(Writer);
            }



        }



        public override void Read()
        {

            ObjectType = reader.ReadInt32();
            Handle = reader.ReadInt32();
            Name = reader.AutoReadUnicode();
            if (Name == "" || Name == null)
            {
                NonIdentified++;
                Name = "Non identified object " + NonIdentified;
            }
            Transparent = reader.ReadInt32();

            InkEffect = reader.ReadInt32();
            InkEffectParameter = reader.ReadUInt32();
            AntiAliasing = reader.ReadInt32();

            Flags = reader.ReadInt32();

            IconType = reader.ReadInt32();
            if (IconType == 1)
            {
                IconHandle = reader.ReadInt32();
            }
            else throw new InvalidDataException("invalid icon");
            Chunks = new MFAChunkList(reader);
            Chunks.Log = true;
            Chunks.Read();

            if (ObjectType >= 32)//extension base
            {
                Loader = new MFAExtensionObject(reader);

            }
            else if (ObjectType == 0)
            {
                Loader = new MFAQuickBackdrop(reader);
            }
            else if (ObjectType == 1)
            {
                Loader = new MFABackdrop(reader);
            }
            else if (ObjectType == 7)
            {
                Loader = new MFACounter(reader);
            }
            else if (ObjectType == 9)
            {
                Loader = new MFASubApplication(reader);
            }
            else if (ObjectType == 2)
            {
                Loader = new MFAActive(reader);
            }
            else if(ObjectType==3)
            {
                Loader = new MFAText(reader);
            }
            //else throw new NotImplementedException("Unsupported object: " + ObjectType);
            Loader.Read();



        }
        public MFAObjectInfo(ByteReader reader) : base(reader)
        { }
    }
}
