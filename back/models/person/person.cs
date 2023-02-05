using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Cards;
using back.models.Devices;
using back.models.PersonGroups;
using back.models.PersonTypes;

namespace back.models.Persons;

/// <summary>
/// Személyek
/// </summary>
[Table("Person")]
public class Person : BaseModel{

    /// <summary>
    /// a személy neve
    /// </summary>
    /// <value>1 string 100</value>
    [ MinLength(1),MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Tud-e kölcsönözni
    /// </summary>
    /// <value>bool</value>
    public bool IsAbleToBorrow { get; set; }

    /// <summary>
    /// neptunkód
    /// </summary>
    /// <value>nullable string 6</value>
    [MaxLength(6)]
    public string? NeptunCode { get; set; } = null;

    /// <summary>
    /// törzsszám
    /// </summary>
    /// <value>nullable string 20</value>
    [MaxLength(20)]
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// igazolványszám <br/>
    /// (pl személyigazolvány)
    /// </summary>
    /// <value>1 string 20</value>
    [ MinLength(1),MaxLength(20)]
    public string IdNumber { get; set; }

    /// <summary>
    /// igazolvány típusa
    /// </summary>
    /// <value>1 string 30</value>
    [ MinLength(1),MaxLength(30)]
    public string IdNumberType { get; set; }

    /// <summary>
    /// email cím
    /// </summary>
    /// <value>1 string 255</value>
    [ MinLength(1),MaxLength(255)]
    public string Email { get; set; }

    /// <summary>
    /// windows ad felhasználónév
    /// </summary>
    /// <value>6 string 20</value>
    [ MinLength(6),MaxLength(20)]
    public string AdUsername { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 100</value>
    [ MaxLength(100)]
    public string comment { get; set; }

    /// <summary>
    /// Megadja hogy melyik csapathoz tartozik
    /// </summary>
    /// <value>nullable int</value>
    public Guid? PersonGroupId { get; set; } = null;

    [ForeignKey("PersonGroupId")]
    public virtual PersonGroup PersonGroup { get; set; }

    /// <summary>
    /// személy típusa<br/>
    /// pl.: Előadó, Hallgató,VIP stb
    /// </summary>
    /// <value>int</value>
    public Guid? PersonTypeId { get; set; }

    [ForeignKey("PersonTypeId")]
    public virtual PersonType PersonType { get; set; }

    public virtual ICollection<Card> Cards {get; set;}
    public virtual ICollection<Device> Devices {get; set;}
}