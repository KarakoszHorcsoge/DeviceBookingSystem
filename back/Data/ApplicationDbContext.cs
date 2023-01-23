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

namespace back.Data.ApplicationDbContext;

public class ApplicationDbContext: DbContext{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
    base(options){}

    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Authoroty> Authoroties { get; set; }
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

}