using MAS2.GamePieces;
using MAS2.Model;
using MAS2.Users;
using Microsoft.EntityFrameworkCore;


public class Context : DbContext
{
    public DbSet<Campain> Campains { get; set; }
    public DbSet<Zone> Zones { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<GameMaster> GameMasters { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<NPC> NPCs { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<CharacterQuest> CharacterQuestsDBSET { get; set; }
    public DbSet<Enemy> Enemies { get; set; }
    public DbSet<EnemiesZones> EnemiesZonesDBSET { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    //public DbSet<GamePiece> GamePieces { get; set; }

    public Context(){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=postgres;Username=postgres;Password=postgres;Include Error Detail=true");

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Campain>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.GameMaster).WithOne(p => p.Campain).HasForeignKey<Campain>("GameMasterId").IsRequired();
            //e.HasMany(p => p.PlayerList).WithOne(p => p.Campain).HasForeignKey(p => p. ); 
            //e.HasMany(p => p.ZoneList).WithMany(p => p.Campains);
        });

        model.Entity<Zone>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            //e.HasOne(p => p.Map).WithMany(p => p.GetZones()).HasForeignKey("Zone", "Name");
            e.HasMany(p => p.Campains).WithMany(p => p.ZoneList).UsingEntity(
                l => l.HasOne(typeof(Zone)).WithMany().HasForeignKey("ZoneFK"),
                r => r.HasOne(typeof(Campain)).WithMany().HasForeignKey("CamapinFK"));
            //e.HasMany(p => p.EnemiesZones).WithOne(p => p.Zone).HasForeignKey("ZoneId");
        });

        model.Entity<Item>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.Quest).WithMany(p => p.RewardItems).HasForeignKey(p => p.QuestId);
            //e.HasOne(p => p.Equipment).WithOne(p => p.Helm) z drugiej strony
        });

        model.Entity<Map>(e =>
        {
            e.HasMany(p => p.Zones).WithOne(p => p.Map).HasForeignKey("MapId");
        });

        model.Entity<User>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            //e.HasOne(p => p.GameMaster).WithOne(p => p.User).HasForeignKey<User>(p => p.GameMasterId);
        });

        model.Entity<GameMaster>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.User).WithOne(p => p.GameMaster).HasForeignKey<User>("GameMasterId").IsRequired();
        });

        model.Entity<Character>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.Equipment).WithOne(p => p.Character).HasForeignKey<Character>(p => p.EquipmentId).IsRequired();
            e.HasMany(p => p.CharacterQuests).WithOne(p => p.Character).HasForeignKey("PlayerId");
            e.HasOne(p => p.Zone).WithMany(p => p.Characters).HasForeignKey(p => p.ZoneId).IsRequired();
        });

        model.Entity<Player>(e =>
        {
            e.HasOne(p => p.User).WithMany(p => p.PlayerCharacters).HasForeignKey(p => p.UserId);
            e.HasOne(p => p.Campain).WithMany(p => p.PlayerList).HasForeignKey("CampainId").IsRequired(false);
        });

        model.Entity<NPC>(e => {});

        model.Entity<Quest>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            //e.HasOne(p => p.Quest).WithMany(p => p.RewardItems).HasForeignKey(p => p.QuestId);
            e.HasMany(p => p.CharactersQuests).WithOne(p => p.Quest).HasForeignKey("QuestId");
        });

        model.Entity<CharacterQuest>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            //e.HasMany(p => p.CharactersQuests).WithOne(p => p.Quest).HasForeignKey("QuestId");
            //e.HasMany(p => p.CharacterQuests).WithOne(p => (Player)p.Character).HasForeignKey("PlayerId");
        });

        model.Entity<Enemy>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            //e.HasMany(p => p.EnemiesZones).WithOne(p => p.Enemy).HasForeignKey("EnemyId");
        });

        //model.Entity<Enemy>(e =>
        //{
        //    e.HasKey(p => p.Id);
        //    e.Property(p => p.Id).ValueGeneratedOnAdd();
        //    e.HasMany(p => p.EnemiesZones).WithOne(p => p.Enemy).HasForeignKey("EnemyId");
        //});

        model.Entity<EnemiesZones>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.Enemy).WithMany(p => p.EnemiesZones).HasForeignKey("EnemyId");
            e.HasOne(p => p.Zone).WithMany(p => p.EnemiesZones).HasForeignKey("ZoneId");
        });

        model.Entity<Equipment>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.Helm).WithOne(p => p.HelmEquipment).HasForeignKey<Item>(p => p.HelmEquipmentId);
            e.HasOne(p => p.Chest).WithOne(p => p.ChestEquipment).HasForeignKey<Item>(p => p.ChestEquipmentId);
            e.HasOne(p => p.Gloves).WithOne(p => p.GlovesEquipment).HasForeignKey<Item>(p => p.GlovesEquipmentId);
            e.HasOne(p => p.Boots).WithOne(p => p.BootsEquipment).HasForeignKey<Item>(p => p.BootsEquipmentId);
            e.HasOne(p => p.Weapon).WithOne(p => p.WeaponEquipment).HasForeignKey<Item>(p => p.WeaponEquipmentId);
            e.HasMany(p => p.GetItemsInBags).WithOne(p => p.Equipment).HasForeignKey(p => p.EquipmentId);
        });
    }
}