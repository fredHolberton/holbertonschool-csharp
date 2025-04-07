using NUnit.Framework;
using InventoryLibrary;
using System;

namespace InventoryManagement.Tests
{
    public class InventoryManagementTests
    {

        private readonly string filePath = Path.Combine("storage", "inventory_manager.json");
        private string jsonContent;

        [SetUp]
        public void SetUp()
        {
            // Backup existing file if it exists
            if (File.Exists(filePath))
                jsonContent = File.ReadAllText(filePath);
        }

        
        [Test]
        public void User_Constructor_SetNameOK()
        {
            var user = new User("John Do");
            Assert.That(user.name, Is.EqualTo("John Do"));
        }

        [Test]
        public void User_Constructor_ThrowsEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new User(""));
        }

        [Test]
        public void Item_Constructor_SetNameCorrectly()
        {
            var item = new Item("Laptop");
            Assert.That(item.name, Is.EqualTo("Laptop"));
            Assert.That(item.description, Is.EqualTo(""));
            Assert.That(item.price, Is.EqualTo(0));
        }

        [Test]
        public void Item_Constructor_SetPropertiesCorrectly()
        {
            var item = new Item("Laptop", "My beautiful laptop", 700.50f);
            Assert.That(item.name, Is.EqualTo("Laptop"));
            Assert.That(item.description, Is.EqualTo("My beautiful laptop"));
            Assert.That(item.price, Is.EqualTo(700.50f));
        }

        [Test]
        public void Item_Constructor_ThrowsEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new Item(""));
        }


    }
}