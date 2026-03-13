using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using IP = System.Net.IPAddress;

namespace Unasmsys.Core
{
	internal static class Serv
	{
		private static TcpListener _listener = null!;
		private static readonly CancellationTokenSource Cts = new();

		public static IEnumerable<IExFile> ReadArgsByNetwork(TextWriter con, string[] args)
		{
			if (args.Length != 2)
				throw new InvalidOperationException("Server needs host and port!");

			var host = args[0];
			var addr = host switch { "any" => IP.Any, "local" => IP.Loopback, _ => IP.Parse(args[0]) };
			var port = int.Parse(args[1]);
			_listener = new TcpListener(addr, port);

			_listener.Start();
			con.WriteLine($"Server listening on {_listener.LocalEndpoint} ...");

			return ReadArgsByNet(con);
		}

		private static IEnumerable<IExFile> ReadArgsByNet(TextWriter con)
		{
			while (!Cts.IsCancellationRequested)
			{
				var client = _listener.AcceptTcpClient();
				foreach (var item in ReadArgsByNet(con, client))
					yield return item;
			}
			_listener.Stop();
		}

		private static IEnumerable<IExFile> ReadArgsByNet(TextWriter con, TcpClient tcp)
		{
			var endpoint = tcp.Client.RemoteEndPoint;
			con.WriteLine($"Client connected => {endpoint}");

			using var stream = tcp.GetStream();
			using var reader = new StreamReader(stream);
			using var writer = new StreamWriter(stream);

			var preamble = reader.TakeWhile(l => !string.IsNullOrWhiteSpace(l)).ToArray();
			const string tmp = "Content-Length:";
			var lenTxt = preamble.FirstOrDefault(p => p.StartsWith(tmp))?.Split(tmp, 2).Last();
			_ = int.TryParse(lenTxt, out var len);

			var content = reader.ReadStr(len).Split('=', 2);
			var mode = content[0];
			var arg = content[1];
			var nl = Environment.NewLine;
			using var fake = new StringReader($"{mode} {arg}{nl}{nl}");

			writer.WriteLine("HTTP/1.1 200 OK");
			writer.WriteLine();

			foreach (var file in writer.Wrap(Pipes.ReadArgsByInput(fake)))
				yield return file;
		}
	}
}