using System;
using Generator.Tools;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Generator.Extractors;
using Generator.API;
using Iced.Intel;
using System;
using System.Threading.Tasks;
using Generator.Tools;
using System.Collections.Generic;
using System.Linq;
using Generator.Meta;
using System.IO;
using System.Reflection;
using System.Text;
using Iced.Intel;
using System.Threading.Tasks;
using CodeWriter = Generator.Common.CodeWriter;
using static Generator.Tools.FileTool;

namespace Generator.Core
{
    internal static class CodeDump
    {
        internal static async Task Run(Options o)
        {
            if (CreateOrGetDir(o.OutputDir) is not { } outDir)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            if (CreateOrGetDir(o.InputDir) is not { } inpDir)
            {
                await Console.Error.WriteLineAsync("No input dir given!");
                return;
            }

            await GenerateEnum(outDir);
            
            Console.WriteLine("Done.");
        }

        private static async Task GenerateEnum(string outDir)
        {
            var w = new CodeWriter();
            await w.WriteLineAsync("using System;");
            await w.WriteLineAsync();
            await w.WriteLineAsync("namespace Generator.Extractors");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("public static class Opcode");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");

            var fuzF = Path.Combine(outDir, "Opcode.cs");
            await File.WriteAllTextAsync(fuzF, w.ToString(), Encoding.UTF8);

            
            
            
            
            
            /*
             
             using System.Collections.Generic;
               using D = SuperHot.Dialect;
               using O = SuperHot.OpMeta;
               
               // ReSharper disable InconsistentNaming
               // ReSharper disable IdentifierTypo
               
               namespace SuperHot.Auto
               {
               	public enum Opcode
               	{
               		None = 0,
               
               		/// <summary>
               		/// Add binary
               		/// <remarks>Arithmetic</remarks>
               		/// </summary>
               		[O([D.Sh,D.Sh2,D.Sh2a,D.Sh2e,D.Sh3,D.Sh3e,D.Sh4,D.Sh4a], 2, "#0,r0", "#-100,r10")]
               		Add,
               
               
               
             
             
             
             * public static class OpcodeExt
               {
               		public static string ToName(this Opcode code) => _names[code];
               
               public static class OpcodeExt
               {
               	public static string ToName(this Opcode code) => _names[code];

               	private static readonly Dictionary<Opcode, string> _names = new()
               	{
               		{ Opcode.Add, "add" },
               		{ Opcode.Addc, "addc" },
               		{ Opcode.Addv, "addv" },
               		{ Opcode.And, "and" },
               
             */


            
        }
    }
}