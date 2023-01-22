namespace back.models.Persons;

public class PersonAddUpdateResponse : BaseRequestResponse
{
    PersonGetResponse Person { get; set; }
}