
namespace back.models.Receptions;

public class ReceptionGetResponse{
    
    /// <summary>
    /// porta id-ja
    /// </summary>
    /// <value>1 string 50</value>
    public string Name { get; set; }

    /// <summary>
    /// Porta címe
    /// </summary>
    /// <value>1 string 100</value>
    public string Address { get; set; }

    /// <summary>
    /// megjegyzések
    /// </summary>
    /// <value>string 255</value>
    public string Comment { get; set; }

    /// <summary>
    /// A portáért felelős rendszergazda
    /// </summary>
    /// <value>int</value>
    public int AdminId { get; set; }
}
