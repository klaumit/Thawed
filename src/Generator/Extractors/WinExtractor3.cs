using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CliWrap;
using Generator.API;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Nito.AsyncEx;

namespace Generator.Extractors
{
    public sealed class WinNiExtractor : WinBaseExtractor, IExtractor, IDisposable
    {
        public int ArgCount { get; set; } = 1000;
        public int Port { get; set; } = 9097;

        private readonly CancellationTokenSource _cts;
        private readonly Lazy<HttpClient> _client;
        private readonly AsyncLazy<CommandTask<CommandResult>> _app;

        public WinNiExtractor()
        {
            _cts = new CancellationTokenSource();
            _client = new Lazy<HttpClient>(CreateClient);
            _app = new AsyncLazy<CommandTask<CommandResult>>(() => Task.Factory.StartNew(StartApp));
        }

        private static HttpClient CreateClient()
        {
            var client = new HttpClient();
            var def = client.DefaultRequestHeaders;
            def.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            def.UserAgent.Add(new ProductInfoHeaderValue("Thawed", "1.0.0"));
            return client;
        }

        private CommandTask<CommandResult> StartApp()
        {
            List<string> dArgs = [_exePath, "-ni", "local", $"{Port}"];
            const string cmd = "wine";
            var dumpCmd = Cli.Wrap(cmd)
                .WithArguments(dArgs)
                .WithValidation(CommandResultValidation.None);
            var dumpTask = dumpCmd.ExecuteAsync(_cts.Token);
            return dumpTask;
        }

        public override async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            if (!_app.IsStarted)
            {
                _app.Start();
            }
            foreach (var batch in byteArrays.Chunk(ArgCount))
            {
                var hexes = string.Join(" ", batch.Select(Convert.ToHexString));
                var line = $"h={hexes}";
                var stdOut = await SendRequest(line);
                var parsed = ParseWinOutput(stdOut, batch);
                foreach (var item in parsed)
                    yield return item;
            }
        }

        private async Task<string> SendRequest(string line)
        {
            const string scheme = "application/x-www-form-urlencoded";
            var content = new StringContent(line, Encoding.UTF8, scheme);
            var url = $"http://localhost:{Port}";
            var res = await _client.Value.PostAsync(url, content, _cts.Token);
            return await res.Content.ReadAsStringAsync(_cts.Token);
        }

        public void Dispose()
        {
            using (_client.Value)
            using (_cts)
                _cts.Cancel();
        }
    }
}