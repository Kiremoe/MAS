using System.Text.Json;
using System.Text.Json.Serialization;

namespace MAS1
{
    public static class SaveService
    {
        private static readonly string _filePath = "save.json";

        private static FileContents? _fileContents;
        
        private struct FileContents
        {
            public List<Character> Characters;
            public List<Item> Items;
            public List<Quest> Quests;
            public List<Zone> Zones;
            public List<CharacterQuest> CharactersQuests;
            public List<Equipment> Equipments;

            public FileContents(List<Character> characters, List<Item> items, List<Quest> quests, List<Zone> zones, List<CharacterQuest> characterQuests, List<Equipment> equipments)
            {
                Characters = characters;
                Items = items;
                Quests = quests;
                Zones = zones;
                CharactersQuests = characterQuests;
                Equipments = equipments;
            }
        }

        // Ekstensja trwała
        public static void LoadFromFile() // Metoda klasowa
        {
            if (!File.Exists(_filePath)) { return; }
            try
            {
                _fileContents = JsonSerializer.Deserialize<FileContents>(File.ReadAllText(_filePath));
                if (_fileContents.HasValue) 
                {
                    Character.Characters = _fileContents.Value.Characters; 
                    Item.Items = _fileContents.Value.Items;
                    Quest.Quests = _fileContents.Value.Quests;
                    Zone.Zones = _fileContents.Value.Zones;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SaveToFile()
        {
            _fileContents = new FileContents(Character.Characters, Item.Items, Quest.Quests, Zone.Zones, CharacterQuest.CharactersQuests, Equipment.Equipments);
            string jsonString = JsonSerializer.Serialize(_fileContents);
            File.WriteAllText(_filePath, jsonString);
        }

        public static void ClearFile()
        {
            _fileContents = new FileContents(new List<Character>(), new List<Item>(), new List<Quest>(), new List<Zone>(), new List<CharacterQuest>(), new List<Equipment>());
            string jsonString = JsonSerializer.Serialize(_fileContents);
            File.WriteAllText(_filePath, jsonString);
        }
    }
}
