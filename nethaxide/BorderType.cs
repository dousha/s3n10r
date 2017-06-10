using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nethaxide
{
	[Flags]
	enum BorderType
	{
		NONE = 0,
		TOP = 0x1,
		LEFT = 0x2,
		RIGHT = 0x4,
		BOTTOM = 0x8
	}
}
