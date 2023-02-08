using Microsoft.EntityFrameworkCore;
using back.models;
using back.models.Authorotys;
using back.models.Administrators;
using back.models.BorrowRestrictions;
using back.models.Cards;
using back.models.DelayedEvents;
using back.models.Devices;
using back.models.DeviceTypes;
using back.models.EventLogs;
using back.models.Persons;
using back.models.PersonGroups;
using back.models.PersonTypes;
using back.models.Preferences;
using back.models.Receptions;

namespace back.DbContexts.ApplicationDbContext;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    base(options)
    { }

    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Authoroty> Authorotys { get; set; }
    public DbSet<BorrowRestriction> BorrowRestrictions { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<DelayedEvent> DelayedEvents { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceType> DeviceTypes { get; set; }
    public DbSet<EventLog> EventLogs { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonGroup> PersonGroups { get; set; }
    public DbSet<PersonType> PersonTypes { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<Reception> Receptions { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Administrator

        builder.Entity<Administrator>().HasKey(a => a.Id);

        builder.Entity<Administrator>()
            .HasOne(a => a.Creator)
            .WithMany(a => a.CreatedAdministrators)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedAdministrators)
            .WithOne(a => a.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasOne(a => a.Modifier)
            .WithMany(a => a.ModifiedAdministrators)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedAdministrators)
            .WithOne(a => a.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.AdminPreferences)
            .WithOne(p => p.Administrator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedPreferences)
            .WithOne(p => p.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedPreferences)
            .WithOne(p => p.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasOne(a => a.Authoroty)
            .WithMany(a => a.Administrators)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedAuthorotys)
            .WithOne(a => a.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedAuthorotys)
            .WithOne(a => a.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedBorrowRestrictions)
            .WithOne(b => b.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedBorrowRestrictions)
            .WithOne(b => b.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedCards)
            .WithOne(c => c.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedCards)
            .WithOne(c => c.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedDelayedEvents)
            .WithOne(de => de.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedDelayedEvents)
            .WithOne(de => de.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedDevices)
            .WithOne(d => d.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedDevices)
            .WithOne(d => d.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedDeviceTypes)
            .WithOne(dt => dt.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedDeviceTypes)
            .WithOne(dt => dt.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedPersons)
            .WithOne(p => p.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedPersons)
            .WithOne(p => p.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedPersonGroups)
            .WithOne(pg => pg.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedPersonGroups)
            .WithOne(pg => pg.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedPersonTypes)
            .WithOne(pg => pg.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedPersonTypes)
            .WithOne(pg => pg.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.Receptions)
            .WithOne(r => r.Admin)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.CreatedReceptions)
            .WithOne(r => r.Creator)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Administrator>()
            .HasMany(a => a.ModifiedReceptions)
            .WithOne(r => r.Modifier)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Authoroty
        builder.Entity<Authoroty>()
            .HasKey(a => a.Id);
        builder.Entity<Authoroty>()
            .HasOne(a => a.Creator)
            .WithMany(a => a.CreatedAuthorotys)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Authoroty>()
            .HasOne(a => a.Modifier)
            .WithMany(a => a.ModifiedAuthorotys)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Authoroty>()
            .HasIndex(a => a.Name)
            .IsUnique(true);
        #endregion

        #region BorrowRestriction

        builder.Entity<BorrowRestriction>()
            .HasKey(br => br.Id);

        builder.Entity<BorrowRestriction>()
            .HasOne(br => br.Reception)
            .WithMany(br => br.BorrowRestrictions)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<BorrowRestriction>()
            .HasOne(br => br.Device)
            .WithMany(d => d.BorrowRestrictions)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<BorrowRestriction>()
            .HasOne(br => br.DeviceType)
            .WithMany(dt => dt.BorrowRestrictions)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<BorrowRestriction>()
            .HasOne(br => br.Creator)
            .WithMany(a => a.CreatedBorrowRestrictions)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<BorrowRestriction>()
            .HasOne(br => br.Modifier)
            .WithMany(a => a.ModifiedBorrowRestrictions)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Card
        builder.Entity<Card>()
            .HasKey(c => c.Id);

        builder.Entity<Card>()
            .HasOne(c => c.Owner)
            .WithMany(o => o.Cards)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Card>()
            .HasOne(C => C.Creator)
            .WithMany(a => a.CreatedCards)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Card>()
            .HasOne(c => c.Modifier)
            .WithMany(c => c.ModifiedCards)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region DelayedEvent
        builder.Entity<DelayedEvent>()
            .HasKey(de => de.Id);

        builder.Entity<DelayedEvent>()
            .HasOne(de => de.Creator)
            .WithMany(a => a.CreatedDelayedEvents)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<DelayedEvent>()
            .HasOne(de => de.Modifier)
            .WithMany(a => a.ModifiedDelayedEvents)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Device
        builder.Entity<Device>()
            .HasKey(d => d.Id);

        builder.Entity<Device>()
            .HasOne(d => d.DeviceType)
            .WithMany(dt => dt.Devices)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Device>()
            .HasOne(d => d.Reception)
            .WithMany(r => r.Devices)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Device>()
            .HasOne(d => d.Posesser)
            .WithMany(p => p.Devices)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Device>()
            .HasMany(d => d.BorrowRestrictions)
            .WithOne(d => d.Device)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Device>()
            .HasOne(d => d.Creator)
            .WithMany(a => a.CreatedDevices)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Device>()
            .HasOne(d => d.Modifier)
            .WithMany(a => a.ModifiedDevices)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region DeviceType
        builder.Entity<DeviceType>()
            .HasKey(dt => dt.Id);

        builder.Entity<DeviceType>()
            .HasMany(dt => dt.Devices)
            .WithOne(d => d.DeviceType)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<DeviceType>()
            .HasMany(dt => dt.BorrowRestrictions)
            .WithOne(br => br.DeviceType)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<DeviceType>()
            .HasOne(dt => dt.Creator)
            .WithMany(a => a.CreatedDeviceTypes)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<DeviceType>()
            .HasOne(dt => dt.Modifier)
            .WithMany(a => a.ModifiedDeviceTypes)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region EventLog
        builder.Entity<EventLog>()
            .HasKey(el => el.Id);

        builder.Entity<EventLog>()
            .HasOne(el => el.CommandOrigin)
            .WithMany(a => a.OriginEventLogs)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EventLog>()
            .HasOne(el => el.CommandParent)
            .WithMany(a => a.ParentEventLogs)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EventLog>()
            .HasOne(el => el.ParentEvent)
            .WithOne(el => el.ChildEvent)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<EventLog>()
            .HasOne(el => el.ChildEvent)
            .WithOne(el => el.ParentEvent)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region Person
        builder.Entity<Person>()
            .HasKey(p => p.Id);
        builder.Entity<Person>()
            .HasOne(P => P.PersonGroup)
            .WithMany(pg => pg.Persons)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Person>()
            .HasOne(p => p.PersonType)
            .WithMany(pt => pt.Persons)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Person>()
            .HasMany(p => p.Cards)
            .WithOne(c => c.Owner)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Person>()
            .HasMany(p => p.Devices)
            .WithOne(d => d.Posesser)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Person>()
            .HasOne(p => p.Creator)
            .WithMany(a => a.CreatedPersons)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Person>()
            .HasOne(p => p.Modifier)
            .WithMany(a => a.ModifiedPersons)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region PersonGroup
        builder.Entity<PersonGroup>()
            .HasKey(pg => pg.Id);

        builder.Entity<PersonGroup>()
            .HasMany(pg => pg.Persons)
            .WithOne(p => p.PersonGroup)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<PersonGroup>()
            .HasOne(pg => pg.Creator)
            .WithMany(a => a.CreatedPersonGroups)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<PersonGroup>()
            .HasOne(pg => pg.Modifier)
            .WithMany(a => a.ModifiedPersonGroups)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region PersonType
        builder.Entity<PersonType>()
            .HasKey(pt => pt.Id);
        builder.Entity<PersonType>()
            .HasMany(pt => pt.Persons)
            .WithOne(p => p.PersonType)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<PersonType>()
            .HasOne(pt => pt.Creator)
            .WithMany(a => a.CreatedPersonTypes)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<PersonType>()
            .HasOne(pt => pt.Modifier)
            .WithMany(a => a.ModifiedPersonTypes)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Preference

        builder.Entity<Preference>().HasKey(p => p.Id);

        builder.Entity<Preference>()
            .HasOne(p => p.Administrator)
            .WithMany(c => c.AdminPreferences)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Preference>()
            .HasOne(p => p.Creator)
            .WithMany(a => a.CreatedPreferences)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Preference>()
            .HasOne(p => p.Modifier)
            .WithMany(a => a.ModifiedPreferences)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Reception
        builder.Entity<Reception>()
            .HasKey(r => r.Id);

        builder.Entity<Reception>()
            .HasOne(r => r.Admin)
            .WithMany(a => a.Receptions)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Reception>()
            .HasMany(r => r.Devices)
            .WithOne(d => d.Reception)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Reception>()
            .HasMany(r => r.BorrowRestrictions)
            .WithOne(br => br.Reception)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Reception>()
            .HasOne(r => r.Creator)
            .WithMany(a => a.CreatedReceptions)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Reception>()
            .HasOne(r => r.Modifier)
            .WithMany(a => a.ModifiedReceptions)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion
    }

}