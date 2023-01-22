using back.enums.status;

namespace back.models.PersonGroups;

public class PersonGroupGetResponse : BaseResponse{

    /// <summary>
    /// Személy csoport neve 
    /// </summary>
    /// <value></value>
    public string Name { get; set; }

    /// <summary>
    /// státusz
    /// </summary>
    /// <value>enum (inactive,active,temporarilyActive,partiallyActive)</value>
    public PersonGroupStatus status { get; set; }

    /// <summary>
    /// Megjegyzés
    /// </summary>
    /// <value>string 255</value>
    public string comment { get; set; }
}