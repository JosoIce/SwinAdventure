using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestClass]
    public class IdentifiableObjectTest
    {
        [TestMethod]
        public void TestAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2", "id3" });

            Assert.IsTrue(id.AreYou("id1"));
        }

        [TestMethod]
        public void TestNotAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2", "id3" });

            Assert.IsFalse(id.AreYou("id5"));
        }

        [TestMethod]
        public void TestCaseSensitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2", "id3" });

            Assert.IsTrue(id.AreYou("ID1"));
        }

        [TestMethod]
        public void TestFirstId()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2", "id3" });
            Assert.AreEqual(id.FirstId, "id1");
        }

        [TestMethod]
        public void TestAddId()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2", "id3" });

            id.AddIdentifier("id4");

            Assert.IsTrue(id.AreYou("id4"));
        }
    }
}
