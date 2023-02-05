using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Administrators;

namespace back.models.Preferences;

/// <summary>
/// Személyek beállításai
/// </summary>
[Table("Preference")]
public class Preference : BaseModel{

    /// <summary>
    /// preferencia neve
    /// </summary>
    /// <value>1 string 25</value>
    [ MinLength(1),MaxLength(25)]
    public string Name { get; set; }

    /// <summary>
    /// preferencia értéke
    /// </summary>
    /// <value>1 string 100</value>
    [MinLength(1),MaxLength(100)]
    public string Value { get; set; }

    public Guid? AdministratorId {get; set;}

    public virtual Administrator Administrator { get; set;}
}