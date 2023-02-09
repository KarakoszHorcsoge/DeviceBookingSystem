
using back.enums.status;
using back.models.DeviceTypes;
using back.models.Persons;
using back.models.Receptions;

namespace back.models.Devices;


public class DeviceGetResponse : BaseResponse{

    /// <summary>
    /// az eszköz státusza
    /// </summary>
    /// <value>deviceStatus enum</value>
    public DeviceStatus DeviceStatus { get; set; }

    /// <summary>
    /// Megjegyzés
    /// </summary>
    /// <value>string 255</value>
    public string Comment { get; set; }

    /// <summary>
    /// eszköz tipusának id-ja
    /// </summary>
    /// <value>int</value>
    public Guid DeviceTypeId { get; set; }

    public DeviceType DeviceType { get; set; }

    /// <summary>
    /// porta id-ja
    /// </summary>
    /// /// <value>int</value>
    public Guid ReceptionId { get; set; }

    public Reception Reception { get; set; }

    /// <summary>
    /// A birtokos id-ja
    /// </summary>
    /// <value>nullable int</value>
    public Guid? PosesserId { get; set; }

    public Person Posesser { get; set; }
}