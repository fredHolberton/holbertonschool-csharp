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
        /* Name of the storage directory */
        private const string storageFolder = "storage";
        /* Name of the storage file name */
        private const string storageFileName = "inventory_manager.json";
        
        /// <summary>Gets or sets a dictionary of objects.</summary>
        public Dictionary<string, object> objects { get; set; }

        /// <summary>Constructor to set property.</summary>
        public JSONStorage()
        {
            this.objects = new Dictionary<string, object>();
        }

        /// <summary>Return all objects of the dictionary.</summary>
        public Dictionary<string, object> All()
        {
            return objects;
        }

        /// <summary>Add a new object in dictionary.</summary>
        public void New(object obj)
        {
            string key = $"{obj.GetType().Name}.{((BaseClass)obj).id}";
            if (!objects.ContainsKey(key))
            {
                objects[key] = obj;
            }
        }

        /// <summary>Save the inventory in a serialized Json file.</summary>
        public void Save()
        {
            if (!Directory.Exists(storageFolder))
                Directory.CreateDirectory(storageFolder);

            string filePath = Path.Combine(storageFolder, storageFileName);
            try
            {
                // Serialize the objects dictionary into a JSON string
                string json = JsonSerializer.Serialize(objects, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                // Write the JSON string to a file
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error saving to file: {ex.Message}");
            }
        }

        /// <summary>Deserializes the JSON file and loads the objects into the dictionary.</summary>
        public void Load()
        {
            this.objects = new Dictionary<string, object>();
            string filePath = Path.Combine(storageFolder, storageFileName);
            // Vérifier si le répertoire et le fichier existent
    
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Le fichier JSON n'a pas été trouvé.");
            }

            // Lire le contenu du fichier JSON
            string json = File.ReadAllText(filePath);

            // Désérialiser le contenu JSON dans un dictionnaire
            var deserializedObjects = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            if (deserializedObjects == null)
            {
                throw new InvalidOperationException("Erreur lors de la désérialisation des objets.");
            }

            // Parcourir chaque entrée et désérialiser selon le type
            foreach (var entry in deserializedObjects)
            {
                string key = entry.Key;
                JsonElement jsonElement = entry.Value;

                // Extraire le type à partir de la clé (par exemple, "User" de "User.12345")
                string typeName = key.Split('.')[0];

                object obj = null;

                // Désérialiser l'objet en fonction du type
                switch (typeName)
                {
                    case "User":
                        obj = JsonSerializer.Deserialize<User>(jsonElement.GetRawText());
                        break;
                    case "Item":
                        obj = JsonSerializer.Deserialize<Item>(jsonElement.GetRawText());
                        break;
                    case "Inventory":
                        obj = JsonSerializer.Deserialize<Inventory>(jsonElement.GetRawText());
                        break;
                    default:
                        throw new InvalidOperationException($"Type inconnu : {typeName}");
                }

                // Ajouter l'objet désérialisé au dictionnaire
                objects[key] = obj;
            }
        }

    }
}