using System.ComponentModel.DataAnnotations;

namespace back.models.Preferences;

public class PreferenceGetResponse : BaseResponse{

    /// <summary>
    /// preferencia neve
    /// </summary>
    /// <value>1 string 25</value>
    public string Name { get; set; }

    /// <summary>
    /// preferencia értéke
    /// </summary>
    /// <value>1 string 100</value>
    public string Value { get; set; }

}