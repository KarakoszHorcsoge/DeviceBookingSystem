using System.ComponentModel.DataAnnotations;

namespace back.models{

public class authoroty{
    /// <summary>
    /// jogosultsági szint id<br/>
    /// </summary>
    /// <value>auto increment, intiger</value>
    [Required]
    public int authorotyid { get; set; }

    /// <summary>
    /// név<br/>
    /// 
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