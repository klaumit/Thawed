using System.Collections.Concurrent;

namespace Experimenter.Models
{
    internal record NodeC
    {
        public string? H { get; set; }
        public Example? D { get; set; }
        public ConcurrentBag<NodeC>? S { get; set; }
    }
}