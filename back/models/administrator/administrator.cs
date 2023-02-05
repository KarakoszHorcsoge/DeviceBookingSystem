
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Authorotys;
using back.models.BorrowRestrictions;
using back.models.Cards;
using back.models.DelayedEvents;
using back.models.Devices;
using back.models.DeviceTypes;
using back.models.EventLogs;
using back.models.PersonGroups;
using back.models.Persons;
using back.models.PersonTypes;
using back.models.Preferences;
using back.models.Receptions;

namespace back.models.Administrators;
/// <summary>
/// Rendszergazdák
/// </summary>
[Table("Administrator")]
public class Administrator : BaseModel
{

    /// <summary>
    /// név
    /// </summary>
    /// <value>1 string 45</value>
    [MinLength(1), MaxLength(45)]
    public string Name { get; set; }

    /// <summary>
    /// email cím
    /// </summary>
    /// <value>1 string 100</value>
    [MinLength(1), MaxLength(100)]
    public string Email { get; set; }

    /// <summary>
    /// authorotyId<br/>
    /// referálja az authoroty táblát
    /// </summary>
    /// <value>int</value>
    public Guid? AuthorotyId { get; set; }

    [ForeignKey("AuthorotyId")]
    public virtual Authoroty Authoroty { get; set; }

    public virtual ICollection<Administrator> CreatedAdministrators { get; set; }
    public virtual ICollection<Administrator> ModifiedAdministrators { get; set; }
    public virtual ICollection<Preference> AdminPreferences { get; set; }
    public virtual ICollection<Preference> CreatedPreferences { get; set; }
    public virtual ICollection<Preference> ModifiedPreferences { get; set; }
    public virtual ICollection<Authoroty> CreatedAuthorotys { get; set; }
    public virtual ICollection<Authoroty> ModifiedAuthorotys { get; set; }
    public virtual ICollection<BorrowRestriction> CreatedBorrowRestrictions { get; set; }
    public virtual ICollection<BorrowRestriction> ModifiedBorrowRestrictions { get; set; }
    public virtual ICollection<Card> Cards { get; set; }
    public virtual ICollection<Card> CreatedCards { get; set; }
    public virtual ICollection<Card> ModifiedCards { get; set; }
    public virtual ICollection<DelayedEvent> CreatedDelayedEvents { get; set; }
    public virtual ICollection<DelayedEvent> ModifiedDelayedEvents { get; set; }
    public virtual ICollection<Device> CreatedDevices { get; set; }
    public virtual ICollection<Device> ModifiedDevices { get; set; }
    public virtual ICollection<DeviceType> CreatedDeviceTypes { get; set; }
    public virtual ICollection<DeviceType> ModifiedDeviceTypes { get; set; }
    public virtual ICollection<Person> CreatedPersons { get; set; }
    public virtual ICollection<Person> ModifiedPersons { get; set; }
    public virtual ICollection<PersonGroup> CreatedPersonGroups { get; set; }
    public virtual ICollection<PersonGroup> ModifiedPersonGroups { get; set; }
    public virtual ICollection<PersonType>  CreatedPersonTypes { get; set; }
    public virtual ICollection<PersonType>  ModifiedPersonTypes { get; set; }
    public virtual ICollection<Reception> Receptions { get; set; }
    public virtual ICollection<Reception> CreatedReceptions { get; set; }
    public virtual ICollection<Reception> ModifiedReceptions { get; set; }
    public virtual ICollection<EventLog> OriginEventLogs { get; set; }
    public virtual ICollection<EventLog> ParentEventLogs { get; set; }
}