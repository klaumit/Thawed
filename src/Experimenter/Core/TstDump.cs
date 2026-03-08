using System.Collections.Generic;
using System.IO;
using System.Linq;
using Experimenter.Models;
using Generator.Tools;
using static System.IO.Directory;
using System;
using System.Threading.Tasks;
using static Generator.Tools.FileTool;

// ReSharper disable ClassNeverInstantiated.Global

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

            // TODO

            Console.WriteLine("Done.");
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
                if (val.Contains("CMPS"))
                    yield return new OpHex(key, val);
            }
        }

        internal static IEnumerable<OpBin> ReadBinResults(string r)
        {
            var file = EnumerateFiles(r, "bin_results.json", So).First();
            var dict = JsonTool.FromFile<SortedDictionary<string, string>>(file);
            foreach (var (key, val) in dict ?? [])
            {
                if (val.Contains("CMPS"))
                    yield return new OpBin(key, val);
            }
        }

        internal static IEnumerable<OpName> ReadOpNames(string r)
        {
            var file = EnumerateFiles(r, "opCodeNames.json", So).First();
            var dict = JsonTool.FromFile<SortedDictionary<string, string>>(file);
            foreach (var (key, val) in dict ?? [])
            {
                if (key.Contains("CMPS"))
                    yield return new OpName(key, val);
            }
        }

        internal static IEnumerable<OpGroup> ReadOpGroups(string r)
        {
            var file = EnumerateFiles(r, "opCodeGroups.json", So).First();
            var dict = JsonTool.FromFile<SortedDictionary<string, string[]>>(file);
            foreach (var (key, val) in dict ?? [])
            {
                if (val.Length >= 2)
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