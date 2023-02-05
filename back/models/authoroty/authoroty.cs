using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Administrators;

namespace back.models.Authorotys;
/// <summary>
/// Jogosultsági szintek
/// </summary>
[Table("Authoroty")]
public class Authoroty : BaseModel
{

    /// <summary>
    /// név<br/>
    /// </summary>
    /// <value>1 string 45</value>
    [MinLength(1), MaxLength(45)]
    public string Name { get; set; }

    /// <summary>
    /// jogosultsági szint
    /// </summary>
    /// <value>int</value>
    public int AuthorotyLevel { get; set; }

    public virtual ICollection<Administrator> Administrators { get; set; }

}