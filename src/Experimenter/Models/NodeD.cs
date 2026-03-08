using System.Collections.Generic;

namespace Experimenter.Models
{
    internal record NodeD
    {
        public string? H { get; set; }
        public Example? D { get; set; }
        public List<NodeD>? S { get; set; }
    }
}