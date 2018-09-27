using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestClass]
    public class LookCommandTests
    {
        private LookCommand cmd;
        private Player p;

        public LookCommandTests()
        {
            cmd = new LookCommand();
            p = new Player("Josiah", "The Coolest");
        }

        [TestMethod]
        private void TestLookAtMe()
        {
            var expected = "aasdasd";

            string[] text = new string[] { "Look", "at", "inventory" };
            var result = cmd.Excecute(p, text);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        private void TestLookAtGem()
        {

        }
        [TestMethod]
        private void TestLookAtUnk()
        {

        }
        [TestMethod]
        private void TestLookAtGemInMe()
        {

        }
        [TestMethod]
        private void TestLookAtGemInBag()
        {

        }
        [TestMethod]
        private void TestLookAtGemInNoBag()
        {

        }
        [TestMethod]
        private void TestLookAtNoGemInBag()
        {

        }
        [TestMethod]
        private void TestInvalidLook()
        {

        }
    }
}
