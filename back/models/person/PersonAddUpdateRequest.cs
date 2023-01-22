using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models.Persons;

public class PersonAddUpdateRequest : BaseRequest{

    /// <summary>
    /// a személy neve
    /// </summary>
    /// <value>1 string 100</value>
    [Required,MinLength(1),MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Tud-e kölcsönözni
    /// </summary>
    /// <value>bool</value>
    [Required]
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
    [Required,MinLength(1),MaxLength(20)]
    public string IdNumber { get; set; }

    /// <summary>
    /// igazolvány típusa
    /// </summary>
    /// <value>1 string 30</value>
    [Required,MinLength(1),MaxLength(30)]
    public string IdNumberType { get; set; }

    /// <summary>
    /// email cím
    /// </summary>
    /// <value>1 string 255</value>
    [Required,MinLength(1),MaxLength(255)]
    public string Email { get; set; }

    /// <summary>
    /// windows ad felhasználónév
    /// </summary>
    /// <value>6 string 20</value>
    [Required,MinLength(6),MaxLength(20)]
    public string AdUsername { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 100</value>
    [Required,MaxLength(100)]
    public string comment { get; set; }

    /// <summary>
    /// Megadja hogy melyik csapathoz tartozik
    /// </summary>
    /// <value>nullable int</value>
    public Guid? PersonGroupId { get; set; } = null;
}