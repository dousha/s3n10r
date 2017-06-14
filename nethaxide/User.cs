using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace nethaxide
{
	/// <summary>
	/// User is the server-side data representation of <see cref="Client"/>s.
	/// </summary>
	struct User
	{
		public User(TcpClient client, ClientIdentifier ident)
		{
			_client = client;
			_ident = ident;
		}

		public TcpClient Client
		{
			get
			{
				return _client;
			}
		}

		public ClientIdentifier Identifier
		{
			get
			{
				return _ident;
			}
		}

		private TcpClient _client;
		private ClientIdentifier _ident;
	}
}
