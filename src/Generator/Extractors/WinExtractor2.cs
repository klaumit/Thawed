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
    public sealed class WinSiExtractor : WinBaseExtractor, IExtractor, IDisposable
    {
        public int ArgCount { get; set; } = 1000;

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
            Console.WriteLine($" {nameof(StartApp)} 1 ");
            List<string> dArgs = [_exePath, "-si"];
            const string cmd = "wine";
            var dumpCmd = Cli.Wrap(cmd)
                .WithArguments(dArgs)
                .WithValidation(CommandResultValidation.None)
                .WithStandardInputPipe(PipeSource.Create(OnInput))
                .WithStandardOutputPipe(PipeTarget.Create(OnOutput))
                .WithStandardErrorPipe(PipeTarget.Create(OnError));
            Console.WriteLine($" {nameof(StartApp)} 2 ");
            var dumpTask = dumpCmd.ExecuteAsync(_cts.Token);
            Console.WriteLine(
                $" {nameof(StartApp)} 3 {dumpTask.Task.Result.ExitTime} {dumpTask.Task.Result.StartTime} ");
            return dumpTask;
        }

        public override async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            Console.WriteLine($" {nameof(Decode)} 1 ");
            if (!_app.IsStarted)
            {
                _app.Start();
                var chArg = await _argChannel.Reader.ReadAsync();
                var chRes = await _resChannel.Reader.ReadAsync();
                Console.WriteLine($" --> '{chArg}' ");
                Console.WriteLine($" --> '{chRes}' ");
            }
            Console.WriteLine($" {nameof(Decode)} 2 ");
            foreach (var batch in byteArrays.Chunk(ArgCount))
            {
                Console.WriteLine($" {nameof(Decode)} 3 ");
                var line = $"h {string.Join(" ", batch.Select(Convert.ToHexString))}";
                _expectedCount = line.Count(' ');
                Console.WriteLine($" {nameof(Decode)} 4 ");
                var writer = _argChannel.Writer;
                Console.WriteLine($" {nameof(Decode)} 5 ");
                await writer.WaitToWriteAsync(_cts.Token);
                Console.WriteLine($" {nameof(Decode)} 6 ");
                await writer.WriteAsync(line, _cts.Token);
                Console.WriteLine($" {nameof(Decode)} 7 ");
                var stdOut = await _resChannel.Reader.ReadAsync(_cts.Token);
                Console.WriteLine($" {nameof(Decode)} 8 ");
                var parsed = ParseWinOutput(stdOut, batch);
                Console.WriteLine($" {nameof(Decode)} 9 ");
                foreach (var item in parsed)
                {
                    Console.WriteLine($" {nameof(Decode)} 10 ");
                    yield return item;
                }
                Console.WriteLine($" {nameof(Decode)} 11 ");
            }
            Console.WriteLine($" {nameof(Decode)} 12 ");
        }

        private void OnError(Stream stream)
        {
            using var reader = new StreamReader(stream);
            while (reader.ReadLine() is { } line)
            {
                Console.WriteLine($" {nameof(OnError)} '{line}'");
            }
        }

        private async Task OnOutput(Stream stream, CancellationToken t)
        {
            const string tmp = "   [ ";

            Console.WriteLine($" {nameof(OnOutput)} {stream} begin ");

            var reader = new StreamReader(stream);

            Console.WriteLine($" {nameof(OnOutput)} {reader} {_resChannel.Writer} begin ");

            await _resChannel.Writer.WriteAsync(" OUT READY ", t);

            while (!reader.EndOfStream)
            {
                Console.WriteLine($" {nameof(OnOutput)} line begin ");

                try
                {
                    Console.WriteLine($" {nameof(OnOutput)} {stream.CanRead} {stream.CanSeek} " +
                                      $"{stream.CanWrite}  ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                var count = 0;
                var empty = 0;
                var bld = new StringBuilder();
                Console.WriteLine($" {nameof(OnOutput)} << '{bld}' ");
                while (!reader.EndOfStream && await reader.ReadLineAsync(t) is { } line)
                {
                    if (line.Contains(tmp))
                    {
                        empty = 0;
                        count++;
                    }
                    if (line.Length == 0) empty++;
                    Console.WriteLine($" {nameof(OnOutput)} <<< '{line}' ({count} | {empty}) ");
                    bld.AppendLine(line);
                    if (count == _expectedCount && empty >= 2)
                    {
                        _expectedCount = -1;
                        break;
                    }
                }
                Console.WriteLine($" {nameof(OnOutput)} <<<< '{bld}' ");
                var stdOut = bld.ToString();

                Console.WriteLine($" {nameof(OnOutput)} '{stdOut}' ");

                await _resChannel.Writer.WaitToWriteAsync(t);
                await _resChannel.Writer.WriteAsync(stdOut, t);

                Console.WriteLine($" {nameof(OnOutput)} line end ");
            }

            Console.WriteLine($" {nameof(OnOutput)} {reader} {_resChannel.Writer} begin ");

            Console.WriteLine($" {nameof(OnOutput)} {stream} end ");
        }

        private async Task OnInput(Stream stream, CancellationToken t)
        {
            Console.WriteLine($" {nameof(OnInput)} {stream} begin ");

            var writer = new StreamWriter(stream);

            Console.WriteLine($" {nameof(OnInput)} {_argChannel.Reader} {writer} begin ");

            await _argChannel.Writer.WriteAsync(" IN READY ", t);

            await foreach (var line in _argChannel.Reader.ReadAllAsync(t))
            {
                Console.WriteLine($" {nameof(OnInput)} '{line}' ");

                try
                {
                    Console.WriteLine($" {nameof(OnInput)} {stream.CanRead} {stream.CanSeek} " +
                                      $"{stream.CanWrite}  ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                await writer.WriteLineAsync(line);
                await writer.FlushAsync(t);

                try
                {
                    Console.WriteLine($" {nameof(OnInput)} {stream.CanRead} {stream.CanSeek} " +
                                      $"{stream.CanWrite}  ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }

            Console.WriteLine($" {nameof(OnInput)} {_argChannel.Reader} {writer} end ");

            Console.WriteLine($" {nameof(OnInput)} {stream} end ");
        }

        public void Dispose()
        {
            Console.WriteLine($" {nameof(Dispose)} begin ");
            using (_cts)
            {
                _argChannel.Writer.Complete();
                _resChannel.Writer.Complete();
                _cts.Cancel();
            }
            Console.WriteLine($" {nameof(Dispose)} end ");
        }
    }
}