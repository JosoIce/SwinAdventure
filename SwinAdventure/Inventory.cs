using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {

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

        }

        public Item Fetch(string id)
        {

        }

        public string ItemList
        {
            get
            {
                string itemOutput = "";
                foreach (Item i in _items)
                {
                    itemOutput += i.ShortDescription + "\n";
                }
                return itemOutput;
            }
        }
    }
}
