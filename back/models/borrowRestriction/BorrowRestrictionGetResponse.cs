namespace back.models.BorrowRestrictions;

public class BorrowRestrictionGetResponse : BaseResponse
{
    /// <summary>
    /// kezdeti idő
    /// </summary>
    /// <value>DateTime</value>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// befejezési idő
    /// </summary>
    /// <value>DateTime</value>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Porta id-ja
    /// </summary>
    /// <value>int</value>
    public Guid ReceptionId { get; set; }

    /// <summary>
    /// eszköz id-ja
    /// </summary>
    /// <value>nullable int</value>
    public Guid? DeviceId { get; set; }

    /// <summary>
    /// eszköz típusának id-ja
    /// </summary>
    /// <value>nullable int</value>
    public Guid? DeviceTypeId { get; set; }

    /// <summary>
    /// if device type is added need an amount
    /// </summary>
    /// <value>nullable int</value>
    public int? Amount { get; set; }
}