using System;
using System.Collections.Generic;
using System.Linq;
using CliWrap;
using Generator.API;

namespace Generator.Extractors
{
    public sealed class WinNiExtractor : WinBaseExtractor, IExtractor, IDisposable
    {
        public int ArgCount { get; set; } = 1000;

        public override async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var batch in byteArrays.Chunk(ArgCount))
            {
                List<string> dArgs = [_exePath, "-ni"];

                const string cmd = "wine";
                var dumpCmd = Cli.Wrap(cmd)
                    .WithArguments(dArgs)
                    .WithValidation(CommandResultValidation.None);

                throw new InvalidOperationException($"{dumpCmd} ?!");
            }
            yield break;
        }

        public void Dispose()
        {
        }
    }
}