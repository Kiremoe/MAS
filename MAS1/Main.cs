using MAS1;

void Main()
{
    SaveService.ClearFile();
    //SaveService.LoadFromFile();

    Zone zone = new Zone("Swamp", "Muddy and hard to get through wetlands");
    Quest quest = new Quest("Save the princes");
    Item sword = new Item("Sword", 1, null, 1, null, Item.EquipmentType.Weapon);
    Character character = new Character("Andrzej", zone);

    character.Equipment.Weapon = sword;
    character.AddQuest(quest);





    SaveService.SaveToFile();
    foreach (Character c in Character.Characters)
    {
        Console.WriteLine(string.Format("Name: {0} | lvl: {1}", c.Name, c.Level.ToString()));
    }

    Console.WriteLine("Done!");
}

Main();


