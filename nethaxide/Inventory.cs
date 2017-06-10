using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace nethaxide
{
	public class Inventory
	{
		public Inventory()
		{
			_content = new List<ItemStack>(30);
			// ^ by default we have 30 slots
			_capacity = 30;
		}

		public Inventory(int size)
		{
			_content = new List<ItemStack>(size);
			_capacity = size;
		}

		public Inventory(string json){
			_content = 
				JsonConvert.DeserializeObject<List<ItemStack>>(json);
		}

		/// <summary>
		/// Consumes the specified item.
		/// </summary>
		/// <returns>Ture on success, false otherwise.</returns>
		/// <param name="item">Item.</param>
		public bool Consume(Item item)
		{
			foreach (ItemStack i in _content)
			{
				if (item.Equals(i.Item))
				{
					if (i.Consume())
					{
						_content.Remove(i);
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Add the specified item stack.
		/// </summary>
		/// <returns>True on success, false otherwise.</returns>
		/// <param name="item">Item stack.</param>
		public bool Add(ItemStack item)
		{
			// find if such a type of item exists
			foreach (ItemStack i in _content)
			{
				if (i.Item.Equals(item.Item))
				{
					// if found, directly add the number instead of inserting a 
					// new one
					_content.Remove(i);
					_content.Add(item + i);
					return true;
				}
			}
			// insert a new one if not found
			if (_content.Count == _capacity)
			{
				// test if full
				return false;
			}
			_content.Add(item);
			return true;
		}

		/// <summary>
		/// Add the specified one (1) item.
		/// </summary>
		/// <returns>True on success, false otherwise.</returns>
		/// <param name="item">Item.</param>
		public bool Add(Item item)
		{
			foreach (ItemStack i in _content)
			{
				if (i.Item.Equals(item))
				{
					_content.Remove(i);
					_content.Add(i + new ItemStack(item, 1));
					return true;
				}
			}
			if (_content.Count == _capacity)
				return false;
			_content.Add(new ItemStack(item, 1));
			return true;
		}

		public List<ItemStack> Content
		{
			get
			{
				return _content;
			}
		}

		public int Capacity
		{
			get
			{
				return _capacity;
			}

			set
			{
				_capacity = value;
			}
		}

		private int _capacity;
		private List<ItemStack> _content;
	}
}
