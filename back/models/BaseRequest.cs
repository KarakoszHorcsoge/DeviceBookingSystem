namespace back.models;

public class BaseRequest{
    /// <summary>
    /// Amikor eredetileg ell lett küldve a kérelem
    /// </summary>
    /// <value></value>
    public DateTime OriginalSendTime { get; set; }

    public Guid CreatorId { get; set; }

    public Guid ModifierId { get; set; }
}