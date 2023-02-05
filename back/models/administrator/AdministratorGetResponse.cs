using System.ComponentModel.DataAnnotations;
using back.models.Authorotys;

namespace back.models.Administrators;

public class AdministratorGetResponse:BaseResponse
{
    /// <summary>
    /// név
    /// </summary>
    /// <value>1 string 45</value>
    public string Name { get; set; }

    /// <summary>
    /// email cím
    /// </summary>
    /// <value>1 string 100</value>
    public string Email { get; set; }

    /// <summary>
    /// authorotyId<br/>
    /// referálja az authoroty táblát
    /// </summary>
    /// <value>int</value>
    public Guid AuthorotyId { get; set; }

    public virtual Authoroty Authoroty {get; set;}
}