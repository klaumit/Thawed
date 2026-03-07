using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Experimenter.Models
{
    internal record NodeC
    {
        public string? H { get; set; }
        public Example? D { get; set; }
        public ConcurrentBag<NodeC>? S { get; set; }
    }

    internal record NodeD
    {
        public string? H { get; set; }
        public Example? D { get; set; }
        public List<NodeD>? S { get; set; }
    }
}