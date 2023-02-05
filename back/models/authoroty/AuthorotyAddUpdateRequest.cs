namespace back.models.Authorotys;

public class AuthorotyAddUpdateRequest : BaseRequest
{

    /// <summary>
    /// név<br/>
    /// </summary>
    /// <value>1 string 45</value>
    public string Name { get; set; }

    /// <summary>
    /// jogosultsági szint
    /// </summary>
    /// /// <value>int</value>
    public int AuthorotyLevel { get; set; }
}