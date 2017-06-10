﻿using System;
namespace nethaxide
{
	public class Player : IEntity
	{
		public Player()
		{
			_inv = new Inventory();
		}
	}
}
