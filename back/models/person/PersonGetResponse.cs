using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.PersonGroups;
using back.models.PersonTypes;

namespace back.models.Persons;

public class PersonGetResponse : BaseResponse{

    /// <summary>
    /// a személy neve
    /// </summary>
    /// <value>1 string 100</value>
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
    public string? NeptunCode { get; set; } = null;

    /// <summary>
    /// törzsszám
    /// </summary>
    /// <value>nullable string 20</value>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// igazolványszám <br/>
    /// (pl személyigazolvány)
    /// </summary>
    /// <value>1 string 20</value>
    public string IdNumber { get; set; }

    /// <summary>
    /// igazolvány típusa
    /// </summary>
    /// <value>1 string 30</value>
    public string IdNumberType { get; set; }

    /// <summary>
    /// email cím
    /// </summary>
    /// <value>1 string 255</value>
    public string Email { get; set; }

    /// <summary>
    /// windows ad felhasználónév
    /// </summary>
    /// <value>6 string 20</value>
    public string AdUsername { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 100</value>
    public string comment { get; set; }

    /// <summary>
    /// Megadja hogy melyik csapathoz tartozik
    /// </summary>
    /// <value>nullable int</value>
    public Guid? PersonGroupId { get; set; } = null;

    public virtual PersonGroup PersonGroup { get; set; }

    /// <summary>
    /// személy típusa<br/>
    /// pl.: Előadó, Hallgató,VIP stb
    /// </summary>
    /// <value>int</value>
    public Guid PersonTypeId { get; set; }

    public virtual PersonType PersonType { get; set; }
}