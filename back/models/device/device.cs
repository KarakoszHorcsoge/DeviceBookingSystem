using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.enums.status;

namespace back.models;

/// <summary>
/// Eszközök
/// </summary>
[Table("Device")]
public class Device : BaseModel{

    /// <summary>
    /// az eszköz státusza
    /// </summary>
    /// <value>deviceStatus enum</value>
    [Required]
    public DeviceStatus DeviceStatus { get; set; }

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
    [Required]
    public int DeviceTypeId { get; set; }

    [ForeignKey("DeviceTypeId")]
    public virtual DeviceType DeviceType { get; set; }

    /// <summary>
    /// porta id-ja
    /// </summary>
    /// <value>int</value>
    [Required]
    public int ReceptionId { get; set; }

    [ForeignKey("ReceptionId")]
    public virtual Reception Reception { get; set; }

    /// <summary>
    /// A birtokos id-ja
    /// </summary>
    /// <value>nullable int</value>
    public int? PosesserId { get; set; }

    [ForeignKey("PersonId")]
    public virtual Person Posesser { get; set; }
}