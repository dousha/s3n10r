using System;
using Newtonsoft.Json;
namespace nethaxide
{
	public struct Item
	{
		public Item(string json)
		{
			Item i = JsonConvert.DeserializeObject<Item>(json);
			_name = i.Name;
			_lore = i.Lore;
			_type = i.Type;
		}

		public string Serialize(){
			return JsonConvert.SerializeObject(this);
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public string Lore
		{
			get
			{
				return _lore;
			}
		}

		public ItemType Type
		{
			get
			{
				return _type;
			}
		}

		private string _name;
		private string _lore;
		private ItemType _type;

	}
}
