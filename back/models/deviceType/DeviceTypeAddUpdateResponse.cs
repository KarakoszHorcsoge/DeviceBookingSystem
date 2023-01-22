
namespace back.models.DeviceTypes;

public class DeviceTypeAddUpdateResponse : BaseRequestResponse{
    DeviceTypeGetResponse DeviceType { get; set; }
}