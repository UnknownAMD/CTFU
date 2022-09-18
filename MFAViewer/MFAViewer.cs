using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CTFAK.CCN;
using CTFAK.CCN.Chunks.Frame;
using CTFAK.CCN.Chunks.Objects;
using CTFAK.FileReaders;
using CTFAK.Memory;
using CTFAK.MFA;
using CTFAK.Tools;
using Action = CTFAK.CCN.Chunks.Frame.Action;

namespace MFAViewer
{
    public class MFAViewer : IFusionTool
    {
        public string Name => "MFA Viewer";

        public void Execute(IFileReader reader)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("MFA Viewer v1.0");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("by lily snow :3");
            Console.WriteLine("made for MemzDev");
            Console.WriteLine();
            Console.WriteLine();

            var game = reader.getGameData();
            GameData gameData = reader.getGameData();
            var frameCount = 0;

            foreach (var framer in game.frames)
            {
                frameCount++;
                Console.WriteLine(frameCount + ". " + framer.name);
            }
            string str = Console.ReadLine();
            var frame = game.frames[Convert.ToInt32(str) - 1];
            Console.WriteLine("Title: " + frame.name);
            foreach(ObjectInstance obj in frame.objects)
            {
                try
                {
                    Console.WriteLine($"Object name: {game.frameitems[obj.objectInfo - 1].name}, Object type: {game.frameitems[obj.objectInfo - 1].ObjectType}, X: {obj.x}, Y: {obj.y}, Layer: {obj.layer}");
                }
                catch(Exception)
                {
                    Console.WriteLine($"Object name: UNKNOWN, Object type: {game.frameitems[obj.objectInfo - 1].ObjectType}, X: {obj.x}, Y: {obj.y}, Layer: {obj.layer}");
                }
            }
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
            Execute(reader);
        }
    }
}
