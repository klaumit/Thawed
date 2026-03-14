using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CliWrap;
using CliWrap.EventStream;
using Generator.API;

namespace Generator.Extractors
{
    public sealed class WinNiExtractor : WinBaseExtractor, IExtractor, IDisposable
    {
        public int ArgCount { get; set; } = 1000;
        public int Port { get; set; } = 9097;

        private CancellationTokenSource cts = new CancellationTokenSource();

        public override async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var batch in byteArrays.Chunk(ArgCount))
            {
                List<string> dArgs = [_exePath, "-ni", "local", $"{Port}"];

                var _output = Console.Out;

                const string cmd = "wine";
                var dumpCmd = Cli.Wrap(cmd)
                    .WithArguments(dArgs)
                    .WithValidation(CommandResultValidation.None);

                await foreach (var cmdEvent in dumpCmd.ListenAsync(cts.Token))
                {
                    switch (cmdEvent)
                    {
                        case StartedCommandEvent started:
                            await _output.WriteLineAsync($"Process started; ID: {started.ProcessId}");
                            break;
                        case StandardOutputCommandEvent stdOut:
                            await _output.WriteLineAsync($"Out> {stdOut.Text}");
                            break;
                        case StandardErrorCommandEvent stdErr:
                            await _output.WriteLineAsync($"Err> {stdErr.Text}");
                            break;
                        case ExitedCommandEvent exited:
                            await _output.WriteLineAsync($"Process exited; Code: {exited.ExitCode}");
                            break;
                    }
                }

                // throw new InvalidOperationException($"{dumpCmd} ?!");
            }
            yield break;
        }

        public void Dispose()
        {
            Console.WriteLine("1?");
            cts.Cancel();
            Console.WriteLine("2!");
        }
    }
}
