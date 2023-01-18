using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models;

/// <summary>
/// Személyek beállításai
/// </summary>
[Table("Preference")]
public class Preference : BaseModel{

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
}