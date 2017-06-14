using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace nethaxide
{
	class Client
	{
		public Client(string name)
		{
			// [DBG]
			_ident = new ClientIdentifier(name, "127.0.0.1");
			Connect();
		}

		public void Connect()
		{
			// [DBG]
			try
			{
				IPAddress ip = IPAddress.Parse("127.0.0.1");
				_client = new TcpClient();
				_client.Connect(ip, 25566);
				Thread.Sleep(1000);
				if (_client != null)
				{
					_stream = _client.GetStream();
					_stream.ReadTimeout = 2000;
					_stream.WriteTimeout = 2000;
					BinaryWriter writer = new BinaryWriter(_stream);
					writer.Write(_ident.ToString());
					writer.Flush();
				}
			}
			catch (Exception ex)
			{
				if (_client != null)
				{
					_client.Close();
				}

				if (_stream != null)
				{
					_stream.Close();
				}

				Console.WriteLine("[Client] X");
				Console.WriteLine(ex.ToString());
			}
		}

		private TcpClient _client;
		private ClientIdentifier _ident;
		private NetworkStream _stream;
	}
}
