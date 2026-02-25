using System.IO;
using System.Xml;
using System.Xml.Serialization;
using x86refLib.Xml;

namespace x86refLib
{
    public static class RefX86
    {
        private static readonly XmlSerializer Serializer = new(typeof(x86reference));

        public static x86reference LoadFile(string file)
        {
            using var stream = File.OpenRead(file);
            var cfg = new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore };
            using var reader = XmlReader.Create(stream, cfg);
            var obj = Serializer.Deserialize(reader)!;
            return (x86reference)obj;
        }

        public static void SaveFile(x86reference obj, string file)
        {
            using var stream = File.Create(file);
            var cfg = new XmlWriterSettings { NewLineChars = "\n", Indent = true };
            using var writer = XmlWriter.Create(stream, cfg);
            Serializer.Serialize(writer, obj);
        }
    }
}