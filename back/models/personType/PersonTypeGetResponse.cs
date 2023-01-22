namespace back.models.PersonTypes;

public class PersonTypeGetResponse : BaseResponse{

    /// <summary>
    /// neve a személy típusnak
    /// </summary>
    /// <value>1 string 25</value>
    public string Name { get; set; }

    /// <summary>
    /// tud-e kölcsönözni
    /// </summary>
    /// <value>bool</value>
    public bool IsBorrowable { get; set; }

    /// <summary>
    /// a kártya vonalkódjának előtagja
    /// </summary>
    /// <value> string 2</value>
    public string CardPrefix { get; set; }

    /// <summary>
    /// megjegyzés
    /// </summary>
    /// <value>string 255</value>
    public string Comment { get; set; }
}