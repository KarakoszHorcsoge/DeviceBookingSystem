using System.ComponentModel.DataAnnotations;

namespace back.models.DeviceTypes;

public class DeviceTypeGetResponse : BaseResponse{

    /// <summary>
    /// az eszköz típusának neve
    /// </summary>
    /// <value>1 string 25</value>
    public string Name { get; set; }
    
}