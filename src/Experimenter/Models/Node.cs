using System.Collections.Generic;

namespace Experimenter.Models
{
    internal record Node
    {
        public string? H { get; set; }
        public Example? D { get; set; }
        public List<Node>? S { get; set; }
    }
}