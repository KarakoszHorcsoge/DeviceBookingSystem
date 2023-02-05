using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Administrators;
using back.models.BorrowRestrictions;
using back.models.Devices;

namespace back.models.Receptions;

/// <summary>
/// Recepció
/// </summary>
[Table("Reception")]
public class Reception : BaseModel{

    /// <summary>
    /// porta id-ja
    /// </summary>
    /// <value>1 string 50</value>
    [MinLength(1),MaxLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Porta címe
    /// </summary>
    /// <value>1 string 100</value>
    [MinLength(1),MaxLength(100)]
    public string Address { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 255</value>
    [MaxLength(255)]
    public string Comment { get; set; }

    /// <summary>
    /// A portáért felelős rendszergazda
    /// </summary>
    /// <value>int</value>
    public Guid? AdminId { get; set; }

    [ForeignKey("administrator")]
    public virtual Administrator Admin { get; set; }

    public virtual ICollection<Device> Devices { get; set; }
    public virtual ICollection<BorrowRestriction> BorrowRestrictions { get; set; }
}