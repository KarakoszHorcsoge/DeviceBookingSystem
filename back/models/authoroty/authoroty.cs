using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models{
/// <summary>
/// Jogosultsági szintek
/// </summary>
[Table("Authoroty")]
public class Authoroty : BaseModel{
    
    /// <summary>
    /// név<br/>
    /// </summary>
    /// <value>1 string 45</value>
    [Required,MinLength(1),MaxLength(45)]
    public string name { get; set; }

    /// <summary>
    /// jogosultsági szint
    /// </summary>
    /// <value>int</value>
    [Required]
    public int authorotyLevel { get; set; }
    
}




}