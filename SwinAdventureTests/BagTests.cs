using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestClass]
    public class BagTests
    {
        [TestMethod]
        public void TestBagLocatesItems()
        {
            var result = false;
            Item item = new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing");
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "Stores Things");
            bag.Inventory.Put(item);
            var newItem = bag.Locate("sword");
            if (item == newItem)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestBagLocatesItself()
        {
            var result = false;
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "Stores Things");
            var testLocate = bag.Locate("bag");
            if (bag == testLocate) result = true;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestBagLocatesNothing()
        {
            Item item = new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing");
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "Stores Things");
            bag.Inventory.Put(item);
            var itemTest = bag.Locate("bow");
            Assert.IsNull(itemTest);
        }

        [TestMethod]
        public void TestBagFullDescription()
        {
            Item item = new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing");
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "Stores Things");
            bag.Inventory.Put(item);
            string expected = "In the Bag you see:" + "     Sword (sword)\n";
            Assert.AreEqual(bag.FullDescription, expected);
        }

        [TestMethod]
        public void TestBagInBag()
        {
            Item item1 = new Item(new string[] { "sword1" }, "Sword1", "Sharp, for stabbing");
            Bag bag1 = new Bag(new string[] { "bag1" }, "Bag1", "Stores Things");
            Item item2 = new Item(new string[] { "sword2" }, "Sword2", "Sharp, for stabbing");
            Bag bag2 = new Bag(new string[] { "bag2" }, "Bag2", "Stores Things");
            bag2.Inventory.Put(item2);
            bag1.Inventory.Put(bag2);
            bag1.Inventory.Put(item2);
            var result = false;
            if (bag1.Locate("bag2") == bag2) result = true;
            if (bag1.Locate("sword1") == item1) result = true;
            if (bag1.Locate("sword2") != item2) result = true;
            Assert.IsTrue(result);
        }
    }
}
