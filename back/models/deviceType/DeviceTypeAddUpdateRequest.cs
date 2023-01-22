using System.ComponentModel.DataAnnotations;

namespace back.models.DeviceTypes;

public class DeviceTypeAddUpdateRequest : BaseRequest{

    /// <summary>
    /// az eszköz típusának neve
    /// </summary>
    /// <value>1 string 25</value>
    [Required, MinLength(1),MaxLength(25)]
    public string Name { get; set; }
    
}