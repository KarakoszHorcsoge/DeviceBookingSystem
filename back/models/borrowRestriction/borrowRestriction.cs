using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models;

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
    public int ReceptionId { get; set; }

    [ForeignKey("ReceptionId")]
    public virtual Reception Reception { get; set; }

    /// <summary>
    /// eszköz id-ja
    /// </summary>
    /// <value>nullable int</value>
    public int? DeviceId { get; set; }

    [ForeignKey("deviceId")]
    public virtual Device Device { get; set; }

    /// <summary>
    /// eszköz típusának id-ja
    /// </summary>
    /// <value>nullable int</value>
    public int? DeviceTypeId { get; set; }

    [ForeignKey("DeviceType")]
    public virtual DeviceType DeviceType { get; set; }

    /// <summary>
    /// if device type is added need an amount
    /// </summary>
    /// <value>nullable int</value>
    public int? Amount { get; set; }
}