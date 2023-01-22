using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back.models.Administrators;

namespace back.models;

public class BaseModel{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime CreationTime { get; set; }

    [Required]
    public DateTime ModificationTime { get; set; }

    [Required]
    public Guid CreatorId { get; set; }

    [ForeignKey("CreatorId")]
    public Administrator Creator { get; set; }

    [Required]
    public Guid ModifierId { get; set; }

    [ForeignKey("ModifierId")]
    public Administrator Modifier { get; set; }
}