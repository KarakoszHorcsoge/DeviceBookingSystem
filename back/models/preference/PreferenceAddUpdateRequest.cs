using System.ComponentModel.DataAnnotations;

namespace back.models.Preferences;

public class PreferenceAddUpdateRequest : BaseRequest{

    /// <summary>
    /// preferencia neve
    /// </summary>
    /// <value>1 string 25</value>
    [Required,MinLength(1),MaxLength(25)]
    public string Name { get; set; }

    /// <summary>
    /// preferencia értéke
    /// </summary>
    /// <value>1 string 100</value>
    [Required,MinLength(1),MaxLength(100)]
    public string Value { get; set; }

    [Required]
    public Guid AdministratorId {get; set;}

}