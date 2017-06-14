﻿using System;
namespace nethaxide
{
	public class Player : IEntity
	{
		public Player(string name)
		{
			_name = name;
			// then consult player database to create this entity
		}
	}
}
