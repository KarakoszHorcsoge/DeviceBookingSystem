using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.models.DelayedEvents;


public class DelayedEventAddUpdateRequest : BaseRequest
{
    /// <summary>
    /// neve a delayed eventnek, ha nem autómata
    /// </summary>
    /// <value>nullable 1 string 50</value>
    [Required, MinLength(1), MaxLength(50)]
    public string Name { get; set; }

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
    [Required]
    public string Command { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 255</value>
    [Required, MaxLength(255)]
    public string Comment { get; set; }
}