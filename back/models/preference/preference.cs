using System.ComponentModel.DataAnnotations;

namespace back.models;

public class preference{
    
    /// <summary>
    /// preferencia id
    /// </summary>
    /// <value>int autoincrement</value>
    [Required]
    public int PreferenceId { get; set; }

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

    /// <summary>
    /// az administrator id-ja
    /// </summary>
    /// <value>int</value>
    [Required]
    public int AdministratorId { get; set; }

    public virtual administrator Administrator{get;set;}
}