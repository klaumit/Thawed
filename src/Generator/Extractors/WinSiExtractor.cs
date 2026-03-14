using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using CliWrap;
using Generator.API;
using Nito.AsyncEx;

namespace Generator.Extractors
{
    public sealed class WinSiExtractor : WinExtractor, IDisposable
    {
        public int ArgCount { get; set; } = 1000;
        public TextWriter Error { get; set; } = Console.Error;

        private readonly CancellationTokenSource _cts;
        private readonly Channel<string> _argChannel;
        private readonly Channel<string> _resChannel;
        private readonly AsyncLazy<CommandTask<CommandResult>> _app;
        private int _expectedCount;

        public WinSiExtractor()
        {
            _cts = new CancellationTokenSource();
            _argChannel = Channel.CreateBounded<string>(1);
            _resChannel = Channel.CreateBounded<string>(1);
            _app = new AsyncLazy<CommandTask<CommandResult>>(() => Task.Factory.StartNew(StartApp));
            _expectedCount = 0;
        }

        private CommandTask<CommandResult> StartApp()
        {
            List<string> dArgs = [ExePath, "-si"];
            const string cmd = "wine";
            var dumpCmd = Cli.Wrap(cmd)
                .WithArguments(dArgs)
                .WithValidation(CommandResultValidation.None)
                .WithStandardInputPipe(PipeSource.Create(OnInput))
                .WithStandardOutputPipe(PipeTarget.Create(OnOutput))
                .WithStandardErrorPipe(PipeTarget.Create(OnError));
            var dumpTask = dumpCmd.ExecuteAsync(_cts.Token);
            return dumpTask;
        }

        private void StopApp()
        {
            if (_argChannel.Writer.TryWrite(string.Empty))
                return;
            Task.Run(async () =>
            {
                await _argChannel.Writer.WaitToWriteAsync(_cts.Token);
                await _argChannel.Writer.WriteAsync(string.Empty);
            });
        }

        public override async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            if (!_app.IsStarted)
            {
                _app.Start();
                _ = await _argChannel.Reader.ReadAsync();
                _ = await _resChannel.Reader.ReadAsync();
            }
            foreach (var batch in byteArrays.Chunk(ArgCount))
            {
                var line = $"h {string.Join(" ", batch.Select(Convert.ToHexString))}";
                _expectedCount = line.Count(' ');
                var writer = _argChannel.Writer;
                await writer.WaitToWriteAsync(_cts.Token);
                await writer.WriteAsync(line, _cts.Token);
                var stdOut = await _resChannel.Reader.ReadAsync(_cts.Token);
                var parsed = ParseWinOutput(stdOut, batch);
                foreach (var item in parsed)
                    yield return item;
            }
        }

        private void OnError(Stream stream)
        {
            using var reader = new StreamReader(stream);
            while (reader.ReadLine() is { } line)
                Error.WriteLine(line);
        }

        private async Task OnOutput(Stream stream, CancellationToken t)
        {
            const string tmp = "   [ ";
            var reader = new StreamReader(stream);
            await _resChannel.Writer.WriteAsync(" OUT READY ", t);
            while (!_cts.IsCancellationRequested)
            {
                var count = 0;
                var empty = 0;
                var bld = new StringBuilder();
                while (await reader.ReadLineAsync(t) is { } line)
                {
                    if (line.Contains(tmp))
                    {
                        empty = 0;
                        count++;
                    }
                    if (line.Length == 0) empty++;
                    bld.AppendLine(line);
                    if (count == _expectedCount && empty >= 2)
                    {
                        _expectedCount = -1;
                        break;
                    }
                }
                var stdOut = bld.ToString();
                await _resChannel.Writer.WaitToWriteAsync(t);
                await _resChannel.Writer.WriteAsync(stdOut, t);
            }
        }

        private async Task OnInput(Stream stream, CancellationToken t)
        {
            var writer = new StreamWriter(stream);
            await _argChannel.Writer.WriteAsync(" IN READY ", t);
            await foreach (var line in _argChannel.Reader.ReadAllAsync(t))
            {
                await writer.WriteLineAsync(line);
                await writer.FlushAsync(t);
            }
        }

        public void Dispose()
        {
            StopApp();
            using (_cts)
            {
                _argChannel.Writer.Complete();
                _resChannel.Writer.Complete();
                _cts.Cancel();
            }
        }
    }
}