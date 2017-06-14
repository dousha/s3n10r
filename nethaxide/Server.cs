using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace nethaxide
{
	class Server
	{
		public Server()
		{
			_listener = new TcpListener(IPAddress.Parse("0.0.0.0"), 25566);
			_users = new List<User>();
			Start();
		}

		public void Start()
		{
			_acceptor = new Thread(AcceptConnection);
			_pooler = new Thread(Pool);
			_running = true;
			_acceptor.Start();
			_pooler.Start();
		}

		public void Stop()
		{
			
			foreach (User user in _users) 
			{
				user.Client.Close();
				_users.Remove(user);
			}
		}

		private void AcceptConnection()
		{
			_listener.Start();
			for (; ; )
			{
				TcpClient curClient = null;
				Thread.Sleep(1000);
				if (!_running) return;
				try
				{
					curClient = _listener.AcceptTcpClient();
					if (curClient != null)
					{
						// [DBG]
						Console.WriteLine("[Server] Establishing connection...");
						NetworkStream stream = curClient.GetStream();
						stream.ReadTimeout = 2000;
						stream.WriteTimeout = 2000;
						BinaryReader reader = new BinaryReader(stream);
						string data = reader.ReadString();
						ClientIdentifier ident = Newtonsoft.Json.JsonConvert.DeserializeObject<ClientIdentifier>(data);
						User user = new User(curClient, ident);
						_users.Add(user);
						Console.WriteLine(string.Format("[Server] Connected with : {0}", user.Identifier.Name));
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("[Server] X");
					Console.WriteLine(ex.ToString());
				}
			}
		}

		private void DropConnection()
		{

		}

		private void Pool()
		{
			
		}

		private bool _running;
		private TcpListener _listener;
		private List<User> _users;
		private Thread _acceptor;
		private Thread _pooler;
	}
}
