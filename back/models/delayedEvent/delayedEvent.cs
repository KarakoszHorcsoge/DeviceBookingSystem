using System.ComponentModel.DataAnnotations;

namespace back.models;

public class delayedEvent{
    /// <summary>
    /// késleltetett események id
    /// </summary>
    /// <value>int autoincrement</value>
    [Required]
    public int DelayedEventId { get; set; }

    /// <summary>
    /// neve a delayed eventnek, ha nem autómata
    /// </summary>
    /// <value>nullable 1 string 50</value>
    [MinLength(1),MaxLength(50)]
    public string? Name { get; set; }

    /// <summary>
    /// Létrehozási idő
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// lefutási idő
    /// </summary>
    /// <value>DateTime</value>
    [Required]
    public DateTime ExecutionTime { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 255</value>
    [Required,MaxLength(255)]
    public string Comment { get; set; }

    /// <summary>
    /// létrehozó id
    /// </summary>
    /// <value>int</value>
    [Required]
    public int CreatorId { get; set; }

    public administrator Creator { get; set; }
}