using System.ComponentModel.DataAnnotations;

namespace back.models.PersonTypes;



public class PersonType : BaseRequest{

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