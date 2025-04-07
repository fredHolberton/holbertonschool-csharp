using System;
using System.Collections.Generic;
using InventoryLibrary;
using System.Linq;
using System.Text.Json;

namespace InventoryManager
{
    class Program
    {
        static InventoryLibrary.JSONStorage storage = new InventoryLibrary.JSONStorage();
        
        static void Main(string[] args)
        {
            storage.Load();

            InitialPrompt();

            while (true)
            {
                
                try
                {
                    Console.Write("\n> ");
                    string input = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(input))
                        continue;

                    var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string command = parts[0].ToLower();

                    switch (command)
                    {
                        case "classnames":
                            ClassNames();
                            break;
                        case "all":
                            if (parts.Length == 1) ShowAll();
                            else ShowAll(parts[1]);
                            break;
                        case "create":
                            if (parts.Length == 2) Create(parts[1]);
                            else InvalidInput();
                            break;
                        case "show":
                            if (parts.Length == 3) Show(parts[1], parts[2]);
                            else InvalidInput();
                            break;
                        case "update":
                            if (parts.Length == 3) Update(parts[1], parts[2]);
                            else InvalidInput();
                            break;
                        case "delete":
                            if (parts.Length == 3) Delete(parts[1], parts[2]);
                            else InvalidInput();
                            break;
                        case "exit":
                            return;
                        default:
                            InvalidInput();
                            break;
                    }

                    InitialPrompt();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                
            }
        }

        /* print the initial Prompt before each input command */
        static void InitialPrompt()
        {
            Console.WriteLine("\nInventory Manager");
            Console.WriteLine("-------------------------");
            Console.WriteLine("<ClassNames> show all ClassNames of objects");
            Console.WriteLine("<All> show all objects");
            Console.WriteLine("<All [ClassName]> show all objects of a ClassName");
            Console.WriteLine("<Create [ClassName]> a new object");
            Console.WriteLine("<Show [ClassName object_id]> an object");
            Console.WriteLine("<Update [ClassName object_id]> an object");
            Console.WriteLine("<Delete [ClassName object_id]> an object");
            Console.WriteLine("<Exit>");
        }

        static void ClassNames()
        {
            var classNames = storage.All().Keys
                .Select(k => k.Split('.')[0])
                .Distinct(StringComparer.OrdinalIgnoreCase);

            foreach (var name in classNames)
                Console.WriteLine(name);
        }

        static void ShowAll(string className = null)
        {
            bool classNameFounded = false;

            foreach (KeyValuePair<string, object> kvp in storage.All())
            {
                string classNameKey = kvp.Key.Split('.')[0];
                string id = kvp.Key.Split('.')[1];

                if (className == null || className.ToLower() == classNameKey.ToLower())
                {
                    if (className != null)
                        classNameFounded = true;
                    Show(classNameKey, id);
                }
                    
            }

            if (className != null && !classNameFounded)
            {
                throw new Exception($"{className} is not a valid object type");
            }
        }

        static void Create(string className)
        {
            BaseClass obj = null;
            className = className.ToLower();

            try
            {
                switch (className)
                {
                    case "user":
                        Console.Write("Enter name: ");
                        obj = new User(Console.ReadLine());
                        break;

                    case "item":
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Item item = new Item(name );
                        Console.Write("Enter description (optional): ");
                        item.description = Console.ReadLine();
                        Console.Write("Enter price (optional): ");
                        if (float.TryParse(Console.ReadLine(), out float price))
                            item.price = (float)Math.Round(price, 2);
                        obj = item;
                        break;

                    case "inventory":
                        Console.Write("Enter user_id: ");
                        string userId = Console.ReadLine();
                        Console.Write("Enter item_id: ");
                        string itemId = Console.ReadLine();
                        Console.Write("Enter quantity (default 1): ");
                        int quantity = int.TryParse(Console.ReadLine(), out int q) ? q : 1;
                        obj = new Inventory(userId, itemId, quantity);
                        break;

                    default:
                        throw new Exception($"{className} is not a valid object type");
                        return;
                }

                storage.New(obj);
                storage.Save();
                Console.WriteLine("Object created.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating object: {ex.Message}");
            }
        }

        static void Show(string className, string id)
        {

            string key = $"{className}.{id}";
            bool classNameFound = false;
            bool idFound = false;

            foreach (KeyValuePair<string, object> kvp in storage.All())
            {
                string classNameKey = kvp.Key.Split('.')[0];
                if (classNameKey.ToLower() == className.ToLower())
                {
                    classNameFound = true;
                    if (kvp.Key.ToLower() == key.ToLower())
                    {
                        idFound = true;
                        switch (className.ToLower())
                        {
                            case "user":
                                User user = (User)(kvp.Value);
                                Console.WriteLine($"{user.ToString()}\n");
                                break;

                            case "item":
                                Item item = (Item)(kvp.Value);
                                Console.WriteLine($"{item.ToString()}\n");
                                break;

                            case "inventory":
                                Inventory inventory = (Inventory)(kvp.Value);
                                Console.WriteLine($"{inventory.ToString()}\n");
                                break;
                        }

                        
                    }
                }
            }
            if (!classNameFound)
            {
                throw new Exception($"{className} is not a valid object type");
            }
            else if (!idFound)
            {
                throw new Exception($"Object {id} could not be found");
            }

        }

        static void Update(string className, string id)
        {
            string key = $"{className}.{id}";
            bool classNameFound = false;
            bool idFound = false;

            foreach (KeyValuePair<string, object> kvp in storage.All())
            {
                string classNameKey = kvp.Key.Split('.')[0];
                if (classNameKey.ToLower() == className.ToLower())
                {
                    classNameFound = true;
                    if (kvp.Key.ToLower() == key.ToLower())
                    {
                        idFound = true;
                        switch (className.ToLower())
                        {
                            case "user":
                                User user = (User)(kvp.Value);
                                Console.Write($"Current name is '{user.name}', enter new name: ");
                                user.name = Console.ReadLine();
                                break;

                            case "item":
                                Item item = (Item)(kvp.Value);
                                Console.Write($"Current name is '{item.name}', enter new name: ");
                                item.name = Console.ReadLine();
                                Console.Write($"Current description is '{item.description}', enter new description: ");
                                item.description = Console.ReadLine();
                                Console.Write($"Current price is '{item.price}', enter new price: ");
                                if (float.TryParse(Console.ReadLine(), out float p)) item.price = p;
                                break;

                            case "inventory":
                                Inventory inventory = (Inventory)(kvp.Value);
                                Console.Write($"Current quantity is '{inventory.quantity}', enter new quantity: ");
                                if (int.TryParse(Console.ReadLine(), out int newQty)) inventory.quantity = newQty;
                                break;
                        }

                        
                    }
                }
            }
            if (!classNameFound)
            {
                throw new Exception($"{className} is not a valid object type");
                return;
            }
            else if (!idFound)
            {
                throw new Exception($"Object {id} could not be found");
                return;
            }

            storage.Save();
            Console.WriteLine("Object updated.");
        }

        static void Delete(string className, string id)
        {
            string key = $"{className}.{id}";
            bool classNameFound = false;
            bool idFound = false;

            foreach (KeyValuePair<string, object> kvp in storage.All())
            {
                string classNameKey = kvp.Key.Split('.')[0];
                if (classNameKey.ToLower() == className.ToLower())
                {
                    classNameFound = true;
                    if (kvp.Key.ToLower() == key.ToLower())
                    {
                        idFound = true;

                        if (storage.objects.Remove(kvp.Key))
                        {
                            storage.Save();
                            Console.WriteLine("Object deleted.");
                            return;
                        }
                    
                    }
                }
            }

            if (!classNameFound)
            {
                throw new Exception($"{className} is not a valid object type");
                return;
            }
            else if (!idFound)
            {
                throw new Exception($"Object {id} could not be found");
                return;
            }

        }

        static void InvalidInput()
        {
            throw new Exception("Invalid input. Try again.");
        }

    }
    
}
