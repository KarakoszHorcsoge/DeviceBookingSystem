using System.ComponentModel.DataAnnotations;
using back.enums.status;

namespace back.models.Devices;


public class DeviceAddUpdateRequest : BaseRequest{

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
    public Guid DeviceTypeId { get; set; }

    /// <summary>
    /// porta id-ja
    /// </summary>
    /// /// <value>int</value>
    [Required]
    public Guid ReceptionId { get; set; }

    /// <summary>
    /// A birtokos id-ja
    /// </summary>
    /// <value>nullable int</value>
    public Guid? PosesserId { get; set; }
}