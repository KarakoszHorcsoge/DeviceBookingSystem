﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back.DbContexts.ApplicationDbContext;

#nullable disable

namespace back.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230201204701_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("back.models.Administrators.Administrator", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AuthorotyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorotyId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("back.models.Authorotys.Authoroty", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AuthorotyLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Authoroty");
                });

            modelBuilder.Entity("back.models.BorrowRestrictions.BorrowRestriction", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DeviceId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DeviceTypeId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ReceptionId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("ModifierId");

                    b.HasIndex("ReceptionId");

                    b.ToTable("BorrowRestriction");
                });

            modelBuilder.Entity("back.models.Cards.Card", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AdministratorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ExperationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("back.models.DelayedEvents.DelayedEvent", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Command")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("DelayedEvent");
                });

            modelBuilder.Entity("back.models.DeviceTypes.DeviceType", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("DeviceType");
                });

            modelBuilder.Entity("back.models.Devices.Device", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<int>("DeviceStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("DeviceTypeId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("PosesserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ReceptionId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("ModifierId");

                    b.HasIndex("PersonId");

                    b.HasIndex("ReceptionId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("back.models.EventLogs.EventLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ChildEventId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Command")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("CommandOriginId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CommandParentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("CommandType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ParentEventId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("SecondTargetId")
                        .HasColumnType("int");

                    b.Property<int>("TargetId")
                        .HasColumnType("int");

                    b.Property<string>("TargetType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CommandOriginId");

                    b.HasIndex("CommandParentId");

                    b.HasIndex("ParentEventId")
                        .IsUnique();

                    b.ToTable("EventLog");
                });

            modelBuilder.Entity("back.models.PersonGroups.PersonGroup", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("PersonGroup");
                });

            modelBuilder.Entity("back.models.PersonTypes.PersonType", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CardPrefix")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsBorrowable")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("PersonType");
                });

            modelBuilder.Entity("back.models.Persons.Person", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AdUsername")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("IdNumberType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("IsAbleToBorrow")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NeptunCode")
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<Guid?>("PersonGroupId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("PersonTypeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("RegistrationNumber")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.HasIndex("PersonGroupId");

                    b.HasIndex("PersonTypeId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("back.models.Preferences.Preference", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AdministratorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("Preference");
                });

            modelBuilder.Entity("back.models.Receptions.Reception", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("AdminId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("administrator")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.HasIndex("administrator");

                    b.ToTable("Reception");
                });

            modelBuilder.Entity("back.models.Administrators.Administrator", b =>
                {
                    b.HasOne("back.models.Authorotys.Authoroty", "Authoroty")
                        .WithMany("Administrators")
                        .HasForeignKey("AuthorotyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedAdministrators")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedAdministrators")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Authoroty");

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("back.models.Authorotys.Authoroty", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedAuthorotys")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedAuthorotys")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("back.models.BorrowRestrictions.BorrowRestriction", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedBorrowRestrictions")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Devices.Device", "Device")
                        .WithMany("BorrowRestrictions")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("back.models.DeviceTypes.DeviceType", "DeviceType")
                        .WithMany("BorrowRestrictions")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedBorrowRestrictions")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Receptions.Reception", "Reception")
                        .WithMany("BorrowRestrictions")
                        .HasForeignKey("ReceptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Device");

                    b.Navigation("DeviceType");

                    b.Navigation("Modifier");

                    b.Navigation("Reception");
                });

            modelBuilder.Entity("back.models.Cards.Card", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", null)
                        .WithMany("Cards")
                        .HasForeignKey("AdministratorId");

                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedCards")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedCards")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Persons.Person", "Owner")
                        .WithMany("Cards")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Modifier");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("back.models.DelayedEvents.DelayedEvent", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedDelayedEvents")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedDelayedEvents")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("back.models.DeviceTypes.DeviceType", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedDeviceTypes")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedDeviceTypes")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("back.models.Devices.Device", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedDevices")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.DeviceTypes.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedDevices")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Persons.Person", "Posesser")
                        .WithMany("Devices")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Receptions.Reception", "Reception")
                        .WithMany("Devices")
                        .HasForeignKey("ReceptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("DeviceType");

                    b.Navigation("Modifier");

                    b.Navigation("Posesser");

                    b.Navigation("Reception");
                });

            modelBuilder.Entity("back.models.EventLogs.EventLog", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "CommandOrigin")
                        .WithMany("OriginEventLogs")
                        .HasForeignKey("CommandOriginId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "CommandParent")
                        .WithMany("ParentEventLogs")
                        .HasForeignKey("CommandParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.EventLogs.EventLog", "ChildEvent")
                        .WithOne("ParentEvent")
                        .HasForeignKey("back.models.EventLogs.EventLog", "ParentEventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ChildEvent");

                    b.Navigation("CommandOrigin");

                    b.Navigation("CommandParent");
                });

            modelBuilder.Entity("back.models.PersonGroups.PersonGroup", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedPersonGroups")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedPersonGroups")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("back.models.PersonTypes.PersonType", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedPersonTypes")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedPersonTypes")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("back.models.Persons.Person", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedPersons")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedPersons")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.PersonGroups.PersonGroup", "PersonGroup")
                        .WithMany("Persons")
                        .HasForeignKey("PersonGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.PersonTypes.PersonType", "PersonType")
                        .WithMany("Persons")
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Modifier");

                    b.Navigation("PersonGroup");

                    b.Navigation("PersonType");
                });

            modelBuilder.Entity("back.models.Preferences.Preference", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Administrator")
                        .WithMany("AdminPreferences")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedPreferences")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedPreferences")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Administrator");

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("back.models.Receptions.Reception", b =>
                {
                    b.HasOne("back.models.Administrators.Administrator", "Creator")
                        .WithMany("CreatedReceptions")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Modifier")
                        .WithMany("ModifiedReceptions")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("back.models.Administrators.Administrator", "Admin")
                        .WithMany("Receptions")
                        .HasForeignKey("administrator")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Admin");

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("back.models.Administrators.Administrator", b =>
                {
                    b.Navigation("AdminPreferences");

                    b.Navigation("Cards");

                    b.Navigation("CreatedAdministrators");

                    b.Navigation("CreatedAuthorotys");

                    b.Navigation("CreatedBorrowRestrictions");

                    b.Navigation("CreatedCards");

                    b.Navigation("CreatedDelayedEvents");

                    b.Navigation("CreatedDeviceTypes");

                    b.Navigation("CreatedDevices");

                    b.Navigation("CreatedPersonGroups");

                    b.Navigation("CreatedPersonTypes");

                    b.Navigation("CreatedPersons");

                    b.Navigation("CreatedPreferences");

                    b.Navigation("CreatedReceptions");

                    b.Navigation("ModifiedAdministrators");

                    b.Navigation("ModifiedAuthorotys");

                    b.Navigation("ModifiedBorrowRestrictions");

                    b.Navigation("ModifiedCards");

                    b.Navigation("ModifiedDelayedEvents");

                    b.Navigation("ModifiedDeviceTypes");

                    b.Navigation("ModifiedDevices");

                    b.Navigation("ModifiedPersonGroups");

                    b.Navigation("ModifiedPersonTypes");

                    b.Navigation("ModifiedPersons");

                    b.Navigation("ModifiedPreferences");

                    b.Navigation("ModifiedReceptions");

                    b.Navigation("OriginEventLogs");

                    b.Navigation("ParentEventLogs");

                    b.Navigation("Receptions");
                });

            modelBuilder.Entity("back.models.Authorotys.Authoroty", b =>
                {
                    b.Navigation("Administrators");
                });

            modelBuilder.Entity("back.models.DeviceTypes.DeviceType", b =>
                {
                    b.Navigation("BorrowRestrictions");

                    b.Navigation("Devices");
                });

            modelBuilder.Entity("back.models.Devices.Device", b =>
                {
                    b.Navigation("BorrowRestrictions");
                });

            modelBuilder.Entity("back.models.EventLogs.EventLog", b =>
                {
                    b.Navigation("ParentEvent")
                        .IsRequired();
                });

            modelBuilder.Entity("back.models.PersonGroups.PersonGroup", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("back.models.PersonTypes.PersonType", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("back.models.Persons.Person", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Devices");
                });

            modelBuilder.Entity("back.models.Receptions.Reception", b =>
                {
                    b.Navigation("BorrowRestrictions");

                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
