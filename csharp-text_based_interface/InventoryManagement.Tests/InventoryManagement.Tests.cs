using NUnit.Framework;
using InventoryLibrary;
using System;
using System.IO;
using System.Collections.Generic;

namespace InventoryManagement.Tests
{
    [TestFixture]
    public class BaseClassTests
    {
        [Test]
        public void BaseClass_ShouldGenerateUniqueId_OnCreation()
        {
            var baseClass1 = new Item("Item1");
            var baseClass2 = new Item("Item2");
            Assert.AreNotEqual(baseClass1.id, baseClass2.id);
        }

        [Test]
        public void BaseClass_ShouldSetDates_OnCreation()
        {
            var baseClass = new Item("Item");
            Assert.AreEqual(baseClass.date_created.Date, DateTime.UtcNow.Date);
            Assert.AreEqual(baseClass.date_updated.Date, DateTime.UtcNow.Date);
        }
    }

    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void Item_ShouldThrowException_WhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Item(string.Empty));
        }

        [Test]
        public void Item_ShouldInitializeWithValidName()
        {
            var item = new Item("Item1");
            Assert.AreEqual(item.name, "Item1");
        }

        [Test]
        public void Item_ShouldAllowOptionalFields()
        {
            var item = new Item("Item2", "Description", 10.5f, new List<string> { "tag1", "tag2" });
            Assert.AreEqual(item.description, "Description");
            Assert.AreEqual(item.price, 10.5f);
            Assert.Contains("tag1", item.tags);
            Assert.Contains("tag2", item.tags);
        }

        [Test]
        public void Item_ShouldRoundPriceToTwoDecimalPlaces()
        {
            var item = new Item("Item3", price: 10.1234f);
            Assert.AreEqual(item.price, 10.12f);
        }

        [Test]
        public void Item_ToString_ShouldReturnCorrectFormat()
        {
            var item = new Item("Item", "Sample", 15.99f);
            var expected = $"Item: Item\n  Description: Sample\n  Price: 15,99\n  ID: {item.id}";
            Assert.AreEqual(item.ToString(), expected);
        }
    }

    [TestFixture]
    public class UserTests
    {
        [Test]
        public void User_ShouldThrowException_WhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new User(string.Empty));
        }

        [Test]
        public void User_ShouldInitializeWithValidName()
        {
            var user = new User("John Doe");
            Assert.AreEqual(user.name, "John Doe");
        }

        [Test]
        public void User_ToString_ShouldReturnCorrectFormat()
        {
            var user = new User("John");
            var expected = $"User: John (id: {user.id})";
            Assert.AreEqual(user.ToString(), expected);
        }
    }

    [TestFixture]
    public class InventoryTests
    {
        [Test]
        public void Inventory_ShouldThrowException_WhenQuantityIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Inventory("user1", "item1", -1));
        }

        [Test]
        public void Inventory_ShouldInitializeWithValidProperties()
        {
            var inventory = new Inventory("user1", "item1", 10);
            Assert.AreEqual(inventory.user_id, "user1");
            Assert.AreEqual(inventory.item_id, "item1");
            Assert.AreEqual(inventory.quantity, 10);
        }

        [Test]
        public void Inventory_ToString_ShouldReturnCorrectFormat()
        {
            var inventory = new Inventory("user1", "item1", 10);
            var expected = $"Inventory:\n  User ID: user1\n  Item ID: item1\n  Quantity: 10\n  ID: {inventory.id}";
            Assert.AreEqual(inventory.ToString(), expected);
        }
    }

    [TestFixture]
    public class JSONStorageTests
    {
        private JSONStorage storage;

        [SetUp]
        public void SetUp()
        {
            storage = new JSONStorage();
            if (Directory.Exists("storage"))
            {
                Directory.Delete("storage", true); // Clear previous storage
            }
        }

        [Test]
        public void JSONStorage_ShouldAddNewObject()
        {
            var item = new Item("New Item");
            storage.New(item);

            var allObjects = storage.All();
            Assert.AreEqual(allObjects.Count, 1);
            Assert.IsTrue(allObjects.ContainsKey($"Item.{item.id}"));
        }

        [Test]
        public void JSONStorage_ShouldSaveToFile()
        {
            var item = new Item("New Item");
            storage.New(item);

            storage.Save();
            string filePath = Path.Combine("storage", "inventory_manager.json");
            Assert.IsTrue(File.Exists(filePath));
        }

        [Test]
        public void JSONStorage_ShouldLoadFromFile()
        {
            var item = new Item("New Item");
            storage.New(item);
            storage.Save();

            // Create a new instance of JSONStorage and load the data
            var newStorage = new JSONStorage();
            newStorage.Load();

            var allObjects = newStorage.All();
            Assert.AreEqual(allObjects.Count, 1);
            Assert.IsTrue(allObjects.ContainsKey($"Item.{item.id}"));
        }

        [Test]
        public void JSONStorage_ShouldThrowException_WhenFileNotFound()
        {
            Assert.Throws<FileNotFoundException>(() => storage.Load());
        }
    }
}