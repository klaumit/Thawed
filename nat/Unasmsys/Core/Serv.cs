using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using IP = System.Net.IPAddress;

namespace Unasmsys.Core
{
	internal static class Serv
	{
		private static TcpListener _listener;
		private static CancellationTokenSource _cts = new();

		public static (TextWriter w, IEnumerable<IFile> f) ReadArgsByNetwork(TextWriter con, string[] args)
		{
			if (args.Length != 2)
			{
				throw new InvalidOperationException("Server needs host and port!");
			}
			var host = args[0];
			var addr = host switch { "any" => IP.Any, "local" => IP.Loopback, _ => IP.Parse(args[0]) };
			var port = int.Parse(args[1]);
			_listener = new TcpListener(addr, port);
			_listener.Start();
			con.WriteLine($"Server listening on {_listener.LocalEndpoint} ...");
			var w = new StringWriter();
			return (w, ReadArgsByNet(con));
		}

		private static IEnumerable<IFile> ReadArgsByNet(TextWriter con)
		{
			while (!_cts.IsCancellationRequested)
			{
				var client = _listener.AcceptTcpClient();
				Task.Run(() => ReadArgsByNet(con, client));
			}
			_listener.Stop();
			yield break;
		}

		private static void ReadArgsByNet(TextWriter con, TcpClient tcp)
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

			var content = reader.ReadStr(len).Split('=',2);
			var mode = content[0];
			var arg = content[1];
			var nl = Environment.NewLine;
			using var fake = new StringReader($"{mode} {arg}{nl}{nl}");

			writer.WriteLine("HTTP/1.1 200 OK");
			writer.WriteLine();
			writer.Flush();

			foreach (var file in Pipes.ReadArgsByInput(fake))
			{
				Console.WriteLine(" ? " + file + " / " + file.Name + " / " + file.Bytes.Length);

				;
			}

			;
		}
	}
}