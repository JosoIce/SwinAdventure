using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void TestItemIsIdentifiable()
        {
            Item item = new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing");

            var result = item.AreYou("sword");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestShortDescription()
        {
            Item item = new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing");
            string expected = "Sword (sword)";

            Assert.AreEqual(item.ShortDescription, expected);
        }

        [TestMethod]
        public void TestFullDescription()
        {
            Item item = new Item(new string[] { "sword" }, "Sword", "Sharp, for stabbing");
            string expected = "Sharp, for stabbing";

            Assert.AreEqual(item.FullDescription, expected);
        }
    }
}
