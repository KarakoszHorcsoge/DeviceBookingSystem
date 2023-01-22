namespace back.models.PersonType;

public class PersonTypeAddUpdateResponse : BaseRequestResponse
{
    PersonTypeGetResponse PersonType { get; set; }
}