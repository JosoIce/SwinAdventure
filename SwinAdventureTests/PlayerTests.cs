using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestPlayerIdentifiable()
        {
            Player player = new Player("Bob", "Top Lad");
            Assert.IsTrue(player.AreYou("me") && player.AreYou("inventory"));
        }

        [TestMethod]
        public void TestPlayerLocatesItems()
        {
            var result = false;
            Player player = new Player("Bob", "Top Lad");
            Item item = new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing");
            player.Inventory.Put(item);
            var newItem = player.Locate("sword");
            if (item == newItem)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPlayerLocatesItself()
        {
            Player player = new Player("Bob", "Top Lad");
            var meTest = player.Locate("me");
            var invTest = player.Locate("inventory");
            var result = false;

            if (meTest == player|| invTest == player)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPlayerLocatesNothing()
        {
            Player player = new Player("Bob", "Top Lad");
            var result = player.Locate("Bow");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestPlayerFullDescription()
        {
            Player player = new Player("Bob", "Top Lad");
            player.Inventory.Put(new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing"));
            player.Inventory.Put(new Item(new string[] { "bow" }, "Bow", "Ranged Weapon"));
            player.Inventory.Put(new Item(new string[] { "axe" }, "Axe", "And my Axe!"));

            string inventory = "You are carrying:\n" + "     Sword (sword)\n" + "     Bow (bow)\n" + "     Axe (axe)\n";

            Assert.AreEqual(player.FullDescription, inventory);
        }
    }
}
