using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.enums.status;

namespace back.models;

public class device{

    /// <summary>
    /// Az eszköz id-ja
    /// </summary>
    /// <value>int auto increment</value>
    [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeviceId { get; set; }

    /// <summary>
    /// létrehozási idő
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// az eszköz státusza
    /// </summary>
    /// <value>deviceStatus enum</value>
    [Required]
    public deviceStatus DeviceStatus { get; set; }

    /// <summary>
    /// Megjegyzés
    /// </summary>
    /// <value>string 255</value>
    [Required,MaxLength(255)]
    public string Comment { get; set; }

    /// <summary>
    /// eszköz tipusának id-ja
    /// </summary>
    /// <value>int</value>
    [Required,ForeignKey("deviceType")]
    public int DeviceTypeId { get; set; }

    public virtual deviceType DeviceType { get; set; }

    /// <summary>
    /// porta id-ja
    /// </summary>
    /// <value>int</value>
    [Required, ForeignKey("reception")]
    public int ReceptionId { get; set; }

    public virtual reception Reception { get; set; }

    /// <summary>
    /// létrehozó id-ja
    /// </summary>
    /// <value>int</value>
    [Required,ForeignKey("administrator")]
    public int CreatorId { get; set; }

    public virtual administrator Administrator { get; set; }

    /// <summary>
    /// A birtokos id-ja
    /// </summary>
    /// <value>nullable int</value>
    [ForeignKey("person")]
    public int? PosesserId { get; set; }

    public virtual person? Posesser { get; set; }
}