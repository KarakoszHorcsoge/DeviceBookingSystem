using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Administrators;

namespace back.models;

public class BaseModel{
    [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public DateTime CreationTime { get; set; }

    public DateTime ModificationTime { get; set; }

    public Guid? CreatorId { get; set; }

    [ForeignKey("CreatorId")]
    public virtual Administrator Creator { get; set; }

    public Guid? ModifierId { get; set; }

    [ForeignKey("ModifierId")]
    public virtual Administrator Modifier { get; set; }
}