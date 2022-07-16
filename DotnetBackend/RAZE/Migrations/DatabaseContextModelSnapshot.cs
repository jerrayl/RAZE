﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RAZE;

namespace RAZE.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("RAZE.Entities.BonusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BonusTypes");
                });

            modelBuilder.Entity("RAZE.Entities.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Effect")
                        .HasColumnType("TEXT");

                    b.Property<int>("ElementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identifier")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Production")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tier")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("RAZE.Entities.BuildingCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ElementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("BuildingCosts");
                });

            modelBuilder.Entity("RAZE.Entities.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("RAZE.Entities.GameRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identifier")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StatusTypeId");

                    b.ToTable("GameRooms");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BonusTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BonusTypeId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerBonuses");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerBuilding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerBuildings");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerProduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ElementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerProductions");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ElementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerResources");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GameRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameRoomId");

                    b.ToTable("PlayerSessions");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerTroop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardSlot")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TroopId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TroopId");

                    b.ToTable("PlayerTroops");
                });

            modelBuilder.Entity("RAZE.Entities.StatusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StatusTypes");
                });

            modelBuilder.Entity("RAZE.Entities.Troop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ElementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identifier")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tier")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.ToTable("Troops");
                });

            modelBuilder.Entity("RAZE.Entities.TroopCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ElementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TroopId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TroopId");

                    b.ToTable("TroopCosts");
                });

            modelBuilder.Entity("RAZE.Entities.Building", b =>
                {
                    b.HasOne("RAZE.Entities.Element", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");
                });

            modelBuilder.Entity("RAZE.Entities.BuildingCost", b =>
                {
                    b.HasOne("RAZE.Entities.Building", null)
                        .WithMany("BuildingCosts")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RAZE.Entities.GameRoom", b =>
                {
                    b.HasOne("RAZE.Entities.StatusType", "StatusType")
                        .WithMany()
                        .HasForeignKey("StatusTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusType");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerBonus", b =>
                {
                    b.HasOne("RAZE.Entities.BonusType", "BonusType")
                        .WithMany()
                        .HasForeignKey("BonusTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAZE.Entities.PlayerSession", "Player")
                        .WithMany("PlayerBonuses")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BonusType");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerBuilding", b =>
                {
                    b.HasOne("RAZE.Entities.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAZE.Entities.PlayerSession", "Player")
                        .WithMany("PlayerBuildings")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerProduction", b =>
                {
                    b.HasOne("RAZE.Entities.Element", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAZE.Entities.PlayerSession", "Player")
                        .WithMany("PlayerProductions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerResource", b =>
                {
                    b.HasOne("RAZE.Entities.Element", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAZE.Entities.PlayerSession", "Player")
                        .WithMany("PlayerResources")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerSession", b =>
                {
                    b.HasOne("RAZE.Entities.GameRoom", "GameRoom")
                        .WithMany()
                        .HasForeignKey("GameRoomId");

                    b.Navigation("GameRoom");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerTroop", b =>
                {
                    b.HasOne("RAZE.Entities.PlayerSession", "Player")
                        .WithMany("PlayerTroops")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAZE.Entities.Troop", "Troop")
                        .WithMany()
                        .HasForeignKey("TroopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Troop");
                });

            modelBuilder.Entity("RAZE.Entities.Troop", b =>
                {
                    b.HasOne("RAZE.Entities.Element", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");
                });

            modelBuilder.Entity("RAZE.Entities.TroopCost", b =>
                {
                    b.HasOne("RAZE.Entities.Troop", null)
                        .WithMany("TroopCosts")
                        .HasForeignKey("TroopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RAZE.Entities.Building", b =>
                {
                    b.Navigation("BuildingCosts");
                });

            modelBuilder.Entity("RAZE.Entities.PlayerSession", b =>
                {
                    b.Navigation("PlayerBonuses");

                    b.Navigation("PlayerBuildings");

                    b.Navigation("PlayerProductions");

                    b.Navigation("PlayerResources");

                    b.Navigation("PlayerTroops");
                });

            modelBuilder.Entity("RAZE.Entities.Troop", b =>
                {
                    b.Navigation("TroopCosts");
                });
#pragma warning restore 612, 618
        }
    }
}
