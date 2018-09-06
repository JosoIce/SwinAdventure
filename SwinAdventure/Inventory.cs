using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (Item i in _items)
            {
                if (i.FirstId == id) { return true;}
            }

            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    Item tempItem = i;
                    _items.Remove(i);
                    return tempItem;
                }
            }

            return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id)) return i;
            }

            return null;
        }

        public string ItemList
        {
            get
            {
                string itemOutput = "";
                foreach (Item i in _items)
                {
                    itemOutput += "     " + i.ShortDescription + "\n";
                }
                return itemOutput;
            }
        }
    }
}
