using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwinAdventure;

namespace SwinAdventureTests
{
    /// <summary>
    /// Summary description for LookCommandTests
    /// </summary>
    [TestClass]
    public class LookCommandTests
    {
        public LookCommandTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestLookAtMe()
        {
            LookCommand cmd = new LookCommand();
            Player p = new Player("Josiah", "The Coolest");
            Item item = new Item(new string[] { "gem" }, "Gem", "Shiny and Expensive");
            p.Inventory.Put(item);

            var expected = "You are carrying:\n" + "\tGem (gem)\n";
            string[] text = new string[] { "Look", "at", "inventory" };
            var result = cmd.Excecute(p, text);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLookAtGem()
        {
            LookCommand cmd = new LookCommand();
            Player p = new Player("Josiah", "The Coolest");
            Item item = new Item(new string[] { "gem" }, "Gem", "Shiny and Expensive");
            p.Inventory.Put(item);

            var expected = "Shiny and Expensive";
            string[] text = new string[] { "Look", "at", "gem"};
            var result = cmd.Excecute(p, text);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLookAtUnk()
        {
            LookCommand cmd = new LookCommand();
            Player p = new Player("Josiah", "The Coolest");

            var expected = "Cannot find gem in inventory";
            string[] text = new string[] { "Look", "at", "gem", "in", "inventory" };
            var result = cmd.Excecute(p, text);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLookAtGemInMe()
        {
            LookCommand cmd = new LookCommand();
            Player p = new Player("Josiah", "The Coolest");
            Item item = new Item(new string[] { "gem" }, "Gem", "Shiny and Expensive");
            p.Inventory.Put(item);

            var expected = "Shiny and Expensive";
            string[] text = new string[] { "Look", "at", "gem", "in", "inventory" };
            var result = cmd.Excecute(p, text);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLookAtGemInBag()
        {
            LookCommand cmd = new LookCommand();
            Player p = new Player("Josiah", "The Coolest");
            Item item = new Item(new string[] { "gem" }, "Gem", "Shiny and Expensive");
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "Stores Things");
            p.Inventory.Put(bag);
            bag.Inventory.Put(item);

            var expected = "Shiny and Expensive";
            string[] text = new string[] { "look", "at", "gem", "in", "bag" };
            var result = cmd.Excecute(p, text);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLookAtGemInNoBag()
        {
            LookCommand cmd = new LookCommand();
            Player p = new Player("Josiah", "The Coolest");
            Item item = new Item(new string[] { "gem" }, "Gem", "Shiny and Expensive");
            p.Inventory.Put(item);

            var expected = "I cannot find the bag";
            string[] text = new string[] { "look", "at", "gem", "in", "bag" };
            var result = cmd.Excecute(p, text);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLookAtNoGemInBag()
        {
            LookCommand cmd = new LookCommand();
            Player p = new Player("Josiah", "The Coolest");
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "Stores Things");
            p.Inventory.Put(bag);

            var expected = "Cannot find gem in bag";
            string[] text = new string[] { "look", "at", "gem", "in", "bag" };
            var result = cmd.Excecute(p, text);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestInvalidLook()
        {
            LookCommand cmd = new LookCommand();
            Player p = new Player("Josiah", "The Coolest");

            var expected1 = "Error in look input";
            var expected2 = "What do you want to look at?";
            var expected3 = "What do you want to look in?";

            string[] command1 = new string[] { "BOOM" };
            string[] command2 = new string[] { "Look", "in", "here" };
            string[] command3 = new string[] {"look", "at", "a", "a", "sword"};

            var test1 = cmd.Excecute(p, command1);
            var test2 = cmd.Excecute(p, command2);
            var test3 = cmd.Excecute(p, command3);

            var result = false;

            if (expected1 == test1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            if (expected2 == test2)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            if (expected3 == test3)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            Assert.IsTrue(result);
        }
    }
}
