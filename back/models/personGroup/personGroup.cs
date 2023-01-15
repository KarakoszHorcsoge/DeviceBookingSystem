using System.ComponentModel.DataAnnotations;
using back.enums.status;

namespace back.models;

public class personGroup{
    /// <summary>
    /// Szemékly csoportok id ja
    /// </summary>
    /// <value>int autoincrement</value>
    [Required]
    public int PersonGroupId { get; set; }

    /// <summary>
    /// Személy csoport neve 
    /// </summary>
    /// <value></value>
    [Required,MinLength(1),MaxLength(255)]
    public string Name { get; set; }

    /// <summary>
    /// Létrehozás ideje
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// státusz
    /// </summary>
    /// <value>enum (inactive,active,temporarilyActive,partiallyActive)</value>
    [Required]
    public personGroupStatus status { get; set; }

    /// <summary>
    /// Megjegyzés
    /// </summary>
    /// <value>string 255</value>
    [Required,MaxLength(255)]
    public string comment { get; set; }

    /// <summary>
    /// Létrehozó id
    /// </summary>
    /// <value>int</value>
    [Required]
    public int CreatorId { get; set; }

    [Required]
    public virtual administrator Creator {get;set;}
}