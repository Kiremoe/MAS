﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MAS2.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230621142934_Hope3")]
    partial class Hope3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CampainZone", b =>
                {
                    b.Property<int>("CampainsId")
                        .HasColumnType("integer");

                    b.Property<int>("ZoneListId")
                        .HasColumnType("integer");

                    b.HasKey("CampainsId", "ZoneListId");

                    b.HasIndex("ZoneListId");

                    b.ToTable("CampainZone");
                });

            modelBuilder.Entity("MAS2.GamePieces.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("integer");

                    b.Property<int>("ExperiencePoints")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId")
                        .IsUnique();

                    b.HasIndex("ZoneId");

                    b.ToTable("Character");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Character");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MAS2.GamePieces.CharacterQuest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("QuestId");

                    b.ToTable("CharacterQuestsDBSET");
                });

            modelBuilder.Entity("MAS2.GamePieces.EnemiesZones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EnemyId")
                        .HasColumnType("integer");

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<int>("ZoneId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EnemyId");

                    b.HasIndex("ZoneId");

                    b.ToTable("EnemiesZonesDBSET");
                });

            modelBuilder.Entity("MAS2.GamePieces.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("AttackRange")
                        .HasColumnType("real");

                    b.Property<int>("AttackType")
                        .HasColumnType("integer");

                    b.Property<int>("Damage")
                        .HasColumnType("integer");

                    b.Property<int>("MaxHealth")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("MAS2.GamePieces.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("MAS2.GamePieces.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BootsEquipmentId")
                        .HasColumnType("integer");

                    b.Property<int?>("ChestEquipmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("integer");

                    b.Property<int?>("GlovesEquipmentId")
                        .HasColumnType("integer");

                    b.Property<int?>("HelmEquipmentId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestId")
                        .HasColumnType("integer");

                    b.Property<int?>("WeaponEquipmentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BootsEquipmentId")
                        .IsUnique();

                    b.HasIndex("ChestEquipmentId")
                        .IsUnique();

                    b.HasIndex("EquipmentId");

                    b.HasIndex("GlovesEquipmentId")
                        .IsUnique();

                    b.HasIndex("HelmEquipmentId")
                        .IsUnique();

                    b.HasIndex("QuestId");

                    b.HasIndex("WeaponEquipmentId")
                        .IsUnique();

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MAS2.GamePieces.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Goal")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RewardValue")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("MAS2.GamePieces.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("MapId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("MAS2.Model.Campain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GameMasterId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameMasterId")
                        .IsUnique();

                    b.ToTable("Campains");
                });

            modelBuilder.Entity("MAS2.Users.GameMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("GameMasters");
                });

            modelBuilder.Entity("MAS2.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GameMasterId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GameMasterId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MAS2.GamePieces.NPC", b =>
                {
                    b.HasBaseType("MAS2.GamePieces.Character");

                    b.Property<bool>("IsFriendly")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("NPC");
                });

            modelBuilder.Entity("MAS2.GamePieces.Player", b =>
                {
                    b.HasBaseType("MAS2.GamePieces.Character");

                    b.Property<int?>("CampainId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasIndex("CampainId");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("Player");
                });

            modelBuilder.Entity("MAS2.GamePieces.Map", b =>
                {
                    b.HasBaseType("MAS2.GamePieces.Item");

                    b.HasDiscriminator().HasValue("Map");
                });

            modelBuilder.Entity("CampainZone", b =>
                {
                    b.HasOne("MAS2.Model.Campain", null)
                        .WithMany()
                        .HasForeignKey("CampainsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS2.GamePieces.Zone", null)
                        .WithMany()
                        .HasForeignKey("ZoneListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAS2.GamePieces.Character", b =>
                {
                    b.HasOne("MAS2.GamePieces.Equipment", "Equipment")
                        .WithOne("Character")
                        .HasForeignKey("MAS2.GamePieces.Character", "EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS2.GamePieces.Zone", "Zone")
                        .WithMany("Characters")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("MAS2.GamePieces.CharacterQuest", b =>
                {
                    b.HasOne("MAS2.GamePieces.Character", "Character")
                        .WithMany("CharacterQuests")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS2.GamePieces.Quest", "Quest")
                        .WithMany("CharactersQuests")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Quest");
                });

            modelBuilder.Entity("MAS2.GamePieces.EnemiesZones", b =>
                {
                    b.HasOne("MAS2.GamePieces.Enemy", "Enemy")
                        .WithMany("EnemiesZones")
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS2.GamePieces.Zone", "Zone")
                        .WithMany("EnemiesZones")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enemy");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("MAS2.GamePieces.Item", b =>
                {
                    b.HasOne("MAS2.GamePieces.Equipment", "BootsEquipment")
                        .WithOne("Boots")
                        .HasForeignKey("MAS2.GamePieces.Item", "BootsEquipmentId");

                    b.HasOne("MAS2.GamePieces.Equipment", "ChestEquipment")
                        .WithOne("Chest")
                        .HasForeignKey("MAS2.GamePieces.Item", "ChestEquipmentId");

                    b.HasOne("MAS2.GamePieces.Equipment", "Equipment")
                        .WithMany("GetItemsInBags")
                        .HasForeignKey("EquipmentId");

                    b.HasOne("MAS2.GamePieces.Equipment", "GlovesEquipment")
                        .WithOne("Gloves")
                        .HasForeignKey("MAS2.GamePieces.Item", "GlovesEquipmentId");

                    b.HasOne("MAS2.GamePieces.Equipment", "HelmEquipment")
                        .WithOne("Helm")
                        .HasForeignKey("MAS2.GamePieces.Item", "HelmEquipmentId");

                    b.HasOne("MAS2.GamePieces.Quest", "Quest")
                        .WithMany("RewardItems")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS2.GamePieces.Equipment", "WeaponEquipment")
                        .WithOne("Weapon")
                        .HasForeignKey("MAS2.GamePieces.Item", "WeaponEquipmentId");

                    b.Navigation("BootsEquipment");

                    b.Navigation("ChestEquipment");

                    b.Navigation("Equipment");

                    b.Navigation("GlovesEquipment");

                    b.Navigation("HelmEquipment");

                    b.Navigation("Quest");

                    b.Navigation("WeaponEquipment");
                });

            modelBuilder.Entity("MAS2.GamePieces.Zone", b =>
                {
                    b.HasOne("MAS2.GamePieces.Map", "Map")
                        .WithMany("Zones")
                        .HasForeignKey("MapId");

                    b.Navigation("Map");
                });

            modelBuilder.Entity("MAS2.Model.Campain", b =>
                {
                    b.HasOne("MAS2.Users.GameMaster", "GameMaster")
                        .WithOne("Campain")
                        .HasForeignKey("MAS2.Model.Campain", "GameMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameMaster");
                });

            modelBuilder.Entity("MAS2.Users.User", b =>
                {
                    b.HasOne("MAS2.Users.GameMaster", "GameMaster")
                        .WithOne("User")
                        .HasForeignKey("MAS2.Users.User", "GameMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameMaster");
                });

            modelBuilder.Entity("MAS2.GamePieces.Player", b =>
                {
                    b.HasOne("MAS2.Model.Campain", "Campain")
                        .WithMany("PlayerList")
                        .HasForeignKey("CampainId");

                    b.HasOne("MAS2.Users.User", "User")
                        .WithMany("PlayerCharacters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campain");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MAS2.GamePieces.Character", b =>
                {
                    b.Navigation("CharacterQuests");
                });

            modelBuilder.Entity("MAS2.GamePieces.Enemy", b =>
                {
                    b.Navigation("EnemiesZones");
                });

            modelBuilder.Entity("MAS2.GamePieces.Equipment", b =>
                {
                    b.Navigation("Boots");

                    b.Navigation("Character")
                        .IsRequired();

                    b.Navigation("Chest");

                    b.Navigation("GetItemsInBags");

                    b.Navigation("Gloves");

                    b.Navigation("Helm");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("MAS2.GamePieces.Quest", b =>
                {
                    b.Navigation("CharactersQuests");

                    b.Navigation("RewardItems");
                });

            modelBuilder.Entity("MAS2.GamePieces.Zone", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("EnemiesZones");
                });

            modelBuilder.Entity("MAS2.Model.Campain", b =>
                {
                    b.Navigation("PlayerList");
                });

            modelBuilder.Entity("MAS2.Users.GameMaster", b =>
                {
                    b.Navigation("Campain")
                        .IsRequired();

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("MAS2.Users.User", b =>
                {
                    b.Navigation("PlayerCharacters");
                });

            modelBuilder.Entity("MAS2.GamePieces.Map", b =>
                {
                    b.Navigation("Zones");
                });
#pragma warning restore 612, 618
        }
    }
}
