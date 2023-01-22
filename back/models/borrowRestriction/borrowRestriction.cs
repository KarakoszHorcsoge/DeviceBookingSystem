using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Devices;
using back.models.DeviceTypes;
using back.models.Receptions;

namespace back.models.BorrowRestrictions;

/// <summary>
/// Kölcsönzési korlátok
/// </summary>
[Table("BorrowRestriction")]
public class BorrowRestriction : BaseModel{
    
    /// <summary>
    /// kezdeti idő
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime StartTime { get; set; }

    /// <summary>
    /// befejezési idő
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Porta id-ja
    /// </summary>
    /// <value>int</value>
    [Required]
    public Guid ReceptionId { get; set; }

    [ForeignKey("ReceptionId")]
    public virtual Reception Reception { get; set; }

    /// <summary>
    /// eszköz id-ja
    /// </summary>
    /// <value>nullable int</value>
    public Guid? DeviceId { get; set; }

    [ForeignKey("DeviceId")]
    public virtual Device Device { get; set; }

    /// <summary>
    /// eszköz típusának id-ja
    /// </summary>
    /// <value>nullable int</value>
    public Guid? DeviceTypeId { get; set; }

    [ForeignKey("DeviceTypeId")]
    public virtual DeviceType DeviceType { get; set; }

    /// <summary>
    /// if device type is added need an amount
    /// </summary>
    /// <value>nullable int</value>
    public int? Amount { get; set; }
}