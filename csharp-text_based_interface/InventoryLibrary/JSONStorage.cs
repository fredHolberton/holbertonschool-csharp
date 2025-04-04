using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using InventoryLibrary;

namespace InventoryLibrary
{
    /// <summary>Public class to manage storage in json format.</summary>
    public class JSONStorage
    {
        /// <summary>Gets or sets a dictionary of objects.</summary>
        public Dictionary<string, BaseClass> objects { get; set; } = new Dictionary<string, BaseClass>();

        /// <summary>Return all objects of the dictionary.</summary>
        public Dictionary<string, BaseClass> All()
        {
            return objects;
        }

        /// <summary>Add a new object in dictionary.</summary>
        public void New(BaseClass obj)
        {
            string key = $"{obj.GetType().Name}.{obj.id}";
            if (!objects.ContainsKey(key))
            {
                objects.Add(key, obj);
            }
        }

        /// <summary>Save the inventory in a serialized Json file.</summary>
        public void Save()
        {
            string filePath = "../storage/inventory_manager.json";
            try
            {
                // Ensure the "storage" directory exists
                Directory.CreateDirectory("../storage");

                // Serialize the objects dictionary into a JSON string
                string json = JsonSerializer.Serialize(objects, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                // Write the JSON string to a file
                File.WriteAllText(filePath, json);
                Console.WriteLine("Objects saved to JSON file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        /// <summary>Deserializes the JSON file and loads the objects into the dictionary.</summary>
        public void Load()
        {
            string filePath = "../storage/inventory_manager.json";
            try
            {
                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // Read the JSON string from the file
                    string json = File.ReadAllText(filePath);

                    // Deserialize the JSON string into the objects dictionary
                    objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(json);
                    Console.WriteLine("Objects loaded from JSON file.");
                }
                else
                {
                    Console.WriteLine($"File {filePath} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }
    }
}