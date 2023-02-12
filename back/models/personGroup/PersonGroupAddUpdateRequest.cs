using System.ComponentModel.DataAnnotations;
using back.enums.status;

namespace back.models.PersonGroups;

public class PersonGroupAddUpdateRequest : BaseRequest{

    /// <summary>
    /// Személy csoport neve 
    /// </summary>
    /// <value></value>
    [Required,MinLength(1),MaxLength(255)]
    public string Name { get; set; }

    /// <summary>
    /// státusz
    /// </summary>
    /// <value>enum (inactive,active,temporarilyActive,partiallyActive)</value>
    [Required]
    public PersonGroupStatus status { get; set; }

    /// <summary>
    /// Megjegyzés
    /// </summary>
    /// <value>string 255</value>
    [Required,MaxLength(255)]
    public string comment { get; set; }
}