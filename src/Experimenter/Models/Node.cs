using System.Collections.Concurrent;

namespace Experimenter.Models
{
    internal record Node
    {
        public string? H { get; set; }
        public Example? D { get; set; }
        public ConcurrentBag<Node>? S { get; set; }
    }
}