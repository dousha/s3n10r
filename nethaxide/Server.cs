using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace nethaxide
{
	class Server
	{
		public Server()
		{
			_listener = new TcpListener(new IPAddress(new byte[]{0x0, 0x0, 0x0, 0x0}), 25565);
		}

		public void Start()
		{
			Thread acceptor = new Thread(AcceptConnection);
			Thread pooler = new Thread(Pool);
			acceptor.Start();
			pooler.Start();
		}

		public void Stop()
		{
			foreach (TcpClient client in _clients) 
			{
				client.Close();
			}
		}

		private void AcceptConnection()
		{
			TcpClient curClient = null;
			for(;;)
			{
				Thread.Sleep(1000);
				curClient = _listener.AcceptTcpClient();
				Console.WriteLine(string.Format("Connection in : {0}", curClient.ToString()));
				_clients.Add(curClient);
			}
		}

		private void DropConnection()
		{

		}

		private void Pool()
		{
			if (_clients.Count == 0)
			{
				Thread.Sleep(1000);
			}
			foreach (TcpClient client in _clients)
			{
				client.ReceiveTimeout = 2000;

			}
		}

		private TcpListener _listener;
		private List<TcpClient> _clients;
	}
}
