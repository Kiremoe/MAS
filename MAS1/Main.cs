using MAS2;

void Main()
{
    //SaveService.ClearFile();
    //SaveService.LoadFromFile();

    Zone zone = new Zone("Swamp", "Muddy and hard to get through wetlands");
    Quest quest = new Quest("Save the princes", null, null, 100, null, null);
    Quest quest2 = new Quest("Kill the dragon");
    Item sword = new Item("Sword", 1, null, 1, Item.EquipmentType.Weapon);
    Item map = new Map("Map of the world", null, 1, new List<Zone> { zone });
    Character character = new Character("Andrzej", zone);
    character.Equipment.Weapon = sword;
    character.Equipment.AddItemToBags(map);
    character.AddQuest(quest);
    character.AddQuest(quest2);
    character.CompleteQuest(quest);
    character.ReturnQuest(quest);


    //SaveService.SaveToFile();

    //foreach (Character c in Character.Characters)
    //{
    //    Console.WriteLine(string.Format("Name: {0} | lvl: {1}", c.Name, c.Level.ToString()));
    //}

    Console.WriteLine("Done!");

    
}

Main();


