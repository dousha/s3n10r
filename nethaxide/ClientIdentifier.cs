using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace nethaxide
{
	[Serializable]
	struct ClientIdentifier
	{
		public ClientIdentifier(string name, string ip)
		{
			// [DBG]
			_name = name;
			_ip = ip;
			_token = "token-debug-abcd-0000-abcd-abadcafe";
		}

		public override string ToString()
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(this);
		}

		public string Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		public string IP
		{
			get
			{
				return _ip;
			}

			set
			{
				_ip = value;
			}
		}

		public string Token
		{
			get
			{
				return _token;
			}

			set
			{
				_token = value;
			}
		}

		private string _name;
		private string _ip;
		private string _token;
	}
}
