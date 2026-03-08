using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Experimenter.Models;
using Generator.Common;
using Generator.Tools;
using static System.IO.Directory;
using static Generator.Tools.FileTool;

namespace Experimenter.Core
{
    internal static class TstDump
    {
        internal static async Task Run(Options o)
        {
            if (CreateOrGetDir(o.OutputDir) is not { } oD)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            if (CreateOrGetDir(o.InputDir) is not { } iD)
            {
                await Console.Error.WriteLineAsync("No input dir given!");
                return;
            }

            Console.WriteLine($"Input  => {iD}");
            Console.WriteLine($"Output => {oD}");

            await GenerateTest(iD, oD);

            Console.WriteLine("Done.");
        }

        private static async Task GenerateTest(string inDir, string outDir)
        {
            /*{
                Console.WriteLine(JsonTool.ToJson(ReadMyInstr(root)));
                Console.WriteLine(JsonTool.ToJson(ReadIntelInstr(root)));
                Console.WriteLine(JsonTool.ToJson(ReadWinCache(root)));
                Console.WriteLine(JsonTool.ToJson(ReadWinRes(root).Distinct()));
                Console.WriteLine(JsonTool.ToJson(ReadSmplList(root)));
            }*/

            var opG = ReadOpGroups(inDir).GroupBy(x => x.Group)
                .ToDictionary(k => k.Key, v => v.Distinct().ToArray());
            var opN = ReadOpNames(inDir)
                .ToDictionary(k => k.Op, v => v.Desc);
            var opB = ReadBinResults(inDir).Concat(ReadHexResults(inDir)
                    .Select(x => new OpBin(HexToBin(x.Hex), x.Op)))
                .Select(ToMyInstr).GroupBy(x => x.Op)
                .ToDictionary(k => k.Key, v => v.Distinct().ToArray());

            var w = new CodeWriter();
            await w.WriteLineAsync("using Xunit;");
            await w.WriteLineAsync();
            await w.WriteLineAsync("// ReSharper disable IdentifierTypo");
            await w.WriteLineAsync();
            await w.WriteLineAsync("namespace Thawed.UnitTests.Auto");
            await w.WriteLineAsync("{");
            var first1 = true;
            foreach (var (groupName, groupList) in opG.OrderBy(x => x.Key))
            {
                if (first1)
                    first1 = false;
                else
                    await w.WriteLineAsync();
                await w.WriteLineAsync($"public class {groupName}Test : AbstractDecodeTest");
                await w.WriteLineAsync("{");
                var first2 = true;
                foreach (var g in groupList.OrderBy(x => x.Op))
                {
                    if (first2)
                        first2 = false;
                    else
                        await w.WriteLineAsync();
                    var opCode = g.Op;
                    var opTitle = opCode.Title();
                    var opLong = opN[opCode];
                    await w.WriteLineAsync("/// <summary>");
                    await w.WriteLineAsync($"/// {opLong}");
                    await w.WriteLineAsync("/// </summary>");
                    await w.WriteLineAsync("[Theory]");
                    if (opB.TryGetValue(opCode, out var opBl) && opBl.Length >= 1)
                    {
                        foreach (var (oh, oo, oa) in opBl.OrderBy(x => x.Hex.Length)
                                     .ThenBy(x => x.Hex))
                        {
                            await w.WriteLineAsync($"[InlineData(\"{oh}\", \"{oo}\", \"{oa}\")]");
                        }
                    }
                    await w.WriteLineAsync($"public void Check{opTitle}(string bin, string op, string arg)");
                    await w.WriteLineAsync("{");
                    await w.WriteLineAsync("AssertDecode(bin, op, arg);");
                    await w.WriteLineAsync("}");
                }
                await w.WriteLineAsync("}");
            }
            await w.WriteLineAsync("}");

            var tstF = Path.Combine(outDir, "BigTest.cs");
            await File.WriteAllTextAsync(tstF, w.ToString(), Encoding.UTF8);
            Console.WriteLine($"Generated '{Path.GetFileNameWithoutExtension(tstF)}'!");
        }

        private static MyInstrR ToMyInstr(OpBin x)
        {
            var pt = x.Op.Split(' ', 2);
            return new MyInstrR(x.Bin, pt[0].Trim(), pt.Length == 2 ? pt[1].Trim() : "");
        }

        private static string HexToBin(string hex)
        {
            var bytes = Convert.FromHexString(hex);
            return bytes.Format('b', " ");
        }

        private const SearchOption So = SearchOption.AllDirectories;

        internal static IEnumerable<MyInstrR> ReadWinRes(string r)
        {
            var file = EnumerateFiles(r, "Win.csv", So).First();
            var array = CsvTool.FromFile<WinInstr>(file);
            foreach (var m in array)
            {
                if (m.Op is not { } op || m.Hex is not { } hex)
                    continue;
                if (m.Offset != "00000")
                    continue;
                var arg = m.Arg ?? "";
                if (op.Contains("CMPS"))
                    yield return new MyInstrR(hex, op, arg);
            }
        }

        internal static IEnumerable<SampleR> ReadSmplList(string r)
        {
            var file = EnumerateFiles(r, "smpl_list.json", So).First();
            var dict = JsonTool.FromFile<SortedDictionary<string, SortedDictionary<string, Sample>>>(file);
            foreach (var (key1, val1) in dict ?? [])
            foreach (var (key2, val2) in val1)
            {
                if (val2.M.Contains("CMPS"))
                    yield return new SampleR(key1, key2, val2.C, val2.H, val2.M, val2.A);
            }
        }

        internal static IEnumerable<MyInstrR> ReadWinCache(string r)
        {
            var file = EnumerateFiles(r, "cache_Win.json", So).First();
            var dict = JsonTool.FromFile<SortedDictionary<string, Cached>>(file);
            foreach (var (_, val) in dict ?? [])
            {
                if (val.O != 0)
                    continue;
                if (val.H.TrimOrNull() is not { } hex || val.D.TrimOrNull() is not { } tx)
                    continue;
                var pt = tx.Split(' ', 2);
                if (pt[0].TrimOrNull() is not { } op)
                    continue;
                var arg = pt.Length == 2 ? pt[1].TrimOrNull() ?? "" : "";
                if (op.Contains("CMPS"))
                    yield return new MyInstrR(hex, op, arg);
            }
        }

        internal static IEnumerable<OpHex> ReadHexResults(string r)
        {
            var file = EnumerateFiles(r, "hex_results.json", So).First();
            var dict = JsonTool.FromFile<SortedDictionary<string, string>>(file);
            foreach (var (key, val) in dict ?? [])
            {
                yield return new OpHex(key, val);
            }
        }

        internal static IEnumerable<OpBin> ReadBinResults(string r)
        {
            var file = EnumerateFiles(r, "bin_results.json", So).First();
            var dict = JsonTool.FromFile<SortedDictionary<string, string>>(file);
            foreach (var (key, val) in dict ?? [])
            {
                yield return new OpBin(key, val);
            }
        }

        internal static IEnumerable<OpName> ReadOpNames(string r)
        {
            var file = EnumerateFiles(r, "opCodeNames.json", So).First();
            var dict = JsonTool.FromFile<SortedDictionary<string, string>>(file);
            foreach (var (key, val) in dict ?? [])
            {
                yield return new OpName(key, val);
            }
        }

        internal static IEnumerable<OpGroup> ReadOpGroups(string r)
        {
            var file = EnumerateFiles(r, "opCodeGroups.json", So).First();
            var dict = JsonTool.FromFile<SortedDictionary<string, string[]>>(file);
            foreach (var (key, val) in dict ?? [])
            {
                yield return new OpGroup(key, val.Last());
            }
        }

        internal static IEnumerable<IntelInstr> ReadIntelInstr(string r)
        {
            var file = EnumerateFiles(r, "Intel_Instructions.csv", So).First();
            var array = CsvTool.FromFile<IntelInstr>(file);
            foreach (var m in array)
            {
                if (m.Format is not { } fmt)
                    continue;
                if (fmt.Contains("CMPS"))
                    yield return m;
            }
        }

        internal static IEnumerable<MyInstrR> ReadMyInstr(string r)
        {
            var file = EnumerateFiles(r, "My_Instructions.csv", So).First();
            var array = CsvTool.FromFile<MyInstr>(file);
            foreach (var m in array)
            {
                if (m.Hex.TrimOrNull() is not { } hex || m.Op.TrimOrNull() is not { } op)
                    continue;
                var arg = m.Args.TrimOrNull() ?? "";
                if (op.Contains("CMPS"))
                    yield return new MyInstrR(hex, op, arg);
            }
        }
    }
}