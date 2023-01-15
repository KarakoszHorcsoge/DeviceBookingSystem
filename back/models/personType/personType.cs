using System.ComponentModel.DataAnnotations;

namespace back.models;

public class personType{

    /// <summary>
    /// személy típusának id-ja
    /// </summary>
    /// <value>int</value>
    [Required]
    public int PersonTypeId { get; set; }

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
    public string CardTag { get; set; }

    /// <summary>
    /// Létrehozási idő
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// megjegyzés
    /// </summary>
    /// <value>string 255</value>
    [Required,MaxLength(255)]
    public string comment { get; set; }

    /// <summary>
    /// Létrehozó admin id-ja
    /// </summary>
    /// <value>int</value>
    [Required]
    public int CreatorId { get; set; }

    public virtual administrator Creator { get; set; }
}