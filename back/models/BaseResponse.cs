using back.models.Administrators;

namespace back.models;

public class BaseResponse{
    public Guid Id { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime ModificationTime { get; set; }

    public Guid? CreatorId { get; set; }

    public virtual Administrator Creator { get; set; }

    public Guid? ModifierId { get; set; }

    public virtual Administrator Modifier { get; set; }

    
}