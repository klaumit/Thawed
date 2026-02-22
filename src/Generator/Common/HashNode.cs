using System.Collections.Generic;
using Generator.Meta;

namespace Generator.Common
{
    public sealed class HashNode
    {
        public string? Path { get; set; }

        public string? Hex { get; set; }

        public List<Extracted>? Raw { get; set; }

        public List<HashNode>? Nodes { get; set; }
    }
}