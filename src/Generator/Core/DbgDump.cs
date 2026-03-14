using System;
using System.Threading.Tasks;
using Generator.Tools;
using System.Collections.Generic;
using System.Linq;
using Generator.Meta;
using System.IO;
using System.Reflection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Generator.API;
using Generator.Extractors;
using Generator.Tools;
using System.Text;
using Iced.Intel;
using CodeWriter = Generator.Common.CodeWriter;
using static Generator.Tools.FileTool;

namespace Generator.Core
{
    internal static class DbgDump
    {
        internal static async Task Run(Options o)
        {
            IExtractor[] extractors =
            [
                new GnuExtractor(), new IcedExtractor(), new NasmExtractor(),
                new WinFiExtractor(), new WinHiExtractor(),
                new WinSiExtractor(), new WinNiExtractor()
            ];
            var cands = FuzzerX.GetAllCandidates(withNum: false).Take(3).ToArray();
            foreach (var extractor in extractors)
            {
                await foreach (var d in extractor.Decode(cands))
                {
                    var item = d.FirstOrDefault(x => x.O == 0);
                    if (item == null)
                        continue;
                    var json = JsonTool.ToJson(new { e = extractor.GetName(), d = item });
                    Console.WriteLine(json);
                }
            }
            Array.ForEach(extractors, e => (e as IDisposable)?.Dispose());

            Console.WriteLine("Done.");
        }
    }
}