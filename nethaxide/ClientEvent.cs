﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nethaxide
{
	[Serializable]
	struct ClientEvent
	{
		ClientIdentifier identifier;
		ClientEventType type;
		
	}
}