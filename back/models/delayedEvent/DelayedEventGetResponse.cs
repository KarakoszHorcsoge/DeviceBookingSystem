using System.ComponentModel.DataAnnotations;

namespace back.models.DelayedEvents;

public class DelayedEventGetResponse : BaseResponse
{
    /// <summary>
    /// neve a delayed eventnek, ha nem autómata
    /// </summary>
    /// <value>nullable 1 string 50</value>
    public string Name { get; set; }

    /// <summary>
    /// lefutási idő
    /// </summary>
    /// <value>DateTime</value>
    public DateTime ExecutionTime { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 255</value>
    public string Command { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 255</value>
    public string Comment { get; set; }
}