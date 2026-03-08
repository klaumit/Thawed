using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Experimenter.Models;
using Generator.Extractors;
using Generator.Tools;
using Generator.API;
using Iced.Intel;
using static Generator.Tools.FileTool;
using static Generator.Tools.ArgTool;
using static Generator.Tools.JsonTool;
using CF = Iced.Intel.CpuidFeature;
using NDC = Experimenter.Models.NodeC;
using NDS = Experimenter.Models.NodeD;
using IDC = System.Collections.Concurrent.ConcurrentDictionary<string,
    System.Collections.Concurrent.ConcurrentDictionary<Iced.Intel.Code, Experimenter.Models.Example>>;
using IDS = System.Collections.Generic.SortedDictionary<string, 
    System.Collections.Generic.SortedDictionary<Iced.Intel.Code, Experimenter.Models.Example>>;

namespace Experimenter.Core
{
    internal static class TstDump
    {
    }
}