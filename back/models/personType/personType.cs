using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models.PersonTypes;

/// <summary>
/// Személyek típusai
/// </summary>
[Table("PersonType")]
public class PersonType : BaseModel{

    /// <summary>
    /// neve a személy típusnak
    /// </summary>
    /// <value>1 string 25</value>
    [Required,MinLength(1),MaxLength(25)]
    public string Name { get; set; }

    /// <summary>
    /// tud-e kölcsönözni
    /// </summary>
    /// <value>bool</value>
    [Required]
    public bool IsBorrowable { get; set; }

    /// <summary>
    /// a kártya vonalkódjának előtagja
    /// </summary>
    /// <value> string 2</value>
    [Required,MaxLength(2)]
    public string CardPrefix { get; set; }

    /// <summary>
    /// megjegyzés
    /// </summary>
    /// <value>string 255</value>
    [Required,MaxLength(255)]
    public string Comment { get; set; }
}