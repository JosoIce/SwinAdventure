using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void TestFindItem()
        {
            var result = false;
            Inventory inventory = new Inventory();
            int itemsPassed = 0;
            for (int i = 0; i < 5; i++)
            {
                inventory.Put(new Item(new string[] { "item" + i.ToString() }, "name" + i.ToString(), "desc" + i.ToString()));
            }

            for (int i = 0; i < 5; i++)
            {
                if (inventory.HasItem("item" + i.ToString()))
                {
                    itemsPassed++;
                }
            }

            if (itemsPassed == 5)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestNoFindItem()
        {
            var result = false;
            Inventory inventory = new Inventory();
            int itemsPassed = 0;
            for (int i = 0; i < 5; i++)
            {
                inventory.Put(new Item(new string[] { "item" + i.ToString() }, "name" + i.ToString(), "desc" + i.ToString()));
            }

            for (int i = 0; i < 5; i++)
            {
                if (!inventory.HasItem("item"))
                {
                    itemsPassed++;
                }
            }

            if (itemsPassed == 5)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestFetchItem()
        {
            var result = false;
            Item item = new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing");
            Inventory inventory = new Inventory();
            inventory.Put(item);
            Item fetched = inventory.Fetch("sword");

            if (item == fetched)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestTakeItem()
        {
            var result = false;
            Item item = new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing");
            Inventory inventory = new Inventory();
            inventory.Put(item);
            inventory.Take("sword");

            if (!inventory.HasItem("sword")) result = true;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestItemList()
        {
            Inventory inventory = new Inventory();
            inventory.Put(new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing"));
            inventory.Put(new Item(new string[] { "bow" }, "Bow", "Ranged Weapon"));
            inventory.Put(new Item(new string[] { "axe" }, "Axe", "And my Axe!"));

            string expected = "\tSword (sword)\n" + "\tBow (bow)\n" + "\tAxe (axe)\n";

            Assert.AreEqual(inventory.ItemList, expected);
        }
    }
}
