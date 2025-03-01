﻿using CTFAK.Memory;
using CTFAK.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CTFAK.CCN.Constants;

namespace CTFAK.CCN.Chunks.Objects
{
    public class ObjectCommon : ChunkLoader
    {
        private short _valuesOffset;
        private short _stringsOffset;
        private uint _fadeinOffset;
        private uint _fadeoutOffset;
        private short _movementsOffset;
        private short _subAppOffset;
        private short _animationsOffset;
        private short _systemObjectOffset;
        private short _counterOffset;
        private short _extensionOffset;
        public string Identifier;

        public Animations Animations;

        public BitDict Preferences = new BitDict(new string[]
            {
                "Backsave",
                "ScrollingIndependant",
                "QuickDisplay",
                "Sleep",
                "LoadOnCall",
                "Global",
                "BackEffects",
                "Kill",
                "InkEffects",
                "Transitions",
                "FineCollisions",
                "AppletProblems"
            }
        );

        public BitDict Flags = new BitDict(new string[]
            {
                "DisplayInFront",
                "Background",
                "Backsave",
                "RunBeforeFadeIn",
                "Movements",
                "Animations",
                "TabStop",
                "WindowProc",
                "Values",
                "Sprites",
                "InternalBacksave",
                "ScrollingIndependant",
                "QuickDisplay",
                "NeverKill",
                "NeverSleep",
                "ManualSleep",
                "Text",
                "DoNotCreateAtStart",
                "FakeSprite",
                "FakeCollisions"
            }
        );

        public BitDict NewFlags = new BitDict(new string[]
            {
                "DoNotSaveBackground",
                "SolidBackground",
                "CollisionBox",
                "VisibleAtStart",
                "ObstacleSolid",
                "ObstaclePlatform",
                "AutomaticRotation"
            }
        );

        public Color BackColor;
        public ObjectInfo Parent;
        public Counters Counters;
        public SubApplication SubApplication;
        public byte[] ExtensionData;
        public int ExtensionPrivate;
        public int ExtensionId;
        public int ExtensionVersion;
        //public AlterableValues Values;
        //public AlterableStrings Strings;
        public Movements Movements;
        public Text Text;
        public Counter Counter;
        public short[] _qualifiers = new short[8];

        public ObjectCommon(ObjectInfo parent) { this.Parent = parent; }
        public override void Read(ByteReader reader)
        {
            var currentPosition = reader.Tell();
            if (Settings.Build >= 284&&Settings.gameType==Settings.GameType.NORMAL)
            {
                var size = reader.ReadInt32();
                _animationsOffset = reader.ReadInt16();
                _movementsOffset = reader.ReadInt16();
                var version = reader.ReadUInt16();
                reader.Skip(2);
                _extensionOffset = reader.ReadInt16();
                _counterOffset = reader.ReadInt16();
                Flags.flag = reader.ReadUInt16();
                var penisFlags = reader.ReadInt16();
                if (penisFlags == 6) Flags["DoNotCreateAtStart"] = true;


                var end = reader.Tell() + 8 * 2;
                for (int i = 0; i < 8; i++)
                {
                    _qualifiers[i] = reader.ReadInt16();
                }

                reader.Seek(end);

                _systemObjectOffset = reader.ReadInt16();

                _valuesOffset = reader.ReadInt16();
                _stringsOffset = reader.ReadInt16();
                NewFlags.flag = reader.ReadUInt16();
                Preferences.flag = reader.ReadUInt16();
                Identifier = reader.ReadAscii(4);
                BackColor = reader.ReadColor();
                _fadeinOffset = reader.ReadUInt32();
                _fadeoutOffset = reader.ReadUInt32();
            }
            else if(Settings.gameType==Settings.GameType.NORMAL)
            {
                var size = reader.ReadInt32();
                _movementsOffset = reader.ReadInt16();
                _animationsOffset = reader.ReadInt16();
                var version = reader.ReadInt16();
                _counterOffset = reader.ReadInt16();
                _systemObjectOffset = reader.ReadInt16();
                reader.Skip(1);
                _subAppOffset = reader.ReadInt16();
                Flags.flag = reader.ReadUInt16();
                var penisFlags = reader.ReadInt16();
                //reader.Skip(2);
                if (penisFlags == 6) Flags["DoNotCreateAtStart"] = true;
                var end = reader.Tell() + 8 * 2;
                for (int i = 0; i < 8; i++)
                {
                    _qualifiers[i] = reader.ReadInt16();
                }

                reader.Seek(end);

                _extensionOffset = reader.ReadInt16();

                _valuesOffset = reader.ReadInt16();
                _stringsOffset = reader.ReadInt16();
                NewFlags.flag = reader.ReadUInt16();
                Preferences.flag = reader.ReadUInt16();
                Identifier = reader.ReadAscii(2);
                BackColor = reader.ReadColor();
                _fadeinOffset = reader.ReadUInt32();
                _fadeoutOffset = reader.ReadUInt32();
            }
            else if (Settings.twofiveplus)
            {
                Console.WriteLine("Reading stuff for 2.5+");
                var size = reader.ReadInt32();
                _animationsOffset = reader.ReadInt16();
                _movementsOffset = reader.ReadInt16();
                var version = reader.ReadUInt16();
                reader.Skip(2);
                _extensionOffset = reader.ReadInt16();
                _counterOffset = reader.ReadInt16();
                Flags.flag = reader.ReadUInt16();
                var penisFlags = reader.ReadInt16();
                //reader.Skip(2);
                if (penisFlags == 6) Flags["DoNotCreateAtStart"] = true;
                var end = reader.Tell() + 8 * 2;
                for (int i = 0; i < 8; i++)
                {
                    _qualifiers[i] = reader.ReadInt16();
                }

                reader.Seek(end);
                if (reader.Tell() > reader.Size() - 20)
                {
                    Console.WriteLine("E216: Ran out of bytes reading ObjectCommon (" + reader.Tell() + "/" + reader.Size() + ")");
                    return; //really hacky shit, but it works
                }
                _systemObjectOffset = reader.ReadInt16();

                _valuesOffset = reader.ReadInt16();
                _stringsOffset = reader.ReadInt16();
                NewFlags.flag = reader.ReadUInt16();
                Preferences.flag = reader.ReadUInt16();
                Identifier = reader.ReadAscii(4);
                BackColor = reader.ReadColor();
                _fadeinOffset = reader.ReadUInt32();
                _fadeoutOffset = reader.ReadUInt32();
            }
            else if (Settings.android)
            {
                if (Settings.Build >= 290)
                {
                    
                    var size = reader.ReadInt32();
                    //Console.WriteLine("MY ASS");
                    reader.Skip(-4);
                    reader.ReadBytes(size+4);
                    reader.Skip(-size+4);
                    currentPosition =0;
                    
                    _movementsOffset = reader.ReadInt16();
                    var version = reader.ReadUInt16();
                    _extensionOffset = reader.ReadInt16();
                    _counterOffset = reader.ReadInt16();
                    _valuesOffset = reader.ReadInt16();
                    Flags.flag = reader.ReadUInt16();
                    var penisFlags = reader.ReadInt16();
                    if (penisFlags == 6) Flags["DoNotCreateAtStart"] = true;
                
                    for (int i = 0; i < 8; i++)
                    {
                        _qualifiers[i] = reader.ReadInt16();
                    }
                    _systemObjectOffset = reader.ReadInt16();
                    _animationsOffset = (short)(reader.ReadInt16());
                    reader.Skip(2);
                    _stringsOffset = reader.ReadInt16();
                    NewFlags.flag = reader.ReadUInt32();
                    Preferences.flag = reader.ReadUInt16();
                    Identifier = reader.ReadAscii(4);
                    BackColor = reader.ReadColor();
                    _fadeinOffset = reader.ReadUInt32();
                    _fadeoutOffset = reader.ReadUInt32();

                }
                else if (Settings.Old)
                {
                    var size = reader.ReadUInt16();
                    var checksum = reader.ReadUInt16();
                    _movementsOffset = reader.ReadInt16();
                    _animationsOffset = reader.ReadInt16();
                    var version = reader.ReadUInt16();
                    _counterOffset = reader.ReadInt16();
                    _systemObjectOffset = reader.ReadInt16();
                    var ocVariable = reader.ReadUInt32();
                    Flags.flag = reader.ReadUInt16();
                    
                    var end = reader.Tell() + 8 * 2;
                    for (int i = 0; i < 8; i++)
                    {
                        _qualifiers[i] = reader.ReadInt16();
                    }
                    reader.Seek(end);

                    _extensionOffset = reader.ReadInt16();
                    _valuesOffset = reader.ReadInt16();
                    NewFlags.flag = reader.ReadUInt16();
                    Preferences.flag = reader.ReadUInt16();
                    Identifier = reader.ReadAscii(4);
                    BackColor = reader.ReadColor();
                    _fadeinOffset = reader.ReadUInt32();
                    _fadeoutOffset = reader.ReadUInt32();
                }
                else
                {
                    var size = reader.ReadInt32();
                    //File.WriteAllBytes($"FNAFWorldTest\\{Utils.Utils.ClearName(Parent.name)}.chunk",reader.ReadBytes(size-4));
                    //reader.Skip(-size+4);
                    _movementsOffset = reader.ReadInt16();
                    _animationsOffset = reader.ReadInt16();
                
                    var version = reader.ReadInt16();
                    _counterOffset = reader.ReadInt16();
                    _systemObjectOffset = reader.ReadInt16();
                    _valuesOffset = reader.ReadInt16();
                    Flags.flag = reader.ReadUInt16();
                    var penisFlags = reader.ReadInt16();
                    if (penisFlags == 6) Flags["DoNotCreateAtStart"] = true;
                
                    for (int i = 0; i < 8; i++)
                    {
                        _qualifiers[i] = reader.ReadInt16();
                    }
                    _extensionOffset = reader.ReadInt16();
                    reader.Skip(2);
                    _stringsOffset = reader.ReadInt16();
                    NewFlags.flag = reader.ReadUInt32();
                    Preferences.flag = reader.ReadUInt16();
                    Identifier = reader.ReadAscii(4);
                    BackColor = reader.ReadColor();
                    _fadeinOffset = reader.ReadUInt32();
                    _fadeoutOffset = reader.ReadUInt32();
                }
                //currentPosition = reader.Tell();
                
                
            }
            

            
            if (_animationsOffset > 0)
            {
                //Console.WriteLine("ANIMS FOUND: "+Parent.name);
                reader.Seek(currentPosition + _animationsOffset);
                Animations = new Animations();
                Animations.Read(reader);
            }



            if (_movementsOffset > 0)
            {
                if (Settings.Old)
                {
                    reader.Seek(currentPosition + _movementsOffset);
                    Movements = new Movements();
                    var newMovement = new Movement();
                    newMovement.Read(reader);
                    Movements.Items.Add(newMovement);
                }
                else
                {
                    reader.Seek(currentPosition + _movementsOffset);

                    Movements = new Movements();
                    Movements.Read(reader);
                }
                
                

            }

            if (_systemObjectOffset > 0)
            {
                reader.Seek(currentPosition + _systemObjectOffset);
                switch (Identifier)
                {
                    //Text
                    case "TEXT":
                        Text = new Text();
                        Text.Read(reader);
                        break;
                    //Counter
                    case "CNTR":
                    case "SCORE":
                    case "LIVES":
                        Counters = new Counters();
                        Counters.Read(reader);
                        break;

                }
            }

            if (_extensionOffset > 0)
            {

                    reader.Seek(currentPosition + _extensionOffset);

                    var dataSize = reader.ReadInt32() - 20;
                    reader.Skip(4); //maxSize;
                    ExtensionVersion = reader.ReadInt32();
                    ExtensionId = reader.ReadInt32();
                    ExtensionPrivate = reader.ReadInt32();
                    if (dataSize != 0)
                    {
                        ExtensionData = reader.ReadBytes(dataSize);
                    }
                    else ExtensionData = new byte[0];
              
            }

            if (_counterOffset > 0)
            {
                reader.Seek(currentPosition + _counterOffset);
                Counter = new Counter(reader);
                Counter.Read();
            }

            if (_subAppOffset > 0)
            {
                reader.Seek(currentPosition + _counterOffset);
                SubApplication = new SubApplication(reader);
                SubApplication.Read();
            }
        }

        public override void Write(ByteWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
