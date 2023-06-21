using MAS2;
using MAS2.GamePieces;
using MAS2.Model;
using MAS2.Users;
using System.Windows;


public abstract class GeneralFunctions
{
    public static void InitailSetup()
    {
        using var db = new Context();

        if (db.Users.Any()) { return; }

        User user1 = new User("TestUser", "TestPassword");
        User user2 = new User("TestUser", "TestPassword");
        User user3 = new User("TestUser", "TestPassword");
        User user4 = new User("TestUser", "TestPassword");
        Zone zone1 = new Zone("Mokradła", "Gęsto zarośnięte mokradła, nad którymi rozwija się zmród zgnilizny.");
        Zone zone2 = new Zone("Pola", "Pagórki, na których rosną w uporządkowany sposób przeróżne rośliny oprawne.");
        Quest quest1 = new Quest("Uratuj księżniczkę", null, null, 100, null, null);
        Quest quest2 = new Quest("Zabij smoka");
        Item sword = new Item("Prosty miecz", 1, null, 1, Item.EquipmentType.Weapon);
        Map map = new Map("Mapa świata", null, 1, new List<Zone> { zone1, zone2 });
        Player character1 = new Player("Najemnik", zone2, user1);
        Player character2 = new Player("Mag", zone2, user2);
        Player character3 = new Player("Barbażyńca", zone2, user3);
        Player character4 = new Player("Kleryk", zone2, user4);
        character1.Equipment.Weapon = sword;
        character1.Equipment.AddItemToBags(map);
        character1.AddQuest(quest1);
        character1.AddQuest(quest2);
        character1.CompleteQuest(quest1);

        Enemy enemy1 = new Enemy("Zombie", 10, Character.AttackType.Physical, 1f, 2);
        Enemy enemy2 = new Enemy("Południca", 20, Character.AttackType.Fire, 3f, 3);
        Enemy enemy3 = new Enemy("Utopce", 20, Character.AttackType.Physical, 1f, 1);
        EnemiesZones ez1 = new EnemiesZones(enemy1, zone1);
        EnemiesZones ez2 = new EnemiesZones(enemy2, zone2);
        EnemiesZones ez3 = new EnemiesZones(enemy3, zone1);

        NPC npc1 = new NPC(new List<string>() { "Każdy kiedyś skończy w grobie" }, false, "Myrkul, władca kości", zone1);
        NPC npc2 = new NPC(new List<string>() { "Witam cię", "Wiedz, że każda magia pozostawia po sobie ślady" }, true, "Kess, dysydentka magii", zone1);
        NPC npc3 = new NPC(new List<string>() { "Witaj podróżniku", "Nie jestem kotem, tylko kotoludziem" }, true, "Ajanii, dumny koteł", zone2);


        db.Users.Add(user1);
        db.Users.Add(user2);
        db.Users.Add(user3);
        db.Users.Add(user4);
        db.Zones.Add(zone1);
        db.Zones.Add(zone2);
        db.Quests.Add(quest1);
        db.Quests.Add(quest2);
        db.Items.Add(sword);
        db.Maps.Add(map);
        db.Players.Add(character1);
        db.Players.Add(character2);
        db.Players.Add(character3);
        db.Players.Add(character4);
        db.Enemies.Add(enemy1);
        db.Enemies.Add(enemy2);
        db.Enemies.Add(enemy3);
        //db.EnemiesZonesDBSET.Add(ez1);
        //db.EnemiesZonesDBSET.Add(ez2);
        //db.EnemiesZonesDBSET.Add(ez3);
        db.NPCs.Add(npc1);
        db.NPCs.Add(npc2);
        db.NPCs.Add(npc3);
        db.SaveChanges();

    }

    public static GameMaster GetGameMaster()
    {
        using var db = new Context();
        return db.GameMasters.First(); // FOR SAMPLE USE CASE SCENARIO
    }

    public static void Submit(GameMaster gameMaster, List<Zone> zones, List<Player> players, List<Enemy> enemies, List<NPC> npcs )
    {
        using var db = new Context();
        Campain campain = new Campain(db.GameMasters.Find(gameMaster.Id));
        foreach(Zone zone in zones)
        {
            campain.AddZoneToCampain(db.Zones.Find(zone.Id));
        }
        foreach(Player player in players)
        {
            campain.AddPlayerToCampain(db.Players.Find(player.Id));
        }
        foreach(Enemy enemy in enemies)
        {
            foreach(EnemiesZones enemiesZones in enemy.EnemiesZones)
            {
                if (zones.Contains(enemiesZones.Zone))
                {
                    enemy.RemoveEnemyInstanceFromZone(enemiesZones); //FOR SAMPLE USE CASE SCENARIO
                }
            }
            
        }
        db.NPCs.RemoveRange(db.NPCs.Where(e => npcs.Contains(e))); //FOR SAMPLE USE CASE SCENARIO
        db.Campains.Add(campain);
        db.SaveChanges();
    }

    public static List<Zone> GetZones()
    {
        using var db = new Context();
        List<Zone> zones = new List<Zone>();
        zones.AddRange(db.Zones.ToList());
        return zones;
    }

    public static List<Enemy> GetEnemies(List<Zone> zones)
    {
        using var db = new Context();
        List<Enemy> enemies = new List<Enemy>();
        enemies.AddRange(db.EnemiesZonesDBSET.Where(e => zones.Contains(e.Zone)).Select(e => e.Enemy).ToList());
        return enemies;
    }

    public static List<NPC> GetNPCs(List<Zone> zones)
    {
        using var db = new Context();
        List<NPC> npcs = new List<NPC>();
        npcs.AddRange(db.NPCs.Where(e => zones.Contains(e.Zone)).ToList());
        return npcs;
    }

    public static List<Player> GetPlayers(List<Zone> zones)
    {
        using var db = new Context();
        List<Player> players = new List<Player>();
        players.AddRange(db.Players.Where(e => zones.Contains(e.Zone)).ToList());
        return players;
    }

}


