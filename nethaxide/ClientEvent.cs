using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nethaxide
{
	[Serializable]
	struct ClientEvent
	{
		public ClientEvent(ClientIdentifier identifier, ClientEventType type)
		{
			_identifier = identifier;
			_type = type;

		}

		public override string ToString()
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(this);
		}

		public ClientIdentifier Identifier
		{
			get
			{
				return _identifier;
			}
		}

		public ClientEventType Type
		{
			get
			{
				return _type;
			}
		}
		
		private ClientIdentifier _identifier;
		private ClientEventType _type;

	}
}
