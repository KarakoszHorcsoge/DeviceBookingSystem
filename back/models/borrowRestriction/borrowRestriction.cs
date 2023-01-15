using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models;

public class borrowRestriction{
    /// <summary>
    /// kölcsönzési korlátozás id-ja
    /// </summary>
    /// <value>int</value>
    [Required,Key]
    public int BorrowRestrictionId { get; set; }
    
    /// <summary>
    /// Létrehozási idő
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime CreationTime { get; set; }

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
    [Required,ForeignKey("reception")]
    public int ReceptionId { get; set; }

    public virtual reception Reception { get; set; }

    /// <summary>
    /// eszköz id-ja
    /// </summary>
    /// <value>nullable int</value>
    [ForeignKey("device")]
    public int? DeviceId { get; set; }

    public virtual device? Device { get; set; }

    /// <summary>
    /// eszköz típusának id-ja
    /// </summary>
    /// <value>nullable int</value>
    [ForeignKey("deviceType")]
    public int? DeviceTypeId { get; set; }

    public virtual deviceType DeviceType { get; set; }

    /// <summary>
    /// if device type is added need an amount
    /// </summary>
    /// <value>nullable int</value>
    public int? Amount { get; set; }
    
    [Required]
    public int CreatorId { get; set; }

    /// <summary>
    /// létrehozó admin id-ja
    /// </summary>
    /// <value>int</value>
    [ForeignKey("administrator")]
    public virtual administrator Creator { get; set; }
}