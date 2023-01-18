using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models;

/// <summary>
/// Eszköz típusának megadása
/// </summary>
[Table("DeviceType")]
public class DeviceType{

    /// <summary>
    /// az eszköz típusának neve
    /// </summary>
    /// <value>1 string 25</value>
    [Required, MinLength(1),MaxLength(25)]
    public string Name { get; set; }
    
}