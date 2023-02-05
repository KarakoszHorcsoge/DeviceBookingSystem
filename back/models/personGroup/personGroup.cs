using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.enums.status;
using back.models.Persons;

namespace back.models.PersonGroups;

/// <summary>
/// Személy csoportok
/// </summary>
[Table("PersonGroup")]
public class PersonGroup : BaseModel{

    /// <summary>
    /// Személy csoport neve 
    /// </summary>
    /// <value></value>
    [ MinLength(1),MaxLength(255)]
    public string Name { get; set; }

    /// <summary>
    /// státusz
    /// </summary>
    /// <value>enum (inactive,active,temporarilyActive,partiallyActive)</value>
    public PersonGroupStatus status { get; set; }

    /// <summary>
    /// Megjegyzés
    /// </summary>
    /// <value>string 255</value>
    [ MaxLength(255)]
    public string comment { get; set; }

    public ICollection<Person> Persons { get; set; }
}