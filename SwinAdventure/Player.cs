using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    class Player : GameObject
    {
        private Inventory _inventory;

        public Player(string name, string desc) : base (new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            
        }

        public override string FullDescription
        {
            get
            {
                return "You are carrying:\n" + _inventory.ItemList;
            }
        }
    }
}
