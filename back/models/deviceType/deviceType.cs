using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models;

public class deviceType{

    /// <summary>
    /// eszköz típus idja
    /// </summary>
    /// <value>int auto increment</value>
    [Required, Key ,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeviceTypeId { get; set; }

    /// <summary>
    /// az eszköz típusának neve
    /// </summary>
    /// <value>1 string 25</value>
    [Required, MinLength(1),MaxLength(25)]
    public string Name { get; set; }

    /// <summary>
    /// létrehozási idő
    /// </summary>
    /// <value>datetime</value>
    [Required]
    public DateTime CreationTime { get; set; }

    [ForeignKey("administraotr"),Required]
    public int CreatorId { get; set; }

    public virtual administrator Creator { get; set; }
}