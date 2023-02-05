using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.enums.status;
using back.models.BorrowRestrictions;
using back.models.DeviceTypes;
using back.models.Persons;
using back.models.Receptions;

namespace back.models.Devices;

/// <summary>
/// Eszközök
/// </summary>
[Table("Device")]
public class Device : BaseModel{

    /// <summary>
    /// az eszköz státusza
    /// </summary>
    /// <value>deviceStatus enum</value>
    public DeviceStatus DeviceStatus { get; set; }

    /// <summary>
    /// Megjegyzés
    /// </summary>
    /// <value>string 255</value>
    [MaxLength(255)]
    public string Comment { get; set; }

    /// <summary>
    /// eszköz tipusának id-ja
    /// </summary>
    /// <value>int</value>
    public Guid DeviceTypeId { get; set; }

    [ForeignKey("DeviceTypeId")]
    public virtual DeviceType DeviceType { get; set; }

    /// <summary>
    /// porta id-ja
    /// </summary>
    /// <value>int</value>
    public Guid? ReceptionId { get; set; }

    [ForeignKey("ReceptionId")]
    public virtual Reception Reception { get; set; }

    /// <summary>
    /// A birtokos id-ja
    /// </summary>
    /// <value>nullable int</value>
    public Guid? PosesserId { get; set; }

    [ForeignKey("PersonId")]
    public virtual Person Posesser { get; set; }

    public virtual ICollection<BorrowRestriction> BorrowRestrictions { get; set; }
}