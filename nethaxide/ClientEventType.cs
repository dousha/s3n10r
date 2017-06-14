using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nethaxide
{
	enum ClientEventType
	{
		DUMMY = 0,
		LOGIN,
		LOGOUT,
		MOVE, /// player moves
		USE, /// player uses a <see cref="Machine"/>
		CONSUME, /// player uses an <see cref="Item"/>
		EFFECT, /// player applys an <see cref="Effect"/>
		TIMER, /// player starts or cancels a <see cref="Timer"/>
		CHAT /// player talks
	}
}
