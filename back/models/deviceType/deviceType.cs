using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.BorrowRestrictions;
using back.models.Devices;

namespace back.models.DeviceTypes;

/// <summary>
/// Eszköz típusának megadása
/// </summary>
[Table("DeviceType")]
public class DeviceType : BaseModel{

    /// <summary>
    /// az eszköz típusának neve
    /// </summary>
    /// <value>1 string 25</value>
    [ MinLength(1),MaxLength(25)]
    public string Name { get; set; }
    
    public virtual ICollection<Device> Devices { get; set; }
    public virtual ICollection<BorrowRestriction> BorrowRestrictions {get; set;}

}