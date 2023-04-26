using System.Text.Json;
using System.Text.Json.Serialization;

namespace MAS2
{
    public static class SaveService
    {
        private static readonly string _filePath = "save.json";

        private static FileContents _fileContents = new FileContents();
        
        private class FileContents
        {
            public List<Character> Characters { get; set; }
            public List<Item> Items { get; set; }
            public List<Quest> Quests { get; set; }
            public List<Zone> Zones { get; set; }
            public List<CharacterQuest> CharactersQuests { get; set; }
            public List<Equipment> Equipments { get; set; }

            public FileContents(List<Character> characters, List<Item> items, List<Quest> quests, List<Zone> zones, List<CharacterQuest> characterQuests, List<Equipment> equipments)
            {
                Characters = characters;
                Items = items;
                Quests = quests;
                Zones = zones;
                CharactersQuests = characterQuests;
                Equipments = equipments;
            }

            public FileContents() : this(Character.Characters, Item.Items, Quest.Quests, Zone.Zones, CharacterQuest.CharactersQuests, Equipment.Equipments) { }
        }

        // Ekstensja trwała
        //public static void LoadFromFile() // Metoda klasowa
        //{
        //    if (!File.Exists(_filePath)) { return; }
        //    try
        //    {
        //        if(_fileContents == null) { throw new Exception("FileContents should not be null"); }
        //        FileContents? x = JsonSerializer.Deserialize<FileContents>(File.ReadAllText(_filePath));
        //        if (x == null) { throw new Exception("File was corrupted"); }
        //        _fileContents = x;
        //        Character.Characters = _fileContents.Characters; 
        //        Item.Items = _fileContents.Items;
        //        Quest.Quests = _fileContents.Quests;
        //        Zone.Zones = _fileContents.Zones;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        //public static void SaveToFile()
        //{
        //    _fileContents = new FileContents();
        //    string jsonString = JsonSerializer.Serialize(_fileContents); //loop reference problem
        //    Console.WriteLine(jsonString);
        //    File.WriteAllText(_filePath, jsonString);
        //}

        //public static void ClearFile()
        //{
        //    _fileContents = new FileContents(new List<Character>(), new List<Item>(), new List<Quest>(), new List<Zone>(), new List<CharacterQuest>(), new List<Equipment>());
        //    string jsonString = JsonSerializer.Serialize(_fileContents);
        //    File.WriteAllText(_filePath, jsonString);
        //}
    }
}
