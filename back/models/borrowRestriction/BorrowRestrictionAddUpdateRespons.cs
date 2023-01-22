namespace back.models.BorrowRestrictions;

public class BorrowRestrictionAddUpdateResponse : BaseRequestResponse
{
    BorrowRestrictionGetResponse BorrowRestriction { get; set; }
}