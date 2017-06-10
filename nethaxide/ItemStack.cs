using System;
namespace nethaxide
{
	public struct ItemStack
	{
		public ItemStack(Item item, int count)
		{
			_item = item;
			_count = count;
		}

		public ItemStack(ItemStack item)
		{
			_item = item.Item;
			_count = item.Count;
		}

		public bool Consume()
		{
			_count--;
			return _count == 0;
		}

		public static ItemStack operator + (ItemStack i1, ItemStack i2)
		{
			if (!i1.Item.Equals(i2.Item))
				throw new ArgumentException("Cannot add different items");
			return new ItemStack(i1.Item, i1.Count + i2.Count);
		}

		public Item Item
		{
			get
			{
				return _item;
			}
		}

		public int Count
		{
			get
			{
				return _count;
			}

			set
			{
				_count = value;
			}
		}

		private Item _item;
		private int _count;
	}
}
