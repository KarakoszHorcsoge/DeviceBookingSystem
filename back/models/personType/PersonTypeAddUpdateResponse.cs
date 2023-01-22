namespace back.models.PersonTypes;

public class PersonTypeAddUpdateResponse : BaseRequestResponse
{
    PersonTypeGetResponse PersonType { get; set; }
}