
namespace back.models.Preferences;

public class PreferenceAddUpdateResponse : BaseRequestResponse{
    public PreferenceGetResponse Preference { get; set; }
}