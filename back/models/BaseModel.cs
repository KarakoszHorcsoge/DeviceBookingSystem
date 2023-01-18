using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models;

public class BaseModel{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime CreationTime { get; set; }

    public DateTime ModificationTime { get; set; }

    public Guid CreatorId { get; set; }

    [ForeignKey("CreatorId")]
    public Administrator Creator { get; set; }
}