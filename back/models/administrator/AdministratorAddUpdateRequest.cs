using System.ComponentModel.DataAnnotations;

namespace back.models.Administrators;

public class AdministratorAddUpdateRequest : BaseRequest
{

    /// <summary>
    /// név
    /// </summary>
    /// <value>1 string 45</value>
    [Required, MinLength(1), MaxLength(45)]
    public string Name { get; set; }

    /// <summary>
    /// email cím
    /// </summary>
    /// <value>1 string 100</value>
    [Required, EmailAddress, MinLength(1), MaxLength(100)]
    public string Email { get; set; }

    /// <summary>
    /// authorotyId<br/>
    /// referálja az authoroty táblát
    /// </summary>
    /// <value>int</value>
    [Required]
    public Guid AuthorotyId { get; set; }

}